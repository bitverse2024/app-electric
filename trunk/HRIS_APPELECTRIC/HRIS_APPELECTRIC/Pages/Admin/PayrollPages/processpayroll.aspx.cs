﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin.PayrollPages
{
    public partial class processpayroll : System.Web.UI.Page
    {

        Payroll pr = new Payroll();
        Employee emp = new Employee();
        Common cm = new Common();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //chkIsGovDeductionDisabled.Checked = true;
                //chkIsLoanDeductionDisabled.Checked = true;
                //ddlCredDate.Items.AddRange(emp.GetDropDownMenuList("TBL_CUTOFF", "CDesc"));
                ddlCredDate.Items.AddRange(emp.GetDropDownMenuList("TBL_CUTOFF", "CDesc", "id", " ORDER by Company asc, MONTH(cofrom) asc"));
                cblLoan.Items.AddRange(emp.GetDropDownMenuList("TBL_LOANS", "LoanDesc", "id", " ORDER by LoanDesc asc"));
            }
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            

            bool IsEnableLeaveMonetization = false;//06/08/2022 Jan Wong
            bool IsfilingEnabled = true;
            bool IsLoanDeductionDisabled = false;
            bool IsGovDeductionDisabled = false;
            string GovDeductionPercentage = "";
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                //for OT
                //if (chkIsfilingEnabled.Checked)
                //{
                //    IsfilingEnabled = true;

                //}
                //if (!chkIsfilingEnabled.Checked)
                //{
                //    IsfilingEnabled = false;

                //}
                if (chkIsGovDeductionDisabled.Checked)
                {
                    IsGovDeductionDisabled = true;
                }
                if (chkIsLoanDeductionDisabled.Checked)
                {
                    IsLoanDeductionDisabled = true;
                }
                if (cblGovDeduction.SelectedValue == "1") GovDeductionPercentage = ".3";
                if (cblGovDeduction.SelectedValue == "2") GovDeductionPercentage = ".7";
                if (cbEnableLeaveMonetization.Checked) IsEnableLeaveMonetization = true;//06/08/2022 Jan Wong
                #region LOAN
                /*10/21/2021 
                 * 
                 * 
                 as per Sir Roland
                 Cut off 10th - deduction - SSS and HDMF loan
                 Cut off 25th - deduction - SSS and HDMF Calamity Loan
                 
                 */
                List<string> loanselected = new List<string>();
                for (int i = 0; i < cblLoan.Items.Count; i++)
                {
                    if (cblLoan.Items[i].Selected)
                    {
                        loanselected.Add(cblLoan.Items[i].Value);
                    }
                }
                #endregion LOAN

                System.Threading.Thread.Sleep(5000);
                if (pr.processpayrollAE(ddlCredDate.SelectedValue, ddlEmployee.SelectedValue, IsfilingEnabled, IsLoanDeductionDisabled, IsGovDeductionDisabled, GovDeductionPercentage, loanselected, IsEnableLeaveMonetization) < 0)
                {
                    reset();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Payroll Failed !!!');", true);
                }
                else
                {
                    reset();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Payroll Successful !!!');", true);
                }

            }
        }
        protected void ddlCredDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            string getPayrollGroup = cm.GetSpecificDataFromDB("PayrollGroup", "TBL_CUTOFF", "where id = " + ddlCredDate.SelectedValue + "");
            ddlEmployee.Items.Clear();
            ddlEmployee.Items.Insert(0, new ListItem("---Select Employee---", ""));
            ddlEmployee.Items.AddRange(emp.GetDropDownMenuListEmployeeWhereCutOff(getPayrollGroup));
        }
        void reset()
        {
            ddlCredDate.SelectedValue = "";
            ddlEmployee.Items.Clear();
            ddlEmployee.Items.Insert(0, new ListItem("---Select Employee---", ""));
        }



    }
}