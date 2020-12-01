using AutoMapper;
using ExpenseTracker.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.ViewModels.MainCategory
{
    public class NewMainCategoryVm : IMapFrom<ExpenseTracker.Domain.Model.Entity.MainCategory>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewMainCategoryVm, ExpenseTracker.Domain.Model.Entity.MainCategory>().ReverseMap();
        }
    }
}
