using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HRIS_APPELECTRIC.Pages.Admin.TK
{
    public partial class viewovertime : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Timekeeping tk = new Timekeeping();
        Common cm = new Common();
        public string empno = "";
        string empviewURL = "";
        public int gridtotalcount = 0;
        public string gridrangecount = "";
        string getdate, getin, getout, getreason,gethours, getfiledate;
        public Dictionary<string, string> empInfo = new Dictionary<string, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
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
                refresh();
            }
        }
        void refresh()
        {
            DataTable dt = new DataTable();
            dt = tk.populateGridOvertime(empno);
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
            string _status = ((TextBox)currentRow.FindControl("txtSearchOT_Status")).Text;
            string _datefiled = ((TextBox)currentRow.FindControl("txtSearchDateFiled")).Text;
            string _tripdate = ((TextBox)currentRow.FindControl("txtSearchOTDate")).Text;
            string _in = ((TextBox)currentRow.FindControl("txtSearchTimeIn")).Text;
            string _out = ((TextBox)currentRow.FindControl("txtSearchTimeOut")).Text;
            string _hours = ((TextBox)currentRow.FindControl("txtSearchTotalHours")).Text;
            string _reason = ((TextBox)currentRow.FindControl("txtSearchReason")).Text;
            string _approver1 = ((TextBox)currentRow.FindControl("txtSearchApprover1")).Text;
            string _dapproved1 = ((TextBox)currentRow.FindControl("txtSearchDapproved1")).Text;
            string _approver2 = ((TextBox)currentRow.FindControl("txtSearchApprover2")).Text;
            string _dapproved2 = ((TextBox)currentRow.FindControl("txtSearchDapproved2")).Text;
            string expr = emp.build_or_like_param(saveSearchParam(_status, _datefiled, _tripdate, _in, _out, _hours, _reason, _approver1, _dapproved1, _approver2, _dapproved2));
            //string expr = "and (license_type like '%" + lictype + "%' or license_no like '%" + licno + "%' or lic_expirydate like '%" + licdate + "%')";
            //GridViewList.DataSource = emp.populateGridSearch((DataTable)ViewState["EMP_GRID"], expr);
            GridViewList.DataSource = tk.populateGridOvertimeCol(empno, expr);
            GridViewList.DataBind();

            if (GridViewList.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('No Data Found !!!');", true);
                refresh();
            }

        }
        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow currentRow = (GridViewRow)((DropDownList)sender).Parent.Parent;
            string stat = ((DropDownList)currentRow.FindControl("ddlStat")).SelectedValue.ToString();
            string expr = emp.build_or_like_param(saveSearchParam1(stat));

            GridViewList.DataSource = tk.populateGridOvertimeCol(empno, expr);
            GridViewList.DataBind();

        }

        Dictionary<string, string> saveSearchParam1(string _status)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("ot_Status", "'%" + _status + "%'");


            return param;


        }
        Dictionary<string, string> saveSearchParam(string _status, string _datefiled, string _tripdate, string _in, string _out, string _hours, string _reason, string _approver1, string _dapproved1, string _approver2, string _dapproved2)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("ot_Status", "'%" + _status + "%'");
            if(_datefiled != "")
                param.Add("DateFiled", "'%" + Convert.ToDateTime(_datefiled).ToString("yyyy-MM-dd") + "%'");
            if (_tripdate != "")
                param.Add("OTDate", "'%" + Convert.ToDateTime(_tripdate).ToString("yyyy-MM-dd") + "%'");
            param.Add("ot_Time", "'%" + _in + "%'");
            if (_out != "")
                param.Add("ot_TimeOut", "'%" + Convert.ToDateTime(_out).ToString("yyyy-MM-dd") + "%'");
            param.Add("ot_Hours", "'%" + _hours + "%'");
            param.Add("Reason", "'%" + _reason + "%'");
            param.Add("Approver1", "'%" + _approver1 + "%'");
            if (_dapproved1 != "")
                param.Add("DateApproved1", "'%" + Convert.ToDateTime(_dapproved1).ToString("yyyy-MM-dd") + "%'");
            param.Add("Approver2", "'%" + _approver2 + "%'");
            if (_dapproved2 != "")
                param.Add("DateApproved2", "'%" + Convert.ToDateTime(_dapproved2).ToString("yyyy-MM-dd") + "%'");


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
                getdate = cm.FormatDate(cm.GetSpecificDataFromDB("OTDate", "TBL_OVERTIME", "where id = " + e.CommandArgument.ToString() + ""));
                getreason = cm.FormatDate(cm.GetSpecificDataFromDB("Reason", "TBL_OVERTIME", "where id = " + e.CommandArgument.ToString() + ""));
                getfiledate = cm.FormatDate(cm.GetSpecificDataFromDB("DateFiled", "TBL_OVERTIME", "where id = " + e.CommandArgument.ToString() + ""));
                emp.DeleteQuery("TBL_OVERTIME", "where id =" + e.CommandArgument.ToString() + "");
                cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " removed OT of " + emp.GetEmployeeName(empno) + " with DATE " + getdate +
                    ".Date Filed: " + getfiledate + ".Reason: " + getreason + ".", "DELETE", "x123", "qwg-23", "DELETE", Session["EMP_ID"].ToString());
                refresh();
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

            TimeSpan otTimeIn = TimeSpan.Parse(addTimeIn.Value);
            TimeSpan otTimeOut = TimeSpan.Parse(addTimeOut.Value);
            int i = TimeSpan.Compare(otTimeIn, otTimeOut);
            if (i == -1)
            {
                //if (cm.ItemExist("TBL_OVERTIME", "id", "where EmpID = '" + empno + "' and '" + addTimeIn.Value + "' BETWEEN ot_Time AND ot_TimeOut OR '" + addTimeOut.Value + "' BETWEEN ot_Time AND ot_TimeOut AND ot_Status = '1'", ""))
                //{
                //if (cm.ItemExist("TBL_OVERTIME", "id", "where EmpID = '" + empno + "' and OTDate = '" + Overtime_Date.Value + "' AND ot_Status = '1'", ""))
                //{
                //    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Duplicate overtime is not allowed.');", true);
                //    return;
                //}
                if ((datetoday.Date > bussDt.Date) && (datetoday.Date != bussDt.Date))
                {
                    string confirmValue = Request.Form["confirm_value"];
                    if (confirmValue.Contains("Yes"))
                    {
                        
                        if (cblOTInOut.Items[0].Selected == true || cblOTInOut.Items[1].Selected == true)
                        {
                            string ottype = "OUT";
                            ottype = cblOTInOut.Items[0].Selected == true ? "IN" : "OUT";
                            
                            if (cm.ItemExist("TBL_OVERTIME", "id", "where EmpID = '" + empno + "' and OTDate = '" + Overtime_Date.Value + "' AND ot_Status = '1' AND ot_Type = '"+ ottype + "'", ""))
                            {
                                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Duplicate overtime is not allowed.');", true);
                                return;
                            }
                            if (emp.InsertQueryCommon(saveParam(ottype), "TBL_OVERTIME"))
                            {

                                cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " created OT with DATE " + Overtime_Date.Value + " for " + emp.GetEmployeeName(empno) +
                                                ".Date Filed: " + cm.FormatDate(DateTime.Now) + ".Reason: " + getreason + ".", "CREATE", "x123", "qwg-23", "CREATE", Session["EMP_ID"].ToString());
                                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Save !!!');", true);
                                refresh();
                                Overtime_Reason.Value = "";
                                //otHrs.Value = "";
                                addTimeIn.Value = "17:00";
                                addTimeOut.Value = "18:00";
                                Overtime_Date.Value = "";
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('AM/PM Required.');", true);
                            cblOTInOut.Items[1].Selected = true;


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
            

        
        

        Dictionary<string, string> saveParam(string ot_Type)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            List<string> approver = new List<string>();
            param.Add("EmpID", empno);
            param.Add("OTDate", "'" + Overtime_Date.Value + "'");
            param.Add("ot_Time", "'" + addTimeIn.Value + "'");
            param.Add("ot_TimeOut", "'" + addTimeOut.Value + "'");
            param.Add("Reason", "'" + Overtime_Reason.Value + "'");
            param.Add("ot_Type", "'" + ot_Type + "'");

            //try
            //{
            if (Session["ROLES"].ToString() == "admin")
            {
                param.Add("ot_Status", "'1'");

            }
            else
            {
                param.Add("Approver1", "'" + empInfo["emp_Approver1"] + "'");
                param.Add("Approver2", "'" + empInfo["emp_Approver2"] + "'");
                param.Add("Approving", "'" + empInfo["emp_Approver1"] + "'");
                param.Add("ot_Status", "'2'");
            }
            //}
            //catch
            //{
            //    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Session Expired.');", true);
            //    Response.Redirect("~/Pages/Login.aspx");
            //}

            param.Add("ot_hours", "" + get_OT_Hours(addTimeIn.Value, addTimeOut.Value) + "");
            //param.Add("ot_hours", "" + otHrs.Value + "");
            param.Add("FullName", "'" + empInfo["emp_FullName"] + "'");
            param.Add("DateFiled", "'" + cm.FormatDateyyyy(DateTime.Now) + "'");
            param.Add("DateApproved", "'" + cm.FormatDateyyyy(DateTime.Now) + "'");

            return param;


        }

        Dictionary<string, string> saveUpdateParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("OTDate", "'" + upd_OTDate.Value + "'");

            param.Add("ot_Time", "'" + upd_in.Value + "'");
            param.Add("ot_TimeOut", "'" + upd_out.Value + "'");
            param.Add("Reason", "'" + upd_Reason.Value + "'");
            param.Add("ot_hours", "" + get_OT_Hours(upd_in.Value, upd_out.Value) + "");
            //param.Add("ot_hours", "" + upd_hours + "");

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
            //otHrs.Value = "";
            addTimeIn.Value = "";
            addTimeOut.Value = "";
            Overtime_Date.Value = "";

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
            upd_OTDate.Value = cm.FormatDateyyyy(cm.GetSpecificDataFromDB("OTDate", "TBL_OVERTIME", "where id = " + id + ""));
            //upd_hours.Value = cm.GetSpecificDataFromDB("ot_hours", "TBL_OVERTIME", "where id = " + id + "");
            upd_in.Value = cm.GetSpecificDataFromDB("ot_Time", "TBL_OVERTIME", "where id = " + id + "");
            upd_out.Value = cm.GetSpecificDataFromDB("ot_TimeOut", "TBL_OVERTIME", "where id = " + id + "");
            upd_Reason.Value = cm.GetSpecificDataFromDB("Reason", "TBL_OVERTIME", "where id = " + id + "");
        }
        protected void lnkbtnXlist_Click(object sender, EventArgs e)
        {
            closeTransDetails();
        }

        private void getdata()
        {
            getdate = cm.FormatDate(cm.GetSpecificDataFromDB("OTDate", "TBL_OVERTIME", "where id = " + HiddenEmpID.Value + ""));
            //gethours = cm.GetSpecificDataFromDB("ot_hours", "TBL_OVERTIME", "where id = " + HiddenEmpID.Value + "");
            getin = cm.GetSpecificDataFromDB("ot_Time", "TBL_OVERTIME", "where id = " + HiddenEmpID.Value + "");
            getout = cm.GetSpecificDataFromDB("ot_TimeOut", "TBL_OVERTIME", "where id = " + HiddenEmpID.Value + "");
            getreason = cm.GetSpecificDataFromDB("Reason", "TBL_OVERTIME", "where id = " + HiddenEmpID.Value + "");
        }

        private void addlogs()
        {
            if (getdate != upd_OTDate.Value)
            {
                cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " changed OT DATE for " + emp.GetEmployeeName(empno) + " from " + getdate + " to " + upd_OTDate.Value +
                    ".Date Filed: " + getfiledate + ".Reason: " + getreason + ".", "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getin != upd_in.Value)
            {
                cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " changed OT TIME IN for " + emp.GetEmployeeName(empno) + " from " + getin + " to " + upd_in.Value +
                    ".Date Filed: " + getfiledate + ".Reason: " + getreason + ".", "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getout != upd_out.Value)
            {
                cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " changed OT TIME OUT for " + emp.GetEmployeeName(empno) + " from " + getout + " to " + upd_out.Value +
                    ".Date Filed: " + getfiledate + ".Reason: " + getreason + ".", "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getreason != upd_Reason.Value)
            {
                cm.AddLog("User " + Session["FULLNAME"].ToString().ToUpper() + " changed OT REASON for " + emp.GetEmployeeName(empno) + " from " + getreason + " to " + upd_Reason.Value +
                    ".Date Filed: " + getfiledate + ".Reason: " + getreason + ".", "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
        }

        protected void btnsaveUpdate_Click(object sender, EventArgs e)
        {
            DateTime updbussDt = Convert.ToDateTime(upd_OTDate.Value);
            DateTime upddatetoday = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Taipei Standard Time");

            TimeSpan updotTimeIn = TimeSpan.Parse(upd_in.Value);
            TimeSpan updotTimeOut = TimeSpan.Parse(upd_out.Value);
            if (cm.ItemExist("TBL_OVERTIME", "id", "where EmpID = '" + empno + "' and OTDate =  '" + upd_OTDate.Value + "' AND ot_Status = '1' AND id != " + HiddenEmpID.Value + "", ""))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Duplicate overtime is not allowed.');", true);
                return;
            }
            int i = TimeSpan.Compare(updotTimeIn, updotTimeOut);
            if (i == -1)
            {
                if ((upddatetoday.Date > updbussDt.Date) && (upddatetoday.Date != updbussDt.Date))
                {
                    string confirmValue = Request.Form["confirm_value"];

                    if (confirmValue == "Yes")
                    {
                        getdata();
                        if (cm.UpdateQueryCommon(saveUpdateParam(), "TBL_OVERTIME", "id = '" + HiddenEmpID.Value + "'"))
                        {
                            addlogs();
                            //db_Emp.updateUserInfo(HiddenEmpID.Value, txtbox_username.Text, txtbox_password.Text, (drpdwn_acctstatus.SelectedValue == "1" ? true : false));
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully updated.');", true);
                            closeTransDetails();
                            refresh();
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
            dg.DataSource = tk.populateGridOvertime(empno);
            dg.DataBind();

            dg.RenderControl(htmlwriter);


            Response.Write(swriter.ToString());
            cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " exported OVERTIME",
            "EXPORT", "TIMEKEEPING", Session["EMP_ID"].ToString(), "TIMEKEEPING", Session["EMP_ID"].ToString());
            Response.End();
            //exportTOxlsx();


        }
    }
}