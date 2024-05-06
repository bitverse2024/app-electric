using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin.PayrollPages
{
    public partial class EmployeeAdjustmentList : System.Web.UI.Page
    {
        public int gridtotalcount = 0;
        public string gridrangecount = "";
        public static string empno = "";
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
            dt = emp.populateGridEmployeeAdjustmentOthers(empno);
            GridViewList.DataSource = dt;
            GridViewList.DataBind();
            ViewState["EMP_GRID"] = dt;
            ViewState["SORTDR"] = null;
            summary();
        }
        Dictionary<string, string> saveSearchParam(string _CutOffID, string _AdjustmentAdd, string _AdjRemarks, string _AdjustmentOthersAdd, string _AdjOthrsRemarks)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();

            param.Add("CutOffID", "'%" + _CutOffID + "%'");
            param.Add("AdjustmentAdd", "'%" + _AdjustmentAdd + "%'");
            param.Add("AdjRemarks", "'%" + _AdjRemarks + "%'");
            param.Add("AdjustmentOthersAdd", "'%" + _AdjustmentOthersAdd + "%'");
            param.Add("AdjOthrsRemarks", "'%" + _AdjOthrsRemarks + "%'");
            return param;


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
            string _CutOffID = ((TextBox)currentRow.FindControl("txtCutOffID")).Text;
            string _AdjustmentAdd = ((TextBox)currentRow.FindControl("txtSSSDed")).Text;
            string _AdjRemarks = ((TextBox)currentRow.FindControl("txtPhilDed")).Text;
            string _AdjustmentOthersAdd = ((TextBox)currentRow.FindControl("txtPagibigDed")).Text;
            string _AdjOthrsRemarks = ((TextBox)currentRow.FindControl("txtPagibigDed")).Text;
            string expr = emp.build_or_like_param(saveSearchParam(_CutOffID, _AdjustmentAdd, _AdjRemarks, _AdjustmentOthersAdd, _AdjOthrsRemarks));
            GridViewList.DataSource = emp.populateGridEmployeeAdjustmentOthersCol(expr, empno);
            GridViewList.DataBind();
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
                //Session["ACTIVE_EMPNO"] = e.CommandArgument.ToString();
                //Response.Redirect("~/Pages/Admin/PayrollPages/viewdts.aspx?id=" + e.CommandArgument.ToString());

            }
            if (e.CommandName == "del")
            {
                string getiscomputed = cm.GetSpecificDataFromDB("iscomputed", "TBL_ADJUSTMENT", "where id = " + e.CommandArgument.ToString() + "");
                //0 false
                if (getiscomputed != "1")
                {

                    emp.DeleteQuery("TBL_ADJUSTMENT", "where id =" + e.CommandArgument.ToString() + "");
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " removed ADJUSTMENT for Employee " + empno,
                        "DELETE", "x123", "qwg-23", "DELETE", Session["EMP_ID"].ToString());
                    refresh();
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                    "alert",
                    "alert('Successfully Deleted');",
                    true);
                }
                else
                {
                    refresh();
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                    "alert",
                    "alert('data is being used by another table.');",
                    true);
                }


            }

        }


    }
}