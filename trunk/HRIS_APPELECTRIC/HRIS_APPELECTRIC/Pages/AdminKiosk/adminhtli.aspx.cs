using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace HRIS_APPELECTRIC.Pages.AdminKiosk
{
    public partial class adminhtli : System.Web.UI.Page
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
            dt = admin.populateGridHTLI();
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
            string txtSearchName = ((TextBox)currentRow.FindControl("txtSearchName")).Text;
            string txtSearchPosition = ((TextBox)currentRow.FindControl("txtSearchPosition")).Text;
            string txtSearchCp_Number = ((TextBox)currentRow.FindControl("txtSearchCp_Number")).Text;
            string txtSearchPhone_Number = ((TextBox)currentRow.FindControl("txtSearchPhone_Number")).Text;
            string txtSearchEmail = ((TextBox)currentRow.FindControl("txtSearchEmail")).Text;



            string expr = admin.build_or_like_param(true, saveSearchParam(txtSearchName, txtSearchPosition, txtSearchCp_Number, txtSearchPhone_Number, txtSearchEmail));
            //string expr = "and (license_type like '%" + lictype + "%' or license_no like '%" + licno + "%' or lic_expirydate like '%" + licdate + "%')";
            //GridViewList.DataSource = emp.populateGridSearch((DataTable)ViewState["EMP_GRID"], expr);
            GridViewList.DataSource = admin.populateGridHTLICol(expr);
            GridViewList.DataBind();



        }
        Dictionary<string, string> saveSearchParam(string txtSearchName, string txtSearchPosition, string txtSearchCp_Number, string txtSearchPhone_Number, string txtSearchEmail)
        {

            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("Name", "'%" + txtSearchName + "%'");
            param.Add("Position", "'%" + txtSearchPosition + "%'");
            param.Add("Cp_Number", "'%" + txtSearchCp_Number + "%'");
            param.Add("Phone_Number", "'%" + txtSearchPhone_Number + "%'");
            param.Add("Email", "'%" + txtSearchEmail + "%'");

            //if (double.TryParse(txtSearchGracePeriod, out testval)) param.Add("GracePeriod", "" + txtSearchGracePeriod + "");
            //if (double.TryParse(txtallowance1, out testval)) param.Add("allowance1", "" + txtallowance1 + "");
            //if (double.TryParse(txtallowance2, out testval)) param.Add("allowance2", "" + txtallowance2 + "");

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
                admin.DeleteQuery("TBL_HTLI", "where id =" + e.CommandArgument.ToString() + "");
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
            Response.AddHeader("content-disposition", "attachment;filename= HTLIList" + ".xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Charset = "";
            this.EnableViewState = false;

            System.IO.StringWriter swriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlwriter = new System.Web.UI.HtmlTextWriter(swriter);

            DataGrid dg = new DataGrid();
            dg.DataSource = admin.populateGridAllHTLI();
            dg.DataBind();

            dg.RenderControl(htmlwriter);


            Response.Write(swriter.ToString());
            Response.End();
            //exportTOxlsx();

        }

        protected void ExportToPDF(object sender, EventArgs e)
        {

            //Create a dummy GridView
            DataTable dt = new DataTable();
            dt = admin.populateGridHTLI();

            GridView GridView2 = new GridView();

            GridView2.AllowPaging = false;

            GridView2.DataSource = dt;

            GridView2.DataBind();



            Response.ContentType = "application/pdf";

            Response.AddHeader("content-disposition",

                "attachment;filename=HTLIList.pdf");

            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            StringWriter sw = new StringWriter();

            HtmlTextWriter hw = new HtmlTextWriter(sw);

            GridView2.RenderControl(hw);

            StringReader sr = new StringReader(sw.ToString());

            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);

            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

            pdfDoc.Open();

            htmlparser.Parse(sr);

            pdfDoc.Close();

            Response.Write(pdfDoc);

            Response.End();

        }
    }
}