using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Entity
{
   public class Customers
    {
        public int ID { get; set; }
        //TODO:User ID eklendi identity db den user ıd yi bura ile ilişkilendirme üzerinden 2 db ilişkisi yapılacak
        public string UserID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public bool Gender { get; set; }     
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CreditCard { get; set; }
        public string CreditCardTypeID { get; set; }
        public string CardExpMo { get; set; }
        public string CardExpYr { get; set; }

        public List<Adress> Adress { get; set; }
        public List<Orders> Orders { get; set; }
    }
}
