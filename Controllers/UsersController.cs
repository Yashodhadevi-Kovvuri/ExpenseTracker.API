using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.API.Data;
using ExpenseTracker.API.Models;
using System.Security.Cryptography;
using System.Text;

namespace ExpenseTracker.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly AppDbContext _context;

		public UsersController(AppDbContext context)
		{
			_context = context;
		}

		// POST: api/users/register
		[HttpPost("register")]
		public IActionResult Register(User user)
		{
			// Hash password
			user.PasswordHash = HashPassword(user.PasswordHash);

			_context.Users.Add(user);
			_context.SaveChanges();

			return Ok(new { message = "User registered successfully" });
		}

		// POST: api/users/login
		[HttpPost("login")]
		public IActionResult Login(User loginUser)
		{
			var user = _context.Users
				.FirstOrDefault(u => u.Email == loginUser.Email);

			if (user == null)
				return Unauthorized("Invalid email or password");

			var hashedPassword = HashPassword(loginUser.PasswordHash);

			if (user.PasswordHash != hashedPassword)
				return Unauthorized("Invalid email or password");

			return Ok(new { message = "Login successful" });
		}

		private string HashPassword(string password)
		{
			using var sha256 = SHA256.Create();
			var bytes = Encoding.UTF8.GetBytes(password);
			var hash = sha256.ComputeHash(bytes);
			return Convert.ToBase64String(hash);
		}
	}
}