using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Domain.Model.Entity;
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
    public class ExpenseController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<ExpenseController> _logger;
        private readonly IExpenseService _expenseService;

        public ExpenseController(ILogger<ExpenseController> logger, IExpenseService expenseService, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _expenseService = expenseService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim.Value;

            var expensesModel = _expenseService.GetAllExpensesForList(userId);
            return View(expensesModel);
        }
    }
}
