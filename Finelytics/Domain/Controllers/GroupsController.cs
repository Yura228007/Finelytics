using Microsoft.AspNetCore.Mvc;
using finelytics.Models;
namespace finelytics.Domain.Controllers
{
    public interface IGroupsController
    {
        public Task<IActionResult> Create(Group group, string pagePath);
        public Task<IActionResult> Update(Group group, string pagePath);
        public Task<IActionResult> Delete(Group group, string pagePath);
        public List<Group> Read();
    }
    public class GroupsController : Controller, IGroupsController
    {
        private readonly AppDbContext _context;
        public GroupsController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Create(Group group, string pagePath)
        {
            _context.Groups.Add(group);
            await _context.SaveChangesAsync();
            return RedirectToAction(pagePath);
        }
        public async Task<IActionResult> Update(Group group, string pagePath)
        {
            _context.Groups.Update(group);
            await _context.SaveChangesAsync();
            return RedirectToAction(pagePath);
        }
        public async Task<IActionResult> Delete(Group group, string pagePath)
        {
            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();
            return RedirectToAction(pagePath);
        }
        public List<Group> Read()
        {
            List<Group> groups = new List<Group>();
            foreach (Group g in _context.Groups)
            {
                groups.Add(g);
            }
            return groups;
        }
    }
}
