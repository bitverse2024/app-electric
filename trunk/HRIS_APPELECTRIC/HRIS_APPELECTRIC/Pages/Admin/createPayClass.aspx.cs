using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HRIS_APPELECTRIC.Pages.Admin
{
    public partial class createPayClass : System.Web.UI.Page
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
            param.Add("PayClassCode", "'" + PayClassCode.Value + "'");
            param.Add("PayClassName", "'" + PayClassDesc.Value + "'");
            param.Add("Level", "'" + PayClassLevel.Value + "'");
            return param;
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string txtSearchPayClassCode = PayClassCode.Value;
            string expr = emp.build_or_like_param(true, saveSearchParam(txtSearchPayClassCode));
            DataTable dt = new DataTable();
            dt = admin.populateGridPayClassCol(expr);
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if (dt.Rows.Count == 0)
                {
                    if (emp.InsertQueryCommon(saveParam(), "TBL_PAYCLASS"))
                    {
                        cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " created PAY CLASS " + PayClassDesc.Value,
                            "CREATE", "x123", "qwg-23", "CREATE", Session["EMP_ID"].ToString());
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Pay Class Successfully Save !!!');", true);
                        PayClassCode.Value = "";
                        PayClassDesc.Value = "";
                        PayClassLevel.Value = "";
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Pay Class Code already exist !!!');", true);
                    PayClassCode.Focus();
                }
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            PayClassCode.Value = "";
            PayClassDesc.Value = "";
            PayClassLevel.Value = "";
        }
        Dictionary<string, string> saveSearchParam(string txtSearchPayClassCode)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("PayClassCode", "'%" + PayClassCode.Value + "%'");

            return param;


        }
    }
}