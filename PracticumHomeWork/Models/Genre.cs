using PracticumHomeWork.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticumHomeWork.Models
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
