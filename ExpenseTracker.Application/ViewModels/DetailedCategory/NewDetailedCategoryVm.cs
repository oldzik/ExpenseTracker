using AutoMapper;
using ExpenseTracker.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.ViewModels.DetailedCategory
{
    public class NewDetailedCategoryVm : IMapFrom<ExpenseTracker.Domain.Model.Entity.DetailedCategory>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MainCategoryId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewDetailedCategoryVm, ExpenseTracker.Domain.Model.Entity.DetailedCategory>().ReverseMap();
        }
    }
}
