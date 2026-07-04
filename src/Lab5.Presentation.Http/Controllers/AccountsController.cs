using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts.Models;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts.Operations;
using Lab5.Presentation.Http.Models.Accounts;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab5.Presentation.Http.Controllers;

[ApiController]
[Route("/api/accounts")]
public sealed class AccountsController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountsController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost]
    public ActionResult<AccountDto> CreateAccount([FromBody] CreateAccountRequest httpRequest)
    {
        var request = new CreateAccount.Request(httpRequest.PinCode);
        CreateAccount.Response response = _accountService.CreateAccount(request);

        return response switch
        {
            CreateAccount.Response.Success success => Ok(success.Account),
            CreateAccount.Response.Failure failure => BadRequest(failure.Message),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("deposit")]
    public ActionResult<AccountDto> Deposit([FromBody] DepositRequest httpRequest)
    {
        var request = new Deposit.Request(httpRequest.SessionKey, httpRequest.Amount);
        Deposit.Response response = _accountService.Deposit(request);

        return response switch
        {
            Deposit.Response.Success success => Ok(success.Account),
            Deposit.Response.Failure failure => BadRequest(failure.Message),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("withdraw")]
    public ActionResult<AccountDto> Withdraw([FromBody] WithdrawRequest httpRequest)
    {
        var request = new Withdraw.Request(httpRequest.SessionKey, httpRequest.Amount);
        Withdraw.Response response = _accountService.Withdraw(request);

        return response switch
        {
            Withdraw.Response.Success success => Ok(success.Account),
            Withdraw.Response.Failure failure => BadRequest(failure.Message),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("balance")]
    public ActionResult<decimal> ViewBalance([FromQuery] Guid sessionKey)
    {
        var request = new ViewBalance.Request(sessionKey);
        ViewBalance.Response response = _accountService.ViewBalance(request);

        return response switch
        {
            ViewBalance.Response.Success success => Ok(success.Balance),
            ViewBalance.Response.Failure failure => BadRequest(failure.Message),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("history")]
    public ActionResult<IReadOnlyList<TransactionDto>> History([FromQuery] Guid sessionKey)
    {
        var request = new GetHistory.Request(sessionKey);
        GetHistory.Response response = _accountService.GetHistory(request);

        return response switch
        {
            GetHistory.Response.Success success => Ok(success.Transactions),
            GetHistory.Response.Failure failure => BadRequest(failure.Message),
            _ => throw new UnreachableException(),
        };
    }
}