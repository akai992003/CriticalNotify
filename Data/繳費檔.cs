using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CriticalNotify.Data;

public class 繳費檔
{
    [Key]
    public Int32 counter { get; set; }
    public string 拆帳字串 { get; set; }
    public string 繳費日期 { get; set; }


}

public class dto拆帳字串
{
    public double 診察費 { get; set; }
    public double 病房費 { get; set; }
    public double 管灌膳食費 { get; set; }
    public double 檢查費 { get; set; }
    public double 放射線診療費 { get; set; }
    public double 治療處置費 { get; set; }
    public double 手術費 { get; set; }
    public double 復健治療費 { get; set; }
    public double 血液血漿費 { get; set; }
    public double 血液透析費 { get; set; }
    public double 麻醉費 { get; set; }
    public double 特殊材料費 { get; set; }
    public double 藥費 { get; set; }
    public double 藥事服務費 { get; set; }
    public double 精神科治療費 { get; set; }
    public double 注射技術費 { get; set; }
    public double 嬰兒費 { get; set; }
    public double 自定 { get; set; }
    public double 檢驗費 { get; set; }
    public double 工本費 { get; set; }
    public double 手續費 { get; set; }
}

public interface I繳費Service
{
    Task<List<string>> 取得拆帳字串(string 日期);
}

public class 繳費Service : I繳費Service
{
    public 繳費Service(HNContext _HNContext) { }

    public async Task<List<string>> 取得拆帳字串(string 日期)
    {
        using var context = new HNContext();
        var q = await (from p in context.繳費檔
                       where 
                       //p.counter == 4923751
                       p.拆帳字串 != null && p.拆帳字串 != ""
                       &&  p.繳費日期 == 日期
                        
                       select p.拆帳字串).ToListAsync();
        return q;

    }

}