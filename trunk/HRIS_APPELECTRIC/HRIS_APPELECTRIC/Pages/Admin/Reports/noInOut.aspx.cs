﻿using iTextSharp.text;
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
    public partial class noInOut : System.Web.UI.Page
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
            string company = cm.GetSpecificDataFromDB("id", "TBL_COMPANY", "where CoName = '" + ddlComp.SelectedItem.ToString() + "'");
            string department = cm.GetSpecificDataFromDB("id", "TBL_DEPARTMENT", "where DeptName = '" + ddlDept.SelectedItem.ToString() + "'");
            string dates = "B.buss_date BETWEEN '" + txt_txtStartDate.Value + "' AND '" + txt_txtEndDate.Value + "'";
            string comp = "E.id =" + company;
            string dept = "D.id =" + department;
            DataTable dt = new DataTable();
            if (ddlComp.SelectedIndex != 0)
            {
                string expr = dates + " AND " + comp;
                dt= tk.populateGridUASummaryCol(expr);
                GridOBT.DataSource = dt;
                GridOBT.DataBind();
            }
            if (ddlDept.SelectedIndex != 0)
            {
                string expr = dates + " AND " + dept;
                dt = tk.populateGridUASummaryCol(expr);
                GridOBT.DataSource = dt;
                GridOBT.DataBind();
            }
            if (ddlComp.SelectedIndex != 0 && ddlDept.SelectedIndex != 0)
            {
                string expr = dates + " AND " + dept + " AND " + comp;
                dt = tk.populateGridUASummaryCol(expr);
                GridOBT.DataSource = dt;
                GridOBT.DataBind();
            }
            if (ddlComp.SelectedIndex == 0 && ddlDept.SelectedIndex == 0)
            {
                string expr = dates;
                dt = tk.populateGridUASummaryCol(expr);
                GridOBT.DataSource = dt;
                GridOBT.DataBind();
            }
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

                GridOBT.DataSource = dt;
                GridOBT.DataBind();
                //summary();

            }

        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            string company = cm.GetSpecificDataFromDB("id", "TBL_COMPANY", "where CoName = '" + ddlComp.SelectedItem.ToString() + "'");
            string department = cm.GetSpecificDataFromDB("id", "TBL_DEPARTMENT", "where DeptName = '" + ddlDept.SelectedItem.ToString() + "'");
            string dates = "B.buss_date BETWEEN '" + txt_txtStartDate.Value + "' AND '" + txt_txtEndDate.Value + "'";
            string comp = "E.id =" + company;
            string dept = "D.id =" + department;

            DataGrid dg = new DataGrid();

            if (ddlComp.SelectedIndex != 0)
            {
                string expr = dates + " AND " + comp;
                dg.DataSource = tk.populateGridUASummaryCol(expr);
                dg.DataBind();
            }
            if (ddlDept.SelectedIndex != 0)
            {
                string expr = dates + " AND " + dept;
                dg.DataSource = tk.populateGridUASummaryCol(expr);
                dg.DataBind();
            }
            if (ddlComp.SelectedIndex != 0 && ddlDept.SelectedIndex != 0)
            {
                string expr = dates + " AND " + dept + " AND " + comp;
                dg.DataSource = tk.populateGridUASummaryCol(expr);
                dg.DataBind();
            }
            if (ddlComp.SelectedIndex == 0 && ddlDept.SelectedIndex == 0)
            {
                string expr = dates;
                dg.DataSource = tk.populateGridUASummaryCol(expr);
                dg.DataBind();
            }


            if (dg.Items.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("content-disposition", "attachment;filename= UASummary" + txt_txtStartDate.Value + "-" + txt_txtEndDate.Value + ".xls");
                Response.ContentType = "application/vnd.ms-excel";
                Response.Charset = "";
                this.EnableViewState = false;

                System.IO.StringWriter swriter = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlwriter = new System.Web.UI.HtmlTextWriter(swriter);
                swriter.Write("<table style='border-style:solid; border-width:thin;font-weight:bold;font-size:18px'><tr><td colspan='3' style='border-style:solid; border-width:thin;text-align:center'>Unaccounted Attendance Summary for " + cm.FormatDateddMMMMyyyy(txt_txtStartDate.Value) + " to " + cm.FormatDateddMMMMyyyy(txt_txtEndDate.Value) + "</td></tr>" +
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

        protected void btnRxportPDF_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string company = cm.GetSpecificDataFromDB("id", "TBL_COMPANY", "where CoName = '" + ddlComp.SelectedItem.ToString() + "'");
            string department = cm.GetSpecificDataFromDB("id", "TBL_DEPARTMENT", "where DeptName = '" + ddlDept.SelectedItem.ToString() + "'");
            string dates = "B.buss_date BETWEEN '" + txt_txtStartDate.Value + "' AND '" + txt_txtEndDate.Value + "'";
            string comp = "E.id =" + company;
            string dept = "D.id =" + department;

            DataGrid dg = new DataGrid();

            if (ddlComp.SelectedIndex != 0)
            {
                string expr = dates + " AND " + comp;
                dt = tk.populateGridUASummaryCol(expr);
            }
            if (ddlDept.SelectedIndex != 0)
            {
                string expr = dates + " AND " + dept;
                dt = tk.populateGridUASummaryCol(expr);
            }
            if (ddlComp.SelectedIndex != 0 && ddlDept.SelectedIndex != 0)
            {
                string expr = dates + " AND " + dept + " AND " + comp;
                dt = tk.populateGridUASummaryCol(expr);
            }
            if (ddlComp.SelectedIndex == 0 && ddlDept.SelectedIndex == 0)
            {
                string expr = dates;
                dt = tk.populateGridUASummaryCol(expr);
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

                pdfDoc.Add(new Phrase("\r\nUnaccounted Attendance Summary for " + cm.FormatDateddMMMMyyyy(txt_txtStartDate.Value) + " to " + cm.FormatDateddMMMMyyyy(txt_txtEndDate.Value) + "\n"));

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

        protected void GridOBT_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sort")
            {
                sort_grid(e.CommandArgument.ToString());

            }
        }
    }
}