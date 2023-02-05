using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using SaleAppExample.Data.DbContext;
using SaleAppExample.Data.DbContext.Entities;
using SaleAppExample.Data.UnitOfWork;
using SaleAppExample.Data.UnitOfWork.Repositories;

namespace SaleAppExample.Data;

public static class AppDbInitializer
{
	private static IUnitOfWork _uof;
	private static IConfiguration _conf;
	private static IStoreOfUsers<Buyer, Guid> _userStore;
	public static void Initialize(CustomBaseDataContext context, IConfiguration conf, IUnitOfWork uof,
		IStoreOfUsers<Buyer, Guid> userStore)
	{
		_conf = conf;
		_uof = uof;
		_userStore = userStore;
		
		if ((conf["SeedForce"].ToLower() == "true" || conf["DbProvider"].ToLower() == "ram")
		    || (conf["DbProvider"].ToLower() != "ram" && !((RelationalDatabaseCreator)context.GetService<IDatabaseCreator>()).Exists()))
		{
			using (context)
				CreateDb(context);
		}
	}

	private static async Task CreateDb(CustomBaseDataContext context)
	{
		if(_conf["DbProvider"].ToLower() != "ram")
			context.Database.EnsureCreated();

		var users = new List<Buyer>
		{
			new Buyer()
			{
				Id = new Guid("1d3ebe1f-1f0b-451a-9b5e-b094b0f49d27"),
				Email = "ivan@test.org",
				Name = "Иван",
				Password = "123qwe@"
			},
			new()
			{
				Id = new Guid("2d3ebe1f-1f0b-451a-9b5e-b094b0f49d27"),
				Email = "petr@test.org",
				Name = "Петр",
				Password = "123qwe@"
			},
		};

		foreach (var user in users)
		{
			await _userStore.AddAsync(user, user.Password);
			// _uof.Repository<Buyer, Guid>().Insert(user);
		}
		
		
		var products = new List<Product>
		{
			new()
			{
				Id = new Guid("3d3ebe1f-1f0b-451a-9b5e-b094b0f49d27"),
				Name = "Молотый кофе",
				Price = 10
			},
			new()
			{
				Id = new Guid("4d3ebe1f-1f0b-451a-9b5e-b094b0f49d27"),
				Name = "Вода",
				Price = 2
			},
			new()
			{
				Id = new Guid("5d3ebe1f-1f0b-451a-9b5e-b094b0f49d27"),
				Name = "Сливочное масло",
				Price = 5
			},
			new()
			{
				Id = new Guid("6d3ebe1f-1f0b-451a-9b5e-b094b0f49d27"),
				Name = "Кокосовое масло",
				Price = 6
			}
		};
		
		foreach (var user in products)
		{
			_uof.Repository<Product, Guid>().Insert(user);
		}
		context.SaveChanges();

		var salePoint = new SalePoint
		{
			Id = new Guid("7d3ebe1f-1f0b-451a-9b5e-b094b0f49d27"),
			Name = "Кофейник",
			Address = "Во дворе",
		};
		_uof.Repository<SalePoint, Guid>().Insert(salePoint);
		context.SaveChanges();

		var firstProvidedProducts = new ProvidedProduct
		{
			Id = new Guid("8d3ebe1f-1f0b-451a-9b5e-b094b0f49d27"),
			ProductId = products[0].Id,
			ProductQuantity = 10,
			SalePointId = salePoint.Id
		};
		
		_uof.Repository<ProvidedProduct, Guid>().Insert(firstProvidedProducts);
		context.SaveChanges();
	}
}