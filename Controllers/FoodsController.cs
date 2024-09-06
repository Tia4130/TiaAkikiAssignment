using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API1.Data;
using API1.Models;

[Route("api/[controller]")]
[ApiController]
public class FoodsController : ControllerBase
{
    private readonly AppDbContext _context;

    // Constructor to inject the DbContext (AppDbContext)
    public FoodsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/foods
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Food>>> GetFoods()
    {
        return await _context.Foods.ToListAsync();
    }

    // POST: api/foods
    [HttpPost]
    public async Task<ActionResult<Food>> PostFood(Food food)
    {
        _context.Foods.Add(food);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetFoods), new { id = food.Id }, food);
    }

    // PUT: api/foods/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutFood(int id, Food food)
    {
        if (id != food.Id)
        {
            return BadRequest();
        }

        _context.Entry(food).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/foods/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFood(int id)
    {
        var food = await _context.Foods.FindAsync(id);

        if (food == null)
        {
            return NotFound();
        }

        _context.Foods.Remove(food);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
