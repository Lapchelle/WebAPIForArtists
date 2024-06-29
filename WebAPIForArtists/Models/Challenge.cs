using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPIForArtists.Data.Enum;

namespace WebAPIForArtists.Models
{
    public class Challenge
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public DateTime? StartTime { get; set; }
        public string? Website { get; set; }
        public ChallengeCategory Category { get; set; }
        [ForeignKey("AppUser")]
        public string? UserId{ get; set; }
        public AppUser? AppUser { get; set; }
    }
}
