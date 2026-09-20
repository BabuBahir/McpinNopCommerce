nopCommerce MCP plugin
====

An [MCP (Model Context Protocol)](https://modelcontextprotocol.io/) server plugin for nopCommerce 5.00 (`.NET 10`), exposed over Streamable HTTP.

## MCP Tools

Read-only is the default. Write tools throw an error unless the **Allow write tools** option is enabled (see [Configuration](#configuration)).

| Area | Read | Write |
|---|---|---|
| Catalog | `get_products`, `get_product`, `get_categories`, `get_manufacturers`, `get_product_attributes` | `create_product`, `update_product`, `create_product_attribute_combination`, `set_inventory`, `manage_tags` |
| Orders | `get_orders`, `get_order_by_id`, `search_orders` | `mark_order_as_paid`, `cancel_order`, `create_shipment`, `mark_shipment_as_shipped` |
| Customers | `get_customers`, `get_customer_by_id`, `get_customer_addresses` | `create_customer`, `update_customer`, `add_customer_address` |
| Metafields | `get_metafield` | `set_metafield` |
| Logs | `read_logs` | — |

## Build

A local checkout of the nopCommerce 5.00 source tree is required (referenced via `NopCommerceRoot` in `Nop.Plugin.MCP\Nop.Plugin.Misc.Mcp.csproj`), expected at `D:\PROJECTS\nopCommerce` by default:

```bat
dotnet build Nop.Plugin.MCP\Nop.Plugin.Misc.Mcp.slnx -c Release
```

The build deploys into `<checkout>\src\Presentation\Nop.Web\Plugins\Misc.Mcp`. Restart the web app, then enable the plugin from **Admin → Configuration → Local plugins**.

## Configuration

Settings on the plugin's admin page:
- **Enabled** – exposes the MCP endpoint (takes effect after an app restart)
- **Endpoint path** – URL path of the MCP server (default `/mcp`)
- **API key** – static secret that MCP clients may present
- **Allow write tools** – gate for the write tools above; unchecked, the endpoint is strictly read-only
- **Default page size** / **Maximum page size** – pagination limits for tool calls

## Authentication

The endpoint is **not anonymous**. Every request must present a valid **API key** (`X-Api-Key: <API_KEY>` or `Authorization: Bearer <API_KEY>`). Invalid or missing credentials are rejected with **HTTP 401**.

## Connect

```bash
claude mcp add --transport http nopcommerce https://yourstore.com/mcp --header "Authorization: Bearer <YOUR_API_KEY>"
```

The path comes from **Endpoint path** (default `/mcp`), the key from **API key**. Plain `http://` only works for localhost; remote stores must be served over HTTPS.