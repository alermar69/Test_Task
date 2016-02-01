using MVC.Models;
using System;
using System.Text;
using System.Web.Mvc;

namespace MVC.HtmlHelpers
{
    public static class PageHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
                                              PageInfo pagingInfo,
                                              Func<int, string> pageUrl)
        {

            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pagingInfo.CountPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}