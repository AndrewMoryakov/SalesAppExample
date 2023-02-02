using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using SaleAppExample.Data;
using SaleAppExample.Data.DbContext;
using SaleAppExample.Data.DbContext.Entities;
using SaleAppExample.Data.UnitOfWork;
using SaleAppExample.Filters;
using SaleAppExample.Security;

namespace SaleAppExample
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        
        //ToDo Добавить Unit тесты
        //ToDo доработать логику контроллера продаж
        //ToDO доработать авторизацю
        //ToDo перепроверить по DRY, SOLID
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<CustomBaseDataContext, ApplicationMemoryDbContext>();
            switch (Configuration["DbProvider"])
            {
                case "sqlite":
                    services.AddDbContext<ApplicationMemoryDbContext>(
                        opt => opt.UseSqlite(Configuration.GetConnectionString("DefaultConnectionSqlite")));
                    break;
                case "mssql":
                    services.AddDbContext<ApplicationMemoryDbContext>(
                        opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionMsSql")));
                    break;
                case "ram":
                    services.AddDbContext<ApplicationMemoryDbContext>(
                        opt => opt.UseInMemoryDatabase("dateBaseInMemory"));
                    break;
            }

            services.AddSingleton<IPasswordHasher<Buyer>, PasswordHasher<Buyer>>();
            services.AddScoped<ISaleStore, SaleStore>();
            services.AddAuthorization();
            // services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddControllers().AddControllersAsServices();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SaleAppExample", Version = "v1" });
                c.EnableAnnotations();
                c.SchemaFilter<SwaggerSchemaFilter>();

            });
            
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            });
            
            //ToDO тут надо поработать над подключением Buyer как IdentityUser  
            // services.AddScoped<ITokenFactory<Buyer>, TokenFactory<Buyer>>();	        
            // services.AddScoped<IAuthenticationService<Buyer>, AuthenticationService<Buyer>>();
	        
	        
            services.Configure<AuthTokenOptions>(Configuration.GetSection("AuthOptions"));
            var authTokenOptions = Configuration.GetSection("AuthOptions").Get<AuthTokenOptions>() as AuthTokenOptions;
            var signingConfigurations = new SigningCredentialsKeys(authTokenOptions.Secret) as SigningCredentialsKeys;
            services.AddSingleton(signingConfigurations);
            services.ConfigureJwtAuthentication(authTokenOptions, signingConfigurations);

            services.AddAuthorization();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SaleAppExample v1");
                c.DocumentTitle = "test api";
            });
            

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("CorsPolicy");
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
