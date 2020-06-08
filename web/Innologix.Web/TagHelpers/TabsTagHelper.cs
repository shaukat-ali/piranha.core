using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Piranha.Extend;
using Innologix.Layouts.Blocks;

namespace Innologix.Web.TagHelpers
{
    [HtmlTargetElement("inno-tabs")]
    public class TabsTagHelper : TagHelper
    {
        public string Id { get; set; }
        public IList<Block> Items { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            StringBuilder tagsNav = new StringBuilder();
            StringBuilder tagsContent = new StringBuilder();

            for (var n = 0; n < Items.Count; n++)
            {
                var item = Items[n] as BlockGroupItem;
                tagsNav.AppendLine($@"
                    <li class=""nav-item"" role=""presentation"">
                        <a class=""nav-link {(n == 0 ? "active" : "")}"" data-toggle=""tab"" href=""#tc_{@item.Id:N}"" role=""tab"" aria-selected=""{ (n == 0 ? "true" : "false")}"">{item.Title.Value}</a>
                    </li>
                ");
                tagsContent.AppendLine($@"<div class=""tab-pane fade {(n == 0 ? "show active" : "")}"" id=""tc_{@item.Id:N}"" role=""tabpanel"">{item.Body.Value}</div>");
            }

            output.TagName = "div";
            output.Attributes.Add("class", "block block-group-tabs");
            output.Attributes.Add("id", $"tabs_{Id}");
            output.Content.SetHtmlContent($@"
                <ul class=""nav nav-tabs"" role=""tablist"">{ tagsNav }</ul>
                <div class=""tab-content"">{ tagsContent }</div>
            ");
            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}
