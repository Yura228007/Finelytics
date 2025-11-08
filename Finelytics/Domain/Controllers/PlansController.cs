using Microsoft.AspNetCore.Mvc;
using finelytics.Models;
namespace finelytics.Domain.Controllers
{
    public interface IPlansController
    {
        public Task<IActionResult> Create(Plan plan, string pagePath);
        public Task<IActionResult> Update(Plan plan, string pagePath);
        public Task<IActionResult> Delete(Plan plan, string pagePath);
        public List<Plan> Read();
    }
    public class PlansController : Controller, IPlansController
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
