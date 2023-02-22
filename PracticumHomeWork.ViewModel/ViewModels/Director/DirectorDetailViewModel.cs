using PracticumHomeWork.ViewModel.ViewModels.Movie;

namespace PracticumHomeWork.ViewModel.ViewModels.Director
{
    public class DirectorDetailViewModel
    {
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public List<MovieDetailViewModel> Movies { get; set; }
    }
}
