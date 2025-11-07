using Microsoft.AspNetCore.Mvc;
using Finelytics.Models;
namespace Finelytics.Domain.Controllers
{
    public class UsersGroupsController : Controller
    {
        private readonly AppDbContext _context;
        public UsersGroupsController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Create(UsersGroup usersGroup, string pagePath)
        {
            _context.UsersGroups.Add(usersGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(pagePath);
        }
        public async Task<IActionResult> Update(UsersGroup usersGroup, string pagePath)
        {
            _context.UsersGroups.Update(usersGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(pagePath);
        }
        public async Task<IActionResult> Delete(UsersGroup usersGroup, string pagePath)
        {
            _context.UsersGroups.Remove(usersGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(pagePath);
        }
        public List<UsersGroup> Read()
        {
            List<UsersGroup> userGroups = new List<UsersGroup>();
            foreach (UsersGroup ug in _context.UsersGroups)
            {
                userGroups.Add(ug);
            }
            return userGroups;
        }
    }
}
