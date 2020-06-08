using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Piranha.Extend;
using Innologix.Layouts.Blocks;

namespace Innologix.Web.TagHelpers
{
    [HtmlTargetElement("inno-accordian")]
    public class AccordianTagHelper : TagHelper
    {
        public string Id { get; set; }
        public IList<Block> Items { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            StringBuilder content = new StringBuilder();

            for (var n = 0; n < Items.Count; n++)
            {
                var item = Items[n] as BlockGroupItem;

                content.AppendLine($@"
                    <div>
                        <a class=""btn btn-link btn-block text-left"" data-toggle=""collapse"" data-target=""#item_{item.Id:N}"" aria-expanded=""{(n == 0 ? "true" : "false")}"">
                            {item.Title.Value}
                        </a>
                        <div id=""item_{item.Id:N}"" class=""collapse {(n == 0 ? "show" : "")}"" aria-labelledby=""headingOne"" data-parent=""#accordian_{Id}"">
                            {item.Body.Value}
                        </div>
                    </div>
                ");
            }

            output.TagName = "div";
            output.Attributes.Add("class", $"block block-group-accordian {(Items.Count > 0 ? "multi" : "")}");
            output.Attributes.Add("id", $"accordian_{Id}");
            output.Content.SetHtmlContent(content.ToString());
            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}
