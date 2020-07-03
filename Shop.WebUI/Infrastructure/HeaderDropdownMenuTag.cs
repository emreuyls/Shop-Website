using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Shop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.WebUI.Infrastructure
{
    [HtmlTargetElement("ul", Attributes = "headercategory")]
    public class HeaderDropdownMenuTag : TagHelper
    {
        public IEnumerable<Category> headercategory { get; set; }
        string category_list = "";
        TagBuilder result = new TagBuilder("ul");
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            Categorys(0);
            output.PreContent.AppendHtml(result.InnerHtml);

        }

        void Categorys(int id)
        {
            List<Category> AltCategory = headercategory.Where(x => x.SubCategory == id).ToList();
            if (AltCategory.Count() == 0)
                return;
            foreach (var category in AltCategory)
            {
                if (category.SubCategory == 0)
                {

                    category_list += $"<li class=\"dropdown dropdown-megamenu\"><a href=\"/{category.CategoryName}-c-{category.ID}\" >{category.CategoryName}</a><ul class=\"dropdown-menu\"><li><div class=\"header-navigation-content\"><div class=\"row\">";
                    Categorys(category.ID);

                }
                else
                {
                    if (category.SeconderyCategory)
                    {
                        category_list += $"<div class=\"col-md-4 header-navigation-col\"><a href=\"/{category.CategoryName}-c-{category.ID}\"><h4>{category.CategoryName}</h4></a> <ul>";
                        Categorys(category.ID);
                    }
                    else
                    {
                        category_list += $"<li><a href=\"/{category.CategoryName}-c-{category.ID}\" ></a></li>";
                        Categorys(category.ID);
                    }
                    category_list += $"</ul></div>";
                }

            }
            category_list += ("</div></div></li></ul>");
            result.InnerHtml.AppendHtml(category_list);
            category_list = "";


        }
    }
}
