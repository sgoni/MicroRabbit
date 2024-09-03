using Microrabbit.Transfer.Application.Interfaces;
using Microrabbit.Transfer.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MicroRabbit.Transfer.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransferController : Controller
{
    private readonly ILogger<TransferController> _logger;
    private readonly ITransferService _transferService;

    public TransferController(ITransferService transferService, ILogger<TransferController> logger)
    {
        _transferService = transferService;
        _logger = logger;
    }

    [HttpGet(Name = "GetTransfers")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<TransferLog>> Get()
    {
        return Ok(_transferService.GetTransferLogs());
    }
}