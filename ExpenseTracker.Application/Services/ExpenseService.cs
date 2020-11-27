using AutoMapper;
using AutoMapper.QueryableExtensions;
using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Application.ViewModels.Expense;
using ExpenseTracker.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpenseTracker.Application.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepo;
        private readonly IBudgetRepository _budgetRepo;
        private readonly IExpenseRepository _expenseRepo;

        public ExpenseService(IMapper mapper, IUserRepository userRepo, IBudgetRepository budgetRepo, IExpenseRepository expenseRepo)
        {
            _mapper = mapper;
            _userRepo = userRepo;
            _budgetRepo = budgetRepo;
            _expenseRepo = expenseRepo;
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
    }
}
