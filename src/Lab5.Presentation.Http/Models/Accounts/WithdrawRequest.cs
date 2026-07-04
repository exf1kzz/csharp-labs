using System.ComponentModel.DataAnnotations;

namespace Lab5.Presentation.Http.Models.Accounts;

public sealed class WithdrawRequest
{
    [Required]
    public Guid SessionKey { get; set; }

    [Range(0.01, double.MaxValue)]
    public decimal Amount { get; set; }
}