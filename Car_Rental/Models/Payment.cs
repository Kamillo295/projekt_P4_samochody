using System;

namespace CarRental.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Status { get; set; } 

        public int RentalId { get; set; }
        public Rental Rental { get; set; }
    }
}