using System.Collections.Generic;

namespace CarRental.Models
{
    // Model reprezentujący samochód w wypożyczalni
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string RegistrationNumber { get; set; }
        public decimal PricePerDay { get; set; }
        public bool IsAvailable { get; set; }

        // Relacja: Jeden samochód może mieć wiele historii wynajmu
        public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
    }
}