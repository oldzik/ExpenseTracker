using AutoMapper;
using ExpenseTracker.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.ViewModels.DetailedCategory
{
    public class DetailedCatForListVm : IMapFrom<ExpenseTracker.Domain.Model.Entity.DetailedCategory>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ExpenseTracker.Domain.Model.Entity.DetailedCategory, DetailedCatForListVm>();
        }
    }
}
