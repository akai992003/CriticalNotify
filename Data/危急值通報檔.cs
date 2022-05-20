using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CriticalNotify.Data
{
    public class 危急值通報檔
    {
        [Key]
        public int counter { get; set; }
        public int? 結果檔_counter { get; set; }
        public int? 病患檔_counter { get; set; }
        public string? 檢查類別 { get; set; }
        public int? 來源代碼 { get; set; }
        public string? 報告台代碼 { get; set; }
        public string? 流水單號 { get; set; }
        public string? 流程旗標 { get; set; }
        public string 通報日期 { get; set; }
        public string 通報時間 { get; set; }
        public string 回覆日期 { get; set; }
        public string 回覆時間 { get; set; }
        public string? 回覆內容 { get; set; }
        public string? 通報人 { get; set; }
        public string? 回覆醫師 { get; set; }
    }
    public interface I危急值通報檔Service
    {
        // Task<dtoMeetlink1> GetMeetlink1();
        // Task NewOne(dtoMeetlink2 dto);
        Task New危急值通報檔(危急值通報檔 dto);
        Task<危急值通報檔> Get危急值通報檔ByCounter(int counter);
    }

    public class 危急值通報檔Service : I危急值通報檔Service
    {
        public 危急值通報檔Service(HNContext _HNContext) { }
        public async Task New危急值通報檔(危急值通報檔 dto)
        {

            var d = new 危急值通報檔();
            d.結果檔_counter = dto.結果檔_counter;
            d.病患檔_counter = dto.病患檔_counter;
            d.檢查類別 = dto.檢查類別;
            d.來源代碼 = dto.來源代碼;
            d.報告台代碼 = dto.報告台代碼;
            d.流水單號 = dto.流水單號;
            d.流程旗標 = dto.流程旗標;
            d.通報日期 = dto.通報日期;
            d.通報時間 = dto.通報時間;
            d.回覆日期 = dto.回覆日期;
            d.回覆時間 = dto.回覆時間;
            d.回覆內容 = dto.回覆內容;
            d.通報人 = dto.通報人;
            d.回覆醫師 = dto.回覆醫師;
            using (var context = new HNContext())
            {
                await context.hn危急值通報檔.AddAsync(d);
                await context.SaveChangesAsync();
            }
        }
        public async Task<危急值通報檔> Get危急值通報檔ByCounter(int counter)
        {
            using (var context = new HNContext())
            {
                var q = await (from p in context.hn危急值通報檔
                               where p.counter == counter
                               select new 危急值通報檔
                               {
                                   counter = p.counter,
                                   結果檔_counter = p.結果檔_counter,
                                   病患檔_counter = p.病患檔_counter,
                                   檢查類別 = p.檢查類別,
                                   來源代碼 = p.來源代碼,
                                   報告台代碼 = p.報告台代碼,
                                   流水單號 = p.流水單號,
                                   流程旗標 = p.流程旗標,
                                   通報日期 = p.通報日期,
                                   通報時間 = p.通報時間,
                                   回覆日期 = p.回覆日期,
                                   回覆時間 = p.回覆時間,
                                   回覆內容 = p.回覆內容,
                                   通報人 = p.通報人,
                                   回覆醫師 = p.回覆醫師
                               }).FirstOrDefaultAsync();
                if (q == null)
                {
                    return new 危急值通報檔();
                }
                else
                {
                    return q;
                }
            }
        }

    }


}