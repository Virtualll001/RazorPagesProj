using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesProj.Models;

namespace RazorPagesProj.Pages.ViewKuch
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty] //OnPost metoda dostane tuto instanci jako parametr (nemusí se už vypisovat do kulatých závorek)
        public Kucharka Kucharka { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _db.Kucharka.AddAsync(Kucharka);//tady zatím Kuchařka nebyla přidána = jen příprava
            await _db.SaveChangesAsync(); //až po tomto příkazu budou data uložena do databáze
            return RedirectToPage("./Index");
        }
    }
}
