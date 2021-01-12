using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RazorPagesProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesProj.Controllers
{
    [Route("api/Kucharka")] //routing je jen tady!
    [ApiController] //api je potřeba přidat do services ve Startup.cs!
    public class KucharkaController : Controller
    {
        private readonly ApplicationDbContext _db;

        public KucharkaController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Kucharka.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var receptFromDb = await _db.Kucharka.FirstOrDefaultAsync(u => u.Id == id);
            if (receptFromDb == null)
            {
                return Json(new { success = false, message = "Při mazání došlo k chybě." });
            }
            _db.Kucharka.Remove(receptFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Odstranění zápisu proběhlo úspěšně." });
        }
    }
}
