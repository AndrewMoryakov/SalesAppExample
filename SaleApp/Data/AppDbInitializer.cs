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
	private static IConfiguration _conf;
	public static void Initialize(CustomBaseDataContext context, IConfiguration conf, IUnitOfWork uof)
	{
		_conf = conf;
		_uof = uof;
		
		if ((conf["SeedForce"].ToLower() == "true" || conf["DbProvider"].ToLower() == "ram")
		    || (conf["DbProvider"].ToLower() != "ram" && !((RelationalDatabaseCreator)context.GetService<IDatabaseCreator>()).Exists()))
		{
			using (context)
				CreateDb(context);
		}
	}

	private static void CreateDb(CustomBaseDataContext context)
	{
		if(_conf["DbProvider"].ToLower() != "ram")
			context.Database.EnsureCreated();

		var users = new List<Product>
		{
			new()
			{
				Id = Guid.NewGuid(),
				Name = "Молотый кофе",
				Price = 10
			},
			new()
			{
				Id = Guid.NewGuid(),
				Name = "Вода",
				Price = 2
			},
			new()
			{
				Id = Guid.NewGuid(),
				Name = "Сливочное масло",
				Price = 5
			},
			new()
			{
				Id = Guid.NewGuid(),
				Name = "Кокосовое масло",
				Price = 6
			}
		};
		
		foreach (var user in users)
		{
			_uof.Repository<Product, Guid>().Insert(user);			
		}

		context.SaveChanges();
	}
}