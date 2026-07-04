using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Http.Models.Sessions;

public sealed class CreateAdminSessionRequest
{
    [NotNull]
    [Required]
    public string? SystemPassword { get; set; }
}