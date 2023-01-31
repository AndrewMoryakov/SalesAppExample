using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using SaleAppExample.Data.DbContext;
using SaleAppExample.Data.UnitOfWork;

namespace SaleAppExample
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<CustomBaseDataContext, ApplicationMemoryDbContext>();
            //
            switch (Configuration["DbProvider"])
            {
                case "sqlite":
                    services.AddEntityFrameworkSqlite().AddDbContext<ApplicationMemoryDbContext>(
                        opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionSqlite")));
                    break;
                case "mssql":
                    services.AddEntityFrameworkSqlServer().AddDbContext<ApplicationMemoryDbContext>(
                        opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionMsSql")));
                    break;
                case "ram":
                    services.AddEntityFrameworkInMemoryDatabase().AddDbContext<ApplicationMemoryDbContext>(
                        opt => opt.UseInMemoryDatabase("dateBaseInMemory"));
                    break;
            }

            services.AddAuthorization();
            // services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddControllers().AddControllersAsServices();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SaleAppExample", Version = "v1" });
                c.EnableAnnotations();
            });
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
