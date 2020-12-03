using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Domain.Model.Entity
{
    public class MonthOfYear
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int MonthId { get; set; }

        public Month Month { get; set; }

    }
}
