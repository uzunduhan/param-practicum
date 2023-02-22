using PracticumHomeWork.Base.Model;

namespace PracticumHomeWork.Data.Models
{
    public class Director : BaseModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime Birthday { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
