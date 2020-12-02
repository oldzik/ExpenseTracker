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

namespace ExpenseTracker.Application.ViewModels.Expense
{
    public class NewExpenseVm : IMapFrom<ExpenseTracker.Domain.Model.Entity.Expense>
    {
        public int Id { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [DisplayName("Data")]
        public DateTime Date { get; set; }
        [DisplayName("Kwota")]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        [DisplayName("Kategoria")]
        public int SelectedCategory { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public string UserId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewExpenseVm, ExpenseTracker.Domain.Model.Entity.Expense>()
                .ForMember(d => d.DetailedCategoryId, opt => opt.MapFrom(s => s.SelectedCategory));
        }

    }
}
