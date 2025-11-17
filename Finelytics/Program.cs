using finelytics.Domain;
using finelytics.Components;
using Microsoft.EntityFrameworkCore;
using finelytics;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddRazorComponents().AddInteractiveServerComponents();

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddControllersWithViews();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        //builder.Services.AddScoped<ICategoriesController, CategoriesController>();
        //builder.Services.AddScoped<IGroupsController,GroupsController>();
        //builder.Services.AddScoped<IPlansController, PlansController>();
        //builder.Services.AddScoped<IPlansCategoriesController, PlansCategoriesController>();
        //builder.Services.AddScoped<ITransactionsController, TransactionsController>();
        //builder.Services.AddScoped<IUsersController, UsersController>();
        //builder.Services.AddScoped<IUsersGroupsController, UsersGroupsController>();
        //builder.Services.AddScoped<IUsersPlansController, UsersPlansController>();
        builder.Services.AddScoped(sp =>
            new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5169")
            }
        );

        builder.Services.AddScoped<UsersService>();
        builder.Services.AddSingleton<PlansService>();
        builder.Services.AddScoped<CategoriesService>();
        builder.Services.AddScoped<TransactionsService>();

        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
        }

        app.UseAntiforgery();
        app.UseStaticFiles();
        app.MapControllers();
        app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
        app.MapDefaultControllerRoute();
        app.Run();
    }
}



