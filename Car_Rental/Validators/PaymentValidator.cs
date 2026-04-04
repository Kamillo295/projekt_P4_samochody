using System;
using FluentValidation;
using CarRental.Models;

namespace CarRental.Validators
{
    // Klasa sprawdzająca poprawność danych płatności
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            // Płatność musi być przypisana do konkretnego wynajmu
            RuleFor(p => p.RentalId).GreaterThan(0).WithMessage("Płatność musi być powiązana z konkretnym wynajmem.");

            // Kwota musi być większa od zera
            RuleFor(p => p.Amount).GreaterThan(0).WithMessage("Kwota płatności musi być większa niż 0.");

            // Status (np. "Opłacono", "Oczekuje") nie może być pusty
            RuleFor(p => p.Status).NotEmpty().WithMessage("Status płatności jest wymagany.");

            // Data płatności nie może być ustawiona w przyszłości (może być najwyżej teraz)
            RuleFor(p => p.PaymentDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Data płatności nie może być z przyszłości.");
        }
    }
}