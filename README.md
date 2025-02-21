# Template for a Dotnet API Hosted Blazor WASM App with JWT Auth

## Usage

Download project, use Rider to rename `Base` to your new Project name. You can use Visual Studio, but it tends to bork stuff and require external editing of `.sln` and `.csproj`s

Project assumes Guid V7s as primary keys, which allows for PKs to be assigned on the client/server side to allow for manual saving of nested objects without having to do a round trip to generate and recall primary keys. This is an easy fix however, just replace any instance of Guid with your chosen primary key type, and remove the initialisations of `Guid.CreateVersion7()`;

Set your db connection in the server `appsettings.json`, currently uses InMemory database for testing

Replace icons and set app name in `Client > wwwroot > appsettings.json`. AppName is used in the login screen, and AppBarName is displayed in the top bar at larger screen sizes. They're different to allow for more customisation. For example one client has the Header-Logo as the first initial of their company name, so the appbarname is the rest of their company name.

Add your roles to the `Shared > Enums > AppRole`s enum and add their description to the dictionary. I'd advise adding one role per "functionality" of the app, mostly one per page.

Implement the email sender according to your requirements.

## Non Standard stuff

I'm not using the Identity Roles at all, I've got a custom implementation that allows for groups to be created by users.

My Login with Two Factor involves submitting first the username and password, then if "requires two factor" is returned, when the user enters their code, it submits the username, password, and 2fa code in the same request.

I use statics for routes for both client and API. This raises some unintuitive aspects when it comes to binding params, but I think it's worth it.

In the API Side you can use `[RequiresRoles(requireAllRoles: false, AppRole.Admin, AppRole.Test)]` to make endpoints require one of a list of roles, or all of a list of roles.

Likewise on the client side, my `AuthorizeComponent` can be used to hide elements based on the same criteria.

My JWTs have more processing on the server side than they're supposed to, but that's really the only way to have user lockouts take effect immediately rather than after the current jwt expires.



## References

[A large amount of the JWT stuff came from this tutorial on reddit](https://www.reddit.com/r/csharp/comments/u6n8nz/the_bullshitless_aspnet_blazor_wasm_jwt/)

