using PracticumHomeWork.ViewModel.ViewModels.Movie;

namespace PracticumHomeWork.ViewModel.ViewModels.Genre
{
    public class GenreDetailViewModel
    {
        public string Name { get; set; }
        public List<MovieDetailViewModel> Movies { get; set; }
    }
}
