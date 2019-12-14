using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Entity
{
   public class Payment
    {
        public int ID { get; set; }
        public string PaymentType { get; set; }
        public bool Allowed { get; set; }
    }
}
