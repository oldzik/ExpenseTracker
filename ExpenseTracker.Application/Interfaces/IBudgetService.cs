using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Interfaces
{
    public interface IBudgetService
    {
        public void CreateBudgetForNewUser(string userId);
    }
}
