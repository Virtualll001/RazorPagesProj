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
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesProj.Models.ApplicationDbContext _context;

        public DetailsModel(RazorPagesProj.Models.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
