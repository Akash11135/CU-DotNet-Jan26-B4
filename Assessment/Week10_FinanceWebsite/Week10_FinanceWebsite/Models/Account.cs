using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Week10_FinanceWebsite.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Balance { get; set; }

        //to avoid transactions validations.
        [ValidateNever]
        public List<Transaction> Transactions { get; set; }

    }
}
