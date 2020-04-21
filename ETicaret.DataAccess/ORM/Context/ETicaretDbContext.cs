using ETicaret.DataAccess.ORM.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.DataAccess.ORM.Context
{
   public class ETicaretDbContext : DbContext
    {
        public ETicaretDbContext()
        {
            Database.Connection.ConnectionString = "Server = LAPTOP-LUSV6GL5\\MSSQLSERVER01; Database = ETicaret; Trusted_Connection = True";
        }
        //Database de kolon isimlerin sonuna s harfi koymasını engeller
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        DbSet<User> User { get; set; }
        DbSet<Product> Product { get; set; }
        DbSet<Category> Category { get; set; }
        DbSet<UserAddress> UserAddress { get; set; }
        DbSet<Basket> Basket { get; set; }
        DbSet<Order> Order { get; set; }
        DbSet<OrderProduct> OrderProduct { get; set; }

        public System.Data.Entity.DbSet<ETicaret.DataAccess.ORM.Entities.UserAddress> UserAddresses { get; set; }
    }
}
