using System;
using System.Collections.Generic;
using SaleAppExample.Data.DbContext.Entities.Service;

namespace SaleAppExample.Data.DbContext.Entities
{
	public class SalePoint : Entity<Guid>
	{
		public string Name { get; set; }
		public string Address { get; set; }
		public ICollection<ProvidedProduct> ProvidedProducts { get; set; }
	}
}