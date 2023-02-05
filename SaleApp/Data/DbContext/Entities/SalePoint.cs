using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using SaleAppExample.Data.DbContext.Entities.Service;

namespace SaleAppExample.Data.DbContext.Entities
{
	public class SalePoint : BaseEntity<Guid>
	{
		public string Name { get; set; }
		public string Address { get; set; }
		[IgnoreDataMember]
		public ICollection<ProvidedProduct> ProvidedProducts { get; set; }
		[IgnoreDataMember]
		public ICollection<Sale> SaleOfThisSalePoint { get; set; }
	}
}