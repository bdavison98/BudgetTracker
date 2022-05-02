#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesExpenses.Data;
using budge.Models;

namespace budge.Views.Expenses
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesExpenses.Data.RazorPagesExpensesContext _context;

        public IndexModel(RazorPagesExpenses.Data.RazorPagesExpensesContext context)
        {
            _context = context;
        }

        public IList<Expenses> Expenses { get;set; }

        public async Task OnGetAsync()
        {
            Expenses = await _context.Expenses.ToListAsync();
        }
    }
}
