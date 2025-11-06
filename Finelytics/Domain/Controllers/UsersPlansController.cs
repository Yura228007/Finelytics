using Microsoft.AspNetCore.Mvc;
using Finelytics.Models;
namespace Finelytics.Domain.Controllers
{
    public class UsersPlansController : Controller
    {
        private readonly AppDbContext _context;
        public UsersPlansController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Create(UserPlan userPlan, string pagePath)
        {
            _context.UserPlans.Add(userPlan);
            await _context.SaveChangesAsync();
            return RedirectToAction(pagePath);
        }
        public async Task<IActionResult> Update(UserPlan userPlan, string pagePath)
        {
            _context.UserPlans.Update(userPlan);
            await _context.SaveChangesAsync();
            return RedirectToAction(pagePath);
        }
        public async Task<IActionResult> Delete(UserPlan userPlan, string pagePath)
        {
            _context.UserPlans.Remove(userPlan);
            await _context.SaveChangesAsync();
            return RedirectToAction(pagePath);
        }
        public List<UserPlan> Read()
        {
            List<UserPlan> userPlans = new List<UserPlan>();
            foreach (UserPlan up in _context.UserPlans)
            {
                userPlans.Add(up);
            }
            return userPlans;
        }
    }
}
