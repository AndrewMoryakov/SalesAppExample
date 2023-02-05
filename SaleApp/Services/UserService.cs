using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SaleAppExample.Data.DbContext;
using SaleAppExample.Data.DbContext.Entities;

namespace SaleAppExample.Services;

public class UserService: IUserService, IDisposable
{
	private UserManager<Buyer> _userManager;
	private CustomBaseDataContext _context;

	private SignInManager<Buyer> _signInManager2;
	private IPasswordHasher<Buyer> _passwordHasher;
	private IHttpContextAccessor _httpContext;

	public UserService(CustomBaseDataContext context, UserManager<Buyer> userManager,
		SignInManager<Buyer> signInManager2, IPasswordHasher<Buyer> hasher,
		IHttpContextAccessor httpContext
	)
	{
		_userManager = userManager;
		_signInManager2 = signInManager2;
		_passwordHasher = hasher;
		_httpContext = httpContext;
		_context = context;
	}
	
	public string GetEmailCurrentUser()
	{
		return _httpContext.HttpContext.User.Claims
			.FirstOrDefault(el => el.Type == ClaimTypes.Email)?.Value;
	}

	public Guid GetCurrentUserId()
	{
		return new Guid(_httpContext.HttpContext.User.Claims
			.FirstOrDefault(el => el.Type == ClaimTypes.NameIdentifier)?.Value);
	}

	private bool disposed = false;
	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!disposed)
		{
			if (disposing)
			{
			}


			_userManager?.Dispose();
			_context?.Dispose();

			disposed = true;
		}
	}

	~UserService()
	{
		Dispose(false);
	}
}