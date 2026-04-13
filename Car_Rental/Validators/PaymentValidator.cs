using System;
using FluentValidation;
using CarRental.Models;

namespace CarRental.Validators
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(p => p.RentalId).GreaterThan(0).WithMessage("Płatność musi być powiązana z konkretnym wynajmem.");

            RuleFor(p => p.Amount).GreaterThan(0).WithMessage("Kwota płatności musi być większa niż 0.");

            RuleFor(p => p.Status).NotEmpty().WithMessage("Status płatności jest wymagany.");

            RuleFor(p => p.PaymentDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Data płatności nie może być z przyszłości.");
        }
    }
}