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
    private readonly I報告台結果檔Service I報告台結果檔;

    public WSController(ILogger<HomeController> logger, I病患檔Service _病患檔, I報告台結果檔Service _報告台結果檔)
    {
        _logger = logger;
        I病患檔 = _病患檔;
        I報告台結果檔 = _報告台結果檔;

    }
    //給方鼎呼叫的ws 需要他們從檢驗報到台、報告登錄台、報告報到台傳入參數
    [HttpGet("criti_report")]
    public async Task<IActionResult> criti_report1(string type, int counter)
    {
        var q = await this.I報告台結果檔.Get報告台結果檔(type,counter);
        return Ok(new
        {
            counter = q.counter,
            病患檔_counter = q.病患檔_counter,
            來源代碼 = q.來源代碼,
            報告台代碼 = q.報告台代碼,
            來源檔_counter = q.來源檔_counter,
            開單日期 = q.開單日期,
            報到日期 = q.報到日期,
            報到時間 = q.報到時間,
            檢查日期 = q.檢查日期,
            檢查時間 = q.檢查時間,
            完成日期 = q.完成日期,
            完成時間 = q.完成時間,
            報告師代號 = q.報告師代號,
            流程旗標 = q.流程旗標,
            申請流水號 = q.申請流水號
        });
    }

    [HttpGet("test3")]
    public async Task<IActionResult> mytest3(string ID)
    {
        var q = await this.I病患檔.Get病患檔ByID(ID);
        return Ok(new
        {
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
        string? id = d1.type;
        int counter = d1.counter;
        id = id + "after11111";
        counter += 100;
        return Ok(new
        {
            _id = id,
            _counter = counter

        });

    }

}
