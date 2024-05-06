using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HRIS_APPELECTRIC.Pages.Admin
{
    public partial class UserList : System.Web.UI.Page
    {
        User db_Emp = new User();
        Common cm = new Common();
        Employee emp = new Employee();
        string[] searchItem = new string[2];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ROLES"].ToString() != "admin")
                {
                    Response.Redirect("~/Pages/Login.aspx");
                }
                refresh();
            }
        }
        /// <summary>
        /// Reset/Refresh the employee list
        /// </summary>
        void refresh()
        {
            //GridUserList.DataSource = db.populateGridUserList();
            //GridUserList.DataBind();
            DataTable dt = new DataTable();
            dt = db_Emp.populateGridUserListCol();
            GridUserList.DataSource = db_Emp.populateGridUserListCol();
            GridUserList.DataBind();
            ViewState["USER_MASTER"] = dt;
            ViewState["SORTDR"] = null;

        }
        protected void GridUserList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridUserList.PageIndex = e.NewPageIndex;
            refresh();
        }
        protected void GridUserList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "updateInfo")
            {
                openTransDetails(e.CommandArgument.ToString());

            }

            if (e.CommandName == "view")
            {
                Session["ACTIVE_EMPNO"] = e.CommandArgument.ToString();
                Response.Redirect("~/Pages/Admin/userview.aspx?empid=" + e.CommandArgument.ToString());
            }


            if (e.CommandName == "Sort")
            {
                sort_grid(e.CommandArgument.ToString());

            }

            if (e.CommandName == "Reset")
            {
                refresh();
            }


        }
        protected void sort_grid(string sort_args)
        {
            DataTable dt = (DataTable)ViewState["USER_MASTER"];
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

                GridUserList.DataSource = dt;
                GridUserList.DataBind();


            }

        }
        /// <summary>
        /// Event that will trigger the search and get values from the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            //awong-retrieve textbox values from the grid control during runtime.
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
            //string a1 = ((TextBox)GridUserList.FindControl("txtSearch1")).Text;
            //string a2 = ((TextBox)GridUserList.FindControl("txtSearch2")).Text;

            string a1 = ((TextBox)currentRow.FindControl("txtSearchFullName")).Text;
            string a2 = ((TextBox)currentRow.FindControl("txtSearchEmpNo")).Text;
            string a3 = ((TextBox)currentRow.FindControl("txtSearchUsername")).Text;
            string a4 = ((TextBox)currentRow.FindControl("txtSearchEmail")).Text;
            string a5 = ((TextBox)currentRow.FindControl("txtSearchStatus")).Text;
            if (a5.Contains("LOCKED"))
            {
                a5 = ">=3";
            }
            else
                a5 = "<3";
            string expr = emp.build_or_like_param(true, saveSearchParam(a1, a2, a3, a4, a5));
            GridUserList.DataSource = db_Emp.populateGridUserListCol(expr);
            GridUserList.DataBind();

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
        Dictionary<string, string> saveSearchParam(string a1, string a2, string a3, string a4, string a5)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("emp_FullName", "'%" + a1 + "%'");
            param.Add("emp_EmpID", "'%" + a2 + "%'");
            param.Add("username", "'%" + a3 + "%'");
            param.Add("email", "'%" + a4 + "%'");
            param.Add("loginAttempt", "'%" + a5 + "%'");


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
            string username = "", fullname = "", email = "", roles = "";
            db_Emp.getUserInfo(empNo, out username, out fullname, out email, out roles);
            txtbox_username.Text = username;
            lblfname.Text = fullname;
            HiddenEmpID.Value = empNo;
            //TODO dapat fullname to


            //db_Emp.getEmployeeInfo(empNo, out fname, out mname, out lname);
            ////txtbox_fname.Text = fname;
            ////txtbox_mname.Text = mname;
            ////txtbox_lname.Text = lname;




        }
        protected void lnkbtnXlist_Click(object sender, EventArgs e)
        {
            closeTransDetails();
        }
        protected void btnsaveUpdate_Click(object sender, EventArgs e)
        {
            if (txtbox_username.Text != "" && txtbox_password.Text != "")
            {
                db_Emp.updateUserInfo(HiddenEmpID.Value, txtbox_username.Text, txtbox_password.Text, (drpdwn_acctstatus.SelectedValue == "1" ? true : false));
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully updated !!!');", true);
                closeTransDetails();
                refresh();
            }
            else
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Fields should not be empty !!!');", true);
        }

        public void closeViewModal()
        {
            UPViewUser.Update();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(string.Format(@"$('#{0}').modal('hide')", "ViewUserModal"));
            sb.Append(@"</script>");

            ScriptManager.RegisterStartupScript(this, this.GetType(), "ViewUserModal", sb.ToString(), false);

        }
        public void openViewModal(string empNo)
        {
            UPViewUser.Update();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(string.Format(@"$('#{0}').modal('show')", "ViewUserModal"));
            sb.Append(@"</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ViewUserModal", sb.ToString(), false);
            string username = "", fullname = "", email = "", roles = "";

            db_Emp.getUserInfo(empNo, out username, out fullname, out email, out roles);
            mlblusrname.Text = username;
            mlblempno.Text = empNo;
            lblfname.Text = fullname;

            //TODO dapat fullname to


            //db_Emp.getEmployeeInfo(empNo, out fname, out mname, out lname);
            ////txtbox_fname.Text = fname;
            ////txtbox_mname.Text = mname;
            ////txtbox_lname.Text = lname;




        }
        protected void lnkbtnXlist2_Click(object sender, EventArgs e)
        {
            closeViewModal();
        }

        protected void btnexitviewmodal_Click(object sender, EventArgs e)
        {
            closeViewModal();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("content-disposition", "attachment;filename= UserAccountList" + ".xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Charset = "";
            this.EnableViewState = false;

            System.IO.StringWriter swriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlwriter = new System.Web.UI.HtmlTextWriter(swriter);

            DataGrid dg = new DataGrid();
            dg.DataSource = db_Emp.populateGridUserList();
            dg.DataBind();

            dg.RenderControl(htmlwriter);


            Response.Write(swriter.ToString());
            cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " exported User List to Excel File",
                    "EXPORT", "x123", "qwg-23", "EXPORT", Session["EMP_ID"].ToString());
            Response.End();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {


        }
    }
}