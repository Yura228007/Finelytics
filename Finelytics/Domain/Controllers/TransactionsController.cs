using Microsoft.AspNetCore.Mvc;
using finelytics.Models;
namespace finelytics.Domain.Controllers
{
    public interface ITransactionsController
    {
        public Task<IActionResult> Create(Transaction transaction, string pagePath);
        public Task<IActionResult> Update(Transaction transaction, string pagePath);
        public Task<IActionResult> Delete(Transaction transaction, string pagePath);
        public List<Transaction> Read();
    }
    public class TransactionsController : Controller, ITransactionsController
    {
        private readonly AppDbContext _context;
        public TransactionsController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Create(Transaction transaction, string pagePath)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(pagePath);
        }
        public async Task<IActionResult> Update(Transaction transaction, string pagePath)
        {
            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(pagePath);
        }
        public async Task<IActionResult> Delete(Transaction transaction, string pagePath)
        {
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(pagePath);
        }
        public List<Transaction> Read()
        {
            List<Transaction> transactions = new List<Transaction>();
            foreach (Transaction t in _context.Transactions)
            {
                transactions.Add(t);
            }
            return transactions;
        }
    }
}
