namespace CarRental.DTOs
{
    public class CarDisplayDto
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string RegistrationNumber { get; set; }
        public decimal PricePerDay { get; set; }
        public bool IsAvailable { get; set; }

        // Zauważ: nie ma tu kolekcji Rentals!
    }
}