using ExpenseTracker.Application.ViewModels.Expense;
using ExpenseTracker.Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Interfaces
{
    public interface IBudgetService
    {
        public void CreateBudgetForNewUser(string userId);
        public bool ChangeSum(int expenseId, int operation);
        public void EditSum(EditExpenseVm model);
        public void RemoveFromSumBeforeMainCategoryDelete(int mainCategoryId);
        public void RemoveFromSumBeforeDetailedCategoryDelete(int detCategoryId);
    }
}
