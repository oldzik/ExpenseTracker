using AutoMapper;
using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Application.ViewModels.Expense;
using ExpenseTracker.Domain.Interface;
using ExpenseTracker.Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpenseTracker.Application.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly IMapper _mapper;
        private readonly IBudgetRepository _budgetRepo;
        private readonly IExpenseRepository _expenseRepo;
        private readonly IMainCategoryRepository _mainCRepo;
        private readonly IDetailedCategoryRepository _detailedCRepo;

        public BudgetService(IMapper mapper, IBudgetRepository budgetRepo, IExpenseRepository expenseRepo, IMainCategoryRepository mainCRepo, IDetailedCategoryRepository detailedCRepo)
        {
            _mapper = mapper;
            _budgetRepo = budgetRepo;
            _expenseRepo = expenseRepo;
            _mainCRepo = mainCRepo;
            _detailedCRepo = detailedCRepo;
        }

        public void CreateBudgetForNewUser(string userId)
        {
            Budget newUserBudget = new Budget()
            {
                Sum = 0,
                ApplicationUserRef = userId
            };

            _budgetRepo.AddBudget(newUserBudget);
        }

        public bool ChangeSum(int expenseId, int operation)
        {
            if (operation != 1 && operation != -1)
                return false;
            
            //Get expense and budget from db, add(1) or subtract(-1) amount and update budget.
            Expense exp = _expenseRepo.GetExpenseById(expenseId);
            Budget budget = _budgetRepo.GetBudgetById(exp.BudgetId);

            switch (operation)
            {
                case 1:
                    budget.Sum += exp.Amount;
                    break;
                case -1:
                    budget.Sum -= exp.Amount;
                    break;
            }
            _budgetRepo.UpdateAmount(budget);
            return true;
        }

        public void EditSum(EditExpenseVm model)
        {
            Expense exp = _expenseRepo.GetExpenseById(model.Id);
            var budget = _budgetRepo.GetBudgetById(exp.BudgetId);
            decimal lastValue = exp.Amount;
            decimal currentValue = model.Amount;
            budget.Sum += currentValue - lastValue;
            _budgetRepo.UpdateAmount(budget);
        }

        public void RemoveFromSumBeforeMainCategoryDelete(int mainCategoryId)
        {
            List<DetailedCategory> detCategories = _detailedCRepo.GetDetailedCategoriesOfMainCategory(mainCategoryId).ToList();
            var budget = GetBudgetOfMainCategory(mainCategoryId);
            var sumToRemoveFromBudget = SumAllExpensesAmountsOfDetailedCategories(detCategories);
          
            UpdateBudgetBeforeCategoryDelete(budget, sumToRemoveFromBudget);
        }

        public void RemoveFromSumBeforeDetailedCategoryDelete(int detailedCategoryId)
        {
            DetailedCategory detCategory = _detailedCRepo.GetDetailedCategoryById(detailedCategoryId);
            int mainCategoryId = detCategory.MainCategoryId;
            var budget = GetBudgetOfMainCategory(mainCategoryId);
            var sumToRemoveFromBudget = SumAllExpensesAmountsOfDetailedCategory(detCategory);

            UpdateBudgetBeforeCategoryDelete(budget, sumToRemoveFromBudget);
        }

        private void UpdateBudgetBeforeCategoryDelete(Budget budget, decimal sumToRemove)
        {
            budget.Sum -= sumToRemove;
            _budgetRepo.UpdateAmount(budget);
        }

        private Budget GetBudgetOfMainCategory(int mainCategoryId)
        {
            var userId = _mainCRepo.GetMainCategoryById(mainCategoryId).ApplicationUserId;
            var budget = _budgetRepo.GetBudgetByUserId(userId);
            return budget;
        }

        private decimal SumAllExpensesAmountsOfDetailedCategory(DetailedCategory detCategory)
        {
            decimal sum = 0;
            List<Expense> expensesOfCategory = _expenseRepo.GetAllExpensesOfDetailedCategory(detCategory.Id).ToList();
            for (int i = 0; i < expensesOfCategory.Count; i++)
            {
                sum += expensesOfCategory[i].Amount;
            }
            return sum;
        }

        private decimal SumAllExpensesAmountsOfDetailedCategories(List<DetailedCategory> detCategories)
        {
            decimal sum = 0;
            List<Expense> expensesOfCategory; 
            foreach (var detCategory in detCategories)
            {
                expensesOfCategory = _expenseRepo.GetAllExpensesOfDetailedCategory(detCategory.Id).ToList();

                for (int i = 0; i < expensesOfCategory.Count; i++)
                {
                    sum += expensesOfCategory[i].Amount;
                }
            }
            return sum;
        }
    }
}
