﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HRIS_APPELECTRIC.Pages.Admin.TK
{
    public partial class viewleaves : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Timekeeping tk = new Timekeeping();
        Common cm = new Common();
        public string empno = "";
        string empviewURL = "";
        public int gridtotalcount = 0;
        public string gridrangecount = "";
        string getleave, getallowed, getrem, getact, getexp;
        protected void Page_Load(object sender, EventArgs e)
        {
            empno = Request.QueryString["id"];

            if (!IsPostBack)
            {
                Leave_LeaveType.Items.AddRange(emp.GetDropDownMenuList("TBL_LEAVETYPE", "LeaveTypeDesc"));
                upd_leavetype.Items.AddRange(emp.GetDropDownMenuList("TBL_LEAVETYPE", "LeaveTypeDesc"));
                upd_leavetype.DataValueField = emp.GetDropDownMenuList("TBL_LEAVETYPE", "id").ToString();
                refresh();
            }
        }
        void refresh()
        {
            DataTable dt = new DataTable();
            dt = tk.populateGridLeaves(empno);
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
        public string getname()
        {
            string name = "";
            name = emp.GetEmployeeName(empno);

            return name;

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
            string _leavetype = ((TextBox)currentRow.FindControl("txtSearchLeavetype")).Text;
            string _earned = ((TextBox)currentRow.FindControl("txtSearchEarned")).Text;
            string _used = ((TextBox)currentRow.FindControl("txtSearchUsed")).Text;
            string _remaining = ((TextBox)currentRow.FindControl("txtSearchRemaining")).Text;
            string _expiry = ((TextBox)currentRow.FindControl("txtSearchExpiry")).Text;
            string expr = emp.build_or_like_param(saveSearchParam(_leavetype, _earned, _used, _remaining, _expiry));
            //string expr = "and (license_type like '%" + lictype + "%' or license_no like '%" + licno + "%' or lic_expirydate like '%" + licdate + "%')";
            //GridViewList.DataSource = emp.populateGridSearch((DataTable)ViewState["EMP_GRID"], expr);
            

            DataTable dt = new DataTable();
            dt = tk.populateGridLeavesCol(empno, expr);
            GridViewList.DataSource = dt;
            GridViewList.DataBind();
            ViewState["EMP_GRID"] = dt;
            ViewState["SORTDR"] = null;
            summary();
        }

        Dictionary<string, string> saveSearchParam(string _leavetype, string _earned, string _used, string _remaining, string _expiry)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();

            param.Add("B.LeaveTypeDesc", "'%" + _leavetype + "%'");
            param.Add("A.Allowed", "'%" + _earned + "%'");
            param.Add("A.Remaining", "'%" + _remaining + "%'");
            param.Add("A.Used", "'%" + _used + "%'");
            param.Add("A.Expiry", "'%" + cm.FormatDateyyyy(_expiry) + "%'");


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
            if (e.CommandName == "del")
            {
                getleave = cm.GetSpecificDataFromDB("LeaveType", "TBL_LEAVES", "where id = " + e.CommandArgument.ToString() + "");
                emp.DeleteQuery("TBL_LEAVES", "where id =" + e.CommandArgument.ToString() + "");
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " removed LEAVE " + getleave + " for " + emp.GetEmployeeName(empno),
                        "DELETE", "LEAVES", Session["EMP_ID"].ToString(), "LEAVES", Session["EMP_ID"].ToString());
                refresh();
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Successfully Deleted');",
                true);

            }
            if (e.CommandName == "upd")
            {
                HiddenEmpID.Value = e.CommandArgument.ToString();
                populateUpdateField(e.CommandArgument.ToString());
                openTransDetails(empno);
            }
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                //06/09/2022 Jan Wong
                string getempregdate = ""; DateTime dtregdate = new DateTime();
                getempregdate = cm.GetSpecificDataFromDB("emp_RegularizationDate", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + empno + "'");
                bool isvalidregdate = DateTime.TryParse(getempregdate, out dtregdate);
                DateTime dtregdateplusyearnow = new DateTime(cm.dtnow().Year, dtregdate.Month, dtregdate.Day);
                int counter = 1;
                while(dtregdateplusyearnow.Date <= cm.dtnow().Date)
                {
                    dtregdateplusyearnow = dtregdateplusyearnow.AddYears(counter);
                    counter++;
                }
                
                if (getempregdate == "" || !isvalidregdate)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Please set employee regularization date.');", true);
                    return;
                }
                //06/09/2022 Jan Wong End 
                if (!(cm.ItemExist("TBL_LEAVES","*"," where LeaveType = '"+ Leave_LeaveType.SelectedValue+ "' AND EmpID = '"+empno+"'","")))
                { 
                    if (emp.InsertQueryCommon(saveParam(dtregdate), "TBL_LEAVES"))
                    {
                        cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " created " + Leave_LeaveType.SelectedItem.Text + " for " + emp.GetEmployeeName(empno),
                                "CREATE", "LEAVES", Session["EMP_ID"].ToString(), "LEAVES", Session["EMP_ID"].ToString());
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Save !!!');", true);
                        refresh();
                        reset();
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Duplicate leave is not allowed.');", true);
                    return;

                }
            }
        }

        Dictionary<string, string> saveParam(DateTime dtregdate)
        {
            double used = Convert.ToDouble(Leave_Allowed.Value) - Convert.ToDouble(Leave_Remaining.Value);
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("LeaveType", "'" + Leave_LeaveType.SelectedValue + "'");
            param.Add("Allowed", "'" + Leave_Allowed.Value + "'");
            param.Add("Remaining", "'" + Leave_Remaining.Value + "'");
            param.Add("Used", used.ToString());
            //param.Add("Expiry", "'" + Expiry.Value + "'");
            param.Add("Expiry", "'" + cm.FormatDate(dtregdate) + "'");//06/09/2022 Jan Wong
            param.Add("Activated", "'" + Leave_Activated.Value + "'");

            param.Add("EmpID", "'" + empno + "'");

            return param;


        }

        Dictionary<string, string> saveUpdateParam()
        {
            double used = Convert.ToDouble(upd_allowed.Value) - Convert.ToDouble(upd_remaining.Value);
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("LeaveType", "'" + upd_leavetype.SelectedValue + "'");
            param.Add("Allowed", "'" + upd_allowed.Value + "'");
            param.Add("Remaining", "'" + upd_remaining.Value + "'");
            param.Add("Used", used.ToString());
            //param.Add("Expiry", "'" + upd_expirydt.Value + "'");
            param.Add("Activated", "'" + upd_activated.Value + "'");

            param.Add("EmpID", "'" + empno + "'");

            return param;


        }

        void reset()
        {
            Leave_Activated.SelectedIndex = 0;
            Leave_Allowed.Value = "";
            Leave_LeaveType.SelectedValue = "";
            Leave_Remaining.Value = "";
            //Expiry.Value = "";

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

        public void populateUpdateField(string id)
        {
            string bd;
            upd_leavetype.SelectedValue = cm.GetSpecificDataFromDB("LeaveType", "TBL_LEAVES", "where id = " + id + "");
            upd_allowed.Value = cm.GetSpecificDataFromDB("Allowed", "TBL_LEAVES", "where id = " + id + "");
            upd_remaining.Value = cm.GetSpecificDataFromDB("Remaining", "TBL_LEAVES", "where id = " + id + "");
            upd_activated.Value = cm.GetSpecificDataFromDB("Activated", "TBL_LEAVES", "where id = " + id + "");
            //upd_expirydt.Value = cm.FormatDateyyyy(cm.GetSpecificDataFromDB("Expiry", "TBL_LEAVES", "where id = " + id + ""));
        }
        protected void lnkbtnXlist_Click(object sender, EventArgs e)
        {
            closeTransDetails();
        }

        private void getdata()
        {
            getleave = cm.GetSpecificDataFromDB("LeaveType", "TBL_LEAVES", "where id = " + HiddenEmpID.Value + "");
            getallowed = cm.GetSpecificDataFromDB("Allowed", "TBL_LEAVES", "where id = " + HiddenEmpID.Value + "");
            getrem = cm.GetSpecificDataFromDB("Remaining", "TBL_LEAVES", "where id = " + HiddenEmpID.Value + "");
            getact = cm.GetSpecificDataFromDB("Activated", "TBL_LEAVES", "where id = " + HiddenEmpID.Value + "");
            getexp = cm.FormatDate(cm.GetSpecificDataFromDB("Expiry", "TBL_LEAVES", "where id = " + HiddenEmpID.Value + ""));
        }

        private void addlogs()
        {
            if (getleave != upd_leavetype.SelectedValue)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Leave TYPE for " + emp.GetEmployeeName(empno) + " from " + getleave + " to " + upd_leavetype.SelectedValue,
                    "CHANGE", "LEAVES", Session["EMP_ID"].ToString(), "LEAVES", Session["EMP_ID"].ToString());
            }
            if (getallowed != upd_allowed.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Leave ALLOWED for " + emp.GetEmployeeName(empno) + " from " + getallowed + " to " + upd_allowed.Value,
                    "CHANGE", "LEAVES", Session["EMP_ID"].ToString(), "LEAVES", Session["EMP_ID"].ToString());
            }
            if (getrem != upd_remaining.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Leave REMAINING for " + emp.GetEmployeeName(empno) + " from " + getrem + " to " + upd_remaining.Value,
                    "CHANGE", "LEAVES", Session["EMP_ID"].ToString(), "LEAVES", Session["EMP_ID"].ToString());
            }
            if (getact != upd_activated.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Leave ACTIVATED for " + emp.GetEmployeeName(empno) + " from " + getact + " to " + upd_activated.Value,
                    "CHANGE", "LEAVES", Session["EMP_ID"].ToString(), "LEAVES", Session["EMP_ID"].ToString());
            }
            //if (getexp != upd_expirydt.Value)
            //{
            //    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Leave EXPIRY DATE for " + emp.GetEmployeeName(empno) + " from " + getexp + " to " + upd_expirydt.Value,
            //        "CHANGE", "LEAVES", Session["EMP_ID"].ToString(), "LEAVES", Session["EMP_ID"].ToString());
            //}
        }

        protected void btnsaveUpdate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                

                if (!(cm.ItemExist("TBL_LEAVES", "*", " where LeaveType = '" + upd_leavetype.SelectedValue + "' AND EmpID = '" + empno + "' AND id != "+HiddenEmpID.Value+"", "")))
                {
                    getdata();
                    if (cm.UpdateQueryCommon(saveUpdateParam(), "TBL_LEAVES", "id = '" + HiddenEmpID.Value + "'"))
                    {
                        addlogs();
                        //db_Emp.updateUserInfo(HiddenEmpID.Value, txtbox_username.Text, txtbox_password.Text, (drpdwn_acctstatus.SelectedValue == "1" ? true : false));
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully updated !!!');", true);
                        closeTransDetails();
                        refresh();
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Duplicate leave is not allowed.');", true);
                }
                
            }
            else
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Fields should not be empty !!!');", true);
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("content-disposition", "attachment;filename= Leaves" + empno + ".xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Charset = "";
            this.EnableViewState = false;

            System.IO.StringWriter swriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlwriter = new System.Web.UI.HtmlTextWriter(swriter);

            DataGrid dg = new DataGrid();
            dg.DataSource = tk.populateGridLeaves(empno);
            dg.DataBind();

            dg.RenderControl(htmlwriter);


            Response.Write(swriter.ToString());
            cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " exported Leaves",
            "EXPORT", "TIMEKEEPING", Session["EMP_ID"].ToString(), "TIMEKEEPING", Session["EMP_ID"].ToString());
            Response.End();
            //exportTOxlsx();


        }
    }
}