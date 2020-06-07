
using System.Text;
using Piranha.Extend;
using Piranha.Extend.Blocks;
using Piranha.Models;

namespace Innologix.Layouts.Blocks
{
    /// <summary>
    /// two column image and text block vertical aligned.
    /// </summary>
    [BlockGroupType(Name = "Image and Text (3 Column Vertical)", Category = "Layouts", Icon = "fa fa-newspaper", UseCustomView = true,
        Component = "block-grp-3col-v-image-text", SvgIcon = "/manager/assets/svg/3col_v_image_caption.svg")]
    [BlockItemType(Type = typeof(ImageAndTextBlock))]
    public class ThreeColumnVImageAndTextBlock : BlockGroup, ISearchable
    {
        public ThreeColumnVImageAndTextBlock()
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
