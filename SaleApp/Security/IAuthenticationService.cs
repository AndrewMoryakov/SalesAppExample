using System.Threading;
using Microsoft.AspNetCore.Identity;

namespace SaleAppExample.Security;

public interface IAuthenticationService<in TUser> where TUser:IdentityUser
{
    public Jwt CreateAccessTokenAsync(TUser user, string password, CancellationToken cancellationToken);
}