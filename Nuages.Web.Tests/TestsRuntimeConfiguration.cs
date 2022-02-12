using Xunit;

namespace Nuages.Web.Tests;


public class TestsRuntimeConfiguration
{
    [Fact]
    public void ShouldTestRuntimeCOnfigurationWithSuccess()
    {
        IRuntimeConfiguration config = new RuntimeConfiguration();
        
#if DEBUG
        Assert.True(config.IsDebug);
#else
        Assert.False(config.IsDebug);
#endif
        
        Assert.False(config.IsTest);
    }
}