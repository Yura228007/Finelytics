using Finelytics.Components;
using ChartJs.Blazor;
using Microsoft.AspNetCore.Components.Web;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddRazorComponents().AddInteractiveServerComponents();
        var app = builder.Build();
        app.UseAntiforgery();
        app.UseStaticFiles();
        app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
        app.Run();
    }
}         