using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Domain.Model.Entity
{
    public class DetailedCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MainCategoryId { get; set; }

        public MainCategory MainCategory { get; set; }
        public ICollection<Expense> Expenses { get; set; }
        public ICollection<PlannedExpense> PlannedExpenses { get; set; }

    }
}
