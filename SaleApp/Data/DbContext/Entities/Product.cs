using System;
using SaleAppExample.Data.DbContext.Entities.Service;
using SaleAppExample.Filters;

namespace SaleAppExample.Data.DbContext.Entities
{
	public class Product : BaseEntity<Guid>
	{
		public string Name { get; set; }
		public decimal Price { get; set; }
	}
}