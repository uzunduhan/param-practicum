using PracticumHomeWork.Base.Model;

namespace PracticumHomeWork.Data.Models
{
    public class Genre : BaseModel
    {
        public string Name { get; set; }
        public bool? IsActive { get; set; } = true;
        public ICollection<Movie> Movies { get; }
    }
}
