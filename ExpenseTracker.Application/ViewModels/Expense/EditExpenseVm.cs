using AutoMapper;
using ExpenseTracker.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.ViewModels.Expense
{
    public class EditExpenseVm : IMapFrom<ExpenseTracker.Domain.Model.Entity.Expense>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EditExpenseVm, ExpenseTracker.Domain.Model.Entity.Expense>().ReverseMap();
        }
    }
}
