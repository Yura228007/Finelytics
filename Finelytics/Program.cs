using finelytics.Domain;
using finelytics.Domain.Controllers;
using finelytics.Components;
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
        builder.Services.AddScoped<ICategoriesController, CategoriesController>();
        builder.Services.AddScoped<IGroupsController,GroupsController>();
        builder.Services.AddScoped<IPlansController, PlansController>();
        builder.Services.AddScoped<IPlansCategoriesController, PlansCategoriesController>();
        builder.Services.AddScoped<ITransactionsController, TransactionsController>();
        builder.Services.AddScoped<IUsersController, UsersController>();
        builder.Services.AddScoped<IUsersGroupsController, UsersGroupsController>();
        builder.Services.AddScoped<IUsersPlansController, UsersPlansController>();
        var app = builder.Build();
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
        }
            app.UseAntiforgery();
            app.UseStaticFiles();
            app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
            app.MapDefaultControllerRoute();
            app.Run();
        }
}



