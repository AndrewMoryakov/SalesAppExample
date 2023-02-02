using Microsoft.AspNetCore.Identity;

namespace SaleAppExample.Security;

public interface ITokenFactory<in TUser> where TUser:IdentityUser
{
    Jwt CreateAccessToken(TUser user);
}