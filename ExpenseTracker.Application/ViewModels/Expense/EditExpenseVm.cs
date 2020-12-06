using AutoMapper;
using ExpenseTracker.Application.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExpenseTracker.Application.ViewModels.Expense
{
    public class EditExpenseVm : IMapFrom<ExpenseTracker.Domain.Model.Entity.Expense>
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [DataType(DataType.Currency)]
        [RegularExpression(@"^[\d]+(\,\d{1,2})?$", ErrorMessage = "Required XXXX,XX format.")]
        [Required]
        public decimal Amount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EditExpenseVm, ExpenseTracker.Domain.Model.Entity.Expense>().ReverseMap();
        }
    }
}
