using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDataBase
{
    public class Product
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Cost { get; set; }

            public virtual ICollection<SaleInfo> SaleInfos { get; set; }

            public Product()
            {
                SaleInfos = new List<SaleInfo>();
            }

    }
}
