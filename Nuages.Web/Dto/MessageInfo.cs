// ReSharper disable UnusedMember.Global

namespace Nuages.Web.Dto;

// ReSharper disable once ClassNeverInstantiated.Global
public class MessageInfo
{
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public string? Code { get; set; }

    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public string Message { get; set; } = string.Empty;

    public MessageType MessageType { get; set; } = MessageType.Error;
}