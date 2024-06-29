using System.ComponentModel.DataAnnotations;

namespace WebAPIForArtists.Models
{
    public class Address
    {
        [Key]

        public  int Id { get; set; }
        public string? Park { get; set; }

        public string? City { get; set; }
        public string? Region { get; set; }
    }
}
