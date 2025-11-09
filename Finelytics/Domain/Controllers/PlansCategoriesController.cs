using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using finelytics.Models;
using finelytics.Domain;

namespace finelytics.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlansCategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PlansCategoriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/planscategories
        [HttpGet]
        public async Task<ActionResult<List<PlanCategory>>> GetPlanCategories(CancellationToken cancellationToken = default)
        {
            return await _context.PlansCategories.ToListAsync(cancellationToken);
        }

        // GET: api/planscategories/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PlanCategory>> GetPlanCategory(int id, CancellationToken cancellationToken = default)
        {
            var planCategory = await _context.PlansCategories.FindAsync([id], cancellationToken);
            if (planCategory == null)
                return NotFound();
            return planCategory;
        }

        // POST: api/planscategories
        [HttpPost]
        public async Task<ActionResult<PlanCategory>> CreatePlanCategory(PlanCategory planCategory, CancellationToken cancellationToken = default)
        {
            await _context.PlansCategories.AddAsync(planCategory, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return CreatedAtAction(nameof(GetPlanCategory), new { id = planCategory.Id }, planCategory);
        }

        // PUT: api/planscategories/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlanCategory(int id, PlanCategory planCategory, CancellationToken cancellationToken = default)
        {
            if (id != planCategory.Id)
                return BadRequest();

            _context.Entry(planCategory).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
            return NoContent();
        }

        // DELETE: api/planscategories/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanCategory(int id, CancellationToken cancellationToken = default)
        {
            var planCategory = await _context.PlansCategories.FindAsync([id], cancellationToken);
            if (planCategory == null)
                return NotFound();

            _context.PlansCategories.Remove(planCategory);
            await _context.SaveChangesAsync(cancellationToken);
            return NoContent();
        }
    }
}