using AutoMapper;
using ExpenseTracker.Application.Interfaces;
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
        public BudgetService(IMapper mapper, IBudgetRepository budgetRepo)
        {
            _mapper = mapper;
            _budgetRepo = budgetRepo;
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
    }
}
