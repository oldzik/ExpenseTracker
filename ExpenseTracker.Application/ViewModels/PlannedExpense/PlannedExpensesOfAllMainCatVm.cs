using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.ViewModels.PlannedExpense
{
    public class PlannedExpensesOfAllMainCatVm
    {       
        public List<PlannedExpensesOfMainCatVm> PlannedExpOfMainCat { get; set; }
        public decimal SumOfPlanned { get; set; }
        public DateTime MonthOfYear { get; set; }
        public int Count { get; set; }

    }
}
