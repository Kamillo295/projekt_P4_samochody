using FluentValidation;
using CarRental.DTOs;

namespace CarRental.Validators;

public class CustomerValidator : AbstractValidator<CustomerDto>
{
    public CustomerValidator()
    {
        RuleFor(c => c.FirstName).NotEmpty().WithMessage("Imię jest wymagane.");
        RuleFor(c => c.LastName).NotEmpty().WithMessage("Nazwisko jest wymagane.");
        RuleFor(c => c.Email)
            .NotEmpty().WithMessage("Adres e-mail jest wymagany.")
            .EmailAddress().WithMessage("Podaj poprawny format adresu e-mail.");
        RuleFor(c => c.PhoneNumber).NotEmpty().WithMessage("Numer telefonu jest wymagany.");
        RuleFor(c => c.DrivingLicenseNumber).NotEmpty().WithMessage("Numer prawa jazdy jest wymagany.");
    }
}