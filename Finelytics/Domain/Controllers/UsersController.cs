using Microsoft.AspNetCore.Mvc;
using finelytics.Models;

namespace finelytics.Domain.Controllers
{
    public interface IUsersController
    {
        public Task<IActionResult> Create(User user, string pagePath);
        public Task<IActionResult> Update(User user, string pagePath);
        public Task<IActionResult> Delete(User user, string pagePath);
        public List<User> Read();
    }
    public class UsersController : Controller, IUsersController
    {
        private readonly AppDbContext _context;
        public UsersController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Create(User user,string pagePath)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(pagePath);
        }
        public async Task<IActionResult> Update(User user, string pagePath)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(pagePath);
        }
        public async Task<IActionResult> Delete(User user, string pagePath)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(pagePath);
        }
        public List<User> Read()
        {
            List<User> users = new List<User>();
            foreach (User u in _context.Users)
            {
                users.Add(u);
            }
            return users;
        }
    }
}
