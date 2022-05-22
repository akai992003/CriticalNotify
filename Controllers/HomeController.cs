using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CriticalNotify.Models;
using CriticalNotify.Data;

namespace CriticalNotify.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly I危急值通報檔Service I危急值通報檔;

    public HomeController(ILogger<HomeController> logger,I危急值通報檔Service _危急值通報檔)
    {
        _logger = logger;
        I危急值通報檔 =_危急值通報檔;
    }

    public async Task<IActionResult> Index(int counter)
    {
        var q = await I危急值通報檔.Get危急值通報檔ByCounter(counter);
        return View(q);
        
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
}
