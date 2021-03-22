using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Application.ViewModels.Expense;
using ExpenseTracker.Domain.Model.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ExpenseTracker.Web.Controllers
{
    [Authorize(Roles ="User")]
    public class ExpenseController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<ExpenseController> _logger;
        private readonly IExpenseService _expenseService;
        private readonly IBudgetService _budgetService;

        public ExpenseController(ILogger<ExpenseController> logger, IExpenseService expenseService, IBudgetService budgetSerivce, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _expenseService = expenseService;
            _budgetService = budgetSerivce;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            DateTime currentDate = DateTime.Today;

            //Get all expenses of current month
            var expensesModel = _expenseService.GetAllExpensesForList(currentDate, userId);
            return View(expensesModel);
        }

        [HttpPost]
        public IActionResult Index(DateTime chosenDate, string userId)
        {
            //Get all expenses of chosen month
            var expensesModel = _expenseService.GetAllExpensesForList(chosenDate, userId);
            return View(expensesModel);
        }

        [HttpGet]
        public IActionResult CreateExpense()
        {
            var userId = _userManager.GetUserId(HttpContext.User);

            //Create view model (with user's categories and userId) for new expense
            NewExpenseVm model = _expenseService.CreateNewExpense(userId);
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateExpense(NewExpenseVm model)
        {
            //Try to add expense to the database. If success, add amount to the user's budget.
            var id = _expenseService.AddExpense(model);
            if(id != 0)
            {
                _budgetService.ChangeSum(id, 1);
            }

            return RedirectToAction("Index");
        }

        public IActionResult DeleteExpense(int expenseId)
        {
            //Subtract amount from budget and delete expense from db
            _budgetService.ChangeSum(expenseId, -1);
            _expenseService.DeleteExpense(expenseId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditExpense(int expenseId)
        {
            //Get expense from db, display view to edit
            var expense = _expenseService.GetExpenseForEdit(expenseId);
            return View(expense);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditExpense(EditExpenseVm model)
        {
            if(ModelState.IsValid)
            {
                _budgetService.EditSum(model);
                _expenseService.UpdateExpense(model);
                return RedirectToAction("ShowChosenMonth", new {chosenDate = model.Date });
            }

            return View(model);
        }

        public IActionResult ShowChosenMonth(DateTime chosenDate)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var expensesModel = _expenseService.GetAllExpensesForList(chosenDate, userId);
            return View("Index", expensesModel);
        }

        public IActionResult GetExpensesOfDetailedCatPerMonth(string monthOfYear, int detailedCategoryId)
        {
            DateTime date = DateTime.Parse(monthOfYear);
            var model = _expenseService.GetAllExpensesOfDetCatPerMonth(date, detailedCategoryId);
            return View(model);
        }
    }
}
