using System;

namespace SaleAppExample.Data.DbContext.Entities.Service;

public class BaseEntity<TKey> : Entity<TKey> where TKey : struct
{
	public TKey Id { get; set; }
	public DateTimeOffset CreatedDateTime { get; set; }
	public DateTimeOffset? UpdatedDateTime { get; set; }
}