using System.Text.Json;
using System.Text.Json.Serialization;

namespace HttpConfigurationProviderDemo.OrderApi;

public class TenantConfigurationProvider : ConfigurationProvider
{
    private readonly HttpClient _httpClient;

    private readonly string _tenantApiUrl;

    public TenantConfigurationProvider(string tenantApiUrl)
    {        
        this._httpClient = new HttpClient();
        this._tenantApiUrl = tenantApiUrl;
    }

    public override void Load()
    {
        var response = this._httpClient.GetAsync($"{this._tenantApiUrl}/api/tenants").GetAwaiter().GetResult();

        if (!response.IsSuccessStatusCode)
        {

        }

        var responseContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

        var options = new JsonSerializerOptions();

        options.Converters.Add(new JsonStringEnumConverter());

        var tenants = JsonSerializer.Deserialize<List<Tenant>>(responseContent, options);

        if (tenants == null)
        {

        }       

        foreach (var tenant in tenants)
        {
            Data.Add(tenant.Id, JsonSerializer.Serialize(tenant));
        }
    }
}