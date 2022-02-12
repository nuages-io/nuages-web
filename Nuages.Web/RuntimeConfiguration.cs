namespace Nuages.Web;

public class RuntimeConfiguration : IRuntimeConfiguration
{
    public bool IsDebug
    {
        get
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }
    }

    public bool IsTest => false;
}

public interface IRuntimeConfiguration
{
    bool IsDebug { get; }
    bool IsTest { get; }
}