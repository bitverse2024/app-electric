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
    public partial class viewdependent : System.Web.UI.Page
    {
        Employee emp = new Employee();
        public string empno = "";
        Common cm = new Common();
        public int gridtotalcount = 0;
        public string gridrangecount = "";
        string getfulln, getbdate, getrel, getocc, getmname, getlname;
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
                "alert('Injection not allowed!!!');window.location ='viewdependent.aspx?id=" + empno + "';",
                true);
            }


            if (!IsPostBack)
            {
                refresh();
                summary();
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
            dt = emp.populateGridDependent(empno);
            GridDependentList.DataSource = dt;
            GridDependentList.DataBind();
            ViewState["EMP_DEPENDENT"] = dt;
            ViewState["SORTDR"] = null;

        }
        void summary()
        {
            gridtotalcount = ((DataTable)ViewState["EMP_DEPENDENT"]).Rows.Count;
            int pageIndex = GridDependentList.PageIndex;
            int c = (pageIndex > 0 ? 10 * pageIndex : 0) + GridDependentList.Rows.Count;
            gridrangecount = (c > 0 ? c : 0) + " - " + gridtotalcount;
        }
        protected void sort_grid(string sort_args)
        {
            DataTable dt = (DataTable)ViewState["EMP_DEPENDENT"];
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

                GridDependentList.DataSource = dt;
                GridDependentList.DataBind();


            }

        }
        protected void GridUserList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sort")
            {
                sort_grid(e.CommandArgument.ToString());

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
                getfulln = cm.GetSpecificDataFromDB("DName", "TBL_DEPENDENT", "where id = " + e.CommandArgument.ToString() + "");
                emp.DeleteQuery("TBL_DEPENDENT", "where id =" + e.CommandArgument.ToString() + "");
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " removed Dependent with NAME: " + getfulln + " for " + emp.GetEmployeeName(empno),
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
            string bd;
            upd_FName.Value = cm.GetSpecificDataFromDB("DName", "TBL_DEPENDENT", "where id = " + id + "");
            upd_MName.Value = cm.GetSpecificDataFromDB("DMidName", "TBL_DEPENDENT", "where id = " + id + "");
            upd_LName.Value = cm.GetSpecificDataFromDB("DSurname", "TBL_DEPENDENT", "where id = " + id + "");
            bd = cm.GetSpecificDataFromDB("DOB", "TBL_DEPENDENT", "where id = " + id + "");
            upd_Birthdate.Value = cm.FormatDate(bd);
            upd_Relationship.Value = cm.GetSpecificDataFromDB("Relationship", "TBL_DEPENDENT", "where id = " + id + "");
            upd_Occupation.Value = cm.GetSpecificDataFromDB("Occupation", "TBL_DEPENDENT", "where id = " + id + "");
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
            vw_FName.Value = upd_FName.Value;
            vw_Birthdate.Value = upd_Birthdate.Value;
            vw_Relationship.Value = upd_Relationship.Value;
            vw_Occupation.Value = upd_Occupation.Value;
            vw_MName.Value = upd_MName.Value;
            vw_LName.Value = upd_LName.Value;
        }

        protected void GridUserList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridDependentList.PageIndex = e.NewPageIndex;
            refresh();
        }
        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            //awong-retrieve textbox values from the grid control during runtime.
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
            //string a1 = ((TextBox)GridUserList.FindControl("txtSearch1")).Text;
            //string a2 = ((TextBox)GridUserList.FindControl("txtSearch2")).Text;
            string Name = ((TextBox)currentRow.FindControl("txtSearchName")).Text;
            string Relationship = ((TextBox)currentRow.FindControl("txtSearchRelationship")).Text;
            string Birthdate = ((TextBox)currentRow.FindControl("txtSearchDOB")).Text;
            string Age = ((TextBox)currentRow.FindControl("txtSearchAge")).Text;
            string Occupation = ((TextBox)currentRow.FindControl("txtSearchOccupation")).Text;

            string expr = emp.build_or_like_param(saveSearchParam(Name, Relationship, Birthdate, Age, Occupation));
            GridDependentList.DataSource = emp.populateGridDependentListCol(empno, expr);
            GridDependentList.DataBind();

            #region Search per textbox
            //if (sender is TextBox)
            //{
            //    TextBox txtBox = (TextBox)sender;
            //    if (txtBox.ID == "txtSearch1")
            //    {
            //        GridUserList.DataSource = db.populateGridUserListCol(txtBox.Text, "");
            //        GridUserList.DataBind();
            //    }
            //    if (txtBox.ID == "txtSearch2")
            //    {
            //        GridUserList.DataSource = db.populateGridUserListCol("", txtBox.Text);
            //        GridUserList.DataBind();
            //    }
            //}
            #endregion

        }
        Dictionary<string, string> saveSearchParam(string Name, string Relationship, string Birthdate, string Age, string Occupation)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add(DName.ID, "'%" + Name + "%'");
            param.Add("Relationship", "'%" + Relationship + "%'");
            param.Add("DOB", "'%" + Birthdate + "%'");
            param.Add("Age", "'%" + Age + "%'");
            param.Add("Occupation", "'%" + Occupation + "%'");
            return param;
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            refresh();
            DName.Text = "";
            Relationship.Text = "";
            txtDOB.Value = "";
            Occupation.Text = "";

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string str_age = "";
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if (txtDOB.Value != "")
                {
                    DateTime dt = DateTime.ParseExact(txtDOB.Value, "MM/dd/yyyy", null);
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
                    }
                }

                if (emp.InsertQueryCommon(saveParam(str_age), "TBL_DEPENDENT"))
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " created Dependent with NAME: " + DName.Text + " for " + emp.GetEmployeeName(empno),
                                    "CREATE", "x123", "qwg-23", "CREATE", Session["EMP_ID"].ToString());
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Save !!!');", true);
                }
                refresh();
                DName.Text = "";
                Relationship.Text = "";
                txtDOB.Value = "";
                Occupation.Text = "";
            }
        }

        Dictionary<string, string> saveParam(string age)
        {

            //string tagname = txtEmployee_Surname.Controls;
            //string Clienti = txtEmployee_Surname.ClientID;
            //string aaso = txtEmployee_Surname.UniqueID;
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add(DName.ID, "'" + DName.Text + "'");
            param.Add("DSurname", "'" + LName.Text + "'");
            param.Add("DMidName", "'" + MName.Text + "'");
            if (txtDOB.Value == "")
            {
                param.Add("DOB", SqlDateTime.Null.ToString());
            }
            else
            {
                param.Add("DOB", "'" + txtDOB.Value + "'");
            }
            param.Add(Relationship.ID, "'" + Relationship.Text + "'");
            param.Add(Occupation.ID, "'" + Occupation.Text + "'");
            param.Add("Age", "'" + age + "'");
            param.Add("EmpID", "'" + empno + "'");

            return param;


        }
        Dictionary<string, string> saveUpdateParam(string age)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add(DName.ID, "'" + upd_FName.Value + "'");
            param.Add("DSurname", "'" + upd_LName.Value + "'");
            param.Add("DMidName", "'" + upd_MName.Value + "'");
            if (upd_Birthdate.Value == "")
            {
                param.Add("DOB", SqlDateTime.Null.ToString());
            }
            else
            {
                param.Add("DOB", "'" + upd_Birthdate.Value + "'");
            }
            param.Add(Relationship.ID, "'" + upd_Relationship.Value + "'");
            param.Add(Occupation.ID, "'" + upd_Occupation.Value + "'");
            param.Add("Age", "'" + age + "'");
            param.Add("EmpID", "'" + empno + "'");

            return param;
        }

        private void getdata()
        {
            getfulln = cm.GetSpecificDataFromDB("DName", "TBL_DEPENDENT", "where id = " + HiddenEmpID.Value + "");
            getmname = cm.GetSpecificDataFromDB("DMidName", "TBL_DEPENDENT", "where id = " + HiddenEmpID.Value + "");
            getlname = cm.GetSpecificDataFromDB("DSurname", "TBL_DEPENDENT", "where id = " + HiddenEmpID.Value + "");
            getbdate = cm.GetSpecificDataFromDB("DOB", "TBL_DEPENDENT", "where id = " + HiddenEmpID.Value + "");
            getrel = cm.GetSpecificDataFromDB("Relationship", "TBL_DEPENDENT", "where id = " + HiddenEmpID.Value + "");
            getocc = cm.GetSpecificDataFromDB("Occupation", "TBL_DEPENDENT", "where id = " + HiddenEmpID.Value + "");
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
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Dependent FIRST NAME for " + emp.GetEmployeeName(empno) + " from " + getfulln + " to " + upd_FName.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getmname != upd_MName.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Dependent MIDDLE NAME for " + emp.GetEmployeeName(empno) + " from " + getmname + " to " + upd_MName.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getlname != upd_LName.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Dependent LAST NAME for " + emp.GetEmployeeName(empno) + " from " + getlname + " to " + upd_LName.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (date.ToString() != compareDate.ToString())
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Dependent BIRTHDATE for " + emp.GetEmployeeName(empno) + " from " + cm.FormatDate(getbdate) + " to " + upd_Birthdate.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getrel != upd_Relationship.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Dependent RELATIONSHIP for " + emp.GetEmployeeName(empno) + " from " + getrel + " to " + upd_Relationship.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getocc != upd_Occupation.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Dependent OCCUPATION for " + emp.GetEmployeeName(empno) + " from " + getocc + " to " + upd_Occupation.Value,
                   "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
        }

        protected void btnsaveUpdate_Click(object sender, EventArgs e)
        {
            string str_age = "";
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
                    }
                }

                if (cm.UpdateQueryCommon(saveUpdateParam(str_age), "TBL_DEPENDENT", "id = '" + HiddenEmpID.Value + "'"))
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