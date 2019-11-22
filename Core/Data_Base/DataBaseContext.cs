using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data_Base
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
}
