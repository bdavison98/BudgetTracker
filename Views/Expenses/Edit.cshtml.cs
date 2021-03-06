#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesExpenses.Data;
using budge.Models;

namespace budge.Views.Expenses
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesExpenses.Data.RazorPagesExpensesContext _context;

        public EditModel(RazorPagesExpenses.Data.RazorPagesExpensesContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Expenses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpensesExists(Expenses.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ExpensesExists(int id)
        {
            return _context.Expenses.Any(e => e.ID == id);
        }
    }
}
