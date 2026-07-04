using System.ComponentModel.DataAnnotations;

namespace Lab5.Presentation.Http.Models.Accounts;

public sealed class DepositRequest
{
    [Required]
    public Guid SessionKey { get; set; }

    [Range(0.01, double.MaxValue)]
    public decimal Amount { get; set; }
}