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
    /// SingleButton options on the MessageBox.
    /// </summary>
    public enum MessageBoxDefaultButtonEnum
    {
        /// <summary>
        /// OK button on the MessageBox.
        /// </summary>
        OK,

        /// <summary>
        /// CANCEL button on the MessageBox.
        /// </summary>
        CANCEL,

        /// <summary>
        /// YES button on the MessageBox.
        /// </summary>
        YES,

        /// <summary>
        /// NO button on the MessageBox.
        /// </summary>
        NO

    }
}
