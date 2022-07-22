using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace CriticalNotify.Data
{
    public class 住診處置內容檔
    {
        [Key]
        public int counter { get; set; }
        public int 結果檔_counter { get; set; }
        public string 處置簡稱 { get; set; }
        public string 處置代號 { get; set; }

    }

    public interface I住診處置內容檔Service
    {
        // Task<dtoMeetlink1> GetMeetlink1();
        // Task NewOne(dtoMeetlink2 dto);
        Task<住診處置內容檔> Get住診處置內容檔Bycounter(int counter);


    }

    public class 住診處置內容檔Service : I住診處置內容檔Service
    {
        public 住診處置內容檔Service(HNContext _HNContext) { }
        public async Task<住診處置內容檔> Get住診處置內容檔Bycounter(int counter)
        {
            using (var context = new HNContext())
            {
                var q = await (from p in context.住診處置內容檔
                               where p.counter == counter
                               //    orderby p.身份證字號 descending
                               select new 住診處置內容檔
                               {
                                   counter = p.counter,
                                   結果檔_counter = p.結果檔_counter,
                                   處置簡稱 = p.處置簡稱,
                                   處置代號 = p.處置代號
                               }).FirstOrDefaultAsync();
                if (q == null)
                {
                    return new 住診處置內容檔();
                }
                else
                {
                    return q;
                }
            }
        }
    }
}