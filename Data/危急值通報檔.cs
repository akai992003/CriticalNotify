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
    
}