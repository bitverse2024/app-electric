using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin.PayrollPages
{
    public partial class viewcashad : System.Web.UI.Page
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
                ddlCutOff.Items.AddRange(emp.GetDropDownMenuList("TBL_CUTOFF", "CDesc"));
                refresh();
            }
        }
        void refresh()
        {
            DataTable dt = new DataTable();
            dt = emp.populateGridEmployeeCashAdvance(empno);
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
            if (e.CommandName == "upd")
            {
                HiddenEmpID.Value = e.CommandArgument.ToString();
                populateUpdateField(e.CommandArgument.ToString());
                openTransDetails();

            }
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
        public void populateUpdateField(string id)
        {
            ddlCutOff.SelectedValue = cm.GetSpecificDataFromDB("CutOffID", "TBL_CASHADVANCE", "where id = " + id + "");
            updCashAd.Value = cm.GetSpecificDataFromDB("LoanBalance", "TBL_CASHADVANCE", "where id = " + id + "");
            updLoanBal.Value = cm.GetSpecificDataFromDB("CashAdvance", "TBL_CASHADVANCE", "where id = " + id + "");
            

        }
        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
        }
        protected void btnsaveUpdate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                //getdata();
                if (cm.UpdateQueryCommon(saveUpdateParam(), "TBL_CASHADVANCE", "id = " + HiddenEmpID.Value + ""))
                {


                    refresh();

                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully updated !!!');", true);
                    closeTransDetails();
                    refresh();
                }
                else
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Fields should not be empty !!!');", true);
            }
        }
        Dictionary<string, string> saveUpdateParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();

            param.Add("CutOffID", "" + ddlCutOff.SelectedValue + "");
            param.Add("CashAdvance", "" + updCashAd.Value + "");
            param.Add("LoanBalance", "" + updLoanBal.Value + "");


            return param;


        }
        protected void lnkbtnXlist_Click(object sender, EventArgs e)
        {
            closeTransDetails();
        }
        public void openTransDetails()
        {
            upListDetails.Update();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(string.Format(@"$('#{0}').modal('show')", "listmodal"));
            sb.Append(@"</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "listmodal", sb.ToString(), false);
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

        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("content-disposition", "attachment;filename= CashAd" + empno + ".xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Charset = "";
            this.EnableViewState = false;

            System.IO.StringWriter swriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlwriter = new System.Web.UI.HtmlTextWriter(swriter);

            DataGrid dg = new DataGrid();
            dg.DataSource = emp.populateGridEmployeeCashAdvance(empno);
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