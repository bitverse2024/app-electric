﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin.Reports
{
    public partial class contractualprob : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Common cm = new Common();
        Timekeeping tk = new Timekeeping();
        public string empno = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            empno = Request.QueryString["empid"];
            if (Session["ROLES"].ToString() != "admin")
            {
                Response.Redirect("~/Pages/Login.aspx");
            }
            if (!IsPostBack)
            {
                refresh();
            }
        }
        private void refresh()
        {
            ddlComp.Items.AddRange(emp.GetDropDownMenuList("TBL_COMPANY", "CoName"));
            ddlComp.DataValueField = emp.GetDropDownMenuList("TBL_COMPANY", "id").ToString();
            ddlDept.Items.AddRange(emp.GetDropDownMenuList("TBL_DEPARTMENT", "DeptName"));
            ddlDept.DataValueField = emp.GetDropDownMenuList("TBL_DEPARTMENT", "id").ToString();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string stat = "";
            string company = cm.GetSpecificDataFromDB("id", "TBL_COMPANY", "where CoName = '" + ddlComp.SelectedItem.ToString() + "'");
            string department = cm.GetSpecificDataFromDB("id", "TBL_DEPARTMENT", "where DeptName = '" + ddlDept.SelectedItem.ToString() + "'");
            string comp = "D.id =" + company;
            string dept = "E.id =" + department;
            //if (ddlStat.SelectedIndex == 0)
            //{
            stat = "B.StatusDesc ='" + ddlStat.SelectedValue.ToString() + "'";
            //}
            //if (ddlStat.SelectedIndex == 1)
            //{
            //    stat = "B.StatusDesc ='4'";
            //}
            if (ddlComp.SelectedIndex != 0)
            {
                string expr = stat + " AND " + comp;
                GridActive.DataSource = emp.populategridprobcont(expr);
                GridActive.DataBind();
            }
            if (ddlDept.SelectedIndex != 0)
            {
                string expr = stat + " AND " + dept;
                GridActive.DataSource = emp.populategridprobcont(expr);
                GridActive.DataBind();
            }
            if (ddlComp.SelectedIndex != 0 && ddlDept.SelectedIndex != 0)
            {
                string expr = stat + " AND " + dept + " AND " + comp;
                GridActive.DataSource = emp.populategridprobcont(expr);
                GridActive.DataBind();
            }
            if (ddlComp.SelectedIndex == 0 && ddlDept.SelectedIndex == 0)
            {
                string expr = stat;
                GridActive.DataSource = emp.populategridprobcont(expr);
                GridActive.DataBind();
            }
        }
    }
}