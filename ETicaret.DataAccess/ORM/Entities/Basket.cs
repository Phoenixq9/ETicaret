using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.DataAccess.ORM.Entities
{
    public class Basket:Base
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantitiy { get; set; }
        public List<Product> Product { get; set; }       
       // public User User { get; set; }
    }
}
