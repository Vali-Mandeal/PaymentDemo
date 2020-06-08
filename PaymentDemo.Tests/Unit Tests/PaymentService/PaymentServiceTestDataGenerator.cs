using System;
using System.Collections;
using System.Collections.Generic;
using PaymentDemo.Entities;

namespace PaymentDemo.Tests.Unit_Tests.PaymentService
{
    public class PaymentServiceTestDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            {
                "Cheap Payment",
                new Payment
                {
                    CreditCardNumber = "4539683495058328",
                    CardHolder = "John Doe",
                    ExpirationDate = new DateTime(2021, 1, 01),
                    SecurityCode = null,
                    Amount = 9.78m
                },
                1,
                0,
                0
            },
            new object[]
            {
                "Expensive Payment",
                new Payment
                {
                    CreditCardNumber = "4539683495058328",
                    CardHolder = "John Doe",
                    ExpirationDate = new DateTime(2030, 1, 01),
                    SecurityCode = null,
                    Amount = 29.78m
                },
                1,
                1,
                0
            },
            new object[]
            {
                "Premium Payment",
                new Payment
                {
                    CreditCardNumber = "4539683495058328",
                    CardHolder = "John Doe",
                    ExpirationDate = new DateTime(2051, 1, 01),
                    SecurityCode = null,
                    Amount = 559.78m
                },
                0,
                0,
                3
            }
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}