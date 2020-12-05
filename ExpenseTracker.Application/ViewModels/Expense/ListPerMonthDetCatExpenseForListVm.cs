using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.ViewModels.Expense
{
    public class ListPerMonthDetCatExpenseForListVm
    {
        public List<ExpenseForListVm> Expenses { get; set; }
        public int MainCategoryId { get; set; }
        public DateTime MonthOfYear { get; set; }
        public int Count { get; set; }
    }
}
