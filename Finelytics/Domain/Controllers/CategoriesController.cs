using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using finelytics.Models;
using finelytics.Domain;

namespace finelytics.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/categories
        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetCategories(CancellationToken cancellationToken = default)
        {
            return await _context.Categories.ToListAsync(cancellationToken);
        }

        // GET: api/categories/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id, CancellationToken cancellationToken = default)
        {
            var category = await _context.Categories.FindAsync([id], cancellationToken);
            if (category == null)
                return NotFound();
            return category;
        }

        // POST: api/categories
        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(Category category, CancellationToken cancellationToken = default)
        {
            await _context.Categories.AddAsync(category, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        // PUT: api/categories/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, Category category, CancellationToken cancellationToken = default)
        {
            if (id != category.Id)
                return BadRequest();

            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
            return NoContent();
        }

        // DELETE: api/categories/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id, CancellationToken cancellationToken = default)
        {
            var category = await _context.Categories.FindAsync([id], cancellationToken);
            if (category == null)
                return NotFound();

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync(cancellationToken);
            return NoContent();
        }
    }
}