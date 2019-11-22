using System.Collections.Generic;
using System.Linq;
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
                    return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\DcTenXen0621\Data\School\107-1-SoftWare_Engerneering\FinalProject\Core\App_Data\MyDataBase.mdf;Integrated Security=True";
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
        public IActionResult Index(string sortby)
        {
            List<Customer> customers = db.Customer.ToList();
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortby) ? "name" : "";
            ViewBag.NumberSortParm = string.IsNullOrEmpty(sortby) ? "number" : "";
            ViewBag.CitySortParm = string.IsNullOrEmpty(sortby) ? "city" : "";
            ViewBag.CountrySortParm = string.IsNullOrEmpty(sortby) ? "country" : "";
            ViewBag.MailNumSortParm = string.IsNullOrEmpty(sortby) ? "mailnum" : "";
            switch (sortby)
            {
                case "name":
                    customers = customers.OrderBy(x => x.客戶名稱).ToList();
                    break;
                case "number":
                    customers = customers.OrderBy(x => x.統一編號).ToList();
                    break;
                case "city":
                    customers = customers.OrderBy(x => x.鄉鎮市區).ToList();
                    break;
                case "country":
                    customers = customers.OrderBy(x => x.縣市).ToList();
                    break;
                case "mailnum":
                    customers = customers.OrderBy(x => x.郵遞區號).ToList();
                    break;
                default:
                    break;
            }
            return View(customers);
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Search(string search)
        {
            List<Customer> customers = db.Customer.Where(x=>x.客戶名稱 == search 
            || x.統一編號 == search || x.縣市 == search || x.鄉鎮市區 == search ||
            x.郵遞區號 == search || x.客戶編號 == search).ToList();

            return View(customers);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = db.Customer.Find(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = db.Customer.Find(id);
            
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(Customer model)
        {
            db.Customer.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index", "Customer", null);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer model)
        {
            db.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index", "Customer", null);
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