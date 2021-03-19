using ExpenseTracker.Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpenseTracker.Domain.Interface
{
    public interface IMainCategoryRepository
    {
        public void AddMainCategories(List<MainCategory> mainCategories);
        public IQueryable<MainCategory> GetAllMainCategoriesOfUser(string userId);
        public int AddMainCategory(MainCategory mainCat);
        MainCategory GetMainCategoryById(int mainCategoryId);
        void UpdateMainCategory(MainCategory mainCategory);
        void DeleteMainCategory(int mainCategoryId);
        string GetMainCategoryNameById(int mainCategoryId);
    }
}
