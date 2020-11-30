using ExpenseTracker.Domain.Interface;
using ExpenseTracker.Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpenseTracker.Infrastructure.Repositories
{
    public class MainCategoryRepository : IMainCategoryRepository
    {
        private readonly Context _context;
        public MainCategoryRepository(Context context)
        {
            _context = context;
        }

        public void AddMainCategories(List<MainCategory> mainCategories)
        {
            _context.MainCategories.AddRange(mainCategories);
            _context.SaveChanges();
        }

        public IQueryable<MainCategory> GetAllMainCategoriesOfUser(string userId)
        {
            var categories = _context.MainCategories.Where(c => c.ApplicationUserId == userId);
            return categories;
        }
    }
}
