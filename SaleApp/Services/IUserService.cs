using System;

namespace SaleAppExample.Services;

public interface IUserService
{
	public string GetEmailCurrentUser();
	public Guid GetCurrentUserId();
}