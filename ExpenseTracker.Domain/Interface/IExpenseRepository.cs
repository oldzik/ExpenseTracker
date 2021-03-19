using ExpenseTracker.Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpenseTracker.Domain.Interface
{
    public interface IExpenseRepository
    {
        public Expense GetExpenseById(int expenseId);
        public int AddExpense(Expense exp);
        public void DeleteExpense(int expenseId);
        public void UpdateExpense(Expense expense);
        public IQueryable<Expense> GetAllExpensesOfBudget(int budgetId);
        IQueryable<Expense> GetAllExpensesOfDetailedCategory(int detailedCategoryId);
        IQueryable<Expense> GetAllExpensesOfMainCategoryPerMonth(int mainCatId, DateTime monthOfYear);
        IQueryable<Expense> GetAllExpensesOfDetailedCategoryPerMonth(int detailedCatId, DateTime monthOfYear);
    }
}
