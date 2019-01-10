using Core.Data_Base;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public class EFRepository
    {
        private DataBaseContext DbContext { get; set; }

        public EFRepository()
        {
            DbContext = new DataBaseContext();
        }
        public List<Customer> SelectAll(string name)
        {
            var result = new List<Customer>();
            var query = DbContext.Customer.AsQueryable();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.客戶名稱 == name);
            }

            return query.ToList();
        }
        private void Orderby(IQueryable<Customer> query)
        {
            query.OrderBy(x => x.縣市);
        }
        public void Insert(Customer item)
        {
            DbContext.Customer.Add(item);
            DbContext.SaveChanges();
        }
        private void Update(Customer item)
        {
            var exsit = DbContext.Customer.Where(x => x.客戶編號 == item.客戶編號).SingleOrDefault();
            if (exsit == null)
            {
                return;
            }
            exsit.客戶編號 = item.客戶編號;
            exsit.客戶名稱 = item.客戶名稱;
            exsit.統一編號 = item.統一編號;
            exsit.帳單地址 = item.帳單地址;
            exsit.鄉鎮市區 = item.鄉鎮市區;
            exsit.縣市 = item.縣市;
            exsit.郵遞區號 = item.郵遞區號;
            exsit.公司電話 = item.公司電話;
            exsit.公司傳真 = item.公司傳真;
            exsit.含稅 = item.含稅;
            exsit.聯絡人 = item.聯絡人;
            exsit.聯絡人電話 = item.聯絡人電話;
            exsit.附註 = item.附註;
            DbContext.SaveChanges();
        }
        private void Delete(string In)
        {
            var exsit = DbContext.Customer.Where(x => x.客戶編號 == In).SingleOrDefault();
            if (exsit == null)
            {
                return;
            }
            DbContext.Remove(exsit);
            DbContext.SaveChanges();
        }
    }
}
