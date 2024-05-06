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
    public partial class viewexams : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Common cm = new Common();
        public string empno = "";
        string empviewURL = "";
        public int gridtotalcount = 0;
        public string gridrangecount = "";
        string takedate;
        string exam;
        string rems;
        string stat;
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
                "alert('Injection not allowed!!!');window.location ='viewexams.aspx?id=" + empno + "';",
                true);
            }
            if (!IsPostBack)
            {
                refresh();
            }
        }
        void refresh()
        {
            DataTable dt = new DataTable();
            dt = emp.populateGridExam(empno);
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
            string _datetaken = ((TextBox)currentRow.FindControl("txtSearchDateTaken")).Text;
            string _desc = ((TextBox)currentRow.FindControl("txtSearchDescription")).Text;
            string _remarks = ((TextBox)currentRow.FindControl("txtSearchRemarks")).Text;
            string expr = emp.build_or_like_param(saveSearchParam(_datetaken, _desc, _remarks));
            //string expr = "and (license_type like '%" + lictype + "%' or license_no like '%" + licno + "%' or lic_expirydate like '%" + licdate + "%')";
            //GridViewList.DataSource = emp.populateGridSearch((DataTable)ViewState["EMP_GRID"], expr);
            GridViewList.DataSource = emp.populateGridExamCol(empno, expr);
            GridViewList.DataBind();



        }

        Dictionary<string, string> saveSearchParam(string _datetaken, string _desc, string _remarks)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();

            param.Add("DateTaken", "'%" + _datetaken + "%'");
            param.Add(ExamType.ID, "'%" + _desc + "%'");
            param.Add(Remarks.ID, "'%" + _remarks + "%'");


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
                exam = cm.GetSpecificDataFromDB("ExamType", "TBL_GOVTEXAM", "where id = " + e.CommandArgument.ToString() + "");
                emp.DeleteQuery("TBL_GOVTEXAM", "where id =" + e.CommandArgument.ToString() + "");
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " removed Exam/Seminar with DESCRIPTION: " + exam + " for " + emp.GetEmployeeName(empno),
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
            string divname = "";
        }

        public void populateUpdateField(string id)
        {
            string bd = cm.GetSpecificDataFromDB("DateTaken", "TBL_GOVTEXAM", "where id = " + id + "");
            upd_DateTaken.Value = cm.FormatDate(bd);
            upd_ExamType.Value = cm.GetSpecificDataFromDB("ExamType", "TBL_GOVTEXAM", "where id = " + id + "");
            upd_Remarks.Value = cm.GetSpecificDataFromDB("Remarks", "TBL_GOVTEXAM", "where id = " + id + "");
            upd_Status.Value = cm.GetSpecificDataFromDB("ExamStatus", "TBL_GOVTEXAM", "where id = " + id + "");
        }

        protected void lnkbtnXlist_Click(object sender, EventArgs e)
        {
            closeTransDetails();
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
            vw_DateTaken.Value = upd_DateTaken.Value;
            vw_ExamType.Value = upd_ExamType.Value;
            vw_Remarks.Value = upd_Remarks.Value;
            vw_ExamStatus.Value = upd_Status.Value;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if (emp.InsertQueryCommon(saveParam(), "TBL_GOVTEXAM"))
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " created Exam/Seminar with DESCRIPTION: " + ExamType.Value + " for " + emp.GetEmployeeName(empno),
                                   "CREATE", "x123", "qwg-23", "CREATE", Session["EMP_ID"].ToString());
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Save !!!');", true);
                    refresh();
                }
                txtDateTaken.Value = "";
                ExamType.Value = "";
                Remarks.Value = "";
                ExamStatus.Value = "";
            }
        }

        Dictionary<string, string> saveParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("DateTaken", "'" + txtDateTaken.Value + "'");
            param.Add(ExamType.ID, "'" + ExamType.Value + "'");
            param.Add(Remarks.ID, "'" + Remarks.Value + "'");
            param.Add(ExamStatus.ID, "'" + ExamStatus.Value + "'");
            param.Add("EmpID", "'" + empno + "'");

            return param;


        }

        Dictionary<string, string> saveUpdateParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("DateTaken", "'" + upd_DateTaken.Value + "'");
            param.Add(ExamType.ID, "'" + upd_ExamType.Value + "'");
            param.Add(Remarks.ID, "'" + upd_Remarks.Value + "'");
            param.Add(ExamStatus.ID, "'" + upd_Status.Value + "'");
            param.Add("EmpID", "'" + empno + "'");

            return param;


        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtDateTaken.Value = "";
            ExamType.Value = "";
            Remarks.Value = "";
            ExamStatus.Value = "";
            refresh();
        }

        private void getdata()
        {
            takedate = cm.GetSpecificDataFromDB("DateTaken", "TBL_GOVTEXAM", "where id = " + HiddenEmpID.Value + "");
            exam = cm.GetSpecificDataFromDB("ExamType", "TBL_GOVTEXAM", "where id = " + HiddenEmpID.Value + "");
            rems = cm.GetSpecificDataFromDB("Remarks", "TBL_GOVTEXAM", "where id = " + HiddenEmpID.Value + "");
            stat = cm.GetSpecificDataFromDB("ExamStatus", "TBL_GOVTEXAM", "where id = " + HiddenEmpID.Value + "");
        }

        private void addlogs()
        {
            var formats = new string[] { "dd/MM/yyyy", "MM/dd/yyyy" };
            DateTime compareDate = DateTime.ParseExact(upd_DateTaken.Value, formats, CultureInfo.CurrentCulture, DateTimeStyles.None);
            DateTime date = DateTime.ParseExact(cm.FormatDate(takedate), formats, CultureInfo.CurrentCulture, DateTimeStyles.None);
            if (date != compareDate)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Exam/Seminar DATE TAKEN for " + emp.GetEmployeeName(empno) + " from " + cm.FormatDate(takedate) + " to " + upd_DateTaken.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (exam != upd_ExamType.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Exam/Seminar DESCRIPTION for " + emp.GetEmployeeName(empno) + " from " + exam + " to " + upd_ExamType.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (rems != upd_Remarks.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Exam/Seminar REMARKS for " + emp.GetEmployeeName(empno) + " from " + rems + " to " + upd_Remarks.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (stat != upd_Status.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Exam/Seminar STATUS for " + emp.GetEmployeeName(empno) + " from " + stat + " to " + upd_Status.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
        }

        protected void btnsaveUpdate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                getdata();
                if (cm.UpdateQueryCommon(saveUpdateParam(), "TBL_GOVTEXAM", "id = '" + HiddenEmpID.Value + "'"))
                {
                    addlogs();
                    refresh();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully updated !!!');", true);
                    closeTransDetails();
                    refresh();
                }
            }
        }
    }
}