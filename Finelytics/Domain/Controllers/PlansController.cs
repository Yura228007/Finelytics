using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using finelytics.Models;
using finelytics.Domain;

namespace finelytics.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlansController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PlansController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/plans
        [HttpGet]
        public async Task<ActionResult<List<Plan>>> GetPlans(CancellationToken cancellationToken = default)
        {
            return await _context.Plans.ToListAsync(cancellationToken);
        }

        // GET: api/plans/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Plan>> GetPlan(int id, CancellationToken cancellationToken = default)
        {
            var plan = await _context.Plans.FindAsync([id], cancellationToken);
            if (plan == null)
                return NotFound();
            return plan;
        }

        // POST: api/plans
        [HttpPost]
        public async Task<ActionResult<Plan>> CreatePlan(Plan plan, CancellationToken cancellationToken = default)
        {
            await _context.Plans.AddAsync(plan, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return CreatedAtAction(nameof(GetPlan), new { id = plan.Id }, plan);
        }

        // PUT: api/plans/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlan(int id, Plan plan, CancellationToken cancellationToken = default)
        {
            if (id != plan.Id)
                return BadRequest();

            _context.Entry(plan).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
            return NoContent();
        }

        // DELETE: api/plans/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlan(int id, CancellationToken cancellationToken = default)
        {
            var plan = await _context.Plans.FindAsync([id], cancellationToken);
            if (plan == null)
                return NotFound();

            _context.Plans.Remove(plan);
            await _context.SaveChangesAsync(cancellationToken);
            return NoContent();
        }
    }
}