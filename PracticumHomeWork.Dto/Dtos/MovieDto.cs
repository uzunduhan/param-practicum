using PracticumHomeWork.Base.Dto;
using System.ComponentModel.DataAnnotations;

namespace PracticumHomeWork.Dto.Dtos
{
    public class MovieDto : BaseDto
    {
        [Required]
        [MaxLength(125)]
        public string Title { get; set; }

        [Required]
        public int? GenreId { get; set; }

        [Required]
        public int? Duration { get; set; }

        [Required]
        public float? RatingScore { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
