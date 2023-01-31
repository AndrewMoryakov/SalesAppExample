using System;
using Microsoft.AspNetCore.Identity;

namespace SaleAppExample.Data.DbContext.Entities.Service;

public class UserRoot<TKey>:IdentityUser   
{
    public DateTimeOffset CreatedDateTime { get; set; }
    public DateTimeOffset? UpdatedDateTime { get; set; }
}