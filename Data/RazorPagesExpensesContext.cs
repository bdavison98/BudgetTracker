#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using budge.Models;

namespace RazorPagesExpenses.Data
{
    public class RazorPagesExpensesContext : DbContext
    {
        public RazorPagesExpensesContext (DbContextOptions<RazorPagesExpensesContext> options)
            : base(options)
        {
        }

        public DbSet<budge.Models.Expenses> Expenses { get; set; }
    }
}
