using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Application.ViewModels.DetailedCategory;
using ExpenseTracker.Application.ViewModels.MainCategory;
using ExpenseTracker.Domain.Model.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ExpenseTracker.Web.Controllers
{
    [Authorize(Roles = "User")]
    public class CategoryController : Controller
    {
        private readonly ILogger<ExpenseController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IBudgetService _budgetService;
        private readonly IMainCService _mainCService;
        private readonly IDetailedCService _detailedCService;

        public CategoryController(ILogger<ExpenseController> logger, UserManager<ApplicationUser> userManager, IBudgetService budgetSerivce, IMainCService mainCService, IDetailedCService detailedCService)
        {
            _logger = logger;
            _userManager = userManager;
            _budgetService = budgetSerivce;
            _mainCService = mainCService;
            _detailedCService = detailedCService;
        }

        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var model = _mainCService.GetMainCategoriesForList(userId);
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
            var userId = _userManager.GetUserId(HttpContext.User);
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
            _budgetService.RemoveFromSumBeforeMainCategoryDelete(mainCategoryId);
            _mainCService.DeleteMainCategory(mainCategoryId);
            return RedirectToAction("Index");
        }


        //DETAILED CATEGORIES
        public IActionResult DetailedCategories(int mainCategoryId)
        {
            var model = _detailedCService.GetDetailedCategoriesForList(mainCategoryId);
            return View(model);
        }

        [HttpGet]
        public IActionResult CreateDetailedCategory(int mainCategoryId)
        {
            var model = _detailedCService.GetNewDetailedCategoryToCreate(mainCategoryId);

            return View(model);
        }

        [HttpPost]
        public IActionResult CreateDetailedCategory(NewDetailedCategoryVm model)
        {
            var id = _detailedCService.AddDetailedCategory(model);
            return RedirectToAction("DetailedCategories", new { mainCategoryId = model.MainCategoryId});
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
                return RedirectToAction("DetailedCategories", new { mainCategoryId = model.MainCategoryId });
            }
            return View(model);
        }

        public IActionResult DeleteDetailedCategory(int detailedCategoryId, int mainCatId)
        {
            _budgetService.RemoveFromSumBeforeDetailedCategoryDelete(detailedCategoryId);
            _detailedCService.DeleteDetailedCategory(detailedCategoryId);
            return RedirectToAction("DetailedCategories", new { mainCategoryId = mainCatId });
        }
    }
}
