using AppIdentityServer;
using AppIdentityServer.Data;
using AppIdentityServer.IdentityConfiguration;
using AppIdentityServer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


internal class Program
{
    private static void Main(string[] args)
    {
        var seed = args.Contains("/seed");
        if (seed)
        {
            args = args.Except(new[] { "/seed" }).ToArray();
        }
        var builder = WebApplication.CreateBuilder(args);

        var assembly = typeof(Program).Assembly.GetName().Name;
        var conn = builder.Configuration.GetConnectionString("DefaultConnection");
        if (seed)
        {
            SeedData.EnsureSeedData(conn);
        }
        //services
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<UserDbContext>(options =>
        options.UseSqlServer(conn, b => b.MigrationsAssembly(assembly)));
        builder.Services.AddIdentity<IdentityUser, IdentityRole>()

            .AddEntityFrameworkStores<UserDbContext>()
            .AddDefaultTokenProviders();
        //builder.Services.AddScoped<IUserClaimsPrincipalFactory<IdentityUser>, UserClaimsPrincipalFactory<IdentityUser, IdentityRole>>();
        builder.Services.AddIdentityServer()
            .AddAspNetIdentity<IdentityUser>()
            .AddConfigurationStore(options =>
            {
                options.ConfigureDbContext = b =>
                b.UseSqlServer(conn, opt => opt.MigrationsAssembly(assembly));
            })
            .AddOperationalStore(options =>
            {
                options.ConfigureDbContext = b =>
               b.UseSqlServer(conn, opt => opt.MigrationsAssembly(assembly));
            })
            .AddDeveloperSigningCredential()
        .AddProfileService<ProfileService>();


        var app = builder.Build();


        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        /*app.Use(async (context, next) =>
        {
            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                var testUser = new IdentityUser
                {
                    UserName = "testuser",
                    Email = "testuser@example.com",
                    EmailConfirmed = true
                };

                var user = await userManager.FindByNameAsync(testUser.UserName);
                if (user == null)
                {
                    var result = await userManager.CreateAsync(testUser, "Test@123");
                    if (!result.Succeeded)
                    {
                        throw new Exception("Failed to create test user: " + string.Join(", ", result.Errors.Select(e => e.Description)));
                    }
                }
            }

            await next.Invoke();
        });*/
        app.UseStaticFiles();
        
        app.UseRouting();
        app.UseIdentityServer();
        app.UseAuthorization();
        app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());

        app.Run();
    }
}