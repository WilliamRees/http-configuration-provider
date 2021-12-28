namespace HttpConfigurationProviderDemo.OrderApi;

public class TenantConfigurationSource : IConfigurationSource
{
    private readonly string _tenantApiUrl;

    public TenantConfigurationSource(string tenantApiUrl)
    {
        _tenantApiUrl = tenantApiUrl;
    }

    public IConfigurationProvider Build(IConfigurationBuilder builder) =>
        new TenantConfigurationProvider(this._tenantApiUrl);
}