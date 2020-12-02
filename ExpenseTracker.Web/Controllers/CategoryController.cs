using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Application.ViewModels.DetailedCategory;
using ExpenseTracker.Application.ViewModels.MainCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ExpenseTracker.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<ExpenseController> _logger;
        private readonly IExpenseService _expenseService;
        private readonly IBudgetService _budgetService;
        private readonly IMainCService _mainCService;
        private readonly IDetailedCService _detailedCService;

        public CategoryController(ILogger<ExpenseController> logger, IExpenseService expenseService, IBudgetService budgetSerivce, IMainCService mainCService, IDetailedCService detailedCService)
        {
            _logger = logger;
            _expenseService = expenseService;
            _budgetService = budgetSerivce;
            _mainCService = mainCService;
            _detailedCService = detailedCService;
        }

        public IActionResult Index()
        {

            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim.Value;

            var model = _mainCService.GetMainCategoriesForList(userId);
            return View(model);

        }

        public IActionResult DetailedCategory(int mainCategoryId)
        {

            var model = _detailedCService.GetDetailedCategoriesForList(mainCategoryId);
            return View(model);
        }

        [HttpGet]
        public IActionResult CreateMainCategory()
        {
            return View(new NewMainCategoryVm());
        }

        [HttpPost]
        public IActionResult CreateMainCategory(NewMainCategoryVm model)
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim.Value;

            var id = _mainCService.AddMainCategory(model, userId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditMainCategory(int mainCategoryId)
        {
            var mainCategory = _mainCService.GetMainCategoryForEdit(mainCategoryId);
            return View(mainCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditMainCategory(NewMainCategoryVm model)
        {
            if(ModelState.IsValid)
            {
                _mainCService.UpdateMainCategory(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult DeleteMainCategory(int mainCategoryId)
        {
            var detCategories = _detailedCService.GetDetailedCategoriesOfMainCategory(mainCategoryId);
            var sumToRemoveFromBudget = _budgetService.SumAllExpensesAmountsOfDetailedCategories(detCategories);
            var budget = _budgetService.GetBudgetOfMainCategory(mainCategoryId);
            _budgetService.RemoveFromSumBeforeCategoryDelete(budget, sumToRemoveFromBudget);

            _mainCService.DeleteMainCategory(mainCategoryId);
            return RedirectToAction("Index");
        }

        //DETAILED CATEGORIES
        [HttpGet]
        public IActionResult CreateDetailedCategory(int mainCategoryId)
        {
            return View(new NewDetailedCategoryVm() {MainCategoryId=mainCategoryId });
        }

        [HttpPost]
        public IActionResult CreateDetailedCategory(NewDetailedCategoryVm model)
        {
            var id = _detailedCService.AddDetailedCategory(model);
            return RedirectToAction("DetailedCategory", new { mainCategoryId = model.MainCategoryId});
        }

        [HttpGet]
        public IActionResult EditDetailedCategory(int detailedCategoryId)
        {
            var detailedCategory = _detailedCService.GetDetailedCategoryForEdit(detailedCategoryId);
            return View(detailedCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditDetailedCategory(NewDetailedCategoryVm model)
        {
            if (ModelState.IsValid)
            {
                _detailedCService.UpdateDetailedCategory(model);
                return RedirectToAction("DetailedCategory", new { mainCategoryId = model.MainCategoryId });
            }
            return View(model);
        }

        public IActionResult DeleteDetailedCategory(int detailedCategoryId)
        {
            var detCategory = _detailedCService.GetDetailedCategoryById(detailedCategoryId);
            int mainCatId = detCategory.MainCategoryId;

            var sumToRemoveFromBudget = _budgetService.SumAllExpensesAmountsOfDetailedCategory(detCategory);
            var budget = _budgetService.GetBudgetOfMainCategory(mainCatId);
            _budgetService.RemoveFromSumBeforeCategoryDelete(budget, sumToRemoveFromBudget);

            _detailedCService.DeleteDetailedCategory(detailedCategoryId);
            return View("DetailedCategory", new { mainCategoryId = mainCatId });
        }


    }
}
