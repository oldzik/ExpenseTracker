using ExpenseTracker.Application.ViewModels.PlannedExpense;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Interfaces
{
    public interface IPlannedExpenseService
    {
        ListNewPlannedExpensePerMonthVm CreateNewPlannedExpPerMonth(string userId);
        void AddPlannedExpensesPerMonth(ListNewPlannedExpensePerMonthVm model);
        PlannedExpensesOfAllMainCatVm GetPlannedExpensesOfAllMainCPerMonth(DateTime monthOfYear, string userId);
    }
}
