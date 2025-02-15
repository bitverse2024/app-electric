﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin
{
    public partial class UpdateEmail : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Common cm = new Common();
        User dbconn = new User();
        public string empid = "";
        public string empno = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            empno = Session["ACTIVE_EMPNO"].ToString();
            if (!IsPostBack)
            {
                if (Session["EMP_ID"] != null)
                {
                    empno = Session["ACTIVE_EMPNO"].ToString();
                    //lblDisplayName2.Text = Session["USER_DISPLAY_NAME"].ToString();
                    Email.Value = cm.GetSpecificDataFromDB("email", "TBL_USERS", "where empid = '" + empno + "'");
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
            param.Add("email", "'" + Email.Value + "'");
            return param;
        }
        Dictionary<string, string> saveParam1()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("emp_Email", "'" + Email.Value + "'");
            return param;
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            empid = Session["ACTIVE_EMPNO"].ToString();
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if (cm.UpdateQueryCommon(saveParam(), "TBL_USERS", "empid = '" + empid + "'"))
                {
                    if (cm.UpdateQueryCommon(saveParam1(), "TBL_EMPLOYEE_MASTER", "emp_EmpID = '" + empid + "'"))
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Email Changed');", true);
                    }
                }
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Email.Value = "";
        }
    }
}