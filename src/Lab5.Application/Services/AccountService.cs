using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Queries;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts.Operations;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Mapping;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Transactions.Results;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Services;

public class AccountService : IAccountService
{
    private readonly IPersistenceContext _context;

    public AccountService(IPersistenceContext context)
    {
        _context = context;
    }

    public CreateAccount.Response CreateAccount(CreateAccount.Request request)
    {
        var account = new Account(AccountId.New(), new PinCode(request.PinCode));

        _context.Accounts.Add(account);

        return new CreateAccount.Response.Success(account.MapToDto());
    }

    public Deposit.Response Deposit(Deposit.Request request)
    {
        var sessionId = new SessionId(request.SessionKey);

        UserSession? session = _context.Sessions
            .Query(SessionQuery.Build(b => b.WithIds(new[] { sessionId })))
            .OfType<UserSession>()
            .SingleOrDefault();

        if (session is null)
        {
            return new Deposit.Response.Failure("Invalid session");
        }

        Account? account = _context.Accounts
            .Query(AccountQuery.Build(b => b.WithIds(new[] { session.AccountId })))
            .SingleOrDefault();

        if (account is null)
        {
            return new Deposit.Response.Failure("Account not found");
        }

        DepositResult result = account.Deposit(new Money(request.Amount));

        if (result is DepositResult.Failure failure)
        {
            return new Deposit.Response.Failure(failure.Message);
        }

        return new Deposit.Response.Success(account.MapToDto());
    }

    public Withdraw.Response Withdraw(Withdraw.Request request)
    {
        var sessionId = new SessionId(request.SessionKey);

        UserSession? session = _context.Sessions
            .Query(SessionQuery.Build(b => b.WithIds(new[] { sessionId })))
            .OfType<UserSession>()
            .SingleOrDefault();

        if (session is null)
        {
            return new Withdraw.Response.Failure("Invalid session");
        }

        Account? account = _context.Accounts
            .Query(AccountQuery.Build(b => b.WithIds(new[] { session.AccountId })))
            .SingleOrDefault();

        if (account is null)
        {
            return new Withdraw.Response.Failure("Account not found");
        }

        WithdrawResult result = account.Withdraw(new Money(request.Amount));

        if (result is WithdrawResult.Failure failure)
        {
            return new Withdraw.Response.Failure(failure.Message);
        }

        return new Withdraw.Response.Success(account.MapToDto());
    }

    public ViewBalance.Response ViewBalance(ViewBalance.Request request)
    {
        var sessionId = new SessionId(request.SessionKey);

        UserSession? session = _context.Sessions
            .Query(SessionQuery.Build(b => b.WithIds(new[] { sessionId })))
            .OfType<UserSession>()
            .SingleOrDefault();

        if (session is null)
        {
            return new ViewBalance.Response.Failure("Invalid session");
        }

        Account? account = _context.Accounts
            .Query(AccountQuery.Build(b => b.WithIds(new[] { session.AccountId })))
            .SingleOrDefault();

        if (account is null)
        {
            return new ViewBalance.Response.Failure("Account not found");
        }

        return new ViewBalance.Response.Success(account.Balance.Value);
    }

    public GetHistory.Response GetHistory(GetHistory.Request request)
    {
        var sessionId = new SessionId(request.SessionKey);

        UserSession? session = _context.Sessions
            .Query(SessionQuery.Build(b => b.WithIds(new[] { sessionId })))
            .OfType<UserSession>()
            .SingleOrDefault();

        if (session is null)
        {
            return new GetHistory.Response.Failure("Invalid session");
        }

        Account? account = _context.Accounts
            .Query(AccountQuery.Build(b => b.WithIds(new[] { session.AccountId })))
            .SingleOrDefault();

        if (account is null)
        {
            return new GetHistory.Response.Failure("Account not found");
        }

        var tracsactions = account.Transactions
            .Select(t => t.MapToDto())
            .ToList();

        return new GetHistory.Response.Success(tracsactions);
    }
}