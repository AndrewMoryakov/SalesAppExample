using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using SaleAppExample.Data.DbContext;
using SaleAppExample.Data.DbContext.Entities;
using SaleAppExample.Data.UnitOfWork;

namespace SaleAppExample.Data;

public class AppDbInitializer
{
	private static IUnitOfWork _uof;
	public static void Initialize(ApplicationMemoryDbContext context, IConfiguration conf, IUnitOfWork uof)
	{
		if (conf["SeedForce"].ToLower() == "true"
		    || !((RelationalDatabaseCreator)context.GetService<IDatabaseCreator>()).Exists())
		{
			using (context)
				CreateDb(context);
		}

		_uof = uof;
	}

	private static void CreateDb(ApplicationMemoryDbContext context)
	{
		context.Database.EnsureCreated();

		var users = new List<Product>
		{
			new()
			{
				Id = Guid.NewGuid(),
				Name = "Молотый кофе"
			},
			new()
			{
				Id = Guid.NewGuid(),
				Name = "Вода"
			},
			// new()
			// {
			//     Name = "Сливочное масло"
			// },
			// new()
			// {
			//     Name = "Кокосовое масло"
			// }
		};
		
		foreach (var user in users)
		{
			_uof.Repository<Product, Guid>().Insert(user);			
		}

		context.SaveChanges();
	}
}