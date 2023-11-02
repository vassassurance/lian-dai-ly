using LianAgentPortal.Data;
using LianAgentPortal.Models.DbModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using LianAgentPortal.Services;

namespace LianAgentPortal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                )
            );

            //builder.Services.AddDatabaseDeveloperPageExceptionFilter();


            builder.Services
                .AddIdentity<LianUser, IdentityRole>(options => {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredLength = 6;
                    options.SignIn.RequireConfirmedAccount = true;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddScoped<ILianApiService, LianApiService>();
            //builder.Services.AddScoped<IPrintCommissionService, PrintCommissionService>();
            //builder.Services.AddScoped<IPrintCommissionShbetService, PrintCommissionShbetService>();
            //builder.Services.AddScoped<IPrintCommissionNew88Service, PrintCommissionNew88Service>();
            //builder.Services.AddScoped<IPrintCommissionMocBaiService, PrintCommissionMocBaiService>();
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddControllersWithViews()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                })
                .AddRazorRuntimeCompilation();


            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Authentication/SignIn";
                options.LogoutPath = $"/Authentication/Logout";
                options.AccessDeniedPath = $"/Authentication/AccessDenied";
            });
            builder.Services.AddRazorPages();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                db.Database.Migrate();
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}