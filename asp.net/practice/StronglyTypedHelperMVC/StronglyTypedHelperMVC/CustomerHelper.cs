using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StronglyTypedHelperMVC
{
    public static class CustomerHelper
    {
        public static IHtmlString Image(string src, string alt)
        {
            return new MvcHtmlString(string.Format("<img src='{0}' alt='{1}'></img>"));
        }

        public static IHtmlString Img(this HtmlHelper helper, string src, string alt)
        {
            return new MvcHtmlString(string.Format("<img src='{0}' alt='{1}'></img>"));
        }

        public static IHtmlString ImgTag(this HtmlHelper helper, string src, string alt)
        {
            TagBuilder tagBuilder = new TagBuilder("img");
            tagBuilder.Attributes.Add("src",src);
            tagBuilder.Attributes.Add("alt",alt);
            return new MvcHtmlString(tagBuilder.ToString());
        }
    }
}