using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PracticumHomeWork.Models;

namespace PracticumHomeWork.DBOperations
{
    public class DataGenerator : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasData(
            new Movie
            {
                ID = 1,
                Title = "Forrest Gump",
                GenreId = 1, // drama
                Duration = 142,
                ReleaseDate = new DateTime(1994, 06, 12),
                RatingScore = 8
            },

           new Movie
           {
               ID = 2,
               Title = "Lord Of The Rings",
               GenreId = 2, //science fiction
               Duration = 570,
               ReleaseDate = new DateTime(2001, 10, 20),
               RatingScore = 9
           },
        
           new Movie
           {
               ID = 3,
               Title = "Treasure Planet",
               GenreId = 2, //science fiction
               Duration = 95,
               ReleaseDate = new DateTime(2010, 05, 12),
               RatingScore = 6
           },
        
           new Movie
           {
               ID = 4,
               Title = "Rocky",
               GenreId = 3, //science fiction
               Duration = 110,
               ReleaseDate = new DateTime(2005, 05, 12),
               RatingScore = 2
           });
        }
    }
}