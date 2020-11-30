using AutoMapper;
using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Domain.Interface;
using ExpenseTracker.Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Services
{
    public class MainCService : IMainCService
    {
        private readonly IMapper _mapper;
        private readonly IMainCategoryRepository _mainCRepo;
        public MainCService(IMapper mapper, IMainCategoryRepository mainCRepo)
        {
            _mapper = mapper;
            _mainCRepo = mainCRepo;
        }

        public void CreateMainCategoriesForNewUser(string userId)
        {
            MainCategory m1 = new MainCategory() { Name = "Wydatki codzienne", ApplicationUserId = userId };
            MainCategory m2 = new MainCategory() { Name = "Wydatki okresowe", ApplicationUserId = userId };
            MainCategory m3 = new MainCategory() { Name = "Wydatki okazjonalne", ApplicationUserId = userId };
            List<MainCategory> mainCategories = new List<MainCategory>();
            mainCategories.Add(m1);
            mainCategories.Add(m2);
            mainCategories.Add(m3);

            _mainCRepo.AddMainCategories(mainCategories);
        }
    }
}
