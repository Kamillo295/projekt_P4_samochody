using System;
using FluentValidation;
using CarRental.Models;

namespace CarRental.Validators
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            // Upewniamy się, że wynajem jest powiązany z istniejącym samochodem i klientem (Id musi być większe od 0)
            RuleFor(r => r.CarId).GreaterThan(0).WithMessage("Należy przypisać samochód do wynajmu.");
            RuleFor(r => r.CustomerId).GreaterThan(0).WithMessage("Należy przypisać klienta do wynajmu.");

            // Data rozpoczęcia wynajmu nie powinna być z przeszłości (bierzemy pod uwagę dzisiejszy dzień)
            RuleFor(r => r.StartDate)
                .GreaterThanOrEqualTo(DateTime.Today).WithMessage("Data rozpoczęcia nie może być wcześniejsza niż dzisiaj.");

            // Najważniejsze: Data zakończenia MUSI być później niż data rozpoczęcia
            RuleFor(r => r.EndDate)
                .GreaterThan(r => r.StartDate).WithMessage("Data zakończenia musi być późniejsza niż data rozpoczęcia wynajmu.");

            // Cena całkowita nie może być wartością ujemną
            RuleFor(r => r.TotalPrice).GreaterThanOrEqualTo(0).WithMessage("Całkowita cena nie może być mniejsza od zera.");
        }
    }
}