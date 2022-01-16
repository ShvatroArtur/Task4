using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDataBase
{
    public class Client
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public virtual ICollection<SaleInfo> SaleInfos { get; set; }

            public Client()
            {
                SaleInfos = new List<SaleInfo>();
            }
    }
    
}
