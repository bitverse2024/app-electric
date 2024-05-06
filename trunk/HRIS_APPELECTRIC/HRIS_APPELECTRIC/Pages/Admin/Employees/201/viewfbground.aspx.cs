using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlTypes;
using System.Globalization;

namespace HRIS_APPELECTRIC.Pages.Admin.Employees._201
{
    public partial class viewfbground : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Common cm = new Common();
        public string empno = "";
        //string empviewURL = "";
        public int gridtotalcount = 0;
        public string gridrangecount = "";
        string getfulln, getbdate, getrel, getocc, getcomp, getnum, getmname, getlname;
        DateTime date, compareDate;
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
                "alert('Injection not allowed!!!');window.location ='viewfbground.aspx?id=" + empno + "';",
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
            dt = emp.populateGridFamilyBG(empno);
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
            string a1 = ((TextBox)currentRow.FindControl("txtFName")).Text;
            string a2 = ((TextBox)currentRow.FindControl("txtBirthdate")).Text;
            string a3 = ((TextBox)currentRow.FindControl("txtAge")).Text;
            string a4 = ((TextBox)currentRow.FindControl("txtRelationship")).Text;
            string a5 = ((TextBox)currentRow.FindControl("txtContactNo")).Text;

            string expr = emp.build_or_like_param(saveSearchParam(a1, a2, a3, a4, a5));
            GridViewList.DataSource = emp.populateGridFamilyBGCol(empno, expr);
            GridViewList.DataBind();
        }
        Dictionary<string, string> saveSearchParam(string a1, string a2, string a3, string a4, string a5)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("FName", "'%" + a1 + "%'");
            param.Add("Birthdate", "'%" + a2 + "%'");
            param.Add("Age", "'%" + a3 + "%'");
            param.Add("Relationship", "'%" + a4 + "%'");
            param.Add("ContactNo", "'%" + a5 + "%'");


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
                getfulln = cm.GetSpecificDataFromDB("FName", "TBL_FAMILYBGROUND", "where id = " + e.CommandArgument.ToString() + "");
                emp.DeleteQuery("TBL_FAMILYBGROUND", "where id =" + e.CommandArgument.ToString() + "");
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " removed Family Background with NAME: " + getfulln + " for " + emp.GetEmployeeName(empno),
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
            vw_FName.Value = upd_FName.Value;
            vw_MName.Value = upd_MName.Value;
            vw_LName.Value = upd_LName.Value;
            vw_Birthdate.Value = upd_Birthdate.Value;
            vw_Relationship.Value = upd_Relationship.Value;
            vw_Occupation.Value = upd_Occupation.Value;
            vw_Company.Value = upd_Company.Value;
            vw_ContactNo.Value = upd_ContactNo.Value;
        }
        public void populateUpdateField(string id)
        {
            string bd;
            upd_FName.Value = cm.GetSpecificDataFromDB("FName", "TBL_FAMILYBGROUND", "where id = " + id + "");
            upd_MName.Value = cm.GetSpecificDataFromDB("MName", "TBL_FAMILYBGROUND", "where id = " + id + "");
            upd_LName.Value = cm.GetSpecificDataFromDB("LName", "TBL_FAMILYBGROUND", "where id = " + id + "");
            bd = cm.GetSpecificDataFromDB("Birthdate", "TBL_FAMILYBGROUND", "where id = " + id + "");
            upd_Birthdate.Value = cm.FormatDate(bd);
            upd_Relationship.Value = cm.GetSpecificDataFromDB("Relationship", "TBL_FAMILYBGROUND", "where id = " + id + "");
            upd_Occupation.Value = cm.GetSpecificDataFromDB("Occupation", "TBL_FAMILYBGROUND", "where id = " + id + "");
            upd_Company.Value = cm.GetSpecificDataFromDB("Company", "TBL_FAMILYBGROUND", "where id = " + id + "");
            upd_ContactNo.Value = cm.GetSpecificDataFromDB("ContactNo", "TBL_FAMILYBGROUND", "where id = " + id + "");
        }

        protected void lnkbtnXlist_Click(object sender, EventArgs e)
        {
            closeTransDetails();
        }

        Dictionary<string, string> saveUpdateParam(string LoanID, string LoanDesc)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("LoanID", "'" + LoanID + "'");
            param.Add("LoanDesc", "'" + LoanDesc + "'");

            return param;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string str_age = "";
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if (txtBirthdate.Value != "")
                {
                    DateTime dt = DateTime.ParseExact(txtBirthdate.Value, "MM/dd/yyyy", null);
                    DateTime dob = DateTime.Now;
                    bool valid = DateTime.TryParse(dt.ToString(), out dob);
                    if (dt >= DateTime.Now)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Birthdate must be less than date today!!!');", true);
                        return;
                    }
                    else
                    {
                        if (!valid)
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Invalid birthdate');", true);
                            return;
                        }
                        DateTime now = DateTime.Today;
                        int age = now.Year - dob.Year;
                        if (dob > now.AddYears(-age)) age--;
                        str_age = age.ToString();
                        saveParam(str_age);
                    }
                }

                if (emp.InsertQueryCommon(saveParam(str_age), "TBL_FAMILYBGROUND"))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Save !!!');", true);
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " created Family Background with NAME: " + FName.Value + " for " + emp.GetEmployeeName(empno),
                                    "CREATE", "x123", "qwg-23", "CREATE", Session["EMP_ID"].ToString());
                }
                FName.Value = "";
                txtBirthdate.Value = "";
                Relationship.Value = "";
                Occupation.Value = "";
                ContactNo.Value = "";
                Company.Value = "";
                refresh();
            }
        }
        Dictionary<string, string> saveParam(string age)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add(FName.ID, "'" + FName.Value + "'");
            param.Add(MName.ID, "'" + MName.Value + "'");
            param.Add(LName.ID, "'" + LName.Value + "'");
            if (txtBirthdate.Value == "")
            {
                param.Add("Birthdate", SqlDateTime.Null.ToString());
            }
            else
            {
                param.Add("Birthdate", "'" + txtBirthdate.Value + "'");
            }
            param.Add(Relationship.ID, "'" + Relationship.Value + "'");
            param.Add(Occupation.ID, "'" + Occupation.Value + "'");
            param.Add(ContactNo.ID, "'" + ContactNo.Value + "'");
            param.Add(Company.ID, "'" + Company.Value + "'");
            param.Add("Age", "'" + age + "'");
            param.Add("EmpID", "'" + empno + "'");

            return param;
        }
        Dictionary<string, string> saveUpdateParam(string age)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add(FName.ID, "'" + upd_FName.Value + "'");
            param.Add(MName.ID, "'" + upd_MName.Value + "'");
            param.Add(LName.ID, "'" + upd_LName.Value + "'");
            if (upd_Birthdate.Value == "")
            {
                param.Add("Birthdate", SqlDateTime.Null.ToString());
            }
            else
            {
                param.Add("Birthdate", "'" + upd_Birthdate.Value + "'");
            }
            param.Add(Relationship.ID, "'" + upd_Relationship.Value + "'");
            param.Add(Occupation.ID, "'" + upd_Occupation.Value + "'");
            param.Add(ContactNo.ID, "'" + upd_ContactNo.Value + "'");
            param.Add(Company.ID, "'" + upd_Company.Value + "'");
            param.Add("Age", "'" + age + "'");
            param.Add("EmpID", "'" + empno + "'");

            return param;
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            FName.Value = "";
            txtBirthdate.Value = "";
            Relationship.Value = "";
            Occupation.Value = "";
            ContactNo.Value = "";
            Company.Value = "";
        }

        private void getdata()
        {
            getfulln = cm.GetSpecificDataFromDB("FName", "TBL_FAMILYBGROUND", "where id = " + HiddenEmpID.Value + "");
            getmname = cm.GetSpecificDataFromDB("MName", "TBL_FAMILYBGROUND", "where id = " + HiddenEmpID.Value + "");
            getlname = cm.GetSpecificDataFromDB("LName", "TBL_FAMILYBGROUND", "where id = " + HiddenEmpID.Value + "");
            getbdate = cm.GetSpecificDataFromDB("Birthdate", "TBL_FAMILYBGROUND", "where id = " + HiddenEmpID.Value + "");
            getrel = cm.GetSpecificDataFromDB("Relationship", "TBL_FAMILYBGROUND", "where id = " + HiddenEmpID.Value + "");
            getocc = cm.GetSpecificDataFromDB("Occupation", "TBL_FAMILYBGROUND", "where id = " + HiddenEmpID.Value + "");
            getcomp = cm.GetSpecificDataFromDB("Company", "TBL_FAMILYBGROUND", "where id = " + HiddenEmpID.Value + "");
            getnum = cm.GetSpecificDataFromDB("ContactNo", "TBL_FAMILYBGROUND", "where id = " + HiddenEmpID.Value + "");
        }

        private void addlogs()
        {
            var formats = new string[] { "dd/MM/yyyy", "MM/dd/yyyy" };
            if (upd_Birthdate.Value != "")
            {
                compareDate = DateTime.ParseExact(upd_Birthdate.Value, formats, CultureInfo.CurrentCulture, DateTimeStyles.None);
            }
            if (getbdate != "")
            {
                date = DateTime.ParseExact(cm.FormatDate(getbdate), formats, CultureInfo.CurrentCulture, DateTimeStyles.None);
            }
            if (getfulln != upd_FName.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Family Background FIRST NAME for " + emp.GetEmployeeName(empno) + " from " + getfulln + " to " + upd_FName.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getmname != upd_MName.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Family Background MIDDLE NAME for " + emp.GetEmployeeName(empno) + " from " + getmname + " to " + upd_MName.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getlname != upd_LName.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Family Background LAST NAME for " + emp.GetEmployeeName(empno) + " from " + getlname + " to " + upd_LName.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (date.ToString() != compareDate.ToString())
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Family Background BIRTHDATE for " + emp.GetEmployeeName(empno) + " from " + cm.FormatDate(getbdate) + " to " + upd_Birthdate.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getrel != upd_Relationship.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Family Background RELATIONSHIP for " + emp.GetEmployeeName(empno) + " from " + getrel + " to " + upd_Relationship.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getocc != upd_Occupation.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Family Background OCCUPATION for " + emp.GetEmployeeName(empno) + " from " + getocc + " to " + upd_Occupation.Value,
                   "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getcomp != upd_Company.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Family Background COMPANY for " + emp.GetEmployeeName(empno) + " from " + getcomp + " to " + upd_Company.Value,
                  "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getnum != upd_ContactNo.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Family Background CONTACT NUMBER for " + emp.GetEmployeeName(empno) + " from " + getnum + " to " + upd_ContactNo.Value,
                  "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
        }

        protected void btnsaveUpdate_Click(object sender, EventArgs e)
        {
            string str_age = "";
            string bd;
            string confirmValue = Request.Form["confirm_value"];
            var formats = new string[] { "MM-dd-yyyy", "MM/dd/yyyy" };
            if (confirmValue == "Yes")
            {
                getdata();
                if (upd_Birthdate.Value != "")
                {
                    DateTime dt = DateTime.ParseExact(upd_Birthdate.Value, formats, CultureInfo.CurrentCulture, DateTimeStyles.None);
                    DateTime dob = DateTime.Now;
                    bool valid = DateTime.TryParse(dt.ToString(), out dob);
                    if (dt >= DateTime.Now)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Birthdate must be less than date today!!!');", true);
                        return;
                    }
                    else
                    {
                        if (!valid)
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Invalid birthdate');", true);
                            return;
                        }
                        DateTime now = DateTime.Today;
                        int age = now.Year - dob.Year;
                        if (dob > now.AddYears(-age)) age--;
                        str_age = age.ToString();
                        saveParam(str_age);
                    }
                }

                if (cm.UpdateQueryCommon(saveUpdateParam(str_age), "TBL_FAMILYBGROUND", "id = '" + HiddenEmpID.Value + "'"))
                {
                    bd = cm.FormatDate(getbdate);
                    refresh();
                    //db_Emp.updateUserInfo(HiddenEmpID.Value, txtbox_username.Text, txtbox_password.Text, (drpdwn_acctstatus.SelectedValue == "1" ? true : false));
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully updated !!!');", true);
                    addlogs();
                    closeTransDetails();
                    refresh();
                }
            }
        }
    }
}