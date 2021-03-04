using ExpenseTracker.Application.ViewModels.Expense;
using ExpenseTracker.Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpenseTracker.Application.Interfaces
{
    public interface IExpenseService
    {
        public ListExpenseForListVm GetAllExpensesForList(DateTime monthOfYear ,string userId);
        public NewExpenseVm CreateNewExpense(string UserId);
        public int AddExpense(NewExpenseVm model);
        public void DeleteExpense(int expenseId);
        public EditExpenseVm GetExpenseForEdit(int expenseId);
        public void UpdateExpense(EditExpenseVm model);
        public ListPerMonthDetCatExpenseForListVm GetAllExpensesForListDetCatPerMonth(DateTime monthOfYear, int detailedCategoryId);
        public DateTime FirstDayOfMonthFromDateTime(DateTime dateTime);
    }
}
