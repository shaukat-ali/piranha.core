/*
 * Copyright (c) .NET Foundation and Contributors
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 *
 * https://github.com/piranhacms/piranha.core
 *
 */

using Piranha.Extend;
using Piranha.Extend.Fields;

namespace Innologix.Layouts.Blocks
{
    /// <summary>
    /// Image block.
    /// </summary>
    [BlockType(Name = "Image Link", Category = "Media", Icon = "fas fa-image", Component = "image-link-block", SortOrder = 150)]
    public class ImageLinkBlock : Block
    {
        /// <summary>
        /// Gets/sets the image body.
        /// </summary>
        public ImageField Body { get; set; }

        public StringField ImageCTALink { get; set; }

        /// <summary>
        /// Gets the title of the block when used in a block group.
        /// </summary>
        /// <returns>The title</returns>
        public override string GetTitle()
        {
            if (Body != null && Body.Media != null)
            {
                return Body.Media.Filename;
            }
            return "No image selected";
        }
    }
}
