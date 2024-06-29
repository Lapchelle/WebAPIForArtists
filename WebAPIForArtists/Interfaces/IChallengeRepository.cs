using WebAPIForArtists.Models;

namespace WebAPIForArtists.Interfaces
{
    public interface IChallengeRepository
    {
        Task<IEnumerable<Challenge>> GetAll();

        Task<Challenge> GetByIdAsync(int id);

        Task<Challenge> GetByIdAsyncNoTracking(int id);

        bool Add(Challenge challenge);

        bool Update(Challenge challenge);

        bool Delete(Challenge challenge);

        bool Save();
    }
}
