using Microsoft.AspNetCore.Mvc;
using Finelytics.Models;
namespace Finelytics.Domain.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly AppDbContext _context;
        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Create(Category category, string pagePath)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(pagePath);
        }
        public async Task<IActionResult> Update(Category category, string pagePath)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(pagePath);
        }
        public async Task<IActionResult> Delete(Category category, string pagePath)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(pagePath);
        }
        public List<Category> Read()
        {
            List<Category> categories = new List<Category>();
            foreach (Category c in _context.Categories)
            {
                categories.Add(c);
            }
            return categories;
        }
    }
}
