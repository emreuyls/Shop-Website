using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Entity
{
   public class Orders
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int OrderNumber { get; set; }
        public int PaymentID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public int ShipperID { get; set; }
        public decimal Freight { get; set; }//Taşıma Ücreti
        public decimal SalesTax { get; set; }
        public string TransactStatus { get; set; }//Taşıma Durumu
        public string ErrLoc { get; set; }
        public string ErrMsg { get; set; }
        public bool Fulfilled { get; set; }//Tamamlandı
        public bool Deleted { get; set; }
        public decimal Paid { get; set; }
        public DateTime PaymentDate { get; set; }

        public Customers Customers { get; set; }
        public Shippers Shippers { get; set; }
        public List<Payment> Payment { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }
}
