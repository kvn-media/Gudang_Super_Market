// GudangController.cs
using Gudang_Super_Market.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class GudangController : ControllerBase
{
    private readonly AppDbContext _context;

    public GudangController(AppDbContext context)
    {
        _context = context;
    }

    // Implementasi CRUD untuk Gudang
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Gudang>>> GetGudangs()
    {
        return await _context.Gudangs.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Gudang>> GetGudang(int id)
    {
        var gudang = await _context.Gudangs.FindAsync(id);

        if (gudang == null)
        {
            return NotFound();
        }

        return gudang;
    }

    [HttpPost]
    public async Task<ActionResult<Gudang>> CreateGudang(Gudang gudang)
    {
        _context.Gudangs.Add(gudang);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetGudang), new { id = gudang.Id }, gudang);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGudang(int id, Gudang gudang)
    {
        if (id != gudang.Id)
        {
            return BadRequest();
        }

        _context.Entry(gudang).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!GudangExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGudang(int id)
    {
        var gudang = await _context.Gudangs.FindAsync(id);
        if (gudang == null)
        {
            return NotFound();
        }

        _context.Gudangs.Remove(gudang);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool GudangExists(int id)
    {
        return _context.Gudangs.Any(e => e.Id == id);
    }
}
