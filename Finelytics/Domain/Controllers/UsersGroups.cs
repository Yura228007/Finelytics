using Microsoft.AspNetCore.Mvc;
using finelytics.Models;
namespace finelytics.Domain.Controllers
{
    public interface IUsersGroupsController
    {
        public Task<IActionResult> Create(UsersGroup usersGroup, string pagePath);
        public Task<IActionResult> Update(UsersGroup usersGroup, string pagePath);
        public Task<IActionResult> Delete(UsersGroup usersGroup, string pagePath);
        public List<UsersGroup> Read();
    }
    public class UsersGroupsController : Controller, IUsersGroupsController
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
