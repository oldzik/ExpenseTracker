using AutoMapper;
using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Application.ViewModels.DetailedCategory;
using ExpenseTracker.Application.ViewModels.PlannedExpense;
using ExpenseTracker.Domain.Interface;
using ExpenseTracker.Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpenseTracker.Application.Services
{
    public class PlannedExpenseService : IPlannedExpenseService
    {
        private readonly IMapper _mapper;
        private readonly IPlannedExpenseRepository _plannedExpenseRepo;
        private readonly IExpenseRepository _expenseRepo;
        private readonly IDetailedCategoryRepository _detailedCRepo;
        private readonly IMainCategoryRepository _mainCRepo;
        public PlannedExpenseService(IMapper mapper, IPlannedExpenseRepository plannedExpenseRepo, IDetailedCategoryRepository detailedCRepo,
            IMainCategoryRepository mainCRepo, IExpenseRepository expenseRepo)
        {
            _mapper = mapper;
            _plannedExpenseRepo = plannedExpenseRepo;
            _detailedCRepo = detailedCRepo;
            _mainCRepo = mainCRepo;
            _expenseRepo = expenseRepo;
        }

        public void AddPlannedExpensesPerMonth(ListNewPlannedExpensePerMonthVm model)
        {
            var newPlannedExpenses = _mapper.Map<List<NewPlannedExpenseVm>, List<PlannedExpense>>(model.PlannedExpenses);
            foreach(var plannedExp in newPlannedExpenses)
            {
                plannedExp.MonthOfYear = model.MonthOfYear;
            }

            _plannedExpenseRepo.AddPlannedExpenses(newPlannedExpenses);
        }

        public ListNewPlannedExpensePerMonthVm CreateNewPlannedExpPerMonth(string userId)
        {
            List<NewPlannedExpenseVm> newPlannedExpenses = new List<NewPlannedExpenseVm>();
            
            var detCategories = _detailedCRepo.GetDetailedCategoriesByUserId(userId).ToList();
            for (int i = 0; i < detCategories.Count; i++)
            {
                var detCategoryVm = _mapper.Map<DetailedCategoryForNewPlannedExpenseVm>(detCategories[i]);
                NewPlannedExpenseVm plannedExp = new NewPlannedExpenseVm()
                { 
                    DetCategory = detCategoryVm 
                };

                newPlannedExpenses.Add(plannedExp);
            }
            var newPlannedExpensesPerMonthVm = new ListNewPlannedExpensePerMonthVm()
            {
                PlannedExpenses = newPlannedExpenses
            };

            return newPlannedExpensesPerMonthVm;
        }

        public PlannedExpensesOfAllMainCatVm GetPlannedExpensesOfAllMainCPerMonth(DateTime monthOfYear, string userId)
        {
            PlannedExpensesOfAllMainCatVm model = new PlannedExpensesOfAllMainCatVm();
            model.PlannedExpOfMainCat = new List<PlannedExpensesOfMainCatVm>();
            var mainCategories = _mainCRepo.GetAllMainCategoriesOfUser(userId).ToList();
            
            foreach(var mainCat in mainCategories)
            {
                var plannedExpMainCatVm = _mapper.Map<PlannedExpensesOfMainCatVm>(mainCat);

                List<PlannedExpense> plannedExps = _plannedExpenseRepo.GetAllPlannedExpensesOfMainCat(mainCat.Id, monthOfYear).ToList();
                List<Expense> exps = _expenseRepo.GetAllExpensesOfMainCategory(mainCat.Id, monthOfYear).ToList();
                //oblicz sume planned
                //oblicz sume spent
                decimal plannedAm = 0;
                foreach(var plannedExp in plannedExps)
                {
                    plannedAm += plannedExp.Amount;
                }
                decimal spentAm = 0;
                foreach (var exp in exps)
                {
                    spentAm += exp.Amount;
                }

                plannedExpMainCatVm.PlannedAmount = plannedAm;
                plannedExpMainCatVm.SpentAmount = spentAm;
                model.PlannedExpOfMainCat.Add(plannedExpMainCatVm);
            }
            model.MonthOfYear = monthOfYear;
            model.Count = model.PlannedExpOfMainCat.Count;  //nie wiem czy tak można?
            return model;
        }
    }
}
