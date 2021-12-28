namespace HttpConfigurationProviderDemo.OrderApi;

public static class ConfigurationBuilderExtensions
{
    public static IConfigurationBuilder AddTenantConfiguration(
        this IConfigurationBuilder builder,
        string tenantsApiUrl)
    {
        builder.Add(new TenantConfigurationSource(tenantsApiUrl));

        return builder;
    }
}