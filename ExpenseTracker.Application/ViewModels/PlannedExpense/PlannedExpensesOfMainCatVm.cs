using AutoMapper;
using ExpenseTracker.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.ViewModels.PlannedExpense
{
    public class PlannedExpensesOfMainCatVm : IMapFrom<ExpenseTracker.Domain.Model.Entity.MainCategory>
    {
        public int MainCategoryId { get; set; } 
        public string MainCategoryName { get; set; }
        public decimal PlannedAmount { get; set; }
        public decimal SpentAmount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ExpenseTracker.Domain.Model.Entity.MainCategory, PlannedExpensesOfMainCatVm>()
                .ForMember(d => d.MainCategoryId, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.MainCategoryName, opt => opt.MapFrom(s => s.Name));
        }
    }
}
