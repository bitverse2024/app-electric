using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HRIS_APPELECTRIC.Pages.AdminKiosk
{
    public partial class adminpassword : System.Web.UI.Page
    {
        AdminLib adl = new AdminLib();
        User dbconn = new User();
        Employee emp = new Employee();
        Common cm = new Common();
        public string empno = "";
        public static string activeempno = "";
        public string emprole = "";
        public string FFName = "";
        public string FLName = "";
        public string firstName = "";
        public string lastName = "", bday = "", bday1 = "", pswrd = "", pwdSha1MD5 = "";
        string empviewURL = "";
        public int gridtotalcount = 0;
        public string gridrangecount = "";
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
        void refresh()
        {
            select_role.Value = "employee";
            emprole = select_role.Value;
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
            emprole = select_role.Value;

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


            if (select_role.Value != "")
            {
                emprole = select_role.Value;
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

            if (e.CommandName == "reset")
            {
                populateUpdateField(e.CommandArgument.ToString());
                openTransDetails(empno);
                //FFName = emp.GetEmployeeFirstName(e.CommandArgument.ToString());
                //FLName = emp.GetEmployeeLastName(e.CommandArgument.ToString());
                //firstName = FFName[0].ToString();
                //lastName = FLName[0].ToString();
                //bday = cm.FormatDate(emp.GetEmployeeBirthday(e.CommandArgument.ToString()));

                //if (firstName != "" && lastName != "")
                //{

                //    cm.UpdateQueryCommon(saveUpdateParam(firstName, lastName, bday), "TBL_USERS", "empid = " + e.CommandArgument.ToString() + "");
                //    refresh();
                //    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully updated !!!');", true);

                //}
                //else
                //    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('User not found');", true);


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
        protected void lnkbtnXlist_Click(object sender, EventArgs e)
        {
            closeTransDetails();
        }
        public void populateUpdateField(string id)
        {
            activeempno = id;

            FFName = emp.GetEmployeeFirstName(id);
            FLName = emp.GetEmployeeLastName(id);
            Label1.Text = "" + id + " - " + FLName + ", " + FFName + "";
            firstName = FFName[0].ToString();
            lastName = FLName[0].ToString();
            bday = cm.FormatDateForPassword(emp.GetEmployeeBirthday(id));
            rst_Password.Value = "" + firstName + "" + lastName + "" + bday + "";
            //a = first letter of first name e.g(Juan Carlos M. Dela Cruz) = "J"
            //b = first letter of lastname e.g(Juan Carlos M. Dela Cruz) = "D"
            //c = birthday with format (MMddyyyy)
            //default password format is letter of "JDMMddyyyy"(a+b+c)
        }
        protected void btnsaveUpdate_Click(object sender, EventArgs e)
        {
            if (rst_Password.Value != null)
            {

                cm.UpdateQueryCommon(saveUpdateParam(rst_Password.Value), "TBL_USERS", "empid = " + activeempno + "");
                refresh();
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully updated !!!');", true);

            }
            else
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('User not found');", true);

        }

        Dictionary<string, string> saveUpdateParam(string psrwddef)
        {
            pswrd = "";
            pwdSha1MD5 = "";
            pswrd = psrwddef;
            pwdSha1MD5 = dbconn.GetSha1(dbconn.MD5Hash(psrwddef));
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("password", "'" + pwdSha1MD5 + "'");
            return param;
        }
    }
}