// using Base.Shared.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Base.Server.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext
{
    
    // public DbSet<TestObject> TestObjects { get; set; }

    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //default precision for decimals
        foreach (var property in builder.Model.GetEntityTypes()
                     .SelectMany(t => t.GetProperties())
                     .Where(p => (p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)) &&
                                 (p.GetPrecision() == null || p.GetScale() == null)))
        {
            property.SetPrecision(18);
            property.SetScale(2);
        }


    }
    
}