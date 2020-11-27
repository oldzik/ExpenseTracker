using ExpenseTracker.Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpenseTracker.Domain.Interface
{
    public interface IExpenseRepository
    {
        public IQueryable<Expense> GetAllExpensesOfBudget(int budgetId);
    }
}
