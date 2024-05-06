using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HRIS_APPELECTRIC.Pages.Admin.TK
{
    public partial class dts : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Timekeeping tk = new Timekeeping();
        Common cm = new Common();
        public string empno = "";
        string empviewURL = "";
        public int gridtotalcount = 0;
        public string gridrangecount = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                refresh();
            }
        }
        void refresh()
        {
            DataTable dt = new DataTable();
            dt = emp.populateGridDTSMaster();
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
            string _empno = ((TextBox)currentRow.FindControl("txtSearchempid")).Text;
            string _fname = ((TextBox)currentRow.FindControl("txtSearchFullName")).Text;
            string _company = ((TextBox)currentRow.FindControl("txtSearchCompany")).Text;
            string expr = emp.build_or_like_param(saveSearchParam(_empno, _fname, _company));

            //string expr = "and (C.SchoolName like '%" + _schoolcode + "%' or B.CourseName like '%" + _coursecode + "%' or A.IDate like '%" + _idate + "%' or A.Remarks like '%" + _remarks + "%')";
            //GridViewList.DataSource = emp.populateGridSearch((DataTable)ViewState["EMP_GRID"], expr);
            GridViewList.DataSource = emp.populateGridDTSMasterCol(expr);
            GridViewList.DataBind();
            summary();



        }

        Dictionary<string, string> saveSearchParam(string _empno, string _fname, string _company)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();

            param.Add("emp_EmpID", "'%" + _empno + "%'");
            param.Add("emp_FullName", "'%" + _fname + "%'");
            param.Add("emp_Assignment", "'%" + _company + "%'");
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
            if (e.CommandName == "view")
            {
                Session["ACTIVE_EMPNO"] = e.CommandArgument.ToString();
                Response.Redirect("~/Pages/Admin/TK/viewdts.aspx?id=" + e.CommandArgument.ToString());

            }
            //if (e.CommandName == "Reset")
            //{
            //    refresh();

            //}
            //if (e.CommandName == "del")
            //{
            //    emp.DeleteQuery("TBL_OBT", "where id =" + e.CommandArgument.ToString() + "");
            //    refresh();
            //    ScriptManager.RegisterStartupScript(this, this.GetType(),
            //    "alert",
            //    "alert('Successfully Deleted');",
            //    true);

            //}
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataGrid dg = new DataGrid();
            dg.DataSource = tk.populateGridDTS();
            dg.DataBind();
            if (dg.Items.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("content-disposition", "attachment;filename= DTR.xls");
                Response.ContentType = "application/vnd.ms-excel";
                Response.Charset = "";
                this.EnableViewState = false;

                System.IO.StringWriter swriter = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlwriter = new System.Web.UI.HtmlTextWriter(swriter);

                //DataGrid dg = new DataGrid();
                //dg.DataSource = tk.populateGridSchedule();
                //dg.DataBind();


                dg.RenderControl(htmlwriter);


                Response.Write(swriter.ToString());
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " exported DTR Summary to Excel File",
                    "EXPORT", "x123", "qwg-23", "EXPORT", Session["EMP_ID"].ToString());
                Response.End();
                //exportTOxlsx();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(),
               "alert",
               "alert('No data to export!!!');",
               true);
            }
        }
        
    }
}