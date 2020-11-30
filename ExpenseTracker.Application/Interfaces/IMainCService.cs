using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Interfaces
{
    public interface IMainCService
    {
        public void CreateMainCategoriesForNewUser(string userId);
    }
}
