using System.Text;
using Nuages.Web.Utilities;
using Xunit;

namespace Nuages.Web.Tests;

public class TestsTextHelper
{
    [Fact]
    public void ShouldRemoveAccent()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        
        string value = "éêôâàèîûù";
        
        Assert.Equal("eeoaaeiuu", TextHelper.RemoveAccents(value));
        Assert.True(false);
    }
}