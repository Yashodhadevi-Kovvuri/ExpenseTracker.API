using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.API.Data;
using ExpenseTracker.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ExpensesController : ControllerBase
	{
		private readonly AppDbContext _context;

		public ExpensesController(AppDbContext context)
		{
			_context = context;
		}

		// POST: api/expenses
		[HttpPost]
		public IActionResult CreateExpense(Expense expense)
		{
			_context.Expenses.Add(expense);
			_context.SaveChanges();
			return Ok(expense);
		}

		// GET: api/expenses
		[HttpGet]
		public IActionResult GetAllExpenses()
		{
			var expenses = _context.Expenses.ToList();
			return Ok(expenses);
		}

		// PUT: api/expenses/5
		[HttpPut("{id}")]
		public IActionResult UpdateExpense(int id, Expense updatedExpense)
		{
			var expense = _context.Expenses.Find(id);

			if (expense == null)
				return NotFound("Expense not found");

			expense.Title = updatedExpense.Title;
			expense.Description = updatedExpense.Description;
			expense.Amount = updatedExpense.Amount;

			_context.SaveChanges();
			return Ok(expense);
		}

		// DELETE: api/expenses/5
		[HttpDelete("{id}")]
		public IActionResult DeleteExpense(int id)
		{
			var expense = _context.Expenses.Find(id);

			if (expense == null)
				return NotFound("Expense not found");

			_context.Expenses.Remove(expense);
			_context.SaveChanges();

			return Ok("Expense deleted successfully");
		}
	}
}