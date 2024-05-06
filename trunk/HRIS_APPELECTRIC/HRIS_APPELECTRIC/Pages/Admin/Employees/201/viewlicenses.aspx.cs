using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HRIS_APPELECTRIC.Pages.Admin.Employees._201
{
    public partial class viewlicenses : System.Web.UI.Page
    {
        Common cm = new Common();
        Employee emp = new Employee();
        public string empno = "";
        string empviewURL = "";
        public int gridtotalcount = 0;
        public string gridrangecount = "";
        string type;
        string expiredate;
        string licno;
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
                "alert('Injection not allowed!!!');window.location ='viewlicenses.aspx?id=" + empno + "';",
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
            dt = emp.populateGridLicense(empno);
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
            string lictype = ((TextBox)currentRow.FindControl("txtSearchLicenseType")).Text;
            string licno = ((TextBox)currentRow.FindControl("txtSearchLicNo")).Text;
            string licdate = ((TextBox)currentRow.FindControl("txtSearchExpiryDate")).Text;
            string expr = emp.build_or_like_param(saveSearchParam(licno, lictype, licdate));
            //string expr = "and (license_type like '%" + lictype + "%' or license_no like '%" + licno + "%' or lic_expirydate like '%" + licdate + "%')";
            //GridViewList.DataSource = emp.populateGridSearch((DataTable)ViewState["EMP_GRID"], expr);
            GridViewList.DataSource = emp.populateGridLicenseCol(empno, expr);
            GridViewList.DataBind();



        }

        Dictionary<string, string> saveSearchParam(string licno, string lictype, string licexpdate)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add(license_no.ID, "'%" + licno + "%'");
            param.Add(license_type.ID, "'%" + lictype + "%'");
            param.Add("lic_expirydate", "'%" + licexpdate + "%'");


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
                type = cm.GetSpecificDataFromDB("license_type", "TBL_LICENSE", "where id = " + e.CommandArgument.ToString() + "");
                emp.DeleteQuery("TBL_LICENSE", "where id =" + e.CommandArgument.ToString() + "");
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " removed License with LICENSE TYPE: " + type + " for " + emp.GetEmployeeName(empno),
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
            upd_license_type.Value = cm.GetSpecificDataFromDB("license_type", "TBL_LICENSE", "where id = " + id + "");
            bd = cm.GetSpecificDataFromDB("lic_expirydate", "TBL_LICENSE", "where id = " + id + "");
            upd_lic_expirydate.Value = cm.FormatDate(bd);
            upd_license_no.Value = cm.GetSpecificDataFromDB("license_no", "TBL_LICENSE", "where id = " + id + "");
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
            vw_license_type.Value = upd_license_type.Value;
            vw_license_no.Value = upd_license_no.Value;
            vw_lic_expirydate.Value = upd_lic_expirydate.Value;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if (emp.InsertQueryCommon(saveParam(), "TBL_LICENSE"))
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " created License with LICENSE TYPE: " + license_type.Value + " for " + emp.GetEmployeeName(empno),
                        "CREATE", "x123", "qwg-23", "CREATE", Session["EMP_ID"].ToString());
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Save !!!');", true);
                    refresh();
                    license_no.Value = "";
                    license_type.Value = "";
                    txtlic_expirydate.Value = "";

                }
            }
        }

        Dictionary<string, string> saveParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add(license_no.ID, "'" + license_no.Value + "'");
            param.Add(license_type.ID, "'" + license_type.Value + "'");
            param.Add("lic_expirydate", "'" + txtlic_expirydate.Value + "'");
            param.Add("EmpID", "'" + empno + "'");


            return param;


        }

        Dictionary<string, string> saveUpdateParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add(license_no.ID, "'" + upd_license_no.Value + "'");
            param.Add(license_type.ID, "'" + upd_license_type.Value + "'");
            param.Add("lic_expirydate", "'" + upd_lic_expirydate.Value + "'");
            param.Add("EmpID", "'" + empno + "'");


            return param;


        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            license_no.Value = "";
            license_type.Value = "";
            txtlic_expirydate.Value = "";
            refresh();
        }

        private void getdata()
        {
            type = cm.GetSpecificDataFromDB("license_type", "TBL_LICENSE", "where id = " + HiddenEmpID.Value + "");
            expiredate = cm.FormatDate(cm.GetSpecificDataFromDB("lic_expirydate", "TBL_LICENSE", "where id = " + HiddenEmpID.Value + ""));
            licno = cm.GetSpecificDataFromDB("license_no", "TBL_LICENSE", "where id = " + HiddenEmpID.Value + "");
        }

        private void addlogs()
        {
            if (type != upd_license_type.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed License LICENSE TYPE for " + emp.GetEmployeeName(empno) + " from " + type + " to " + upd_license_type.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (expiredate != upd_lic_expirydate.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed License EXPIRY DATE for " + emp.GetEmployeeName(empno) + " from " + expiredate + " to " + upd_lic_expirydate.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (licno != upd_license_no.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed License LICENSE NUMBER for " + emp.GetEmployeeName(empno) + " from " + licno + " to " + upd_license_no.Value,
                   "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
        }

        protected void btnsaveUpdate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                getdata();
                if (cm.UpdateQueryCommon(saveUpdateParam(), "TBL_LICENSE", "id = '" + HiddenEmpID.Value + "'"))
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