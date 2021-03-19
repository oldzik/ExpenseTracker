using ExpenseTracker.Domain.Interface;
using ExpenseTracker.Domain.Model.Entity;
using Microsoft.EntityFrameworkCore;
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

        public Expense GetExpenseById(int expenseId)
        {
            var expense = _context.Expenses.AsNoTracking().FirstOrDefault(e => e.Id == expenseId);
            return expense;
        }

        public int AddExpense(Expense exp)
        {
            _context.Expenses.Add(exp);
            _context.SaveChanges();
            return exp.Id;
        }

        public void DeleteExpense(int expenseId)
        {
            var expense = _context.Expenses.Find(expenseId);
            if(expense != null)
            {
                _context.Expenses.Remove(expense);
                _context.SaveChanges();
            }
        }

        public IQueryable<Expense> GetAllExpensesOfBudget(int budgetId)
        {
            var expenses = _context.Expenses.Where(e => e.BudgetId == budgetId);
            return expenses;
        }

        public IQueryable<Expense> GetAllExpensesOfDetailedCategory(int detailedCategoryId)
        {
            var expenses = _context.Expenses.Where(e => e.DetailedCategoryId == detailedCategoryId);
            return expenses;
        }

        public IQueryable<Expense> GetAllExpensesOfDetailedCategoryPerMonth(int detailedCatId, DateTime monthOfYear)
        {
            var expenses = _context.Expenses
                .Where(e => e.DetailedCategoryId == detailedCatId
                && e.Date >= monthOfYear && e.Date < monthOfYear.AddMonths(1));
            return expenses;
        }

        public IQueryable<Expense> GetAllExpensesOfMainCategoryPerMonth(int mainCatId, DateTime monthOfYear)
        {
            var expenses = _context.Expenses
                .Where(e => e.DetailedCategory.MainCategoryId == mainCatId 
                && e.Date >= monthOfYear && e.Date < monthOfYear.AddMonths(1));
            return expenses;
        }

        public void UpdateExpense(Expense expense)
        {
            //the update statement only updates the values that were actually changed 
            //after you attached the entity to the context
            _context.Attach(expense);
            _context.Entry(expense).Property("Name").IsModified = true;
            _context.Entry(expense).Property("Date").IsModified = true;
            _context.Entry(expense).Property("Amount").IsModified = true;
            _context.SaveChanges();
        }
    }
}
