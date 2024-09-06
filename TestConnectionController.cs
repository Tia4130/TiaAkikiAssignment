using Microsoft.AspNetCore.Mvc;
using API1.Data; // Use your namespace
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class TestConnectionController : ControllerBase
{
    private readonly AppDbContext _context;

    public TestConnectionController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {

        var products = _context.Foods.ToList();
        return Ok(products);
    }
}
