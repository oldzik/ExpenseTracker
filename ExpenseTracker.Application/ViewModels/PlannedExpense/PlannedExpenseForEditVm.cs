using AutoMapper;
using ExpenseTracker.Application.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExpenseTracker.Application.ViewModels.PlannedExpense
{
    public class PlannedExpenseForEditVm : IMapFrom<ExpenseTracker.Domain.Model.Entity.PlannedExpense>
    { 
    
        public int Id { get; set; }
        [DataType(DataType.Currency)]
        [RegularExpression(@"^[\d]+(\,\d{1,2})?$", ErrorMessage = "Required XXXX,XX format.")]
        [Required]
        public decimal Amount { get; set; }
        public int MainCatId { get; set; }
        public string DetailedCatName { get; set; }
        public DateTime MonthOfYear { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<ExpenseTracker.Domain.Model.Entity.PlannedExpense, PlannedExpenseForEditVm>().ReverseMap();
        }
    }
}
