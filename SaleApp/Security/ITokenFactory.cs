using System;
using Microsoft.AspNetCore.Identity;
using SaleAppExample.Data.DbContext.Entities.Service;

namespace SaleAppExample.Security;

public interface ITokenFactory<in TUser> where TUser:UserRoot<Guid>
{
    Jwt CreateAccessToken(TUser user);
}