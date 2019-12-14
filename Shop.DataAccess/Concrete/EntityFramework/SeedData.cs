using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Shop.Entity;

namespace Shop.DataAccess.Concrete.EntityFramework
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {

            var context = app.ApplicationServices.GetRequiredService<EFDatabaseContext>();
            context.Database.EnsureCreated();
            if (!context.Products.Any())
            {

                var suppliers = new[]
                {
                    new Suppliers(){CompanyName="Emre LTD. ŞTİ.",ContactFName="Emre",ContactLName="UYLAŞ",ContactTitle="Patron",Address1="Manisa Soma",City="Soma",State="Manisa",PostalCode="45500",Phone="2366124547",Email="emre@gmail.com",PaymentMethods="Cart",DiscountType="Yılbaşı İndirimi",DiscountAvailable=true,CurrentOrder=true},
                      new Suppliers(){CompanyName="Volkan LTD. ŞTİ.",ContactFName="Volkan",ContactLName="SAYIN",ContactTitle="Patron",Address1="İzmir Somalı",City="Bornova",State="İzmir",PostalCode="35600",Phone="2366124547",Email="volkan@gmail.com",PaymentMethods="Cart",DiscountType="Cadılar Bayramı İndirimi",DiscountAvailable=true,CurrentOrder=true},
                       new Suppliers(){CompanyName="Yener LTD. ŞTİ.",ContactFName="Yener",ContactLName="EYŞİ",ContactTitle="Patron",Address1="İstanbul Kücük BayramSokak",City="Şişli",State="İstanbul",PostalCode="12400",Phone="2366124547",Email="yener@gmail.com",PaymentMethods="Cart",DiscountType="Ramazan Bayramı indirimi",DiscountAvailable=true,CurrentOrder=true},
                };
                context.Suppliers.AddRange(suppliers);

                var product = new[]
                {
                    new Products(){SKU="A"+(new Random()).Next(111111,999999),ProductName="Lenovo V130 Intel Core i3-7020U 12GB 240GB SSD FREEDOS 15.6\" FHD Taşınabilir Bilgisayar ",ProductDescription=" Levono Bilgisayar ",QuantityPerUnit=22,UnitPrice=3999, UnitsInStock=4, MSRP=4500,AvailableSize="40",AvailableColors="Red",UnitSize="33",Suppliers=suppliers[0], Picture="lenovov130.jpg",StockCode="SH"+new Random().Next(1111111,9999999).ToString()+DateTime.Now.ToString("dddd").Substring(0, 2).ToUpper()},

                     new Products(){SKU="A"+(new Random()).Next(111111,999999),ProductName="HP Pavilion 15-CS2003NT Intel Core i5 8265U 8GB 1TB MX130 Windows 10 Home 15.6\" FHD ",ProductDescription=" HP Bilgisayar ",QuantityPerUnit=22,UnitPrice=3599, UnitsInStock=4, MSRP=4500,AvailableSize="40",AvailableColors="Red",UnitSize="33",Suppliers=suppliers[0], Picture="hppavilion15-cS2003nt.jpg",StockCode="SH"+new Random().Next(1111111,9999999).ToString()+DateTime.Now.ToString("dddd").Substring(0, 2).ToUpper()},

                       new Products(){SKU="A"+(new Random()).Next(111111,999999),ProductName="Lenovo Tab E10 TB-X104F 32GB 10.1\" IPS Tablet Siyah",ProductDescription=" Lenovo Tablet ",QuantityPerUnit=22,UnitPrice=989, UnitsInStock=6, MSRP=4500,AvailableSize="40",AvailableColors="Red",UnitSize="33",Suppliers=suppliers[0], Picture="lenovotabe10.jpg",StockCode="SH"+new Random().Next(1111111,9999999).ToString()+DateTime.Now.ToString("dddd").Substring(0, 2).ToUpper()},

                       new Products(){SKU="A"+(new Random()).Next(111111,999999),ProductName="Apple iPad 6.Nesil 32GB 9.7\" Wi-Fi IPS Tablet",ProductDescription=" apple Tablet ",QuantityPerUnit=22,UnitPrice=2198, UnitsInStock=6, MSRP=4500,AvailableSize="40",AvailableColors="Red",UnitSize="33",Suppliers=suppliers[0], Picture="ipad6.jpg",StockCode="SH"+new Random().Next(1111111,9999999).ToString()+DateTime.Now.ToString("dddd").Substring(0, 2).ToUpper()},


                        new Products(){SKU="A"+(new Random()).Next(111111,999999),ProductName="MSI AEGIS 3 9SC-225TR Intel Core i7 9700F 16GB 1TB + 256GB SSD RTX2060 Windows 10 Home Masaüstü Bilgisayar",ProductDescription=" apple Tablet ",QuantityPerUnit=22,UnitPrice=11218, UnitsInStock=11, MSRP=4500,AvailableSize="40",AvailableColors="Red",UnitSize="33",Suppliers=suppliers[0], Picture="msiaegis3.jpg",StockCode="SH"+new Random().Next(1111111,9999999).ToString()+DateTime.Now.ToString("dddd").Substring(0, 2).ToUpper()},


                         new Products(){SKU="A"+(new Random()).Next(111111,999999),ProductName="Dark Evo G550 AMD Ryzen 5 2600 8GB 240GB SSD RX 570 Freedos Masaüstü Bilgisayar",ProductDescription=" apple Tablet ",QuantityPerUnit=22,UnitPrice=3199, UnitsInStock=6, MSRP=4500,AvailableSize="40",AvailableColors="Red",UnitSize="33",Suppliers=suppliers[0], Picture="darkevogg550.jpg",StockCode="SH"+new Random().Next(1111111,9999999).ToString()+DateTime.Now.ToString("dddd").Substring(0, 2).ToUpper()},

                    new Products(){SKU="A"+(new Random()).Next(111111,999999),ProductName="Toshiba TR200 480GB 555/540MB/s SATA3 2.5\" 3D NAND SSD",ProductDescription=" apple Tablet ",QuantityPerUnit=22,UnitPrice=352, UnitsInStock=6, MSRP=4500,AvailableSize="40",AvailableColors="Red",UnitSize="33",Suppliers=suppliers[0], Picture="toshibatr200.jpg",StockCode="SH"+new Random().Next(1111111,9999999).ToString()+DateTime.Now.ToString("dddd").Substring(0, 2).ToUpper()},

                };
                context.Products.AddRange(product);

                var category = new[]
                {
                    new Category(){ CategoryName="Bilgisayarlar",PrimaryCategory=true,SubCategory=0 },//0
                    new Category(){ CategoryName="Yazıcılar",PrimaryCategory=true,SubCategory=0},//1
                    new Category(){ CategoryName="Veri Depolama",PrimaryCategory=true,SubCategory=0},//2
                    new Category(){ CategoryName="Bilgisayar Bileşenleri",PrimaryCategory=true,SubCategory=0},//3
                    new Category(){ CategoryName="Çevre Birimleri",PrimaryCategory=true,SubCategory=0},//4
                    new Category(){ CategoryName="Ağ/Modem",PrimaryCategory=true,SubCategory=0},//5
                    new Category(){ CategoryName="Aksesuarlar",PrimaryCategory=true,SubCategory=0},//6
                    new Category(){ CategoryName="Tablet",SeconderyCategory=true,SubCategory=18},//7
                    new Category(){ CategoryName="Masaüstü Bilgisayarlar",SeconderyCategory=true,SubCategory=18},//8
                    new Category(){ CategoryName="Dizüstü Bilgisayarlar-Laptop",SeconderyCategory=true,SubCategory=18},//9
                    new Category(){ CategoryName="Monitör PC",SeconderyCategory=true,SubCategory=19},//10
                    new Category(){ CategoryName="Lazer Yazıcılar",SeconderyCategory=true,SubCategory=19},//11
                    new Category(){ CategoryName="Mürekkep Püskürtmeli Yazıcılar",SeconderyCategory=true,SubCategory=19},//12
                    new Category(){ CategoryName="Tanklı Yazıcılar",SeconderyCategory=true,SubCategory=19},//13
                    new Category(){ CategoryName="Nokta Vuruşlu Yazıcılar",SeconderyCategory=true,SubCategory=19},//14
                    new Category(){ CategoryName="Fotoğraf Yazıcıları",SeconderyCategory=true,SubCategory=19},//15
                    new Category(){ CategoryName="USB Bellek",SeconderyCategory=true,SubCategory=20},//16
                    new Category(){ CategoryName="Taşınabilir Disk",SeconderyCategory=true,SubCategory=20},//17
                    new Category(){ CategoryName="Taşınabilir SSD",SeconderyCategory=true,SubCategory=20},//18
                    new Category(){ CategoryName="Hafıza Kartları",SeconderyCategory=true,SubCategory=20},//19
                    new Category(){ CategoryName="Çoklu Depolama Ünitesi",SeconderyCategory=true,SubCategory=20},//20
                    new Category(){ CategoryName="SSD",SeconderyCategory=true,SubCategory=21},//21
                    new Category(){ CategoryName="Anakartlar",SeconderyCategory=true,SubCategory=21},//22
                    new Category(){ CategoryName="Ekran Kartları",SeconderyCategory=true,SubCategory=21},//23
                    new Category(){ CategoryName="Bellek(RAM)",SeconderyCategory=true,SubCategory=21},//24
                    new Category(){ CategoryName="İşlemciler",SeconderyCategory=true,SubCategory=21},//25
                    new Category(){ CategoryName="Hard Diskler",SeconderyCategory=true,SubCategory=21},//26
                    new Category(){ CategoryName="Bilgisayar Kasaları",SeconderyCategory=true,SubCategory=21},//27
                    new Category(){ CategoryName="Power Supply",SeconderyCategory=true,SubCategory=21},//28
                    new Category(){ CategoryName="Optik Sürücüler",SeconderyCategory=true,SubCategory=21},//29
                    new Category(){ CategoryName="Soğutucular",SeconderyCategory=true,SubCategory=21},//30
                    new Category(){ CategoryName="TV Kartları",SeconderyCategory=true,SubCategory=21},//31
                    new Category(){ CategoryName="Ses Kartları",SeconderyCategory=true,SubCategory=21},//32
                    new Category(){ CategoryName="SSD",SeconderyCategory=true,SubCategory=21},//33
                    new Category(){ CategoryName="Dijital Video İşleme",SeconderyCategory=true,SubCategory=21},//34
                };
                context.Category.AddRangeAsync(category);
                var brand = new[]
                {
                    new Brand(){BrandName="Lenovo"},//0
                    new Brand(){BrandName="Apple"},//1
                    new Brand(){BrandName="MSI"},//2
                    new Brand(){BrandName="Dark Evo"},//3
                    new Brand(){BrandName="Asus"},//4
                    new Brand(){BrandName="Toshiba"},//5
                    new Brand(){BrandName="HP"}//6

                };
                context.Brands.AddRange(brand);


                var productcategory = new[]
                {
                    new ProductCategory(){ Products=product[0],Category=category[9],Brand=brand[0], },
                    new ProductCategory(){ Products=product[1],Category=category[9],Brand=brand[6], },
                    new ProductCategory(){ Products=product[2],Category=category[7],Brand=brand[0], },
                    new ProductCategory(){ Products=product[3],Category=category[7],Brand=brand[1], },
                    new ProductCategory(){ Products=product[4],Category=category[8],Brand=brand[2], },
                    new ProductCategory(){ Products=product[5],Category=category[8],Brand=brand[3], },
                    new ProductCategory(){ Products=product[6],Category=category[21],Brand=brand[5], }

                };
                context.AddRange(productcategory);
                var Image = new[]
                {
                    new Images(){ ImageName="lenovov130.jpg",Products=product[0]},
                    new Images(){ ImageName="lenovov130_1.jpg",Products=product[0]},
                    new Images(){ ImageName="lenovov130_2.jpg",Products=product[0]},
                    new Images(){ ImageName="hppavilion15-cS2003nt.jpg",Products=product[1]},
                    new Images(){ ImageName="hppavilion15-cS2003nt_1.jpg",Products=product[1]},
                    new Images(){ ImageName="hppavilion15-cS2003nt_2.jpg",Products=product[1]},
                    new Images(){ ImageName="hppavilion15-cS2003nt.jpg_3",Products=product[1]},
                    new Images(){ ImageName="lenovotabe10.jpg",Products=product[2]},
                    new Images(){ ImageName="lenovotabe10_1.jpg",Products=product[2]},
                    new Images(){ ImageName="lenovotabe10_2.jpg",Products=product[2]},
                    new Images(){ ImageName="lenovotabe10_3.jpg",Products=product[2]},
                    new Images(){ ImageName="lenovotabe10_4.jpg",Products=product[2]},
                    new Images(){ ImageName="ipad6.jpg",Products=product[3]},
                    new Images(){ ImageName="msiaegis3.jpg",Products=product[4]},
                    new Images(){ ImageName="msiaegis3_1.jpg",Products=product[4]},
                    new Images(){ ImageName="msiaegis3_2.jpg",Products=product[4]},
                    new Images(){ ImageName="msiaegis3_3.jpg",Products=product[4]},
                    new Images(){ ImageName="darkevogg550.jpg",Products=product[5]},
                    new Images(){ ImageName="toshibatr200.jpg",Products=product[6]},
                    new Images(){ ImageName="toshibatr200_1.jpg",Products=product[6]},
                    new Images(){ ImageName="toshibatr200_2.jpg",Products=product[6]},
                };
                context.Images.AddRange(Image);


                var Information = new[]
                {
                    new ProductInformation(){ Products=product[0],Title="Ağırlık",Value="137 Gr"},
                    new ProductInformation(){ Products=product[0],Title="Dahili Hafıza",Value="16 GB"},
                    new ProductInformation(){ Products=product[0],Title="Ekran Boyutu",Value="3,5 inç"},
                    new ProductInformation(){ Products=product[0],Title="Ekran Çözünürlüğü",Value="640 x 960"},
                    new ProductInformation(){ Products=product[0],Title="Ekran Renk Çözünürlüğü",Value="16 Milyon"},
                    new ProductInformation(){ Products=product[0],Title="İşletim Sistemi",Value="iOS 4"},
                    new ProductInformation(){ Products=product[0],Title="RAM Kapasitesi",Value="512 MB RAM"},

                      new ProductInformation(){ Products=product[1],Title="Dahili Hafıza",Value="16 GB"},
                    new ProductInformation(){ Products=product[1],Title="Ekran Boyutu",Value="3,5 inç"},
                    new ProductInformation(){ Products=product[1],Title="Ekran Çözünürlüğü",Value="640 x 960"},
                    new ProductInformation(){ Products=product[1],Title="Ekran Renk Çözünürlüğü",Value="16 Milyon"},
                    new ProductInformation(){ Products=product[1],Title="İşletim Sistemi",Value="iOS 4"},
                    new ProductInformation(){ Products=product[1],Title="RAM Kapasitesi",Value="512 MB RAM"},

                     new ProductInformation(){ Products=product[2],Title="Ağırlık",Value="137 Gr"},
                    new ProductInformation(){ Products=product[2],Title="Dahili Hafıza",Value="16 GB"},
                    new ProductInformation(){ Products=product[2],Title="Ekran Boyutu",Value="3,5 inç"},
                    new ProductInformation(){ Products=product[2],Title="Ekran Çözünürlüğü",Value="640 x 960"},
                    new ProductInformation(){ Products=product[2],Title="Ekran Renk Çözünürlüğü",Value="16 Milyon"},
                    new ProductInformation(){ Products=product[2],Title="İşletim Sistemi",Value="iOS 4"},
                    new ProductInformation(){ Products=product[2],Title="RAM Kapasitesi",Value="512 MB RAM"},

                     new ProductInformation(){ Products=product[3],Title="Ağırlık",Value="137 Gr"},
                    new ProductInformation(){ Products=product[3],Title="Dahili Hafıza",Value="16 GB"},
                    new ProductInformation(){ Products=product[3],Title="Ekran Boyutu",Value="3,5 inç"},
                    new ProductInformation(){ Products=product[3],Title="Ekran Çözünürlüğü",Value="640 x 960"},
                    new ProductInformation(){ Products=product[3],Title="Ekran Renk Çözünürlüğü",Value="16 Milyon"},
                    new ProductInformation(){ Products=product[3],Title="İşletim Sistemi",Value="iOS 4"},
                    new ProductInformation(){ Products=product[3],Title="RAM Kapasitesi",Value="512 MB RAM"},

                    new ProductInformation(){ Products=product[4],Title="Ağırlık",Value="137 Gr"},
                    new ProductInformation(){ Products=product[4],Title="Dahili Hafıza",Value="16 GB"},
                    new ProductInformation(){ Products=product[4],Title="Ekran Boyutu",Value="3,5 inç"},
                    new ProductInformation(){ Products=product[4],Title="Ekran Çözünürlüğü",Value="640 x 960"},
                    new ProductInformation(){ Products=product[4],Title="Ekran Renk Çözünürlüğü",Value="16 Milyon"},
                    new ProductInformation(){ Products=product[4],Title="İşletim Sistemi",Value="iOS 4"},
                    new ProductInformation(){ Products=product[4],Title="RAM Kapasitesi",Value="512 MB RAM"},

                     new ProductInformation(){ Products=product[5],Title="Ağırlık",Value="137 Gr"},
                    new ProductInformation(){ Products=product[5],Title="Dahili Hafıza",Value="16 GB"},
                    new ProductInformation(){ Products=product[5],Title="Ekran Boyutu",Value="3,5 inç"},
                    new ProductInformation(){ Products=product[5],Title="Ekran Çözünürlüğü",Value="640 x 960"},
                    new ProductInformation(){ Products=product[5],Title="Ekran Renk Çözünürlüğü",Value="16 Milyon"},
                    new ProductInformation(){ Products=product[5],Title="İşletim Sistemi",Value="iOS 4"},
                    new ProductInformation(){ Products=product[5],Title="RAM Kapasitesi",Value="512 MB RAM"},

                     new ProductInformation(){ Products=product[6],Title="Ağırlık",Value="137 Gr"},
                    new ProductInformation(){ Products=product[6],Title="Dahili Hafıza",Value="16 GB"},
                    new ProductInformation(){ Products=product[6],Title="Ekran Boyutu",Value="3,5 inç"},
                    new ProductInformation(){ Products=product[6],Title="Ekran Çözünürlüğü",Value="640 x 960"},
                    new ProductInformation(){ Products=product[6],Title="Ekran Renk Çözünürlüğü",Value="16 Milyon"},
                    new ProductInformation(){ Products=product[6],Title="İşletim Sistemi",Value="iOS 4"},
                    new ProductInformation(){ Products=product[6],Title="RAM Kapasitesi",Value="512 MB RAM"},

                };

                context.ProductInformations.AddRange(Information);
                context.SaveChanges();
            }
        }
    }
}
