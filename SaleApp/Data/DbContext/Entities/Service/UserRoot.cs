using System;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Identity;
using SaleAppExample.Filters;

namespace SaleAppExample.Data.DbContext.Entities.Service;

[AdvanceIgnoreDataMember]
public class UserRoot<TKey> : IdentityUser<TKey>, Entity<TKey> where TKey : struct, IEquatable<TKey>
{
	[ProtectedPersonalData] public string UserName { get; set; }

	public string NormalizedUserName { get; set; }

	[ProtectedPersonalData] public string Email { get; set; }

	public string NormalizedEmail { get; set; }

	public bool EmailConfirmed { get; set; }

	public string PasswordHash { get; set; }

	[ProtectedPersonalData] public string PhoneNumber { get; set; }

	public bool PhoneNumberConfirmed { get; set; }

	public bool TwoFactorEnabled { get; set; }

	public string ConcurrencyStamp { get; set; }

	public string SecurityStamp { get; set; }

	public bool LockoutEnabled { get; set; }

	public DateTimeOffset? LockoutEnd { get; set; }

	public int AccessFailedCount { get; set; }
	public TKey Id { get; set; }
	public DateTimeOffset CreatedDateTime { get; set; }
	public DateTimeOffset? UpdatedDateTime { get; set; }
}