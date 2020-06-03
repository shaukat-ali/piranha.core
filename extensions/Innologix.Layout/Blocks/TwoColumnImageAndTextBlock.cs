
using System.Text;
using Piranha.Extend;
using Piranha.Extend.Blocks;
using Piranha.Models;

namespace Innologix.Layouts.Blocks
{
    /// <summary>
    /// Single column quote block.
    /// </summary>
    [BlockGroupType(Name = "Image and Text(2 Column)", Category = "Components", Icon = "fa fa-newspaper",
        SvgIcon = "2col_h_image_caption.svg", Display = BlockDisplayMode.Horizontal, CustomCss = "2col-img-text", FixedItems = 2)]
    [BlockItemType(Type = typeof(ImageAndTextBlock))]
    public class TwoColumnImageAndTextBlock : BlockGroup, ISearchable
    {
        /// <summary>
        /// Gets the content that should be indexed for searching.
        /// </summary>
        public string GetIndexedContent()
        {
            var content = new StringBuilder();

            foreach (var item in Items)
            {
                if (item is ISearchable searchItem)
                {
                    var value = searchItem.GetIndexedContent();

                    if (!string.IsNullOrEmpty(value))
                    {
                        content.AppendLine(value);
                    }
                }
            }
            return content.ToString();
        }
    }
}
