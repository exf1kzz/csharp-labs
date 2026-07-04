using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts.Models;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Transactions;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Mapping;

public static class TransactionMappingExtensions
{
    public static TransactionDto MapToDto(this Transaction transaction)
        => new TransactionDto(transaction.Type.Name, transaction.Amount.Value, transaction.IsCompleted ? "Completed" : "Pending");
}