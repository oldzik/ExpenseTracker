using ExpenseTracker.Application.ViewModels.Expense;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Interfaces
{
    public interface IBudgetService
    {
        public void CreateBudgetForNewUser(string userId);
        public void AddToSum(int expenseId);
        public void RemoveFromSum(int expenseId);
        public void EditSum(EditExpenseVm model);
    }
}
