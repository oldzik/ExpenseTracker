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
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim.Value;

            string currentMonthStr = "01." + DateTime.Today.Month + "." + DateTime.Today.Year;
            DateTime currentMonth = DateTime.ParseExact(currentMonthStr, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            var expensesModel = _expenseService.GetAllExpensesForList(currentMonth,userId);
            return View(expensesModel);
        }

        [HttpPost]
        public IActionResult Index(DateTime monthOfYear, string userId)
        {
            var expensesModel = _expenseService.GetAllExpensesForList( monthOfYear, userId);
            return View(expensesModel);

        }

        [HttpGet]
        public IActionResult CreateExpense()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim.Value;

            NewExpenseVm model = _expenseService.CreateNewExpense(userId);
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateExpense(NewExpenseVm model)
        {
            var id = _expenseService.AddExpense(model);
            if(id != 0)
            {
                _budgetService.AddToSum(id);
            }

            return RedirectToAction("Index");
        }

        public IActionResult DeleteExpense(int expenseId)
        {
            _budgetService.RemoveFromSum(expenseId);
            _expenseService.DeleteExpense(expenseId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditExpense(int expenseId)
        {
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
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult GetExpensesOfDetailedCatPerMonth(DateTime monthOfYear, int detailedCategoryId)
        {
            var model = _expenseService.GetAllExpensesForListDetCatPerMonth(monthOfYear, detailedCategoryId);
            return View(model);
        }

    }
}
