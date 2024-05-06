using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HRIS_APPELECTRIC.Pages.AdminKiosk
{
    public partial class adminusermanagement : System.Web.UI.Page
    {
        Employee db_Emp = new Employee();
        public Common cm = new Common();
        string[] searchItem = new string[2];
        public string empno = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            empno = Request.QueryString["emp_EmpID"];
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
            //w
            //GridUserList.DataSource = db.populateGridUserList();
            //GridUserList.DataBind();
            DataTable dt = new DataTable();
            dt = db_Emp.populateGridEmployeeUAM();
            GridUserList.DataSource = dt;
            GridUserList.DataBind();
            ViewState["EMP_MASTER"] = dt;
            ViewState["SORTDR"] = null;

        }

        protected void GridUserList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridUserList.PageIndex = e.NewPageIndex;
            refresh();
        }
        protected void GridUserList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "upd")
            {
                HiddenEmpID.Value = e.CommandArgument.ToString();
                populateUpdateField(e.CommandArgument.ToString());
                openTransDetails(empno);

            }
        }

        public void populateUpdateField(string id)
        {
            DateTime dt = DateTime.Now;
            Int64 addedDays = Convert.ToInt64(db_Emp.GetEmployeeValidDays(id));
            bool validDate = DateTime.TryParse(db_Emp.GetEmployeeValidTil(id), out dt);
            dt = dt.AddDays(addedDays);
            upd_validdate.Value = db_Emp.GetEmployeeValidDays(id);
            view_validtil.Value = cm.FormatDate(dt);

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

        Dictionary<string, string> saveUpdateParam(string validday)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("validdays", "" + validday + "");


            return param;


        }

        protected void btnsaveUpdate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                //getdata();
                if (upd_validdate.Value != "")
                {
                    //addlogs();
                    cm.UpdateQueryCommon(saveUpdateParam(upd_validdate.Value), "TBL_USERS", "empid = " + HiddenEmpID.Value + "");
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

        protected void sort_grid(string sort_args)
        {
            DataTable dt = (DataTable)ViewState["EMP_MASTER"];
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

        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
            string a1 = ((TextBox)currentRow.FindControl("txtSearchemp_EmpID")).Text;
            string a2 = ((TextBox)currentRow.FindControl("txtSearchemp_FullName")).Text;
            string a3 = ((TextBox)currentRow.FindControl("txtSearchdatecreatep")).Text;
            string a4 = ((TextBox)currentRow.FindControl("txtSearchvaliddays")).Text;
            string expr = db_Emp.build_or_like_param(saveSearchParam(a1, a2, a3, a4));
            GridUserList.DataSource = db_Emp.populateGridEmployeeUAMCol(expr);
            GridUserList.DataBind();



        }
        Dictionary<string, string> saveSearchParam(string a1, string a2, string a3, string a4)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("emp_EmpID", "'%" + a1 + "%'");
            param.Add("emp_FullName", "'%" + a2 + "%'");
            param.Add("datecreatep", "'%" + a3 + "%'");
            param.Add("validdays", "'%" + a4 + "%'");
            return param;


        }
    }
}