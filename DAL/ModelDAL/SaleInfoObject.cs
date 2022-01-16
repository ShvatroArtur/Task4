using System;

namespace DAL.ModelDAL
{
    public class SaleInfoObject
    {
        public int Id { get; set; }
        public DateTime DateSale { get; set; }
        public int? ManagerId { get; set; }
        public int? ClientId { get; set; }
        public int? ProductId { get; set; }
    }
}
