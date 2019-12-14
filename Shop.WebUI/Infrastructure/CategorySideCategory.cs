using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Shop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.WebUI.Infrastructure
{
    [HtmlTargetElement("ul", Attributes = "sub_categorys")]
    public class CategorySideCategory : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;
        public CategorySideCategory(IUrlHelperFactory _urlHelperFactory)
        {
            urlHelperFactory = _urlHelperFactory;
        }
        public IEnumerable<Category> sub_Categorys { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {           
                foreach (var category in sub_Categorys)
                {
                    TagBuilder li = new TagBuilder("li");
                    li.AddCssClass("list-group-item clearfix");
                    li.InnerHtml.AppendHtml(string.Format($"<a href=\"{category.CategoryName}-c-{category.ID}\"><i class=\"fa fa-angle-right\"></i> {category.CategoryName}</a>"));
                    output.PostContent.AppendHtml(li);

                }
          
        }


    }
}
