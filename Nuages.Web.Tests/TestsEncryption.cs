using System;
using Nuages.Web.Utilities;
using Xunit;

namespace Nuages.Web.Tests;

public class TestsEncryption
{
    [Fact]
    public void EncryptAndDecrypt()
    {
        IEncryption encryption = new Encryption();
            
        var key = Guid.NewGuid().ToString();
        const string value = "Test";

        var encryptedValue = encryption.Encrypt(value, key);
        var decryptedValue = encryption.Decrypt(encryptedValue, key);

        Assert.Equal(value, decryptedValue);
    }

    [Fact]
    public void EncryptAndDecryptWithSalt()
    {
        IEncryption encryption = new Encryption();
            
        var key = Guid.NewGuid().ToString();
        const string value = "Test";

        var encryptedValue = encryption.EncryptWithSalt(value, key);
        var decryptedValue = encryption.DecryptWithSalt(encryptedValue, key);

        Assert.Equal(value, decryptedValue);
    }
}