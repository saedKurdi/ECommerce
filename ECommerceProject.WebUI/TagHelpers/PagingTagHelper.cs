using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
namespace ECommerceProject.WebUI.TagHelpers;
[HtmlTargetElement("product-list-pager")]
public class PagingTagHelper : TagHelper
{
    [HtmlAttributeName("page-size")]
    public int PageSize { get; set; }

    [HtmlAttributeName("page-count")]
    public int PageCount { get; set; }

    [HtmlAttributeName("current-category")]
    public int CurrentCategory { get; set; }

    [HtmlAttributeName("current-page")]
    public int CurrentPage { get; set; }

    [HtmlAttributeName("is-admin")]
    public bool IsAdmin { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "section";
        var sb = new StringBuilder();
        if (PageCount > 1)
        {
            sb.Append("<ul class='pagination'>");

            // previous page link : 
            if (CurrentPage > 1)
            {
                int previousPage = CurrentPage - 1;
                if (IsAdmin)
                {
                    sb.Append("<li>");
                    sb.AppendFormat("<a class='page-link' href='/admin/index?page={0}&category={1}'>previous</a>", previousPage, CurrentCategory);
                    sb.Append("</li>");
                }
                else
                {
                    sb.Append("<li>");
                    sb.AppendFormat("<a class='page-link' href='/product/index?page={0}&category={1}'>previous</a>", previousPage, CurrentCategory);
                    sb.Append("</li>");
                }
            }

            // next page link : 
            if (CurrentPage < PageCount)
            {
                int nextPage = CurrentPage + 1;
                if (IsAdmin)
                {
                    sb.Append("<li>");
                    sb.AppendFormat("<a class='page-link' href='/admin/index?page={0}&category={1}'>next</a>", nextPage, CurrentCategory);
                    sb.Append("</li>");
                }
                else
                {
                    sb.Append("<li>");
                    sb.AppendFormat("<a class='page-link' href='/product/index?page={0}&category={1}'>next</a>", nextPage, CurrentCategory);
                    sb.Append("</li>");
                }
            }

            // page number links : 
            for (int i = 1; i <= PageCount; i++)
            {
                sb.AppendFormat("<li class='{0}'>", (i == CurrentPage) ? "page-item active" : "page-item");
                if(IsAdmin) sb.AppendFormat("<a class='page-link' href='/admin/index?page={0}&category={1}'>{2}</a>", i, CurrentCategory, i);
                else sb.AppendFormat("<a class='page-link' href='/product/index?page={0}&category={1}'>{2}</a>", i, CurrentCategory, i);
                sb.Append("</li>");
            }

            sb.Append("</ul>");
        }
        output.Content.SetHtmlContent(sb.ToString());
    }


}
