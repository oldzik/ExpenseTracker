using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Domain.Model.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public Budget Budget { get; set; }
        public ICollection<MainCategory> MainCategories { get; set; }

    }
}
