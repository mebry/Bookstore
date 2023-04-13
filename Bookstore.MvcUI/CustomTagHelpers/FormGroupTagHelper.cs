using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Bookstore.MvcUI.CustomTagHelpers
{
    [HtmlTargetElement("form-group")]
    public class FormGroupTagHelper : TagHelper
    {
        [HtmlAttributeName("asp-for")]
        public ModelExpression? For { get; set; }

        [HtmlAttributeName("class")]
        public string? CssClass { get; set; }

        [HtmlAttributeName("readonly")]
        public bool ReadOnly { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", $"form-group {CssClass}");

            var label = new TagBuilder("label");
            label.Attributes.Add("for", For.Name);
            label.AddCssClass("control-label");
            label.InnerHtml.Append(For.Metadata.DisplayName);

            var input = new TagBuilder("input");
            input.Attributes.Add("id", For.Name);
            input.Attributes.Add("name", For.Name);
            input.Attributes.Add("type", "text");
            input.Attributes.Add("value", For.Model?.ToString());
            if (ReadOnly)
                input.Attributes.Add("readonly", "readonly");
            input.AddCssClass("form-control");

            var validation = new TagBuilder("span");
            validation.Attributes.Add("data-valmsg-for", For.Name);
            validation.AddCssClass("text-danger");

            output.Content.AppendHtml(label);
            output.Content.AppendHtml(input);
            output.Content.AppendHtml(validation);
        }
    }
}
