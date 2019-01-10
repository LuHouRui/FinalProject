using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Customer
    {
        public int Id { set; get; }
        public string 客戶編號 { set; get; }
        public string 客戶名稱 { set; get; }
        public string 統一編號 { set; get; }
        public string 帳單地址 { set; get; }
        public string 鄉鎮市區 { set; get; }
        public string 縣市 { set; get; }
        public string 郵遞區號 { set; get; }
        public string 含稅 { set; get; }
        public string 聯絡人 { set; get; }
        public string 聯絡人電話 { set; get; }
        public string 公司電話 { set; get; }
        public string 公司傳真 { set; get; }
        public string 附註 { set; get; }
        public void Clear()
        {
            客戶編號 = "";
            客戶名稱 = "";
            統一編號 = "";
            帳單地址 = "";
            鄉鎮市區 = "";
            縣市 = "";
            郵遞區號 = "";
            含稅 = "";
            聯絡人 = "";
            聯絡人電話 = "";
            公司電話 = "";
            公司傳真 = "";
            附註 = "";
        }
    }
}
