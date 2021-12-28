using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace HttpConfigurationProviderDemo.OrderApi.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class OrderController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public OrderController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost]
    [ProducesResponseType(typeof(Order), (int)HttpStatusCode.Created)]
    public IActionResult Create(Order order)
    {
        var tenantId = HttpContext.Request.Headers["tenant-id"].FirstOrDefault();

        if (string.IsNullOrEmpty(tenantId)) return Unauthorized();

        var tenant = this._configuration.GetTenant(tenantId);

        if (tenant == null) return BadRequest();

        if (!tenant.IsValidShippingMethod(order.ShippingMethod)) return BadRequest("Invalid shipping method");

        // save order...

        order.Id = Guid.NewGuid().ToString().ToLower();

        return Created("", order);
    }

    public class Order
    {
        public string Id { get; set; } = string.Empty;

        public ShippingMethod ShippingMethod { get; set; }

        public string Product { get; set; } = string.Empty;

        public short Quantity { get; set; }

        public decimal Price { get; set; }
    }
}