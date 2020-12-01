using ExpenseTracker.Application.ViewModels.DetailedCategory;
using ExpenseTracker.Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpenseTracker.Application.Interfaces
{
    public interface IDetailedCService
    {
        public void CreateDetailedCategoriesForNewUser(string userId);
        ListDetailedCatForListVm GetDetailedCategoriesForList(int mainCategoryId);
       List<DetailedCategory> GetDetailedCategoriesOfMainCategory(int mainCategoryId);
    }
}
