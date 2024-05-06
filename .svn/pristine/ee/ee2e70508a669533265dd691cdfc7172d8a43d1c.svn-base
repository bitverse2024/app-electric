using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

namespace HRIS_APPELECTRIC.Pages.Admin.Employees._201
{
    public partial class viewhistory : System.Web.UI.Page
    {
        Employee emp = new Employee();
        public string empno = "";
        public string id = "";
        string empviewURL = "";
        public int gridtotalcount = 0;
        public string gridrangecount = "";
        Common cm = new Common();
        string getfromdate, gettodate, getcomp, getpos, getdnr, getrfleaving, getprev, gethyear,
            getn13, getdem, getcon, getncomp, getbasic, gett13, gettcomp;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ROLES"].ToString() != "admin" && Session["ROLES"].ToString() != "employee")
            {
                Response.Redirect("~/Pages/Login.aspx");
            }
            empno = Request.QueryString["id"];
            if (empno != Session["ACTIVE_EMPNO"].ToString())
            {

                empno = Session["ACTIVE_EMPNO"].ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Injection not allowed!!!');window.location ='viewhistory.aspx?id=" + empno + "';",
                true);
            }
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
            DataTable dt = new DataTable();
            dt = emp.populateGridEmployment(empno);
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
        protected void txtFromDate_TextChanged(object sender, EventArgs e)
        {
            //awong-retrieve textbox values from the grid control during runtime.
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
            string s_fromdate = ((TextBox)currentRow.FindControl("txtFromDate")).Text;
            string s_todate = ((TextBox)currentRow.FindControl("txtToDate")).Text;
            string s_company = ((TextBox)currentRow.FindControl("txtCompany")).Text;
            string s_postion = ((TextBox)currentRow.FindControl("txtPosition")).Text;

            string expr = emp.build_or_like_param(saveSearchParam(s_fromdate, s_todate, s_company, s_postion));
            //string expr = "and (license_type like '%" + lictype + "%' or license_no like '%" + licno + "%' or lic_expirydate like '%" + licdate + "%')";
            //GridViewList.DataSource = emp.populateGridSearch((DataTable)ViewState["EMP_GRID"], expr);
            GridViewList.DataSource = emp.populateGridEmploymentCol(empno, expr);
            GridViewList.DataBind();
        }
        Dictionary<string, string> saveSearchParam(string s_fromdate, string s_todate, string s_company, string s_postion)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("From_Date", "'%" + s_fromdate + "%'");
            param.Add("To_Date", "'%" + s_todate + "%'");
            param.Add(Company.ID, "'%" + s_company + "%'");
            param.Add(Position.ID, "'%" + s_postion + "%'");
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
            if (e.CommandName == "view")
            {
                HiddenEmpID.Value = e.CommandArgument.ToString();
                populateUpdateField(e.CommandArgument.ToString());
                populateViewField(e.CommandArgument.ToString());
                openTransDetailsView(empno);

            }
            if (e.CommandName == "upd")
            {
                HiddenEmpID.Value = e.CommandArgument.ToString();
                populateUpdateField(e.CommandArgument.ToString());
                openTransDetails(empno);
            }
            if (e.CommandName == "del")
            {
                getcomp = cm.GetSpecificDataFromDB("Company", "TBL_EHISTORY", "where id = " + e.CommandArgument + "");
                emp.DeleteQuery("TBL_EHISTORY", "where id =" + e.CommandArgument.ToString() + "");
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " removed EMPLOYMENT HISTORY with COMPANY:" + getcomp + " for " + emp.GetEmployeeName(empno),
                    "DELETE", "x123", "qwg-23", "DELETE", Session["EMP_ID"].ToString());
                refresh();
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Successfully Deleted');",
                true);

            }
        }
        public void closeTransDetails()
        {
            upEmpHistory.Update();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(string.Format(@"$('#{0}').modal('hide')", "listmodal"));
            sb.Append(@"</script>");

            ScriptManager.RegisterStartupScript(this, this.GetType(), "listmodal", sb.ToString(), false);

        }
        public void openTransDetails(string empNo)
        {
            upEmpHistory.Update();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(string.Format(@"$('#{0}').modal('show')", "listmodal"));
            sb.Append(@"</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "listmodal", sb.ToString(), false);
            string divname = "";
        }
        public void populateUpdateField(string id)
        {
            upd_FromDate.Value = cm.GetSpecificDataFromDB("From_Date", "TBL_EHISTORY", "where id = " + id + "");
            upd_ToDate.Value = cm.GetSpecificDataFromDB("To_Date", "TBL_EHISTORY", "where id = " + id + "");
            upd_Company.Value = cm.GetSpecificDataFromDB("Company", "TBL_EHISTORY", "where id = " + id + "");
            upd_Position.Value = cm.GetSpecificDataFromDB("Position", "TBL_EHISTORY", "where id = " + id + "");
            upd_DNR.Value = cm.GetSpecificDataFromDB("DNR", "TBL_EHISTORY", "where id = " + id + "");
            upd_RFLeaving.Value = cm.GetSpecificDataFromDB("RFLeaving", "TBL_EHISTORY", "where id = " + id + "");
            getprev = cm.GetSpecificDataFromDB("Previous", "TBL_EHISTORY", "where id = " + id + "");
            if (getprev == "1")
            {
                upd_Previous.Checked = true;
            }
            else
            {
                upd_Previous.Checked = false;
            }
            upd_HYear.Value = cm.GetSpecificDataFromDB("HYear", "TBL_EHISTORY", "where id = " + id + "");
            upd_NThirteenth.Value = cm.GetSpecificDataFromDB("NThirteenth", "TBL_EHISTORY", "where id = " + id + "");
            upd_Deminimis.Value = cm.GetSpecificDataFromDB("Deminimis", "TBL_EHISTORY", "where id = " + id + "");
            upd_Contributions.Value = cm.GetSpecificDataFromDB("Contributions", "TBL_EHISTORY", "where id = " + id + "");
            upd_NCompensations.Value = cm.GetSpecificDataFromDB("NCompensations", "TBL_EHISTORY", "where id = " + id + "");
            upd_Basic.Value = cm.GetSpecificDataFromDB("Basic", "TBL_EHISTORY", "where id = " + id + "");
            upd_TThirteenth.Value = cm.GetSpecificDataFromDB("TThirteenth", "TBL_EHISTORY", "where id = " + id + "");
            upd_TCompensations.Value = cm.GetSpecificDataFromDB("TCompensations", "TBL_EHISTORY", "where id = " + id + "");

        }
        public void openTransDetailsView(string empNo)
        {
            upListDetails2.Update();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(string.Format(@"$('#{0}').modal('show')", "ViewModal"));
            sb.Append(@"</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ViewModal", sb.ToString(), false);
            string divname = "";

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
        protected void lnkbtnXlistView_Click(object sender, EventArgs e)
        {
            closeTransDetailsView();
        }
        public void populateViewField(string id)
        {
            vw_FromDate.Value = upd_FromDate.Value;
            vw_ToDate.Value = upd_ToDate.Value;
            vw_Company.Value = upd_Company.Value;
            vw_Position.Value = upd_Position.Value;
            vw_Company.Value = upd_Company.Value;
            vw_DNR.Value = upd_DNR.Value;
            vw_RFLeaving.Value = upd_RFLeaving.Value;
            if (getprev == "1")
            {
                vw_Previous.Checked = true;
            }
            else
            {
                vw_Previous.Checked = false;
            }
            vw_HYear.Value = upd_HYear.Value;
            vw_NThirteenth.Value = upd_NThirteenth.Value;
            vw_Deminimis.Value = upd_Deminimis.Value;
            vw_Contributions.Value = upd_Contributions.Value;
            vw_NCompensations.Value = upd_NCompensations.Value;
            vw_Basic.Value = upd_Basic.Value;
            vw_TThirteenth.Value = upd_TThirteenth.Value;
            vw_TCompensations.Value = upd_TCompensations.Value;

        }
        protected void lnkbtnXlist_Click(object sender, EventArgs e)
        {
            closeTransDetails();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {

            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                string dateFrom = txtFrom_Date.Value;
                string dateTo = txtTo_Date.Value;
                bool IsDateAllowedToBeFiled = false;
                var formats = new string[] { "MM-dd-yyyy", "MM/dd/yyyy" };
                DateTime dtIn = new DateTime(), dtOut = new DateTime();
                bool validDate = (DateTime.TryParseExact(dateFrom, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dtIn) &&
                    DateTime.TryParseExact(dateTo, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dtOut));
                if (dtIn <= dtOut)
                {
                    IsDateAllowedToBeFiled = true;

                }
                if (IsDateAllowedToBeFiled == true)
                {

                    if (emp.InsertQueryCommon(saveParam(), "TBL_EHISTORY"))
                    {
                        cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " created EMPLOYMENT HISTORY with COMPANY: " + Company.Value + " for " + emp.GetEmployeeName(empno),
                                        "CREATE", "x123", "qwg-23", "CREATE", Session["EMP_ID"].ToString());
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Save !!!');", true);
                        refresh();
                        txtFrom_Date.Value = "";
                        txtTo_Date.Value = "";
                        Company.Value = "";
                        Position.Value = "";
                        DNR.Value = "";
                        RFLeaving.Value = "";
                        Previous.Checked = false;
                        NThirteenth.Value = "";
                        Deminimis.Value = "";
                        NCompensations.Value = "";
                        Basic.Value = "";
                        TThirteenth.Value = "";
                        TCompensations.Value = "";
                        Contributions.Value = "";
                        HYear.Value = "";
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Please check Date');", true);
                    refresh();
                }
            }
        }

        Dictionary<string, string> saveParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("From_Date", "'" + cm.FormatDate(txtFrom_Date.Value) + "'");
            param.Add("To_Date", "'" + cm.FormatDate(txtTo_Date.Value) + "'");
            param.Add(Company.ID, "'" + Company.Value + "'");
            param.Add(Position.ID, "'" + Position.Value + "'");
            param.Add(DNR.ID, "'" + DNR.Value + "'");
            param.Add(RFLeaving.ID, "'" + RFLeaving.Value + "'");
            param.Add(Previous.ID, (Previous.Checked ? "'1'" : "'0'"));
            param.Add(NThirteenth.ID, "'" + NThirteenth.Value + "'");
            param.Add(Deminimis.ID, "'" + Deminimis.Value + "'");
            param.Add(NCompensations.ID, "'" + NCompensations.Value + "'");
            param.Add(Basic.ID, "'" + Basic.Value + "'");
            param.Add(TThirteenth.ID, "'" + TThirteenth.Value + "'");
            param.Add(TCompensations.ID, "'" + TCompensations.Value + "'");
            param.Add(Contributions.ID, "'" + Contributions.Value + "'");
            param.Add(HYear.ID, "'" + HYear.Value + "'");
            param.Add("IDate", "'" + txtFrom_Date.Value + "-" + txtTo_Date.Value + "'");
            param.Add("EmpID", "'" + empno + "'");

            return param;
        }
        Dictionary<string, string> saveUpdateParam()
        {
            var formats = new string[] {"MM/dd/yyyy" };
            DateTime fromdate = DateTime.ParseExact(upd_FromDate.Value, formats, CultureInfo.CurrentCulture, DateTimeStyles.None);
            DateTime todate = DateTime.ParseExact(upd_ToDate.Value, formats, CultureInfo.CurrentCulture, DateTimeStyles.None);
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("From_Date", "'" + cm.FormatDate(fromdate.ToString()) + "'");
            param.Add("To_Date", "'" + cm.FormatDate(todate.ToString()) + "'");
            param.Add(Company.ID, "'" + upd_Company.Value + "'");
            param.Add(Position.ID, "'" + upd_Position.Value + "'");
            param.Add(DNR.ID, "'" + upd_DNR.Value + "'");
            param.Add(RFLeaving.ID, "'" + upd_RFLeaving.Value + "'");
            param.Add(Previous.ID, (upd_Previous.Checked ? "'1'" : "'0'"));
            param.Add(NThirteenth.ID, "'" + upd_NThirteenth.Value + "'");
            param.Add(Deminimis.ID, "'" + upd_Deminimis.Value + "'");
            param.Add(NCompensations.ID, "'" + upd_NCompensations.Value + "'");
            param.Add(Basic.ID, "'" + upd_Basic.Value + "'");
            param.Add(TThirteenth.ID, "'" + upd_TThirteenth.Value + "'");
            param.Add(TCompensations.ID, "'" + upd_TCompensations.Value + "'");
            param.Add(Contributions.ID, "'" + upd_Contributions.Value + "'");
            param.Add(HYear.ID, "'" + upd_HYear.Value + "'");
            param.Add("IDate", "'" + cm.FormatDate(upd_FromDate.Value) + "-" + cm.FormatDate(upd_ToDate.Value) + "'");
            param.Add("EmpID", "'" + empno + "'");

            return param;
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtFrom_Date.Value = "";
            txtTo_Date.Value = "";
            Company.Value = "";
            Position.Value = "";
            DNR.Value = "";
            RFLeaving.Value = "";
            Previous.Checked = false;
            NThirteenth.Value = "";
            Deminimis.Value = "";
            NCompensations.Value = "";
            Basic.Value = "";
            TThirteenth.Value = "";
            TCompensations.Value = "";
            Contributions.Value = "";
            HYear.Value = "";
        }

        private void getdata()
        {
            getfromdate = cm.GetSpecificDataFromDB("From_Date", "TBL_EHISTORY", "where id = " + HiddenEmpID.Value + "");
            gettodate = cm.GetSpecificDataFromDB("To_Date", "TBL_EHISTORY", "where id = " + HiddenEmpID.Value + "");
            getcomp = cm.GetSpecificDataFromDB("Company", "TBL_EHISTORY", "where id = " + HiddenEmpID.Value + "");
            getpos = cm.GetSpecificDataFromDB("Position", "TBL_EHISTORY", "where id = " + HiddenEmpID.Value + "");
            getdnr = cm.GetSpecificDataFromDB("DNR", "TBL_EHISTORY", "where id = " + HiddenEmpID.Value + "");
            getrfleaving = cm.GetSpecificDataFromDB("RFLeaving", "TBL_EHISTORY", "where id = " + HiddenEmpID.Value + "");
            getprev = cm.GetSpecificDataFromDB("Previous", "TBL_EHISTORY", "where id = " + HiddenEmpID.Value + "");
            gethyear = cm.GetSpecificDataFromDB("HYear", "TBL_EHISTORY", "where id = " + HiddenEmpID.Value + "");
            getn13 = cm.GetSpecificDataFromDB("NThirteenth", "TBL_EHISTORY", "where id = " + HiddenEmpID.Value + "");
            getdem = cm.GetSpecificDataFromDB("Deminimis", "TBL_EHISTORY", "where id = " + HiddenEmpID.Value + "");
            getcon = cm.GetSpecificDataFromDB("Contributions", "TBL_EHISTORY", "where id = " + HiddenEmpID.Value + "");
            getncomp = cm.GetSpecificDataFromDB("NCompensations", "TBL_EHISTORY", "where id = " + HiddenEmpID.Value + "");
            getbasic = cm.GetSpecificDataFromDB("Basic", "TBL_EHISTORY", "where id = " + HiddenEmpID.Value + "");
            gett13 = cm.GetSpecificDataFromDB("TThirteenth", "TBL_EHISTORY", "where id = " + HiddenEmpID.Value + "");
            gettcomp = cm.GetSpecificDataFromDB("TCompensations", "TBL_EHISTORY", "where id = " + HiddenEmpID.Value + "");
        }

        private void addlog()
        {
            if (getfromdate != upd_FromDate.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employment History FROM DATE for " + emp.GetEmployeeName(empno) + " from " + getfromdate + " to " + upd_FromDate.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (gettodate != upd_ToDate.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employment History TO DATE for " + emp.GetEmployeeName(empno) + " from " + gettodate + " to " + upd_ToDate.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getcomp != upd_Company.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employment History COMPANY for " + emp.GetEmployeeName(empno) + " from " + getcomp + " to " + upd_Company.Value,
                   "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getpos != upd_Position.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employment History POSITION for " + emp.GetEmployeeName(empno) + " from " + getpos + " to " + upd_Position.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getdnr != upd_DNR.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employment History DUTIES AND RESPONSIBILITIES for " + emp.GetEmployeeName(empno) + " from " + getdnr + " to " + upd_DNR.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getrfleaving != upd_RFLeaving.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employment History REASON FOR LEAVING for " + emp.GetEmployeeName(empno) + " from " + getrfleaving + " to " + upd_RFLeaving.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getprev == "1")
            {
                if (upd_Previous.Checked == false)
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employment History PREVIOUS for " + emp.GetEmployeeName(empno) + " from " + getprev + " to 0",
                        "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
                }
            }
            if (getprev == "0")
            {
                if (upd_Previous.Checked == true)
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employment History PREVIOUS for " + emp.GetEmployeeName(empno) + " from " + getprev + " to 1",
                        "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
                }
            }
            if (gethyear != upd_HYear.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employment History YEAR for " + emp.GetEmployeeName(empno) + " from " + gethyear + " to " + upd_HYear.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getn13 != upd_NThirteenth.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employment History NON-TAXABLE 13TH MONTH PAY for " + emp.GetEmployeeName(empno) + " from " + getn13 + " to " + upd_NThirteenth.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getdem != upd_Deminimis.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employment History DEMINIMIS for " + emp.GetEmployeeName(empno) + " from " + getdem + " to " + upd_Deminimis.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getcon != upd_Contributions.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employment History CONTRIBUTIONS for " + emp.GetEmployeeName(empno) + " from " + getcon + " to " + upd_Contributions.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getncomp != upd_NCompensations.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employment History NON-TAXABLE COMPENSATIONS for " + emp.GetEmployeeName(empno) + " from " + getncomp + " to " + upd_NCompensations.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getbasic != upd_Basic.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employment History BASIC PAY for " + emp.GetEmployeeName(empno) + " from " + getbasic + " to " + upd_Basic.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (gett13 != upd_TThirteenth.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employment History TAXABLE 13TH MONTH PAY for " + emp.GetEmployeeName(empno) + " from " + gett13 + " to " + upd_TThirteenth.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (gettcomp != upd_TCompensations.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employment History TAXABLE COMPENSATIONS for " + emp.GetEmployeeName(empno) + " from " + gettcomp + " to " + upd_TCompensations.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                getdata();
                if (cm.UpdateQueryCommon(saveUpdateParam(), "TBL_EHISTORY", "id = '" + HiddenEmpID.Value + "'"))
                {
                    addlog();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Updated !!!');", true);
                    upd_FromDate.Value = "";
                    upd_ToDate.Value = "";
                    upd_Company.Value = "";
                    upd_Position.Value = "";
                    upd_DNR.Value = "";
                    upd_RFLeaving.Value = "";
                    upd_Previous.Checked = false;
                    upd_NThirteenth.Value = "";
                    upd_Deminimis.Value = "";
                    upd_NCompensations.Value = "";
                    upd_Basic.Value = "";
                    upd_TThirteenth.Value = "";
                    upd_TCompensations.Value = "";
                    upd_Contributions.Value = "";
                    upd_HYear.Value = "";
                    refresh();
                }
            }
        }
    }
}