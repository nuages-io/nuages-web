namespace Nuages.Web;

public class ApplicationConfig
{
    public ParameterStore? ParameterStore { get; set; }
    public AppConfig? AppConfig { get; set; }
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