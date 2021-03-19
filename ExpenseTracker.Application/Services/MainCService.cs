using AutoMapper;
using AutoMapper.QueryableExtensions;
using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Application.ViewModels.MainCategory;
using ExpenseTracker.Domain.Interface;
using ExpenseTracker.Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
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
        //git
        public int AddMainCategory(NewMainCategoryVm model, string userId)
        {
            var mainCat = _mapper.Map<MainCategory>(model);
            mainCat.ApplicationUserId = userId;
            var id = _mainCRepo.AddMainCategory(mainCat);
            return id;
        }
        //git
        public void CreateMainCategoriesForNewUser(string userId)
        {
            MainCategory m1 = new MainCategory() { Name = "Wydatki codzienne", ApplicationUserId = userId };
            MainCategory m2 = new MainCategory() { Name = "Wydatki okresowe", ApplicationUserId = userId };
            MainCategory m3 = new MainCategory() { Name = "Wydatki okazjonalne", ApplicationUserId = userId };
            List<MainCategory> mainCategories = new List<MainCategory>() { m1, m2, m3 };

            _mainCRepo.AddMainCategories(mainCategories);
        }
        //git
        public NewMainCategoryVm GetMainCategoryForEdit(int mainCategoryId)
        {
            var mainCategory = _mainCRepo.GetMainCategoryById(mainCategoryId);
            var mainCategoryVm = _mapper.Map<NewMainCategoryVm>(mainCategory);
            return mainCategoryVm;
        }
        //git
        public ListMainCatForListVm GetMainCategoriesForList(string userId)
        {
            var mainCategories = _mainCRepo.GetAllMainCategoriesOfUser(userId).ProjectTo<MainCatForListVm>
                (_mapper.ConfigurationProvider).ToList();

            var mainCategoryList = new ListMainCatForListVm()
            {
                MainCategories = mainCategories,
                Count = mainCategories.Count
            };

            return mainCategoryList;
        }
        //git
        public void UpdateMainCategory(NewMainCategoryVm model)
        {
            var mainCategory = _mapper.Map<MainCategory>(model);
            _mainCRepo.UpdateMainCategory(mainCategory);
        }
        //git
        public void DeleteMainCategory(int mainCategoryId)
        {
            _mainCRepo.DeleteMainCategory(mainCategoryId);
        }

    }
}
