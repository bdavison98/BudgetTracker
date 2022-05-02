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
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesExpenses.Data.RazorPagesExpensesContext _context;

        public DeleteModel(RazorPagesExpenses.Data.RazorPagesExpensesContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Expenses = await _context.Expenses.FindAsync(id);

            if (Expenses != null)
            {
                _context.Expenses.Remove(Expenses);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
