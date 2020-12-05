using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.ViewModels.Expense
{
    public class ListExpenseForListVm
    {
        public List<ExpenseForListVm> Expenses { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public DateTime MonthOfYear { get; set; }
        public string UserId { get; set; }
        public int Count { get; set; }
    }
}
