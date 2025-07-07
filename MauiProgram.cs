using BlzMauiApp.Data;
using Blazorise;
using Blazorise.Icons.FontAwesome;
using Radzen;
using Microsoft.AspNetCore.Components.Authorization;
using BlzMauiApp.AuthProvider;
using Blazored.LocalStorage;
using BlzMauiApp.Services;
using BlzMauiApp.Models;
using BlzMauiApp.Services.Data;
using BlzMauiApp.Services.DataService;
using MatBlazor;

namespace BlzMauiApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("slick.ttf", "slick");
            });

        builder.Services.AddMauiBlazorWebView();
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
#endif

        //Register needed elements for authentication
        builder.Services.AddAuthorizationCore();// This is the core functionality
        builder.Services.AddScoped<CustomAuthStateProvider>();// This is our custom provider


        //When asking for the default Microsoft one, give ours!
        builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<CustomAuthStateProvider>());

        //builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>()
        //    .AddScoped<IAlertService, AlertService>();

        builder.Services.AddSingleton<WeatherForecastService>();
        builder.Services.AddSingleton<CDialogService>();

        builder.Services.AddSingleton<APIDataService>();

        builder.Services
  .AddBlazorise(options =>
  {
      options.Immediate = true;
  })
  .AddFontAwesomeIcons();

        // Set path to the SQLite database (it will be created if it does not exist)
        //var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"BenvueIntM.db");

        // Register WeatherForecastService and the SQLite database
        //builder.Services.AddSingleton<LoginDatabase>(
        //    s => ActivatorUtilities.CreateInstance<LoginDatabase>(s, dbPath));

        //builder.Services.AddSingleton<LoginDatabase>();

        //builder.Services.AddSingleton<ILoginDatabase, LoginDatabase>();

        //builder.Services.AddSingleton(new LoginDatabase());

        //builder.Services.AddScoped<AlertService>();

        builder.Services.AddScoped<IAlertService, AlertService>();
        
        builder.Services.AddScoped<NotificationService>();
        builder.Services.AddScoped<TooltipService>();
        builder.Services.AddScoped<ContextMenuService>();

        builder.Services.AddMatBlazor();

        builder.Services.AddBlazoredLocalStorage();


        return builder.Build();
    }
}
