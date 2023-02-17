namespace PracticumHomeWork.DTOs
{
    public class CreateMovieModel
    {
        public string Title { get; set; }
        public int? GenreId { get; set; }
        public int? Duration { get; set; }
        public float? RatingScore { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
