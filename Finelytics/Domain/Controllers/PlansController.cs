using Microsoft.AspNetCore.Mvc;
using Finelytics.Models;
namespace Finelytics.Domain.Controllers
{
    public class PlansController : Controller
    {
        private readonly AppDbContext _context;
        public PlansController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Create(Plan plan, string pagePath)
        {
            _context.Plans.Add(plan);
            await _context.SaveChangesAsync();
            return RedirectToAction(pagePath);
        }
        public async Task<IActionResult> Update(Plan plan, string pagePath)
        {
            _context.Plans.Update(plan);
            await _context.SaveChangesAsync();
            return RedirectToAction(pagePath);
        }
        public async Task<IActionResult> Delete(Plan plan, string pagePath)
        {
            _context.Plans.Remove(plan);
            await _context.SaveChangesAsync();
            return RedirectToAction(pagePath);
        }
        public List<Plan> Read()
        {
            List<Plan> plans = new List<Plan>();
            foreach (Plan p in _context.Plans)
            {
                plans.Add(p);
            }
            return plans;
        }
    }
}
