using Microsoft.AspNetCore.Mvc;
using RazorPagesProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesProj.Controllers
{
    [Route("api/Kucharka")]
    [ApiController]
    public class KucharkaController : Controller
    {
        private readonly ApplicationDbContext _db;

        public KucharkaController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _db.Kucharka.ToList()});
        }
    }
}
