using Microsoft.AspNetCore.Mvc;
using Finelytics.Models;
namespace Finelytics.Domain.Controllers
{
    public class PlansCategoriesController : Controller
    {
        private readonly AppDbContext _context;
        public PlansCategoriesController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Create(PlanCategory planCategory, string pagePath)
        {
            _context.PlansCategories.Add(planCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(pagePath);
        }
        public async Task<IActionResult> Update(PlanCategory planCategory, string pagePath)
        {
            _context.PlansCategories.Update(planCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(pagePath);
        }
        public async Task<IActionResult> Delete(PlanCategory planCategory, string pagePath)
        {
            _context.PlansCategories.Remove(planCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(pagePath);
        }
        public List<PlanCategory> Read()
        {
            List<PlanCategory> planCategories = new List<PlanCategory>();
            foreach (PlanCategory pc in _context.PlansCategories)
            {
                planCategories.Add(pc);
            }
            return planCategories;
        }
    }
}
