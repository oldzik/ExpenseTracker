using ExpenseTracker.Domain.Interface;
using ExpenseTracker.Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpenseTracker.Infrastructure.Repositories
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly Context _context;
        public BudgetRepository(Context context)
        {
            _context = context;
        }

        public int AddBudget(Budget budget)
        {
            _context.Budgets.Add(budget);
            _context.SaveChanges();
            return budget.Id;
        }

        public Budget GetBudgetByUserId(string userId)
        {
            var budget = _context.Budgets.FirstOrDefault(a => a.ApplicationUserRef == userId);
            return budget;
        }
    }
}
