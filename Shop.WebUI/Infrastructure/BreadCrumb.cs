using Microsoft.AspNetCore.Razor.TagHelpers;
using Shop.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.WebUI.Infrastructure
{
    [HtmlTargetElement("ul",Attributes = "breadcrumb")]
    public class BreadCrumb:TagHelper
    {
        public int id { get;}
        private ICategoryRepository repository;
        public BreadCrumb(ICategoryRepository _repository)
        {
            repository = _repository;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            
        }
    }
}
