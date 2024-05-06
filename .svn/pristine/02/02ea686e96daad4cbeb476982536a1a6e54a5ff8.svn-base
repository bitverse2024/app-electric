using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HRIS_APPELECTRIC.Pages.AdminKiosk
{
    public partial class adminsuppliesrequest : System.Web.UI.Page
    {
        public int gridtotalcount = 0;
        public string gridrangecount = "";
        AdminLib admin = new AdminLib();
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
            dt = admin.populateGridSupplyRequest();
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
            string txtSearchdepartment = ((TextBox)currentRow.FindControl("txtSearchdepartment")).Text;
            string txtSearchitem_Name = ((TextBox)currentRow.FindControl("txtSearchitem_Name")).Text;
            string txtSearchquantity = ((TextBox)currentRow.FindControl("txtSearchquantity")).Text;
            string txtSearchrequested_By = ((TextBox)currentRow.FindControl("txtSearchrequested_By")).Text;
            string txtSearchdate_Requested = ((TextBox)currentRow.FindControl("txtSearchdate_Requested")).Text;
            string txtSearchstatus = ((TextBox)currentRow.FindControl("txtSearchstatus")).Text;


            string expr = admin.build_or_like_param(true, saveSearchParam(txtSearchdepartment, txtSearchitem_Name, txtSearchquantity, txtSearchrequested_By, txtSearchdate_Requested, txtSearchstatus));
            //string expr = "and (license_type like '%" + lictype + "%' or license_no like '%" + licno + "%' or lic_expirydate like '%" + licdate + "%')";
            //GridViewList.DataSource = emp.populateGridSearch((DataTable)ViewState["EMP_GRID"], expr);
            GridViewList.DataSource = admin.populateGridSupplyRequestCol(expr);
            GridViewList.DataBind();



        }
        Dictionary<string, string> saveSearchParam(string txtSearchdepartment, string txtSearchitem_Name, string txtSearchquantity, string txtSearchrequested_By, string txtSearchdate_Requested, string txtSearchstatus)
        {

            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("item_Name", "'%" + txtSearchdepartment + "%'");
            param.Add("quantity", "'%" + txtSearchitem_Name + "%'");
            param.Add("item_Name", "'%" + txtSearchquantity + "%'");
            param.Add("quantity", "'%" + txtSearchrequested_By + "%'");
            param.Add("item_Name", "'%" + txtSearchdate_Requested + "%'");
            param.Add("quantity", "'%" + txtSearchstatus + "%'");
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
                //HiddenEmpID.Value = e.CommandArgument.ToString();
                //populateUpdateField(e.CommandArgument.ToString());
                //openTransDetails(empno);

            }
            if (e.CommandName == "del")
            {
                admin.DeleteQuery("TBL_SUPPLYREQUEST", "where id =" + e.CommandArgument.ToString() + "");
                refresh();
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Successfully Deleted');",
                true);

            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("content-disposition", "attachment;filename= SupplyRequestList" + ".xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Charset = "";
            this.EnableViewState = false;

            System.IO.StringWriter swriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlwriter = new System.Web.UI.HtmlTextWriter(swriter);

            DataGrid dg = new DataGrid();
            dg.DataSource = admin.populateGridAllOfficeSupplies();
            dg.DataBind();

            dg.RenderControl(htmlwriter);


            Response.Write(swriter.ToString());
            Response.End();
            //exportTOxlsx();

        }
    }
}