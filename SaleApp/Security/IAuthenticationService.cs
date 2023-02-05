using System;
using System.Threading;
using Microsoft.AspNetCore.Identity;
using SaleAppExample.Data.DbContext.Entities.Service;

namespace SaleAppExample.Security;

public interface IAuthenticationService<in TUser> where TUser:UserRoot<Guid>
{
    public Jwt CreateAccessTokenAsync(TUser user, string password, CancellationToken cancellationToken);
}