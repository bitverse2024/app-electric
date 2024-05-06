using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin
{
    public partial class createProvince : System.Web.UI.Page
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
            param.Add("ProvinceName", "'" + City_CityName.Value + "'");
            param.Add("ProvinceInclude", "'" + City_Include.Value + "'");



            return param;
        }


        protected void refresh()
        {
            City_CityName.Value = "";
            City_Include.Value = "";

        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if (City_CityName.Value != "")
                {
                    if (emp.InsertQueryCommon(saveParam(), "TBL_PROVINCE"))
                    {
                        cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " created PROVINCE " + City_CityName.Value,
                                "CREATE", "x123", "qwg-23", "CREATE", Session["EMP_ID"].ToString());
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Province Successfully Save !!!');", true);
                        refresh();
                    }
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
    }
}