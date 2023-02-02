using System;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using SaleAppExample.Data.DbContext;

namespace SaleAppExample.Data;

public class AppDbContextFactory : IDesignTimeDbContextFactory<CustomBaseDataContext>
{
	private IServiceProvider _services;

	public AppDbContextFactory(IServiceProvider services)
	{
		_services = services;
	}

	public CustomBaseDataContext CreateDbContext(string[] args)
	{
		var db = _services.GetRequiredService<CustomBaseDataContext>();
		return db;
	}
}