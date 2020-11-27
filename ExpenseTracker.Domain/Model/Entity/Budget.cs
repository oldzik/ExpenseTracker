using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Domain.Model.Entity
{
    public class Budget
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public string ApplicationUserRef { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<Expense> Expenses { get; set; }

    }
}
