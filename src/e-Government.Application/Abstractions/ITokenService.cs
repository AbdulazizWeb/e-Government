using System.Security.Claims;

namespace e_Government.Application.Abstractions
{
    public interface ITokenService
    {
        string GetAcessToken(Claim[] claims);
    }
}
