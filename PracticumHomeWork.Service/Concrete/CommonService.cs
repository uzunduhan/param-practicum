using PracticumHomeWork.Service.Abstract;
using System.Text.RegularExpressions;

namespace PracticumHomeWork.Service.Concrete
{
    public class CommonService : ICommonService
    {
        public string getDataWithSpacesDeleted(string value)
        {
            var data = Regex.Replace(value, @"\s+", "");
            return data;
        }
    }
}
