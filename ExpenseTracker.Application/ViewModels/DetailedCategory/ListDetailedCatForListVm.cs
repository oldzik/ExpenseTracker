using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.ViewModels.DetailedCategory
{
    public class ListDetailedCatForListVm
    {
        public List<DetailedCatForListVm> DetailedCategories { get; set; }
        public int Count { get; set; }
    }
}
