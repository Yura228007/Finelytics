using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using finelytics.Models;
using finelytics.Domain;

namespace finelytics.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersPlansController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersPlansController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/usersplans
        [HttpGet]
        public async Task<ActionResult<List<UserPlan>>> GetUsersPlans(CancellationToken cancellationToken = default)
        {
            return await _context.UserPlans.ToListAsync(cancellationToken);
        }

        // GET: api/usersplans/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UserPlan>> GetUsersPlan(int id, CancellationToken cancellationToken = default)
        {
            var userPlan = await _context.UserPlans.FindAsync([id], cancellationToken);
            if (userPlan == null)
                return NotFound();
            return userPlan;
        }

        // POST: api/usersplans
        [HttpPost]
        public async Task<ActionResult<UserPlan>> CreateUsersPlan(UserPlan userPlan, CancellationToken cancellationToken = default)
        {
            await _context.UserPlans.AddAsync(userPlan, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return CreatedAtAction(nameof(GetUsersPlan), new { id = userPlan.Id }, userPlan);
        }

        // PUT: api/usersplans/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsersPlan(int id, UserPlan userPlan, CancellationToken cancellationToken = default)
        {
            if (id != userPlan.Id)
                return BadRequest();

            _context.Entry(userPlan).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
            return NoContent();
        }

        // DELETE: api/usersplans/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsersPlan(int id, CancellationToken cancellationToken = default)
        {
            var userPlan = await _context.UserPlans.FindAsync([id], cancellationToken);
            if (userPlan == null)
                return NotFound();

            _context.UserPlans.Remove(userPlan);
            await _context.SaveChangesAsync(cancellationToken);
            return NoContent();
        }
    }
}