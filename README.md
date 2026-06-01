# BlzMauiApp

BlzMauiApp is a .NET MAUI Blazor Hybrid mobile/desktop application. It hosts a Blazor UI inside a MAUI `BlazorWebView` and targets Android, iOS, Mac Catalyst, and Windows.

The application appears to be a sales/invoice workflow app for a distribution or commerce business. It includes login, dashboard, invoice listing, invoice details, invoice creation, customer/product lookup, local SQLite storage, and API-backed data loading.

## Project Type

- Framework: .NET MAUI Blazor Hybrid
- Current target framework: .NET 6
- UI host: `MainPage.xaml` with `BlazorWebView`
- Blazor app root: `Main.razor`
- Main host page: `wwwroot/index.html`
- Local database: SQLite via `sqlite-net-pcl`
- UI libraries: Radzen.Blazor, Blazorise, MatBlazor, Bootstrap assets

## Main Features

- User login and local authentication state
- Dashboard/home page
- Sales invoice list with pagination
- Sales invoice details page
- Sales invoice creation flow
- Branch, zone, area, representative, customer, and product lookup
- Local SQLite persistence for user login information
- Mobile-style layout with top header, side navigation, and bottom navigation

## Project Structure

```text
AuthProvider/       Custom Blazor authentication state provider
Data/               Sample weather data from the default template
Helpers/            App configuration, route helpers, utility models
Models/             DTOs and view models for login, products, invoices, customers
Pages/              Blazor pages and app screens
Platforms/          MAUI platform-specific Android, iOS, MacCatalyst, Windows, Tizen files
Resources/          MAUI app icons, splash images, fonts, raw assets
Services/           API, alert, dialog, local storage, and SQLite services
Shared/             Layout, header, navigation, login redirect, alert components
wwwroot/            CSS, JavaScript, images, manifest, and Blazor host page
```

## Important Files

- `BlzMauiApp.csproj` - MAUI project configuration, target frameworks, package references, assets
- `MauiProgram.cs` - dependency injection and MAUI/Blazor service registration
- `MainPage.xaml` - hosts the Blazor app in a `BlazorWebView`
- `Main.razor` - Blazor router and authorization routing
- `Pages/LoginPage.razor` - login screen and login flow
- `Pages/SalesList.razor` - sales invoice listing and filters
- `Pages/SalesAdd.razor` - sales invoice entry screen
- `Services/DataService/APIDataService.cs` - remote API calls
- `Services/Data/LoginDatabase.cs` - local SQLite access
- `AuthProvider/CustomAuthStateProvider.cs` - custom auth state generation from local user data
- `Helpers/AppConfiguration.cs` - API URLs, tokens, and local database path settings

## Build

Restore dependencies:

```powershell
dotnet restore BlzMauiApp.sln
```

Build the solution:

```powershell
dotnet build BlzMauiApp.sln
```

Build a specific Windows target:

```powershell
dotnet build BlzMauiApp.csproj -f net6.0-windows10.0.19041.0
```

## Current Status Notes

- The project currently targets .NET 6, which is out of support.
- `Pages/SalesList.razor` contains unresolved Git conflict markers and must be fixed before a clean build.
- Some platform files may be compiled into the wrong target depending on the installed MAUI workload/SDK configuration.
- Authentication currently uses a mix of SQLite and secure storage; this should be consolidated.
- API credentials and sample login credentials are currently hard-coded and should be removed from source control.
- Several pages instantiate services directly instead of using dependency injection.
- Several code paths use synchronous waits such as `Task.Run(...).Result`; these should be converted to normal async flows.

## Recommended Next Steps

1. Resolve the merge conflict in `Pages/SalesList.razor`.
2. Upgrade the app from .NET 6 to a supported .NET MAUI version.
3. Move API tokens and credentials out of source code.
4. Refactor API and SQLite services to use dependency injection consistently.
5. Replace blocking async calls with `async`/`await`.
6. Consolidate login/auth state around one storage mechanism.
