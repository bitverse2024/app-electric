using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin
{
    public partial class createstatus : System.Web.UI.Page
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
            param.Add("EmpStatus", "'" + EmpStatus_EmpStatus.Value + "'");
            param.Add("StatusDesc", "'" + EmpStatus_Description.Value + "'");
            param.Add("SSSRef", "'" + EmpStatus_SSSRef.Value + "'");
            param.Add("DaysPerMonth", "" + (EmpStatus_DaysPerMonth.Value == "" ? "0" : EmpStatus_DaysPerMonth.Value) + "");
            param.Add("DaysPerYear", "" + (EmpStatus_DaysPerYear.Value == "" ? "0" : EmpStatus_DaysPerYear.Value) + "");
            param.Add("MonthPerYear", "" + (EmpStatus_MonthPerYear.Value == "" ? "0" : EmpStatus_MonthPerYear.Value) + "");
            param.Add("VarRef", "'" + EmpStatus_VarRef.Value + "'");


            return param;
        }


        protected void refresh()
        {
            EmpStatus_EmpStatus.Value = "";
            EmpStatus_Description.Value = "";
            EmpStatus_SSSRef.Value = "";
            EmpStatus_DaysPerMonth.Value = "";
            EmpStatus_DaysPerYear.Value = "";
            EmpStatus_MonthPerYear.Value = "";
            EmpStatus_VarRef.Value = "";
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if (emp.InsertQueryCommon(saveParam(), "TBL_STATUS"))
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " created STATUS " + EmpStatus_Description.Value,
                                   "CREATE", "x123", "qwg-23", "CREATE", Session["EMP_ID"].ToString());
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Status Successfully Save !!!');", true);
                    refresh();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Wrong Input!');", true);
                    refresh();
                }
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            refresh();
        }
    }
}