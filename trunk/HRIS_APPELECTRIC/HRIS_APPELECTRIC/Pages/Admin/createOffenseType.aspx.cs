using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin
{
    public partial class createOffenseType : System.Web.UI.Page
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
            param.Add("offense_key", "'" + Offense_Key.Value + "'");
            param.Add("offense_desc", "'" + Offense_Desc.Value + "'");
            param.Add("offense_detaileddesc", "'" + Offense_DescDetailed.Value + "'");
            
            return param;
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if(cm.ItemExist("TBL_OFFENSES","id","where offense_key = '"+ Offense_Key.Value+ "' or offense_desc = '"+Offense_Desc.Value+"'",""))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Offense already exist.');", true);
                    return;
                }
                if (emp.InsertQueryCommon(saveParam(), "TBL_OFFENSES"))
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " created OFFENSE TYPE " + Offense_Desc.Value,
                            "CREATE", "x123", "qwg-23", "CREATE", Session["EMP_ID"].ToString());
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Offense Successfully Save !!!');", true);
                    Offense_Desc.Value = "";
                    Offense_Key.Value = "";
                }
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Offense_Desc.Value = "";
        }
    }
}