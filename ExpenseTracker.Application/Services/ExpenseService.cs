using AutoMapper;
using AutoMapper.QueryableExtensions;
using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Application.ViewModels.Expense;
using ExpenseTracker.Domain.Interface;
using ExpenseTracker.Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ExpenseTracker.Application.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepo;
        private readonly IBudgetRepository _budgetRepo;
        private readonly IDetailedCategoryRepository _detailedCRepo;
        private readonly IExpenseRepository _expenseRepo;

        public ExpenseService(IMapper mapper, IUserRepository userRepo, IBudgetRepository budgetRepo, IExpenseRepository expenseRepo, IDetailedCategoryRepository detailedCRepo)
        {
            _mapper = mapper;
            _userRepo = userRepo;
            _budgetRepo = budgetRepo;
            _expenseRepo = expenseRepo;
            _detailedCRepo = detailedCRepo;
        }

        public int AddExpense(NewExpenseVm newExp)
        {
            var exp = _mapper.Map<Expense>(newExp);
            var budget = _budgetRepo.GetBudgetByUserId(newExp.UserId);
            exp.BudgetId = budget.Id;

            int id = _expenseRepo.AddExpense(exp);
            return id;
        }

        public NewExpenseVm CreateNewExpense(string userId)
        {
            
            var categories = _detailedCRepo.GetDetailedCategoriesOfUser(userId);
            var model = new NewExpenseVm() { Categories = categories, UserId=userId };

            return model;
        }

        public void DeleteExpense(int expenseId)
        {
            
            _expenseRepo.DeleteExpense(expenseId);
        }

        public ListExpenseForListVm GetAllExpensesForList(string userId)
        {

            var budget = _budgetRepo.GetBudgetByUserId(userId);
           
            var expenses = _expenseRepo.GetAllExpensesOfBudget(budget.Id).ProjectTo<ExpenseForListVm>
                 (_mapper.ConfigurationProvider).ToList();

            var expenseList = new ListExpenseForListVm()
            {
                Expenses = expenses,
                Count = expenses.Count
            };
            return expenseList;
        }

        public EditExpenseVm GetExpenseForEdit(int expenseId)
        {
            var expense = _expenseRepo.GetExpenseById(expenseId);
            var expenseVm = _mapper.Map<EditExpenseVm>(expense);
            return expenseVm;
        }

        public void UpdateExpense(EditExpenseVm model)
        {
            var expense = _mapper.Map<Expense>(model);
            _expenseRepo.UpdateExpense(expense);
        }
    }
}
