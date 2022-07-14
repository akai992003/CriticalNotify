using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace CriticalNotify.Data
{

    public class 人事資料檔
    {
        [Key]
        public int counter { get; set; }
        public string? 姓名 { get; set; }
        public string? 身份證字號 { get; set; }
        public string? 電話 { get; set; }
        public string? 呼叫器 { get; set; }
        public Int16 職務代碼 { get; set; }
        public string? 登錄名稱 { get; set; }
        public string? 執照號碼 { get; set; }
        public string? email帳號 { get; set; }
        public string? LineToken { get; set; }

    }
    public interface I人事資料檔Service
    {

        Task<人事資料檔> Get人事資料檔ByID(string ID);

    }

    public class 人事資料檔Service : I人事資料檔Service
    {
        public 人事資料檔Service(HNContext _HNContext) { }

        public async Task<人事資料檔> Get人事資料檔ByID(string ID)
        {
            using (var context = new HNContext())
            {
                var q人事資料檔 = await (from p in context.人事資料檔
                                    where p.身份證字號 == ID
                                    select new 人事資料檔
                                    {
                                        counter = p.counter,
                                        姓名 = p.姓名,
                                        身份證字號 = p.身份證字號,
                                        電話 = p.電話,
                                        呼叫器 = p.呼叫器,
                                        職務代碼 = p.職務代碼,
                                        登錄名稱 = p.登錄名稱,
                                        執照號碼 = p.執照號碼,
                                        email帳號 = p.email帳號,
                                        LineToken = p.LineToken
                                    }).FirstOrDefaultAsync();
                if (q人事資料檔 == null)
                {
                    return new 人事資料檔();
                }
                else
                {
                    return q人事資料檔;
                }

            }
        }



    }
}