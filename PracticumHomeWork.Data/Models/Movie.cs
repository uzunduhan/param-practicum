using PracticumHomeWork.Base.Model;

namespace PracticumHomeWork.Data.Models
{
    public class Movie : BaseModel
    {
        public string Title { get; set; }
        public int? GenreId { get; set; }
        public Genre Genre { get; set; }
        public int? Duration { get; set; }
        public float? RatingScore { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public ICollection<Director> Directors { get; set; }

    }
}
