using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace CriticalNotify.Data
{
    public class dtoDateTo危急值通報檔
    {
        public DateTime sdate { get; set; }
        public DateTime edate { get; set; }
        public string? str_date { get; set; }
        public string? end_date { get; set; }
        public string? 流程旗標 { get; set; }
        public string? 病歷號碼 { get; set; }
        public List<危急值通報檔2>? dto危急值通報檔2 { get; set; }
    }
    public class 危急值通報檔2 : 危急值通報檔
    {
        public string? 姓名 { get; set; }
        public string? 檢查結果 { get; set; }
        public string? 檢查項目 { get; set; }
        public int 來源檔_counter { get; set; }
        public string? 病歷號碼 { get; set; }
        public string? 日期字串 { get; set; }

    }
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
        public DateTime 通報日期 { get; set; }
        public string? 通報時間 { get; set; }
        public DateTime 回覆日期 { get; set; }
        public string? 回覆時間 { get; set; }
        public string? 回覆內容 { get; set; }
        public string? 通報人 { get; set; }
        public string? 回覆醫師 { get; set; }
    }
    public interface I危急值通報檔Service
    {
        Task update危急值通報檔(危急值通報檔2 dto);
        Task New危急值通報檔(危急值通報檔 dto);
        Task<危急值通報檔2> Get危急值通報檔ByCounter(int counter);
        Task<危急值通報檔2> Get危急值通報檔ByCounterJOIN(int counter);
        Task<List<危急值通報檔2>> Get危急值通報檔(DateTime sdate, DateTime edate, string 流程旗標 = "全", string 病歷號碼 = "");
    }

    public class 危急值通報檔Service : I危急值通報檔Service
    {
        public 危急值通報檔Service(HNContext _HNContext) { }
        public async Task update危急值通報檔(危急值通報檔2 dto)
        {
            using (var context = new HNContext())
            {
                var q = context.hn危急值通報檔.Find(dto.counter);
                if (q != null)
                {
                    context.hn危急值通報檔.Attach(q);
                    q.回覆內容 = dto.回覆內容;
                    q.回覆日期 = DateTime.Now;
                    q.回覆時間 = DateTime.Now.ToString("HHmm");
                    await context.SaveChangesAsync();
                }
            }
        }
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
        public async Task<危急值通報檔2> Get危急值通報檔ByCounter(int counter)
        {
            using (var context = new HNContext())
            {
                var q危急值通報檔2 = await (from p in context.hn危急值通報檔
                                      where p.counter == counter
                                      select new 危急值通報檔2
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
                                          回覆醫師 = p.回覆醫師,
                                          姓名 = "",
                                          檢查結果 = ""
                                      }).FirstOrDefaultAsync();
                if (q危急值通報檔2 == null)
                {
                    return new 危急值通報檔2();
                }
                else
                {

                    var q病患檔 = await (from p in context.病患檔
                                      where p.counter == q危急值通報檔2.病患檔_counter
                                      select new
                                      {
                                          counter = p.counter,
                                          姓名 = p.姓名
                                      }).FirstOrDefaultAsync();
                    if (q病患檔 == null)
                    {
                        return q危急值通報檔2;
                    }
                    else
                    {
                        q危急值通報檔2.姓名 = q病患檔.姓名;
                    }

                    var q報告台結果檔 = await (from p in context.報告台結果檔
                                         where p.counter == q危急值通報檔2.結果檔_counter
                                         select new
                                         {
                                             檢查結果 = p.報告內容,
                                             來源代碼 = p.來源代碼,
                                             來源檔_counter = p.來源檔_counter
                                         }).FirstOrDefaultAsync();
                    if (q報告台結果檔 == null)
                    {
                        return q危急值通報檔2;
                    }
                    else
                    {
                        q危急值通報檔2.檢查結果 = q報告台結果檔.檢查結果;

                        return q危急值通報檔2;
                    }



                }
            }
        }


        public async Task<危急值通報檔2> Get危急值通報檔ByCounterJOIN(int counter)
        {
            using (var context = new HNContext())
            {
                var q危急值通報檔2 = await (from p in context.hn危急值通報檔
                                      join p2 in context.病患檔
                                      on p.病患檔_counter equals p2.counter
                                      join p3 in context.報告台結果檔
                                      on p.結果檔_counter equals p3.counter
                                      where p.counter == counter
                                      orderby p3.完成日期 descending
                                      select new 危急值通報檔2
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
                                          回覆醫師 = p.回覆醫師,
                                          姓名 = p2.姓名,
                                          檢查結果 = p3.報告內容,
                                          來源檔_counter = p3.來源檔_counter,
                                          病歷號碼 = p2.病歷號碼
                                      }).FirstOrDefaultAsync();
                if (q危急值通報檔2 == null)
                {
                    return new 危急值通報檔2();
                }
                else
                {
                    if (q危急值通報檔2.來源代碼 == 0) //判斷來源代碼去搜尋門、住診處置內容檔來找出檢查項目名稱，呈現在頁面上。(來源代碼 0=門診 1=住院)
                    {
                        var q門診處置內容檔 = await (from p in context.門診處置內容檔
                                              where p.counter == q危急值通報檔2.來源檔_counter
                                              select new
                                              {
                                                  檢查項目 = p.處置簡稱
                                              }).FirstOrDefaultAsync();
                        q危急值通報檔2.檢查項目 = q門診處置內容檔.檢查項目;
                    }
                    else
                    {
                        var q住診處置內容檔 = await (from p in context.住診處置內容檔
                                              where p.counter == q危急值通報檔2.來源檔_counter
                                              select new
                                              {
                                                  檢查項目 = p.處置簡稱
                                              }).FirstOrDefaultAsync();
                        q危急值通報檔2.檢查項目 = q住診處置內容檔.檢查項目;
                    }
                    return q危急值通報檔2;
                }
            }
        }


        public async Task<List<危急值通報檔2>> Get危急值通報檔(DateTime sdate, DateTime edate, string 流程旗標 = "全", string 病歷號碼 = "")
        {
            using (var context = new HNContext())
            {
                var q = await (from p in context.hn危急值通報檔
                               join p2 in context.病患檔
                               on p.病患檔_counter equals p2.counter
                               join p3 in context.報告台結果檔
                               on p.結果檔_counter equals p3.counter
                               where p.通報日期 >= sdate
                               orderby p.通報日期 descending
                               select new 危急值通報檔2
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
                                   回覆醫師 = p.回覆醫師,
                                   姓名 = p2.姓名,
                                   檢查結果 = p3.報告內容,
                                   來源檔_counter = p3.來源檔_counter,
                                   病歷號碼 = p2.病歷號碼,
                                   日期字串 = p.通報日期.ToString("yyyy-MM-dd")
                               }).ToListAsync();
                if (流程旗標 != "全")
                {
                    //q = q.Where(p => p.流程旗標 == 流程旗標).ToList();

                    q = (from p in q where p.流程旗標 == 流程旗標 select p).ToList();
                }
                if (病歷號碼 != "" && 病歷號碼 != null)
                {
                    //q = q.Where(p => p.流程旗標 == 流程旗標).ToList();

                    q = (from p in q where p.病歷號碼 == 病歷號碼 select p).ToList();
                }
                return q;
            }
        }
    }
}