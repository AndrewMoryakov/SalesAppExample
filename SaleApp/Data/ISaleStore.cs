using System;
using System.Threading;
using System.Threading.Tasks;
using SaleAppExample.Data.DbContext.Entities;

namespace SaleAppExample.Data;

public interface ISaleStore
{
	Task<Sale> AddAsync(Sale sale, CancellationToken ct);
}