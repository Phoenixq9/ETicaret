using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.DataAccess.ORM.Entities
{
    public class Order : Base
    {
        public int UserId { get; set; }
        public int UserAddress { get; set; }
        public int StatusId { get; set; }
        public int TotalPrice { get; set; }
        public int MyProperty { get; set; }      
        public List<OrderProduct> OrderProduct { get; set; }
        public List<Product> Product { get; set; }
        public User User { get; set; }
    }
}
