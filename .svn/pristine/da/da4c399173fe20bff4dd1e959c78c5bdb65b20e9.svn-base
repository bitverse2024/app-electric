using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin
{
    public partial class createHoliday : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Common cm = new Common();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["ROLES"].ToString() != "admin")
                {
                    Session.Abandon();
                    Response.Redirect("~/Pages/Login.aspx");
                }
                if(!IsPostBack)
                {
                    Holiday_Location.Items.AddRange(cm.GetDropDownMenuList("TBL_LOCATION", "LocationName"));
                }
            }
            catch
            {
                Session.Abandon();
                Response.Redirect("~/Pages/Login.aspx");
            }
            
        }
        Dictionary<string, string> saveParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("Holiday", "'" + Holiday_Holiday.Value + "'");
            param.Add("HDescription", "'" + Holiday_HDescription.Value + "'");
            param.Add("HType", "'" + Holiday_Type.Value + "'");
            param.Add("HLocation", "'" + Holiday_Location.Value + "'");
            return param;
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (emp.InsertQueryCommon(saveParam(), "TBL_HOLIDAY"))
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " created HOLIDAY " + Holiday_HDescription.Value,
                               "CREATE", "x123", "qwg-23", "CREATE", Session["EMP_ID"].ToString());
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Holiday Successfully Save !!!');", true);
                    Holiday_Holiday.Value = "";
                    Holiday_HDescription.Value = "";
                    Holiday_Type.Value = "";
                    Holiday_Location.Value = "ALL";
               }
            
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Holiday_Holiday.Value = "";
            Holiday_HDescription.Value = "";
            Holiday_Type.Value = "";
            Holiday_Location.Value = "ALL";
        }
    }
}