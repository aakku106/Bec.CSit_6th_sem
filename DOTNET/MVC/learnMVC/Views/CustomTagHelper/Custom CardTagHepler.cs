using Microsoft.AspNetCore.Razor.TagHelpers;


namespace learnMVC.Views.CustomCardTagHelper
{
    [HtmlTargetElement("student-card")]
    public class CustomCardTagHelper : TagHelper
    {
        [HtmlAttributeName("first-name")]
        public string? FirstName { get; set; }
        [HtmlAttributeName("last-name")]
        public string? LastName { get; set; }
        [HtmlAttributeName("class-name")]
        public string? ClassName { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "student-card");
            var htmlContent = $"<strong>FullName</strong>: {FirstName} {LastName}<br /><strong>Class:</strong> {ClassName}";
            output.Content.SetHtmlContent(htmlContent);

        }
    }
}