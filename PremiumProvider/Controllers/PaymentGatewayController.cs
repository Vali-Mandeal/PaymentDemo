using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PremiumProvider.Dtos;

namespace PremiumProvider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentGatewayController : ControllerBase
    {
        [HttpPost]
        public IActionResult ProcessPayment([FromBody]PaymentDto paymentDto)
        {
            // process payment
            // assume processing fails sometimes
            var random = new Random().Next();

            if(random % 2 ==0) return Ok();
            return StatusCode(StatusCodes.Status500InternalServerError, "Payment failed.");
        }
    }
}