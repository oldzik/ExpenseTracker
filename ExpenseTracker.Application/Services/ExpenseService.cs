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

        public NewExpenseVm CreateNewExpense(string userId)
        {
            int budgetId = _budgetRepo.GetBudgetIdByUserId(userId);
            var categories = _detailedCRepo.GetDetailedCategoriesOfUser(userId);
            var model = new NewExpenseVm() { Categories = categories, UserId = userId, BudgetId = budgetId };

            return model;
        }

        public int AddExpense(NewExpenseVm newExp)
        {
            var exp = _mapper.Map<Expense>(newExp);
            int id = _expenseRepo.AddExpense(exp);
            return id;
        }

        public void DeleteExpense(int expenseId)
        {           
            _expenseRepo.DeleteExpense(expenseId);
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

        public ListExpenseForListVm GetAllExpensesForList(DateTime date, string userId)
        {
            DateTime monthOfYear = FirstDayOfMonthFromDateTime(date);
            int budgetId = _budgetRepo.GetBudgetIdByUserId(userId);
            
            var expenses = _expenseRepo.GetAllExpensesOfBudget(budgetId)
                .Where(e => e.Date >= monthOfYear && e.Date <monthOfYear.AddMonths(1))
                .OrderBy(k => k.Date)
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

        //wszystkie wydatki szczegółowej kategorii na miesiąc
        public ListDetCatExpenseForListVm GetAllExpensesOfDetCatPerMonth(DateTime monthOfYear, int detailedCategoryId)
        {

            var detCategory = _detailedCRepo.GetDetailedCategoryById(detailedCategoryId);
            var expenses = _expenseRepo.GetAllExpensesOfDetailedCategoryPerMonth(detailedCategoryId, monthOfYear)
                .ProjectTo<ExpenseForListVm>(_mapper.ConfigurationProvider).ToList();

            var expenseList = new ListDetCatExpenseForListVm()
            {
                Expenses = expenses,
                DetailedCategoryName = detCategory.Name,
                MainCategoryId = detCategory.MainCategoryId,
                MonthOfYear = monthOfYear,
                Count = expenses.Count
            };
            return expenseList;

        }

        private DateTime FirstDayOfMonthFromDateTime(DateTime dateTime)
        {
            //Set day of month to the first day - expenses are displayed monthly
            if (dateTime.Day == 1)
                return dateTime.Date;
            else
                return new DateTime(dateTime.Year, dateTime.Month, 1);
        }
    }
}
