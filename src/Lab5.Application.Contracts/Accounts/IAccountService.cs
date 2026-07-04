using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts.Operations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts;

public interface IAccountService
{
    CreateAccount.Response CreateAccount(CreateAccount.Request request);

    Deposit.Response Deposit(Deposit.Request request);

    Withdraw.Response Withdraw(Withdraw.Request request);

    ViewBalance.Response ViewBalance(ViewBalance.Request request);

    GetHistory.Response GetHistory(GetHistory.Request request);
}