﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Data;

namespace HRIS_APPELECTRIC.Pages.Admin.Reports
{
    public partial class MonthlyDeployment : System.Web.UI.Page
    {
        Employee emp = new Employee();
        AdminLib admin = new AdminLib();
        public string empno = "";
        Common cm = new Common();
        public string month;
        public string year;
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
            ddlEmpCode.Items.AddRange(emp.GetDropDownMenuList("TBL_COMPANY", "CoName"));
            ddlEmpCode.DataValueField = emp.GetDropDownMenuList("TBL_COMPANY", "id").ToString();

        }

        private void summary()
        {
            month = ddlMonth.Value;
            year = txtYear.Value;
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string date = "emp_DateStart LIKE'" + txtYear.Value + "-" + ddlMonth.Value + "-%'";
            string comp = "emp_Assignment ='" + ddlEmpCode.Value + "'";
            string expr = date + " AND " + comp;
            DataTable dt = new DataTable();
            dt = emp.populateGridDeploymentCol(expr);
            GridUserList.DataSource = dt;
            GridUserList.DataBind();
            summary();
            ViewState["EMP_GRID"] = dt;
            ViewState["SORTDR"] = null;
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

                GridUserList.DataSource = dt;
                GridUserList.DataBind();
                //summary();

            }

        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            string date = "emp_DateStart LIKE'" + txtYear.Value + "-" + ddlMonth.Value + "-%'";
            string comp = "emp_Assignment ='" + ddlEmpCode.Value + "'";
            string expr = date + " AND " + comp;
            DataGrid dg = new DataGrid();
            dg.DataSource = emp.populateGridDeploymentCol(expr);
            dg.DataBind();
            if (dg.Items.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("content-disposition", "attachment;filename= newhires" + txtYear.Value + "-" + ddlMonth.Value + ".xls");
                Response.ContentType = "application/vnd.ms-excel";
                Response.Charset = "";
                this.EnableViewState = false;

                System.IO.StringWriter swriter = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlwriter = new System.Web.UI.HtmlTextWriter(swriter);

                //DataGrid dg = new DataGrid();
                //dg.DataSource = tk.populateGridSchedule();
                //dg.DataBind();
                swriter.Write("<table style='border-style:solid; border-width:thin;font-weight:bold;font-size:18px'><tr><td colspan='3' style='border-style:solid; border-width:thin;text-align:center'>Monthly Hires for " + ddlMonth.Items[ddlMonth.SelectedIndex].Text + " " + txtYear.Value + "</td></tr>" +
                "</table>");

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

        protected void ExportToPDF(object sender, EventArgs e)
        {
            string date = "emp_DateStart LIKE'" + txtYear.Value + "-" + ddlMonth.Value + "-%'";
            string comp = "emp_Assignment ='" + ddlEmpCode.Value + "'";
            string expr = date + " AND " + comp;
            //Create a dummy GridView
            DataTable dt = new DataTable();
            dt = emp.populateGridDeploymentCol(expr);

            GridView GridView2 = new GridView();

            GridView2.AllowPaging = false;

            GridView2.DataSource = dt;

            GridView2.DataBind();


            if (GridView2.Rows.Count > 0)
            {
                Response.ContentType = "application/pdf";

                Response.AddHeader("content-disposition",

                    "attachment;filename=newhires" + txtYear.Value + "-" + ddlMonth.Value + ".pdf");

                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                StringWriter sw = new StringWriter();

                HtmlTextWriter hw = new HtmlTextWriter(sw);

                GridView2.RenderControl(hw);

                StringReader sr = new StringReader(sw.ToString());

                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);

                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
           

                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

                pdfDoc.Open();

                pdfDoc.Add(new Phrase("\r\nMonthly New Hires for " + ddlMonth.Items[ddlMonth.SelectedIndex].Text + " " + txtYear.Value + "\n"));
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

        protected void GridUserList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sort")
            {
                sort_grid(e.CommandArgument.ToString());

            }
        }
    }
}