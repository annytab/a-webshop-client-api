using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annytab.WebshopClientAPI
{
    /// <summary>
    /// This class represent a custom template
    /// </summary>
    public class CustomThemeTemplate
    {
        #region Variables

        public Int32 custom_theme_id;
        public string user_file_name;
        public string master_file_url;
        public string user_file_content;
        public string comment;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new custom theme template with default properties
        /// </summary>
        public CustomThemeTemplate()
        {
            // Set values for instance variables
            this.custom_theme_id = 0;
            this.user_file_name = "";
            this.master_file_url = "";
            this.user_file_content = "";
            this.comment = "";

        } // End of the constructor

        #endregion

    } // End of the class

} // End of the namespace
