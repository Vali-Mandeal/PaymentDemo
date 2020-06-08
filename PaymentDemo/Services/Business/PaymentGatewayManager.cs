using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PaymentDemo.Entities;
using PaymentDemo.Models;

namespace PaymentDemo.Services.Business
{
    public class PaymentGatewayManager
    {
        public async Task<Result<Payment>> Process(Payment payment, string endpoint, string providerName)
        {
            var requestUrl = Environment.GetEnvironmentVariable(endpoint);

            using var httpClient = new HttpClient();
            try
            {
                var requestBody = JsonConvert.SerializeObject(payment);
                var response = await httpClient.PostAsync($"{requestUrl}/paymentgateway",
                    new StringContent(requestBody, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    payment.IdState = (int)PaymentStatus.Processed;
                    return Result<Payment>.Ok(payment);
                }

                payment.IdState = (int)PaymentStatus.Failed;

                return Result<Payment>
                    .Fail($"Processing Payment using {providerName} failed with error: {await response.Content.ReadAsStringAsync()}",
                        payment);
            }
            catch (Exception e)
            {
                payment.IdState = (int)PaymentStatus.Failed;

                return Result<Payment>
                    .Fail($@"Processing Payment failed, service might be down ({providerName})
Message: {e.Message}", payment);
            }
        }
    }
}
