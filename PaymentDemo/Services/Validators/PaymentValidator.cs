using FluentValidation;
using PaymentDemo.Entities;
using DateTime = System.DateTime;

namespace PaymentDemo.Services.Validators
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(payment => payment.CreditCardNumber)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                    .WithMessage("{PropertyName} is required.")
                .Must(BeAValidCreditCardNumber)
                    .WithMessage("{PropertyName} not valid.");

            RuleFor(payment => payment.CardHolder)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.");

            RuleFor(payment => payment.ExpirationDate)
                .Must(BeAValidExpirationDate)
                .WithMessage("{PropertyName} not valid. Card is expired.");

            RuleFor(payment => payment.SecurityCode)
                .Length(3)
                .WithMessage("{PropertyName} must have 3 characters.");

            RuleFor(payment => payment.Amount)
                .GreaterThan(0)
                .WithMessage("{PropertyName} must be positive.");
        }

        private static bool BeAValidCreditCardNumber(string creditCardNumber)
        {
            var result = 0;

            for (var i = creditCardNumber.Length - 1; i >= 0; i -= 2)
                result += (creditCardNumber[i] - '0');

            for (var i = creditCardNumber.Length - 2; i >= 0; i -= 2)
            {
                var val = ((creditCardNumber[i] - '0') * 2);
                while (val > 0)
                {
                    result += (val % 10);
                    val /= 10;
                }
            }

            return result % 10 == 0;
        }

        private static bool BeAValidExpirationDate(DateTime date) => date >= DateTime.Now;
    }
}
