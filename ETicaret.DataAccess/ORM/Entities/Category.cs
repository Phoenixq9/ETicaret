using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.DataAccess.ORM.Entities
{
    public  class Category : Base
    {
        public int ParentId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public List<Product> Product { get; set; }
    }
}
