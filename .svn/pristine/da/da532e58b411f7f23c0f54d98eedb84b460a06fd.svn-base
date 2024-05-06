using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HRIS_APPELECTRIC.Pages.Admin.Employees._201
{
    public partial class vieweducation : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Common cm = new Common();
        public string empno = "";
        string empviewURL = "";
        public int gridtotalcount = 0;
        public string gridrangecount = "";
        string getschooln;
        string getidates;
        string getcname;
        string gethonors;
        string getrems;
        string getlicno;
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
                "alert('Injection not allowed!!!');window.location ='vieweducation.aspx?id=" + empno + "';",
                true);
            }
            if (!IsPostBack)
            {
                refresh();
                SchoolName.Items.AddRange(emp.GetDropDownMenuList("TBL_SCHOOL", "SchoolName"));
                CourseName.Items.AddRange(emp.GetDropDownMenuList("TBL_COURSE", "CourseName"));
                upd_SchoolName.Items.AddRange(emp.GetDropDownMenuList("TBL_SCHOOL", "SchoolName"));
                upd_CourseName.Items.AddRange(emp.GetDropDownMenuList("TBL_COURSE", "CourseName"));
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
            dt = emp.populateGridEduc(empno);
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
            string _schoolcode = ((TextBox)currentRow.FindControl("txtSearchCourseName")).Text;
            string _coursecode = ((TextBox)currentRow.FindControl("txtSearchSchoolName")).Text;
            string _idate = ((TextBox)currentRow.FindControl("txtSearchIdate")).Text;
            string _remarks = ((TextBox)currentRow.FindControl("txtSearchRemarks")).Text;
            string expr = emp.build_or_like_param(saveSearchParam(_schoolcode, _coursecode, _idate, _remarks));

            //string expr = "and (C.SchoolName like '%" + _schoolcode + "%' or B.CourseName like '%" + _coursecode + "%' or A.IDate like '%" + _idate + "%' or A.Remarks like '%" + _remarks + "%')";
            //GridViewList.DataSource = emp.populateGridSearch((DataTable)ViewState["EMP_GRID"], expr);
            GridViewList.DataSource = emp.populateGridEducCol(empno, expr);
            GridViewList.DataBind();



        }

        Dictionary<string, string> saveSearchParam(string _schoolcode, string _coursecode, string _idate, string _remarks)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();

            param.Add(SchoolName.ID, "'%" + _schoolcode + "%'");
            param.Add(CourseName.ID, "'%" + _coursecode + "%'");
            param.Add(IDate.ID, "'%" + _idate + "%'");
            param.Add(Remarks.ID, "'%" + _remarks + "%'");
            return param;


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
            upd_SchoolName.SelectedValue = cm.GetSpecificDataFromDB("SchoolCode", "TBL_EBGROUND", "where id = " + id + "");
            upd_IDate.Value = cm.GetSpecificDataFromDB("IDate", "TBL_EBGROUND", "where id = " + id + "");
            upd_CourseName.SelectedValue = cm.GetSpecificDataFromDB("CourseCode", "TBL_EBGROUND", "where id = " + id + "");
            upd_HReceived.Value = cm.GetSpecificDataFromDB("HReceived", "TBL_EBGROUND", "where id = " + id + "");
            upd_Remarks.Value = cm.GetSpecificDataFromDB("Remarks", "TBL_EBGROUND", "where id = " + id + "");
            upd_LicenseNo.Value = cm.GetSpecificDataFromDB("LicenseNo", "TBL_EBGROUND", "where id = " + id + "");
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
            vw_SchoolName.Value = upd_SchoolName.SelectedValue;
            vw_IDate.Value = upd_IDate.Value;
            vw_CourseName.Value = upd_CourseName.SelectedValue;
            vw_HReceived.Value = upd_HReceived.Value;
            vw_Remarks.Value = upd_Remarks.Value;
            vw_LicenseNo.Value = upd_LicenseNo.Value;
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
                getschooln = cm.GetSpecificDataFromDB("SchoolCode", "TBL_EBGROUND", "where id = " + e.CommandArgument.ToString() + "");
                emp.DeleteQuery("TBL_EBGROUND", "where id =" + e.CommandArgument.ToString() + "");
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " removed Educational Background with SCHOOL CODE: " + getschooln + " for " + emp.GetEmployeeName(empno),
                                "DELETE", "x123", "qwg-23", "DELETE", Session["EMP_ID"].ToString());
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
                if (emp.InsertQueryCommon(saveParam(), "TBL_EBGROUND"))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Save !!!');", true);
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " created Educational Background with SCHOOL: " + SchoolName.SelectedItem + " for " + emp.GetEmployeeName(empno),
                                    "CREATE", "x123", "qwg-23", "CREATE", Session["EMP_ID"].ToString());
                }
                SchoolName.SelectedValue = "0";
                CourseName.SelectedValue = "0";
                IDate.Value = "";
                HReceived.Value = "";
                Remarks.Value = "";
                LicenseNo.Value = "";
                refresh();
            }
        }

        Dictionary<string, string> saveParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("SchoolCode", "'" + SchoolName.SelectedValue + "'");
            param.Add("CourseCode", "'" + CourseName.SelectedValue + "'");
            param.Add(IDate.ID, "'" + IDate.Value + "'");
            param.Add(HReceived.ID, "'" + HReceived.Value + "'");
            param.Add(Remarks.ID, "'" + Remarks.Value + "'");
            param.Add(LicenseNo.ID, "'" + LicenseNo.Value + "'");

            param.Add("EmpID", "'" + empno + "'");

            return param;


        }

        Dictionary<string, string> saveUpdateParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("SchoolCode", "'" + upd_SchoolName.SelectedValue + "'");
            param.Add("CourseCode", "'" + upd_CourseName.SelectedValue + "'");
            param.Add(IDate.ID, "'" + upd_IDate.Value + "'");
            param.Add(HReceived.ID, "'" + upd_HReceived.Value + "'");
            param.Add(Remarks.ID, "'" + upd_Remarks.Value + "'");
            param.Add(LicenseNo.ID, "'" + upd_LicenseNo.Value + "'");

            param.Add("EmpID", "'" + empno + "'");

            return param;


        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            SchoolName.SelectedValue = "0";
            CourseName.SelectedValue = "0";
            IDate.Value = "";
            HReceived.Value = "";
            Remarks.Value = "";
            LicenseNo.Value = "";
            refresh();
        }

        private void getdata()
        {
            getschooln = cm.GetSpecificDataFromDB("SchoolCode", "TBL_EBGROUND", "where id = " + HiddenEmpID.Value + "");
            getidates = cm.GetSpecificDataFromDB("IDate", "TBL_EBGROUND", "where id = " + HiddenEmpID.Value + "");
            getcname = cm.GetSpecificDataFromDB("CourseCode", "TBL_EBGROUND", "where id = " + HiddenEmpID.Value + "");
            gethonors = cm.GetSpecificDataFromDB("HReceived", "TBL_EBGROUND", "where id = " + HiddenEmpID.Value + "");
            getrems = cm.GetSpecificDataFromDB("Remarks", "TBL_EBGROUND", "where id = " + HiddenEmpID.Value + "");
            getlicno = cm.GetSpecificDataFromDB("LicenseNo", "TBL_EBGROUND", "where id = " + HiddenEmpID.Value + "");
        }

        private void addlogs()
        {
            if (getschooln != upd_SchoolName.SelectedValue)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Educational Background SCHOOL for " + emp.GetEmployeeName(empno) + " from " + getschooln + " to " + upd_SchoolName.SelectedValue,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getidates != upd_IDate.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Educational Background INCLUSIVE DATE for " + emp.GetEmployeeName(empno) + " from " + getidates + " to " + upd_IDate.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getcname != upd_CourseName.SelectedValue)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Educational Background COURSE for " + emp.GetEmployeeName(empno) + " from " + getcname + " to " + upd_CourseName.SelectedValue,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (gethonors != upd_HReceived.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Educational Background HONORS RECEIVED for " + emp.GetEmployeeName(empno) + " from " + gethonors + " to " + upd_HReceived.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getrems != upd_Remarks.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Educational Background REMARKS for " + emp.GetEmployeeName(empno) + " from " + getrems + " to " + upd_Remarks.Value,
                   "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getlicno != upd_LicenseNo.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Educational Background LICENSE NUMBER for " + emp.GetEmployeeName(empno) + " from " + getlicno + " to " + upd_LicenseNo.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
        }

        protected void btnsaveUpdate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                getdata();
                if (cm.UpdateQueryCommon(saveUpdateParam(), "TBL_EBGROUND", "id = '" + HiddenEmpID.Value + "'"))
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