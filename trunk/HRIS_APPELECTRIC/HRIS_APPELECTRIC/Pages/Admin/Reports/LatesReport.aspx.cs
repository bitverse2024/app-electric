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
    public partial class LatesReport : System.Web.UI.Page
    {
        Employee db = new Employee();
        User dbUser = new User();
        Common cm = new Common();
        Timekeeping tk = new Timekeeping();
        string contrimonth = "", contriyear = "", contripaygroup = "", contriemp = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                refresh();
            }
        }
        void refresh()
        {
            ddlEmp.Items.AddRange(db.GetDropDownMenuList("TBL_EMPLOYEE_MASTER", "emp_FullName", "emp_EmpID"));
        }
        
        
        protected void ExportToPDF(object sender, EventArgs e)
        {

            
            //Create a dummy GridView
            DataTable dt = new DataTable();
            string yr = "", month = "";
            SplitStr(monthlydt.Value, out yr, out month);
            //GridContributionList.DataSource = tk.populateLatesReportCol(ddlEmp.SelectedValue, yr, month);
            //GridContributionList.DataBind();
            dt = tk.populateLatesReportCol(ddlEmp.SelectedValue, yr, month);

            GridView GridView2 = new GridView();

            GridView2.AllowPaging = false;

            GridView2.DataSource = dt;

            GridView2.DataBind();


            if (GridView2.Rows.Count > 0)
            {
                Response.ContentType = "application/pdf";

                Response.AddHeader("content-disposition",

                    "attachment;filename=LatesReport" + month + yr + ".pdf");

                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                StringWriter sw = new StringWriter();

                HtmlTextWriter hw = new HtmlTextWriter(sw);

                GridView2.RenderControl(hw);

                StringReader sr = new StringReader(sw.ToString());

                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);

                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

                pdfDoc.Open();

                pdfDoc.Add(new Phrase("\r\nLate Report for the Month of " + monthlydt.Value + "\n"));

                htmlparser.Parse(sr);

                pdfDoc.Close();

                Response.Write(pdfDoc);

                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " exported Lates Report to PDF File",
                    "EXPORT", "x123", "qwg-23", "EXPORT", Session["EMP_ID"].ToString());

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
        protected void btnExport_Click(object sender, EventArgs e)
        {
            //Create a dummy GridView
            DataTable dt = new DataTable();
            string yr = "", month = "";
            SplitStr(monthlydt.Value, out yr, out month);
            //GridContributionList.DataSource = tk.populateLatesReportCol(ddlEmp.SelectedValue, yr, month);
            //GridContributionList.DataBind();
            dt = tk.populateLatesReportCol(ddlEmp.SelectedValue, yr, month);

            GridView GridView2 = new GridView();

            GridView2.AllowPaging = false;

            GridView2.DataSource = dt;

            GridView2.DataBind();


            if (GridView2.Rows.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("content-disposition", "attachment;filename= LateReport" + monthlydt.Value + ".xls");
                Response.ContentType = "application/vnd.ms-excel";
                Response.Charset = "";
                this.EnableViewState = false;

                System.IO.StringWriter swriter = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlwriter = new System.Web.UI.HtmlTextWriter(swriter);

                swriter.Write("<table style='border-style:solid; border-width:thin;font-weight:bold;font-size:18px'><tr><td colspan='3' style='border-style:solid; border-width:thin;text-align:center'>Late Report for " + monthlydt.Value + "</td></tr>" +
               "</table>");
                //DataGrid dg = new DataGrid();
                //dg.DataSource = tk.populateGridSchedule();
                //dg.DataBind();


                GridView2.RenderControl(htmlwriter);


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
        void SplitStr(string strtocut, out string year, out string mnth)
        {
            char[] spearator = { '-' };
            String[] strlist = strtocut.Split(spearator);
            year = strlist[0];
            mnth = strlist[1];
        }
        
    }
}