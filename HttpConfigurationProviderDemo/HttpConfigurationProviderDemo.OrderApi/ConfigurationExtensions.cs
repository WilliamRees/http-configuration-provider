using System.Text.Json;

namespace HttpConfigurationProviderDemo.OrderApi;

public static class ConfigurationExtensions
{
    public static Tenant? GetTenant(this IConfiguration configuration, string id)
    {
        var data = configuration[id];

        return string.IsNullOrEmpty(data)
            ? null
            : JsonSerializer.Deserialize<Tenant>(data);
    }
}
