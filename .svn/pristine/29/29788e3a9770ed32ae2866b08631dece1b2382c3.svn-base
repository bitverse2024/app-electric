using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin.Reports
{
    public partial class AbsentSummary : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Common cm = new Common();
        Timekeeping tk = new Timekeeping();
        public string empno = "";
        public int gridtotalcount = 0;
        public string gridrangecount = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            empno = Request.QueryString["empid"];

            if (!IsPostBack)
            {
                ddlComp.Items.AddRange(emp.GetDropDownMenuList("TBL_COMPANY", "CoName", "id", "order by CoName asc"));
                ddlDept.Items.AddRange(emp.GetDropDownMenuList("TBL_DEPARTMENT", "DeptName", "id", "order by DeptName asc"));
                //refresh();
            }
        }
        private void refresh()
        {

            DataTable dt = new DataTable();
            dt = tk.populateGridAbsentSummaryCol(ddlComp.SelectedValue, ddlDept.SelectedValue, txt_txtStartDate.Value, txt_txtEndDate.Value);
            GridSummaryList.DataSource = dt;
            GridSummaryList.DataBind();
            ViewState["EMP_GRID"] = dt;
            ViewState["SORTDR"] = null;
            summary();

        }
        void summary()
        {
            gridtotalcount = ((DataTable)ViewState["EMP_GRID"]).Rows.Count;
            int pageIndex = GridSummaryList.PageIndex;
            int c = (pageIndex > 0 ? 10 * pageIndex : 0) + GridSummaryList.Rows.Count;
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

                GridSummaryList.DataSource = dt;
                GridSummaryList.DataBind();
                summary();


            }

        }
        protected void GridViewList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sort")
            {
                sort_grid(e.CommandArgument.ToString());

            }
            
        }
        protected void GridSummaryList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridSummaryList.PageIndex = e.NewPageIndex;
            refresh();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            refresh();
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataGrid dg = new DataGrid();
            dg.DataSource = tk.populateGridAbsentSummaryCol(ddlComp.SelectedValue, ddlDept.SelectedValue, txt_txtStartDate.Value, txt_txtEndDate.Value);
            dg.DataBind();

            if (dg.Items.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("content-disposition", "attachment;filename= AbsentSummary" + txt_txtStartDate.Value + "-" + txt_txtEndDate.Value + ".xls");
                Response.ContentType = "application/vnd.ms-excel";
                Response.Charset = "";
                this.EnableViewState = false;

                System.IO.StringWriter swriter = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlwriter = new System.Web.UI.HtmlTextWriter(swriter);

                swriter.Write("<table style='border-style:solid; border-width:thin;font-weight:bold;font-size:18px'><tr><td colspan='3' style='border-style:solid; border-width:thin;text-align:center'>Absent Summary for " + cm.FormatDateddMMMMyyyy(txt_txtStartDate.Value) + " to " + cm.FormatDateddMMMMyyyy(txt_txtEndDate.Value) + "</td></tr>" +
                "</table>");
                //DataGrid dg = new DataGrid();
                //dg.DataSource = tk.populateGridSchedule();
                //dg.DataBind();


                dg.RenderControl(htmlwriter);


                Response.Write(swriter.ToString());
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
        
        protected void btnPDFExport_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = tk.populateGridAbsentSummaryCol(ddlComp.SelectedValue, ddlDept.SelectedValue, txt_txtStartDate.Value, txt_txtEndDate.Value);
            

            GridView GridView2 = new GridView();

            GridView2.AllowPaging = false;

            GridView2.DataSource = dt;

            GridView2.DataBind();


            if (GridView2.Rows.Count > 0)
            {
                Response.ContentType = "application/pdf";

                Response.AddHeader("content-disposition",

                    "attachment;filename=officestaff" + DateTime.Now.ToShortDateString() + ".pdf");

                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                StringWriter sw = new StringWriter();

                HtmlTextWriter hw = new HtmlTextWriter(sw);

                GridView2.RenderControl(hw);

                StringReader sr = new StringReader(sw.ToString());

                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);

                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

                pdfDoc.Open();

                pdfDoc.Add(new Phrase("\r\nAbsent Summary for " + cm.FormatDateddMMMMyyyy(txt_txtStartDate.Value) + " to " + cm.FormatDateddMMMMyyyy(txt_txtEndDate.Value) + "\n"));

                htmlparser.Parse(sr);

                pdfDoc.Close();

                Response.Write(pdfDoc);

                Response.End();
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