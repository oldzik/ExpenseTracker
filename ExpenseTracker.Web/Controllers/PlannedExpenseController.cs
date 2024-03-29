﻿using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Application.ViewModels.PlannedExpense;
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
    [Authorize(Roles = "User")]
    public class PlannedExpenseController : Controller
    { 
        private readonly ILogger<PlannedExpenseController> _logger;
        private readonly IPlannedExpenseService _plannedExpService;
        private readonly UserManager<ApplicationUser> _userManager;
        public PlannedExpenseController(ILogger<PlannedExpenseController> logger, IPlannedExpenseService plannedExpService, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _plannedExpService = plannedExpService;
            _userManager = userManager;
        }

        public IActionResult Index(string currentDate)
        {
            DateTime date = DateTime.Parse(currentDate);
            var userId = _userManager.GetUserId(HttpContext.User);

            var model =  _plannedExpService.GetPlannedExpensesOfAllMainCPerMonth(date, userId);
            return View(model);

        }

        public IActionResult GetPlannedExpensesOfMainCategory(string monthOfYear, int mainCategoryId)
        {
            DateTime parsedDate = DateTime.Parse(monthOfYear);
            var model = _plannedExpService.GetPlannedExpensesOfMainCPerMonth(parsedDate, mainCategoryId);
            return View(model);
        }

        [HttpGet]
        public IActionResult PlanExpensesPerMonth(DateTime monthOfYear)
        {
            var userId = _userManager.GetUserId(HttpContext.User);

            var model = _plannedExpService.CreateNewPlannedExpPerMonth(monthOfYear,userId);
            return View(model);
        }

        [HttpPost]
        public IActionResult PlanExpensesPerMonth(ListNewPlannedExpensePerMonthVm model)
        {
            _plannedExpService.AddPlannedExpensesPerMonth(model);
            return RedirectToAction("Index", "PlannedExpense", new { currentDate = model.MonthOfYear.ToString("d") });
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
                return RedirectToAction("GetPlannedExpensesOfMainCategory", new { monthOfYear=model.MonthOfYear.ToString("d"),mainCategoryId=model.MainCatId});
            }
            return View(model);
        }
    }
}
