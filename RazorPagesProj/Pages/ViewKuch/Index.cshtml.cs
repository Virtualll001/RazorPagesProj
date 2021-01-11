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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        //instance ApplicationDbContext, která je přidaná jako služba v metodě ConfigureServices() ve Startup.cs

        public IndexModel(ApplicationDbContext db)
        //dependency injection - do konstruktoru dostaneme instanci z Dependency Containeru
        {
            _db = db;
        }

        public IEnumerable<Kucharka> Kucharka { get; set; }

        public async Task OnGetAsync() //
        {
            Kucharka = await _db.Kucharka.ToListAsync();
        }
        //Async vyžaduje using Microsoft.EntityFrameworkCore; umožňuje více úkolů za běhu;
        /*z databáze přijmeme obsah a uložíme ho do "Kucharka" - IEnumerable (umožňuje průchod kolekcí);
         díky tomu jsou data k dispozici pro View k zobrazení;
         v MVC by tato metoda byla OnAction*/

        public async Task<IActionResult> OnPostDelete(int id) //Post handler - protože jde o tlačítko
        {
            var recept = await _db.Kucharka.FindAsync(id);
            if (recept == null)
            {
                return NotFound();
            }
            _db.Kucharka.Remove(recept);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
