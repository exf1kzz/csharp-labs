namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts.Models;

public sealed record TransactionDto(string Type, decimal Amount, string State);