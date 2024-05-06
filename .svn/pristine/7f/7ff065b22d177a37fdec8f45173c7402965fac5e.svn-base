using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin
{
    public partial class CreateSched : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Common cm = new Common();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ROLES"].ToString() != "admin")
            {
                Response.Redirect("~/Pages/Login.aspx");
            }

        }
        Dictionary<string, string> saveParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("Sched_TimeIn", "'" + Empsched_Sched_TimeIn.Value + "'");
            param.Add("Sched_TimeOut", "'" + Empsched_Sched_TimeOut.Value + "'");
            param.Add("ShiftName", "'" + Empsched_ShiftName.Value + "'");
            param.Add("Grace", "10");
            return param;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if (emp.InsertQueryCommon(saveParam(), "TBL_SCHEDULE"))
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " created SCHEDULE " + Empsched_ShiftName.Value,
                    "CREATE", "x123", "qwg-23", "CREATE", Session["EMP_ID"].ToString());
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Schedule Successfully Save !!!');", true);
                    Empsched_Sched_TimeIn.Value = "";
                    Empsched_Sched_TimeOut.Value = "";
                    Empsched_ShiftName.Value = "";
                }
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Empsched_Sched_TimeIn.Value = "";
            Empsched_Sched_TimeOut.Value = "";
            Empsched_ShiftName.Value = "";
        }
    }
}