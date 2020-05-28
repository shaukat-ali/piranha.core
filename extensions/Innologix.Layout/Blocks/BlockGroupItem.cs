using Piranha.Extend;
using Piranha.Extend.Fields;
using System.Text.RegularExpressions;

namespace Innologix.Layouts.Blocks
{
    /// <summary>
    /// Single column HTML block.
    /// </summary>
    [BlockType(Name = "Content", Component = "html-block", IsUnlisted = true)]
    public class BlockGroupItem : Block, ISearchable
    {
        /// <summary>
        /// Gets/sets the Tile 
        /// </summary>
        public TextField Title { get; set; }

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
            return !string.IsNullOrEmpty(Body.Value) ? Body.Value : "";
        }
    }
}