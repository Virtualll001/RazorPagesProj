using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesProj.Models;

namespace RazorPagesProj.Pages.ViewKuch
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        //stránka opět musí mít přístup do databáze
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Kucharka Kucharka { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Kucharka = await _db.Kucharka.FirstOrDefaultAsync(m => m.Id == id);

            if (Kucharka == null)
            {
                return NotFound();
            }
            return Page();
        }


        public async Task<IActionResult> OnPost()
        {

            if (ModelState.IsValid)
            {
                var RazorPagesProj = await _db.Kucharka.FindAsync(Kucharka.Id);
                RazorPagesProj.Jmeno = Kucharka.Jmeno;
                RazorPagesProj.Ingredience = Kucharka.Ingredience;
                RazorPagesProj.Recept = Kucharka.Recept;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }




















        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _db.Attach(Kucharka).State = EntityState.Modified;

        //    try
        //    {
        //        await _db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!KucharkaExists(Kucharka.Id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return RedirectToPage("./Index");
        //}

        //private bool KucharkaExists(int id)
        //{
        //    return _db.Kucharka.Any(e => e.Id == id);
        //}
    }
}
