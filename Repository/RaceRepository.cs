using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Data;
using RunGroopWebApp.Interfaces;
using RunGroopWebApp.Models;

namespace RunGroopWebApp.Repository
{
    public class RaceRepository : IRaceRepository
    {
        private readonly ApplicationDbContext _db;

        public RaceRepository(ApplicationDbContext db)
        {
           _db = db;
        }
        public bool Add(Race race)
        {
            _db.Add(race);
            return Save();
        }

        public bool Delete(Race race)
        {
            _db.Remove(race);
            return Save();
        }

        public async Task<IEnumerable<Race>> GetAll()
        {
            return await _db.Races.ToListAsync();
        }

        public async Task<IEnumerable<Race>> GetAllRacesByCity(string race)
        {
            return await _db.Races.Where(r => r.Address.City.Contains(race)).ToListAsync();
        }

        public async Task<Race> GetByIdAsync(int id)
        {
            return await _db.Races.Include(i => i.Address).FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _db.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Race race)
        {
            _db.Update(race);
            return Save();
        }
    }
}
