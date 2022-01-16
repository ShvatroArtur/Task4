using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDataBase
{
    public class Manager
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<SaleInfo> SaleInfos { get; set; }

        public Manager()
        {
            SaleInfos = new List<SaleInfo>();
        }
    }
}
