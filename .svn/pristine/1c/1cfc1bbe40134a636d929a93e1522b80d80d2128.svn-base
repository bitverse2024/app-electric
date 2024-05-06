using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HRIS_APPELECTRIC.Pages.Admin.Employees
{
    public partial class viewftsforapproval : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Timekeeping tk = new Timekeeping();
        Common cm = new Common();
        public string empno = "";
        public int gridtotalcount = 0;
        public string gridrangecount = "", userid;
        string getdate, gettime, getreason, gettype, getemp, getfiledate;
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

            dt = tk.populateGridFTSForApproval(empno);
            GridForApproval.DataSource = dt;
            GridForApproval.DataBind();
            ViewState["EMP_GRID1"] = dt;
            ViewState["SORTDR_1"] = null;

            dt = new DataTable();
            dt = tk.populateGridFTS(empno);
            GridFiledFTS.DataSource = dt;
            GridFiledFTS.DataBind();
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
                    GridFiledFTS.DataSource = dt;
                    GridFiledFTS.DataBind();
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
                    string getapp1 = cm.GetSpecificDataFromDB("Approver1", "TBL_FTS", "where id = " + e.CommandArgument.ToString() + "");
                    string getapp2 = cm.GetSpecificDataFromDB("Approver2", "TBL_FTS", "where id = " + e.CommandArgument.ToString() + "");
                    string getdate1 = cm.GetSpecificDataFromDB("DateApproved1", "TBL_FTS", "where id = " + e.CommandArgument.ToString() + "");
                    string getdate2 = cm.GetSpecificDataFromDB("DateApproved2", "TBL_FTS", "where id = " + e.CommandArgument.ToString() + "");
                    getfiledate = cm.FormatDate(cm.GetSpecificDataFromDB("DateFiled", "TBL_FTS", "where id = " + e.CommandArgument.ToString() + ""));
                    getdate = cm.FormatDate(cm.GetSpecificDataFromDB("buss_date", "TBL_FTS", "where id = " + e.CommandArgument.ToString() + ""));
                    getemp = cm.GetSpecificDataFromDB("FullName", "TBL_FTS", "where id = " + e.CommandArgument.ToString() + "");
                    gettype = cm.GetSpecificDataFromDB("fts_type", "TBL_FTS", "where id = " + e.CommandArgument.ToString() + "");
                    getreason = cm.GetSpecificDataFromDB("Reason", "TBL_FTS", "where id = " + e.CommandArgument.ToString() + "");
                    {
                        if (getapp2 == "")
                        {
                            ChangeFTSStatus(e.CommandArgument.ToString(), "1");
                        }
                        else
                        {
                            if (getdate2 != "")
                            {
                                ChangeFTSStatus(e.CommandArgument.ToString(), "1");
                            }
                            else
                            {
                                ChangeFTSStatus(e.CommandArgument.ToString(), "2");
                            }
                        }
                    }
                    if (getapp2 == empno)
                    {
                        if (getdate1 != "")
                        {
                            ChangeFTSStatus(e.CommandArgument.ToString(), "1");
                        }
                        else
                        {
                            ChangeFTSStatus(e.CommandArgument.ToString(), "2");
                        }
                    }

                    cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " Approved UA of " + getemp + " with DATE " + getdate + " and Type " + gettype + ". Date Filed: " +
                        getfiledate + ". Reason: " + getreason + ".", "APPROVE", "UA", e.CommandArgument.ToString(), "UA", Session["EMP_ID"].ToString());
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
                getdate = cm.FormatDate(cm.GetSpecificDataFromDB("buss_date", "TBL_FTS", "where id = " + e.CommandArgument.ToString() + ""));
                getemp = cm.GetSpecificDataFromDB("FullName", "TBL_FTS", "where id = " + e.CommandArgument.ToString() + "");
                getfiledate = cm.FormatDate(cm.GetSpecificDataFromDB("DateFiled", "TBL_FTS", "where id = " + e.CommandArgument.ToString() + ""));
                gettype = cm.GetSpecificDataFromDB("fts_type", "TBL_FTS", "where id = " + e.CommandArgument.ToString() + "");
                getreason = cm.GetSpecificDataFromDB("Reason", "TBL_FTS", "where id = " + e.CommandArgument.ToString() + "");
                emp.DeleteQuery("TBL_FTS", "where id =" + e.CommandArgument.ToString() + "");
                cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " removed filed UA of" + getemp + " with DATE " + getdate + " and Type " +
                    gettype + "." + "Date Filed: " + getfiledate + ". Reason: " + getreason + ".", "DELETE", "UA", e.CommandArgument.ToString(), "UA", Session["EMP_ID"].ToString());
                refresh();
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Successfully Deleted');",
                true);
            }
        }

        void ChangeFTSStatus(string id, string status)
        {
            string getapp1 = cm.GetSpecificDataFromDB("Approver1", "TBL_FTS", "where id = " + hfAprrove.Value + "");
            string getapp2 = cm.GetSpecificDataFromDB("Approver2", "TBL_FTS", "where id = " + hfAprrove.Value + "");
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("fts_Status", "'" + status + "'");
            if (empno == getapp1)
            {
                param.Add("DateApproved1", "'" + cm.FormatDate(DateTime.Now) + "'");
            }
            if (empno == getapp2)
            {
                param.Add("DateApproved2", "'" + cm.FormatDate(DateTime.Now) + "'");
            }
            cm.UpdateQueryCommon(param, "TBL_FTS", " id = " + id + "");

        }

        protected void GridFiledFTS_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridFiledFTS.PageIndex = e.NewPageIndex;
            refresh();
        }
        protected void GridFiledFTS_RowCommand(object sender, GridViewCommandEventArgs e)
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
                getdate = cm.FormatDate(cm.GetSpecificDataFromDB("buss_date", "TBL_FTS", "where id = " + e.CommandArgument.ToString() + ""));
                getfiledate = cm.FormatDate(cm.GetSpecificDataFromDB("DateFiled", "TBL_FTS", "where id = " + e.CommandArgument.ToString() + ""));
                gettype = cm.GetSpecificDataFromDB("fts_type", "TBL_FTS", "where id = " + e.CommandArgument.ToString() + "");
                getreason = cm.GetSpecificDataFromDB("Reason", "TBL_FTS", "where id = " + e.CommandArgument.ToString() + "");
                emp.DeleteQuery("TBL_FTS", "where id =" + e.CommandArgument.ToString() + "");
                cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " removed his/her filed UA with DATE " + getdate + " and Type " + gettype
                    + ". Date Filed: " + getfiledate + ". Reason: " + getreason, "DELETE", "UA", e.CommandArgument.ToString(), "UA", Session["EMP_ID"].ToString());
                refresh();
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Successfully Deleted');",
                true);
            }
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];

            if (confirmValue == "Yes")
            {
                if (cm.ItemExist("TBL_FTS", "id", "where EmpID = '" + empno + "' and buss_date = '" + txtbuss_date.Value + "' and fts_type = '" + Fts_type.Value + "'", ""))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Duplicate Entry Not Allowed');", true);
                    reset();
                    return;
                    
                }
                if (emp.InsertQueryCommon(saveParam(), "TBL_FTS"))
                {
                    cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " created UA with Date " + txtbuss_date.Value + " and Type " + Fts_type.Value + " for " + emp.GetEmployeeName(empno) +
                           ". Date Filed: " + cm.FormatDate(cm.dtnow()) + ". Reason:" + Fts_reasons.Value + ".", "CREATE", "UA", Session["EMP_ID"].ToString(), "UA", Session["EMP_ID"].ToString());
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Save !!!');", true);
                    refresh();
                    reset();
                }
            }
        }

        Dictionary<string, string> saveParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            List<string> approver = new List<string>();
            param.Add("EmpID", empno);
            param.Add("buss_date", "'" + txtbuss_date.Value + "'");
            param.Add("ftime", "'" + Fts_time.Value + "'");
            param.Add("fts_type", "'" + Fts_type.Value + "'");
            param.Add("Reason", "'" + Fts_reasons.Value + "'");
            param.Add("Approver1", "'" + empInfo["emp_Approver1"] + "'");
            param.Add("Approver2", "'" + empInfo["emp_Approver2"] + "'");
            param.Add("Approving", "'" + empInfo["emp_Approver1"] + "'");
            param.Add("fts_status", "'2'");
            param.Add("FullName", "'" + empInfo["emp_FullName"] + "'");
            param.Add("DateFiled", "'" + cm.FormatDate(DateTime.Now) + "'");


            return param;


        }
        void reset()
        {
            upd_bussdate.Value = "";
            upd_reason.Value = "";
            upd_time.Value = "";
            upd_type.Value = "";
            txtbuss_date.Value = "";
            Fts_reasons.Value = "";
            Fts_time.Value = "";
            Fts_type.Value = "";
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            reset();
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
            string username = "", fullname = "", email = "", roles = "";
        }
        protected void lnkbtnXlist_Click(object sender, EventArgs e)
        {
            closeTransDetails();
        }

        public void populateUpdateField(string id)
        {
            upd_bussdate.Value = cm.FormatDateyyyy(cm.GetSpecificDataFromDB("buss_date", "TBL_FTS", "where id = " + id + ""));
            upd_time.Value = cm.GetSpecificDataFromDB("ftime", "TBL_FTS", "where id = " + id + "");
            upd_type.Value = cm.GetSpecificDataFromDB("fts_type", "TBL_FTS", "where id = " + id + "");
            upd_reason.Value = cm.GetSpecificDataFromDB("Reason", "TBL_FTS", "where id = " + id + "");
        }

        Dictionary<string, string> saveUpdateParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("buss_date", "'" + upd_bussdate.Value + "'");
            param.Add("ftime", "'" + upd_time.Value + "'");
            param.Add("fts_type", "'" + upd_type.Value + "'");
            param.Add("Reason", "'" + upd_reason.Value + "'");

            param.Add("EmpID", "'" + empno + "'");

            return param;
        }

        private void getdata()
        {
            getdate = cm.FormatDate(cm.GetSpecificDataFromDB("buss_date", "TBL_FTS", "where id = " + HiddenEmpID.Value + ""));
            gettime = cm.GetSpecificDataFromDB("ftime", "TBL_FTS", "where id = " + HiddenEmpID.Value + "");
            getreason = cm.GetSpecificDataFromDB("Reason", "TBL_FTS", "where id = " + HiddenEmpID.Value + "");
            gettype = cm.GetSpecificDataFromDB("fts_type", "TBL_FTS", "where id = " + HiddenEmpID.Value + "");
            getemp = cm.GetSpecificDataFromDB("FullName", "TBL_OBT", "where id = " + HiddenEmpID.Value + "");
        }

        private void addlogs()
        {
            getfiledate = cm.GetSpecificDataFromDB("DateFiled", "TBL_FTS", "where id = " + HiddenEmpID.Value + "");
            getreason = cm.GetSpecificDataFromDB("Reason", "TBL_FTS", "where id = " + HiddenEmpID.Value + "");
            if (getdate != upd_bussdate.Value)
            {
                cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " changed UA DATE of " + getemp + " from " + getdate + " to " + upd_bussdate.Value
                    + ". Date Filed: " + getfiledate + ".Reason: " + getreason + ".", "CHANGE", "UA", HiddenEmpID.Value, "UA", Session["EMP_ID"].ToString());
            }
            if (gettime != upd_time.Value)
            {
                cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " changed UA TIME of " + getemp + " from " + gettime + " to " + upd_time.Value
                    + ". Date Filed: " + getfiledate + ".Reason: " + getreason + ".", "CHANGE", "UA", HiddenEmpID.Value, "UA", Session["EMP_ID"].ToString());
            }
            if (getreason != upd_reason.Value)
            {
                cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " changed UA REASON of " + getemp + " from " + getreason + " to " + upd_reason
                    + ". Date Filed: " + getfiledate + ".Reason: " + getreason + ".", "CHANGE", "UA", HiddenEmpID.Value, "UA", Session["EMP_ID"].ToString());
            }
            if (gettype != upd_type.Value)
            {
                cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " changed UA TYPE of " + getemp + " from " + gettype + " to " + upd_type.Value
                    + ". Date Filed: " + getfiledate + ".Reason: " + getreason + ".", "CHANGE", "UA", HiddenEmpID.Value, "UA", Session["EMP_ID"].ToString());
            }
        }

        protected void btnsaveUpdate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];

            if (confirmValue == "Yes")
            {
                if (cm.ItemExist("TBL_FTS", "*", "where EmpID = '" + empno + "' and buss_date = '" + upd_bussdate.Value + "' and fts_type = '" + upd_type.Value + "' AND id != " + HiddenEmpID.Value + "", ""))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Duplicate entry not allowed.');", true);
                    return;

                }
                getdata();
                if (cm.UpdateQueryCommon(saveUpdateParam(), "TBL_FTS", "id = '" + HiddenEmpID.Value + "'"))
                {
                    addlogs();
                    //db_Emp.updateUserInfo(HiddenEmpID.Value, txtbox_username.Text, txtbox_password.Text, (drpdwn_acctstatus.SelectedValue == "1" ? true : false));
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully updated !!!');", true);
                    closeTransDetails();
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
            dis_bussdate.Value = cm.FormatDate(cm.GetSpecificDataFromDB("buss_date", "TBL_FTS", "where id = " + id + ""));
            dis_time.Value = cm.GetSpecificDataFromDB("ftime", "TBL_FTS", "where id = " + id + "");
            dis_type.Value = cm.GetSpecificDataFromDB("fts_type", "TBL_FTS", "where id = " + id + "");
            dis_Reason.Value = cm.GetSpecificDataFromDB("Reason", "TBL_FTS", "where id = " + id + "");
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
                getdate = cm.FormatDate(cm.GetSpecificDataFromDB("buss_date", "TBL_FTS", "where id = " + HiddenField1.Value + ""));
                getemp = cm.GetSpecificDataFromDB("FullName", "TBL_FTS", "where id = " + HiddenField1.Value + "");
                getfiledate = cm.FormatDate(cm.GetSpecificDataFromDB("DateFiled", "TBL_FTS", "where id = " + HiddenField1.Value + ""));
                if (cm.UpdateQueryCommon(saveDisapprove(), "TBL_FTS", "id = '" + HiddenField1.Value + "'"))
                {
                    ChangeFTSStatus(HiddenField1.Value, "3");
                    cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " Disapproved UA of " + getemp + "with DATE " + getdate + " and Type " +
                        gettype + ". Date Filed: " + getfiledate + ". Reason for Disapproval: " + dis_Reason2.Value + ".",
                            "DISAPPROVE", "UA", HiddenField1.Value, "UA", Session["EMP_ID"].ToString());
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
            Response.AddHeader("content-disposition", "attachment;filename= UA" + empno + ".xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Charset = "";
            this.EnableViewState = false;

            System.IO.StringWriter swriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlwriter = new System.Web.UI.HtmlTextWriter(swriter);

            DataGrid dg = new DataGrid();
            dg.DataSource = tk.populateGridFTS(empno);
            dg.DataBind();

            dg.RenderControl(htmlwriter);


            Response.Write(swriter.ToString());
            cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " exported UA",
            "EXPORT", "EMPLOYEE", Session["EMP_ID"].ToString(), "EMPLOYEE", Session["EMP_ID"].ToString());
            Response.End();
            //exportTOxlsx();


        }
    }
}