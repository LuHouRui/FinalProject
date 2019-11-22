using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data_Base
{
    public class MysqlDataBaseContext : DbContext
    {
        public string ConnenctionString
        {
            get
            {
                return "Server=localhost; Port=3306; Database=shenyi; Uid=root; Pwd=root;";
            }
        }
        public DbSet<Customer> Customer { get; set; }

        public MysqlDataBaseContext() : base() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(ConnenctionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
