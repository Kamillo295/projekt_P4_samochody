using FluentValidation;
using CarRental.Models;

namespace CarRental.Validators
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Make)
                .NotEmpty().WithMessage("Marka jest wymagana")
                .MaximumLength(250);
            RuleFor(c => c.Model)
                .NotEmpty().WithMessage("Model jest wymagana");
            RuleFor(c => c.Year)
                .InclusiveBetween(1900, System.DateTime.Now.Year + 1)
                .WithMessage("Niepoprawny rok produkcji");
            RuleFor(c => c.RegistrationNumber)
                .NotEmpty()
                .MinimumLength(3)
                .WithMessage("Numer jest za krótki");
            RuleFor(c => c.PricePerDay)
                .GreaterThan(0)
                .WithMessage("Cena musi być większa od 0.");
        }
    }
}
