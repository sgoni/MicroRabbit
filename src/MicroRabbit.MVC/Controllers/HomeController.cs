using System.Diagnostics;
using MicroRabbit.MVC.Models;
using MicroRabbit.MVC.Models.DTO;
using MicroRabbit.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace MicroRabbit.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ITransferService _transferService;

    public HomeController(ITransferService transferService)
    {
        _transferService = transferService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    public async Task<IActionResult> Transfer(TransferViewModel model)
    {
        var transferDto = new TransferDto
        {
            FromAccount = model.FromAccount,
            ToAccount = model.ToAccount,
            TransferAmount = model.TransferAmount
        };

        await _transferService.Transfer(transferDto);

        return View("Index");
    }
}