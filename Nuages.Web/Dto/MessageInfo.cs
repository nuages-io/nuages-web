// ReSharper disable UnusedMember.Global

using System.Diagnostics.CodeAnalysis;

namespace Nuages.Web.Dto;

// ReSharper disable once ClassNeverInstantiated.Global
[ExcludeFromCodeCoverage]
public class MessageInfo
{
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public string? Code { get; set; }

    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public string Message { get; set; } = string.Empty;

    public MessageType MessageType { get; set; } = MessageType.Error;
}