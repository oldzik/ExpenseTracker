using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Application.ViewModels.PlannedExpense;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ExpenseTracker.Web.Controllers
{
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
        public IActionResult PlanExpensesPerMonth()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim.Value;

            var model = _plannedExpService.CreateNewPlannedExpPerMonth(userId);
            return View(model);
        }

        [HttpPost]
        public IActionResult PlanExpensesPerMonth(ListNewPlannedExpensePerMonthVm model)
        {
            _plannedExpService.AddPlannedExpensesPerMonth(model);
            return RedirectToAction("Index", "Expense");
        }
    }
}
