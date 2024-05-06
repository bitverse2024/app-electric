using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin
{
    public partial class createCourse : System.Web.UI.Page
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
            param.Add("CourseName", "'" + Course_CourseName.Value + "'");
            return param;
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if (emp.InsertQueryCommon(saveParam(), "TBL_COURSE"))
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " created COURSE " + Course_CourseName.Value,
                            "CREATE", "x123", "qwg-23", "CREATE", Session["EMP_ID"].ToString());
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Course Successfully Save !!!');", true);
                    Course_CourseName.Value = "";
                }
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Course_CourseName.Value = "";
        }
    }
}