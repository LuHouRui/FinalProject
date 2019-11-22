using Core.Data_Base;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    class MySqlRepository
    {
        private MysqlDataBaseContext DbContext { get; set; }

        public MySqlRepository()
        {
            DbContext = new MysqlDataBaseContext();
        }
        public List<Customer> SelectAll(string name)
        {
            var result = new List<Customer>();
            var query = DbContext.Customer.AsQueryable();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.Name == name);
            }

            return query.ToList();
        }
        private void Orderby(IQueryable<Customer> query)
        {
            query.OrderBy(x => x.City);
        }
        public void Insert(Customer item)
        {
            DbContext.Customer.Add(item);
            DbContext.SaveChanges();
        }
        private void Update(Customer item)
        {
            var exsit = DbContext.Customer.Where(x => x.Name == item.Name).SingleOrDefault();
            if (exsit == null)
            {
                return;
            }
            exsit.Name = item.Name;
            exsit.TaxId = item.TaxId;
            exsit.BillingAddress = item.BillingAddress;
            exsit.Village = item.Village;
            exsit.City = item.City;
            exsit.PostalCode = item.PostalCode;
            exsit.CompanyPhone = item.CompanyPhone;
            exsit.CompanyTax = item.CompanyTax;
            exsit.PercentFive = item.PercentFive;
            exsit.Contact = item.Contact;
            exsit.ContactPhone = item.ContactPhone;
            exsit.Description = item.Description;
            DbContext.SaveChanges();
        }
        private void Delete(int? In)
        {
            var exsit = DbContext.Customer.Where(x => x.ID == In).SingleOrDefault();
            if (exsit == null)
            {
                return;
            }
            DbContext.Remove(exsit);
            DbContext.SaveChanges();
        }
    }
}
