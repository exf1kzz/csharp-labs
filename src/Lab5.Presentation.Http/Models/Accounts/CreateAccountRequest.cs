using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Http.Models.Accounts;

public sealed class CreateAccountRequest
{
    [NotNull]
    [Required]
    [MinLength(4)]
    public string? PinCode { get; set; }
}