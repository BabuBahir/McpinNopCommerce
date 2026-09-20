namespace Nop.Plugin.Misc.Mcp.Dto;

/// <summary>
/// Represents a metafield (nopCommerce generic attribute) encountered through the MCP server
/// </summary>
public record MetafieldInfo
{
    /// <summary>
    /// Gets or sets the entity type name, e.g. "product", "customer" or "order"
    /// </summary>
    public string EntityType { get; set; }

    /// <summary>
    /// Gets or sets the entity identifier the attribute is attached to
    /// </summary>
    public int EntityId { get; set; }

    /// <summary>
    /// Gets or sets the attribute key
    /// </summary>
    public string Key { get; set; }

    /// <summary>
    /// Gets or sets the attribute value
    /// </summary>
    public string Value { get; set; }
}