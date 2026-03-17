using Microsoft.AspNetCore.Mvc;

namespace DAY55_QuickLoan.Controllers
{
    public class LoanController : Controller
    {
        public static List<Loan> loans = new List<Loan>();

        public IActionResult Index()
        {

            return View(loans);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Loan loan)
        {
            var existing = loans.Find(x => x.LoanId == loan.LoanId);

            if (existing != null)
            {
                TempData["Error"] = "Loan already exists";
                return RedirectToAction("Index");
            }

            loans.Add(loan);

            TempData["Success"] = "Loan Added Successfully";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var loan = loans.Find(x => x.LoanId == id);
            if (loan != null)
            {
                  
                loans.Remove(loan);
            }
            TempData["success"] = "Deleted successfully";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id )
        {
            var autoFillform = loans.FirstOrDefault(x => x.LoanId == id);
            if (autoFillform == null)
            {
                return NotFound();
            }
            return View(autoFillform);
        }

        [HttpPost]
        public IActionResult Edit(Loan editedLoan)
        {
            bool check = false;
            foreach(var i in loans)
            {
                if (i.LoanId == editedLoan.LoanId)
                {
                    check = true;
                    i.LoanId = editedLoan.LoanId;
                    i.Amount = editedLoan.Amount;
                    i.BorrowerName = editedLoan.BorrowerName;
                    i.LenderName = editedLoan.LenderName;
                    i.IsSettled = editedLoan.IsSettled;
                }
            }

            if (check)
            {
                TempData["Success"] = "Edited successfully";
            }
            else
            {
                TempData["Error"] = "Unable to edit";
            }
            return RedirectToAction("Index");
        }
    }
}
