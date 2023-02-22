using PracticumHomeWork.ViewModel.ViewModels.Movie;

namespace PracticumHomeWork.ViewModel.ViewModels.Director
{
    public class DirectorsViewModel
    {
        public string FullName { get; set; }
        public List<MovieDetailViewModel> Movies { get; set; }
    }
}
