#region

#endregion

using System.Diagnostics.CodeAnalysis;

namespace Nuages.Web.Dto;

// ReSharper disable once UnusedType.Global
[ExcludeFromCodeCoverage]
public class SearchResult<T>
{
    // ReSharper disable once InconsistentNaming
    // ReSharper disable once CollectionNeverUpdated.Global
    // ReSharper disable once UnusedMember.Global
    public List<T>? data { get; set; }
}