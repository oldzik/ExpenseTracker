using AutoMapper;
using ExpenseTracker.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.ViewModels.PlannedExpense
{
    public class PlannedExpensesOfDetailedCatVm : IMapFrom<ExpenseTracker.Domain.Model.Entity.PlannedExpense>
    {
        public int Id { get; set; }
        public string DetCategoryName { get; set; }
        public int DetailedCategoryId { get; set; }
        public decimal PlannedAmount { get; set; }
        [IgnoreMap]
        public decimal SpentAmount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ExpenseTracker.Domain.Model.Entity.PlannedExpense, PlannedExpensesOfDetailedCatVm>()
                .ForMember(d => d.PlannedAmount, opt => opt.MapFrom(s => s.Amount))
                .ForMember(d => d.DetCategoryName, opt => opt.MapFrom(s => s.DetailedCategory.Name));
        }
    }
}
