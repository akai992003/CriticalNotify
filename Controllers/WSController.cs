using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CriticalNotify.Models;
using CriticalNotify.Data;

namespace CriticalNotify.Controllers;
[Route("api/[controller]")]
[ApiController]
public class WSController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;
    private readonly I病患檔Service I病患檔;

    public WSController(ILogger<HomeController> logger,I病患檔Service _病患檔)
    {
        _logger = logger;
        I病患檔 = _病患檔;
    }
    [HttpGet("test1")]
    public async Task<IActionResult> mytest1(int counter)
    {
        var q = await this.I病患檔.Get病患檔 (counter);
        return Ok(new{
            身份證字號 = q.身份證字號,
            姓名 = q.姓名
        });
    }

   [HttpGet("test3")]
    public async Task<IActionResult> mytest3(string ID)
    {
        var q = await this.I病患檔.Get病患檔ByID (ID);
        return Ok(new{
                data = q
        });
    }


    // public IActionResult Privacy()
    // {
    //     // return View();
    // }
    [HttpPost("test2")]
    public async Task<IActionResult> mytest2(mydto d1)
    {
        string? id = d1.id;
        int counter = d1.counter;
        id = id + "after11111";
        counter += 100;
        return Ok(new{
            _id = id,
            _counter = counter

        });

    }
 
}
