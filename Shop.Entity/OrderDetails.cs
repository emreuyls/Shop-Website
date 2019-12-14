using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Entity
{
   public class OrderDetails
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal Money { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }
        public decimal Total { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public bool Fulfilled { get; set; }
        public DateTime BillDate { get; set; }
        public DateTime ShipDate { get; set; }
        public int ShipperID { get; set; }
        public decimal Freight { get; set; }
        public decimal SalesTax { get; set; }

        public Orders Orders { get; set; }
        public Products Products { get; set; }
    }
}
