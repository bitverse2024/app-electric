using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HRIS_APPELECTRIC.Pages.Admin
{
    public partial class DeptList : System.Web.UI.Page
    {
        Timekeeping tk = new Timekeeping();
        Employee emp = new Employee();
        Common cm = new Common();
        string divid = "";
        public string empno = "";
        public int gridtotalcount = 0;
        public string gridrangecount = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            divid = Request.QueryString["id"];
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
            DataTable dt = new DataTable();
            dt = emp.populateGridDepartment(divid);
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
            string txtSearchDeptName = ((TextBox)currentRow.FindControl("txtSearchDeptName")).Text;

            string expr = emp.build_or_like_param(false, saveSearchParam(txtSearchDeptName));
            //string expr = "and (license_type like '%" + lictype + "%' or license_no like '%" + licno + "%' or lic_expirydate like '%" + licdate + "%')";
            //GridViewList.DataSource = emp.populateGridSearch((DataTable)ViewState["EMP_GRID"], expr);
            GridViewList.DataSource = emp.populateGridDepartmentCol(divid, expr);
            GridViewList.DataBind();



        }
        Dictionary<string, string> saveSearchParam(string txtSearchDeptName)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("DeptName", "'%" + txtSearchDeptName + "%'");

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
            if (e.CommandName == "upd")
            {
                HiddenEmpID.Value = e.CommandArgument.ToString();
                populateUpdateField(e.CommandArgument.ToString());
                openTransDetails(empno);

            }
            if (e.CommandName == "add_pos")
            {
                Response.Redirect("~/Pages/Admin/PositionList.aspx?id=" + e.CommandArgument.ToString());

            }
            if (e.CommandName == "del")
            {
                emp.DeleteQuery("TBL_DEPARTMENT", "where id =" + e.CommandArgument.ToString() + "");
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
            upd_Dept.Value = cm.GetSpecificDataFromDB("DeptName", "TBL_DEPARTMENT", "where id = " + id + "");
        }

        protected void lnkbtnXlist_Click(object sender, EventArgs e)
        {
            closeTransDetails();
        }
        Dictionary<string, string> saveUpdateParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("DeptName", "'" + upd_Dept.Value + "'");
            return param;

        }
        Dictionary<string, string> saveParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("DeptName", "'" + Department_DeptName.Value + "'");
            param.Add("DivCode", "" + divid + "");
            return param;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if (emp.InsertQueryCommon(saveParam(), "TBL_DEPARTMENT"))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Department Successfully Added !!!');", true);
                    Department_DeptName.Value = "";
                }
            }
            refresh();
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Department_DeptName.Value = "";
            refresh();
        }
        protected void btnsaveUpdate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                string getdept = cm.GetSpecificDataFromDB("DeptName", "TBL_DEPARTMENT", "where id = " + HiddenEmpID.Value + "");
                if (cm.UpdateQueryCommon(saveUpdateParam(), "TBL_DEPARTMENT", "id = " + HiddenEmpID.Value + ""))
                {
                    if (getdept != upd_Dept.Value)
                    {
                        cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed DEPARTMENT NAME for " + getdept + " from " + getdept + " to " + upd_Dept.Value,
                                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
                    }
                    refresh();
                    //db_Emp.updateUserInfo(HiddenEmpID.Value, txtbox_username.Text, txtbox_password.Text, (drpdwn_acctstatus.SelectedValue == "1" ? true : false));
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully updated !!!');", true);
                    closeTransDetails();
                    refresh();
                }
                else
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Fields should not be empty !!!');", true);
            }
        }
    }
}