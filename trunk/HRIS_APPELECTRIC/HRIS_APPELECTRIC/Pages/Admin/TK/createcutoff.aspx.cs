﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin.TK
{
    public partial class createcutoff : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Common cm = new Common();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ROLES"].ToString() == null)
            {
                Session.Clear();
                Session.Abandon();
                Response.Redirect("~/Pages/Login.aspx");
            }
            if (Session["ROLES"].ToString() != "admin")
            {
                Session.Clear();
                Session.Abandon();
                Response.Redirect("~/Pages/Login.aspx");
            }
            if (!IsPostBack)
            {
                populateMenus();
            }
        }
        Dictionary<string, string> saveParam()
        {
            string yr = "", month = "";
            Dictionary<string, string> param = new Dictionary<string, string>();
            SplitStr(monthlydt.Value, out yr, out month);
            param.Add("CODate", "'" + CODate.Value + "'");
            param.Add("COFrom", "'" + COFrom.Value + "'");
            param.Add("COTo", "'" + COTo.Value + "'");
            param.Add("CDesc", "'" + CODesc.Value + "'");
            param.Add("PayrollGroup", "" + Employee_PayrollGrpCode.Value + "");
            param.Add("creditMonth", "'" + month + "'");
            param.Add("creditWeek", "'" + creditWeek.Value + "'");
            param.Add("creditYear", "'" + yr + "'");
            param.Add("Company", "'" + CutOff_Company.Value + "'");
            return param;
        }
        void SplitStr(string strtocut, out string year, out string mnth)
        {
            char[] spearator = { '-' };
            String[] strlist = strtocut.Split(spearator);
            year = strlist[0];
            mnth = strlist[1];
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (cm.ItemExist("TBL_CUTOFF", "id", "where CDesc = '" + CODesc.Value + "'"))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Cutoff already exist.');", true);
                return;
            }
            if (emp.InsertQueryCommon(saveParam(), "TBL_CUTOFF"))
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " created CUT OFF " + CODesc.Value,
                        "CREATE", "x123", "qwg-23", "CREATE", Session["EMP_ID"].ToString());
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Save !!!');", true);
                CODate.Value = "";
                COFrom.Value = "";
                COTo.Value = "";
                CODesc.Value = "";
                Employee_PayrollGrpCode.Value = "";
                CutOff_Company.Value = "";
                return;
            }
        }
        void populateMenus()
        {
            Employee_PayrollGrpCode.Items.AddRange(emp.GetDropDownMenuList("TBL_PAYROLLGRP", "payrollgrpname"));
        }
            protected void btnReset_Click(object sender, EventArgs e)
        {
            CODate.Value = "";
            COFrom.Value = "";
            COTo.Value = "";
            CODesc.Value = "";
            Employee_PayrollGrpCode.Value = "";
            creditWeek.SelectedIndex = 0;
        }
    }
}