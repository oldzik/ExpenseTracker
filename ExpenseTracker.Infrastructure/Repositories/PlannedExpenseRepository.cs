using ExpenseTracker.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Infrastructure.Repositories
{
    public class PlannedExpenseRepository : IPlannedExpenseRepository
    {
        private readonly Context _context;
        public PlannedExpenseRepository (Context context)
        {
            _context = context;
        }
    }
}
