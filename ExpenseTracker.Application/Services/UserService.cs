using AutoMapper;
using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IBudgetRepository _budgetRepo;
        public UserService(IMapper mapper, IBudgetRepository budgetRepo)
        {
            _mapper = mapper;
            _budgetRepo = budgetRepo;
        }

    }
}
