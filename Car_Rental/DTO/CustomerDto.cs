namespace CarRental.DTOs;

public class CustomerDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string DrivingLicenseNumber { get; set; }

    public string FullName {  get; set; }
}