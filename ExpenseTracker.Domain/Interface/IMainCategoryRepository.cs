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
    }
}
