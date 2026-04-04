using System;

namespace CarRental.Models
{
    // Model reprezentujący płatność za wynajem
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Status { get; set; } // np. "Opłacono", "Oczekująca"

        // Relacje: Każda płatność jest przypisana do konkretnego wynajmu
        public int RentalId { get; set; }
        public Rental Rental { get; set; }
    }
}