using System.Diagnostics;
using CriticalNotify.Data;
using CriticalNotify.Models;
using Microsoft.AspNetCore.Mvc;

namespace CriticalNotify.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly I危急值通報檔Service I危急值通報檔;
    private readonly I繳費Service I繳費;

    public HomeController(ILogger<HomeController> logger, I危急值通報檔Service _危急值通報檔
    , I繳費Service _I繳費Service)
    {
        _logger = logger;
        I危急值通報檔 = _危急值通報檔;
        I繳費 = _I繳費Service;
    }

    public async Task<IActionResult> Index(int counter)
    {

        var q = await I危急值通報檔.Get危急值通報檔ByCounter(counter);
        return View(q);

    }

    public async Task<IActionResult> Privacy()
    {
        var q = await I繳費.取得拆帳字串("1110601");
        var dl = new List<dto拆帳字串>();
        foreach (var p in q)
        {
            if (p != "" || p != null)
            {
                var ps = p.Split(";");
                // for (int i = 0; i < ps.Length; i++)
                // {

                // }
                var dto = new dto拆帳字串();
                dto.診察費 = double.Parse(ps[0]);
                dto.病房費 = double.Parse(ps[1]);
                dto.管灌膳食費 = double.Parse(ps[2]);
                dto.檢查費 = double.Parse(ps[3]);
                dto.放射線診療費 = double.Parse(ps[4]);
                dto.治療處置費 = double.Parse(ps[5]);
                dto.手術費 = double.Parse(ps[6]);
                dto.復健治療費 = double.Parse(ps[7]);
                dto.血液血漿費 = double.Parse(ps[8]);
                dto.血液透析費 = double.Parse(ps[9]);
                dto.麻醉費 = double.Parse(ps[10]);
                dto.特殊材料費 = double.Parse(ps[11]);
                dto.藥費 = double.Parse(ps[12]);
                dto.藥事服務費 = double.Parse(ps[13]);
                dto.精神科治療費 = double.Parse(ps[14]);
                dto.注射技術費 = double.Parse(ps[15]);
                dto.嬰兒費 = double.Parse(ps[16]);
                dto.自定 = double.Parse(ps[17]);
                dto.檢驗費 = double.Parse(ps[18]);
                dto.工本費 = double.Parse(ps[19]);
                dto.手續費 = double.Parse(ps[20]);

                dl.Add(dto);
            }

        }
        return View(dl);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
