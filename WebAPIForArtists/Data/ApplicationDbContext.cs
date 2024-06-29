using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAPIForArtists.Models;

namespace WebAPIForArtists.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {

        }

        public DbSet<Challenge> Challenges { get; set; }

        public DbSet<Club> Clubs { get; set; }

        public DbSet<Address> Addreses { get; set; }

    }
}
