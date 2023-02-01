using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using SaleAppExample.Data.DbContext.Entities.Service;

namespace SaleAppExample.Data.DbContext.Entities
{
	public class Buyer: Entity<Guid>
	{
		public string Name { get; set; }
		[IgnoreDataMember]
		public ICollection<Sale> Sales { get; set; }
	}
}