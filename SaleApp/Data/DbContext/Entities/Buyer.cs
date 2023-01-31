using System;
using System.Collections.Generic;
using SaleAppExample.Data.DbContext.Entities.Service;

namespace SaleAppExample.Data.DbContext.Entities
{
	public class Buyer: Entity<Guid>
	{
		public string Name { get; set; }
		public ICollection<Sale> Sales { get; set; }
	}
}