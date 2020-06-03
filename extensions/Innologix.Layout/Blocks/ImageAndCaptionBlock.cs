using Piranha.Extend;
using Piranha.Extend.Blocks;
using Piranha.Extend.Fields;
using System.Text;
using System.Text.RegularExpressions;

namespace Innologix.Layouts.Blocks
{
    /// <summary>
    /// Single column HTML block.
    /// </summary>
    [BlockType(Name = "Image and Text", Category = "Components", Icon = "fa fa-newspaper", Component = "image-text-block", 
        SvgIcon = "/manager/assets/svg/1col_h_Image_Caption.svg")]
    public class ImageAndTextBlock : Block, ISearchable
    {
        /// <summary>
        /// Gets/Sets the media
        /// </summary>
        public MediaField Media { get; set; }

        /// <summary>
        /// Gets/sets the title 
        /// </summary>
        public StringField Title { get; set; }

        /// <summary>
        /// Gets/sets the HTML body.
        /// </summary>
        public HtmlField Body { get; set; }

        /// <summary>
        /// Gets the title of the block when used in a block group.
        /// </summary>
        /// <returns>The title</returns>
        public override string GetTitle() => Title.GetTitle();

        /// <summary>
        /// Gets the content that should be indexed for searching.
        /// </summary>
        public string GetIndexedContent()
        {
            var content = new StringBuilder();

            if (!string.IsNullOrEmpty(Title.Value))
                content.AppendLine(Title.Value);

            if (!string.IsNullOrEmpty(Title.Value))
                content.AppendLine(Body.Value);

            return content.ToString();
        }
    }
}