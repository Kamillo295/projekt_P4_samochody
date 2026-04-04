using System;

namespace CarRental.Models
{
    // Model reprezentujący sam proces wypożyczenia
    public class Rental
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalPrice { get; set; }

        // Relacje
        public int CarId { get; set; }
        public Car Car { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public Payment Payment { get; set; }
    }
}