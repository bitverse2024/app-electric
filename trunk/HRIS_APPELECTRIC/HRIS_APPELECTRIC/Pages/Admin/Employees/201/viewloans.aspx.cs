﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HRIS_APPELECTRIC.Pages.Admin.Employees._201
{
    public partial class viewloans : System.Web.UI.Page
    {
        public Employee emp = new Employee();
        public Common cm = new Common();
        public string empno = "";
        string empviewURL = "";
        public int gridtotalcount = 0;
        public string gridrangecount = "";
        public int gridtotalcountPaymentHistory = 0;
        public string gridrangecountPaymentHistory = "";
        string filedate;
        string startded;
        string loancd;
        string amt;
        string dedamt;
        string amtpd;
        string bal;
        string schedule;
        string active;
        public Dictionary<string, string> EmpInf = new Dictionary<string, string>();
        Dictionary<string, string> userinfo = new Dictionary<string, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            empno = Request.QueryString["empid"];
            try
            {
                if (Session["ROLES"].ToString() != "admin" && Session["ROLES"].ToString() != "employee")
                {
                    Session.Abandon();
                    Response.Redirect("~/Pages/Login.aspx");
                }
                else if (empno != Session["EMP_ID"].ToString() && Session["ROLES"].ToString() != "admin")
                {
                    //else if (empno != Session["ACTIVE_EMPNO"].ToString() && Session["ROLES"].ToString() != "admin")
                    //{

                    empno = Session["ACTIVE_EMPNO"].ToString();
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                    "alert",
                    "alert('Injection not allowed!!!');window.location ='viewloans.aspx?empid=" + empno + "';",
                    true);
                }
                else if (Session["ACTIVE_EMPNO"].ToString() == "")
                {
                    Session.Abandon();
                    Response.Redirect("~/Pages/Login.aspx");
                }
                else
                {
                    if (!IsPostBack)
                    {
                        refresh();
                        refreshGridPaymentHistory();
                        populateMenus();

                    }
                }
            }
            catch
            {
                Session.Abandon();
                Response.Redirect("~/Pages/Login.aspx");
            }


            //if (empno != Session["ACTIVE_EMPNO"].ToString())
            //{

            //    empno = Session["ACTIVE_EMPNO"].ToString();
            //    ScriptManager.RegisterStartupScript(this, this.GetType(),
            //    "alert",
            //    "alert('Injection not allowed!!!');window.location ='viewloans.aspx?empid=" + empno + "';",
            //    true);
            //}


        }
        public string getname()
        {
            string name = "";
            name = emp.GetEmployeeName(empno);

            return name;
        }
        protected void GridPaymentHistory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                Dictionary<string, string> LoanPaymentInfo = new Dictionary<string, string>();
                LoanPaymentInfo = cm.GetTableDict("TBL_LOANPAYMENTHISTORY", "where id = " + e.CommandArgument.ToString() + "");
                //loancd = emp.GetEmployeeLoanName(e.CommandArgument.ToString());
                emp.DeleteQuery("TBL_LOANPAYMENTHISTORY", "where id =" + e.CommandArgument.ToString() + "");
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " removed Loan Payment with LOAN ENTRY ID: " + LoanPaymentInfo["loanEntryID"] + " AND amountPaid: " + LoanPaymentInfo["amountPaid"] + " AND PreviousBalance: " + LoanPaymentInfo["beforepaymentbal"] + " AND CurrentBalance: " + LoanPaymentInfo["afterpaymentbal"] + " for " + emp.GetEmployeeName(empno), "DELETE", "x123", "qwg-23", "DELETE", Session["EMP_ID"].ToString());
                refresh();
                refreshGridPaymentHistory();
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Successfully Deleted');",
                true);

            }
        }
        protected void GridViewList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "view")
            {
                HiddenField1.Value = e.CommandArgument.ToString();
                populateUpdateField(e.CommandArgument.ToString());
                populateViewField(e.CommandArgument.ToString());
                openTransDetailsView(empno);

            }
            if (e.CommandName == "upd")
            {
                EmpInf = cm.GetTableDict("TBL_LOANENTRIES", "where id = " + e.CommandArgument.ToString() + "");
                HiddenEmpID.Value = e.CommandArgument.ToString();
                populateUpdateField(e.CommandArgument.ToString());
                openTransDetails(empno);

            }
            if (e.CommandName == "del")
            {
                loancd = emp.GetEmployeeLoanName(e.CommandArgument.ToString());
                emp.DeleteQuery("TBL_LOANENTRIES", "where id =" + e.CommandArgument.ToString() + "");
                emp.DeleteQuery("TBL_LOANPAYMENTHISTORY", "where loanEntryID =" + e.CommandArgument.ToString() + " AND EmpID = '" + empno + "'");
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " removed Loan with LOAN CODE: " + loancd + " for " + emp.GetEmployeeName(empno), "DELETE", "x123", "qwg-23", "DELETE", Session["EMP_ID"].ToString());
                refresh();
                refreshGridPaymentHistory();
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Successfully Deleted');",
                true);

            }
        }
        protected void GridViewList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewList.PageIndex = e.NewPageIndex;
            refresh();
        }
        protected void GridPaymentHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridPaymentHistory.PageIndex = e.NewPageIndex;
            refreshGridPaymentHistory();
        }
        void refresh()
        {
            DataTable dt = new DataTable();
            dt = emp.populateGridLoans(empno);
            GridViewList.DataSource = dt;
            GridViewList.DataBind();
            ViewState["EMP_GRID"] = dt;
            ViewState["SORTDR"] = null;

            summary();
        }
        void refreshGridPaymentHistory()
        {
            DataTable dt = new DataTable();
            dt = emp.populateGridPaymentHistory(empno);
            GridPaymentHistory.DataSource = dt;
            GridPaymentHistory.DataBind();
            ViewState["EMP_GRID1"] = dt;
            ViewState["SORTDR1"] = null;

            summaryPaymentHistory();
        }
        void summary()
        {
            gridtotalcount = ((DataTable)ViewState["EMP_GRID"]).Rows.Count;
            int pageIndex = GridViewList.PageIndex;
            int c = (pageIndex > 0 ? 10 * pageIndex : 0) + GridViewList.Rows.Count;
            gridrangecount = (c > 0 ? c : 0) + " - " + gridtotalcount;
        }
        void summaryPaymentHistory()
        {
            gridtotalcountPaymentHistory = ((DataTable)ViewState["EMP_GRID1"]).Rows.Count;
            int pageIndex = GridPaymentHistory.PageIndex;
            int c = (pageIndex > 0 ? 10 * pageIndex : 0) + GridPaymentHistory.Rows.Count;
            gridrangecountPaymentHistory = (c > 0 ? c : 0) + " - " + gridtotalcountPaymentHistory;
        }
        protected void sort_grid(string sort_args)
        {
            DataTable dt = (DataTable)ViewState["EMP_GRID"];
            if (dt.Rows.Count > 0)
            {
                if (Convert.ToString(ViewState["SORTDR"]) == "Asc")
                {
                    dt.DefaultView.Sort = sort_args + " Desc";
                    ViewState["SORTDR"] = "Desc";
                }
                else
                {
                    dt.DefaultView.Sort = sort_args + " Asc";
                    ViewState["SORTDR"] = "Asc";
                }

                //GridViewList.DataSource = dt;
                //GridViewList.DataBind();
                //summary();

            }

        }
        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            //awong-retrieve textbox values from the grid control during runtime.
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
            string LoanCode = ((TextBox)currentRow.FindControl("txtLoanCode")).Text;
            string DedStart = ((TextBox)currentRow.FindControl("txtDedStart")).Text;
            string LoanAmount = ((TextBox)currentRow.FindControl("txtLoanAmount")).Text;
            string AmountPaid = ((TextBox)currentRow.FindControl("txtAmountPaid")).Text;
            string Balance = ((TextBox)currentRow.FindControl("txtBalance")).Text;
            string DedAmount = ((TextBox)currentRow.FindControl("txtDedAmount")).Text;
            string expr = emp.build_or_like_param(saveSearchParam(LoanCode, DedStart, LoanAmount, AmountPaid, Balance, DedAmount));
            //string expr = "and (license_type like '%" + lictype + "%' or license_no like '%" + licno + "%' or lic_expirydate like '%" + licdate + "%')";
            //GridViewList.DataSource = emp.populateGridSearch((DataTable)ViewState["EMP_GRID"], expr);

            DataTable dt = new DataTable();
            dt = emp.populateGridLoansCol(empno, expr);
            GridViewList.DataSource = dt;
            GridViewList.DataBind();
            ViewState["EMP_GRID"] = dt;

            gridtotalcount = ((DataTable)ViewState["EMP_GRID"]).Rows.Count;
            int pageIndex = GridViewList.PageIndex;
            int c = (pageIndex > 0 ? 10 * pageIndex : 0) + GridViewList.Rows.Count;
            gridrangecount = (c > 0 ? c : 0) + " - " + gridtotalcount;
            //summary();

        }
        protected void ddlChange(object sender, EventArgs e)
        {
            GridViewRow currentRow = (GridViewRow)((DropDownList)sender).Parent.Parent;
            string a1 = ((DropDownList)currentRow.FindControl("ddlSearch")).SelectedItem.Value.ToString();
            string expr = emp.build_or_like_param(saveSearchParam1(a1));
            if (a1 == "ALL") expr = "";
            GridPaymentHistory.DataSource = emp.populateGridPaymentHistoryCol(empno,expr);
            GridPaymentHistory.DataBind();
            summary();
            summaryPaymentHistory();
        }
        Dictionary<string, string> saveSearchParam1(string a1)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("LoanID", "'%" + a1 + "%'");


            return param;


        }
        Dictionary<string, string> saveSearchParam(string LoanCode, string DedStart, string LoanAmount, string AmountPaid, string Balance, string DedAmount)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("LoanDesc", "'%" + LoanCode + "%'");
            param.Add("DedStart", "'%" + DedStart + "%'");
            param.Add("AmountOfLoan", "'%" + LoanAmount + "%'");
            param.Add("AmountPaid", "'%" + AmountPaid + "%'");
            param.Add("Balance", "'%" + Balance + "%'");
            param.Add("DedAmount", "'%" + DedAmount + "%'");


            return param;


        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                //06/28/2022 Jan Wong. Allow multiple loan applied on single loan type.
                if (cm.ItemExist("TBL_LOANENTRIES A, TBL_LOANS B", "A.id", "where A.LoanCode = B.id AND B.LoanID != 'CA' AND EmpID = '" + empno + "' AND LoanCode = '" + Loanentries_LoanCode.Value + "'"))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Loan already exist.');", true);
                    return;
                }
                if (emp.InsertQueryCommon(saveParam(), "TBL_LOANENTRIES"))
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " created Loans with LOAN CODE: " + Loanentries_LoanCode.Value + " for " + emp.GetEmployeeName(empno), "CREATE", "x123", "qwg-23", "CREATE", Session["EMP_ID"].ToString());
                    Reset();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Save !!!');", true);
                    refresh();
                    refreshGridPaymentHistory();
                }
            }


        }
        void populateMenus()
        {
            //will change id to LoanID (CL,SSS,PIL)
            upd_LoanCode.Items.AddRange(emp.GetDropDownMenuList("TBL_LOANS", "LoanDesc", "id", "ORDER BY LoanDesc ASC"));

            Loanentries_LoanCode.Items.AddRange(emp.GetDropDownMenuList("TBL_LOANS", "LoanDesc", "id", "ORDER BY LoanDesc ASC"));



        }

        Dictionary<string, string> saveParam()
        {

            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("EmpID", "'" + empno + "'");
            param.Add("DateFiled", "'" + txtLoanentries_DateFiled.Value + "'");
            param.Add("DedStart", "'" + cm.FormatDate(txtLoanentries_DedStart.Value) + "'");
            param.Add("LoanCode", "'" + Loanentries_LoanCode.Value + "'");
            param.Add("Name", "'" + Loanentries_LoanCode.Items[Loanentries_LoanCode.SelectedIndex].Text + "'");
            param.Add("LoanAmount", "" + Loanentries_LoanAmount.Value + "");
            param.Add("DedAmount", "" + Loanentries_DedAmount.Value + "");
            param.Add("AmountPaid", "" + Loanentries_AmountPaid.Value + "");
            param.Add("Balance", "" + Loanentries_Balance.Value + "");
            //param.Add("Schedule", (Loanentries_Schedule.Checked ? "'1'" : "'0'"));
            param.Add("Loan_Status", (Loanentries_Status.Checked ? "'1'" : "'0'"));
            param.Add("DedDate", DateTime.Parse((txtLoanentries_DedStart.Value)).Day.ToString());


            return param;




        }
        void Reset()
        {
            txtLoanentries_DateFiled.Value = "";
            txtLoanentries_DedStart.Value = "";
            Loanentries_LoanCode.Value = "";
            Loanentries_LoanAmount.Value = "0";
            //Loanentries_AmountOfLoan.Value = "0";
            Loanentries_DedAmount.Value = "0";
            Loanentries_AmountPaid.Value = "0";
            Loanentries_Balance.Value = "0";
            //Loanentries_Schedule.Checked = false;
            Loanentries_Status.Checked = false;



        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
            //refresh();
        }


        public void populateUpdateField(string id)
        {
            Dictionary<string, string> getDict = new Dictionary<string, string>();
            getDict = cm.GetTableDict("TBL_LOANENTRIES", "where id = " + id + "");
            upd_DateFiled.Value = cm.FormatDateyyyy(getDict["DateFiled"]);
            upd_StartDeduction.Value = cm.FormatDateyyyy(getDict["DateFiled"]);
            upd_LoanCode.Value = emp.GetEmployeeLoanName(id);
            //upd_LoanGranted.Value = cm.GetSpecificDataFromDB("LoanAmount", "TBL_LOANENTRIES", "where id = " + id + "");
            upd_LoanAmount.Value = getDict["LoanAmount"];
            upd_DeductionAmount.Value = getDict["DedAmount"];
            upd_AmountPaid.Value = getDict["AmountPaid"];
            upd_Balance.Value = getDict["Balance"];
            string sched = getDict["Schedule"];
            string acti = getDict["Loan_Status"];
            //if (sched == "Y")
            //{
            //    upd_GroupCode.Checked = true;
            //}
            if (acti == "1")
            {
                upd_Active.Checked = true;
            }
        }
        public void populateViewField(string id)
        {
            Dictionary<string, string> getDict = new Dictionary<string, string>();
            getDict = cm.GetTableDict("TBL_LOANENTRIES", "where id = " + id + "");
            view_DateFiled.Value = cm.FormatDate(getDict["DateFiled"]);
            view_StartDeduction.Value = cm.FormatDate(getDict["DedStart"]);
            view_LoanType.Value =  upd_LoanCode.Items[upd_LoanCode.SelectedIndex].Text;
            //view_LoanGranted.Value = upd_Remarks.Value;
            view_LoanAmount.Value = getDict["LoanAmount"]; 
            view_DeductionAmount.Value = getDict["DedAmount"]; 
            view_AmountPaid.Value = getDict["AmountPaid"]; 
            view_Balance.Value = getDict["Balance"];
            //view_ForDeduction.Value = cm.GetSpecificDataFromDB("Schedule", "TBL_LOANENTRIES", "where id = " + id + "");
            view_Active.Value = getDict["Loan_Status"];





        }

        public void closeTransDetails()
        {
            upListDetails.Update();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(string.Format(@"$('#{0}').modal('hide')", "listmodal"));
            sb.Append(@"</script>");

            ScriptManager.RegisterStartupScript(this, this.GetType(), "listmodal", sb.ToString(), false);

        }
        public void openTransDetails(string empNo)
        {
            upListDetails.Update();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(string.Format(@"$('#{0}').modal('show')", "listmodal"));
            sb.Append(@"</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "listmodal", sb.ToString(), false);
        }



        protected void lnkbtnXlist_Click(object sender, EventArgs e)
        {
            closeTransDetails();
        }

        Dictionary<string, string> saveUpdateParam(string DateFiled, string StartDeduction, string LoanCode, string LoanAmount, string DeductionAmount, string AmountPaid, string Balance, string Acti)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();

            param.Add("EmpID", "'" + empno + "'");
            param.Add("DateFiled", "'" + upd_DateFiled.Value + "'");
            param.Add("DedStart", "'" + cm.FormatDate(upd_StartDeduction.Value) + "'");
            param.Add("LoanCode", "'" + upd_LoanCode.Value + "'");
            param.Add("DedDate", DateTime.Parse((upd_StartDeduction.Value)).Day.ToString());
            param.Add("LoanAmount", "" + upd_LoanAmount.Value + "");
            param.Add("DedAmount", "" + upd_DeductionAmount.Value + "");
            param.Add("AmountPaid", "" + upd_AmountPaid.Value + "");
            param.Add("Balance", "" + upd_Balance.Value + "");
            //param.Add("Schedule", (upd_GroupCode.Checked ? "'1'" : "'0'"));
            param.Add("Loan_Status", (upd_Active.Checked ? "'1'" : "'0'"));
            string loanname = "";
            loanname = cm.GetSpecificDataFromDB("LoanDesc", "TBL_LOANS", "where id = " + upd_LoanCode.Value + "");
            param.Add("Name", "'" + loanname + "'");
            return param;


        }

        private void addlog()
        {
            if (filedate != upd_DateFiled.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Loan DATE FILED for " + emp.GetEmployeeName(empno) + " from " + filedate + " to " + upd_DateFiled.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (startded != upd_StartDeduction.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Loan START OF DEDUCTION for " + emp.GetEmployeeName(empno) + " from " + startded + " to " + upd_StartDeduction.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (loancd != upd_LoanCode.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Loan LOAN CODE for " + emp.GetEmployeeName(empno) + " from " + loancd + " to " + upd_LoanCode.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (amt != upd_LoanAmount.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Loan LOAN AMOUNT for " + emp.GetEmployeeName(empno) + " from " + amt + " to " + upd_LoanAmount.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (dedamt != upd_DeductionAmount.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Loan DEDUCTION AMOUNT for " + emp.GetEmployeeName(empno) + " from " + dedamt + " to " + upd_DeductionAmount.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (amtpd != upd_AmountPaid.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Loan AMOUNT PAID for " + emp.GetEmployeeName(empno) + " from " + amtpd + " to " + upd_AmountPaid.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (bal != upd_Balance.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Loan BALANCE for " + emp.GetEmployeeName(empno) + " from " + bal + " to " + upd_Balance.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            //if (schedule == "Y")
            //{
            //    if (upd_GroupCode.Checked == false)
            //    {
            //        cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Loan FOR DEDUCTION for " + emp.GetEmployeeName(empno) + " from " + schedule + " to N",
            //            "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            //    }
            //}
            //if (schedule == "N")
            //{
            //    if (upd_GroupCode.Checked == true)
            //    {
            //        cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Loan FOR DEDCUTION for " + emp.GetEmployeeName(empno) + " from " + schedule + " to Y",
            //            "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            //    }
            //}
            if (active == "Y")
            {
                if (upd_Active.Checked == false)
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Loan ACTIVE for " + emp.GetEmployeeName(empno) + " from " + active + " to N",
                        "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
                }
            }
            if (active == "N")
            {
                if (upd_Active.Checked == true)
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Loan ACTIVE for " + emp.GetEmployeeName(empno) + " from " + active + " to Y",
                        "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
                }
            }
        }

        protected void btnsaveUpdate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if (cm.ItemExist("TBL_LOANENTRIES A, TBL_LOANS B", "A.id", "where A.LoanCode = B.id AND B.LoanID != 'CA' AND EmpID = '" + empno + "' AND LoanCode = '" + upd_LoanCode.Value + "'  AND A.id != " + HiddenEmpID.Value + ""))
                    //if (cm.ItemExist("TBL_LOANENTRIES", "id", "where EmpID = '" + empno + "' AND LoanCode = '" + upd_LoanCode.Value + "' AND id != " + HiddenEmpID.Value + ""))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Loan already exist.');", true);
                    return;
                }
                Dictionary<string, string> getDict = new Dictionary<string, string>();
                getDict = cm.GetTableDict("TBL_LOANENTRIES", "where id = " + HiddenEmpID.Value + "");
                filedate = cm.FormatDate(getDict["DateFiled"]);
                startded = cm.FormatDate(getDict["DedStart"]);
                loancd = emp.GetEmployeeLoanName(HiddenEmpID.Value);
                amt = getDict["LoanAmount"];;
                dedamt = getDict["DedAmount"];
                amtpd = getDict["AmountPaid"];
                bal = getDict["Balance"];
                schedule = getDict["Schedule"]; 
                active = getDict["Loan_Status"]; 
                if (upd_LoanCode.Value != "")
                {
                    addlog();
                    if (cm.UpdateQueryCommon(saveUpdateParam(upd_DateFiled.Value, upd_StartDeduction.Value, upd_LoanCode.Value, upd_LoanAmount.Value,
                        upd_DeductionAmount.Value, upd_AmountPaid.Value, upd_Balance.Value, (upd_Active.Checked ? "'Y'" : "'N'")), "TBL_LOANENTRIES", "id = " + HiddenEmpID.Value + ""))
                    {

                        //db_Emp.updateUserInfo(HiddenEmpID.Value, txtbox_username.Text, txtbox_password.Text, (drpdwn_acctstatus.SelectedValue == "1" ? true : false));
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully updated !!!');", true);
                        closeTransDetails();
                        refresh();
                        refreshGridPaymentHistory();
                    }
                    else
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Incorrect input.');", true);


                }
                else
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Fields should not be empty !!!');", true);
            }
        }

        public void closeTransDetailsView()
        {
            upListDetails2.Update();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(string.Format(@"$('#{0}').modal('hide')", "ViewModal"));
            sb.Append(@"</script>");

            ScriptManager.RegisterStartupScript(this, this.GetType(), "ViewModal", sb.ToString(), false);

        }
        public void openTransDetailsView(string empNo)
        {
            upListDetails2.Update();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(string.Format(@"$('#{0}').modal('show')", "ViewModal"));
            sb.Append(@"</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ViewModal", sb.ToString(), false);

        }



        protected void lnkbtnXlistView_Click(object sender, EventArgs e)
        {
            closeTransDetailsView();
        }
    }
}