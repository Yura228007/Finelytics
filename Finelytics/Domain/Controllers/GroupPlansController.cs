using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using finelytics.Models;
using finelytics.Domain;

namespace finelytics.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupPlansController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GroupPlansController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/groupplans
        [HttpGet]
        public async Task<ActionResult<List<GroupPlans>>> GetGroupsPlans(CancellationToken cancellationToken = default)
        {
            return await _context.GroupPlans.ToListAsync(cancellationToken);
        }

        // GET: api/groupplans/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupPlans>> GetGroupsPlan(int id, CancellationToken cancellationToken = default)
        {
            var groupsPlan = await _context.GroupPlans.FindAsync([id], cancellationToken);
            if (groupsPlan == null)
                return NotFound();
            return groupsPlan;
        }

        // POST: api/groupplans
        [HttpPost]
        public async Task<ActionResult<GroupPlans>> CreateGroupsPlan(GroupPlans groupPlans, CancellationToken cancellationToken = default)
        {
            await _context.GroupPlans.AddAsync(groupPlans, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return CreatedAtAction(nameof(GetGroupsPlan), new { id = groupPlans.Id }, groupPlans);
        }

        // PUT: api/groupplans/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGroupsPlan(int id, GroupPlans groupsPlan, CancellationToken cancellationToken = default)
        {
            if (id != groupsPlan.Id)
                return BadRequest();

            _context.Entry(groupsPlan).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
            return NoContent();
        }

        // DELETE: api/groupplans/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupsPlan(int id, CancellationToken cancellationToken = default)
        {
            var groupsplan = await _context.GroupPlans.FindAsync([id], cancellationToken);
            if (groupsplan == null)
                return NotFound();

            _context.GroupPlans.Remove(groupsplan);
            await _context.SaveChangesAsync(cancellationToken);
            return NoContent();
        }
    }
}