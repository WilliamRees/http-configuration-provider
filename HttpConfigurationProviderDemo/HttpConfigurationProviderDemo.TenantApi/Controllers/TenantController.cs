using Microsoft.AspNetCore.Mvc;
using static HttpConfigurationProviderDemo.TenantApi.Controllers.TenantController.Tenant;

namespace HttpConfigurationProviderDemo.TenantApi.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class TenantController : ControllerBase
{
    private static readonly List<Tenant> Tenants = new List<Tenant>
    {
        Tenant.Create("3dd68063-3e9b-4c4d-8f8f-866467cf0cd0", new List<ShippingMethod> { ShippingMethod.UPS, ShippingMethod.CANADAPOST }),
        Tenant.Create("4fb8d237-bea7-4427-bd75-aab97f33b9ec", new List<ShippingMethod> { ShippingMethod.FEDEX, ShippingMethod.USPS, ShippingMethod.PUROLATOR }),
    };

    [HttpGet]
    public IEnumerable<Tenant> Get()
    {
        return Tenants;
    }

    public class Tenant
    {
        public string Id { get; set; } = string.Empty;

        public List<ShippingMethod> AllowedShippingMethods { get; set; } = new List<ShippingMethod>();

        public static Tenant Create(string id, List<ShippingMethod> shippingMethods)
        {
            return new Tenant
            {
                Id = id,
                AllowedShippingMethods = shippingMethods
            };
        }

        public enum ShippingMethod
        {
            UPS,
            FEDEX,
            USPS,
            CANADAPOST,            
            PUROLATOR
        }
    }
}