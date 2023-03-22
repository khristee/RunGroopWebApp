using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Data;
using RunGroopWebApp.Models;

namespace RunGroopWebApp.Controllers
{
    public class RaceController : Controller
    {
        private readonly ApplicationDbContext _db;

        public RaceController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Race> races =_db.Races.ToList();
            return View(races);
        }

        public IActionResult Detail(int id)
        {
            var race = _db.Races.Include(a => a.Address).FirstOrDefault(c => c.Id == id);
            return View(race);
        }
    }
}
