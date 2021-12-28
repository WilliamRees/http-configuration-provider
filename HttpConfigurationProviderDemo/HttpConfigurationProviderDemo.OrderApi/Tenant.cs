namespace HttpConfigurationProviderDemo.OrderApi;

public class Tenant
{
    public string Id { get; set; } = string.Empty;

    public List<ShippingMethod> AllowedShippingMethods { get; set; } = new List<ShippingMethod>();    

    public bool IsValidShippingMethod(ShippingMethod shippingMethod)
    {
        return this.AllowedShippingMethods.Contains(shippingMethod);
    }
}