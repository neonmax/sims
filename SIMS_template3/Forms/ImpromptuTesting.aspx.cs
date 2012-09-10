using System;
using System.Collections;
using System.Configuration;
using System.Data;
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
    public partial class ImpromptuTesting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
             You can caught the errors generate during the execution of the program and fisplay in a messagebox like below.
              try{}
              catch(CustomException ex)
              {PromptMessage.Show(this); }
             */
        }

        protected void btnShowImpromptu_Click(object sender, EventArgs e)
        {
            CustomException ex= new CustomException("DeepAsp MessageBox", "You have done it , good job.");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);
        }

    }
}
