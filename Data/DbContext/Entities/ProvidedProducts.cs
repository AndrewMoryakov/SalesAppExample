using System;
using System.Collections.Generic;
using SaleAppExample.Data.DbContext.Entities.Service;

namespace SaleAppExample.Data.DbContext.Entities
{
	public class ProvidedProducts : Entity<Guid>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<Sale> Sales { get; set; }
	}
}