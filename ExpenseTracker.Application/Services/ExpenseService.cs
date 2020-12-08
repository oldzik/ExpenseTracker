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
        private readonly IBudgetRepository _budgetRepo;
        private readonly IDetailedCategoryRepository _detailedCRepo;
        private readonly IExpenseRepository _expenseRepo;

        public ExpenseService(IMapper mapper,IBudgetRepository budgetRepo, IExpenseRepository expenseRepo, IDetailedCategoryRepository detailedCRepo)
        {
            _mapper = mapper;
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

        public ListExpenseForListVm GetAllExpensesForList(DateTime monthOfYear, string userId)
        {
            if (monthOfYear.Day != 1)
                monthOfYear = DateTime.ParseExact(monthOfYear.ToString(), "MM.dd.yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            var budget = _budgetRepo.GetBudgetByUserId(userId);
           
            var expenses = _expenseRepo.GetAllExpensesOfBudget(budget.Id)
                .Where(e => e.Date >= monthOfYear && e.Date <monthOfYear.AddMonths(1))
                .ProjectTo<ExpenseForListVm>(_mapper.ConfigurationProvider).ToList();


            var expenseList = new ListExpenseForListVm()
            {
                MonthOfYear = monthOfYear,
                UserId = userId,
                Expenses = expenses,
                Count = expenses.Count
            };
            return expenseList;
        }

        public ListPerMonthDetCatExpenseForListVm GetAllExpensesForListDetCatPerMonth(DateTime monthOfYear, int detailedCategoryId)
        {
            if (monthOfYear.Day != 1)
                monthOfYear = DateTime.ParseExact(monthOfYear.ToString(), "MM.dd.yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            int mainCatId = _detailedCRepo.GetDetailedCategoryById(detailedCategoryId).MainCategoryId;
            var detCategory = _detailedCRepo.GetDetailedCategoryById(detailedCategoryId);
            var expenses = _expenseRepo.GetAllExpensesOfDetailedCategoryPerMonth(detailedCategoryId, monthOfYear)
                .ProjectTo<ExpenseForListVm>(_mapper.ConfigurationProvider).ToList();

            var expenseList = new ListPerMonthDetCatExpenseForListVm()
            {
                Expenses = expenses,
                DetailedCategoryName = detCategory.Name,
                MainCategoryId = mainCatId,
                MonthOfYear = monthOfYear,
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
