public class Car
{
    public int CarId { get; set; }
    public string Model { get; set; }
    public string Brand { get; set; }
    public int Year { get; set; }
    public decimal PricePerDay { get; set; }
    public bool IsAvailable { get; set; }

    // Navigation property for related Rentals
    public ICollection<Rental> Rentals { get; set; }
}
