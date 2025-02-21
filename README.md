# Template for a Dotnet API Hosted Blazor WASM App with MudBlazor UI

## Usage

Download project, use Rider to rename `Base` to your new Project name. You can use Visual Studio, but it tends to bork stuff and require external editing of `.sln` and `.csproj`s

Set your db connection in the server `appsettings.json`, currently uses InMemory database for testing

Replace icons and set app name in `Client > wwwroot > appsettings.json`. AppName is used in the login screen, and AppBarName is displayed in the top bar at larger screen sizes. They're different to allow for more customisation. For example one client has the Header-Logo as the first initial of their company name, so the appbarname is the rest of their company name.

Implement the email sender according to your requirements.

## Non Standard stuff

I use statics for routes for both client and API. This raises some unintuitive aspects when it comes to binding params, but I think it's worth it.

