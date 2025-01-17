using Microsoft.AspNetCore.Mvc;
using CarRentalAPI.Data;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class RentalsController : ControllerBase
{
    private readonly CarRentalContext _context;

    public RentalsController(CarRentalContext context)
    {
        _context = context;
    }

    // GET: api/Rentals
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Rental>>> GetRentals()
    {
        return await _context.Rentals.Include(r => r.User).Include(r => r.Car).ToListAsync();
    }

    // GET: api/Rentals/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Rental>> GetRental(int id)
    {
        var rental = await _context.Rentals.Include(r => r.User).Include(r => r.Car)
                                           .FirstOrDefaultAsync(r => r.RentalId == id);

        if (rental == null)
        {
            return NotFound();
        }

        return rental;
    }

    // POST: api/Rentals
    [HttpPost]
    public async Task<ActionResult<Rental>> PostRental(Rental rental)
    {
        var car = await _context.Cars.FindAsync(rental.CarId);
        if (car == null || !car.IsAvailable)
        {
            return BadRequest("Car not available");
        }

        car.IsAvailable = false;  // Mark the car as unavailable
        rental.TotalCost = (rental.EndDate - rental.StartDate).Days * car.PricePerDay;
        _context.Rentals.Add(rental);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetRental", new { id = rental.RentalId }, rental);
    }

    // PUT: api/Rentals/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRental(int id, Rental rental)
    {
        if (id != rental.RentalId)
        {
            return BadRequest();
        }

        _context.Entry(rental).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/Rentals/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRental(int id)
    {
        var rental = await _context.Rentals.FindAsync(id);
        if (rental == null)
        {
            return NotFound();
        }

        var car = await _context.Cars.FindAsync(rental.CarId);
        if (car != null)
        {
            car.IsAvailable = true;  // Mark the car as available
        }

        _context.Rentals.Remove(rental);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
