
using System.Text;
using Piranha.Extend;
using Piranha.Models;

namespace Innologix.Layouts.Blocks
{
    /// <summary>
    /// Single column quote block.
    /// </summary>
    [BlockGroupType(Name = "Columns 2", Category = "Layouts", Icon = "fas fa-columns", IsGeneric = false)]
    public class Column2Block : BlockGroup, ISearchable
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
