﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HRIS_APPELECTRIC.Pages.Admin.TK
{
    public partial class viewleavesapp : System.Web.UI.Page
    {
        Employee emp = new Employee();
        AdminLib adl = new AdminLib();
        Timekeeping tk = new Timekeeping();
        Common cm = new Common();
        public string empno = "";
        string empviewURL = "";
        public int gridtotalcount = 0;
        public string gridrangecount = "";
        string getdfrom, getdto, getleavehrs, getampm, getleave, getreason,
            mon, tues, wed, thurs, fri, sat, sun, getdays, getstat, getrem, getused, getfiledate;
        DateTime date1, date2; int total;
        string getallowedadmin, getremadmin, getactadmin, getexpadmin, getdaysadmin, getusedadmin,getleaveadmin;
        public Dictionary<string, string> empInfo = new Dictionary<string, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            ResetLeaveCredit();
            empno = Request.QueryString["id"];
            //if (empno != Session["ACTIVE_EMPNO"].ToString())
            //{

            //    empno = Session["ACTIVE_EMPNO"].ToString();
            //    ScriptManager.RegisterStartupScript(this, this.GetType(),
            //    "alert",
            //    "alert('Injection not allowed!!!');window.location ='viewobt.aspx?id=" + empno + "';",
            //    true);
            //}
            empInfo = emp.GetEmployeeInfoDict(empno);
            if (!IsPostBack)
            {
                upd_leavetype.Items.AddRange(emp.GetDropDownMenuList("TBL_LEAVETYPE", "LeaveTypeDesc"));
                Leavesapp_LeaveType.Items.AddRange(emp.GetDropDownMenuList("TBL_LEAVETYPE", "LeaveTypeDesc"));
                refresh();
            }
        }
        //06/27/2022 Jan Wong. Automatic reset of leave credit
        void ResetLeaveCredit()
        {
            Dictionary<string, string> dictIDs = new Dictionary<string, string>();
            dictIDs = adl.getLeaveIDs();
            foreach (KeyValuePair<string, string> leaveids in dictIDs)
            {
                Dictionary<string, string> getleaveDict = new Dictionary<string, string>();
                Dictionary<string, string> saveUpdateParam = new Dictionary<string, string>();
                Dictionary<string, string> saveLeaveToPayParam = new Dictionary<string, string>();
                getleaveDict = cm.GetTableDict("TBL_LEAVES", "where id = " + leaveids.Key + "");
                double getempleavecredit = 0;
                double.TryParse(cm.GetSpecificDataFromDB("LeaveCreditPerYear", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + getleaveDict["EmpID"] + "'"), out getempleavecredit);
                double leavebalance = 0;
                double.TryParse(getleaveDict["Remaining"], out leavebalance);
                DateTime dtNewExpiryDate = new DateTime();
                DateTime.TryParse(leaveids.Value, out dtNewExpiryDate);
                DateTime dtOldExpiryDate = new DateTime();
                DateTime.TryParse(getleaveDict["Expiry"], out dtOldExpiryDate);
                //dtRegDate = dtRegDate.AddYears(-1);// Jan Wong. Add -1 because Leaveids.Value is already have additional year from previous function. (getLeaveIDs)
                if (leavebalance <= 0)
                    continue;
                bool isLeaveToPayExist = cm.ItemExist("TBL_LEAVETOPAY", "id", "where EmpID = '" + getleaveDict["EmpID"] + "' AND creditYear = '" + dtOldExpiryDate.Year.ToString() + "' AND LeaveID = '" + leaveids.Key + "'");
                if (isLeaveToPayExist)
                    continue;
                if (getempleavecredit == 0)
                    continue;
                saveUpdateParam.Add("Allowed", "" + getempleavecredit.ToString() + "");
                saveUpdateParam.Add("Remaining", "" + getempleavecredit.ToString() + "");
                saveUpdateParam.Add("Used", "0");
                saveUpdateParam.Add("Expiry", "'" + cm.FormatDate(dtNewExpiryDate) + "'");
                saveLeaveToPayParam.Add("EmpID", "'" + getleaveDict["EmpID"] + "'");
                saveLeaveToPayParam.Add("LeaveBalance", "" + leavebalance + "");
                saveLeaveToPayParam.Add("creditYear", "'" + dtOldExpiryDate.Year.ToString() + "'");
                saveLeaveToPayParam.Add("LeaveID", "'" + leaveids.Key + "'");
                if (cm.UpdateQueryCommon(saveUpdateParam, "TBL_LEAVES", "id = " + leaveids.Key + ""))
                {
                    if (!cm.ItemExist("TBL_LEAVETOPAY", "id", "where EmpID = '" + getleaveDict["EmpID"] + "' AND creditYear = '" + dtOldExpiryDate.Year.ToString() + "' AND LeaveID = '" + leaveids.Key + "'"))
                    {
                        if (cm.InsertQueryCommon(saveLeaveToPayParam, "TBL_LEAVETOPAY"))
                        {
                            cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " trigger auto reset of leave credit for Employee Number: " + getleaveDict["EmpID"] + " from Allowed: "
                            + getleaveDict["Allowed"] + " to 5, Remaining: " + getleaveDict["Remaining"] + " to 5, Used: " + getleaveDict["Used"] + " to 0, " +
                            "Expiry: " + getleaveDict["Expiry"] + " to " + leaveids.Value,
                                   "UPDATE", "", "", "UPDATE", Session["EMP_ID"].ToString());
                        }

                    }


                }

            }
        }
        public string getname()
        {
            string name = "";
            name = emp.GetEmployeeName(empno);

            return name;
        }

        void refresh()
        {
            DataTable dt = new DataTable();
            dt = tk.populateGridLeavesApp(empno);
            GridViewList.DataSource = dt;
            GridViewList.DataBind();
            ViewState["EMP_GRID"] = dt;
            ViewState["SORTDR"] = null;
            summary();
        }
        void summary()
        {
            gridtotalcount = ((DataTable)ViewState["EMP_GRID"]).Rows.Count;
            int pageIndex = GridViewList.PageIndex;
            int c = (pageIndex > 0 ? 10 * pageIndex : 0) + GridViewList.Rows.Count;
            gridrangecount = (c > 0 ? c : 0) + " - " + gridtotalcount;
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

                GridViewList.DataSource = dt;
                GridViewList.DataBind();
                summary();


            }

        }
        protected void txtItem_TextChanged(object sender, EventArgs e)
        {

            //awong-retrieve textbox values from the grid control during runtime.
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
            string _status = ((TextBox)currentRow.FindControl("txtSearchStatus")).Text;
            string _leavetype = ((TextBox)currentRow.FindControl("txtSearchLeaveType")).Text;
            string _dtfrom = ((TextBox)currentRow.FindControl("txtSearchDateFrom")).Text;
            string _dtto = ((TextBox)currentRow.FindControl("txtSearchDateTo")).Text;
            string _leaveHrs = ((TextBox)currentRow.FindControl("txtSearchLeaveHours")).Text;
            //string _days = ((TextBox)currentRow.FindControl("txtSearchDays")).Text;
            string _datefiled = ((TextBox)currentRow.FindControl("txtSearchDateFiled")).Text;
            string _approver1 = ((TextBox)currentRow.FindControl("txtSearchApprover1")).Text;
            string _dapproved1 = ((TextBox)currentRow.FindControl("txtSearchDapproved1")).Text;
            string _approver2 = ((TextBox)currentRow.FindControl("txtSearchApprover2")).Text;
            string _dapproved2 = ((TextBox)currentRow.FindControl("txtSearchDapproved2")).Text;
            string _reason = ((TextBox)currentRow.FindControl("txtSearchReason")).Text;
            string _dapproval = ((TextBox)currentRow.FindControl("txtSearchDisapproval")).Text;
            string expr = emp.build_or_like_param(saveSearchParam(_status, _leavetype, _dtfrom, _dtto, _leaveHrs, "", _datefiled, _approver1, _dapproved1,
                _approver2, _dapproved2, _reason, _dapproval));
            //string expr = "and (license_type like '%" + lictype + "%' or license_no like '%" + licno + "%' or lic_expirydate like '%" + licdate + "%')";
            //GridViewList.DataSource = emp.populateGridSearch((DataTable)ViewState["EMP_GRID"], expr);
            GridViewList.DataSource = tk.populateGridLeavesAppCol(empno, expr);
            GridViewList.DataBind();

            if (GridViewList.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('No Data Found !!!');", true);
                refresh();
            }

        }

        Dictionary<string, string> saveSearchParam(string _status, string _leavetype, string _dtfrom, string _dtto, string _leaveHrs, string _days, string _datefiled, string _approver1, string _dapproved1, string _approver2, string _dapproved2, string _reason, string _dapproval)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("LeaveStatus", "'%" + _status + "%'");
            param.Add("LeaveTypeDesc", "'%" + _leavetype + "%'");
            param.Add("DateFrom", "'%" + _dtfrom + "%'");
            param.Add("DateTo", "'%" + _dtto + "%'");
            param.Add("LeaveHours", "'%" + _leaveHrs + "%'");
            //param.Add("NumberOfDays", "'%" + _days + "%'");
            param.Add("DateFiled", "'%" + _datefiled + "%'");
            param.Add("Approver1", "'%" + _approver1 + "%'");
            param.Add("DateApproved1", "'%" + _dapproved1 + "%'");
            param.Add("Approver2", "'%" + _approver2 + "%'");
            param.Add("DateApproved2", "'%" + _dapproved2 + "%'");

            param.Add("Reason", "'%" + _reason + "%'");
            param.Add("reasons2", "'%" + _dapproval + "%'");


            return param;


        }
        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow currentRow = (GridViewRow)((DropDownList)sender).Parent.Parent;
            string stat = ((DropDownList)currentRow.FindControl("ddlStat")).SelectedValue.ToString();
            string expr = emp.build_or_like_param(saveSearchParam1(stat));

            GridViewList.DataSource = tk.populateGridLeavesAppCol(empno, expr);
            GridViewList.DataBind();

        }

        Dictionary<string, string> saveSearchParam1(string _status)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("LeaveStatus", "'%" + _status + "%'");


            return param;


        }
        protected void GridViewList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewList.PageIndex = e.NewPageIndex;
            refresh();
        }
        protected void GridViewList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sort")
            {
                sort_grid(e.CommandArgument.ToString());

            }
            if (e.CommandName == "Reset")
            {
                refresh();

            }

            if (e.CommandName == "upd")
            {
                HiddenEmpID.Value = e.CommandArgument.ToString();
                populateUpdateField(e.CommandArgument.ToString());
                openTransDetails(empno);
            }
            if (e.CommandName == "del")
            {
                getleave = cm.GetSpecificDataFromDB("LeaveType", "TBL_LEAVESAPP", "where id = " + e.CommandArgument.ToString() + "");
                getdays = cm.GetSpecificDataFromDB("NumberOfDays", "TBL_LEAVESAPP", "where id = " + e.CommandArgument.ToString() + "");
                getstat = cm.GetSpecificDataFromDB("LeaveStatus", "TBL_LEAVESAPP", "where id = " + e.CommandArgument.ToString() + "");
                getrem = cm.GetSpecificDataFromDB("Remaining", "TBL_LEAVES", "where EmpID = '" + empno + "' and LeaveType ='" + getleave +
                    "' and Activated = '1'");
                getused = cm.GetSpecificDataFromDB("Used", "TBL_LEAVES", "where EmpID = '" + empno + "' and LeaveType ='" + getleave +
                    "' and Activated = '1'");
                getreason = cm.FormatDate(cm.GetSpecificDataFromDB("Reason", "TBL_FTS", "where id = " + e.CommandArgument.ToString() + ""));
                getfiledate = cm.FormatDate(cm.GetSpecificDataFromDB("DateFiled", "TBL_FTS", "where id = " + e.CommandArgument.ToString() + ""));
                double total = Convert.ToDouble(getrem.ToString()) + Convert.ToDouble(getdays.ToString());
                double used = Convert.ToDouble(getused.ToString()) - Convert.ToDouble(getdays.ToString());
                if (getstat == "1")
                {
                    updatecred(empno, total.ToString(), used.ToString());
                }

                emp.DeleteQuery("TBL_LEAVESAPP", "where id =" + e.CommandArgument.ToString() + "");
                cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " removed Applied Leave of " + emp.GetEmployeeName(empno) + " with LEAVE TYPE " + getleave +
                    ".Date Filed: " + getfiledate + ".Reason: " + getreason + ".", "DELETE", "LEAVES", e.CommandArgument.ToString(), "LEAVES", Session["EMP_ID"].ToString());
                refresh();
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Successfully Deleted');",
                true);

            }
        }

        void updatecred(string id, string total, string used)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("Remaining", "'" + total + "'");
            param.Add("Used", "'" + used + "'");
            cm.UpdateQueryCommon(param, "TBL_LEAVES", " EmpID = " + id + " and LeaveType = '" + getleave + "' and Activated = '1'");
        }
        void updatecredadmin(string id, string total, string used,string leavetype)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("Remaining", "'" + total + "'");
            param.Add("Used", "'" + used + "'");
            cm.UpdateQueryCommon(param, "TBL_LEAVES", " EmpID = " + id + " and LeaveType = '" + leavetype + "' and Activated = '1'");
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                //string leavekey = cm.GetSpecificDataFromDB("LeaveKey", "TBL_LEAVETYPE", " where id = " + Leavesapp_LeaveType.SelectedValue + "");
                bool IsDateAllowedToBeFiled = true;
                bool IsSLAllowedToBeFiled = true;
                bool IsBLAllowedToBeFiled = true;
                bool IsEnoughCredits = true;
                string SLstatus = "", iscount = "", numDays = "";
                Dictionary<string, string> param = new Dictionary<string, string>();
                Dictionary<string, string> emailparam = new Dictionary<string, string>();
                if (cm.ItemExist("TBL_LEAVESAPP", "*", "where EmpID = '" + empno + "' and ('" + txtDateFrom.Value + "' BETWEEN DateFrom AND DateTo OR '" + txtDateTo.Value + "' BETWEEN DateFrom AND DateTo) AND (LeaveStatus = '1' OR LeaveStatus ='2')", ""))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Duplicate leave is not allowed.');", true);
                    return;
                }
                //if (cm.ItemExist("TBL_LEAVESAPP", "*", "where EmpID = '" + empno + "' and DateFrom = '" + txtDateFrom.Value + "' AND LeaveStatus = '1'", ""))
                //{
                //    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Duplicate leave is not allowed.');", true);
                //    return;
                //}
                if (cm.ItemExist("TBL_LEAVES", "id", "where EmpID = '" + empno + "' and LeaveType =" + Leavesapp_LeaveType.SelectedValue + " and Activated = '1'", ""))
                {
                    IsBLAllowedToBeFiled = true;
                    param = saveParam(out emailparam, out IsDateAllowedToBeFiled, out IsSLAllowedToBeFiled, out IsBLAllowedToBeFiled, out IsEnoughCredits, out SLstatus, out iscount, out numDays);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Leave is not yet Activated !!!');", true);
                    return;
                }
                if (iscount == "NOTIME")
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Filling of leave in your rest day is not allowed');", true);
                    return;
                }
                
                if (!IsEnoughCredits)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Not enough leave credits !!!');", true);
                }
                else
                {
                    if (slct_LeaveKey.SelectedValue == "VL")
                    {
                        if (!IsDateAllowedToBeFiled)
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Vacation Leave filing should be 3 days prior.');", true);
                            return;
                        }
                    }
                    if (slct_LeaveKey.SelectedValue == "SL")
                    {
                        if (!IsSLAllowedToBeFiled && double.Parse(SLstatus) <= 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Advance filing for sick leave is not allowed.');", true);
                            return;
                        }
                        else if (!IsSLAllowedToBeFiled && double.Parse(SLstatus) >= 2)
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Filing of sick leave two days or more from date of leave is not allowed.');", true);

                            return;
                        }
                        else if (!IsSLAllowedToBeFiled)
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Advance filing for sick leave is not allowed.');", true);
                            return;
                        }
                    }
                    if (adl.IsDateHoliday(txtDateFrom.Value) == true)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Filling Leave in Holiday is not allowed !!!');", true);
                        return;
                    }
                    if (emp.InsertQueryCommon(param, "TBL_LEAVESAPP"))
                    {
                        try
                        {

                            if (Session["ROLES"].ToString() == "admin")
                            {

                                getremadmin = cm.GetSpecificDataFromDB("Remaining", "TBL_LEAVES", "where EmpID = '" + empno + "' and LeaveType ='" + Leavesapp_LeaveType.SelectedValue + "' and Activated = '1'");
                                getusedadmin = cm.GetSpecificDataFromDB("Used", "TBL_LEAVES", "where EmpID = '" + empno + "' and LeaveType ='" + Leavesapp_LeaveType.SelectedValue + "' and Activated = '1'");
                                double total = Convert.ToDouble(getremadmin.ToString()) - Convert.ToDouble(numDays.ToString());
                                double used = Convert.ToDouble(getusedadmin.ToString()) + Convert.ToDouble(numDays.ToString());
                                if (total < 0)
                                {
                                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Leave is not enough.');", true);
                                    Response.Redirect("~/Pages/Admin/TK/viewleavesapp.aspx?id=" + empno);

                                }
                                else
                                {
                                    //updatecred(empno, total.ToString(), used.ToString());
                                    updatecredadmin(empno, total.ToString(), used.ToString(), Leavesapp_LeaveType.SelectedValue);
                                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Save !!!');", true);
                                    cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " created Leave with Leave Type " + Leavesapp_LeaveType.SelectedValue + " for " + emp.GetEmployeeName(empno) +
                                ".Date Filed: " + cm.FormatDate(DateTime.Now) + ".Reason: " + Leavesapp_Reason.Value + ".", "CREATE", "LEAVES", Session["EMP_ID"].ToString(), "LEAVES", Session["EMP_ID"].ToString());
                                }


                            }

                        }
                        catch
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Leave is not enough.');", true);
                            Response.Redirect("~/Pages/Admin/TK/viewleavesapp.aspx?id=" + empno);

                        }
                        //int ret = cm.sendApprove(emailparam, "Leave Approval Request");
                        //if (ret > 0)
                        //{
                        //    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Save !!!');", true);
                        //    cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " created Leave with Leave Type " + Leavesapp_LeaveType.SelectedValue + " for " + emp.GetEmployeeName(empno) +
                        //        ".Date Filed: " + cm.FormatDate(DateTime.Now) + ".Reason: " + Leavesapp_Reason.Value + ".", "CREATE", "LEAVES", Session["EMP_ID"].ToString(), "LEAVES", Session["EMP_ID"].ToString());
                        //}
                        //else
                        //{
                        //    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Save !!! Email not sent');", true);
                        //    cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " created Leave with Leave Type " + Leavesapp_LeaveType.SelectedValue + " for " + emp.GetEmployeeName(empno) +
                        //        ".Date Filed: " + cm.FormatDate(DateTime.Now) + ".Reason: " + Leavesapp_Reason.Value + ".", "CREATE", "LEAVES", Session["EMP_ID"].ToString(), "LEAVES", Session["EMP_ID"].ToString());
                        //}
                        refresh();
                        reset();
                    }
                }
            }
        }

        Dictionary<string, string> saveParam(out Dictionary<string, string> emailparam, out bool IsDateAllowedToBeFiled, out bool IsSLAllowedToBeFiled, out bool IsBLAllowedToBeFiled, out bool IsEnoughCredits, out string strSLstatus, out string iscount, out string OutNumDays)
        {
            strSLstatus = ""; iscount = "";
            IsDateAllowedToBeFiled = true;
            IsSLAllowedToBeFiled = true;
            IsBLAllowedToBeFiled = false;

            Dictionary<string, string> param = new Dictionary<string, string>();
            emailparam = new Dictionary<string, string>();
            string numdays = get_Days(0,txtDateFrom.Value,txtDateTo.Value, Leavesapp_LeaveType.SelectedValue, leave_hours.Text, slct_LeaveKey.SelectedValue, out IsDateAllowedToBeFiled, out IsSLAllowedToBeFiled, out IsEnoughCredits, out strSLstatus, out iscount);
            OutNumDays = numdays;
            List<string> approver = new List<string>();
            param.Add("EmpID", "'"+empno+"'");
            param.Add("DateFrom", "'" + txtDateFrom.Value + "'");
            param.Add("DateTo", "'" + txtDateTo.Value + "'");
            param.Add("LeaveHours", "" + leave_hours.Text + "");// 05/27/2022 Jan Wong. 
            //param.Add("DateTo", "'" + txtDate2.Value + "'");
            param.Add("LeaveType", "'" + Leavesapp_LeaveType.SelectedValue + "'");
            param.Add("LeaveKey", "'" + slct_LeaveKey.SelectedValue + "'");
            param.Add("ampm", "'" + Leavesapp_ampm.Value + "'");
            param.Add("Reason", "'" + Leavesapp_Reason.Value + "'");
            if (Session["ROLES"].ToString() == "admin")
            {
                param.Add("LeaveStatus", "'1'");
            }
            else
            {
                param.Add("Approver1", "'" + empInfo["emp_Approver1"] + "'");
                param.Add("Approver2", "'" + empInfo["emp_Approver2"] + "'");
                param.Add("Approving", "'" + empInfo["emp_Approver1"] + "'");
                param.Add("LeaveStatus", "'2'");
            }

            param.Add("NumberOfDays", "" + numdays + "");
            param.Add("FullName", "'" + empInfo["emp_FullName"] + "'");
            param.Add("DateFiled", "'" + cm.FormatDate(DateTime.Now) + "'");

            emailparam.Add("EmpID", "'" + empno + "'");
            emailparam.Add("DateFrom", txtDateFrom.Value);
            emailparam.Add("DateTo", txtDateTo.Value);
            //emailparam.Add("LeaveHours", txtLeaveHours.Value);
            //emailparam.Add("DateTo", txtDate2.Value);
            emailparam.Add("LeaveType", Leavesapp_LeaveType.SelectedValue);
            //emailparam.Add("ampm", Leavesapp_ampm.Value);
            emailparam.Add("Reason", Leavesapp_Reason.Value);
            emailparam.Add("LeaveStatus", "Pending");
            emailparam.Add("NumberOfDays", numdays);
            emailparam.Add("FullName", empInfo["emp_FullName"]);
            emailparam.Add("DateFiled", cm.FormatDate(DateTime.Now));
            emailparam.Add("DateApproved", cm.FormatDate(DateTime.Now));



            return param;


        }

        //05/27/2022 Jan Wong
        //change string get_Days(string datefrom, string dateto, string leavetype, string ampm, string leavekey, out bool IsDateAllowedToBeFiled, out bool IsSLAllowedToBeFiled, out bool IsEnoughCredits, out string SLstatus, out string iscount)
        // string ampm to string leavehours
        
        string get_Days(double prevleavehrs,string datefrom, string dateto, string leavetype, string leavehours, string leavekey, out bool IsDateAllowedToBeFiled, out bool IsSLAllowedToBeFiled, out bool IsEnoughCredits, out string SLstatus, out string iscount)
        {
            DateTime datetoday = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Taipei Standard Time");
            DateTime expirydate = Convert.ToDateTime(cm.GetSpecificDataFromDB("Expiry", "TBL_LEAVES", " where EmpID = " + empno + " and (LeaveType = '" + Leavesapp_LeaveType.SelectedValue + "' or LeaveType = '" + upd_leavetype.SelectedValue + "')"));
            SLstatus = ""; iscount = "";
            //string leavekey = cm.GetSpecificDataFromDB("LeaveKey", "TBL_LEAVETYPE", " where id = " + leavetype + "");
            IsDateAllowedToBeFiled = true;
            IsSLAllowedToBeFiled = true;
            IsEnoughCredits = true;
            var formats = new string[] { "MM-dd-yyyy", "MM/dd/yyyy" };
            string getallowed = cm.GetSpecificDataFromDB("Remaining", "TBL_LEAVES", "where EmpID = " + empno + " and (LeaveType = '" + Leavesapp_LeaveType.SelectedValue + "' or LeaveType = '" + upd_leavetype.SelectedValue + "')");
            string hr = ""; double count = 0;
            double numdayscount = 0;
            double hrcount = 0;
            
            //05/27/2022 Jan Wong change ampm to leavehours
            //hrcount = (ampm == "DAY" ? 1 : 0.5);
            double dblgetallowed = 0;
            double.TryParse(getallowed, out dblgetallowed);
            dblgetallowed = dblgetallowed * 8;
            dblgetallowed += prevleavehrs;//06/28/2022 Jan Wong. add the previous leavehours. this is for updating approved leaves.
            double.TryParse(leavehours, out hrcount);
            //05/27/2022 Jan Wong end
            DateTime bussDtIn = Convert.ToDateTime((datefrom));
            DateTime bussDtOut = Convert.ToDateTime((dateto));
            //bool validDate = (DateTime.TryParseExact(timein, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dtIn) &&
            //    DateTime.TryParseExact(timeout, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dtOut));
            //bool validDate = (DateTime.TryParseExact(timein, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dtIn));

            while (bussDtIn <= bussDtOut)
            {
                if (cm.isHasSchedule(empInfo["emp_EmpID"].ToString(), bussDtIn.ToString()))
                {
                    if (adl.IsDateHoliday(cm.FormatDate(bussDtIn.ToString())) == false)
                    {
                        count = count + hrcount;
                        numdayscount++;
                    }
                }
                else
            {
                if (bussDtIn.DayOfWeek == DayOfWeek.Monday)
                {
                    if (empInfo["emp_Monday"].ToString() != "0")
                    {
                        if (adl.IsDateHoliday(cm.FormatDate(bussDtIn.ToString())) == false)
                        {
                                numdayscount++;
                                count = count + hrcount;
                                
                        }
                    }
                }
                if (bussDtIn.DayOfWeek == DayOfWeek.Tuesday)
                {
                    if (empInfo["emp_Tuesday"].ToString() != "0")
                    {
                        if (adl.IsDateHoliday(cm.FormatDate(bussDtIn.ToString())) == false)
                        {
                                numdayscount++;
                                count = count + hrcount;
                        }
                    }
                }
                if (bussDtIn.DayOfWeek == DayOfWeek.Wednesday)
                {
                    if (empInfo["emp_Wednesday"].ToString() != "0")
                    {
                        if (adl.IsDateHoliday(cm.FormatDate(bussDtIn.ToString())) == false)
                        {
                                numdayscount++;
                                count = count + hrcount;
                        }
                    }
                }
                if (bussDtIn.DayOfWeek == DayOfWeek.Thursday)
                {
                    if (empInfo["emp_Thursday"].ToString() != "0")
                    {
                        if (adl.IsDateHoliday(cm.FormatDate(bussDtIn.ToString())) == false)
                        {
                                numdayscount++;
                                count = count + hrcount;
                        }
                    }
                }
                if (bussDtIn.DayOfWeek == DayOfWeek.Friday)
                {
                    if (empInfo["emp_Friday"].ToString() != "0")
                    {
                        if (adl.IsDateHoliday(cm.FormatDate(bussDtIn.ToString())) == false)
                        {
                                numdayscount++;
                                count = count + hrcount;
                        }
                    }
                }
                if (bussDtIn.DayOfWeek == DayOfWeek.Saturday)
                {
                    if (empInfo["emp_Saturday"].ToString() != "0")
                    {
                        if (adl.IsDateHoliday(cm.FormatDate(bussDtIn.ToString())) == false)
                        {
                                numdayscount++;
                                count = count + hrcount;
                        }
                    }
                }
                if (bussDtIn.DayOfWeek == DayOfWeek.Sunday)
                {
                    if (empInfo["emp_Sunday"].ToString() != "0")
                    {
                        if (adl.IsDateHoliday(cm.FormatDate(bussDtIn.ToString())) == false)
                        {
                                numdayscount++;
                                count = count + hrcount;
                        }
                    }
                }
            }

                bussDtIn = bussDtIn.AddDays(1);
        }
        //double diff = (dtOut - dtIn).TotalDays;
        //double inputValue = Math.Round(diff, 2);
        //validDate = (DateTime.TryParseExact(timein, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dtIn) && DateTime.TryParseExact(timeout, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dtOut));
        //hr = count.ToString();
            hr = numdayscount.ToString();
            if (count <= 0)
            {
                iscount = "NOTIME";
            }
            //05/27/2022 Jan Wong. change getallowed to dblgetallowed. because count value is hours so i multiple dblgetallowed to 8 since its per day basis.
            //if (count > Convert.ToDouble(getallowed))
            if (count > dblgetallowed)
                    IsEnoughCredits = false;

            if (datetoday > expirydate)
                IsEnoughCredits = false;

            //double numdays = (dtIn - DateTime.Now).TotalDays;
            //if (numdays < 3)
            //    IsDateAllowedToBeFiled = false;
            if (leavekey == "VL1")
            {
                DateTime dtfrom = Convert.ToDateTime(bussDtIn);
                double numdays = (dtfrom - datetoday).TotalDays;
                if ((numdays < 3) || dtfrom <= datetoday)
                {
                    IsDateAllowedToBeFiled = false;
                }

            }
            if (leavekey == "SL1")
            {
                DateTime dtfrom = Convert.ToDateTime(bussDtIn);

                int days = (datetoday - dtfrom).Days;
                if (days != 1)
                {
                    IsSLAllowedToBeFiled = false;
                    SLstatus = days.ToString();
                }

            }
            return hr;


        }

        void reset()
        {
            txtDateFrom.Value = "";
            txtDateTo.Value = "";
            //txtLeaveHours.Value = "";
            Leavesapp_LeaveType.SelectedIndex = 0;
            //Leavesapp_ampm.SelectedIndex = 0;
            Leavesapp_Reason.Value = "";
            leave_hours.Text = "";
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            reset();
            refresh();
        }

        public void closeTransDetails()
        {
            upListDetails.Update();

            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //sb.Append(@"<script type='text/javascript'>");
            //sb.Append(string.Format(@"$('#{0}').modal('hide')", "listmodal"));
            //sb.Append(@"</script>");

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none",
    "<script>$('#listModal').modal('show');</script>", false);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "listmodal", sb.ToString(), false);

        }
        public void openTransDetails(string empNo)
        {
            upListDetails.Update();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(string.Format(@"$('#listmodal').modal('show')"));
            sb.Append(@"</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "listmodal", sb.ToString(), false);
            string username = "", fullname = "", email = "", roles = "";
        }
        protected void lnkbtnXlist_Click(object sender, EventArgs e)
        {
            closeTransDetails();
        }


        public void populateUpdateField(string id)
        {
            Dictionary<string, string> getDict = new Dictionary<string, string>();
            getDict = cm.GetTableDict("TBL_LEAVESAPP", "where id = " + id + "");
            upd_dateFrom.Value = cm.FormatDateyyyy(getDict["DateFrom"]);
            upd_dateTo.Value = cm.FormatDateyyyy(getDict["DateTo"]);
            //upd_LeaveHours.Value = cm.GetSpecificDataFromDB("LeaveHours", "TBL_LEAVESAPP", "where id = " + id + "");
            upd_SelectAmPm.Value = getDict["ampm"];
            upd_leavetype.SelectedValue = getDict["LeaveType"];
            upd_reason.Value = getDict["Reason"];
            upd_leave_hours.Text = getDict["LeaveHours"];
            upd_leavekey.SelectedValue = getDict["LeaveKey"];
        }

        //string get_Days(string timein, string leavetype, out bool IsDateAllowedToBeFiled, out bool IsSLAllowedToBeFiled, out bool IsEnoughCredits)
        //{
        //    IsDateAllowedToBeFiled = true;
        //    IsSLAllowedToBeFiled = true;
        //    IsEnoughCredits = true;
        //    var formats = new string[] { "MM-dd-yyyy", "MM/dd/yyyy" };
        //    string getallowed = cm.GetSpecificDataFromDB("Allowed", "TBL_LEAVES", "where EmpID = " + empno + " and (LeaveType = '" + Leavesapp_LeaveType.SelectedValue + "' or LeaveType = '" + upd_leavetype.SelectedValue + "')");
        //    string hr = ""; DateTime dtIn = new DateTime(), dtOut = new DateTime(); int count = 0;
        //    bool validDate = (DateTime.TryParseExact(timein, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dtIn));

        //    while (dtIn <= dtOut)
        //    {
        //        if (dtIn.DayOfWeek == DayOfWeek.Monday)
        //        {
        //            if (empInfo["emp_Monday"].ToString() == "2")
        //            {
        //                if (adl.IsDateHoliday(cm.FormatDate(dtIn.ToString())) == false)
        //                {
        //                    count = count + 1;
        //                }
        //            }
        //        }
        //        if (dtIn.DayOfWeek == DayOfWeek.Tuesday)
        //        {
        //            if (empInfo["emp_Tuesday"].ToString() == "2")
        //            {
        //                if (adl.IsDateHoliday(cm.FormatDate(dtIn.ToString())) == false)
        //                {
        //                    count = count + 1;
        //                }
        //            }
        //        }
        //        if (dtIn.DayOfWeek == DayOfWeek.Wednesday)
        //        {
        //            if (empInfo["emp_Wednesday"].ToString() == "2")
        //            {
        //                if (adl.IsDateHoliday(cm.FormatDate(dtIn.ToString())) == false)
        //                {
        //                    count = count + 1;
        //                }
        //            }
        //        }
        //        if (dtIn.DayOfWeek == DayOfWeek.Thursday)
        //        {
        //            if (empInfo["emp_Thursday"].ToString() == "2")
        //            {
        //                if (adl.IsDateHoliday(cm.FormatDate(dtIn.ToString())) == false)
        //                {
        //                    count = count + 1;
        //                }
        //            }
        //        }
        //        if (dtIn.DayOfWeek == DayOfWeek.Friday)
        //        {
        //            if (empInfo["emp_Friday"].ToString() == "2")
        //            {
        //                if (adl.IsDateHoliday(cm.FormatDate(dtIn.ToString())) == false)
        //                {
        //                    count = count + 1;
        //                }
        //            }
        //        }
        //        if (dtIn.DayOfWeek == DayOfWeek.Saturday)
        //        {
        //            if (empInfo["emp_Saturday"].ToString() == "2")
        //            {
        //                if (adl.IsDateHoliday(cm.FormatDate(dtIn.ToString())) == false)
        //                {
        //                    count = count + 1;
        //                }
        //            }
        //        }
        //        if (dtIn.DayOfWeek == DayOfWeek.Sunday)
        //        {
        //            if (empInfo["emp_Sunday"].ToString() == "0")
        //            {
        //                if (adl.IsDateHoliday(cm.FormatDate(dtIn.ToString())) == false)
        //                {
        //                    count = count + 1;
        //                }
        //            }
        //        }
        //        dtIn = dtIn.AddDays(1);
        //    }

        //    //double diff = (dtOut - dtIn).TotalDays;
        //    //double inputValue = Math.Round(diff, 2);
        //    validDate = (DateTime.TryParseExact(timein, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dtIn));
        //    hr = count.ToString();
        //    if (count > Convert.ToDouble(getallowed))
        //        IsEnoughCredits = false;

        //    //double numdays = (dtIn - DateTime.Now).TotalDays;
        //    //if (numdays < 3)
        //    //    IsDateAllowedToBeFiled = false;

        //    if (!(DateTime.Now > dtIn) && (leavetype == "SICK LEAVE" || leavetype == "Sick Leave"))
        //        IsSLAllowedToBeFiled = false;
        //    return hr;


        //}

        Dictionary<string, string> saveUpdateParam(double prevleavehrs,out bool IsDateAllowedToBeFiled, out bool IsSLAllowedToBeFiled, out bool IsBLAllowedToBeFiled, out bool IsEnoughCredits, out string updstrSLstatus, out string iscount)
        {
            iscount = "";
            updstrSLstatus = "";
            IsDateAllowedToBeFiled = true;
            IsSLAllowedToBeFiled = true;
            IsBLAllowedToBeFiled = false;
            IsEnoughCredits = true;
            Dictionary<string, string> param = new Dictionary<string, string>();
            string numdays = get_Days(prevleavehrs,upd_dateFrom.Value,upd_dateTo.Value, upd_leavetype.SelectedValue, upd_leave_hours.Text, upd_leavekey.SelectedValue, out IsDateAllowedToBeFiled, out IsSLAllowedToBeFiled, out IsEnoughCredits, out updstrSLstatus, out iscount);
            param.Add("DateFrom", "'" + upd_dateFrom.Value + "'");
            param.Add("DateTo", "'" + upd_dateTo.Value + "'");
            param.Add("LeaveHours", "" + upd_leave_hours.Text + "");
            param.Add("ampm", "'" + upd_SelectAmPm.Value + "'");

            param.Add("LeaveType", upd_leavetype.SelectedValue);
            param.Add("LeaveKey", "'" + upd_leavekey.SelectedValue + "'");
            param.Add("Reason", "'" + upd_reason.Value + "'");
            param.Add("NumberOfDays", "" + numdays + "");

            param.Add("EmpID", "'" + empno + "'");

            return param;

        }

        private void getdata()
        {
            getdfrom = cm.FormatDate(cm.GetSpecificDataFromDB("DateFrom", "TBL_LEAVESAPP", "where id = " + HiddenEmpID.Value + ""));
            getdto = cm.FormatDate(cm.GetSpecificDataFromDB("DateTo", "TBL_LEAVESAPP", "where id = " + HiddenEmpID.Value + ""));
            //getampm = cm.GetSpecificDataFromDB("ampm", "TBL_LEAVESAPP", "where id = " + HiddenEmpID.Value + "");
            getleavehrs = cm.GetSpecificDataFromDB("LeaveHours", "TBL_LEAVESAPP", "where id = " + HiddenEmpID.Value + "");
            getleave = cm.GetSpecificDataFromDB("LeaveType", "TBL_LEAVESAPP", "where id = " + HiddenEmpID.Value + "");
            getreason = cm.GetSpecificDataFromDB("Reason", "TBL_LEAVESAPP", "where id = " + HiddenEmpID.Value + "");
        }

        private void addlogs()
        {
            if (getdfrom != upd_dateFrom.Value)
            {
                cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " changed Applied Leave DATE FROM for " + emp.GetEmployeeName(empno) + " from " + getdfrom + " to " + upd_dateFrom.Value +
                    ".Date Filed: " + getfiledate + ".Reason: " + getreason + ".", "CHANGE", "LEAVES", HiddenEmpID.Value, "LEAVES", Session["EMP_ID"].ToString());
            }
            if (getdto != upd_dateTo.Value)
            {
                cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " changed Applied Leave DATE FROM for " + emp.GetEmployeeName(empno) + " from " + getdto + " to " + upd_dateTo.Value +
                    ".Date Filed: " + getfiledate + ".Reason: " + getreason + ".", "CHANGE", "LEAVES", HiddenEmpID.Value, "LEAVES", Session["EMP_ID"].ToString());
            }
            if (getleavehrs != upd_leave_hours.Text)
            {
                cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " changed Applied Leave LEAVE HOURS for " + emp.GetEmployeeName(empno) + " from " + getleavehrs + " to " + upd_leave_hours.Text +
                    ".Date Filed: " + getfiledate + ".Reason: " + getreason + ".", "CHANGE", "LEAVES", HiddenEmpID.Value, "LEAVES", Session["EMP_ID"].ToString());
            }
            if (getleave != upd_leavetype.SelectedValue)
            {
                cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " changed Applied Leave TYPE for " + emp.GetEmployeeName(empno) + " from " + getleave + " to " + upd_leavetype.SelectedValue +
                     ".Date Filed: " + getfiledate + ".Reason: " + getreason + ".", "CHANGE", "LEAVES", HiddenEmpID.Value, "LEAVES", Session["EMP_ID"].ToString());
            }
            if (getreason != upd_reason.Value)
            {
                cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " changed Applied Leave REASON for " + emp.GetEmployeeName(empno) + " from " + getreason + " to " + upd_reason.Value +
                     ".Date Filed: " + getfiledate + ".Reason: " + getreason + ".", "CHANGE", "LEAVES", HiddenEmpID.Value, "LEAVES", Session["EMP_ID"].ToString());
            }
        }

        protected void btnsaveUpdate_Click(object sender, EventArgs e)
        {
            bool IsDateAllowedToBeFiled = true;
            bool IsSLAllowedToBeFiled = true;
            bool IsBLAllowedToBeFiled = true;
            bool IsEnoughCredits = true;
            string SLstatus = "", iscount = "";
            string strprevleavehr = "", strprevnumofdays = "";
            double prevleavehours = 0, prevnumofdays = 0;
            cm.GetTwoDataFromDB("LeaveHours", "NumberOfDays", "TBL_LEAVESAPP", "where id = " + HiddenEmpID.Value + "", out strprevleavehr, out strprevnumofdays);
            double.TryParse(strprevleavehr, out prevleavehours);
            double.TryParse(strprevnumofdays, out prevnumofdays);
            prevleavehours = prevleavehours * prevnumofdays;
            Dictionary<string, string> param = new Dictionary<string, string>();
            if (cm.ItemExist("TBL_LEAVESAPP", "*", "where EmpID = '" + empno + "' and DateFrom = '" + upd_dateFrom.Value + "' AND LeaveStatus = '1' AND id != " + HiddenEmpID.Value + "", ""))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Duplicate leave is not allowed.');", true);
                return;
            }
            if (cm.ItemExist("TBL_LEAVES", "id", "where EmpID = '" + empno + "' and LeaveType =" + upd_leavetype.SelectedValue + " and Activated = '1'", ""))
            {
                IsBLAllowedToBeFiled = true;
                param = saveUpdateParam(prevleavehours,out IsDateAllowedToBeFiled, out IsSLAllowedToBeFiled, out IsBLAllowedToBeFiled, out IsEnoughCredits, out SLstatus, out iscount);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Leave is not yet Activated !!!');", true);
                return;
            }
            if (iscount == "NOTIME")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Filling of leave in your rest day is not allowed');", true);
                return;
            }
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                string leavekey = cm.GetSpecificDataFromDB("LeaveKey", "TBL_LEAVETYPE", " where id = " + upd_leavetype.SelectedValue + "");
                getdata();
                if (!IsEnoughCredits)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Not enough leave credits !!!');", true);
                }
                else
                {
                    if (leavekey == "VL")
                    {
                        if (!IsDateAllowedToBeFiled)
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Vacation Leave Filing should be 3 days prior !!!');", true);
                            return;
                        }
                    }
                    if (leavekey == "SL")
                    {
                        if (!IsSLAllowedToBeFiled && double.Parse(SLstatus) <= 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Advance filing for sick leave is not allowed.');", true);
                            return;
                        }
                        else if (!IsSLAllowedToBeFiled && double.Parse(SLstatus) >= 2)
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Filing of sick leave two days or more from date of leave is not allowed.');", true);

                            return;
                        }
                        else if (!IsSLAllowedToBeFiled)
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Advance filing for sick leave is not allowed.');", true);
                            return;
                        }
                    }
                    if (adl.IsDateHoliday(upd_dateFrom.Value) == true)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Filling Leave in Holiday is not allowed !!!');", true);
                        return;
                    }
                    if (cm.UpdateQueryCommon(param, "TBL_LEAVESAPP", "id = '" + HiddenEmpID.Value + "'"))
                    {
                        //06/28/2022 Jan Wong. update previous credit.
                        string getrem = cm.GetSpecificDataFromDB("Remaining", "TBL_LEAVES A, TBL_LEAVESAPP B", "where A.LeaveType = B.LeaveType AND B.EmpID = '" + empno + "' and A.EmpID = '" + empno + "' and B.id = '" + HiddenEmpID.Value + "'");
                        string getused = cm.GetSpecificDataFromDB("Used", "TBL_LEAVES A, TBL_LEAVESAPP B", "where A.LeaveType = B.LeaveType AND B.EmpID = '" + empno + "' and A.EmpID = '" + empno + "' and B.id = '" + HiddenEmpID.Value + "'");
                        string getid = cm.GetSpecificDataFromDB("A.id", "TBL_LEAVES A, TBL_LEAVESAPP B", "where A.LeaveType = B.LeaveType AND B.EmpID = '" + empno + "' and A.EmpID = '" + empno + "' and B.id = '" + HiddenEmpID.Value + "'");
                        if (getrem != "" && getused != "" && getid != "")
                        {
                            double total = Convert.ToDouble(getrem.ToString()) + (prevleavehours / 8);//divide to 8 since leave credit is per day.
                            double used = Convert.ToDouble(getused.ToString()) - (prevleavehours / 8);
                            Dictionary<string, string> saveparamprevcredit = new Dictionary<string, string>();
                            saveparamprevcredit.Add("Remaining", total.ToString());
                            saveparamprevcredit.Add("Used", used.ToString());
                            cm.UpdateQueryCommon(saveparamprevcredit, "TBL_LEAVES", "id = " + getid + "");
                        }
                        


                        //06/28/2022 Jan WOng. update existing credit.
                        string updrem = cm.GetSpecificDataFromDB("Remaining", "TBL_LEAVES A, TBL_LEAVESAPP B", "where A.LeaveType = B.LeaveType AND B.EmpID = '" + empno + "' and A.EmpID = '" + empno + "' and B.id = '" + HiddenEmpID.Value + "'");
                        string updused = cm.GetSpecificDataFromDB("Used", "TBL_LEAVES A, TBL_LEAVESAPP B", "where A.LeaveType = B.LeaveType AND B.EmpID = '" + empno + "' and A.EmpID = '" + empno + "' and B.id = '" + HiddenEmpID.Value + "'");
                        string updid = cm.GetSpecificDataFromDB("A.id", "TBL_LEAVES A, TBL_LEAVESAPP B", "where A.LeaveType = B.LeaveType AND B.EmpID = '" + empno + "' and A.EmpID = '" + empno + "' and B.id = '" + HiddenEmpID.Value + "'");
                        if (updrem != "" && updused != "" && updid != "")
                        {
                            double updleavehours = 0;
                            double.TryParse(upd_leave_hours.Text, out updleavehours);
                            double dblupdtotal = Convert.ToDouble(updrem.ToString()) - (updleavehours / 8);//divide to 8 since leave credit is per day.
                            double dblupdused = Convert.ToDouble(updused.ToString()) + (updleavehours / 8);
                            Dictionary<string, string> saveparamexistingcredit = new Dictionary<string, string>();
                            saveparamexistingcredit.Add("Remaining", dblupdtotal.ToString());
                            saveparamexistingcredit.Add("Used", dblupdused.ToString());
                            cm.UpdateQueryCommon(saveparamexistingcredit, "TBL_LEAVES", "id = " + updid + "");
                        }
                            

                        addlogs();
                        //db_Emp.updateUserInfo(HiddenEmpID.Value, txtbox_username.Text, txtbox_password.Text, (drpdwn_acctstatus.SelectedValue == "1" ? true : false));
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully updated !!!');", true);
                        closeTransDetails();
                        refresh();
                    }
                    else
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Fields should not be empty !!!');", true);
                }
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("content-disposition", "attachment;filename= AppliedLeaves" + empno + ".xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Charset = "";
            this.EnableViewState = false;

            System.IO.StringWriter swriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlwriter = new System.Web.UI.HtmlTextWriter(swriter);

            DataGrid dg = new DataGrid();
            dg.DataSource = tk.populateGridLeavesApp(empno);
            dg.DataBind();

            dg.RenderControl(htmlwriter);


            Response.Write(swriter.ToString());
            cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " exported APPLIED LEAAVES",
            "EXPORT", "TIMEKEEPING", Session["EMP_ID"].ToString(), "TIMEKEEPING", Session["EMP_ID"].ToString());
            Response.End();
            //exportTOxlsx();


        }
    }
}