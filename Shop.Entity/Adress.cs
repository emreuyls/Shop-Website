using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Entity
{
   public class Adress
    {
     
        public int ID { get; set; }
        public int UserID { get; set; }
        public string AdressTitle { get; set; }
        public string Names { get; set; }
        public string Phone { get; set; }
        public string Adress1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string BillingAdress { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }        
        public Customers Customers { get; set; }
    }
}
