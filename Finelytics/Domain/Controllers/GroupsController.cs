using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using finelytics.Models;
using finelytics.Domain;

namespace finelytics.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GroupsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/groups
        [HttpGet]
        public async Task<ActionResult<List<Group>>> GetGroups(CancellationToken cancellationToken = default)
        {
            return await _context.Groups.ToListAsync(cancellationToken);
        }

        // GET: api/groups/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> GetGroup(int id, CancellationToken cancellationToken = default)
        {
            var group = await _context.Groups.FindAsync([id], cancellationToken);
            if (group == null)
                return NotFound();
            return group;
        }

        // POST: api/groups
        [HttpPost]
        public async Task<ActionResult<Group>> CreateGroup(Group group, CancellationToken cancellationToken = default)
        {
            await _context.Groups.AddAsync(group, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return CreatedAtAction(nameof(GetGroup), new { id = group.Id }, group);
        }

        // PUT: api/groups/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGroup(int id, Group group, CancellationToken cancellationToken = default)
        {
            if (id != group.Id)
                return BadRequest();

            _context.Entry(group).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
            return NoContent();
        }

        // DELETE: api/groups/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id, CancellationToken cancellationToken = default)
        {
            var group = await _context.Groups.FindAsync([id], cancellationToken);
            if (group == null)
                return NotFound();

            _context.Groups.Remove(group);
            await _context.SaveChangesAsync(cancellationToken);
            return NoContent();
        }
    }
}