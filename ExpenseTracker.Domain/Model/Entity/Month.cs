using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Domain.Model.Entity
{
    public class Month
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<MonthOfYear> MonthOfYears { get; set; }

    }
}
