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

        public int AddDetailedCategory(DetailedCategory detCategory)
        {
            _context.DetailedCategories.Add(detCategory);
            _context.SaveChanges();
            return detCategory.Id;
        }

        public void DeleteDetailedCategory(int detailedCategoryId)
        {
            var detailedCategory = _context.DetailedCategories.Find(detailedCategoryId);
            if(detailedCategory != null)
            {
                _context.DetailedCategories.Remove(detailedCategory);
                _context.SaveChanges();
            }
        }

        public IQueryable<DetailedCategory> GetDetailedCategoriesOfMainCategory(int mainCategoryId)
        {
            var categories = _context.DetailedCategories.Where(c => c.MainCategoryId == mainCategoryId);
            return categories;
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

        public DetailedCategory GetDetailedCategoryById(int detailedCategoryId)
        {
            var detailedCategory = _context.DetailedCategories.FirstOrDefault(c => c.Id == detailedCategoryId);
            return detailedCategory;
        }

        public void UpdateDetailedCategory(DetailedCategory detailedCategory)
        {
            _context.Attach(detailedCategory);
            _context.Entry(detailedCategory).Property("Name").IsModified = true;
            _context.SaveChanges();
        }
    }
}
