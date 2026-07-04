using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Queries;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts.Operations;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Services;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.ValueObjects;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class AccountServiceTests
{
    [Fact]
    public void Withdraw_WhenBalanceIsEnought_ShouldUpdateBalance()
    {
        // Arrange
        var accountId = AccountId.New();
        var sessionId = SessionId.New();

        var account = new Account(accountId, new PinCode("1234"));
        account.Deposit(new Money(777));

        var session = new UserSession(sessionId, accountId);

        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        IPersistenceContext context = Substitute.For<IPersistenceContext>();

        accountRepository
            .Query(Arg.Any<AccountQuery>())
            .Returns(new[] { account });

        sessionRepository
            .Query(Arg.Any<SessionQuery>())
            .Returns(new[] { session });

        context.Accounts.Returns(accountRepository);
        context.Sessions.Returns(sessionRepository);

        var service = new AccountService(context);

        // Act
        Withdraw.Response response = service.Withdraw(new Withdraw.Request(sessionId.Value, 666));

        // Assert
        Withdraw.Response.Success success = Assert.IsType<Withdraw.Response.Success>(response);
        Assert.Equal(111, success.Account.Balance);
    }

    [Fact]
    public void Withdraw_WhenBalanceNotEnought_ShouldReturnFailure()
    {
        // Arrange
        var accountId = AccountId.New();
        var sessionId = SessionId.New();

        var account = new Account(accountId, new PinCode("1234"));
        account.Deposit(new Money(33));

        var session = new UserSession(sessionId, accountId);

        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        IPersistenceContext context = Substitute.For<IPersistenceContext>();

        accountRepository
            .Query(Arg.Any<AccountQuery>())
            .Returns(new[] { account });

        sessionRepository
            .Query(Arg.Any<SessionQuery>())
            .Returns(new[] { session });

        context.Accounts.Returns(accountRepository);
        context.Sessions.Returns(sessionRepository);

        var service = new AccountService(context);

        // Act
        Withdraw.Response response = service.Withdraw(new Withdraw.Request(sessionId.Value, 666));

        // Assert
        Withdraw.Response.Failure failure = Assert.IsType<Withdraw.Response.Failure>(response);
        Assert.Equal("Insufficient funds", failure.Message);
    }

    [Fact]
    public void Deposit_ShouldUpdateBalance()
    {
        // Arrange
        var accountId = AccountId.New();
        var sessionId = SessionId.New();

        var account = new Account(accountId, new PinCode("1234"));
        var session = new UserSession(sessionId, accountId);

        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        IPersistenceContext context = Substitute.For<IPersistenceContext>();

        accountRepository
            .Query(Arg.Any<AccountQuery>())
            .Returns(new[] { account });

        sessionRepository
            .Query(Arg.Any<SessionQuery>())
            .Returns(new[] { session });

        context.Accounts.Returns(accountRepository);
        context.Sessions.Returns(sessionRepository);

        var service = new AccountService(context);

        // Act
        Deposit.Response response = service.Deposit(new Deposit.Request(sessionId.Value, 666));

        // Assert
        Deposit.Response.Success success = Assert.IsType<Deposit.Response.Success>(response);
        Assert.Equal(666, success.Account.Balance);
    }
}