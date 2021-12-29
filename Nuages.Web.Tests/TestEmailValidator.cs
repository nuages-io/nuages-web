using Nuages.Web.Utilities;
using Xunit;

namespace Nuages.Web.Tests;

public class TestEmailValidator
{
    [Fact]
    public void SHouldValidateEMail()
    {
        var emailValidator = new EmailValidator();
        
        Assert.True(emailValidator.IsValidEmail("m@m.io"));
        Assert.False(emailValidator.IsValidEmail("m@.io"));
    }
}