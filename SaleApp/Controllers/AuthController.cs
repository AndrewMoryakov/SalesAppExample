using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SaleAppExample.Data.DbContext.Entities;
using SaleAppExample.Data.ViewModel;
using SaleAppExample.Security;

namespace SaleAppExample.Controllers;

[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class AuthController : ControllerBase
{
	private readonly IAuthenticationService<Buyer> _authenticationService;
	readonly UserManager<Buyer> _userManager;

	public AuthController(IAuthenticationService<Buyer> authService, UserManager<Buyer> usrManager)
	{
		_authenticationService = authService;
		_userManager = usrManager;
	}

	[HttpPost()]
	public async Task<ActionResult<Jwt>> GetAuth(UserVm user, CancellationToken cancellationToken = default)
	{
		var dbUser = await _userManager.FindByEmailAsync(user.Email);
		var tokenResult = _authenticationService.CreateAccessTokenAsync(dbUser, user.Password, cancellationToken);
		return Ok(tokenResult);

	}
}