using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.ViewModels.PlannedExpense
{
    public class ListNewPlannedExpensePerMonthVm
    {
        public List<NewPlannedExpenseVm> PlannedExpenses { get; set; }
        public DateTime MonthOfYear { get; set; }

    }
}
