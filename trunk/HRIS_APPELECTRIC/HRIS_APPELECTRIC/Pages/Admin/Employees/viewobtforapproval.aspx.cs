﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HRIS_APPELECTRIC.Pages.Admin.Employees
{
    public partial class viewobtforapproval : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Timekeeping tk = new Timekeeping();
        Common cm = new Common();
        public string empno = "";
        public int gridtotalcount = 0;
        public string gridrangecount = "", userid;
        string getfrom, getto, getreason, getin, getout, getemp, getfiledate;
        public Dictionary<string, string> empInfo = new Dictionary<string, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            empno = Session["EMP_ID"].ToString();
            userid = Session["USERID"].ToString();
            empInfo = emp.GetEmployeeInfoDict(empno);
            if (!IsPostBack)
            {
                refresh();
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
            DataTable dt = new DataTable(); //GridForApproval

            dt = tk.populateGridOBTForApproval(empno);
            GridForApproval.DataSource = dt;
            GridForApproval.DataBind();
            ViewState["EMP_GRID1"] = dt;
            ViewState["SORTDR_1"] = null;

            dt = new DataTable();
            dt = tk.populateGridOBT(empno);
            GridFiledObt.DataSource = dt;
            GridFiledObt.DataBind();
            ViewState["EMP_GRID2"] = dt;
            ViewState["SORTDR_2"] = null;

            
            summary();
        }
        void summary()
        {
            gridtotalcount = ((DataTable)ViewState["EMP_GRID1"]).Rows.Count;
            int pageIndex = GridForApproval.PageIndex;
            int c = (pageIndex > 0 ? 10 * pageIndex : 0) + GridForApproval.Rows.Count;
            gridrangecount = (c > 0 ? c : 0) + " - " + gridtotalcount;
        }
        protected void sort_grid(string sort_args, string viewstateindex, string viewsortDR, int gridno)
        {
            DataTable dt = (DataTable)ViewState[viewstateindex];
            if (dt.Rows.Count > 0)
            {
                if (Convert.ToString(ViewState[viewsortDR]) == "Asc")
                {
                    dt.DefaultView.Sort = sort_args + " Desc";
                    ViewState[viewsortDR] = "Desc";
                }
                else
                {
                    dt.DefaultView.Sort = sort_args + " Asc";
                    ViewState[viewsortDR] = "Asc";
                }

                if (gridno == 1)
                {
                    GridForApproval.DataSource = dt;
                    GridForApproval.DataBind();
                }
                if (gridno == 2)
                {
                    GridFiledObt.DataSource = dt;
                    GridFiledObt.DataBind();
                }
                //if (gridno == 3)
                //{
                //    GridFiledLeave.DataSource = dt;
                //    GridFiledLeave.DataBind();
                //}
                summary();


            }

        }

        protected void GridForApproval_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button approve = (Button)e.Row.FindControl("btnApprove");
                Button disapprove = (Button)e.Row.FindControl("btnDisapprove");
                Label empid1 = (Label)e.Row.FindControl("lblApp1");
                Label empid2 = (Label)e.Row.FindControl("lblApp2");
                Label date1 = (Label)e.Row.FindControl("lblDate1");
                Label date2 = (Label)e.Row.FindControl("lblDate2");

                if (empid1.Text == empno)
                {
                    if (date1.Text != "")
                    {
                        approve.Visible = false;
                        disapprove.Visible = false;
                    }
                }
                if (empid2.Text == empno)
                {
                    if (date2.Text != "")
                    {
                        approve.Visible = false;
                        disapprove.Visible = false;
                    }
                }
            }
        }

        protected void GridForApproval_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridForApproval.PageIndex = e.NewPageIndex;
            refresh();
        }
        protected void GridForApproval_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sort")
            {
                sort_grid(e.CommandArgument.ToString(), "EMP_GRID1", "SORTDR1", 1);

            }

            if (e.CommandName == "cmd_approve")
            {
                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {
                    hfAprrove.Value = e.CommandArgument.ToString();
                    string getapp1 = cm.GetSpecificDataFromDB("Approver1", "TBL_OBT", "where id = " + e.CommandArgument.ToString() + "");
                    string getapp2 = cm.GetSpecificDataFromDB("Approver2", "TBL_OBT", "where id = " + e.CommandArgument.ToString() + "");
                    string getdate1 = cm.GetSpecificDataFromDB("DateApproved1", "TBL_OBT", "where id = " + e.CommandArgument.ToString() + "");
                    string getdate2 = cm.GetSpecificDataFromDB("DateApproved2", "TBL_OBT", "where id = " + e.CommandArgument.ToString() + "");
                    getfrom = cm.FormatDate(cm.GetSpecificDataFromDB("DateFrom", "TBL_OBT", "where id = " + e.CommandArgument.ToString() + ""));
                    getto = cm.FormatDate(cm.GetSpecificDataFromDB("DateTo", "TBL_OBT", "where id = " + e.CommandArgument.ToString() + ""));
                    getemp = cm.GetSpecificDataFromDB("FullName", "TBL_OBT", "where id = " + e.CommandArgument.ToString() + "");
                    getreason = cm.GetSpecificDataFromDB("Reason", "TBL_OBT", "where id = " + e.CommandArgument.ToString() + "");
                    getfiledate = cm.FormatDate(cm.GetSpecificDataFromDB("DateFiled", "TBL_OBT", "where id = " + e.CommandArgument.ToString() + ""));
                    if (getapp1 == empno)
                    {
                        if (getapp2 == "" || getapp2 == "0")
                        {
                            ChangeOBTStatus(e.CommandArgument.ToString(), "1");
                        }
                        else
                        {
                            if (getdate2 != "")
                            {
                                ChangeOBTStatus(e.CommandArgument.ToString(), "1");
                            }
                            else
                            {
                                ChangeOBTStatus(e.CommandArgument.ToString(), "2");
                            }
                        }
                    }
                    if (getapp2 == empno)
                    {
                        if (getdate1 != "")
                        {
                            ChangeOBTStatus(e.CommandArgument.ToString(), "1");
                        }
                        else
                        {
                            ChangeOBTStatus(e.CommandArgument.ToString(), "2");
                        }
                    }

                    cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " approved filed OBT of" + getemp + "with Date " + getfrom +
                        ". Date To: "+ getto + "Date Filed: " + getfiledate + ".Reason: " + getreason, "APPROVE", "OBT", e.CommandArgument.ToString(), "OBT", Session["EMP_ID"].ToString());
                    refresh();
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                    "alert",
                    "alert('Successfully Approved.');",
                    true);
                }
            }
            if (e.CommandName == "cmd_disapprove")
            {
                HiddenField1.Value = e.CommandArgument.ToString();
                populateUpdateField1(e.CommandArgument.ToString());
                openTransDetails1(empno);
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
                getfrom = cm.FormatDate(cm.GetSpecificDataFromDB("DateFrom", "TBL_OBT", "where id = " + e.CommandArgument.ToString() + ""));
                getto = cm.FormatDate(cm.GetSpecificDataFromDB("DateTo", "TBL_OBT", "where id = " + e.CommandArgument.ToString() + ""));
                getemp = cm.GetSpecificDataFromDB("FullName", "TBL_OBT", "where id = " + e.CommandArgument.ToString() + "");
                getreason = cm.GetSpecificDataFromDB("Reason", "TBL_OBT", "where id = " + e.CommandArgument.ToString() + "");
                getfiledate = cm.FormatDate(cm.GetSpecificDataFromDB("DateFiled", "TBL_OBT", "where id = " + e.CommandArgument.ToString() + ""));
                emp.DeleteQuery("TBL_OBT", "where id =" + e.CommandArgument.ToString() + "");
                cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " removed filed OBT of " + getemp + "with Date " + getfrom +
                    ".Date Filed: " + getfiledate + ".Reason: " + getreason + ".", "DELETE", "OBT", e.CommandArgument.ToString(), "OBT", Session["EMP_ID"].ToString());
                refresh();
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Successfully Deleted');",
                true);
            }
        }

        void ChangeOBTStatus(string id, string status)
        {
            string getapp1 = cm.GetSpecificDataFromDB("Approver1", "TBL_OBT", "where id = " + id + "");
            string getapp2 = cm.GetSpecificDataFromDB("Approver2", "TBL_OBT", "where id = " + id + "");
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("OBT_Status", "'" + status + "'");
            if (empno == getapp1)
            {
                param.Add("DateApproved1", "'" + cm.FormatDate(DateTime.Now) + "'");
            }
            if (empno == getapp2)
            {
                param.Add("DateApproved2", "'" + cm.FormatDate(DateTime.Now) + "'");
            }
            cm.UpdateQueryCommon(param, "TBL_OBT", " id = " + id + "");

        }

        protected void GridFiledObt_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridFiledObt.PageIndex = e.NewPageIndex;
            refresh();
        }
        protected void GridFiledObt_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sort")
            {
                sort_grid(e.CommandArgument.ToString(), "EMP_GRID2", "SORTDR2", 2);

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
                emp.DeleteQuery("TBL_OBT", "where id =" + e.CommandArgument.ToString() + "");
                refresh();
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Successfully Deleted');",
                true);

            }
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> emailParam = new Dictionary<string, string>();
            string confirmValue = "";
            confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if (cm.ItemExist("TBL_OBT", "*", "where EmpID = '" + empno + "'AND ('" + txtDateFrom.Value + "' BETWEEN DateFrom AND DateTo OR '" + txtDateTo.Value + "' BETWEEN DateFrom AND DateTo) AND (OBT_Status = '1' OR OBT_Status = '2')", ""))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Duplicate OBT is not allowed.');", true);
                    return;
                }
                if (cm.ItemExist("TBL_HOLIDAY", "*", "where Holiday BETWEEN '" + txtDateFrom.Value + "' AND '" + txtDateTo.Value + "'", ""))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Filing OBT during Holiday is not allowed.');", true);
                    return;
                }
                if (emp.InsertQueryCommon(saveParam(out emailParam), "TBL_OBT"))
                {
                    int ret = cm.sendApprove(emailParam, "OBT Approval Request");
                    if (ret > 0)
                    {
                        cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " created OBT with Date From" + txtDateFrom.Value + " Date To " + txtDateTo.Value + " for " + emp.GetEmployeeName(empno) +
                            ".Date Filed: " + cm.FormatDate(DateTime.Now) + ".Reason: " + Reason.Value + ".", "CREATE", "OBT", Session["EMP_ID"].ToString(), "OBT", Session["EMP_ID"].ToString());
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Save !!!');", true);
                    }
                    else
                    {
                        cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " created OBT with Date From" + txtDateFrom.Value + " Date To " + txtDateTo.Value + " for " + emp.GetEmployeeName(empno) +
                               ".Date Filed: " + cm.FormatDate(DateTime.Now) + ".Reason: " + Reason.Value + ".", "CREATE", "OBT", Session["EMP_ID"].ToString(), "OBT", Session["EMP_ID"].ToString());
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Save !!! Email not sent');", true);
                    }
                    txtDateFrom.Value = "";
                    txtDateTo.Value = "";
                    Reason.Value = "";
                    addTimeIn.Value = "";
                    addTimeOut.Value = "";
                    refresh();
                }
            }
        }
        Dictionary<string, string> saveParam(out Dictionary<string, string> emailParam)
        {
            TimeSpan tsTimeIn = TimeSpan.Parse(addTimeIn.Value);
            TimeSpan tsTimeOut = TimeSpan.Parse(addTimeOut.Value);
            emailParam = new Dictionary<string, string>();
            Dictionary<string, string> param = new Dictionary<string, string>();
            List<string> approver = new List<string>();
            param.Add("EmpID", "'"+empno+"'");
            param.Add("DateFrom", "'" + txtDateFrom.Value + "'");
            param.Add("DateTo", "'" + txtDateTo.Value + "'");
            //param.Add("EndDate", "'" + txtEndDate.Value + "'");
            param.Add("Reason", "'" + Reason.Value + "'");
            param.Add("TimeIn", "'" + tsTimeIn.ToString(@"h\:mm") + "'");
            param.Add("TimeOut", "'" + tsTimeOut.ToString(@"h\:mm") + "'");
            param.Add("Approver1", "'" + empInfo["emp_Approver1"] + "'");
            param.Add("Approver2", "'" + empInfo["emp_Approver2"] + "'");
            param.Add("Approving", "'" + empInfo["emp_Approver1"] + "'");
            param.Add("OBT_Status", "'2'");
            param.Add("FullName", "'" + empInfo["emp_FullName"] + "'");
            param.Add("DateFiled", "'" + DateTime.Now + "'");

            emailParam.Add("EmployeeID", "'" + empno + "'");
            emailParam.Add("FullName", "'" + empInfo["emp_FullName"] + "'");
            emailParam.Add("DateFrom", "'" + txtDateFrom.Value + "'");
            emailParam.Add("DateTo", "'" + txtDateTo.Value + "'");
            emailParam.Add("Reason", "'" + Reason.Value + "'");
            emailParam.Add("TimeIn", "'" + tsTimeIn.ToString(@"h\:mm") + "'");
            emailParam.Add("TimeOut", "'" + tsTimeOut.ToString(@"h\:mm") + "'");
            emailParam.Add("DateFiled", "'" + cm.FormatDate(DateTime.Now) + "'");
            emailParam.Add("Approver1", "" + empInfo["emp_Approver1"] + "");

            return param;


        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtDateFrom.Value = "";
            txtDateTo.Value = "";
            Reason.Value = "";
            addTimeIn.Value = "";
            addTimeOut.Value = "";

            refresh();
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
        public void populateUpdateField(string id)
        {
            TimeSpan timeIn = TimeSpan.Parse(cm.GetSpecificDataFromDB("TimeIn", "TBL_OBT", "where id = " + id + ""));
            TimeSpan timeOut = TimeSpan.Parse(cm.GetSpecificDataFromDB("TimeOut", "TBL_OBT", "where id = " + id + ""));
            upd_DateFrom.Value = cm.FormatDateyyyy(cm.GetSpecificDataFromDB("DateFrom", "TBL_OBT", "where id = " + id + ""));
            upd_DateTo.Value = cm.FormatDate(cm.GetSpecificDataFromDB("DateTo", "TBL_OBT", "where id = " + id + ""));
            upd_TimeIn.Value = timeIn.ToString(@"hh\:mm");
            upd_TimeOut.Value = timeOut.ToString(@"hh\:mm");
            upd_Reason.Value = cm.GetSpecificDataFromDB("Reason", "TBL_OBT", "where id = " + id + "");
        }

        Dictionary<string, string> saveUpdateParam()
        {
            TimeSpan updtsTimeIn = TimeSpan.Parse(upd_TimeIn.Value);
            TimeSpan updtsTimeOut = TimeSpan.Parse(upd_TimeOut.Value);

            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("DateFrom", "'" + upd_DateFrom.Value + "'");
            param.Add("DateTo", "'" + upd_DateTo.Value + "'");
            param.Add("TimeIn", "'" + updtsTimeIn.ToString(@"h\:mm") + "'");
            param.Add("TimeOut", "'" + updtsTimeOut.ToString(@"h\:mm") + "'");
            param.Add("Reason", "'" + upd_Reason.Value + "'");

            param.Add("EmpID", "'" + empno + "'");

            return param;
        }

        private void getdata()
        {
            getfrom = cm.FormatDate(cm.GetSpecificDataFromDB("DateFrom", "TBL_OBT", "where id = " + HiddenEmpID.Value + ""));
            getto = cm.FormatDate(cm.GetSpecificDataFromDB("DateTo", "TBL_OBT", "where id = " + HiddenEmpID.Value + ""));
            getreason = cm.GetSpecificDataFromDB("Reason", "TBL_OBT", "where id = " + HiddenEmpID.Value + "");
            getin = cm.GetSpecificDataFromDB("TimeIn", "TBL_OBT", "where id = " + HiddenEmpID.Value + "");
            getout = cm.GetSpecificDataFromDB("TimeOut", "TBL_OBT", "where id = " + HiddenEmpID.Value + "");
            getemp = cm.GetSpecificDataFromDB("FullName", "TBL_OBT", "where id = " + HiddenEmpID.Value + "");
        }

        private void addlogs()
        {
            if (getfrom != upd_DateFrom.Value)
            {
                cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " changed OBT DATE FROM for " + getemp + " from " + getfrom + " to " + upd_DateFrom.Value +
                    ".Date Filed: " + getfiledate + ".Reason: " + getreason + ".", "CHANGE", "OBT", HiddenEmpID.Value, "OBT", Session["EMP_ID"].ToString());
            }
            if (getto != upd_DateTo.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed OBT DATE TO for " + getemp + " from " + getto + " to " + upd_DateTo.Value,
                    "CHANGE", "OBT", Session["EMP_ID"].ToString(), "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getreason != upd_Reason.Value)
            {
                cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " changed OBT REASON for " + getemp + " from " + getreason + " to " + upd_Reason.Value +
                    ".Date Filed: " + getfiledate + ".Reason: " + getreason + ".", "CHANGE", "OBT", HiddenEmpID.Value, "OBT", Session["EMP_ID"].ToString());
            }
            if (getin != upd_TimeIn.Value)
            {
                cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " changed OBT TIME IN for " + getemp + " from " + getin + " to " + upd_TimeIn.Value +
                    ".Date Filed: " + getfiledate + ".Reason: " + getreason + ".", "CHANGE", "OBT", HiddenEmpID.Value, "OBT", Session["EMP_ID"].ToString());
            }
            if (getout != upd_TimeOut.Value)
            {
                cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " changed OBT TIME OUT for " + getemp + " from " + getout + " to " + upd_TimeOut.Value +
                    ".Date Filed: " + getfiledate + ".Reason: " + getreason + ".", "CHANGE", "OBT", HiddenEmpID.Value, "OBT", Session["EMP_ID"].ToString());
            }
        }

        protected void btnsaveUpdate_Click(object sender, EventArgs e)
        {
            
            TimeSpan tsTimeIn = TimeSpan.Parse(upd_TimeIn.Value);
            TimeSpan tsTimeOut = TimeSpan.Parse(upd_TimeOut.Value);
            string confirmValue = "";
            confirmValue = Request.Form["confirm_value"];

            if (confirmValue == "Yes")
            {
                if (cm.ItemExist("TBL_OBT", "*", "where EmpID = '" + empno + "'AND ('" + upd_DateFrom.Value + "' BETWEEN DateFrom AND DateTo OR '" + upd_DateTo.Value + "' BETWEEN DateFrom AND DateTo) AND (OBT_Status = '1' OR OBT_Status = '2') and id != " + HiddenEmpID.Value + "", ""))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Duplicate OBT is not allowed.');", true);
                    return;
                }
                if (cm.ItemExist("TBL_HOLIDAY", "*", "where Holiday BETWEEN '" + upd_DateFrom.Value + "' AND '" + upd_DateTo.Value + "'", ""))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Filing OBT during Holiday is not allowed.');", true);
                    return;
                }
                getdata();
                if (cm.UpdateQueryCommon(saveUpdateParam(), "TBL_OBT", "id = '" + HiddenEmpID.Value + "'"))
                {
                    addlogs();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully save.');", true);
                    refresh();
                }
            }
        }

        public void closeTransDetails1()
        {
            updDisapprove.Update();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(string.Format(@"$('#{0}').modal('hide')", "listdisapprove"));
            sb.Append(@"</script>");

            ScriptManager.RegisterStartupScript(this, this.GetType(), "listdisapprove", sb.ToString(), false);

        }
        public void openTransDetails1(string empNo)
        {
            updDisapprove.Update();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(string.Format(@"$('#{0}').modal('show')", "listdisapprove"));
            sb.Append(@"</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "listdisapprove", sb.ToString(), false);
        }
        protected void lnkbtnXlist1_Click(object sender, EventArgs e)
        {
            closeTransDetails1();
        }
        public void populateUpdateField1(string id)
        {
            dis_DateFrom.Value = cm.FormatDate(cm.GetSpecificDataFromDB("DateFrom", "TBL_OBT", "where id = " + id + ""));
            dis_DateTo.Value = cm.FormatDate(cm.GetSpecificDataFromDB("DateTo", "TBL_OBT", "where id = " + id + ""));
            dis_TimeIn.Value = cm.GetSpecificDataFromDB("TimeIn", "TBL_OBT", "where id = " + id + "");
            dis_TimeOut.Value = cm.GetSpecificDataFromDB("TimeOut", "TBL_OBT", "where id = " + id + "");
            dis_Reason.Value = cm.GetSpecificDataFromDB("Reason", "TBL_OBT", "where id = " + id + "");
        }

        Dictionary<string, string> saveDisapprove()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("reasons2", "'" + dis_Reason2.Value + "'");

            return param;
        }

        protected void btnDisapprove_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];

            if (confirmValue == "Yes")
            {
                getfrom = cm.FormatDate(cm.GetSpecificDataFromDB("DateFrom", "TBL_OBT", "where id = " + HiddenField1.Value + ""));
                getto = cm.FormatDate(cm.GetSpecificDataFromDB("DateTo", "TBL_OBT", "where id = " + HiddenField1.Value + ""));
                getemp = cm.GetSpecificDataFromDB("FullName", "TBL_OBT", "where id = " + HiddenField1.Value + "");
                getfiledate = cm.GetSpecificDataFromDB("DateFiled", "TBL_OBT", "where id = " + HiddenField1.Value + "");
                getreason = cm.GetSpecificDataFromDB("Reason", "TBL_OBT", "where id = " + HiddenField1.Value + "");
                if (cm.UpdateQueryCommon(saveDisapprove(), "TBL_OBT", "id = '" + HiddenField1.Value + "'"))
                {
                    ChangeOBTStatus(HiddenField1.Value, "3");
                    cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " Disapproved OBT of " + getemp + "with Date " + getfrom +
                        ".Date Filed: " + getfiledate + ".Reason: " + getreason + ".", "DISAPPROVE", "OBT", HiddenField1.Value, "DISAPPROVE", Session["EMP_ID"].ToString());
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Disapproved !!!');", true);
                    closeTransDetails1();
                    refresh();
                }
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("content-disposition", "attachment;filename= OBT" + empno + ".xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Charset = "";
            this.EnableViewState = false;

            System.IO.StringWriter swriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlwriter = new System.Web.UI.HtmlTextWriter(swriter);

            DataGrid dg = new DataGrid();
            dg.DataSource = tk.populateGridAnnouncement();
            dg.DataBind();

            dg.RenderControl(htmlwriter);


            Response.Write(swriter.ToString());
            cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " exported Announcements",
            "EXPORT", "ANNOUNCEMENT", Session["EMP_ID"].ToString(), "ANNOUNCEMENT", Session["EMP_ID"].ToString());
            Response.End();
            //exportTOxlsx();


        }
    }
}