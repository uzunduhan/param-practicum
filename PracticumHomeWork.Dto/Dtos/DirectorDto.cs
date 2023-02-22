using PracticumHomeWork.Base.Dto;

namespace PracticumHomeWork.Dto.Dtos
{
    public class DirectorDto : BaseDto
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime Birthday { get; set; }
    }
}
