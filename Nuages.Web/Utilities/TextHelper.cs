namespace Nuages.Web.Utilities;

public static class TextHelper
{
    public static string RemoveAccents(string text)
    {
        var tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(text);
        return System.Text.Encoding.UTF8.GetString(tempBytes);
    }
}