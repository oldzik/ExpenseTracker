using AutoMapper;
using ExpenseTracker.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.ViewModels.Expense
{
    public class ExpenseForListVm : IMapFrom<ExpenseTracker.Domain.Model.Entity.Expense>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ExpenseTracker.Domain.Model.Entity.Expense, ExpenseForListVm>()
                .ForMember(d => d.Category, opt => opt.MapFrom(s => s.DetailedCategory.Name));
        
        }
    }
}
