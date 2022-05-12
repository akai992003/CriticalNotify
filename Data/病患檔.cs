using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CriticalNotify.Data
{
    public class 病患檔
    {
        [Key]
        public int counter {get;set;}
        public string? 姓名 {get;set;}
        public string? 身份證字號 {get;set;}

    }

    public interface I病患檔Service
    {
        // Task<dtoMeetlink1> GetMeetlink1();
        // Task NewOne(dtoMeetlink2 dto);
        Task<病患檔> Get病患檔(int counter);
        Task<List<病患檔>> Get病患檔ByID(string ID);

    }

     public class 病患檔Service : I病患檔Service
    {
        public 病患檔Service(HNContext _HNContext) { }
        public async Task<病患檔> Get病患檔(int counter)
        {
            using (var context = new HNContext())
            {
                var q = await (from p in context.病患檔
                               where p.counter == counter
                               orderby p.身份證字號 descending
                               select new 病患檔
                               {
                                   counter = p.counter,
                                   姓名 = p.姓名,
                                   身份證字號 = p.身份證字號
                               }).FirstOrDefaultAsync();
                               if (q == null)
                               {
                                   return new 病患檔();
                               }
                               else
                               {
                                   return q;
                               }
            }
        }

        public async Task<List<病患檔>> Get病患檔ByID(string ID)
        {
            using (var context = new HNContext())
            {
                var q = await (from p in context.病患檔
                               where p.身份證字號 == ID
                               orderby p.身份證字號 descending
                               select new 病患檔
                               {
                                   counter = p.counter,
                                   姓名 = p.姓名,
                                   身份證字號 = p.身份證字號
                               }).ToListAsync();
                               if (q == null)
                               {
                                   return new List<病患檔>();
                               }
                               else
                               {
                                   return q;
                               }
            }
        }

        public async Task New病患檔(病患檔 dto)
        {
            
            var d = new 病患檔();
            d.身份證字號 = dto.身份證字號;
            d.姓名 = dto.姓名;
            d.counter = dto.counter;
            using (var context = new HNContext())
            {
                await context.病患檔.AddAsync(d);
                await context.SaveChangesAsync();
            }
        }


    }
}