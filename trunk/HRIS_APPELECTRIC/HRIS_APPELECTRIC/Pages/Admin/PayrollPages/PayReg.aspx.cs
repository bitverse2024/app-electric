using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;


namespace HRIS_APPELECTRIC.Pages.Admin.PayrollPages
{
    public partial class PayReg : System.Web.UI.Page
    {
        Payroll pr = new Payroll();
        Employee db_Emp = new Employee();
        Common cm = new Common();
        string[] searchItem = new string[2];
        public string empid = "";
        public string empname = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                refresh();
                populateMenus();

            }
        }
        /// <summary>
        /// Reset/Refresh the employee list
        /// </summary>
        void refresh()
        {
            //w
            //GridUserList.DataSource = db.populateGridUserList();
            //GridUserList.DataBind();
            DataTable dt = new DataTable();
            dt = pr.populateGridPayrollRegister();
            GridUserList.DataSource = dt;
            GridUserList.DataBind();
            ViewState["EMP_MASTER"] = dt;
            ViewState["SORTDR"] = null;

        }
        void populateMenus()
        {

            //ddlSearch.Items.AddRange(db_Emp.GetDropDownMenuListPayrollReg("TBL_CUTOFF", "CDesc"));

            



        }

        protected void GridUserList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridUserList.PageIndex = e.NewPageIndex;
            refresh();
        }
        protected void GridUserList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                Session["ACTIVE_EMPNO"] = e.CommandArgument.ToString();
                openMbox();
                //string getemp = cm.GetSpecificDataFromDB("emp_FullName", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = " + e.CommandArgument.ToString() + "");
                //db_Emp.DeleteQuery("TBL_EMPLOYEE_MASTER", "where emp_EmpID =" + e.CommandArgument.ToString() + "");
                //cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " removed Employee " + getemp,
                //    "DELETE", "x123", "qwg-23", "DELETE", Session["EMP_ID"].ToString());
                //refresh();
                //ScriptManager.RegisterStartupScript(this, this.GetType(),
                //"alert",
                //"alert('Successfully Deleted');",
                //true);

            }

            if (e.CommandName == "view")
            {
                Session["ACTIVE_EMPNO"] = e.CommandArgument.ToString();
                Response.Redirect("~/Pages/Admin/Employees/EmployeeView.aspx?empid=" + e.CommandArgument.ToString());
            }

            if (e.CommandName == "update")
            {
                Session["ACTIVE_EMPNO"] = e.CommandArgument.ToString();
                Response.Redirect("~/Pages/Admin/PayrollPages/payregupdate.aspx?empid=" + e.CommandArgument.ToString());
                //openTransDetails(e.CommandArgument.ToString());
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


            //Label lbl = this.FindControl("lblEmpNo") as Label;
            //lbl.Text = "Hello";
            DataTable dt = (DataTable)ViewState["EMP_MASTER"];

            foreach (DataRow row in dt.Rows)
            {
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
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
            string a1 = ((TextBox)currentRow.FindControl("txtSearchEmpName")).Text;
            string a2 = ((TextBox)currentRow.FindControl("txtSearchGrossPay")).Text;

            string a3 = ((TextBox)currentRow.FindControl("txtSearchSSSDed")).Text;
            string a4 = ((TextBox)currentRow.FindControl("txtSearchPhilhealthDed")).Text;
            string a5 = ((TextBox)currentRow.FindControl("txtSearchPagibigDed")).Text;

            string a6 = ((TextBox)currentRow.FindControl("txtSearchTotDed")).Text;
            string a7 = ((TextBox)currentRow.FindControl("txtSearchNetPay")).Text;

            string a8 = ((TextBox)currentRow.FindControl("txtSearchUT")).Text;
            string a9 = ((TextBox)currentRow.FindControl("txtSearchAbsent")).Text;
            string a10 = ((TextBox)currentRow.FindControl("txtSearchLates")).Text;
            string a11 = ((TextBox)currentRow.FindControl("txtSearchOTPay")).Text;

            string expr = pr.build_or_like_paramPayroll(saveSearchParam(a1, a2, a3, a4,a5, a6, a7, a8,a9,a10,a11));
            

            GridUserList.DataSource = pr.populateGridPayrollRegisterCol(expr);
            GridUserList.DataBind();

            

        }
        //protected void ddlSearch_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DataTable dt = new DataTable();
        //    dt = pr.populateGridPayrollRegisterddl(ddlSearch.SelectedValue);
        //    GridUserList.DataSource = dt;
        //    GridUserList.DataBind();
        //    ViewState["EMP_MASTER"] = dt;
        //    ViewState["SORTDR"] = null;
            

        //}
        Dictionary<string, string> saveSearchParam(string a1, string a2, string a3, string a4, string a5, string a6, string a7, string a8, string a9, string a10, string a11)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("EmployeeName", "'%" + a1 + "%'");
            param.Add("GrossPay", "'%" + a2 + "%'");
            param.Add("SSSDed", "'%" + a3 + "%'");
            param.Add("PhilhealthDed", "'%" + a4 + "%'");
            param.Add("PagibigDed", "'%" + a5 + "%'");
            param.Add("TotDed", "'%" + a6 + "%'");
            param.Add("NetPay", "'%" + a7 + "%'");
            param.Add("UTDed", "'%" + a8 + "%'");
            param.Add("AbsentDed", "'%" + a9 + "%'");
            param.Add("LatesDed", "'%" + a10 + "%'");
            param.Add("OTPay", "'%" + a11 + "%'");



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
            lblEmpNo.Text = empNo;

            //db_Emp.getEmployeeInfo(empNo, out fname, out mname, out lname);





        }
        protected void lnkbtnXlist_Click(object sender, EventArgs e)
        {
            closeTransDetails();
        }
        protected void btnDoDelete_Click(object sender, EventArgs e)
        {
            if (deleteDropDownList.SelectedValue == "D")
            {
                HiddenDeleteNo.Value = lblEmpNo.Text;
                openMbox();
                return;
            }
            if (db_Emp.updateEmployeeActiveStatus(lblEmpNo.Text, deleteDropDownList.SelectedValue))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully updated !!!');", true);
                closeTransDetails();
                refresh();
            }
            //else
            //    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Failed to update !!!');", true);

            //if (txtbox_fname.Text != "" && txtbox_mname.Text != "" && txtbox_lname.Text != "")
            //{
            //    db_Emp.updateEmployeeInfo(lblEmpNo.Text, txtbox_fname.Text, txtbox_mname.Text, txtbox_lname.Text);
            //    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully updated !!!');", true);
            //    closeTransDetails();
            //    refresh();
            //}
            //else
            //    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Name should not be empty !!!');", true);
        }


        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("content-disposition", "attachment;filename= PayReg" + ".xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Charset = "";
            this.EnableViewState = false;

            System.IO.StringWriter swriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlwriter = new System.Web.UI.HtmlTextWriter(swriter);

            DataGrid dg = new DataGrid();
            dg.DataSource = db_Emp.populateGridAllEmployee();
            dg.DataBind();

            dg.RenderControl(htmlwriter);


            Response.Write(swriter.ToString());
            cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " exported Employee Master",
            "EXPORT", "x123", "qwg-23", "EXPORT", Session["EMP_ID"].ToString());
            Response.End();
            //exportTOxlsx();


        }

        void exportTOxlsx()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/octet-stream";
            //Response.AddHeader("content-disposition", "attachment;filename= EmployeeMasterList" + ".xls");
            //Response.ContentType = "application/vnd.ms-excel";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=EmployeeMasterList.xlsx");
            Response.Charset = "";
            this.EnableViewState = false;

            System.IO.StringWriter swriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlwriter = new System.Web.UI.HtmlTextWriter(swriter);

            DataGrid dg = new DataGrid();
            dg.DataSource = db_Emp.populateGridAllEmployee();
            dg.DataBind();

            dg.RenderControl(htmlwriter);


            Response.Write(swriter.ToString());
            Response.End();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {


        }



        protected void openMbox()
        {
            //closeTransDetails();
            empid = Session["ACTIVE_EMPNO"].ToString();
            empname = db_Emp.GetEmployeeFullName(empid);
            updateMbox.Update();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(string.Format(@"$('#{0}').modal('show')", "mbox_modal"));
            sb.Append(@"</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "mbox_modal", sb.ToString(), false);
            Label1.Text = "Confirmation (Deletion " + empid + " , " + empname + ")";
        }
        protected void closeMbox()
        {
            updateMbox.Update();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(string.Format(@"$('#{0}').modal('hide')", "mbox_modal"));
            sb.Append(@"</script>");

            ScriptManager.RegisterStartupScript(this, this.GetType(), "mbox_modal", sb.ToString(), false);
        }
        protected void closeMbox_click(object sender, EventArgs e)
        {
            closeMbox();
        }
        protected void btnConfirmClick(object sender, EventArgs e)
        {
            empid = Session["ACTIVE_EMPNO"].ToString();
            string aa = ((Button)sender).CommandArgument;
            if (aa == "YES")
            {
                //db_Emp.DeleteQuery("TBL_EMPLOYEE_MASTER", "where emp_EmpID =" + empid + "");
                //db_Emp.DeleteEmployee(HiddenDeleteNo.Value);
                db_Emp.DeleteEmployee(empid);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully DELETED !!!');", true);
            }
            else
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Cancelled Deletion!!!');", true);
            closeTransDetails();
            closeMbox();
            refresh();

        }

    }
}