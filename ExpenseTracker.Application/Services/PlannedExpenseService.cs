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
        private readonly IDetailedCategoryRepository _detailedCRepo;
        public PlannedExpenseService(IMapper mapper, IPlannedExpenseRepository plannedExpenseRepo, IDetailedCategoryRepository detailedCRepo)
        {
            _mapper = mapper;
            _plannedExpenseRepo = plannedExpenseRepo;
            _detailedCRepo = detailedCRepo;
        }

        public void AddPlannedExpensesPerMonth(ListNewPlannedExpensePerMonthVm model)
        {
           // var newPlannedExpenses = model.PlannedExpenses.ProjectTo<PlannedExpense>(_mapper.ConfigurationProvider)
        }

        public ListNewPlannedExpensePerMonthVm CreateNewPlannedExpPerMonth(string userId)
        {
            List<NewPlannedExpenseVm> newPlannedExpenses = new List<NewPlannedExpenseVm>();
            
            var detCategories = _detailedCRepo.GetDetailedCategoriesByUserId(userId).ToList();
            for (int i = 0; i < detCategories.Count; i++)
            {
                var detCategoryVm = _mapper.Map<NewDetailedCategoryVm>(detCategories[i]);
                NewPlannedExpenseVm plannedExp = new NewPlannedExpenseVm()
                { 
                    DetailedCategory = detCategoryVm 
                };

                newPlannedExpenses.Add(plannedExp);
            }

            var newPlannedExpensesPerMonthVm = new ListNewPlannedExpensePerMonthVm()
            {
                PlannedExpenses = newPlannedExpenses
            };

            return newPlannedExpensesPerMonthVm;
        }
    }
}
