using System.Collections.Generic;

namespace CarRental.Models
{
    // Model reprezentujący klienta
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string DrivingLicenseNumber { get; set; }

        // Relacja: Jeden klient może mieć wiele wypożyczeń
        public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
    }
}