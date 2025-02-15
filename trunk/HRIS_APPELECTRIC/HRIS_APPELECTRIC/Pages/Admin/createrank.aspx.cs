﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin
{
    public partial class createrank : System.Web.UI.Page
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
            param.Add("RankName", "'" + Rank_RankName.Value + "'");
            param.Add("RankDesc", "'" + Rank_RankDesc.Value + "'");
            param.Add("GracePeriod", "" + (Rank_GracePeriod.Value == "" ? "0" : Rank_GracePeriod.Value) + "");
            param.Add("allowance1", "" + (Rank_allowance1.Value == "" ? "0" : Rank_allowance1.Value) + "");
            param.Add("allowance2", "" + (Rank_allowance2.Value == "" ? "0" : Rank_allowance2.Value) + "");
            param.Add("RankStatus", "'Y'");
            if (Rank_Ot.Checked == true)
            {
                param.Add("Ot", "'1'");
            }
            else
            {
                param.Add("Ot", "'0'");
            }
            return param;
        }


        protected void refresh()
        {
            Rank_Ot.Checked = false;
            Rank_RankName.Value = "";
            Rank_RankDesc.Value = "";
            Rank_GracePeriod.Value = "";
            Rank_allowance1.Value = "";
            Rank_allowance2.Value = "";
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if (emp.InsertQueryCommon(saveParam(), "TBL_RANK"))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Rank Successfully Save !!!');", true);
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " created RANK " + Rank_RankName.Value,
                           "CREATE", "x123", "qwg-23", "CREATE", Session["EMP_ID"].ToString());
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