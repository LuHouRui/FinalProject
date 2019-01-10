using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    public class CustomerController : Controller
    {
        public class DataBaseContext : DbContext
        {
            public string ConnenctionString
            {
                get
                {
                    return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Desktop\FinalProject\Core\App_Data\MyDataBase.mdf;Integrated Security=True";
                }
            }
            public DbSet<Customer> Customer { get; set; }

            public DataBaseContext() : base() { }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(ConnenctionString);
                base.OnConfiguring(optionsBuilder);
            }
        }
        private DataBaseContext db;
        public CustomerController()
        {
            db = new DataBaseContext();
        }
        public IActionResult Index()
        {
            List<Customer> customers = db.Customer.ToList();
       
            return View(customers);
        }

        public IActionResult Search(string search)
        {
            List<Customer> customers = db.Customer.Where(x=>x.客戶名稱 == search).ToList();

            return View(customers);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = db.Customer.Find(id);
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = db.Customer.Find(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Customer model)
        {
            var UpdateModel = db.Customer.Find(model.Id);
            UpdateModel.客戶編號 = model.客戶編號;
            UpdateModel.客戶名稱 = model.客戶名稱;
            UpdateModel.統一編號 = model.統一編號;
            UpdateModel.帳單地址 = model.帳單地址;
            UpdateModel.鄉鎮市區 = model.鄉鎮市區;
            UpdateModel.縣市 = model.縣市;
            UpdateModel.郵遞區號 = model.郵遞區號;
            UpdateModel.公司電話 = model.公司電話;
            UpdateModel.公司傳真 = model.公司傳真;
            UpdateModel.含稅 = model.含稅;
            UpdateModel.聯絡人 = model.聯絡人;
            UpdateModel.聯絡人電話 = model.聯絡人電話;
            UpdateModel.附註 = model.附註;
            db.SaveChanges();
            var updated = db.Customer.Find(model.Id);
            return View(updated);
        }
    }
}