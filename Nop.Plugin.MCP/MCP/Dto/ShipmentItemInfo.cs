namespace Nop.Plugin.Misc.Mcp.Dto;

/// <summary>
/// Represents a light-weight shipment item projection exposed through the MCP server
/// </summary>
public record ShipmentItemInfo
{
    public int Id { get; set; }

    public int ShipmentId { get; set; }

    public int OrderItemId { get; set; }

    public int Quantity { get; set; }

    public int WarehouseId { get; set; }
}

/// <summary>
/// Represents a shipment item provided by a caller to the create_shipment tool
/// </summary>
public record ShipmentItemInput
{
    public int OrderItemId { get; set; }

    public int Quantity { get; set; }
}