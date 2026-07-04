using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Sessions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Sessions.Models;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Sessions.Operations;
using Lab5.Presentation.Http.Models.Sessions;
using Microsoft.AspNetCore.Mvc;

namespace Lab5.Presentation.Http.Controllers;

[ApiController]
[Route("/api/sessions")]
public sealed class SessionsController : ControllerBase
{
    private readonly ISessionService _sessionService;

    public SessionsController(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    [HttpPost("user")]
    public ActionResult<SessionDto> CreateUserSession([FromBody] CreateUserSessionRequest httpRequest)
    {
        var request = new CreateUserSession.Request(httpRequest.AccountId, httpRequest.PinCode);

        CreateUserSession.Response response = _sessionService.CreateUserSession(request);

        return Ok(response.Session);
    }

    [HttpPost("admin")]
    public ActionResult<SessionDto> CreateAdminSession([FromBody] CreateAdminSessionRequest httpRequest)
    {
        var request = new CreateAdminSession.Request(httpRequest.SystemPassword);
        CreateAdminSession.Response response = _sessionService.CreateAdminSession(request);

        return Ok(response.Session);
    }
}