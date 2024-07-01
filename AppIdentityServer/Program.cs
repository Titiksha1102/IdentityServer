using AppIdentityServer.IdentityConfiguration;
using AppIdentityServer.Services;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        //services
        builder.Services.AddControllersWithViews();

        builder.Services.AddIdentityServer()
            .AddInMemoryClients(Clients.Get())
            .AddInMemoryIdentityResources(Resources.GetIdentityResources())
            .AddInMemoryApiResources(Resources.GetApiResources())
            .AddInMemoryApiScopes(Scopes.GetApiScopes())
            .AddTestUsers(Users.Get())
            .AddDeveloperSigningCredential()
            .AddProfileService<ProfileService>();


        var app = builder.Build();


        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseStaticFiles();
        app.UseRouting();
        app.UseIdentityServer();
        app.UseAuthorization();
        app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());

        app.Run();
    }
}