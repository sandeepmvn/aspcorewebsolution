using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ASPCoreAppUsingMVC.CustomTagHelpers
{
    [HtmlTargetElement("appreciated",TagStructure = TagStructure.NormalOrSelfClosing)]
    public class AppreciateTagHelper:TagHelper
    {
        public string PersonNameForAppreciation { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // base.Process(context, output);
            output.TagName = "p";
            var appreciateMsg = "Great Work!" + ", " + PersonNameForAppreciation;
            output.Content.SetContent(appreciateMsg);
        }

    }
}
