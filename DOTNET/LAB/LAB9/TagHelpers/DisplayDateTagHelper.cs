using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Lab9.TagHelpers;

[HtmlTargetElement("display-date")]
public class DisplayDateTagHelper : TagHelper
{
    public DateTime Date { get; set; }
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "span";
        output.Content.SetContent(Date.ToString("MM/dd/yyyy"));
    }
}
