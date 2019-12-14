using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Shop.DataAccess.Abstract;
using Shop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.WebUI.Infrastructure
{
   
    [HtmlTargetElement("ul", Attributes = "category")]
    public class SideCategoryMenu : TagHelper
    {
        
        private IUrlHelperFactory urlHelperFactory;      
        public SideCategoryMenu(IUrlHelperFactory _urlHelperFactory)
        {
            
            urlHelperFactory = _urlHelperFactory;
        }
        public IEnumerable<Category> Category { get; set; }
        TagBuilder result = new TagBuilder("ul");
        string category_list="";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            Categorys(0);
            output.PreContent.AppendHtml(result.InnerHtml);

        }

        void Categorys(int id)
        {
            List<Category> AltCategory = Category.Where(x => x.SubCategory == id).ToList();
            if (AltCategory.Count() == 0)
                return;

            foreach (var menu in AltCategory)
            {
                if(menu.SubCategory==0)
                {
                    TagBuilder a = new TagBuilder("a");
                    a.InnerHtml.Append(menu.CategoryName);                    
                    category_list +=$"<li class=\"list-group-item clearfix dropdown\"><a href=\"/{menu.CategoryName}-c-{menu.ID}\"><i class=\"fa fa-angle-right\"></i> {menu.CategoryName}</a>";
                    Categorys(menu.ID);
                }
                else
                {
                    category_list += "<ul class=\"dropdown-menu\">";
                    category_list += $"<li class=\"list-group-item clearfix dropdown\"><a href=\"{menu.CategoryName}-c-{menu.ID}\" ><i class=\"fa fa-angle-right\"></i> {menu.CategoryName}</a></li></ul>";
                    Categorys(menu.ID);
                }
               
            }
            category_list += ("</li>");
            result.InnerHtml.AppendHtml(category_list);
            category_list = "";            
            

            }


        }
    }

