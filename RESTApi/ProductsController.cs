using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApiProject.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductsController : ControllerBase
	{
		private readonly AdventureWorksDbContext _context;

		public ProductsController(AdventureWorksDbContext context)
		{
			_context = context;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetProduct(int id)
		{
			var product = await _context.Products.FindAsync(id);
			return product != null ? Ok(product) : NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> CreateProduct([FromBody] Product product)
		{
			_context.Products.Add(product);
			await _context.SaveChangesAsync();
			return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
		{
			if (id != product.Id)
			{
				return BadRequest();
			}

			_context.Entry(product).State = EntityState.Modified;
			await _context.SaveChangesAsync();
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProduct(int id)
		{
			var product = await _context.Products.FindAsync(id);
			if (product == null)
			{
				return NotFound();
			}

			_context.Products.Remove(product);
			await _context.SaveChangesAsync();
			return NoContent();
		}
	}
}