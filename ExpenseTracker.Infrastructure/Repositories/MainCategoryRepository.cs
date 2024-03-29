﻿using ExpenseTracker.Domain.Interface;
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

        public int AddMainCategory(MainCategory mainCat)
        {
            _context.MainCategories.Add(mainCat);
            _context.SaveChanges();
            return mainCat.Id;
        }

        public void DeleteMainCategory(int mainCategoryId)
        {
            var category = _context.MainCategories.Find(mainCategoryId);
            if(category != null)
            {
                _context.MainCategories.Remove(category);
                _context.SaveChanges();
            }
        }

        public int GetCountOfDetailedCategories(int mainCategoryId)
        {
            var count = _context.DetailedCategories.Where(c => c.MainCategoryId == mainCategoryId).Count();
            return count;
        }

        public IQueryable<MainCategory> GetAllMainCategoriesOfUser(string userId)
        {
            var categories = _context.MainCategories.Where(c => c.ApplicationUserId == userId);
            return categories;
        }

        public MainCategory GetMainCategoryById(int mainCategoryId)
        {
            var mainCategory = _context.MainCategories.FirstOrDefault(c => c.Id == mainCategoryId);
            return mainCategory;
        }

        public string GetMainCategoryNameById(int mainCategoryId)
        {
            var name = _context.MainCategories.FirstOrDefault(c => c.Id == mainCategoryId).Name;
            return name;
        }

        public void UpdateMainCategory(MainCategory mainCategory)
        {
            _context.Attach(mainCategory);
            _context.Entry(mainCategory).Property("Name").IsModified = true;
            _context.SaveChanges();
        }
    }
}
