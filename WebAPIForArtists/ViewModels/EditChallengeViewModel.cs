using WebAPIForArtists.Data.Enum;
using WebAPIForArtists.Models;

namespace WebAPIForArtists.ViewModels
{
    public class EditChallengeViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IFormFile Image { get; set; }

        public string? URL { get; set; }

       

        public ChallengeCategory Category { get; set; }
    }
}
