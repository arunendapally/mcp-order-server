# MCP Order Server

A minimal MCP (Model Context Protocol) server in .NET, exposing a single tool — `get_order_status` — over Streamable HTTP. Built to accompany [Building MCP Servers: A Practical Guide for .NET Developers](https://arunendapally.com).

## What it does

`GetOrderStatus(orderId)` looks up an order in an in-memory dictionary and returns its status and ETA. It demonstrates the core MCP building blocks: tool definition via `[McpServerToolType]` / `[McpServerTool]`, and wiring up the Streamable HTTP transport with `AddMcpServer()` + `MapMcp()`.

## Run it

```bash
cd McpOrderServer
dotnet run
```

The server listens on the URL printed at startup (e.g. `http://localhost:5000`), with the MCP endpoint at `/mcp`.

## Test it with MCP Inspector

```bash
npx @modelcontextprotocol/inspector
```

Point the inspector at `http://localhost:<port>/mcp`, then call `get_order_status` with one of the seeded IDs: `123`, `456`, or `789`.

Or use the CLI mode directly:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:<port>/mcp --method tools/list
npx @modelcontextprotocol/inspector --cli http://localhost:<port>/mcp --method tools/call --tool-name get_order_status --tool-arg orderId=123
```
