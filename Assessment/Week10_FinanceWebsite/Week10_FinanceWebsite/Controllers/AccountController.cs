using Week10_FinanceWebsite.Data;
using Week10_FinanceWebsite.Models;
using Microsoft.AspNetCore.Mvc;




public class AccountController : Controller
{
    private readonly ApplicationDbContext _context;

    public AccountController(ApplicationDbContext context)
    {
        _context = context;
    }

    
    public IActionResult Index()
    {
        var accounts = _context.Accounts.ToList();
        return View(accounts);
    }

   
    public IActionResult Create()
    {
        return View();
    }

    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Account account)
    {
        if (ModelState.IsValid)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();

            TempData["Success"] = "Account created successfully!";

            return RedirectToAction("Index");
        }

        return View(account);
    }

    [Route("/Account/Transactions/{id:int}")]
    public IActionResult Transactions(int? id)
    {
        var transactions = _context.Transactions.Where(t=>t.AccountId == id).ToList();
        if (!transactions.Any()) 
        {
            TempData["Message"] = "No transactions found for this account.";
            return RedirectToAction("Index");
        }
        return View(transactions);
    }
}