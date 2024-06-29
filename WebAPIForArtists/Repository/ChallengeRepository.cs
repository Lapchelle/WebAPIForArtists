using Microsoft.EntityFrameworkCore;
using WebAPIForArtists.Data;
using WebAPIForArtists.Interfaces;
using WebAPIForArtists.Models;

namespace WebAPIForArtists.Repository
{
    public class ChallengeRepository : IChallengeRepository
    {
        private readonly ApplicationDbContext _context;

        public ChallengeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Challenge challenge)
        {
            _context.Add(challenge);
            return Save();
        }

        public bool Delete(Challenge challenge)
        {
            _context.Remove(challenge);
            return Save();
        }

        public async Task<IEnumerable<Challenge>> GetAll()
        {
            return await _context.Challenges.ToListAsync();
        }

        public async Task<Challenge> GetByIdAsync(int id)
        {
            return await _context.Challenges.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Challenge> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Challenges.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Challenge challenge)
        {
            _context.Update(challenge);
            return Save();
        }
    }
}
