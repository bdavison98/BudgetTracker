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
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesExpenses.Data.RazorPagesExpensesContext _context;

        public DetailsModel(RazorPagesExpenses.Data.RazorPagesExpensesContext context)
        {
            _context = context;
        }

        public Expenses Expenses { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Expenses = await _context.Expenses.FirstOrDefaultAsync(m => m.ID == id);

            if (Expenses == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
