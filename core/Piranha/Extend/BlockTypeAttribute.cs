/*
 * Copyright (c) .NET Foundation and Contributors
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 *
 * https://github.com/piranhacms/piranha.core
 *
 */

using System;

namespace Piranha.Extend
{
    [AttributeUsage(AttributeTargets.Class)]
    public class BlockTypeAttribute : Attribute
    {
        private bool _isGenericManuallySet = false;
        private bool _isGeneric = true;
        private string _component = "generic-block";

        /// <summary>
        /// Gets/sets the display name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets/sets the block category.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets/set the icon css.
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Gets/sets if the block type should only be listed
        /// where specified explicitly.
        /// </summary>
        public bool IsUnlisted { get; set; }

        /// <summary>
        /// Gets/sets if the block should use a generic model
        /// when rendered in the manager interface.
        /// </summary>
        public bool IsGeneric
        {
            get => _isGeneric;
            set
            {
                _isGeneric = value;
                _isGenericManuallySet = true;
            }
        }

        /// <summary>
        /// Gets/sets the name of the component that should be
        /// used to render the block in the manager interface.
        /// </summary>
        public string Component
        {
            get => _component;
            set
            {
                _component = value;

                if (!_isGenericManuallySet)
                {
                    _isGeneric = value == "generic-block";
                }
            }
        }

        /// <summary>
        /// Gets/Sets the order of the block
        /// </summary>
        public int SortOrder { get; set; } = 1000;

        /// <summary>
        /// Gets/set the icon svg.
        /// if svg exists it will display full icon on block selection list
        /// </summary>
        public string SvgIcon { get; set; }

        public string CustomCss { get; set; }
    }
}
