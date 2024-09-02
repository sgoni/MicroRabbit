using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MicroRabbit.Banking.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BankingController : Controller
{
    private readonly IAccountService _accountService;

    public BankingController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet]
    [Route("GetAccounts")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<Account>> GetAccounts()
    {
        return Ok(_accountService.GetAccounts());
    }
}