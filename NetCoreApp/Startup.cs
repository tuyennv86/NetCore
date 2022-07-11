using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NetCoreApp.Application.AutoMapper;
using NetCoreApp.Application.Implementation;
using NetCoreApp.Application.Interfaces;
using NetCoreApp.Data.EF;
using NetCoreApp.Data.EF.Repositories;
using NetCoreApp.Data.Entities;
using NetCoreApp.Data.IRepositories;
using NetCoreApp.Extensions;
using NetCoreApp.Helpers;
using NetCoreApp.Infrastructure.Interfaces;
using NetCoreApp.Services;
using System;

namespace NetCoreApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConection"),
                o => o.MigrationsAssembly("NetCoreApp.Data.EF")));

            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            services.AddMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(2);
                options.Cookie.HttpOnly = true;
            });

            // Configure Identity
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.AddTransient(typeof(IUnitOfWork), typeof(EFUnitOfWork));
            services.AddTransient(typeof(IRepository<,>), typeof(EFRepository<,>));

            //services.AddAutoMapper();
            // Add application services.
            services.AddScoped<UserManager<AppUser>, UserManager<AppUser>>();
            services.AddScoped<RoleManager<AppRole>, RoleManager<AppRole>>();

            //services.AddSingleton(Mapper.Configuration);
            services.AddSingleton(AutoMapperConfig.RegisterMappings().CreateMapper());
            //services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));

            services.AddScoped<IUserClaimsPrincipalFactory<AppUser>, CustomClaimsPrincipalFactory>();

            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<DbInitializer>();
            
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddTransient<IFunctionRepository, FunctionRepository>();

            services.AddTransient<IProductCategoryService, ProductCategoryService>();
            services.AddTransient<IFunctionService, FunctionService>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Logs/NetCoreApp-{Date}.txt");
            if (env.EnvironmentName == Environments.Development)
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();           
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);


            app.UseEndpoints(routes =>
            {
                routes.MapControllerRoute(
                     "default",
                     "{controller=Home}/{action=Index}/{id?}");

                routes.MapControllerRoute(
                    "areaRoute",
                    "{area:exists}/{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}