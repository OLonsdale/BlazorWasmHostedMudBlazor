using Base.Server.Data;
// using Base.Shared.Entities;

namespace Base.Server.DataServices;

public class TestService
{
    private readonly AppDbContext db;

    public TestService(AppDbContext db)
    {
        this.db = db;
    }

    public string GetTestMessage()
    {
        return "Hello";
    }
}