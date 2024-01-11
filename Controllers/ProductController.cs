using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;
using Gudang_Super_Market.Models;
using Microsoft.EntityFrameworkCore;

namespace Gudang_Super_Market.Controllers;
public class ProductController : Controller
{
    private readonly IMemoryCache _memoryCache;
    private readonly AppDbContext _dbContext;

    public ProductController(IMemoryCache memoryCache, AppDbContext dbContext)
    {
        _memoryCache = memoryCache;
        _dbContext = dbContext;
    }

    public async Task<IActionResult> Index()
    {
        // Cek apakah data sudah ada di cache
        if (!_memoryCache.TryGetValue("ProductList", out List<Product> productList))
        {
            // Jika tidak ada di cache, ambil dari database atau sumber lainnya
            productList = await RetrieveProductListAsync();

            // Simpan data ke cache dengan waktu expired (contoh: 10 menit)
            _memoryCache.Set("ProductList", productList, TimeSpan.FromMinutes(10));
        }


        return View(productList);
    }

    private async Task<List<Product>> RetrieveProductListAsync()
    {
        // Logika untuk mengambil data dari database atau sumber lainnya
        // Contoh: menggunakan Entity Framework untuk query database
        var result = await _dbContext.Products.ToListAsync(); // Gantilah dengan metode query sesuai dengan proyek Anda

        return result;
    }
}