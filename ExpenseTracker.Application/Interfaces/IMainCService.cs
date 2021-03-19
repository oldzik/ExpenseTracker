using ExpenseTracker.Application.ViewModels.MainCategory;
using ExpenseTracker.Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Interfaces
{
    public interface IMainCService
    {
        public void CreateMainCategoriesForNewUser(string userId);
        ListMainCatForListVm GetMainCategoriesForList(string userId);
        int AddMainCategory(NewMainCategoryVm model, string userId);
        NewMainCategoryVm GetMainCategoryForEdit(int mainCategoryId);
        public void UpdateMainCategory(NewMainCategoryVm model);
        void DeleteMainCategory(int mainCategoryId);
    }
}
