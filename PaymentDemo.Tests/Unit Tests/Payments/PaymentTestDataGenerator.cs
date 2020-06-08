using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PaymentDemo.Dtos;

namespace PaymentDemo.Tests.Unit_Tests.Payments
{
    public class PaymentTestDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            {
                "CheapPayment",
                new PaymentDto
                {
                    CreditCardNumber = "4539683495058328",
                    CardHolder = "John Doe",
                    ExpirationDate = new DateTime(2021, 1,01),
                    SecurityCode = null,
                    Amount = 9.78m
                },
                typeof(OkResult)
            },

            new object[]
            {
                "MediumPayment",
                new PaymentDto
                {
                    CreditCardNumber = "5107374522949593",
                    CardHolder = "Jane Doe",
                    ExpirationDate = new DateTime(2020, 12,01),
                    SecurityCode = "765",
                    Amount = 76.36m
                },
                typeof(OkResult)
            },

            new object[]
            {
                "ExpensivePayment",
                new PaymentDto
                {
                    CreditCardNumber = "5107374522949593",
                    CardHolder = "Rich Doe",
                    ExpirationDate = new DateTime(2025, 6,01),
                    SecurityCode = "893",
                    Amount = 666.01m
                },
                typeof(OkResult)
            }
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}