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
        public int DetailedCategoryId { get; set; }
        public string DetailedCategoryName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewPlannedExpenseVm, ExpenseTracker.Domain.Model.Entity.PlannedExpense>();               
        }
    }
}
