using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Application.ViewModels.PlannedExpense;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "User")]
    public class PlannedExpenseController : Controller
    {
        private readonly ILogger<PlannedExpenseController> _logger;
        private readonly IPlannedExpenseService _plannedExpService;
        public PlannedExpenseController(ILogger<PlannedExpenseController> logger, IPlannedExpenseService plannedExpService)
        {
            _logger = logger;
            _plannedExpService = plannedExpService;
        }

        public IActionResult Index(DateTime monthOfYear)
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim.Value;

            var model =  _plannedExpService.GetPlannedExpensesOfAllMainCPerMonth(monthOfYear, userId);
            return View(model);

        }

        [HttpGet]
        public IActionResult PlanExpensesPerMonth(DateTime monthOfYear)
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim.Value;

            var model = _plannedExpService.CreateNewPlannedExpPerMonth(monthOfYear,userId);
            return View(model);
        }

        [HttpPost]
        public IActionResult PlanExpensesPerMonth(ListNewPlannedExpensePerMonthVm model)
        {
            _plannedExpService.AddPlannedExpensesPerMonth(model);
            return RedirectToAction("Index", "PlannedExpense", new { monthOfYear = model.MonthOfYear });
        }

        public IActionResult GetPlannedExpensesOfMainCategory(DateTime monthOfYear, int mainCategoryId)
        {
            var model = _plannedExpService.GetPlannedExpensesOfMainCPerMonth(monthOfYear, mainCategoryId);
            return View(model);
        }

        [HttpGet]
        public IActionResult EditPlannedExpsOfDetailedCatPerMonth(int plannedExpenseId)
        {
            var plannedExpense = _plannedExpService.GetPlannedExpForEdit(plannedExpenseId);
            return View(plannedExpense);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPlannedExpsOfDetailedCatPerMonth(PlannedExpenseForEditVm model)
        {
            if (ModelState.IsValid)
            {
                _plannedExpService.UpdatePlannedExpense(model);
                return RedirectToAction("GetPlannedExpensesOfMainCategory", new { monthOfYear=model.MonthOfYear,mainCategoryId=model.MainCategoryId});
            }

            return View(model);
        }


    }
}
