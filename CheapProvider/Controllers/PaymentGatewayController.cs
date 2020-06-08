using CheapProvider.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CheapProvider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentGatewayController : ControllerBase
    {
        [HttpPost]
        public IActionResult ProcessPayment([FromBody]PaymentDto paymentDto)
        {
            // do stuff with payment
            return Ok();
        }
    }
}