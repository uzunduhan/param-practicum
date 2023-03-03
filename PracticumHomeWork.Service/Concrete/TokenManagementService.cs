using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PracticumHomeWork.Base.Jwt;
using PracticumHomeWork.Data.Models;
using PracticumHomeWork.Data.Repository.Abstract;
using PracticumHomeWork.Data.UnitOfWork.Abstract;
using PracticumHomeWork.Dto.Models;
using PracticumHomeWork.Service.Abstract;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PracticumHomeWork.Service.Concrete
{
    public class TokenManagementService : ITokenManagementService
    {
        private readonly IGenericRepository<User> genericRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtConfig _jwtConfig;
        private readonly byte[] _secret;

        public TokenManagementService(IGenericRepository<User> genericRepository, IMapper mapper, IUnitOfWork unitOfWork, IOptionsMonitor<JwtConfig> jwtConfig)
        {
            this.genericRepository = genericRepository;
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
            this._jwtConfig = jwtConfig.CurrentValue;
            this._secret = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
        }


        public async Task<TokenResponse> GenerateTokensAsync(TokenRequest tokenRequest, DateTime now, string userAgent)
        {
            try
            {
                var account = genericRepository.Where(x => x.UserName == tokenRequest.UserName).FirstOrDefault();
                if (account is null)
                {
                    throw new InvalidOperationException("InvalidUserInformation");
                }

                if (account.Password != tokenRequest.Password)
                {
                    throw new InvalidOperationException("InvalidUserInformation");
                }

                var token = GenerateAccessToken(account, now);

                account.LastActivity = DateTime.Now;
                _unitOfWork.UserRepository.Update(account);
                await _unitOfWork.CompleteAsync();

                TokenResponse response = new TokenResponse
                {
                    AccessToken = token,
                    ExpireTime = now.AddMinutes(_jwtConfig.AccessTokenExpiration),
                    Role = account.Role,
                    UserName = account.UserName
                };

                return response;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Token_Error");
            }
        }

        private string GenerateAccessToken(User account, DateTime now)
        {
            // Get claim value
            Claim[] claims = GetClaim(account);

            var shouldAddAudienceClaim = string.IsNullOrWhiteSpace(claims?.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?.Value);

            var jwtToken = new JwtSecurityToken(
                _jwtConfig.Issuer,
                shouldAddAudienceClaim ? _jwtConfig.Audience : string.Empty,
                claims,
                expires: now.AddMinutes(_jwtConfig.AccessTokenExpiration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(_secret), SecurityAlgorithms.HmacSha256Signature));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return accessToken;
        }

        private static Claim[] GetClaim(User account)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
                new Claim(ClaimTypes.Name, account.UserName),
                new Claim(ClaimTypes.Role, account.Role),
                new Claim("AccountId", account.Id.ToString()),
                new Claim("LastActivity", account.LastActivity.ToLongTimeString())
            };

            return claims;
        }

    }
}
