using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Domain.Model.Entity
{
    public class Expense
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int BudgetId { get; set; }
        public int DetailedCategoryId { get; set; }

        public Budget Budget { get; set; }
        public DetailedCategory DetailedCategory { get; set; }

    }
}
