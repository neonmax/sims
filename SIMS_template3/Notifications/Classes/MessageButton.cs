using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace DeepASP.JQueryPromptuTest
{
    /// <summary>
    /// Button entity to display on the MessageBox.
    /// </summary>
    public class MessageButton
    {
        #region Constructors

        public MessageButton(string buttonText, string buttonName)
        {
            this.Text = buttonText;
            this.ID = buttonName;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get, Sets the Text of button.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Get, Sets the name of the button.
        /// </summary>
        public string ID { get; set; }

        #endregion

    }

}
