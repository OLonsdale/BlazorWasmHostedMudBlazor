using System.Text.Json.Serialization;
using Base.Server.Data;
using Base.Server.DataServices;
using Base.Server.Services;
using Microsoft.EntityFrameworkCore;

namespace Base.Server;

public static class Program
{
    
    /// Server sometimes returns blazor index.html page instead of an API response
    
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container
        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });
        
        builder.Services.AddRazorPages();

        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseInMemoryDatabase("InMemoryDb");
        });
        
        
        // Add data services
        builder.Services.AddScoped<TestService>();
        
        builder.Services.AddScoped<EmailSender>();
        
        var app = builder.Build();

        // Configure the HTTP request pipeline
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseBlazorFrameworkFiles();
        app.UseStaticFiles();
        
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapRazorPages();
        app.MapControllers();
        app.MapFallbackToFile("index.html");

        app.Run();
    }
}
