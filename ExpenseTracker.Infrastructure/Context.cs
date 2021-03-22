using ExpenseTracker.Domain.Model.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Infrastructure
{
    public class Context : IdentityDbContext<ApplicationUser>
    {
        public Context(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<DetailedCategory> DetailedCategories { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<MainCategory> MainCategories { get; set; }
        public DbSet<PlannedExpense> PlannedExpenses { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .HasOne(a => a.Budget).WithOne(b => b.ApplicationUser)
                .HasForeignKey<Budget>(e => e.ApplicationUserRef)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
