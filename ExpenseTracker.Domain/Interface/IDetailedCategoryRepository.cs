using ExpenseTracker.Domain.Model.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ExpenseTracker.Domain.Interface
{
    public interface IDetailedCategoryRepository
    {
        public void AddDetailedCategories(List<DetailedCategory> detailedCategories);
        public IEnumerable<SelectListItem> GetDetailedCategoriesOfUser(string userId);
    }
}
