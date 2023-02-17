using System.ComponentModel.DataAnnotations.Schema;

namespace PracticumHomeWork.Models
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Title { get; set; }
        public int? GenreId { get; set; }
        public int? Duration { get; set; }
        public float? RatingScore { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
