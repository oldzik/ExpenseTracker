using ExpenseTracker.Domain.Interface;
using ExpenseTracker.Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpenseTracker.Infrastructure.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly Context _context;
        public ExpenseRepository(Context context)
        {
            _context = context;
        }

        public IQueryable<Expense> GetAllExpensesOfBudget(int budgetId)
        {
            var expenses = _context.Expenses.Where(e => e.BudgetId == budgetId);
            return expenses;
        }
    }
}
