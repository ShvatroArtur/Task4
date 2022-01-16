using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDataBase
{
    public class SaleInfo
    {
        public int Id { get; set; }
        public DateTime DateSale { get; set; }
        public int? ManagerId { get; set; }
        public int? ClientId { get; set; }
        public int? ProductId { get; set; }
       
        public virtual Client Client { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual Product Product { get; set; }

    }
}
