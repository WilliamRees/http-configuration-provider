using Refit;

namespace HttpConfigurationProviderDemo.OrderApi;

public interface ITenantsApi
{
    [Get("/api/tenants")]
    Task<List<Tenant>> Get();
}