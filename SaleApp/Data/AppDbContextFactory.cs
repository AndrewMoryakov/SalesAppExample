using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaleAppExample.Data.DbContext;

namespace SaleAppExample.Data;

public class AppDbContextFactory : IDesignTimeDbContextFactory<ApplicationMemoryDbContext>
{
	private IConfiguration _config;
	private IServiceProvider _services;
	public AppDbContextFactory(IConfigurationRoot config, IServiceProvider services)
	{
		_config = config;
		_services = services;
	}

	public AppDbContextFactory()
	{
	}

	public ApplicationMemoryDbContext CreateDbContext(string[] args)
	{
		//var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
		//optionsBuilder.us("Data Source=blog.db");

		//return new BloggingContext(optionsBuilder.Options);
		IConfigurationRoot configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build();

		var dbContext = _services.GetRequiredService<CustomBaseDataContext>();
		// var builder = new DbContextOptionsBuilder<ApplicationMemoryDbContext>();
		var db = _services.GetRequiredService<CustomBaseDataContext>();
		// if(_config!= null)
		// 	switch (_config["DbProvider"])
		// {
		// 	case "sqlite":
		// 		services.AddEntityFrameworkSqlite().AddDbContext<ApplicationMemoryDbContext>(
		// 			opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionSqlite")));
		// 		break;
		// 	case "mssql":
		// 		services.AddEntityFrameworkSqlServer().AddDbContext<ApplicationMemoryDbContext>(
		// 			opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionMsSql")));
		// 		break;
		// 	case "ram":
		// 		services.AddEntityFrameworkInMemoryDatabase().AddDbContext<ApplicationMemoryDbContext>(
		// 			opt => opt.UseInMemoryDatabase("dateBaseInMemory"));
		// 		break;
		// }
		//
		// if (_config!=null && _config["DbProvider"] == "pgsql")
		// 	builder.UseNpgsql(configuration.GetConnectionString("DefaultConnectionPgsql"));
		// else if (_config ==null || _config["DbProvider"] == "mssql")
		// 	builder.UseSqlServer(configuration.GetConnectionString("DefaultConnectionMsSql"));
		// else if (_config == null || _config["DbProvider"] == "mysql")
		// 	builder.UseMySQL(configuration.GetConnectionString("DefaultConnectionMysql"));
		// else if (_config == null || _config["DbProvider"] == "ram")
		// 	builder.UseInMemoryDatabase("dateBaseInMemory");
		//
		// return new ApplicationDbContext(builder.Options);
		return null;
	}
}