﻿using ExpenseTracker.Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpenseTracker.Domain.Interface
{
    public interface IPlannedExpenseRepository
    {
        void AddPlannedExpenses(List<PlannedExpense> newPlannedExpenses);
        IQueryable<PlannedExpense> GetAllPlannedExpensesOfMainCat(int mainCatId, DateTime monthOfYear);
        PlannedExpense GetPlannedExpenseOfDetailedCat(int detailedCatid, DateTime monthOfYear);
        PlannedExpense GetPlannedExpenseById(int plannedExpenseId);
        void UpdatePlannedExpense(PlannedExpense plannedExpense);
        PlannedExpense ReturnFirstPlannedExpInMainCategory(int mainCatId, DateTime monthOfYear);
        PlannedExpense ReturnFirstPlannedExpInMonth(DateTime date);
    }
}
