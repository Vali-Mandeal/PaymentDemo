using FluentAssertions;
using Newtonsoft.Json;
using PaymentDemo.Entities;
using PaymentDemo.Models;
using Xunit;
using Xunit.Abstractions;

namespace PaymentDemo.Tests.Unit_Tests.PaymentService
{
    public class PaymentServiceTests : IClassFixture<PaymentServiceFixture>
    {
        private readonly ITestOutputHelper _output;
        private readonly PaymentServiceFixture _fixture;

        public PaymentServiceTests(ITestOutputHelper output, PaymentServiceFixture fixture)
        {
            _output = output;
            _fixture = fixture;
        }

        [Theory]
        [ClassData(typeof(PaymentServiceTestDataGenerator))]
        public async void PaymentService_BusinessFlow(string label, Payment payment, int maxCheapProviderTries, int maxExpensiveProviderTries)
        {
            var result = await _fixture.PaymentService.Process(payment);

            result.Value.CheapProviderTries.Should().BeLessOrEqualTo(maxCheapProviderTries);
            result.Value.ExpensiveProviderTries.Should().BeLessOrEqualTo(maxExpensiveProviderTries);

            _output.WriteLine($@"
{label}

{JsonConvert.SerializeObject(payment)}

Cheap Provider tries : {result.Value.CheapProviderTries} (max {maxCheapProviderTries})
Expensive Provider tries: {result.Value.ExpensiveProviderTries} (max {maxExpensiveProviderTries})");
        }
    }
}
