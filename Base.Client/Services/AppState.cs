namespace Base.Client.Services;

public class AppState(IConfiguration config)
{
    public string AppName { get; } = config["AppName"] ?? "App Name Not Set";
    public string AppBarName { get; } = config["AppBarName"] ?? "App Bar Name Not Set";
}