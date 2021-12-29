using System.Text.Json.Serialization;

namespace HttpConfigurationProviderDemo.OrderApi;

public class Tenant
{
    [JsonPropertyNameAttribute("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyNameAttribute("allowedShippingMethods")]
    public List<ShippingMethod> AllowedShippingMethods { get; set; } = new List<ShippingMethod>();    

    public bool IsValidShippingMethod(ShippingMethod shippingMethod)
    {
        return this.AllowedShippingMethods.Contains(shippingMethod);
    }
}