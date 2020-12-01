using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.ViewModels.MainCategory
{
    public class ListMainCatForListVm
    {
        public List<MainCatForListVm> MainCategories { get; set; }
        public int Count { get; set; }
    }
}
