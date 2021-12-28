using System.Text.Json;
using Refit;

namespace HttpConfigurationProviderDemo.OrderApi;

public class TenantConfigurationProvider : ConfigurationProvider
{
    private readonly ITenantsApi _tenantsApi;

    public TenantConfigurationProvider(string tenantApiUrl)
    {
        this._tenantsApi = RestService.For<ITenantsApi>(tenantApiUrl);
    }

    public override void Load()
    {
        var tenants = this._tenantsApi.Get().GetAwaiter().GetResult();

        foreach (var tenant in tenants)
        {
            Data.Add(tenant.Id, JsonSerializer.Serialize(tenant));
        }
    }
}