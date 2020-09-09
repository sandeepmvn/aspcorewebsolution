using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ASPCoreAppUsingMVC
{
    public static class HtmlHelperCustomExtension
    {
        public static string FormatToCurrency(this IHtmlHelper htmlHelper, decimal amount)
        {
            return string.Format("{0:c}", amount);
        }


        //public static IHtmlContent Image(this IHtmlHelper htmlHelper, string alt, string src)
        //{
        //    IHtmlContentBuilder htmlContentBuilder=new HtmlContentBuilder()
        //    //System.Web.Mvc.TagBuilder tagBuilder = new System.Web.Mvc.TagBuilder("img");
        //    //tagBuilder.MergeAttribute("alt", alt);
        //    //tagBuilder.MergeAttribute("src", src);

        //    //return System.Web.Mvc.MvcHtmlString.Create(tagBuilder.ToString(System.Web.Mvc.TagRenderMode.SelfClosing));
        //    //&lt;img alt=&#x27;this is htmlhelper image&#x27; src=&#x27;&#x27;
        //    return HttpUtility.HtmlEncode($"<img alt='{alt}' src='{src}'   />");
        //}
    }
}
