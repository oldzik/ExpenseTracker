using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Interfaces
{
    public interface IDetailedCService
    {
        public void CreateDetailedCategoriesForNewUser(string userId);
    }
}
