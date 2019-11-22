using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }
        [DisplayName("客戶名稱")]
        [Required]
        public string Name { get; set; }
        [DisplayName("統一編號")]
        public string TaxId { get; set; }
        [DisplayName("帳單地址")]
        public string BillingAddress { get; set; }
        [DisplayName("鄉鎮市區")]
        public string Village { get; set; }
        [DisplayName("縣市")]
        public string City { get; set; }
        [DisplayName("郵遞區號")]
        public string PostalCode { get; set; }
        [DisplayName("5％")]
        public string PercentFive { get; set; }
        [DisplayName("聯絡人")]
        public string Contact { get; set; }
        [DisplayName("聯絡人電話")]
        public string ContactPhone { get; set; }
        [DisplayName("公司電話")]
        public string CompanyPhone { get; set; }
        [DisplayName("公司傳真")]
        public string CompanyTax { get; set; }
        [DisplayName("附註")]
        public string Description { get; set; }
    }
}
