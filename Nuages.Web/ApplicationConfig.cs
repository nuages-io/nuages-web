namespace Nuages.Web;

public class ApplicationConfig
{
    public ParameterStore ParameterStore { get; set; } = new();
    public AppConfig AppConfig { get; set; } = new();
}

public class ParameterStore
{
    public bool Enabled { get; set; }
    public string? Path { get; set; }
}

public class AppConfig
{
    public bool Enabled { get; set; }
    public string? ApplicationId { get; set; }
    public string? EnvironmentId { get; set; }
    public string? ConfigProfileId { get; set; }
}