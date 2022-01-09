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
        
        const string value = "éêôâàèîûù";
        
        Assert.Equal("eeoaaeiuu", TextHelper.RemoveAccents(value));
    }
}