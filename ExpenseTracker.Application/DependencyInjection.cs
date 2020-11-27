using AutoMapper;
using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Application.Services;
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
            services.AddTransient<IUserService,UserService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
