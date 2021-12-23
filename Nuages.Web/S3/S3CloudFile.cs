namespace Nuages.Web.S3;

public class S3CloudFile
{
    public string Key { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public byte[]? Data { get; set; }
    public string BucketName { get; set; } = string.Empty;
}