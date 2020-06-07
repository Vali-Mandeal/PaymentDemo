using System.Linq;
using FluentAssertions;
using Newtonsoft.Json;
using PaymentDemo.Entities;
using PaymentDemo.Services.Validators;
using Xunit;
using Xunit.Abstractions;

namespace PaymentDemo.Tests.Unit_Tests.PaymentValidation
{
    public class PaymentValidationTests
    {
        private readonly ITestOutputHelper _output;
        private readonly PaymentValidator _paymentValidator;

        public PaymentValidationTests(ITestOutputHelper output)
        {
            _output = output;
            _paymentValidator = new PaymentValidator();
        }
            
        [Theory]
        [ClassData(typeof(PaymentValidationDataGenerator))]
        public void PaymentValidation(string label, Payment payment, bool expected)
        {
            var validationResult = _paymentValidator.Validate(payment);

            validationResult.IsValid.Should().Be(expected);
            _output.WriteLine($@"
{label}
{JsonConvert.SerializeObject(payment, Formatting.Indented)}

Errors: ");
            foreach (var error in validationResult.Errors) _output.WriteLine($" {error.ErrorMessage}");
            if(!validationResult.Errors.Any()) _output.WriteLine("  None");
        }   
    }
}   
