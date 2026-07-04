using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Http.Models.Sessions;

public class CreateUserSessionRequest
{
    [Required]
    public Guid AccountId { get; set; }

    [NotNull]
    [Required]
    [MinLength(4)]
    public string? PinCode { get; set; }
}