using PracticumHomeWork.Data.DBOperations;
using PracticumHomeWork.Data.Models;

namespace TestSetup
{
    public static class Movies
    {
        public static void AddMovies(this DatabaseContext context)
        {
             context.Movies.AddRange(
                       //ID = 1,
                         new Movie{
                          Title = "test1",
                          GenreId = 1, // personel growth
                          Duration = 200,
                          RatingScore = 7,
                          ReleaseDate = new DateTime(2001,06,12)
                          },

                          new Movie
                          {
                              Title = "test2",
                              GenreId = 1, // personel growth
                              Duration = 200,
                              RatingScore = 7,
                              ReleaseDate = new DateTime(2001, 06, 12)
                          },
                            
                        new Movie
                        {
                            Title = "test3",
                            GenreId = 1, // personel growth
                            Duration = 200,
                            RatingScore = 7,
                            ReleaseDate = new DateTime(2001, 06, 12)
                        }
                );

        }
    }
}