using PracticumHomeWork.Dto.Models;

namespace PracticumHomeWork.Service.Abstract
{
    public interface ITokenManagementService
    {
        Task<TokenResponse> GenerateTokensAsync(TokenRequest loginResource, DateTime now, string userAgent);
    }
}
