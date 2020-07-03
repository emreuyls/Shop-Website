using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.WebUI.Models
{
    public class AdressModel
    {
        public int ID { get; set; }
        [Display(Name = "Ad Soyad")]
        [Required(ErrorMessage = "{0} Doldurulmak Zorundadır")]
        [MinLength(2)]
        public string Names { get; set; }
        [Display(Name = "Adres Adı")]
        [Required(ErrorMessage = "{0} Boş Bırakılamaz")]
        [MinLength(2)]
        public string Title { get; set; }
        [Display(Name = "Adres")]
        [Required(ErrorMessage = "{0} Boş Bırakılamaz")]
        [MinLength(2)]
        public string Adress1 { get; set; }
        [Display(Name = "İlçe")]
        [Required(ErrorMessage = "{0} Boş Bırakılamaz")]
        [MinLength(2)]
        public string City { get; set; }
        [Display(Name = "İl")]
        [Required(ErrorMessage = "{0} Boş Bırakılamaz")]
        [MinLength(2)]
        public string State { get; set; }
        [Display(Name = "Telefon")]
        [Required(ErrorMessage = "{0} Boş Bırakılamaz")]
        [MinLength(2)]
        [Phone]
        public string Phone { get; set; }      
    
        public string BillingAdress { get; set; }

        public string BillingCity { get; set; }

        public string BillingState { get; set; }

        public bool BillingCheck { get; set; }
    }
}

