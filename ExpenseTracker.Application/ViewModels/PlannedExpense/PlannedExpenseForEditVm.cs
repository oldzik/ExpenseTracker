using AutoMapper;
using ExpenseTracker.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.ViewModels.PlannedExpense
{
    public class PlannedExpenseForEditVm : IMapFrom<ExpenseTracker.Domain.Model.Entity.PlannedExpense>
    { 
    
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int MainCategoryId { get; set; }
        public DateTime MonthOfYear { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<ExpenseTracker.Domain.Model.Entity.PlannedExpense, PlannedExpenseForEditVm>().ReverseMap();
        }
    }
}
