using FluentValidation;
using CarRental.DTOs;

namespace CarRental.Validators;

public class RentalValidator : AbstractValidator<RentalDto>
{
    public RentalValidator()
    {
        RuleFor(r => r.CarId).GreaterThan(0).WithMessage("Należy przypisać samochód do wynajmu.");
        RuleFor(r => r.CustomerId).GreaterThan(0).WithMessage("Należy przypisać klienta do wynajmu.");
        RuleFor(r => r.StartDate)
            .GreaterThanOrEqualTo(DateTime.Today).WithMessage("Data rozpoczęcia nie może być wcześniejsza niż dzisiaj.");
        RuleFor(r => r.EndDate)
            .GreaterThan(r => r.StartDate).WithMessage("Data zakończenia musi być późniejsza niż data rozpoczęcia wynajmu.");
        RuleFor(r => r.TotalPrice).GreaterThanOrEqualTo(0).WithMessage("Całkowita cena nie może być mniejsza od zera.");
    }
}