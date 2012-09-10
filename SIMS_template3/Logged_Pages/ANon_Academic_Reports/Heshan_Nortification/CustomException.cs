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
    /// Represent errors that occur during the execution.
    /// </summary>
    public class CustomException : Exception
    {
        #region Constructors
        public CustomException()
        { }
        public CustomException(string caption, string alertMessage)
        {
            this.Caption = caption;
            this.AlertMessage = alertMessage;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Caption for the message box. 
        /// </summary>
        public string Caption { get; set; }

        public string AlertMessage { get; set; }

        #endregion 
    }
}
