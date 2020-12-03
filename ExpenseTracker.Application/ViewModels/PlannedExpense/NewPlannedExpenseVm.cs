using AutoMapper;
using ExpenseTracker.Application.Mapping;
using ExpenseTracker.Application.ViewModels.DetailedCategory;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.ViewModels.PlannedExpense
{
    public class NewPlannedExpenseVm : IMapFrom<ExpenseTracker.Domain.Model.Entity.PlannedExpense>
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public NewDetailedCategoryVm DetailedCategory{ get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewPlannedExpenseVm, ExpenseTracker.Domain.Model.Entity.PlannedExpense>()
                .ForMember(d => d.DetailedCategoryId, opt => opt.MapFrom(s => s.DetailedCategory.Id));
        }

    }
}
