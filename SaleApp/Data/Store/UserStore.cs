using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SaleAppExample.Data.DbContext;
using SaleAppExample.Data.DbContext.Entities;
using SaleAppExample.Data.DbContext.Entities.Service;
using SaleAppExample.Data.UnitOfWork;
using SaleAppExample.Data.UnitOfWork.Repositories;

namespace SaleAppExample.Data;

public class UserStore<TUser, TKey>: IStoreOfUsers<TUser, TKey> where TUser : UserRoot<TKey> where TKey : struct, IEquatable<TKey>
{
	private IPasswordHasher<TUser> _pswrdHasher;
	private IUnitOfWork _uow;
	private IRepository<TUser, TKey> _userRep;

	public UserStore(CustomBaseDataContext context, IPasswordHasher<TUser> pswHasher,
		IUnitOfWork uow)
	{
		_pswrdHasher = pswHasher;
		_uow = uow;
		_userRep = _uow.Repository<TUser, TKey>();
	}

	public async Task<TUser> AddAsync(TUser user, string password)
	{
		user.NormalizedEmail = user.Email.ToUpper();
		if (!_userRep.GetAll().Any(u => u.NormalizedEmail == user.NormalizedEmail))
		{
			user.CreatedDateTime = DateTimeOffset.Now;
			var hashed = _pswrdHasher.HashPassword(user, password);
			user.PasswordHash = hashed;
			_userRep.Insert(user);
		}
		else
		{
			throw new BadHttpRequestException("User with email already exists");
		}

		return user;
	}
}