﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HRIS_APPELECTRIC.Pages.Admin.TK
{
    public partial class ExportDTRSummaryExcel : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Timekeeping tk = new Timekeeping();
        Common cm = new Common();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DTS_BussDate.Items.AddRange(emp.GetDropDownMenuList("TBL_CUTOFF", "CDesc"));
            }
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            string coto = cm.GetSpecificDataFromDB("CODate", "TBL_CUTOFF", "where CDesc='" + DTS_BussDate.SelectedItem.Text + "'");
            string expr = "CODate = '" + cm.FormatDate(coto) + "'";
            DataGrid dg = new DataGrid();
            dg.DataSource = tk.populateGridSummaryCol(expr);
            dg.DataBind();
            dg.ShowHeader = false;
            dg.Font.Size = 8;
            if (dg.Items.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("content-disposition", "attachment;filename= DTRSummary" + ".xls");//DTS_BussDate.SelectedItem.Text +
                Response.ContentType = "application/vnd.ms-excel";
                Response.Charset = "";
                this.EnableViewState = false;

                System.IO.StringWriter swriter = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlwriter = new System.Web.UI.HtmlTextWriter(swriter);

                swriter.Write("<table style='border-style:solid; border-width:thin;font-weight:bold;font-size:10px'><tr><td colspan='3' style='border-style:solid; border-width:thin;text-align:center'>EMPLOYER NAME:</td><td colspan='3' style='border-style:solid; border-width:thin;text-align:center'>APP-ELECTRIC</td></tr>" +
                    "<tr><td colspan='3' style='border-style:solid; border-width:thin;text-align:center'>DOCUMENT TYPE:</td><td colspan='3' style='border-style:solid; border-width:thin;text-align:center'>TIMEKEEPING SUMMARY</td></tr>" +
                    "<tr><td colspan='3' style='border-style:solid; border-width:thin;text-align:center'>CUT-OFF PERIOD:</td><td colspan='3' style='border-style:solid; border-width:thin;text-align:center'>" + DTS_BussDate.SelectedItem.Text + "</td></tr>" +
                    "<td colspan='3' style='border-style:solid; border-width:thin;text-align:center'>PAYROLL DATE:</td><td colspan='3' style='text-align:left; border-style:solid; border-width:thin;text-align:center' >" + cm.FormatDate(coto) + "</td></tr>" +
                    "<tr><td colspan='3' style='border-style:solid; border-width:thin;text-align:center'>DATE/TIME GENERATED:</td><td colspan='3' style='text-align:left; border-style:solid; border-width:thin;text-align:center'>" + cm.FormatDate(DateTime.Now) + "</td></tr>" +
                    "<tr><td colspan='29 'style='border-style:solid; border-width:thin;'></td></tr></table>");
                swriter.Write("<table style='border-style:solid; border-width:thin;font-weight:bold;background-color:#FFA500;font-size:10px'><tr><td style='border-style:solid; border-width:thin;'></td><td style='border-style:solid; border-width:thin;'></td><td colspan='2' style='border-style:solid; border-width:thin;'></td>" +
                    "<td colspan='4' style='border-style:solid; border-width:thin;text-align:center;'>LEAVES</td><td colspan='2' style='border-style:solid; border-width:thin;'></td><td colspan='2' style='border-style:solid; border-width:thin;'></td>" +
                    "<td colspan='17' style='border-style:solid; border-width:thin;text-align:center;'>OVERTIME</td></tr>");
                swriter.Write("<table style='border-style:solid; border-width:thin;font-weight:bold;background-color:#FFA500;font-size:10px'><tr><td style='border-style:solid; border-width:thin;text-align:center'></td><td style='text-align:left; border-style:solid; border-width:thin;text-align:center'></td>" +
                    "<td colspan='2' style='text-align:left; border-style:solid; border-width:thin;text-align:center'>REG WORK</td><td colspan='2' style='text-align:left; border-style:solid; border-width:thin;text-align:center'>WITH PAY</td>" +
                    "<td colspan='2' style='text-align:left; border-style:solid; border-width:thin;text-align:center'>WITHOUT PAY</td><td colspan='2' style='text-align:left; border-style:solid; border-width:thin;text-align:center'>ABSENCE</td>" +
                    "<td colspan='2' style='text-align:left; border-style:solid; border-width:thin;text-align:center'>TARDINESS</td><td colspan='2' style='text-align:left; border-style:solid; border-width:thin;text-align:center'>REGULAR</td>" +
                    "<td colspan='3' style='text-align:left; border-style:solid; border-width:thin;text-align:center'>LEGAL</td><td colspan='3' style='text-align:left; border-style:solid; border-width:thin;text-align:center'>SPECIAL</td>" +
                    "<td colspan='3' style='text-align:left; border-style:solid; border-width:thin;text-align:center'>RESTDAY</td><td colspan='3' style='text-align:left; border-style:solid; border-width:thin;text-align:center'>LEGAL REST</td>" +
                    "<td colspan='3' style='text-align:left; border-style:solid; border-width:thin;text-align:center'>SPECIAL REST</td></tr>");
                swriter.Write("<table style='font-weight:bold;background-color:#FFA500;font-size:10px'><tr><td style='border-style:solid; border-width:thin;text-align:center'>LEVEL</td><td style='border-style:solid; border-width:thin;text-align:center'>EMPLOYEE NAME</td>" +
                    "<td style='border-style:solid; border-width:thin;text-align:center'>DAYS</td><td style='border-style:solid; border-width:thin;text-align:center'>HRS</td>" +
                    "<td style='border-style:solid; border-width:thin;text-align:center'>DAYS</td><td style='border-style:solid; border-width:thin;text-align:center'>HRS</td><td style='border-style:solid; border-width:thin;text-align:center'>DAYS</td><td style='border-style:solid; border-width:thin;text-align:center'>HRS</td>" +
                    "<td style='border-style:solid; border-width:thin;text-align:center'>DAYS</td><td style='border-style:solid; border-width:thin;text-align:center'>HRS</td>" +
                    "<td style='border-style:solid; border-width:thin;text-align:center'>LATE</td><td style='border-style:solid; border-width:thin;text-align:center'>UT</td><td style='border-style:solid; border-width:thin;text-align:center'>OT</td><td style='border-style:solid; border-width:thin;'>NDO</td>" +
                    "<td style='border-style:solid; border-width:thin;text-align:center'>8HRS</td><td style='border-style:solid; border-width:thin;text-align:center'>OT</td><td style='border-style:solid; border-width:thin;text-align:center'>NDO</td>" +
                    "<td style='border-style:solid; border-width:thin;text-align:center'>8HRS</td><td style='border-style:solid; border-width:thin;text-align:center'>OT</td><td style='border-style:solid; border-width:thin;text-align:center'>NDO</td>" +
                    "<td style='border-style:solid; border-width:thin;text-align:center'>8HRS</td><td style='border-style:solid; border-width:thin;text-align:center'>OT</td><td style='border-style:solid; border-width:thin;text-align:center'>NDO</td>" +
                    "<td style='border-style:solid; border-width:thin;text-align:center'>8HRS</td><td style='border-style:solid; border-width:thin;text-align:center'>OT</td><td style='border-style:solid; border-width:thin;text-align:center'>NDO</td>" +
                    "<td style='border-style:solid; border-width:thin;text-align:center'>8HRS</td><td style='border-style:solid; border-width:thin;text-align:center'>OT</td><td style='border-style:solid; border-width:thin;text-align:center'>NDO</td></tr>");
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
    }
}