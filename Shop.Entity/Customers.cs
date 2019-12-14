using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Entity
{
   public class Customers
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Adress1 { get; set; }
        public string Adress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CreditCard { get; set; }
        public string CreditCardTypeID { get; set; }
        public string CardExpMo { get; set; }
        public string CardExpYr { get; set; }
        public string BillingAdress { get; set; }
        public string BillingCity { get; set; }
        public string BillingRegion { get; set; }
        public string BillingPostalCode { get; set; }
        public string BillingCountry { get; set; }
        public string ShipAdress { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public List<Orders> Orders { get; set; }
    }
}
