using System.ComponentModel.DataAnnotations.Schema;

namespace UmbErrorSample.DB.Models
{
    [Table("movie")]
    public class Movie
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int ReleaseYear { get; set; }
        public string? MainActor { get; set; }
        public List<MovieGenre> Genres { get; set; }
    }
}
