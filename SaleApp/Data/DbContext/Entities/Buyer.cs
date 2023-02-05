using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using SaleAppExample.Data.DbContext.Entities.Service;
using SaleAppExample.Data.UnitOfWork.Repositories;
using SaleAppExample.Filters;

namespace SaleAppExample.Data.DbContext.Entities
{
	public class Buyer: UserRoot<Guid>
	{
		public string Name { get; set; }
		[IgnoreDataMember]
		public ICollection<Sale> Sales { get; set; }
		[IgnoreDataMember]
		[JsonIgnore]
		public string Password { get; set; }
	}
}