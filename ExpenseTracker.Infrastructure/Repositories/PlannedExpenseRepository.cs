using ExpenseTracker.Domain.Interface;
using ExpenseTracker.Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpenseTracker.Infrastructure.Repositories
{
    public class PlannedExpenseRepository : IPlannedExpenseRepository
    {
        private readonly Context _context;
        public PlannedExpenseRepository (Context context)
        {
            _context = context;
        }

        public void AddPlannedExpenses(List<PlannedExpense> newPlannedExpenses)
        {
            _context.PlannedExpenses.AddRange(newPlannedExpenses);
            _context.SaveChanges();
        }

        public IQueryable<PlannedExpense> GetAllPlannedExpensesOfMainCat(int mainCatId, DateTime monthOfYear)
        {
            var plannedExps = _context.PlannedExpenses
                .Where(e => e.DetailedCategory.MainCategoryId == mainCatId && e.MonthOfYear == monthOfYear);
            return plannedExps;
        }
    }
}
