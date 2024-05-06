using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ClosedXML;
using ClosedXML.Excel;
using System.IO;
using System.Globalization;

namespace HRIS_APPELECTRIC.Pages.Admin.PayrollPages
{
    public partial class AlphaListReportByCutOffs : System.Web.UI.Page
    {
        Payroll pr = new Payroll();
        Employee emp = new Employee();
        Timekeeping tk = new Timekeeping();
        Common cm = new Common();
        string getCompany = "";
        string getCutoffDesc = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                lbCutOff.Items.AddRange(emp.GetDropDownMenuListOrdrBy("TBL_CUTOFF", "CDesc", "id", " ORDER by Company asc, MONTH(cofrom) asc"));

            }
            if (Request["__EVENTARGUMENT"] != null && Request["__EVENTARGUMENT"] == "move")
            {
                int idx = lbCutOff.SelectedIndex;
                ListItem item = lbCutOff.SelectedItem;
                lbCutOff.Items.Remove(item);
                lbCutOffSelected.SelectedIndex = -1;
                lbCutOffSelected.Items.Add(item);
            }
            lbCutOff.Attributes.Add("ondblclick", ClientScript.GetPostBackEventReference(lbCutOff, "move"));
        }
        void clear()
        {
            lbCutOff.DataSource = null;
            lbCutOff.Items.Clear();
            lbCutOff.Items.AddRange(emp.GetDropDownMenuListOrdrBy("TBL_CUTOFF", "CDesc", "id", "where CDesc like '%" + cm.dtnow().Year + "%' ORDER by Company asc, MONTH(cofrom) asc"));
            lbCutOffSelected.DataSource = null;
            lbCutOffSelected.Items.Clear();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            List<string> cutoffselected = new List<string>();
            //foreach (var item in lbCutOffSelected.Items)
            //{
            //var texts = ListBox1.Items
            //    .Cast<ListItem>()
            //    .Select(item => item.Text)
            //    .ToArray()
            //cutoffselected.Add(item.ToString());
            //}
            foreach (ListItem lst in lbCutOffSelected.Items)
            {
                cutoffselected.Add(lst.Value);
                getCutoffDesc += lst.Text + " ";
            }
            if (cutoffselected.Count > 0)
            {
                DataTable dt = new DataTable();
                dt = pr.populateAlphaListReportByCutOffs(cutoffselected);
                //string getCompany = ddlCompany.SelectedValue != "" ? cm.GetSpecificDataFromDB("CoName", "TBL_COMPANY", "where id = " + ddlCompany.SelectedValue + "") : "";

                //filename =  contrimonth != "" ? cm.getMonthFullName(int.Parse(contrimonth)) +" "+ contriyear : "ALL CONTRIBUTION " + contriyear;
                //getCompany = contricutoff != "" ? cm.GetSpecificDataFromDB("CDesc", "TBL_CUTOFF", "where id = " + contricutoff + "") : "ContributionReport";


                using (XLWorkbook wb = new XLWorkbook())
                {

                    var ws = wb.Worksheets.Add("Report");
                    //var wsReportNameHeaderRange = ws.Range(string.Format("A{0}:{1}{0}", 1, Char.ConvertFromUtf32(65 + dt.Columns.Count)));
                    var wsReportNameHeaderRange = ws.Range("A1:AA1");
                    wsReportNameHeaderRange.Style.Font.Bold = true;
                    wsReportNameHeaderRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    wsReportNameHeaderRange.Merge();
                    wsReportNameHeaderRange.Value = "Company:            " + getCompany + "";

                    //var wsReportDateHeaderRange = ws.Range(string.Format("A{0}:{1}{0}", 2, Char.ConvertFromUtf32(65 + dt.Columns.Count)));
                    var wsReportDateHeaderRange = ws.Range("A2:AA2");
                    wsReportDateHeaderRange.Merge();
                    wsReportDateHeaderRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    //wsReportDateHeaderRange.Value = string.Format("Report Generated Date :{0}", cm.dtnow().ToString("dd/MM/yyyy"));
                    wsReportDateHeaderRange.Value = string.Format("Report Generated Date :{0}", cm.FormatDateddMMMMyyyy(cm.dtnow()));
                    //var wsReportCreatedByHeaderRange = ws.Range(string.Format("A{0}:{1}{0}", 3, Char.ConvertFromUtf32(65 + dt.Columns.Count)));
                    var wsReportCreatedByHeaderRange = ws.Range("A3:AA3");
                    wsReportCreatedByHeaderRange.Merge();
                    wsReportCreatedByHeaderRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    DateTime dttoday = DateTime.Parse(cm.dtnow().ToString());
                    int monthnumber = 0;
                    //int.TryParse(ddlMonth.SelectedValue, out monthnumber);
                    //string getmonthname = ddlMonth.SelectedValue != "" ? CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(monthnumber) : "";
                    //wsReportCreatedByHeaderRange.Value = string.Format("Time: "+ dttoday.ToString("hh:mm tt") +" "+ getmonthname + " "+ cm.dtnow().Year + " Pay Period 1  to  " + getmonthname + " " + cm.dtnow().Year + " Pay Period 2   {0}", "eto galing sa cutoff buoin mo nalng");
                    //wsReportCreatedByHeaderRange.Value = "Time: " + dttoday.ToString("hh:mm tt") + "  " + cm.dtnow().Year + " Pay Period 1  to   " + cm.dtnow().Year + " Pay Period 2";
                    wsReportCreatedByHeaderRange.Value = getCutoffDesc;
                    ws.Row(3).InsertRowsBelow(1);
                    ws.Row(4).Style.Border.OutsideBorder = XLBorderStyleValues.None;
                    ws.Row(4).Style.Border.RightBorder = XLBorderStyleValues.None;
                    ws.Row(4).Style.Border.LeftBorder = XLBorderStyleValues.None;
                    int rowIndex = 5;
                    //int columnIndex = 0;
                    int columnIndex = 1;
                    foreach (DataColumn column in dt.Columns)
                    {
                        //if(column.ColumnName == "PHONE CHARGE")
                        //{
                        //    ws.Cell("Z1").Value = column.ColumnName;
                        //    ws.Cell("Z1").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        //}
                        //else
                        //{
                        //ws.Cell(string.Format("{0}{1}", Char.ConvertFromUtf32(65 + columnIndex), rowIndex)).Value = column.ColumnName;
                        //ws.Cell(string.Format("{0}{1}", Char.ConvertFromUtf32(65 + columnIndex), rowIndex)).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        //}
                        ws.Cell(string.Format("{0}{1}", ExcelColumnFromNumber(columnIndex), rowIndex)).Value = column.ColumnName;
                        ws.Cell(string.Format("{0}{1}", ExcelColumnFromNumber(columnIndex), rowIndex)).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                        columnIndex++;
                    }
                    rowIndex++;
                    foreach (DataRow row in dt.Rows)
                    {
                        int valueCount = 1;
                        foreach (object rowValue in row.ItemArray)
                        {
                            //ws.Cell(string.Format("{0}{1}", Char.ConvertFromUtf32(65 + valueCount), rowIndex)).Value = rowValue;
                            //ws.Cell(string.Format("{0}{1}", Char.ConvertFromUtf32(65 + valueCount), rowIndex)).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                            ws.Cell(string.Format("{0}{1}", ExcelColumnFromNumber(valueCount), rowIndex)).Value = rowValue;
                            ws.Cell(string.Format("{0}{1}", ExcelColumnFromNumber(valueCount), rowIndex)).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                            valueCount++;
                        }
                        rowIndex++;
                    }

                    rowIndex = rowIndex + 2;
                    ws.Cell(string.Format("{0}{1}", "A", rowIndex)).Value = "Checked by:____________________";
                    ws.Cell(string.Format("{0}{1}", "A", rowIndex)).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    ws.Cell(string.Format("{0}{1}", "D", rowIndex)).Value = "Approved by:_________________";
                    ws.Cell(string.Format("{0}{1}", "D", rowIndex)).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=AlphaListReport.xlsx");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {

                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
            }

        }
        public static string ExcelColumnFromNumber(int column)
        {
            string columnString = "";
            decimal columnNumber = column;
            while (columnNumber > 0)
            {
                decimal currentLetterNumber = (columnNumber - 1) % 26;
                char currentLetter = (char)(currentLetterNumber + 65);
                columnString = currentLetter + columnString;
                columnNumber = (columnNumber - (currentLetterNumber + 1)) / 26;
            }
            return columnString;
        }
        public static int NumberFromExcelColumn(string column)
        {
            int retVal = 0;
            string col = column.ToUpper();
            for (int iChar = col.Length - 1; iChar >= 0; iChar--)
            {
                char colPiece = col[iChar];
                int colNum = colPiece - 64;
                retVal = retVal + colNum * (int)Math.Pow(26, col.Length - (iChar + 1));
            }
            return retVal;
        }
        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    foreach (ListItem lst in lbCutOff.Items)
        //    {
        //        if (lst.Selected == true)
        //        {
        //            lbCutOffSelected.Items.Add(lst.Text);
        //        }

        //    }
        //}
        protected void btnremove_Click(object sender, EventArgs e)
        {
            foreach (ListItem lst in lbCutOffSelected.Items)
            {
                if (lst.Selected == true)
                {
                    //lbCutOffSelected.Items.Remove(lst);

                    //int idx = lbCutOffSelected.SelectedIndex;
                    //ListItem item = lbCutOffSelected.SelectedItem;
                    lbCutOffSelected.Items.Remove(lst);
                    //lbCutOff.SelectedIndex = -1;
                    lbCutOff.Items.Add(lst);
                }
            }
        }
        protected void btnclear_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}