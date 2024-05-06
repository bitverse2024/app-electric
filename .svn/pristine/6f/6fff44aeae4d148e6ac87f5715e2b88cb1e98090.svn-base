using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HRIS_APPELECTRIC.Pages.Admin.Employees
{
    public partial class viewotforapproval : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Timekeeping tk = new Timekeeping();
        Common cm = new Common();
        public string empno = "";
        public int gridtotalcount = 0;
        public string gridrangecount = "", userid;
        string getdate, getin, getout, getreason, getemp, getfiledate;
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

            dt = tk.populateGridOTForApproval(empno);
            GridForApproval.DataSource = dt;
            GridForApproval.DataBind();
            ViewState["EMP_GRID1"] = dt;
            ViewState["SORTDR_1"] = null;

            dt = new DataTable();
            dt = tk.populateGridOvertime(empno);
            GridFiledOT.DataSource = dt;
            GridFiledOT.DataBind();
            ViewState["EMP_GRID2"] = dt;
            ViewState["SORTDR_2"] = null;

            //dt = new DataTable();
            //dt = tk.populateGridLeavesApp(empno);
            //GridFiledLeave.DataSource = dt;
            //GridFiledLeave.DataBind();
            //ViewState["EMP_GRI3"] = dt;
            //ViewState["SORTDR_3"] = null;
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
                    GridFiledOT.DataSource = dt;
                    GridFiledOT.DataBind();
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
                    if (cm.ItemExist("TBL_OVERTIME", "id", "where EmpID = '" + empno + "' and OTDate = '" + Overtime_Date.Value + "' AND ot_Status = '1'", ""))
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Duplicate overtime is not allowed.');", true);
                        return;
                    }
                        hfAprrove.Value = e.CommandArgument.ToString();
                    string getapp1 = cm.GetSpecificDataFromDB("Approver1", "TBL_OVERTIME", "where id = " + e.CommandArgument.ToString() + "");
                    string getapp2 = cm.GetSpecificDataFromDB("Approver2", "TBL_OVERTIME", "where id = " + e.CommandArgument.ToString() + "");
                    string getdate1 = cm.GetSpecificDataFromDB("DateApproved1", "TBL_OVERTIME", "where id = " + e.CommandArgument.ToString() + "");
                    string getdate2 = cm.GetSpecificDataFromDB("DateApproved2", "TBL_OVERTIME", "where id = " + e.CommandArgument.ToString() + "");
                    getdate = cm.FormatDate(cm.GetSpecificDataFromDB("OTDate", "TBL_OVERTIME", "where id = " + e.CommandArgument.ToString() + ""));
                    getemp = cm.GetSpecificDataFromDB("FullName", "TBL_OVERTIME", "where id = " + e.CommandArgument.ToString() + "");
                    getreason = cm.GetSpecificDataFromDB("Reason", "TBL_OVERTIME", "where id = " + e.CommandArgument.ToString() + "");
                    getfiledate = cm.FormatDate(cm.GetSpecificDataFromDB("DateFiled", "TBL_OVERTIME", "where id = " + e.CommandArgument.ToString() + ""));
                    if (getapp1 == empno)
                    {
                        if (getapp2 == "")
                        {
                            ChangeOTStatus(e.CommandArgument.ToString(), "1");
                        }
                        else
                        {
                            if (getdate2 != "")
                            {
                                ChangeOTStatus(e.CommandArgument.ToString(), "1");
                            }
                            else
                            {
                                ChangeOTStatus(e.CommandArgument.ToString(), "2");
                            }
                        }
                    }
                    if (getapp2 == empno)
                    {
                        if (getdate1 != "")
                        {
                            ChangeOTStatus(e.CommandArgument.ToString(), "1");
                        }
                        else
                        {
                            ChangeOTStatus(e.CommandArgument.ToString(), "2");
                        }
                    }

                    cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " Approved OT of " + getemp + "with DATE " + getdate +
                        ".Date Filed: " + getfiledate + ".Reason: " + getreason + ".", "APPROVE", "OT", e.CommandArgument.ToString(), "OT", Session["EMP_ID"].ToString());
                    refresh();
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                    "alert",
                    "alert('Successfully Approved');",
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
                getdate = cm.FormatDate(cm.GetSpecificDataFromDB("OTDate", "TBL_OVERTIME", "where id = " + e.CommandArgument.ToString() + ""));
                getemp = cm.GetSpecificDataFromDB("FullName", "TBL_OVERTIME", "where id = " + e.CommandArgument.ToString() + "");
                getreason = cm.GetSpecificDataFromDB("Reason", "TBL_OVERTIME", "where id = " + e.CommandArgument.ToString() + "");
                getfiledate = cm.FormatDate(cm.GetSpecificDataFromDB("DateFiled", "TBL_OVERTIME", "where id = " + e.CommandArgument.ToString() + ""));
                emp.DeleteQuery("TBL_OVERTIME", "where id =" + e.CommandArgument.ToString() + "");
                cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " removed filed OT of " + getemp + " with DATE " + getdate +
                    ".Date Filed: " + getfiledate + ".Reason: " + getreason, "DELETE", "OT", e.CommandArgument.ToString(), "OT", Session["EMP_ID"].ToString());
                refresh();
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Successfully Deleted');",
                true);
            }
        }

        void ChangeOTStatus(string id, string status)
        {
            string getapp1 = cm.GetSpecificDataFromDB("Approver1", "TBL_OVERTIME", "where id = " + hfAprrove.Value + "");
            string getapp2 = cm.GetSpecificDataFromDB("Approver2", "TBL_OVERTIME", "where id = " + hfAprrove.Value + "");
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("ot_Status", "'" + status + "'");
            if (empno == getapp1)
            {
                param.Add("DateApproved1", "'" + cm.FormatDate(DateTime.Now) + "'");
            }
            if (empno == getapp2)
            {
                param.Add("DateApproved2", "'" + cm.FormatDate(DateTime.Now) + "'");
            }
            cm.UpdateQueryCommon(param, "TBL_OVERTIME", " id = " + id + "");

        }

        protected void GridFiledOT_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridFiledOT.PageIndex = e.NewPageIndex;
            refresh();
        }
        protected void GridFiledOT_RowCommand(object sender, GridViewCommandEventArgs e)
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
                getdate = cm.FormatDate(cm.GetSpecificDataFromDB("OTDate", "TBL_OVERTIME", "where id = " + e.CommandArgument.ToString() + ""));
                getreason = cm.GetSpecificDataFromDB("Reason", "TBL_OVERTIME", "where id = " + e.CommandArgument.ToString() + "");
                getfiledate = cm.FormatDate(cm.GetSpecificDataFromDB("DateFiled", "TBL_OVERTIME", "where id = " + e.CommandArgument.ToString() + ""));
                emp.DeleteQuery("TBL_OVERTIME", "where id =" + e.CommandArgument.ToString() + "");
                refresh();
                cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " removed his/her filed OT with DATE" + getdate,
                        "DELETE", "OT", e.CommandArgument.ToString(), "OT", Session["EMP_ID"].ToString());
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Successfully Deleted');",
                true);
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            DateTime bussDt = Convert.ToDateTime(Overtime_Date.Value);
            DateTime datetoday = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Taipei Standard Time");
            TimeSpan tsTimeIn = TimeSpan.Parse(Overtime_Time.Value);
            TimeSpan tsTimeOut = TimeSpan.Parse(Overtime_TimeOut.Value);
            string confirmValue = Request.Form["confirm_value"];

            if (confirmValue == "Yes")
            {
                if (cm.ItemExist("TBL_OVERTIME", "id", "where EmpID = '" + empno + "' and OTDate = '" + Overtime_Date.Value + "' AND ot_Status = '1'", ""))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Duplicate overtime is not allowed.');", true);
                    return;
                }
                int i = TimeSpan.Compare(tsTimeIn, tsTimeOut);
                if ((i == -1))
                {
                    if ((datetoday.Date > bussDt.Date) && (datetoday.Date != bussDt.Date))
                    {

                        if (Overtime_TimeOut.Value == "")
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Number of hours should be 30 minutes above !!!');", true);
                        }
                        if (Overtime_TimeOut.Value != "")
                        {
                            if (Convert.ToDouble(get_OT_Hours(Overtime_Time.Value, Overtime_TimeOut.Value)) > 0.5)
                            {
                                if (emp.InsertQueryCommon(saveParam(), "TBL_OVERTIME"))
                                {
                                    cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " created OT with DATE " + Overtime_Date.Value + " for " + emp.GetEmployeeName(empno) +
                                    ".Date Filed: " + cm.FormatDate(DateTime.Now) + ".Reason: " + Overtime_Reason.Value + ".",
                                    "CREATE", "OT", Session["EMP_ID"].ToString(), "OT", Session["EMP_ID"].ToString());
                                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Save !!!');", true);
                                    refresh();
                                    Overtime_Reason.Value = "";
                                    Overtime_Time.Value = "17:00";
                                    Overtime_TimeOut.Value = "18:00";
                                    Overtime_Date.Value = "";

                                }
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Number of hours should be 30 minutes above !!!');", true);
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Advance filing of overtime is not allowed.');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Time in must be shorter than time out.');", true);
                }
            }
        }
        Dictionary<string, string> saveParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            List<string> approver = new List<string>();
            param.Add("EmpID", "'" + empno + "'");
            param.Add("OTDate", "'" + Overtime_Date.Value + "'");
            param.Add("ot_Time", "'" + Overtime_Time.Value + "'");
            param.Add("ot_TimeOut", "'" + Overtime_TimeOut.Value + "'");
            param.Add("Reason", "'" + Overtime_Reason.Value + "'");
            param.Add("Approver1", "'" + empInfo["emp_Approver1"] + "'");
            param.Add("Approver2", "'" + empInfo["emp_Approver2"] + "'");
            param.Add("Approving", "'" + empInfo["emp_Approver1"] + "'");
            param.Add("ot_Status", "'2'");
            param.Add("ot_hours", "" + get_OT_Hours(Overtime_Time.Value, Overtime_TimeOut.Value) + "");
            param.Add("FullName", "'" + empInfo["emp_FullName"] + "'");
            param.Add("DateFiled", "'" + cm.FormatDate(DateTime.Now) + "'");

            return param;


        }

        string get_OT_Hours(string timein, string timeout)
        {
            string hr = "";
            TimeSpan diff = TimeSpan.Parse(timeout) - TimeSpan.Parse(timein);
            double inputValue = Math.Round(diff.TotalHours, 2);
            hr = inputValue.ToString();
            return hr;


        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Overtime_Reason.Value = "";
            Overtime_Time.Value = "17:00";
            Overtime_TimeOut.Value = "18:00";
            Overtime_Date.Value = "";
            //TripDate.Value = "";
            //EndDate.Value = "";
            //Reason.Value = "";
            //TimeIn.Value = "";
            //TimeOut.Value = "";

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
            upd_OTDate.Value = cm.FormatDateyyyy(cm.GetSpecificDataFromDB("OTDate", "TBL_OVERTIME", "where id = " + id + ""));
            upd_in.Value = cm.GetSpecificDataFromDB("ot_Time", "TBL_OVERTIME", "where id = " + id + "");
            upd_out.Value = cm.GetSpecificDataFromDB("ot_TimeOut", "TBL_OVERTIME", "where id = " + id + "");
            upd_Reason.Value = cm.GetSpecificDataFromDB("Reason", "TBL_OVERTIME", "where id = " + id + "");
        }

        Dictionary<string, string> saveUpdateParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("OTDate", "'" + cm.FormatDate(upd_OTDate.Value) + "'");
            param.Add("ot_Time", "'" + upd_in.Value + "'");
            param.Add("ot_TimeOut", "'" + upd_out.Value + "'");
            param.Add("Reason", "'" + upd_Reason.Value + "'");

            param.Add("EmpID", "'" + empno + "'");

            return param;
        }

        private void getdata()
        {
            getdate = cm.FormatDate(cm.GetSpecificDataFromDB("OTDate", "TBL_OVERTIME", "where id = " + HiddenEmpID.Value + ""));
            getin = cm.GetSpecificDataFromDB("ot_Time", "TBL_OVERTIME", "where id = " + HiddenEmpID.Value + "");
            getout = cm.GetSpecificDataFromDB("ot_TimeOut", "TBL_OVERTIME", "where id = " + HiddenEmpID.Value + "");
            getreason = cm.GetSpecificDataFromDB("Reason", "TBL_OVERTIME", "where id = " + HiddenEmpID.Value + "");
            getemp = cm.GetSpecificDataFromDB("FullName", "TBL_OVERTIME", "where id = " + HiddenEmpID.Value + "");
        }

        private void addlogs()
        {
            if (getdate != upd_OTDate.Value)
            {
                cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " changed OT DATE for " + getemp + " from " + getdate + " to " + upd_OTDate.Value +
                    ".Date Filed: " + getfiledate + ".Reason: " + getreason + ".", "CHANGE", "OT", HiddenEmpID.Value, "OT", Session["EMP_ID"].ToString());
            }
            if (getin != upd_in.Value)
            {
                cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " changed OT TIME IN for " + getemp + " from " + getin + " to " + upd_in.Value +
                    ".Date Filed: " + getfiledate + ".Reason: " + getreason + ".", "CHANGE", "OT", HiddenEmpID.Value, "OT", Session["EMP_ID"].ToString());
            }
            if (getout != upd_out.Value)
            {
                cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " changed OT TIME OUT for " + getemp + " from " + getout + " to " + upd_out.Value +
                    ".Date Filed: " + getfiledate + ".Reason: " + getreason + ".", "CHANGE", "OT", HiddenEmpID.Value, "OT", Session["EMP_ID"].ToString());
            }
            if (getreason != upd_Reason.Value)
            {
                cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " changed OT REASON for " + getemp + " from " + getreason + " to " + upd_Reason.Value +
                    ".Date Filed: " + getfiledate + ".Reason: " + getreason + ".", "CHANGE", "OT", HiddenEmpID.Value, "OT", Session["EMP_ID"].ToString());
            }
        }

        protected void btnsaveUpdate_Click(object sender, EventArgs e)
        {
            DateTime bussDt = Convert.ToDateTime(upd_OTDate.Value);
            DateTime datetoday = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Taipei Standard Time");
            string confirmValue = Request.Form["confirm_value"];
            TimeSpan tsTimeIn = TimeSpan.Parse(upd_in.Value);
            TimeSpan tsTimeOut = TimeSpan.Parse(upd_out.Value);
            if (confirmValue == "Yes")
            {

                if (cm.ItemExist("TBL_OVERTIME", "id", "where EmpID = '" + empno + "' and OTDate = '" + upd_OTDate.Value + "' AND ot_Status = '1' AND id != " + HiddenEmpID.Value + "", ""))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Duplicate overtime is not allowed.');", true);
                    return;
                }
                int i = TimeSpan.Compare(tsTimeIn, tsTimeOut);
                if ((i == -1))
                {
                    if ((datetoday.Date > bussDt.Date) && (datetoday.Date != bussDt.Date))
                    {
                        getdata();
                    if (upd_out.Value == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Number of hours should be 30 minutes above !!!');", true);
                    }
                        if (upd_out.Value != "")
                        {
                            if (Convert.ToDouble(get_OT_Hours(upd_in.Value, upd_out.Value)) > 0.5)
                            {
                                if (cm.UpdateQueryCommon(saveUpdateParam(), "TBL_OVERTIME", "id = '" + HiddenEmpID.Value + "'"))
                                {
                                    addlogs();
                                    //db_Emp.updateUserInfo(HiddenEmpID.Value, txtbox_username.Text, txtbox_password.Text, (drpdwn_acctstatus.SelectedValue == "1" ? true : false));
                                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully updated !!!');", true);
                                    closeTransDetails();
                                    refresh();
                                }
                                else
                                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Fields should not be empty !!!');", true);
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Number of hours should be 30 minutes above !!!');", true);
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Advance filing of overtime is not allowed.');", true);
                    }
                }
                else
                {

                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Time in must be shorter than time out.');", true);
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
            disOTDate.Value = cm.FormatDate(cm.GetSpecificDataFromDB("OTDate", "TBL_OVERTIME", "where id = " + id + ""));
            disin.Value = cm.FormatDate(cm.GetSpecificDataFromDB("ot_Time", "TBL_OVERTIME", "where id = " + id + ""));
            disout.Value = cm.GetSpecificDataFromDB("ot_TimeOut", "TBL_OVERTIME", "where id = " + id + "");
            dis_reason1.Value = cm.GetSpecificDataFromDB("Reason", "TBL_OVERTIME", "where id = " + id + "");
        }

        Dictionary<string, string> saveDisapprove()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("reasons2", "'" + dis_Reason.Value + "'");

            return param;
        }

        protected void btnDisapprove_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];

            if (confirmValue == "Yes")
            {
                getdate = cm.FormatDate(cm.GetSpecificDataFromDB("OTDate", "TBL_OVERTIME", "where id = " + HiddenField1.Value + ""));
                getemp = cm.GetSpecificDataFromDB("FullName", "TBL_OVERTIME", "where id = " + HiddenField1.Value + "");
                getreason = cm.GetSpecificDataFromDB("Reason", "TBL_OBT", "where id = " + HiddenField1.Value + "");
                getfiledate = cm.FormatDate(cm.GetSpecificDataFromDB("DateFiled", "TBL_OBT", "where id = " + HiddenField1.Value + ""));
                if (cm.UpdateQueryCommon(saveDisapprove(), "TBL_OVERTIME", "id = '" + HiddenField1.Value + "'"))
                {
                    ChangeOTStatus(HiddenField1.Value, "3");
                    cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " Disapproved OT of " + getemp + " with DATE" + getdate +
                        ".Date Filed: " + getfiledate + ".Reason: " + getreason + ".", "DISAPPROVE", "OT", HiddenField1.Value, "OT", Session["EMP_ID"].ToString());
                    //db_Emp.updateUserInfo(HiddenEmpID.Value, txtbox_username.Text, txtbox_password.Text, (drpdwn_acctstatus.SelectedValue == "1" ? true : false));
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
            Response.AddHeader("content-disposition", "attachment;filename= OT" + empno + ".xls");
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