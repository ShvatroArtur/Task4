﻿using System;

namespace Workers
{
    public class Journal
    {
        public string ManagerName { get; private set; }
        public DateTime SaleDate { get; private set; }
        public string ClientName { get; private set; }
        public string ProductName { get; private set; }
        public string ProductCost { get; private set; }

        public Journal(string managerName, DateTime saleDate, string clientName, string productName, string productCost)
        {
            ManagerName = managerName;
            SaleDate = saleDate;
            ClientName = clientName;
            ProductName = productName;
            ProductCost = productCost;
        }
    }
}
