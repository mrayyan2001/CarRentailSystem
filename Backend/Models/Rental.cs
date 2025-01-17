public class Rental
{
    public int RentalId { get; set; }
    public int UserId { get; set; }
    public int CarId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalCost { get; set; }
    public DateTime CreatedAt { get; set; }

    // Navigation properties
    public User User { get; set; }
    public Car Car { get; set; }
}
