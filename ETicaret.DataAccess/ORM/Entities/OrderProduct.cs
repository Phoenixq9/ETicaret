using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.DataAccess.ORM.Entities
{
    public class OrderProduct : Base
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Category Category { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
