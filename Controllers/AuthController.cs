using Gudang_Super_Market.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public AuthController(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    [HttpPost("register")]
    public async Task<ActionResult<User>> Register(User user)
    {
        try
        {
            // Hash password menggunakan BCrypt
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);

            // Ganti password asli dengan yang sudah di-hash sebelum disimpan ke database
            user.Password = hashedPassword;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }
        catch (Exception ex)
        {
            // Handle error
            return BadRequest(new { Message = "Gagal mendaftarkan pengguna.", Error = ex.Message });
        }
    }

    [HttpPost("login")]
    public async Task<ActionResult<User>> Login(User user)
    {
        try
        {
            // Mengambil pengguna dari database berdasarkan username
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == user.Username);

            if (existingUser == null || !BCrypt.Net.BCrypt.Verify(user.Password, existingUser.Password))
            {
                // Username tidak ditemukan atau password tidak sesuai
                return BadRequest(new { Message = "Login gagal. Periksa kembali username dan password Anda." });
            }

            // Generate token JWT
            var token = GenerateJwtToken(existingUser);

            return Ok(new { Token = token });
        }
        catch (Exception ex)
        {
            // Handle error
            return BadRequest(new { Message = "Gagal melakukan login.", Error = ex.Message });
        }
    }

    private string GenerateJwtToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
            
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
