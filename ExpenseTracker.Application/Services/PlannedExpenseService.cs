using AutoMapper;
using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Application.ViewModels.DetailedCategory;
using ExpenseTracker.Application.ViewModels.PlannedExpense;
using ExpenseTracker.Domain.Interface;
using ExpenseTracker.Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        public ListNewPlannedExpensePerMonthVm CreateNewPlannedExpPerMonth(DateTime date, string userId)
        {
            DateTime monthOfYear = FirstDayOfMonthFromDateTime(date);
            var newPlannedExpenses = new List<NewPlannedExpenseVm>();

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
                PlannedExpenses = newPlannedExpenses,
                MonthOfYear = monthOfYear
            };

            return newPlannedExpensesPerMonthVm;
        }

        public PlannedExpensesOfAllMainCatVm GetPlannedExpensesOfAllMainCPerMonth(DateTime date, string userId)
        {
            DateTime monthOfYear = FirstDayOfMonthFromDateTime(date);

            PlannedExpensesOfAllMainCatVm model = new PlannedExpensesOfAllMainCatVm();
            model.PlannedExpOfMainCat = new List<PlannedExpensesOfMainCatVm>();
            var mainCategories = _mainCRepo.GetAllMainCategoriesOfUser(userId).ToList();
            if (mainCategories != null)
            {
                foreach (var mainCat in mainCategories)
                {
                    var plannedExpMainCatVm = _mapper.Map<PlannedExpensesOfMainCatVm>(mainCat);

                    List<PlannedExpense> plannedExps = _plannedExpenseRepo.GetAllPlannedExpensesOfMainCat(mainCat.Id, monthOfYear).ToList();
                    if (plannedExps.Count == 0)
                        break;
                        
                    List<Expense> exps = _expenseRepo.GetAllExpensesOfMainCategoryPerMonth(mainCat.Id, monthOfYear).ToList();
                    //oblicz sume planned
                    //oblicz sume spent
                    decimal plannedAm = 0;
                    foreach (var plannedExp in plannedExps)
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
            }
            model.MonthOfYear = monthOfYear;
            model.Count = model.PlannedExpOfMainCat.Count; 
            return model;
        }

        public PlannedExpensesOfAllDetailedCatVm GetPlannedExpensesOfMainCPerMonth(DateTime monthOfYear, int mainCategoryId)
        {
            if (monthOfYear.Day != 1)
                monthOfYear = DateTime.ParseExact(monthOfYear.ToString(), "MM.dd.yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            PlannedExpensesOfAllDetailedCatVm model = new PlannedExpensesOfAllDetailedCatVm();
            model.PlannedExpOfDetailedCat = new List<PlannedExpensesOfDetailedCatVm>();

            var mainCategory = _mainCRepo.GetMainCategoryById(mainCategoryId);
            var detailedCategories = _detailedCRepo.GetDetailedCategoriesOfMainCategory(mainCategoryId).ToList();
            if(detailedCategories != null)
            {
                foreach(var detailedCat in detailedCategories)
                {
                    var plannedExpDetailedCatVm = _mapper.Map<PlannedExpensesOfDetailedCatVm>(detailedCat);

                    PlannedExpense plannedExp = _plannedExpenseRepo.GetPlannedExpenseOfDetailedCat(detailedCat.Id, monthOfYear);
                    if (plannedExp == null)
                        break;

                    List<Expense> exps = _expenseRepo.GetAllExpensesOfDetailedCategoryPerMonth(detailedCat.Id, monthOfYear).ToList();
                    // sum spent
                    decimal spentAm = 0;
                    foreach (var exp in exps)
                    {
                        spentAm += exp.Amount;
                    }

                    plannedExpDetailedCatVm.PlannedAmount = plannedExp.Amount;
                    plannedExpDetailedCatVm.SpentAmount = spentAm;
                    plannedExpDetailedCatVm.PlannedExpenseId = plannedExp.Id;
                    model.PlannedExpOfDetailedCat.Add(plannedExpDetailedCatVm);
                }
            }
            model.MainCategoryId = mainCategoryId;
            model.MainCategoryName = mainCategory.Name;
            model.MonthOfYear = monthOfYear;
            model.Count = model.PlannedExpOfDetailedCat.Count;
            return model;
        }

        public PlannedExpenseForEditVm GetPlannedExpForEdit(int plannedExpenseId)
        {
            var plannedExpense = _plannedExpenseRepo.GetPlannedExpenseById(plannedExpenseId);
            var plannedExpenseVm = _mapper.Map<PlannedExpenseForEditVm>(plannedExpense);
            var detCat = _detailedCRepo.GetDetailedCategoryById(plannedExpense.DetailedCategoryId);
            plannedExpenseVm.DetailedCatName = detCat.Name;
            plannedExpenseVm.MainCatId = detCat.MainCategoryId;
            return plannedExpenseVm;

        }

        public void UpdatePlannedExpense(PlannedExpenseForEditVm model)
        {
            var plannedExpense = _mapper.Map<PlannedExpense>(model);
            _plannedExpenseRepo.UpdatePlannedExpense(plannedExpense);
        }






        //PRIVATE
        private DateTime FirstDayOfMonthFromDateTime(DateTime dateTime)
        {
            //Set day of month to the first day - you plan a budget per month
            if (dateTime.Day == 1)
                return dateTime.Date;
            else
                return new DateTime(dateTime.Year, dateTime.Month, 1);
        }
    }
}
