using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts.Models;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Mapping;

public static class AccountMappingExtensions
{
    public static AccountDto MapToDto(this Account account)
        => new AccountDto(account.Id.Value, account.Balance.Value);
}