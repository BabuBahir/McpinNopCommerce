namespace Nop.Plugin.Misc.Mcp.Dto;

/// <summary>
/// Represents a paginated result exposed through the MCP server
/// </summary>
public record PagedResult<T>
{
    public int TotalCount { get; set; }

    public int PageIndex { get; set; }

    public int PageSize { get; set; }

    public int TotalPages { get; set; }

    public IList<T> Items { get; set; } = new List<T>();
}