using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ASPCoreAppUsingMVC.CustomTagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string EmailTo { get; set; }
        const string domainName = "@deccansoft.com";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //base.Process(context, output);
            output.TagName = "a";
            output.Attributes.Add("href", $"mailto:{EmailTo}{domainName}");
            output.Content.SetContent(EmailTo+ domainName);
        }
    }
}
