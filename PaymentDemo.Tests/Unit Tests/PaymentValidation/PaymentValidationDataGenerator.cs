using System;
using System.Collections;
using System.Collections.Generic;
using PaymentDemo.Entities;

namespace PaymentDemo.Tests.Unit_Tests.PaymentValidation
{
    public class PaymentValidationDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            {
                "Valid Payment",
                new Payment
                {
                    CreditCardNumber = "4539683495058328",
                    CardHolder = "John Doe",
                    ExpirationDate = new DateTime(2021, 1,01),
                    SecurityCode = null,
                    Amount = 9.78m
                },
                true
            },
            new object[]
            {
                "Invalid Payment(Bad expiration date)",
                new Payment
                {
                    CreditCardNumber = "4539683495058328",
                    CardHolder = "John Doe",
                    ExpirationDate = new DateTime(2010, 1,01),
                    SecurityCode = null,
                    Amount = 9.78m
                },
                false
            },
            new object[]
            {
                "Invalid Payment(Bad Credit Card Number)",
                new Payment
                {
                    CreditCardNumber = "54539683495058328",
                    CardHolder = "John Doe",
                    ExpirationDate = new DateTime(2021, 1,01),
                    SecurityCode = null,
                    Amount = 9.78m
                },
                false
            },
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}