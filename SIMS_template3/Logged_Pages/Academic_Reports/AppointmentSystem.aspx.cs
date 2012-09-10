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
using System.Data.Odbc;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing;
using DeepASP.JQueryPromptuTest;

public partial class Logged_Pages_AParents_Reports_Parent_Info : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }



    private void addApointment()
    {
        DB_Connect.InsertQuery("INSERT INTO `appointment_principal` (`USER_NO`, `ADATE`, `ATIME_SLOT`, `NOTE`, `NAME`, `EMAIL`, `TYPE`, `PHONE`) VALUES ('555', '" + DaySelector.SelectedDate.ToShortDateString() + "', '" + ddlTimeslot.SelectedItem.Value + "', '" + txtNotes.Text.ToString() + "', '" + txtName.Text.ToString() + "', '" + txtEmail.Text.ToString() + "', '" + ddlAppointmentType.SelectedItem.Value + "', '" + txtNumber.Text.ToString() + "')");

        CustomException ex = new CustomException("Success", "Appointment Scheduled Successfully.");
        MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
        messageBox.Show(this);

        ClearInputs(Page.Controls);

    }


    protected void DateCal_SelectionChanged(object sender, EventArgs e)
    {
        DateTime dtSelectedDate = DaySelector.SelectedDate;
        txtDate.Text = String.Format("{0:yyyy-MM-dd}", dtSelectedDate);

        ddlTimeslot.Items.Clear();
        ddlTimeslot.Items.Add(new ListItem("Select Timeslot", "Empty"));

        //If No Items Selected
        //ddlTimeslot.Items.Add(new ListItem("Select Timeslot", "Empty"));
        OdbcDataAdapter adpAppointmentList = DB_Connect.ExecuteQuery("SELECT DISTINCT ATIME_SLOT FROM appointment_principal WHERE ADATE='" + DaySelector.SelectedDate.ToShortDateString() + "'");
        adpAppointmentList.SelectCommand.CommandType = CommandType.Text;
        DataSet dsAppointmentList = new DataSet();
        adpAppointmentList.Fill(dsAppointmentList);

        Boolean timeSlot1 = true;
        Boolean timeSlot2 = true;
        Boolean timeSlot3 = true;
        Boolean timeSlot4 = true;

        if (dsAppointmentList.Tables[0].Rows.Count > 0)
        {

            String timeSlot = "";

            for (int i = 0; i < dsAppointmentList.Tables[0].Rows.Count; i++)
            {
                timeSlot = dsAppointmentList.Tables[0].Rows[i][0].ToString();

                if (timeSlot.Equals("9.00 - 9.15"))
                    timeSlot1 = false;
                else if (timeSlot.Equals("9.15 - 9.30"))
                    timeSlot2 = false;
                else if (timeSlot.Equals("9.30 - 9.45"))
                    timeSlot3 = false;
                else if (timeSlot.Equals("4"))
                    timeSlot4 = false;
            }

        }

        if (timeSlot1)
        {
            ddlTimeslot.Items.Add(new ListItem("9.00 - 9.15", "9.00 - 9.15"));
        }

        if (timeSlot2)
        {
            ddlTimeslot.Items.Add(new ListItem("9.15 - 9.30", "9.15 - 9.30"));
        }

        if (timeSlot3)
        {
            ddlTimeslot.Items.Add(new ListItem("9.30 - 9.45", "9.30 - 9.45"));
        }

        if (timeSlot2)
        {
            ddlTimeslot.Items.Add(new ListItem("9.45 - 10.00", "9.45 - 10.00"));
        }


        dsAppointmentList.Dispose();
    }



    protected void btnAddAppointment_Click(object sender, EventArgs e)
    {
        addApointment();
    }

    protected void DaySelector_OnRender(object sender, DayRenderEventArgs e)
    {
        e.Day.IsSelectable = !e.Day.IsWeekend;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearInputs(Page.Controls);
    }

    private void ClearInputs(ControlCollection ctrls)
    {
        foreach (Control ctrl in ctrls)
        {
            if (ctrl is TextBox)
                ((TextBox)ctrl).Text = string.Empty;
            else if (ctrl is DropDownList)
                ((DropDownList)ctrl).ClearSelection();

            ClearInputs(ctrl.Controls);
        }
    }
}
