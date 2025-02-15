﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin
{
    public partial class createlocation : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Common cm = new Common();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["ROLES"].ToString() != "admin")
                {
                    Response.Redirect("~/Pages/Login.aspx");
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
            param.Add("LocationName", "'" + Empgroup_GroupName.Value + "'");
            //param.Add("MinimumWage", "" + Empgroup_minimum.Value + "");

            return param;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if(cm.ItemExist("TBL_LOCATION","id", "where LocationName = '"+ Empgroup_GroupName.Value + "'"))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('duplicate location name is not allowed.');", true);
                    return;
                }
                if (emp.InsertQueryCommon(saveParam(), "TBL_LOCATION"))
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " created LOCATION " + Empgroup_GroupName.Value,
                                "CREATE", "x123", "qwg-23", "CREATE", Session["EMP_ID"].ToString());
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Location Successfully Save !!!');", true);
                    refresh();
                }
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Empgroup_GroupName.Value = "";
            //Empgroup_minimum.Value = "";
        }

        protected void refresh()
        {
            Empgroup_GroupName.Value = "";
            //Empgroup_minimum.Value = "";
        }
    }
}