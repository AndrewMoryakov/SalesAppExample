using System;
using SaleAppExample.Data.DbContext.Entities.Service;

namespace SaleAppExample.Data.DbContext.Entities
{
	public class Product : Entity<Guid>
	{
		public string Name { get; set; }
		public decimal Price { get; set; }
		public Guid Id { get; set; }
		public DateTimeOffset CreatedDateTime { get; set; }
		public DateTimeOffset? UpdatedDateTime { get; set; }
	}
}