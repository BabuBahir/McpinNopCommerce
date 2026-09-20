nopCommerce MCP plugin
====

An [MCP (Model Context Protocol)](https://modelcontextprotocol.io/) server plugin for nopCommerce 5.00 (`.NET 10`), exposed over Streamable HTTP.

## MCP Tools
<details>
  <summary>Click to See Available Tools </summary>
  
Read-only is the default. Write tools throw an error unless the **Allow write tools** option is enabled in Admin Configuration

| Area | Read | Write |
|---|---|---|
| Catalog | `get_products`, `get_product`, `get_categories`, `get_manufacturers`, `get_product_attributes` | `create_product`, `update_product`, `create_product_attribute_combination`, `set_inventory`, `manage_tags` |
| Orders | `get_orders`, `get_order_by_id`, `search_orders` | `mark_order_as_paid`, `cancel_order`, `create_shipment`, `mark_shipment_as_shipped` |
| Customers | `get_customers`, `get_customer_by_id`, `get_customer_addresses` | `create_customer`, `update_customer`, `add_customer_address` |
| Metafields | `get_metafield` | `set_metafield` |
| Logs | `read_logs` | — |


</details>

## Build

<details>
A local checkout of the nopCommerce 5.00 source tree is required (referenced via `NopCommerceRoot` in `Nop.Plugin.MCP\Nop.Plugin.Misc.Mcp.csproj`), expected at `D:\PROJECTS\nopCommerce` by default:

```bat
dotnet build Nop.Plugin.MCP\Nop.Plugin.Misc.Mcp.slnx -c Release
```

The build deploys into `<checkout>\src\Presentation\Nop.Web\Plugins\Misc.Mcp`. Restart the web app, then enable the plugin from **Admin → Configuration → Local plugins**.
</details>
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
<details>
<summary>Click to expand</summary>

If using YOUR_API_KEY instead of Bearer Token then YOUR_API_KEY has to be same as given in Admin portal.
For e.g. suppose my token is FirstGoodToken , Now the bash will become 

```claude mcp add --transport http nopcommerce http://localhost:54720/mcp --header "Authorization: Bearer FirstGoodToken"```
& The admin portal will have to be 
<img width="1743" height="582" alt="image" src="https://github.com/user-attachments/assets/bf4ceff5-3d0b-457c-b0a2-13cd04c1424e" />

As you can when both Admin portal & bash command had FirstGoodToken , it resulted in "√ Connected" 
but when bash command cli had badtoken , it resulted in 401 , We can then remove this mcp with ```claude mcp remove nopcommerce```
 
</details> 

<details>
<summary>Click to check how to use with natural language</summary>
Get the Mcp Tools using natural language 
 <img width="1091" height="875" alt="image" src="https://github.com/user-attachments/assets/d9bb0ddc-f20f-46bc-b54f-7f205f261ce8" />
Give Prompt to add a Vendor and let AI decide what MCP tools to call
<img width="1753" height="660" alt="image" src="https://github.com/user-attachments/assets/c4dc37b3-3ee0-4acd-b7bc-f6a547db7595" />
<img width="1095" height="820" alt="image" src="https://github.com/user-attachments/assets/443247b5-8623-4275-b2ab-de66e5f3c209" />


 
 
</details>
  
The path comes from **Endpoint path** (default `/mcp`), the key from **API key**. Plain `http://` only works for localhost; remote stores must be served over HTTPS.
