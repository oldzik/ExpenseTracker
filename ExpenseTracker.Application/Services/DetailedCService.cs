using AutoMapper;
using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Domain.Interface;
using ExpenseTracker.Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpenseTracker.Application.Services
{
    public class DetailedCService : IDetailedCService
    {
        private readonly IMapper _mapper;
        private readonly IDetailedCategoryRepository _detailedCRepo;
        private readonly IMainCategoryRepository _mainCRepo;
        public DetailedCService(IMapper mapper, IDetailedCategoryRepository detailedCRepo, IMainCategoryRepository mainCRepo)
        {
            _mapper = mapper;
            _detailedCRepo = detailedCRepo;
            _mainCRepo = mainCRepo;
        }

        public void CreateDetailedCategoriesForNewUser(string userId)
        {
            var mainCategories = _mainCRepo.GetAllMainCategoriesOfUser(userId).ToList();

            var d1 = new DetailedCategory() { Name = "Żywność", MainCategoryId = mainCategories[0].Id };
            var d2 = new DetailedCategory() { Name = "Chemia domowa", MainCategoryId = mainCategories[0].Id };
            var d3 = new DetailedCategory() { Name = "Rachunki", MainCategoryId = mainCategories[1].Id };
            var d4 = new DetailedCategory() { Name = "Kredyty", MainCategoryId = mainCategories[1].Id };
            var d5 = new DetailedCategory() { Name = "Transport i komunikacja", MainCategoryId = mainCategories[1].Id };
            var d6 = new DetailedCategory() { Name = "Hobby i rozrywka", MainCategoryId = mainCategories[2].Id };
            var d7 = new DetailedCategory() { Name = "Wystrój mieszkania", MainCategoryId = mainCategories[2].Id };
            var d8 = new DetailedCategory() { Name = "Wyjazdy", MainCategoryId = mainCategories[2].Id };
            
            List<DetailedCategory> detailedCategories = new List<DetailedCategory>() { d1,d2,d3,d4,d5,d6,d7,d8 };

            _detailedCRepo.AddDetailedCategories(detailedCategories);

        }
    }
}
