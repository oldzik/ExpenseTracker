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
        public BudgetService(IMapper mapper, IBudgetRepository budgetRepo, IExpenseRepository expenseRepo, IMainCategoryRepository mainCRepo)
        {
            _mapper = mapper;
            _budgetRepo = budgetRepo;
            _expenseRepo = expenseRepo;
            _mainCRepo = mainCRepo;
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

        public void AddToSum(int expenseId)
        {
            Expense exp = _expenseRepo.GetExpenseById(expenseId);
            var budget = _budgetRepo.GetBudgetById(exp.BudgetId);
            budget.Sum += exp.Amount;
            _budgetRepo.UpdateAmount(budget);
        }

        public void RemoveFromSum(int expenseId)
        {
            Expense exp = _expenseRepo.GetExpenseById(expenseId);
            var budget = _budgetRepo.GetBudgetById(exp.BudgetId);
            budget.Sum -= exp.Amount;
            _budgetRepo.UpdateAmount(budget);
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

        public decimal SumAllExpensesOfDetailedCategories(List<DetailedCategory> detCategories)
        {
            decimal sum = 0;
            List<Expense> expensesOfCategory;
            foreach (var detCategory in detCategories)
            {
                expensesOfCategory = _expenseRepo.GetAllExpensesOfDetailedCategory(detCategory.Id).ToList();
                
                for (int i = 0; i < expensesOfCategory.Count; i++)
                {
                    sum += expensesOfCategory[0].Amount;
                }
            }
            return sum;
        }

        public void RemoveFromSumBeforeCategoryDelete(Budget budget, decimal sumToRemoveFromBudget)
        {
            budget.Sum -= sumToRemoveFromBudget;
            _budgetRepo.UpdateAmount(budget);
        }

        public Budget GetBudgetOfMainCategory(int mainCategoryId)
        {
            var userId = _mainCRepo.GetMainCategoryById(mainCategoryId).ApplicationUserId;
            var budget = _budgetRepo.GetBudgetByUserId(userId);
            return budget;
        }
    }
}
