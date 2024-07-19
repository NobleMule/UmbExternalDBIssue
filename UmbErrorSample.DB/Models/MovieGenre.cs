using System.ComponentModel.DataAnnotations.Schema;

namespace UmbErrorSample.DB.Models
{
    [Table("movieGenre")]
    public class MovieGenre
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
