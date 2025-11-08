using Microsoft.AspNetCore.Mvc;
using finelytics.Models;
namespace finelytics.Domain.Controllers
{
    public interface IPlansCategoriesController
    {
        public Task<IActionResult> Create(PlanCategory category, string pagePath);
        public Task<IActionResult> Update(PlanCategory category, string pagePath);
        public Task<IActionResult> Delete(PlanCategory category, string pagePath);
        public List<PlanCategory> Read();
    }
    public class PlansCategoriesController : Controller, IPlansCategoriesController
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
