using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin
{
    public partial class createmovementtype : System.Web.UI.Page
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
            param.Add("MovementTypeName", "'" + MovementTypeName.Value + "'");
            param.Add("MovementClass", "'" + MovementClass.Value + "'");
            return param;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if (emp.InsertQueryCommon(saveParam(), "TBL_MOVEMENTTYPE"))
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " created MOVEMENT TYPE " + MovementTypeName.Value,
                           "CREATE", "x123", "qwg-23", "CREATE", Session["EMP_ID"].ToString());
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Movement Type Successfully Save !!!');", true);
                    refresh();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Please provide required field!');", true);
                    refresh();
                }
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            refresh();
        }

        protected void refresh()
        {
            MovementTypeName.Value = "";
            MovementClass.Value = "N";
        }
    }
}