using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesProj.Models;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesProj.Pages.ViewKuch
{
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        //stránka opìt musí mít pøístup do databáze
        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Kucharka Kucharka { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Kucharka = new Kucharka();
            if (id == null)
            {
                //create
                return Page();
            }

            //update
            Kucharka = await _db.Kucharka.FirstOrDefaultAsync(m => m.Id == id); //dtto FindAsync(); 
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
                if (Kucharka.Id == 0)
                {
                    _db.Kucharka.Add(Kucharka);
                }
                else
                {
                    _db.Kucharka.Update(Kucharka);
                }

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }


    }
}
