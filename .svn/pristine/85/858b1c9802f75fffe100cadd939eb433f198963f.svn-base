using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HRIS_APPELECTRIC.Pages.AdminKiosk
{
    public partial class adminrolemanagement : System.Web.UI.Page
    {
        AdminLib adl = new AdminLib();
        Employee emp = new Employee();
        Common cm = new Common();
        public string empno = "";
        public string emprole = "";
        string empviewURL = "", role;
        public int gridtotalcount = 0;
        public string gridrangecount = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //empno = Request.QueryString["id"];
            if (!IsPostBack)
            {
                if (Session["ROLES"].ToString() != "admin")
                {
                    Response.Redirect("~/Pages/Login.aspx");
                }

                refresh();
            }
        }
        void refresh()
        {
            select_role.SelectedIndex = 0;
            //role = cm.GetSpecificDataFromDB("RoleName", "TBL_ROLES", "WHERE RoleDesc ='" + select_role.SelectedIndex + "'");
            emprole = "employee";
            DataTable dt = new DataTable();
            dt = adl.populateGridRoleManagement(emprole);
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
            //role = cm.GetSpecificDataFromDB("RoleName", "TBL_ROLES", "WHERE RoleDesc ='" + select_role.SelectedItem.Text + "'");
            emprole = select_role.SelectedValue;

            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
            string FullName = ((TextBox)currentRow.FindControl("txtSearchFullName")).Text;


            string expr = emp.build_or_like_param(saveSearchParam(FullName));


            GridViewList.DataSource = adl.populateGridRoleManagementCol(emprole, expr);
            GridViewList.DataBind();



        }
        Dictionary<string, string> saveSearchParam(string FullName)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("fullname", "'%" + FullName + "%'");




            return param;


        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {


            if (select_role.SelectedIndex != 0)
            {
                emprole = select_role.SelectedValue;
                //role = cm.GetSpecificDataFromDB("RoleName", "TBL_ROLES", "WHERE RoleDesc ='" + select_role.SelectedItem.Text + "'");
                GridViewList.DataSource = adl.populateGridRoleManagement(emprole);
                GridViewList.DataBind();
                summary();
            }



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
            if (e.CommandName == "view")
            {
                HiddenEmpID.Value = e.CommandArgument.ToString();
                populateUpdateField(e.CommandArgument.ToString());
                openTransDetails(empno);

            }

        }

        public void populateUpdateField(string id)
        {
            lblDisplayempname.Text = emp.GetEmployeeName(id);
            lblDisplayempid.Text = id;
            //string role = cm.GetSpecificDataFromDB("roles", "TBL_USERS", "where empid = " + id + "");
            upd_roles.SelectedValue = emp.GetEmployeeRole(id);


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
        protected void btnsaveUpdate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {

                if (upd_roles.SelectedValue != "0")
                {
                    //string role = cm.GetSpecificDataFromDB("RoleName", "TBL_ROLES", "WHERE RoleDesc ='" + upd_roles.SelectedItem.Text + "'");
                    cm.UpdateQueryCommon(saveUpdateParam(upd_roles.SelectedValue), "TBL_USERS", "empid = " + HiddenEmpID.Value + "");
                    refresh();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully updated !!!');", true);
                    closeTransDetails();
                    refresh();
                }
                else
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Fields should not be empty !!!');", true);
            }
        }

        Dictionary<string, string> saveUpdateParam(string updroles)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("roles", "'" + updroles + "'");


            return param;


        }
    }
}