using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HRIS_APPELECTRIC.Pages.Admin
{
    public partial class mrlist : System.Web.UI.Page
    {
        Timekeeping tk = new Timekeeping();
        Employee emp = new Employee();
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
            DataTable dt = new DataTable();
            dt = emp.populateGridMR();
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
            string txtSearchDiv = ((TextBox)currentRow.FindControl("txtSearchDiv")).Text;
            string txtSearchPos = ((TextBox)currentRow.FindControl("txtSearchPos")).Text;
            string txtSearchWorkExperience = ((TextBox)currentRow.FindControl("txtSearchWorkExperience")).Text;
            string txtSearchSkills = ((TextBox)currentRow.FindControl("txtSearchSkills")).Text;
            string txtSearchRequestedBy = ((TextBox)currentRow.FindControl("txtSearchRequestedBy")).Text;
            string expr = emp.build_or_like_param(true, saveSearchParam(txtSearchDiv, txtSearchPos, txtSearchWorkExperience, txtSearchSkills, txtSearchRequestedBy));
            //string expr = "and (license_type like '%" + lictype + "%' or license_no like '%" + licno + "%' or lic_expirydate like '%" + licdate + "%')";
            //GridViewList.DataSource = emp.populateGridSearch((DataTable)ViewState["EMP_GRID"], expr);
            GridViewList.DataSource = emp.populateGridMRCol(expr);
            GridViewList.DataBind();



        }
        Dictionary<string, string> saveSearchParam(string txtSearchDiv, string txtSearchPos, string txtSearchWorkExperience, string txtSearchSkills, string txtSearchRequestedBy)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("DivName", "'%" + txtSearchDiv + "%'");
            param.Add("PositionName", "'%" + txtSearchPos + "%'");
            param.Add("worexperience", "'%" + txtSearchWorkExperience + "%'");
            param.Add("skills", "'%" + txtSearchSkills + "%'");
            param.Add("requestedby", "'%" + txtSearchRequestedBy + "%'");

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
            if (e.CommandName == "Reset")
            {
                refresh();

            }
            if (e.CommandName == "del")
            {
                emp.DeleteQuery("TBL_MR", "where id =" + e.CommandArgument.ToString() + "");
                refresh();
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Successfully Deleted');",
                true);

            }
        }
    }
}