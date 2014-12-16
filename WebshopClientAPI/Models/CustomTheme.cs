using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Annytab.WebshopClientAPI
{
    /// <summary>
    /// This class represents a custom theme
    /// </summary>
    public class CustomTheme
    {
        #region Variables

        public Int32 id;
        public string name;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new custom theme with default properties
        /// </summary>
        public CustomTheme()
        {
            // Set values for instance variables
            this.id = 0;
            this.name = "";

        } // End of the constructor

        #endregion

    } // End of the class

} // End of the namespace
