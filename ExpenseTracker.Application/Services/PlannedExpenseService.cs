using AutoMapper;
using AutoMapper.QueryableExtensions;
using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Application.ViewModels.PlannedExpense;
using ExpenseTracker.Domain.Interface;
using ExpenseTracker.Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

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
        
        public ListNewPlannedExpensePerMonthVm CreateNewPlannedExpPerMonth(DateTime date, string userId)
        {
            DateTime monthOfYear = FirstDayOfMonthFromDateTime(date);
            var newPlannedExpenses = new List<NewPlannedExpenseVm>();

            var detCategories = _detailedCRepo.GetDetailedCategoriesByUserId(userId).ToList();
            for (int i = 0; i < detCategories.Count; i++)
            {
                NewPlannedExpenseVm plannedExp = new NewPlannedExpenseVm()
                {
                    DetailedCategoryId = detCategories[i].Id,
                    DetailedCategoryName = detCategories[i].Name
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

        public void AddPlannedExpensesPerMonth(ListNewPlannedExpensePerMonthVm model)
        {
            var newPlannedExpenses = _mapper.Map<List<NewPlannedExpenseVm>, List<PlannedExpense>>(model.PlannedExpenses);
            foreach (var plannedExp in newPlannedExpenses)
            {
                plannedExp.MonthOfYear = model.MonthOfYear;
            }

            _plannedExpenseRepo.AddPlannedExpenses(newPlannedExpenses);
        }

        public PlannedExpensesOfAllMainCatVm GetPlannedExpensesOfAllMainCPerMonth(DateTime date, string userId)
        {
            DateTime monthOfYear = FirstDayOfMonthFromDateTime(date);

            decimal sumOfPlanned = 0;
            PlannedExpensesOfAllMainCatVm model = new PlannedExpensesOfAllMainCatVm();
            model.PlannedExpOfMainCat = new List<PlannedExpensesOfMainCatVm>();
            var mainCategories = _mainCRepo.GetAllMainCategoriesOfUser(userId).ToList();
            if (mainCategories != null)
            {
                foreach (var mainCat in mainCategories)
                {
                    var plannedExpMainCatVm = _mapper.Map<PlannedExpensesOfMainCatVm>(mainCat);
                    var listPlannedDetailed = GetPlannedExpensesFromDetailedCategories(mainCat.Id, monthOfYear);
                    //listPlannedDetailed == null, if Main Category dont have any Detailed Categories.
                    if (listPlannedDetailed == null)
                    {
                        plannedExpMainCatVm.PlannedAmount = 0;
                        plannedExpMainCatVm.SpentAmount = 0;                      
                    }
                    else
                    {
                        foreach (var plannedDetailed in listPlannedDetailed)
                        {
                            plannedExpMainCatVm.PlannedAmount += plannedDetailed.PlannedAmount;
                            plannedExpMainCatVm.SpentAmount += plannedDetailed.SpentAmount;
                        }
                        sumOfPlanned += plannedExpMainCatVm.PlannedAmount;
                    }
                    model.PlannedExpOfMainCat.Add(plannedExpMainCatVm);
                }
            }
            model.MonthOfYear = monthOfYear;
            model.SumOfPlanned = sumOfPlanned;
            model.Count = model.PlannedExpOfMainCat.Count; 
            return model;
        }

        public PlannedExpensesOfAllDetailedCatVm GetPlannedExpensesOfMainCPerMonth(DateTime monthOfYear, int mainCategoryId)
        {
            string mainCategoryName = _mainCRepo.GetMainCategoryNameById(mainCategoryId);
            DateTime date = FirstDayOfMonthFromDateTime(monthOfYear);
            var model = new PlannedExpensesOfAllDetailedCatVm()
            {
                MonthOfYear = date,
                MainCategoryId=mainCategoryId,
                MainCategoryName = mainCategoryName
            };

            int countDetCategories = _mainCRepo.GetCountOfDetailedCategories(mainCategoryId);
            if (countDetCategories != 0)
            {
                bool isPlanned = CheckIfMonthWasPlanned(date);
                if(isPlanned)
                {
                    CreatePlannedExpensesForNewDetailedCategories(mainCategoryId, date);
                    var plannedExpenses = GetPlannedExpensesFromDetailedCategories(mainCategoryId, date);
                    model.PlannedExpOfDetailedCat = plannedExpenses;
                    model.Count = plannedExpenses.Count;
                }
                else
                {
                    //there are detailed categories, but not planned for the month.
                    model.Count = -1;
                }                
            }
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


        private List<PlannedExpensesOfDetailedCatVm> GetPlannedExpensesFromDetailedCategories(int mainCatId, DateTime date)
        {           
            var plannedExpenses = _plannedExpenseRepo.GetAllPlannedExpensesOfMainCat(mainCatId, date)
                .ProjectTo<PlannedExpensesOfDetailedCatVm>(_mapper.ConfigurationProvider).ToList();

            foreach (var plannedExp in plannedExpenses)
            {
                decimal spentAm = SumSpentAmountPerMonthOfDetailed(plannedExp.DetailedCategoryId, date);
                plannedExp.SpentAmount = spentAm;
            }
            return plannedExpenses;
        }

        private void CreatePlannedExpensesForNewDetailedCategories(int mainCatId, DateTime date)
        {
            var newPlannedExpenses = new List<PlannedExpense>();
            var detCategories = _detailedCRepo.GetDetailedCategoriesOfMainCategory(mainCatId);
            foreach (var detCategory in detCategories)
            {
                var plannedExpense = _plannedExpenseRepo.GetPlannedExpenseOfDetailedCat(detCategory.Id, date);
                if (plannedExpense == null)
                {
                    PlannedExpense newPlannedExp = new PlannedExpense()
                    {
                        Amount = 0,
                        MonthOfYear = date,
                        DetailedCategoryId = detCategory.Id
                    };
                    newPlannedExpenses.Add(newPlannedExp);
                }
            }
            if (newPlannedExpenses.Count != 0)
                _plannedExpenseRepo.AddPlannedExpenses(newPlannedExpenses);
        }

        private bool CheckIfMonthWasPlanned(DateTime date)
        {
            var firstPlannedExp = _plannedExpenseRepo.ReturnFirstPlannedExpInMonth(date);
            if (firstPlannedExp == null)
                return false;
            return true;
        }
 
        private decimal SumSpentAmountPerMonthOfDetailed(int detailedCatId, DateTime month)
        {
            List<Expense> exps = _expenseRepo.GetAllExpensesOfDetailedCategoryPerMonth(detailedCatId, month).ToList();
            
            decimal spentAm = 0;
            foreach (var exp in exps)
            {
                spentAm += exp.Amount;
            }
            return spentAm;
        }

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
