using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin.PayrollPages
{
    public partial class cashademp : System.Web.UI.Page
    {
        public int gridtotalcount = 0;
        public string gridrangecount = "";
        public string empno = "";
        Employee emp = new Employee();
        Common cm = new Common();
        protected void Page_Load(object sender, EventArgs e)
        {
            empno = Request.QueryString["empid"];
            if (!IsPostBack)
            {
                refresh();
            }

        }

        void refresh()
        {
            DataTable dt = new DataTable();
            dt = emp.populateGridAdjustmentMaster();
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
        Dictionary<string, string> saveSearchParam(string _empno, string _fname)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();

            param.Add("emp_EmpID", "'%" + _empno + "%'");
            param.Add("emp_FullName", "'%" + _fname + "%'");
            
            return param;


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

            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
            string _empno = ((TextBox)currentRow.FindControl("txtSearchempid")).Text;
            string _fname = ((TextBox)currentRow.FindControl("txtSearchFullName")).Text;
           
            string expr = emp.build_or_like_param(saveSearchParam(_empno, _fname));
            GridViewList.DataSource = emp.populateGridAdjustmentMasterCol(expr);
            GridViewList.DataBind();
        }
        protected void GridViewList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewList.PageIndex = e.NewPageIndex;
            refresh();
        }
        protected void GridViewList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "view")
            {
                Session["ACTIVE_EMPNO"] = e.CommandArgument.ToString();
                Response.Redirect("~/Pages/Admin/PayrollPages/viewcashad.aspx?empid=" + e.CommandArgument.ToString());

            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("content-disposition", "attachment;filename= CashAdvance" + ".xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Charset = "";
            this.EnableViewState = false;

            System.IO.StringWriter swriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlwriter = new System.Web.UI.HtmlTextWriter(swriter);

            DataGrid dg = new DataGrid();
            dg.DataSource = emp.populateGridAdjustmentMaster();
            dg.DataBind();

            dg.RenderControl(htmlwriter);


            Response.Write(swriter.ToString());
            cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " exported CASH ADVANCE",
            "EXPORT", "PAYROLL", Session["EMP_ID"].ToString(), "PAYROLL", Session["EMP_ID"].ToString());
            Response.End();
            //exportTOxlsx();


        }
    }
}