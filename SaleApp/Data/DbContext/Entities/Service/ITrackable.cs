using System;

namespace SaleAppExample.Data.DbContext.Entities.Service;

public interface ITrackable
{
    DateTimeOffset CreatedDateTime { get; set; }

    DateTimeOffset? UpdatedDateTime { get; set; }   
}