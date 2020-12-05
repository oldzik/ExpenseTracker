using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.ViewModels.PlannedExpense
{
    public class PlannedExpensesOfAllDetailedCatVm
    {
        public List<PlannedExpensesOfDetailedCatVm> PlannedExpOfDetailedCat { get; set; }
        public DateTime MonthOfYear { get; set; }
        public int MainCategoryId { get; set; }
        public string MainCategoryName { get; set; }
        public int Count { get; set; }
    }
}
