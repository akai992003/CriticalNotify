using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CriticalNotify.Data;

public class 繳費檔
{
    [Key]
    public Int32 counter { get; set; }
    public Int32 病患檔_counter { get; set; }
    public string? 姓名 { get; set; }
    public string? 拆帳字串 { get; set; }
    public string 日期 { get; set; }
    public string 經手人代號 { get; set; }
    public string 註銷否 { get; set; }
    public string 醫師代號 { get; set; }
    public string 付款方式代碼 { get; set; }
    public Single 實收檢驗費 { get; set; }
    public Single 實收檢查費 { get; set; }
}

public class dto拆帳字串2
{
    public string dto日期 { get; set; }
    public List<dto拆帳字串> dto { get; set; }
}


public class dto拆帳字串
{

    public string 病患姓名 { get; set; }
    public double _01病房費 { get; set; }
    public double _02膳食費 { get; set; }
    public double _03藥品費 { get; set; }
    public double _04檢驗費 { get; set; }
    public double _05心電圖費 { get; set; }
    public double _06X光費 { get; set; }
    public double _07X光材料費 { get; set; }
    public double _08醫療衛材費 { get; set; }
    public double _09治療費 { get; set; }
    public double _10手術房費 { get; set; }
    public double _11麻醉藥品費 { get; set; }
    public double _12助理醫師費 { get; set; }
    public double _13護理費 { get; set; }
    public double _14洗腎費 { get; set; }
    public double _15證明書費 { get; set; }
    public double _16復健治療費 { get; set; }
    public double _17育嬰費 { get; set; }
    public double _18斷層攝影費 { get; set; }
    public double _19本院助手費 { get; set; }
    public double _20核子檢驗費 { get; set; }
    public double _21切片檢查費 { get; set; }
    public double _22尿動力測驗 { get; set; }
    public double _23電話費 { get; set; }
    public double _24手續費 { get; set; }
    public double _25一般材料費 { get; set; }
    public double _26病歷摘要 { get; set; }
    public double _27檢驗材料費 { get; set; }
    public double _28手術材料費 { get; set; }
    public double _29 { get; set; }
    public double _30掛號費 { get; set; }
    public double _31診察費 { get; set; }
    public double _32門診會診費 { get; set; }
    public double _33住院會診費 { get; set; }
    public double _34手術費 { get; set; }
    public double _35麻醉費 { get; set; }
    public double _36助手費 { get; set; }
    public double _37加護病房費 { get; set; }
    public double _38眼科技術費 { get; set; }
    public double _39特別護士費 { get; set; }
    public double _40特別材料費 { get; set; }
    public double _41技術治療費 { get; set; }
    public double _42血片判讀費 { get; set; }
    public double _43健保門診自付款 { get; set; }
    public double _44健保住診自付款 { get; set; }
    public double _45藥事服務費 { get; set; }
    public double _46初診工本費 { get; set; }
    public double _47影印費 { get; set; }
    public double _48衛教費 { get; set; }
    public double _49指定醫師費 { get; set; }
    public double _50醫療諮詢費 { get; set; }
    public double _51輔具費 { get; set; }
    public double _52檢查費 { get; set; }
    public double _53精神科鑑定費 { get; set; }
    public double _54實習費 { get; set; }
    public double _55醫事服務費 { get; set; }
    public double _56醫美技術治療費 { get; set; }
    public double _57營養配方 { get; set; }
    public double _58處置費 { get; set; }
    public double _59 { get; set; }
    public double _60健康檢查 { get; set; }
    public double _61影印費 { get; set; }
    public double _62病情諮詢費 { get; set; }
    public double _63保險公司指定醫師費 { get; set; }
    public double _64頭皮諮詢 { get; set; }
    public double _65疼痛麻醉費 { get; set; }
    public double _66疼痛麻醉材料費 { get; set; }
    public double _67無痛鏡檢麻醉費 { get; set; }
    public double _68無痛鏡檢材料費 { get; set; }
}

public interface I繳費Service
{
    Task<List<繳費檔>> 取得拆帳字串(string 日期);
    Task<List<繳費檔>> 取得拆帳字串(string 日期, string 費用單位);

    Task<double> 取得檢驗費(string 日期);
    Task<double> 取得檢驗費(string 日期, string 費用單位);
    Task<double> 取得院內檢驗費(string 日期);
}

public class 繳費Service : I繳費Service
{
    public 繳費Service(HNContext _HNContext) { }

