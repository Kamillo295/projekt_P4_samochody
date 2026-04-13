namespace CarRental.DTOs;

public class RentalDto
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalPrice { get; set; }
    public int CarId { get; set; }
    public int CustomerId { get; set; }

    public string CarFullName { get; set; }
    public string CustomerFullName { get; set; }
}