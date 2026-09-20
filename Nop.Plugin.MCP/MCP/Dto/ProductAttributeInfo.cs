namespace Nop.Plugin.Misc.Mcp.Dto;

/// <summary>
/// Represents a product attribute mapping projection exposed through the MCP server
/// </summary>
public record ProductAttributeInfo
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int ProductAttributeId { get; set; }

    public string AttributeName { get; set; }

    public string TextPrompt { get; set; }

    public bool IsRequired { get; set; }

    public string AttributeControlType { get; set; }

    public int DisplayOrder { get; set; }

    public IList<ProductAttributeValueInfo> Values { get; set; } = new List<ProductAttributeValueInfo>();
}

/// <summary>
/// Represents a product attribute value projection exposed through the MCP server
/// </summary>
public record ProductAttributeValueInfo
{
    public int Id { get; set; }

    public string Name { get; set; }

    public decimal PriceAdjustment { get; set; }

    public bool PriceAdjustmentUsePercentage { get; set; }

    public decimal WeightAdjustment { get; set; }

    public decimal Cost { get; set; }

    public bool IsPreSelected { get; set; }

    public int DisplayOrder { get; set; }
}

/// <summary>
/// Represents a product attribute combination projection exposed through the MCP server
/// </summary>
public record ProductCombinationInfo
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string AttributesXml { get; set; }

    public int StockQuantity { get; set; }

    public bool AllowOutOfStockOrders { get; set; }

    public string Sku { get; set; }

    public string ManufacturerPartNumber { get; set; }

    public string Gtin { get; set; }

    public decimal? OverriddenPrice { get; set; }

    public int NotifyAdminForQuantityBelow { get; set; }

    public int MinStockQuantity { get; set; }
}