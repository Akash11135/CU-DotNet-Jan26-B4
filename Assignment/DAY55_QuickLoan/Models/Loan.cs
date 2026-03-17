using System.ComponentModel.DataAnnotations;

public class Loan
{
    [Required]
    public int LoanId { get; set; }
    [Required]
    [Display(Name = "Borrower Name")]
    public string BorrowerName { get; set; } = string.Empty;

    [Display(Name = "Lender Name")]
    public string LenderName { get; set; } = string.Empty;

    [Range(1,500000)]
    [Required]
    public double Amount { get; set; }
    public bool IsSettled { get; set; }
}