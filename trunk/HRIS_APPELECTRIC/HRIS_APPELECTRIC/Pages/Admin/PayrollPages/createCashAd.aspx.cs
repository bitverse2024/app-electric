using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin.PayrollPages
{
    public partial class createCashAd : System.Web.UI.Page
    {
        public string empno = "";
        Employee emp = new Employee();
        Common cm = new Common();
        protected void Page_Load(object sender, EventArgs e)
        {
            empno = Request.QueryString["empid"];
            if (!IsPostBack)
            {
                ddlCutoff.Items.AddRange(emp.GetDropDownMenuList("TBL_CUTOFF", "CDesc"));
                clearfield();


            }
        }
        

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if (!cm.ItemExist("TBL_CASHADVANCE", "id", "where EmpID = '" + empno + "'", ""))
                {

                    if (emp.InsertQueryCommon(saveParam(), "TBL_CASHADVANCE"))
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Save !!!');", true);
                        clearfield();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Invalid Input !!!');", true);
                        clearfield();
                    }


                }
                else
                {
                    if (cm.UpdateQueryCommon(saveParam(), "TBL_CASHADVANCE", " EmpID = '" + empno + "'"))
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Updated !!!');", true);
                        
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Invalid Input !!!');", true);
                        clearfield();

                    }

                }
            }

        }
        void clearfield()
        {
            ddlCutoff.SelectedValue = "";
            txtCashAd.Value = "";
            txtLoanBal.Value = "";
            
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            clearfield();



        }
        Dictionary<string, string> saveParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("EmpID", "'" + empno + "'");
            param.Add("CutOffID", "" + ddlCutoff.SelectedValue + "");
            if(txtCashAd.Value != "")
            {
                param.Add("CashAdvance", "" + txtCashAd.Value + "");
            }
            if (txtLoanBal.Value != "")
            {
                param.Add("LoanBalance", "" + txtLoanBal.Value + "");
            }
            
            
            return param;
        }
    }
}