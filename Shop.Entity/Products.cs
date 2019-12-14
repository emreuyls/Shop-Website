using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Entity
{
  public class Products
    {
        public int ID { get; set; }
        public string SKU { get; set; }
        public string SupplierProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int SupplierID { get; set; }
        public int QuantityPerUnit { get; set; }//Stok
        public string UnitSize { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal MSRP { get; set; }//üreticinin önerdiği Perakende satış fiyati
        public string AvailableSize { get; set; }
        public string AvailableColors { get; set; }
        public decimal Discount { get; set; }
        public double UnitWeight { get; set; }
        public int UnitsInStock { get; set; }
        public string StockCode { get; set; }
        public int UnitsOnOrder { get; set; }
        public bool ProductAvailable { get; set; }
        public bool DiscountAvailable { get; set; }
        public bool CurrentOrder { get; set; }
        public string Picture { get; set; }
        public int Ranking { get; set; }
        public string Note { get; set; }
        public int CategoryID { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
        public Suppliers Suppliers { get; set; }        
        public List<Images> Images { get; set; }
        public List<ProductInformation> ProductInformations { get; set; }
    }
}
