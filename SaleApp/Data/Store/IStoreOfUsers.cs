using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SaleAppExample.Data.DbContext.Entities;
using SaleAppExample.Data.DbContext.Entities.Service;

namespace SaleAppExample.Data;

public interface IStoreOfUsers<TUser, TKey> where TUser : UserRoot<TKey> where TKey : struct, IEquatable<TKey>
{
	public Task<TUser> AddAsync(TUser user, string password);
}