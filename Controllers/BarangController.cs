using Gudang_Super_Market.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class BarangController : ControllerBase
{
    private readonly AppDbContext _context;

    public BarangController(AppDbContext context)
    {
        _context = context;
    }

    // Implementasi CRUD untuk Barang
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Barang>>> GetBarangs()
    {
        return await _context.Barangs.Include(b => b.Gudang).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Barang>> GetBarang(int id)
    {
        var barang = await _context.Barangs.FindAsync(id);

        if (barang == null)
        {
            return NotFound();
        }

        return barang;
    }

    [HttpPost]
    public async Task<ActionResult<Barang>> CreateBarang(Barang barang)
    {
        _context.Barangs.Add(barang);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBarang), new { id = barang.Id }, barang);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBarang(int id, Barang barang)
    {
        if (id != barang.Id)
        {
            return BadRequest();
        }

        _context.Entry(barang).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BarangExists(id))
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
    public async Task<IActionResult> DeleteBarang(int id)
    {
        var barang = await _context.Barangs.FindAsync(id);
        if (barang == null)
        {
            return NotFound();
        }

        _context.Barangs.Remove(barang);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpGet("Monitoring")]
    public async Task<ActionResult<IEnumerable<Barang>>> GetMonitoringBarang(string namaGudang, DateTime? expiredDate)
    {
        IQueryable<Barang> monitoringQuery = _context.Barangs.Include(b => b.Gudang);

        if (!string.IsNullOrEmpty(namaGudang))
        {
            monitoringQuery = monitoringQuery.Where(b => b.Gudang.NamaGudang == namaGudang);
        }

        if (expiredDate.HasValue)
        {
            monitoringQuery = monitoringQuery.Where(b => b.ExpiredDate <= expiredDate);
        }

        var monitoringResult = await monitoringQuery.ToListAsync();

        return monitoringResult;
    }

    private bool BarangExists(int id)
    {
        return _context.Barangs.Any(e => e.Id == id);
    }


}
