using ExpenseTracker.Domain.Interface;
using ExpenseTracker.Domain.Model.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpenseTracker.Infrastructure.Repositories
{
    public class DetailedCategoryRepository : IDetailedCategoryRepository
    {
        private readonly Context _context;
        public DetailedCategoryRepository(Context context)
        {
            _context = context;
        }

        public void AddDetailedCategories(List<DetailedCategory> detailedCategories)
        {
            _context.DetailedCategories.AddRange(detailedCategories);
            _context.SaveChanges();
        }

        public IEnumerable<SelectListItem> GetDetailedCategoriesOfUser(string userId)
        {
            List<SelectListItem> categories = _context.DetailedCategories
                .Where(c => c.MainCategory.ApplicationUserId==userId).AsNoTracking()
                .OrderBy(n => n.Name)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.Name
                }).ToList();
            return new SelectList(categories, "Value", "Text");
                
        }
    }
}
