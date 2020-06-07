using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentDemo.Dtos;
using PaymentDemo.Entities;
using PaymentDemo.Models;
using PaymentDemo.Services.Business.Interfaces;

namespace PaymentDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;
        private readonly IValidator _paymentValidator;

        public PaymentsController(IPaymentService paymentService, 
            IMapper mapper, 
            IValidator paymentValidator)
        {
            _paymentService = paymentService;
            _mapper = mapper;
            _paymentValidator = paymentValidator;   
        }   
            
        [HttpPost]
        [ProducesResponseType( StatusCodes.Status200OK)]
        [ProducesResponseType( StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ProcessPayment(PaymentDto paymentDto)
        {
            var payment = _mapper.Map<Payment>(paymentDto);

            var validationResult = _paymentValidator.Validate(payment);
            if (!validationResult.IsValid)
            {
                var errorMessage = validationResult.Errors.Aggregate("", (current, error) => current + $@"
{error.ErrorMessage}");

                return BadRequest(errorMessage);
            }
            payment.IdState = (int)PaymentStatus.Pending;

            var result = await _paymentService.Process(payment);
            if (result.IsFailed)
                return StatusCode(StatusCodes.Status500InternalServerError,
                    result.Error);

            return Ok();
        }
    }
}       