    public async Task<List<繳費檔>> 取得拆帳字串(string 日期)
    {
        using var context = new HNContext();
        var q = await (from p in context.繳費檔
                       where
                       //p.counter == 4923751
                       p.拆帳字串 != null && p.拆帳字串 != "" && p.付款方式代碼 != "1"
                       && p.日期 == 日期 && p.經手人代號.Contains("A12364")
                       //    (p.經手人代號.Contains("A11784") || p.經手人代號.Contains("A12240") || p.經手人代號.Contains("A12364") || p.經手人代號.Contains("A11771")
                       //    || p.經手人代號.Contains("A12551") || p.經手人代號.Contains("A12433") || p.經手人代號.Contains("A0681") || p.經手人代號.Contains("A12432") || p.經手人代號.Contains("A10653"))
                       && p.註銷否 == "N"

                       select new 繳費檔
                       {
                           姓名 = p.姓名,
                           拆帳字串 = p.拆帳字串
                       }).ToListAsync();
        return q;

    }
    public async Task<List<繳費檔>> 取得拆帳字串(string 日期, string 費用單位) //從上面的總金額拆出體檢一組的檢驗費用
    {
        using var context = new HNContext();
        var q = await (from p in context.繳費檔
                       where
                       //p.counter == 4923751
                       p.拆帳字串 != null && p.拆帳字串 != "" && p.付款方式代碼 != "1"
                       && p.日期 == 日期 && (p.經手人代號.Contains("A11784") || p.經手人代號.Contains("A12240") || p.經手人代號.Contains("A12364") || p.經手人代號.Contains("A11771")
                       || p.經手人代號.Contains("A12551") || p.經手人代號.Contains("A12433") || p.經手人代號.Contains("A0681") || p.經手人代號.Contains("A12432") || p.經手人代號.Contains("A10653"))
                       && p.註銷否 == "N" && (p.醫師代號.Contains("ZZ1") || p.醫師代號.Contains("360"))
                       // A11784=魏素華 ; A12240=袁小媛 ; A12364=蕭蕙華 ; A11771=呂雅萍 ; A12551=張蘊禮 ; A12433=謝鴻豪 ; A0681=卓正玲 ; A12432=劉家蓉 ; A10653=戴詮玉
                       select new 繳費檔
                       {
                           姓名 = p.姓名,
                           拆帳字串 = p.拆帳字串
                       }).ToListAsync();
        return q;

    }

    public async Task<double> 取得檢驗費(string 日期) // for 拆帳字串是 null 的時候去統計繳費檔的實收檢驗費
    {
        using var context = new HNContext();
        var q = await (from p in context.繳費檔
                       where p.日期 == 日期

                       && p.付款方式代碼 != "1" && p.經手人代號.Contains("A12364")
                       //    && (p.經手人代號.Contains("A11784") || p.經手人代號.Contains("A12240") || p.經手人代號.Contains("A12364") || p.經手人代號.Contains("A11771")
                       //    || p.經手人代號.Contains("A12551") || p.經手人代號.Contains("A12433") || p.經手人代號.Contains("A0681") || p.經手人代號.Contains("A12432") || p.經手人代號.Contains("A10653"))
                       && p.註銷否 == "N"
                        && p.拆帳字串 == null
                       //    && p.counter == 4921007
                       select p.實收檢驗費).ToListAsync();

        if (q.FirstOrDefault() == null)
        {
            return 0;
        }
        return q.Sum();

    }

    public async Task<double> 取得檢驗費(string 日期, string 費用單位) // for 拆帳字串是 null 的時候去統計繳費檔的體檢一組檢驗費用
    {
        using var context = new HNContext();
        var q = await (from p in context.繳費檔
                       where
                       //p.counter == 4923751
                       p.日期 == 日期
                       && p.付款方式代碼 != "1"
                       && (p.經手人代號.Contains("A11784") || p.經手人代號.Contains("A12240") || p.經手人代號.Contains("A12364") || p.經手人代號.Contains("A11771")
                       || p.經手人代號.Contains("A12551") || p.經手人代號.Contains("A12433") || p.經手人代號.Contains("A0681") || p.經手人代號.Contains("A12432") || p.經手人代號.Contains("A10653"))
                       && p.註銷否 == "N" && (p.醫師代號.Contains("ZZ1") || p.醫師代號.Contains("360"))
                       // A11784=魏素華 ; A12240=袁小媛 ; A12364=蕭蕙華 ; A12551=張蘊禮 ; A12433=謝鴻豪 ; A0681=卓正玲 ; A12432=劉家蓉
                       && p.拆帳字串 == null
                       select p.實收檢驗費).ToListAsync();
        if (q.FirstOrDefault() == null)
        {
            return 0;
        }
        return q.Sum();

    }
    public async Task<double> 取得院內檢驗費(string 日期) // for 拆帳字串是 null 的時候去統計繳費檔的院內檢驗費用
    {
        using var context = new HNContext();
        var q = await (from p in context.繳費檔
                       where
                       //p.counter == 4923751
                       p.日期 == 日期
                       && p.付款方式代碼 != "1"
                       && (p.經手人代號.Contains("A11784") || p.經手人代號.Contains("A12240") || p.經手人代號.Contains("A12364") || p.經手人代號.Contains("A11771")
                       || p.經手人代號.Contains("A12551") || p.經手人代號.Contains("A12433") || p.經手人代號.Contains("A0681") || p.經手人代號.Contains("A12432") || p.經手人代號.Contains("A10653"))
                       && p.註銷否 == "N"
                       && (p.實收檢驗費 > 0 || p.實收檢查費 > 0)
                       // A11784=魏素華 ; A12240=袁小媛 ; A12364=蕭蕙華 ; A12551=張蘊禮 ; A12433=謝鴻豪 ; A0681=卓正玲 ; A12432=劉家蓉
                       select p.實收檢驗費).ToListAsync();
        if (q.FirstOrDefault() == null)
        {
            return 0;
        }
        return q.Sum();

    }


}