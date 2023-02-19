namespace PracticumHomeWork.Data.Models
{
    public class MovieParameters
    {
        public uint ReleaseDateMin { get; set; }
        public uint ReleaseDateMax { get; set; } = (uint)DateTime.Now.Year;
        public bool ValidYearRange => ReleaseDateMax > ReleaseDateMin;
    }
}
