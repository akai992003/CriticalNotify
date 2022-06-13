﻿using System.Diagnostics;
using CriticalNotify.Data;
using CriticalNotify.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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
        var q = await I繳費.取得拆帳字串("1110526");
        var q2 = await I繳費.取得拆帳字串("1110526","體一");
        var dl = new List<dto拆帳字串>();
        var dl2 = new List<dto拆帳字串>();
        var mo = 0;
        foreach (var p in q)
        {
            if (p != "" || p != null)
            {
                var ps = p.Split(";");
                // for (int i = 0; i < ps.Length; i++)
                // {

                // }
                var dto = new dto拆帳字串();

                dto._01病房費 = double.Parse(ps[2]);
                dto._02膳食費 = double.Parse(ps[3]);
                dto._03藥品費 = double.Parse(ps[4]);
                dto._04檢驗費 = double.Parse(ps[5]);
                dto._05心電圖費 = double.Parse(ps[6]);
                dto._06X光費 = double.Parse(ps[7]);
                dto._07X光材料費 = double.Parse(ps[8]);
                dto._08醫療衛材費 = double.Parse(ps[9]);
                dto._09治療費 = double.Parse(ps[10]);
                dto._10手術房費 = double.Parse(ps[11]);
                dto._11麻醉藥品費 = double.Parse(ps[12]);
                dto._12助理醫師費 = double.Parse(ps[13]);
                dto._13護理費 = double.Parse(ps[14]);
                dto._14洗腎費 = double.Parse(ps[15]);
                dto._15證明書費 = double.Parse(ps[16]);
                dto._16復健治療費 = double.Parse(ps[17]);
                dto._17育嬰費 = double.Parse(ps[18]);
                dto._18斷層攝影費 = double.Parse(ps[19]);
                dto._19本院助手費 = double.Parse(ps[20]);
                dto._20核子檢驗費 = double.Parse(ps[21]);
                dto._21切片檢查費 = double.Parse(ps[22]);
                dto._22尿動力測驗 = double.Parse(ps[23]);
                dto._23電話費 = double.Parse(ps[24]);
                dto._24手續費 = double.Parse(ps[25]);
                dto._25一般材料費 = double.Parse(ps[26]);
                dto._26病歷摘要 = double.Parse(ps[27]);
                dto._27檢驗材料費 = double.Parse(ps[28]);
                dto._28手術材料費 = double.Parse(ps[29]);
                dto._29 = double.Parse(ps[30]);
                dto._30掛號費 = double.Parse(ps[31]);
                dto._31診察費 = double.Parse(ps[32]);
                dto._32門診會診費 = double.Parse(ps[33]);
                dto._33住院會診費 = double.Parse(ps[34]);
                dto._34手術費 = double.Parse(ps[35]);
                dto._35麻醉費 = double.Parse(ps[36]);
                dto._36助手費 = double.Parse(ps[37]);
                dto._37加護病房費 = double.Parse(ps[38]);
                dto._38眼科技術費 = double.Parse(ps[39]);
                dto._39特別護士費 = double.Parse(ps[40]);
                dto._40特別材料費 = double.Parse(ps[41]);
                dto._41技術治療費 = double.Parse(ps[42]);
                dto._42血片判讀費 = double.Parse(ps[43]);
                dto._43健保門診自付款 = double.Parse(ps[44]);
                dto._44健保住診自付款 = double.Parse(ps[45]);
                dto._45藥事服務費 = double.Parse(ps[46]);
                dto._46初診工本費 = double.Parse(ps[47]);
                dto._47影印費 = double.Parse(ps[48]);
                dto._48衛教費 = double.Parse(ps[49]);
                dto._49指定醫師費 = double.Parse(ps[50]);
                dto._50醫療諮詢費 = double.Parse(ps[51]);
                dto._51輔具費 = double.Parse(ps[52]);
                dto._52檢查費 = double.Parse(ps[53]);
                dto._53精神科鑑定費 = double.Parse(ps[54]);
                dto._54實習費 = double.Parse(ps[55]);
                dto._55醫事服務費 = double.Parse(ps[56]);
                dto._56醫美技術治療費 = double.Parse(ps[57]);
                dto._57營養配方 = double.Parse(ps[58]);
                dto._58處置費 = double.Parse(ps[59]);
                dto._59 = double.Parse(ps[60]);
                dto._60健康檢查 = double.Parse(ps[61]);
                dto._61影印費 = double.Parse(ps[62]);
                dto._62病情諮詢費 = double.Parse(ps[63]);
                dto._63保險公司指定醫師費 = double.Parse(ps[64]);
                dto._64頭皮諮詢 = double.Parse(ps[65]);
                dto._65疼痛麻醉費 = double.Parse(ps[66]);
                dto._66疼痛麻醉材料費 = double.Parse(ps[67]);
                dto._67無痛鏡檢麻醉費 = double.Parse(ps[68]);
                dto._68無痛鏡檢材料費 = double.Parse(ps[69]);
                dl.Add(dto);
            }

        }
        foreach (var p in q2)
        {
            if (p != "" || p != null)
            {
                var ps = p.Split(";");
                // for (int i = 0; i < ps.Length; i++)
                // {

                // }
                var dto = new dto拆帳字串();

                dto._01病房費 = double.Parse(ps[2]);
                dto._02膳食費 = double.Parse(ps[3]);
                dto._03藥品費 = double.Parse(ps[4]);
                dto._04檢驗費 = double.Parse(ps[5]);
                dto._05心電圖費 = double.Parse(ps[6]);
                dto._06X光費 = double.Parse(ps[7]);
                dto._07X光材料費 = double.Parse(ps[8]);
                dto._08醫療衛材費 = double.Parse(ps[9]);
                dto._09治療費 = double.Parse(ps[10]);
                dto._10手術房費 = double.Parse(ps[11]);
                dto._11麻醉藥品費 = double.Parse(ps[12]);
                dto._12助理醫師費 = double.Parse(ps[13]);
                dto._13護理費 = double.Parse(ps[14]);
                dto._14洗腎費 = double.Parse(ps[15]);
                dto._15證明書費 = double.Parse(ps[16]);
                dto._16復健治療費 = double.Parse(ps[17]);
                dto._17育嬰費 = double.Parse(ps[18]);
                dto._18斷層攝影費 = double.Parse(ps[19]);
                dto._19本院助手費 = double.Parse(ps[20]);
                dto._20核子檢驗費 = double.Parse(ps[21]);
                dto._21切片檢查費 = double.Parse(ps[22]);
                dto._22尿動力測驗 = double.Parse(ps[23]);
                dto._23電話費 = double.Parse(ps[24]);
                dto._24手續費 = double.Parse(ps[25]);
                dto._25一般材料費 = double.Parse(ps[26]);
                dto._26病歷摘要 = double.Parse(ps[27]);
                dto._27檢驗材料費 = double.Parse(ps[28]);
                dto._28手術材料費 = double.Parse(ps[29]);
                dto._29 = double.Parse(ps[30]);
                dto._30掛號費 = double.Parse(ps[31]);
                dto._31診察費 = double.Parse(ps[32]);
                dto._32門診會診費 = double.Parse(ps[33]);
                dto._33住院會診費 = double.Parse(ps[34]);
                dto._34手術費 = double.Parse(ps[35]);
                dto._35麻醉費 = double.Parse(ps[36]);
                dto._36助手費 = double.Parse(ps[37]);
                dto._37加護病房費 = double.Parse(ps[38]);
                dto._38眼科技術費 = double.Parse(ps[39]);
                dto._39特別護士費 = double.Parse(ps[40]);
                dto._40特別材料費 = double.Parse(ps[41]);
                dto._41技術治療費 = double.Parse(ps[42]);
                dto._42血片判讀費 = double.Parse(ps[43]);
                dto._43健保門診自付款 = double.Parse(ps[44]);
                dto._44健保住診自付款 = double.Parse(ps[45]);
                dto._45藥事服務費 = double.Parse(ps[46]);
                dto._46初診工本費 = double.Parse(ps[47]);
                dto._47影印費 = double.Parse(ps[48]);
                dto._48衛教費 = double.Parse(ps[49]);
                dto._49指定醫師費 = double.Parse(ps[50]);
                dto._50醫療諮詢費 = double.Parse(ps[51]);
                dto._51輔具費 = double.Parse(ps[52]);
                dto._52檢查費 = double.Parse(ps[53]);
                dto._53精神科鑑定費 = double.Parse(ps[54]);
                dto._54實習費 = double.Parse(ps[55]);
                dto._55醫事服務費 = double.Parse(ps[56]);
                dto._56醫美技術治療費 = double.Parse(ps[57]);
                dto._57營養配方 = double.Parse(ps[58]);
                dto._58處置費 = double.Parse(ps[59]);
                dto._59 = double.Parse(ps[60]);
                dto._60健康檢查 = double.Parse(ps[61]);
                dto._61影印費 = double.Parse(ps[62]);
                dto._62病情諮詢費 = double.Parse(ps[63]);
                dto._63保險公司指定醫師費 = double.Parse(ps[64]);
                dto._64頭皮諮詢 = double.Parse(ps[65]);
                dto._65疼痛麻醉費 = double.Parse(ps[66]);
                dto._66疼痛麻醉材料費 = double.Parse(ps[67]);
                dto._67無痛鏡檢麻醉費 = double.Parse(ps[68]);
                dto._68無痛鏡檢材料費 = double.Parse(ps[69]);
                dl2.Add(dto);
            }

        }
        var total檢驗費 = dl.Sum(c => c._04檢驗費);
        var total檢驗費體一 = dl2.Sum(d => d._04檢驗費);
        ViewBag.total檢驗費 = total檢驗費;
        ViewBag.total檢驗費體一 = total檢驗費體一;
        return View(dl);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
