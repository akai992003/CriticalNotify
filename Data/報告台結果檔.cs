using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CriticalNotify.Data
{
    public class 報告台結果檔
    {
        [Key]
        public int counter { get; set; }
        public int 病患檔_counter  { get; set; }
        public Int16 來源代碼{get;set;}
        public Int16 報告台代碼{get;set;}
        public int 來源檔_counter{get;set;}
        public string 開單日期{get;set;}
        public string 報到日期{get;set;}
        public string 報到時間{get;set;}
        public string 檢查日期{get;set;}
        public string 檢查時間{get;set;}
        public string 完成日期{get;set;}
        public string 完成時間{get;set;}
        public string 報告師代號{get;set;}
        public string 流程旗標{get;set;}
        public string 申請流水號 {get;set;}
    }
    public interface I報告台結果檔Service
    {
        Task<報告台結果檔> Get報告台結果檔(string type,int counter);
    }
     public class 報告台結果檔Service : I報告台結果檔Service
    {
        public 報告台結果檔Service(HNContext _HNContext) { }
        public async Task<報告台結果檔> Get報告台結果檔(string type,int counter)
        {
            using (var context = new HNContext())
            {
                
                var q = await (from p in context.報告台結果檔
                               where p.counter == counter
                               orderby p.病患檔_counter descending
                               select new 報告台結果檔
                               {
                                   counter = p.counter,
                                   病患檔_counter = p.病患檔_counter,
                                   來源代碼 = p.來源代碼,
                                   報告台代碼 = p.報告台代碼,
                                   來源檔_counter = p.來源檔_counter,
                                   開單日期 = p.開單日期,
                                   報到日期 = p.報到日期,
                                   報到時間 = p.報到時間,
                                   檢查日期 = p.檢查日期,
                                   檢查時間 = p.檢查時間,
                                   完成日期 = p.完成日期,
                                   完成時間 = p.完成時間,
                                   報告師代號 = p.報告師代號,
                                   流程旗標 = p.流程旗標,
                                   申請流水號 = p.申請流水號
                               }).FirstOrDefaultAsync();
                               if (q == null)
                               {
                                   return new 報告台結果檔();
                               }
                               else
                               {
                                   return q;
                               }
            }
            
        }
    }

}