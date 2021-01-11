using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesProj.Models;

namespace RazorPagesProj.Pages.ViewKuch
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesProj.Models.ApplicationDbContext _context;

        public DeleteModel(RazorPagesProj.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Kucharka Kucharka { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Kucharka = await _context.Kucharka.FirstOrDefaultAsync(m => m.Id == id);

            if (Kucharka == null)
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

            Kucharka = await _context.Kucharka.FindAsync(id);

            if (Kucharka != null)
            {
                _context.Kucharka.Remove(Kucharka);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
