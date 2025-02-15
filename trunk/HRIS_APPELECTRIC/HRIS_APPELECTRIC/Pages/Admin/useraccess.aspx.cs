﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin
{
    public partial class useraccess : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Common cm = new Common();
        User dbconn = new User();
        public string empid = "";
        public string empno = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            empno = Session["ACTIVE_EMPNO"].ToString();
            if (Session["ROLES"].ToString() != "admin")
            {
                Response.Redirect("~/Pages/Login.aspx");
            }
            if (!IsPostBack)
            {
                if (Session["EMP_ID"] != null)
                {
                    empno = Session["ACTIVE_EMPNO"].ToString();
                    //lblDisplayName2.Text = Session["USER_DISPLAY_NAME"].ToString();
                    User_access.Value = cm.GetSpecificDataFromDB("roles", "TBL_USERS", "where empid = '" + empno + "'");
                }
            }
        }
        public string getname()
        {
            string name = "";
            name = emp.GetEmployeeName(empno);

            return name;

        }
        Dictionary<string, string> saveParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("roles", "'" + User_access.Value + "'");
            return param;
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            empid = Session["ACTIVE_EMPNO"].ToString();
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if (User_access.Value != "empty")
                {
                    if (cm.UpdateQueryCommon(saveParam(), "TBL_USERS", "empid = '" + empid + "'"))
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('User role successfully updated!');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Please select user role!');", true);
                }
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            User_access.SelectedIndex = 0;
        }
    }
}