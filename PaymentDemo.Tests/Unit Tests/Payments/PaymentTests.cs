using System;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PaymentDemo.Dtos;
using Xunit;
using Xunit.Abstractions;

namespace PaymentDemo.Tests.Unit_Tests.Payments
{
    public class PaymentTests : IClassFixture<PaymentFixture>
    {
        private readonly ITestOutputHelper _output;
        private readonly PaymentFixture _fixture;

        public PaymentTests(ITestOutputHelper output, PaymentFixture fixture)
        {
            _output = output;
            _fixture = fixture;
        }

        [ClassData(typeof(PaymentTestDataGenerator))]
        [Theory]
        public async void ProcessPayment_Returns200OK(string label, PaymentDto paymentDto, Type expected)
        {
            var result = await _fixture.Controller.ProcessPayment(paymentDto);

            result.Should().BeOfType(expected);
            _output.WriteLine(label);
            _output.WriteLine(JsonConvert.SerializeObject(paymentDto, Formatting.Indented));
        }

        [Fact]
        public async void PaymentsController_InvalidPayment_Returns400Bad_ProcessPayment()
        {
            var paymentDto = new PaymentDto
            {
                CreditCardNumber = "5107374622949593",
                CardHolder = "Failed Doe",
                ExpirationDate = new DateTime(2015, 6, 01),
                SecurityCode = "8973",
                Amount = -666.01m
            };
            var result = await _fixture.Controller.ProcessPayment(paymentDto);

            result.Should().BeOfType(typeof(BadRequestObjectResult));
            _output.WriteLine(JsonConvert.SerializeObject(paymentDto, Formatting.Indented));
        }
    }
}
