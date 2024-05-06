using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HRIS_APPELECTRIC.Pages.Admin
{
    public partial class createPayrollGroup : System.Web.UI.Page
    {
        Employee emp = new Employee();
        AdminLib admin = new AdminLib();
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
            param.Add("payrollgrpname", "'" + PayGrpName.Value + "'");
            param.Add("payrollmode", "'" + PayrollGrpMode.SelectedValue + "'");
            param.Add("grplocation", "'" + PayLocation.Value + "'");
            return param;
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string txtSearchPayClassCode = PayGrpName.Value;
            string expr = emp.build_or_like_param(true, saveSearchParam(txtSearchPayClassCode));
            DataTable dt = new DataTable();
            dt = admin.populateGridPayClassCol(expr);
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if (dt.Rows.Count == 0)
                {
                    if (emp.InsertQueryCommon(saveParam(), "TBL_PAYROLLGRP"))
                    {
                        cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " created PAY CLASS " + PayGrpName.Value,
                            "CREATE", "x123", "qwg-23", "CREATE", Session["EMP_ID"].ToString());
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Pay Class Successfully Save !!!');", true);
                        PayGrpName.Value = "";
                        PayrollGrpMode.SelectedValue = "";
                        PayLocation.Value = "";
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Pay Class Code already exist !!!');", true);
                    PayGrpName.Focus();
                }
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            
        }
        Dictionary<string, string> saveSearchParam(string txtSearchPayClassCode)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("PayClassCode", "'%" + PayGrpName.Value + "%'");

            return param;


        }
    }
}