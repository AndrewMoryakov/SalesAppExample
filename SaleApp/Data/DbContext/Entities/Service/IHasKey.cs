using System.Security.Principal;

namespace SaleAppExample.Data.DbContext.Entities.Service;

public interface IHasKey<T> 
{
    T Id { get; set; }
}