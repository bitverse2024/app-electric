using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin
{
    public partial class createmr : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Common cm = new Common();
        string hrmrid = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ROLES"].ToString() != "admin")
            {
                Response.Redirect("~/Pages/Login.aspx");
            }
            hrmrid = Request.QueryString["id"];
        }

        Dictionary<string, string> saveParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("hrmrid", "" + hrmrid + "");
            param.Add("DivCode", "" + cm.GetSpecificDataFromDB("DivCode", "TBL_HRMR", "where id = " + hrmrid + "") + "");
            param.Add("DeptId", "" + cm.GetSpecificDataFromDB("DeptId", "TBL_HRMR", "where id = " + hrmrid + "") + "");
            param.Add("PositionCode", "" + cm.GetSpecificDataFromDB("PositionCode", "TBL_HRMR", "where id = " + hrmrid + "") + "");
            param.Add("dateneeded", "'" + cm.FormatDate(cm.GetSpecificDataFromDB("startmonth", "TBL_HRMR", "where id = " + hrmrid + "")) + "'");
            param.Add("workexperience", "'" + Manpowerrequest_workexperience.Value + "'");
            param.Add("skills", "'" + Manpowerrequest_skills.Value + "'");
            param.Add("requestedby", "'" + emp.GetEmployeeName(Session["EMP_ID"].ToString()) + "'");
            param.Add("mr_status", "'hiring'");
            return param;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (emp.InsertQueryCommon(saveParam(), "TBL_MR"))
            {
                cm.UpdateQueryCommon("hrmr_status", "hiring", "TBL_HRMR", "id = " + hrmrid + "");
                reset();
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('MR Successfully Save !!!');", true);

            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }

        void reset()
        {
            Manpowerrequest_workexperience.Value = "";
            Manpowerrequest_skills.Value = "";
        }
    }
}