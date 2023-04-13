//using Microsoft.AspNetCore.Html;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using System.Security.Policy;

//namespace Bookstore.MvcUI.CustomHtmlHelpers
//{
//    public static class ModalHelper
//    {
//        public static IHtmlContent SuccessModal(this IHtmlHelper html, string title, string description, string action, string controller)
//        {
//            var modalId = Guid.NewGuid().ToString();

//            var modal = new TagBuilder("div");
//            modal.Attributes.Add("class", "modal fade");
//            modal.Attributes.Add("id", modalId);
//            modal.Attributes.Add("tabindex", "-1");
//            modal.Attributes.Add("role", "dialog");
//            modal.Attributes.Add("aria-labelledby", $"{modalId}-label");
//            modal.Attributes.Add("aria-hidden", "true");

//            var dialog = new TagBuilder("div");
//            dialog.Attributes.Add("class", "modal-dialog");
//            dialog.Attributes.Add("role", "document");

//            var content = new TagBuilder("div");
//            content.Attributes.Add("class", "modal-content");

//            var header = new TagBuilder("div");
//            header.Attributes.Add("class", "modal-header");

//            var titleTag = new TagBuilder("h5");
//            titleTag.Attributes.Add("class", "modal-title");
//            titleTag.Attributes.Add("id", $"{modalId}-label");
//            titleTag.InnerHtml.Append(title);

//            var closeButton = new TagBuilder("button");
//            closeButton.Attributes.Add("type", "button");
//            closeButton.Attributes.Add("class", "close");
//            closeButton.Attributes.Add("data-dismiss", "modal");
//            closeButton.Attributes.Add("aria-label", "Close");

//            var closeIcon = new TagBuilder("span");
//            closeIcon.Attributes.Add("aria-hidden", "true");
//            closeIcon.InnerHtml.Append("&times;");

//            closeButton.InnerHtml.AppendHtml(closeIcon);

//            header.InnerHtml.AppendHtml(titleTag);
//            header.InnerHtml.AppendHtml(closeButton);

//            var body = new TagBuilder("div");
//            body.Attributes.Add("class", "modal-body");
//            body.InnerHtml.Append(description);

//            var footer = new TagBuilder("div");
//            footer.Attributes.Add("class", "modal-footer");

//            var okButton = new TagBuilder("button");
//            okButton.Attributes.Add("type", "button");
//            okButton.Attributes.Add("class", "btn btn-primary");
//            okButton.Attributes.Add("data-dismiss", "modal");
//            okButton.InnerHtml.Append("OK");

//            footer.InnerHtml.AppendHtml(okButton);

//            content.InnerHtml.AppendHtml(header);
//            content.InnerHtml.AppendHtml(body);
//            content.InnerHtml.AppendHtml(footer);

//            dialog.InnerHtml.AppendHtml(content);
//            modal.InnerHtml.AppendHtml(dialog);

//            var script = new TagBuilder("script");
//            script.InnerHtml.AppendHtml($@"
//            $(document).ready(function() {{
//                $('#{modalId}').on('hidden.bs.modal', function () {{
//                    window.location.href = '{Url.Action(action, controller)}';
//                }});
//            }});");

//            return new HtmlContentBuilder()
//                .AppendHtml(modal)
//                .AppendHtml(script);
//        }
//    }

//}
