using System.ComponentModel;
using ModelContextProtocol.Server;

namespace McpOrderServer;

[McpServerToolType]
public static class OrderTools
{
    private static readonly Dictionary<string, (string Status, string Eta)> Orders = new()
    {
        ["123"] = ("shipped", "2026-07-02"),
        ["456"] = ("processing", "2026-07-05"),
        ["789"] = ("delivered", "2026-06-20"),
    };

    [McpServerTool, Description("Look up the current status of an order by ID.")]
    public static object GetOrderStatus([Description("The order ID to look up, e.g. \"123\"")] string orderId)
    {
        if (Orders.TryGetValue(orderId, out var order))
        {
            return new { orderId, status = order.Status, eta = order.Eta };
        }

        return new { orderId, status = "not_found" };
    }
}
