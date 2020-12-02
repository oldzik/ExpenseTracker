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
        public void AddToSum(int expenseId);
        public void RemoveFromSum(int expenseId);
        public void EditSum(EditExpenseVm model);
        public decimal SumAllExpensesAmountsOfDetailedCategories(List<DetailedCategory> detCategories);
        void RemoveFromSumBeforeCategoryDelete(Budget budget,decimal sumToRemoveFromBudget);
        Budget GetBudgetOfMainCategory(int mainCategoryId);
        decimal SumAllExpensesAmountsOfDetailedCategory(DetailedCategory detCategory);
    }
}
