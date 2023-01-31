using System;

namespace SaleAppExample.Data.DbContext.Entities.Service;

public abstract class Entity<TKey> : IHasKey<TKey>, ITrackable where TKey:struct
{
    public TKey Id { get; set; }

    public DateTimeOffset CreatedDateTime { get; set; }

    public DateTimeOffset? UpdatedDateTime { get; set; }
}