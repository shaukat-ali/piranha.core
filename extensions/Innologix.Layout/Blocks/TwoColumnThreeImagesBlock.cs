
using System.Text;
using Piranha.Extend;
using Piranha.Extend.Blocks;
using Piranha.Models;

namespace Innologix.Layouts.Blocks
{
    /// <summary>
    /// two column image and text block horizontal aligned.
    /// </summary>
    [BlockGroupType(Name = "Three Images", Category = "Components", Icon = "fa fa-newspaper", UseCustomView = true,
        Component = "block-grp-2col-3images", SvgIcon = "/manager/assets/svg/2col_3images.svg")]
    [BlockItemType(Type = typeof(ImageBlock))]
    public class TwoColumnThreeImagesBlock : BlockGroup, ISearchable
    {
        public TwoColumnThreeImagesBlock()
        {
            ItemsOnCreate = 3;
        }

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
