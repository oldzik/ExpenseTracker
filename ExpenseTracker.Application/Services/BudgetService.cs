using AutoMapper;
using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Application.ViewModels.Expense;
using ExpenseTracker.Domain.Interface;
using ExpenseTracker.Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly IMapper _mapper;
        private readonly IBudgetRepository _budgetRepo;
        private readonly IExpenseRepository _expenseRepo;
        public BudgetService(IMapper mapper, IBudgetRepository budgetRepo, IExpenseRepository expenseRepo)
        {
            _mapper = mapper;
            _budgetRepo = budgetRepo;
            _expenseRepo = expenseRepo;
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
    }
}
