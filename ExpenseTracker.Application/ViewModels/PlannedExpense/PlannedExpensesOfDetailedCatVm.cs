using AutoMapper;
using ExpenseTracker.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.ViewModels.PlannedExpense
{
    public class PlannedExpensesOfDetailedCatVm : IMapFrom<ExpenseTracker.Domain.Model.Entity.DetailedCategory>
    {
        public int Id { get; set; } //detailed category id
        public int PlannedExpenseId { get; set; }
        public string Name { get; set; }
        [IgnoreMap]
        public decimal PlannedAmount { get; set; }
        [IgnoreMap]
        public decimal SpentAmount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ExpenseTracker.Domain.Model.Entity.DetailedCategory, PlannedExpensesOfDetailedCatVm>();
        }
    }
}
