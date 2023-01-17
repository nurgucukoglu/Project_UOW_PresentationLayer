using Microsoft.EntityFrameworkCore;
using Project_UOW_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_UOW_DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-0LTDDDI\\SQLEXPRESS01;initial catalog=UnitOfWorkProjectDb;integrated security=true"); 
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<ProcessDetail> ProcessDetails { get; set; }
    }
}
