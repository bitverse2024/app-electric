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
    public partial class LeaveSummary : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Common cm = new Common();
        Timekeeping tk = new Timekeeping();
        public string empno = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            empno = Request.QueryString["empid"];

            if (!IsPostBack)
            {
                refresh();
            }
        }

        private void refresh()
        {
            ddlComp.Items.AddRange(emp.GetDropDownMenuList("TBL_COMPANY", "CoName"));
            ddlComp.DataValueField = emp.GetDropDownMenuList("TBL_COMPANY", "id").ToString();
            ddlDept.Items.AddRange(emp.GetDropDownMenuList("TBL_DEPARTMENT", "DeptName"));
            ddlDept.DataValueField = emp.GetDropDownMenuList("TBL_DEPARTMENT", "id").ToString();

        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string dates = "C.DateFrom BETWEEN '" + txt_txtStartDate.Value + "' AND '" + txt_txtEndDate.Value + "'";
            //string company = cm.GetSpecificDataFromDB("id", "TBL_COMPANY", "where CoName = '" + ddlComp.SelectedItem.ToString() + "'");
            //string department = cm.GetSpecificDataFromDB("id", "TBL_DEPARTMENT", "where DeptName = '" + ddlDept.SelectedItem.ToString() + "'");
            //string comp = "F.id =" + company;
            //string dept = "E.id =" + department;
            string comp = "F.id =" + ddlComp.SelectedValue;
            string dept = "E.id =" + ddlDept.SelectedValue;

            if (ddlComp.SelectedIndex != 0)
            {
                string expr = dates + " AND " + comp;
                GridOT.DataSource = tk.populateGridLeavesSummaryCol(expr);
                GridOT.DataBind();
            }
            if (ddlDept.SelectedIndex != 0)
            {
                string expr = dates + " AND " + dept;
                GridOT.DataSource = tk.populateGridLeavesSummaryCol(expr);
                GridOT.DataBind();
            }
            if (ddlComp.SelectedIndex != 0 && ddlDept.SelectedIndex != 0)
            {
                string expr = dates + " AND " + dept + " AND " + comp;
                GridOT.DataSource = tk.populateGridLeavesSummaryCol(expr);
                GridOT.DataBind();
            }
            if (ddlComp.SelectedIndex == 0 && ddlDept.SelectedIndex == 0)
            {
                string expr = dates;
                GridOT.DataSource = tk.populateGridLeavesSummaryCol(expr);
                GridOT.DataBind();
            }
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            string dates = "C.DateFrom BETWEEN '" + txt_txtStartDate.Value + "' AND '" + txt_txtEndDate.Value + "'";
            //string company = cm.GetSpecificDataFromDB("id", "TBL_COMPANY", "where CoName = '" + ddlComp.SelectedItem.ToString() + "'");
            //string department = cm.GetSpecificDataFromDB("id", "TBL_DEPARTMENT", "where DeptName = '" + ddlDept.SelectedItem.ToString() + "'");
            //string comp = "F.id =" + company;
            //string dept = "E.id =" + department;
            string comp = "F.id =" + ddlComp.SelectedValue;
            string dept = "E.id =" + ddlDept.SelectedValue;
            DataGrid dg = new DataGrid();

            if (ddlComp.SelectedIndex != 0)
            {
                string expr = dates + " AND " + comp;
                dg.DataSource = tk.populateGridLeavesSummaryCol(expr);
                dg.DataBind();
            }
            if (ddlDept.SelectedIndex != 0)
            {
                string expr = dates + " AND " + dept;
                dg.DataSource = tk.populateGridLeavesSummaryCol(expr);
                dg.DataBind();
            }
            if (ddlComp.SelectedIndex != 0 && ddlDept.SelectedIndex != 0)
            {
                string expr = dates + " AND " + dept + " AND " + comp;
                dg.DataSource = tk.populateGridLeavesSummaryCol(expr);
                dg.DataBind();
            }
            if (ddlComp.SelectedIndex == 0 && ddlDept.SelectedIndex == 0)
            {
                string expr = dates;
                dg.DataSource = tk.populateGridLeavesSummaryCol(expr);
                dg.DataBind();
            }


            if (dg.Items.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("content-disposition", "attachment;filename= LeavesSummary" + txt_txtStartDate.Value + "-" + txt_txtEndDate.Value + ".xls");
                Response.ContentType = "application/vnd.ms-excel";
                Response.Charset = "";
                this.EnableViewState = false;

                System.IO.StringWriter swriter = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlwriter = new System.Web.UI.HtmlTextWriter(swriter);

                swriter.Write("<table style='border-style:solid; border-width:thin;font-weight:bold;font-size:18px'><tr><td colspan='3' style='border-style:solid; border-width:thin;text-align:center'>Leave Summary for " + cm.FormatDateddMMMMyyyy(txt_txtStartDate.Value) + " to " + cm.FormatDateddMMMMyyyy(txt_txtEndDate.Value) + "</td></tr>" +
               "</table>");
                //DataGrid dg = new DataGrid();
                //dg.DataSource = tk.populateGridSchedule();
                //dg.DataBind();


                dg.RenderControl(htmlwriter);


                Response.Write(swriter.ToString());
                Response.End();
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " exported Leaves Summary",
                "EXPORT", "REPORTS", Session["EMP_ID"].ToString(), "REPORTS", Session["EMP_ID"].ToString());
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

        protected void btnExportPDF_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string dates = "C.DateFrom BETWEEN '" + txt_txtStartDate.Value + "' AND '" + txt_txtEndDate.Value + "'";
            //string company = cm.GetSpecificDataFromDB("id", "TBL_COMPANY", "where CoName = '" + ddlComp.SelectedItem.ToString() + "'");
            //string department = cm.GetSpecificDataFromDB("id", "TBL_DEPARTMENT", "where DeptName = '" + ddlDept.SelectedItem.ToString() + "'");
            //string comp = "F.id =" + company;
            //string dept = "E.id =" + department;
            string comp = "F.id =" + ddlComp.SelectedValue;
            string dept = "E.id =" + ddlDept.SelectedValue;


            if (ddlComp.SelectedIndex != 0)
            {
                string expr = dates + " AND " + comp;
                dt = tk.populateGridLeavesSummaryCol(expr);
            }
            if (ddlDept.SelectedIndex != 0)
            {
                string expr = dates + " AND " + dept;
                dt = tk.populateGridLeavesSummaryCol(expr);
            }
            if (ddlComp.SelectedIndex != 0 && ddlDept.SelectedIndex != 0)
            {
                string expr = dates + " AND " + dept + " AND " + comp;
                dt = tk.populateGridLeavesSummaryCol(expr);
            }
            if (ddlComp.SelectedIndex == 0 && ddlDept.SelectedIndex == 0)
            {
                string expr = dates;
                dt = tk.populateGridLeavesSummaryCol(expr);
            }


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

                pdfDoc.Add(new Phrase("\r\nLeave Summary for " + cm.FormatDateddMMMMyyyy(txt_txtStartDate.Value) + " to " + cm.FormatDateddMMMMyyyy(txt_txtEndDate.Value) + "\n"));

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