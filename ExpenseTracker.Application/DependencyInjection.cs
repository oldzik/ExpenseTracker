using AutoMapper;
using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Application.Services;
using ExpenseTracker.Application.ViewModels.Expense;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ExpenseTracker.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IBudgetService, BudgetService>();
            services.AddTransient<IExpenseService, ExpenseService>();
            services.AddTransient<IMainCService,MainCService>();
            services.AddTransient<IDetailedCService,DetailedCService>();
            services.AddTransient<IPlannedExpenseService, PlannedExpenseService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
