using ExpenseTracker.Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Domain.Interface
{
    public interface IBudgetRepository
    {
        public Budget GetBudgetByUserId(string userId);
        public int AddBudget(Budget budget);
        public Budget GetBudgetById(int id);
        public void UpdateAmount(Budget budget);
    }
}
