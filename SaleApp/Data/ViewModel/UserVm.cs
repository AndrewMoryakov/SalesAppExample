using System.ComponentModel.DataAnnotations;

namespace SaleAppExample.Data.ViewModel;

public class UserVm
{
	[Required]
	public string Email { get; set; } = string.Empty;

	[Required]
	[MinLength(6)]
	public string Password { get; set; } = string.Empty;
}