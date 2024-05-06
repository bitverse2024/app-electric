using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HRIS_APPELECTRIC.Pages.Admin.TK
{
    public partial class leaves : System.Web.UI.Page
    {
        Employee emp = new Employee();
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
            dt = emp.populateGridEmployeeMasterEFiling();
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
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
            string _empid = ((TextBox)currentRow.FindControl("txtSearchempid")).Text;
            string _fname = ((TextBox)currentRow.FindControl("txtSearchFullName")).Text;
            string expr = emp.build_or_like_param(saveSearchParam(_empid, _fname));
            GridViewList.DataSource = emp.populateGridEmployeeMasterEFilingCol(expr);
            GridViewList.DataBind();
            summary();



        }
        Dictionary<string, string> saveSearchParam(string _empid, string _fname)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();

            param.Add("emp_EmpID", "'%" + _empid + "%'");
            param.Add("emp_FullName", "'%" + _fname + "%'");

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
                Response.Redirect("~/Pages/Admin/TK/viewleaves.aspx?id=" + e.CommandArgument.ToString());
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
    }
}