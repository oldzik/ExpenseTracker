using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Domain.Model.Entity
{
    public class PlannedExpense
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime MonthOfYear { get; set; }
        public int DetailedCategoryId { get; set; }


        public DetailedCategory DetailedCategory { get; set; }


    }
}
