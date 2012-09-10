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
using System.Collections.Generic;
using System.Text;

namespace DeepASP.JQueryPromptuTest
{
    /// <summary>
    /// MessageBox class responsible to set the Impromptu properties and display.
    /// <url>deepasp.wordpress.com</url>
    /// <author>Muhamad Hussain</author>
    /// </summary>
    public class MessageBox
    {
        #region Properties

        /// <summary>
        /// MessageBox Caption.
        /// </summary>
        private string Caption { get; set; }

        /// <summary>
        /// Text to display on the MessageBox.        
        /// </summary>
        private string Message { get; set; }

        /// <summary>
        /// Index of the button to focus.Invalid Index would be discarded and set Default. Default: 0.
        /// </summary>
        private int Focus { get; set; }

        /// <summary>
        /// List of buttons on the MessageBox.
        /// </summary>
        private List<MessageButton> Buttons { get; set; }

        /// <summary>
        /// A function to be called when the button is submitted. .
        /// </summary>
        private string CallBackFunction { get; set; }


        #endregion

        #region Constructors

        /// <summary>
        /// Initializes the deafult buttons with the default functions on the MessageBox.
        /// </summary>
        /// <param name="buttonType">button type to display on the MessageBox.</param>
        /// <param name="exception">CustomException object</param>
        public MessageBox(CustomException ex, MessageBoxDefaultButtonEnum buttonType)
        {
            this.Message = ex.AlertMessage;
            this.Caption = ex.Caption;
            /* you can set the event for the button funtion e.g. 
                call server side event.
                this.CallBackFunction = function(v,m,f){if(v == 'OK'){setTimeout('__doPostBack(\\'btnFake\\',\\'\\')', 0);}}
            */
            this.CallBackFunction = "null";
            SetDefaultSingleButtonSettings(buttonType);
        }

        /// <summary>
        /// Initialize the Custom buttons and their call back function.
        /// </summary>
        /// <param name="buttons">List of Buttons</param>
        /// <param name="focus">Index of the button to focus</param>
        /// <param name="callBackFunction">Javascript or JQuery function to execute on the button click.</param>
        /// <param name="exception">CustomException object thrown in the application.</param>
        public MessageBox(CustomException ex, List<MessageButton> buttons, int focusIndex, string callBackFunction)
        {
            // implement according to your requirement
        }

        #endregion

        #region Show Functions

        /// <summary>
        /// Display the prompt. with the default settings.
        /// </summary>
        public void Show(Page page)
        {
            string script = GetPromptuScript();
            ScriptManager.RegisterStartupScript(page, this.GetType(), "PromptuScript", script, true);
        }

        #endregion

        #region Pre-requisite Functions of Promptu

        /// <summary>
        /// Sets the default values of the PromptMessage.
        /// </summary>
        /// <param name="buttonType"></param>
        private void SetDefaultSingleButtonSettings(MessageBoxDefaultButtonEnum buttonType)
        {
            this.Buttons = new List<MessageButton>();
            switch (buttonType)
            {
                case MessageBoxDefaultButtonEnum.OK:
                    {
                        this.Buttons.Add(new MessageButton(MessageBoxDefaultButtonEnum.OK.ToString(), MessageBoxDefaultButtonEnum.OK.ToString()));
                        break;
                    }
                case MessageBoxDefaultButtonEnum.CANCEL:
                    {
                        this.Buttons.Add(new MessageButton("CANCEL", "CANCEL"));
                        break;
                    }
                case MessageBoxDefaultButtonEnum.YES:
                    {
                        this.Buttons.Add(new MessageButton("YES", "YES"));
                        break;
                    }
                case MessageBoxDefaultButtonEnum.NO:
                    {
                        this.Buttons.Add(new MessageButton("NO", "NO"));
                        break;
                    }
            }
            this.Focus = 0;
        }

        /// <summary>
        /// Returns the buttons script to populate on the impromptu.
        /// </summary>
        /// <returns></returns>
        private string GetButtons()
        {
            string buttons = "{";
            foreach (MessageButton btn in this.Buttons)
            {
                buttons += btn.Text + ":'" + btn.ID + "',";
            }
            buttons = buttons.Substring(0, buttons.Length - 1);
            buttons += "}";
            return buttons;
        }

        #endregion

        #region Jquery Functions

        /// <summary>
        /// Returns the javascript
        /// </summary>
        /// <returns></returns>
        private string GetPromptuScript()
        {
            this.CallBackFunction = this.CallBackFunction == null ? "null" : this.CallBackFunction;           
            return " $(document).ready(function() { ShowImpromptu('" + this.Caption + "','" + this.Message + "', " + this.GetButtons() + " ," + this.Focus + "," + this.CallBackFunction + ");});";
        }

        #endregion

    }

}