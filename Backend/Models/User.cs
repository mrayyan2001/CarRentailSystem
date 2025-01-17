public class User
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public DateTime CreatedAt { get; set; }

    // Navigation property for related Rentals
    public ICollection<Rental> Rentals { get; set; }
}
