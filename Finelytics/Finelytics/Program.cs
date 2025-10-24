using Finelytics.Components;
using ChartJs.Blazor;
using Microsoft.AspNetCore.Components.Web;
using Finelytics.Domain;
using Microsoft.EntityFrameworkCore;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddRazorComponents().AddInteractiveServerComponents();
        
        builder.Services.AddDbContext<AppDbContext>(options => 
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddControllersWithViews();

        var app = builder.Build();
        
        app.UseAntiforgery();
        app.UseStaticFiles();
        app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
        app.MapDefaultControllerRoute();
        app.Run();
    }
}         