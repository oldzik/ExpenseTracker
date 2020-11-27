using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.ViewModels.Expense
{
    public class ListExpenseForListVm
    {
        public List<ExpenseForListVm> Expenses { get; set; }
        public int Count { get; set; }
    }
}
