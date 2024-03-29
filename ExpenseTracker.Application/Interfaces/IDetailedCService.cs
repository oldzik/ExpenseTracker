﻿using ExpenseTracker.Application.ViewModels.DetailedCategory;
using ExpenseTracker.Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpenseTracker.Application.Interfaces
{
    public interface IDetailedCService
    {
        public void CreateDetailedCategoriesForNewUser(string userId);
        ListDetailedCatForListVm GetDetailedCategoriesForList(int mainCategoryId);
        int AddDetailedCategory(NewDetailedCategoryVm model);
        NewDetailedCategoryVm GetDetailedCategoryForEdit(int detailedCategoryId);
        public void UpdateDetailedCategory(NewDetailedCategoryVm model);
        void DeleteDetailedCategory(int detailedCategoryId);
        NewDetailedCategoryVm GetNewDetailedCategoryToCreate(int mainCategoryId);
    }
}
