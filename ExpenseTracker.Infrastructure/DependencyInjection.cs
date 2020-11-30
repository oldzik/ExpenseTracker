using ExpenseTracker.Domain.Interface;
using ExpenseTracker.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IBudgetRepository, BudgetRepository>();
            services.AddTransient<IExpenseRepository, ExpenseRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IMainCategoryRepository, MainCategoryRepository>();
            services.AddTransient<IDetailedCategoryRepository, DetailedCategoryRepository>();
            return services;
        }
    }
}
