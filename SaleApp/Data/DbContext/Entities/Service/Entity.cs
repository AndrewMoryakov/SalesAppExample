using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace SaleAppExample.Data.DbContext.Entities.Service;

public class Entity<TKey> : IHasKey<TKey>, ITrackable where TKey:struct
{
    [IgnoreDataMember]
    // [Key]
    [ScaffoldColumn(false)]
    // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public TKey Id { get; set; }
    [IgnoreDataMember]

    public DateTimeOffset CreatedDateTime { get; set; }
    [IgnoreDataMember]

    public DateTimeOffset? UpdatedDateTime { get; set; }
}