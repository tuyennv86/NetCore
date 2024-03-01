using EntityFrameworkCore.UseRowNumberForPaging;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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
using NetCoreApp.Authorization;
using NetCoreApp.Data.EF;
using NetCoreApp.Data.EF.Repositories;
using NetCoreApp.Data.Entities;
using NetCoreApp.Data.IRepositories;
using NetCoreApp.Helpers;
using NetCoreApp.Infrastructure.Interfaces;
using NetCoreApp.Services;
using System;
using System.Threading.Tasks;

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
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConection"), o => o.UseRowNumberForPaging()));           

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
                       
            //Config returnUrl when no login
            services.ConfigureApplicationCookie(options => {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                //options.LoginPath = "/Login";
                //options.AccessDeniedPath = "/AccessDenied";
                options.SlidingExpiration = true;
                options.Events = new CookieAuthenticationEvents
                {
                    OnRedirectToLogin = ctx => {
                        var requestPath = ctx.Request.Path;
                        if (requestPath.StartsWithSegments("/Admin"))
                        {
                            ctx.Response.Redirect("/Admin?ReturnUrl=" + requestPath + ctx.Request.QueryString);
                        }
                        else
                        {
                            ctx.Response.Redirect("/Account/Login?ReturnUrl=" + requestPath + ctx.Request.QueryString);
                        }
                        return Task.CompletedTask;
                    }
                };
            });

            services.AddTransient(typeof(IUnitOfWork), typeof(EFUnitOfWork));
            services.AddTransient(typeof(IRepository<,>), typeof(EFRepository<,>));
            
            // Add application services.
            services.AddScoped<UserManager<AppUser>, UserManager<AppUser>>();
            services.AddScoped<RoleManager<AppRole>, RoleManager<AppRole>>();
            
            services.AddSingleton(AutoMapperConfig.RegisterMappings().CreateMapper());            

            services.AddScoped<IUserClaimsPrincipalFactory<AppUser>, CustomClaimsPrincipalFactory>();

            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<DbInitializer>();
                        
            services.AddTransient<ICategoryTypeRepository, CategoryTypeRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IFunctionRepository, FunctionRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ITagRepository, TagRepository>();
            services.AddTransient<IProductTagRepository, ProductTagRepository>();
                        
            services.AddTransient<IFunctionService, FunctionService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategoryTypeService, CategoryTypeService>();
            services.AddTransient<ICategoryService, CategoryService>();

            services.AddTransient<ITourRepository, TourRepository>();
            services.AddTransient<ITourService, TourService>();
            services.AddTransient<ITourDateRepository, TourDateRepository>();
            services.AddTransient<ITourDateService, TourDateService>();
            services.AddTransient<ITourImagesRepository, TourImagesRepository>();
            services.AddTransient<ITourImagesService, TourImagesService>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IPermissionRepository, PermissionRepository>();
            
            // đăng ký phân quyền 
            services.AddTransient<IAuthorizationHandler, BaseResourceAuthorizationHandler>();

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