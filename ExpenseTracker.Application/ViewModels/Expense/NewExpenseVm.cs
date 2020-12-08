using AutoMapper;
using ExpenseTracker.Application.Mapping;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpenseTracker.Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ExpenseTracker.Application.ViewModels.Expense
{
    public class NewExpenseVm : IMapFrom<ExpenseTracker.Domain.Model.Entity.Expense>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        public int SelectedCategory { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public string UserId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewExpenseVm, ExpenseTracker.Domain.Model.Entity.Expense>()
                .ForMember(d => d.DetailedCategoryId, opt => opt.MapFrom(s => s.SelectedCategory));
        }

    }

    public class NewExpenseValidation : AbstractValidator<NewExpenseVm>
    {
        public NewExpenseValidation()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(2);
            RuleFor(x => x.Amount).NotEmpty();
        }
    }
}
