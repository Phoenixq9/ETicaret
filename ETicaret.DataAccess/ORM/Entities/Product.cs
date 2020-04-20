using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.DataAccess.ORM.Entities
{
    public class Product : Base
    {
        public int CategoryId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Tax { get; set; }
        public int Stock { get; set; }
        public string IsActive { get; set; }
        public double Discount { get; set; }
        public Category Category { get; set; }
    }
}
