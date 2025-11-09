using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using finelytics.Models;
using finelytics.Domain;

namespace finelytics.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersGroupsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersGroupsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/usersgroups
        [HttpGet]
        public async Task<ActionResult<List<UsersGroup>>> GetUsersGroups(CancellationToken cancellationToken = default)
        {
            return await _context.UsersGroups.ToListAsync(cancellationToken);
        }

        // GET: api/usersgroups/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UsersGroup>> GetUsersGroup(int id, CancellationToken cancellationToken = default)
        {
            var usersGroup = await _context.UsersGroups.FindAsync([id], cancellationToken);
            if (usersGroup == null)
                return NotFound();
            return usersGroup;
        }

        // POST: api/usersgroups
        [HttpPost]
        public async Task<ActionResult<UsersGroup>> CreateUsersGroup(UsersGroup usersGroup, CancellationToken cancellationToken = default)
        {
            await _context.UsersGroups.AddAsync(usersGroup, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return CreatedAtAction(nameof(GetUsersGroup), new { id = usersGroup.Id }, usersGroup);
        }

        // PUT: api/usersgroups/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsersGroup(int id, UsersGroup usersGroup, CancellationToken cancellationToken = default)
        {
            if (id != usersGroup.Id)
                return BadRequest();

            _context.Entry(usersGroup).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
            return NoContent();
        }

        // DELETE: api/usersgroups/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsersGroup(int id, CancellationToken cancellationToken = default)
        {
            var usersGroup = await _context.UsersGroups.FindAsync([id], cancellationToken);
            if (usersGroup == null)
                return NotFound();

            _context.UsersGroups.Remove(usersGroup);
            await _context.SaveChangesAsync(cancellationToken);
            return NoContent();
        }
    }
}