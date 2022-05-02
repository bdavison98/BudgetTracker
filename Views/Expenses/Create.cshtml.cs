#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesExpenses.Data;
using budge.Models;

namespace budge.Views.Expenses
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesExpenses.Data.RazorPagesExpensesContext _context;

        public CreateModel(RazorPagesExpenses.Data.RazorPagesExpensesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Expenses Expenses { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Expenses.Add(Expenses);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
