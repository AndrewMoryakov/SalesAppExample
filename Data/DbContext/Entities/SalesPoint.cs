using System;
using System.Collections.Generic;
using SaleAppExample.Data.DbContext.Entities.Service;

namespace SaleAppExample.Data.DbContext.Entities
{
	public class SalesPoint : Entity<Guid>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public ICollection<ProvidedProducts> Products { get; set; }
	}
}