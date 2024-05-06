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
    public partial class PayrollRegisterReport : System.Web.UI.Page
    {
        Payroll pr = new Payroll();
        Employee emp = new Employee();
        Timekeeping tk = new Timekeeping();
        Common cm = new Common();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCredDate.Items.AddRange(emp.GetDropDownMenuList("TBL_CUTOFF", "CDesc", "id", " ORDER by Company asc, MONTH(cofrom) asc"));
                //lbCutOff.Items.AddRange(emp.GetDropDownMenuList("TBL_CUTOFF", "CDesc", "id", "where CDesc like '%" + cm.dtnow().Year + "%' ORDER by Company asc, MONTH(cofrom) asc"));
                //ddlCompany.Items.AddRange(emp.GetDropDownMenuList("TBL_COMPANY", "CoName","id","order by CoName Asc"));
                //GetMyMonthList(ddlMonth, true);
            }
        }
        //void GetMyMonthList(DropDownList MyddlMonthList, bool SetCurruntMonth)
        //{
        //    DateTime month = Convert.ToDateTime("1/1/2000");
        //    for (int i = 0; i < 12; i++)
        //    {
        //        DateTime NextMont = month.AddMonths(i);
        //        ListItem list = new ListItem();
        //        list.Text = NextMont.ToString("MMMM");
        //        list.Value = NextMont.Month.ToString();
        //        MyddlMonthList.Items.Add(list);
        //    }
        //    if (SetCurruntMonth == true)
        //    {
        //        MyddlMonthList.Items.FindByValue(cm.dtnow().Month.ToString()).Selected = true;
        //    }
        //}
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //dt = pr.populateAlphaListReport(ddlCompany.SelectedValue,ddlMonth.SelectedValue);
            //dt = pr.populateAlphaListReport(ddlCredDate.SelectedValue);
            //string getCompany = ddlCompany.SelectedValue != "" ? cm.GetSpecificDataFromDB("CoName", "TBL_COMPANY", "where id = " + ddlCompany.SelectedValue + "") : "";
            string getCompany = "APP-ELECTRIC";

            Dictionary<string, string> getCutoffDict = new Dictionary<string, string>();
            getCutoffDict = cm.GetTableDict("TBL_CUTOFF", "where id = " + ddlCredDate.SelectedValue + "");
            string getCOFrom = getCutoffDict["COFrom"];
            string getCOTo = getCutoffDict["COTo"];
            string getCDesc = getCutoffDict["CDesc"];
            //filename =  contrimonth != "" ? cm.getMonthFullName(int.Parse(contrimonth)) +" "+ contriyear : "ALL CONTRIBUTION " + contriyear;
            //getCompany = contricutoff != "" ? cm.GetSpecificDataFromDB("CDesc", "TBL_CUTOFF", "where id = " + contricutoff + "") : "ContributionReport";


            using (XLWorkbook wb = new XLWorkbook())
            {

                var ws = wb.Worksheets.Add("Report");
                // Set the width of all columns in the worksheet
                ws.Columns().Width = 8;

                // Set the height of all rows in the worksheet
                ws.Rows().Height = 20;

                //var wsReportNameHeaderRange = ws.Range(string.Format("A{0}:{1}{0}", 1, Char.ConvertFromUtf32(65 + dt.Columns.Count)));
                var wsReportNameHeaderRange = ws.Range("A1:BB1");
                wsReportNameHeaderRange.Style.Font.Bold = true;
                wsReportNameHeaderRange.Style.Border.OutsideBorder = XLBorderStyleValues.None;
                wsReportNameHeaderRange.Merge();
                wsReportNameHeaderRange.Style.Font.FontSize = 13;
                wsReportNameHeaderRange.Style.Font.FontName = "Arial";
                //wsReportNameHeaderRange.Value = "Company:            " + getCompany + "";
                wsReportNameHeaderRange.Value = getCompany;

                //var wsReportDateHeaderRange = ws.Range(string.Format("A{0}:{1}{0}", 2, Char.ConvertFromUtf32(65 + dt.Columns.Count)));
                var wsReportDateHeaderRange = ws.Range("A2:BB2");
                wsReportDateHeaderRange.Merge();
                wsReportDateHeaderRange.Style.Border.OutsideBorder = XLBorderStyleValues.None;
                wsReportDateHeaderRange.Style.Font.FontSize = 13;
                wsReportDateHeaderRange.Style.Font.FontName = "Arial";
                //wsReportDateHeaderRange.Value = string.Format("Report Generated Date :{0}", cm.dtnow().ToString("dd/MM/yyyy"));
                wsReportDateHeaderRange.Value = string.Format("Report Generated Date :{0}", cm.FormatDateddMMMMyyyy(cm.dtnow()));
                //var wsReportCreatedByHeaderRange = ws.Range(string.Format("A{0}:{1}{0}", 3, Char.ConvertFromUtf32(65 + dt.Columns.Count)));
                var wsReportCreatedByHeaderRange = ws.Range("A3:BB3");
                wsReportCreatedByHeaderRange.Merge();
                wsReportCreatedByHeaderRange.Style.Border.OutsideBorder = XLBorderStyleValues.None;
                wsReportCreatedByHeaderRange.Style.Font.FontSize = 13;
                wsReportCreatedByHeaderRange.Style.Font.FontName = "Arial";
                DateTime dttoday = DateTime.Parse(cm.dtnow().ToString());
                int monthnumber = 0;
                //int.TryParse(ddlMonth.SelectedValue, out monthnumber);
                //string getmonthname = ddlMonth.SelectedValue != "" ? CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(monthnumber) : "";
                //wsReportCreatedByHeaderRange.Value = string.Format("Time: "+ dttoday.ToString("hh:mm tt") +" "+ getmonthname + " "+ cm.dtnow().Year + " Pay Period 1  to  " + getmonthname + " " + cm.dtnow().Year + " Pay Period 2   {0}", "eto galing sa cutoff buoin mo nalng");
                wsReportCreatedByHeaderRange.Value = "Payroll Period: " + getCDesc + "";
                ws.Row(3).InsertRowsBelow(1);
                ws.Row(4).Style.Border.OutsideBorder = XLBorderStyleValues.None;
                ws.Row(4).Style.Border.RightBorder = XLBorderStyleValues.None;
                ws.Row(4).Style.Border.LeftBorder = XLBorderStyleValues.None;
                int rowIndex = 5;
                //int columnIndex = 0;
                int columnIndex = 1;
                bool countercolumn = false, counterrow = false;
                DataTable dt = new DataTable();
                //dt = pr.populatePayrollRegisterReport(ddlCredDate.SelectedValue, deptid);
                dt = pr.populatePayrollRegisterReport(ddlCredDate.SelectedValue);
                if (countercolumn == false)
                {
                    foreach (DataColumn column in dt.Columns)
                    {
                        ws.Cell(string.Format("{0}{1}", ExcelColumnFromNumber(columnIndex), rowIndex)).Value = column.ColumnName;
                        ws.Cell(string.Format("{0}{1}", ExcelColumnFromNumber(columnIndex), rowIndex)).Style.Border.OutsideBorder = XLBorderStyleValues.None;
                        ws.Cell(string.Format("{0}{1}", ExcelColumnFromNumber(columnIndex), rowIndex)).Style.Font.FontSize = 7;
                        ws.Cell(string.Format("{0}{1}", ExcelColumnFromNumber(columnIndex), rowIndex)).Style.Font.FontName = "Arial";

                        columnIndex++;
                    }
                }
                if (countercolumn == false)
                    rowIndex++;
                countercolumn = true;
                counterrow = false;
                foreach (DataRow row in dt.Rows)
                {
                    counterrow = true;
                    int valueCount = 1;
                    foreach (object rowValue in row.ItemArray)
                    {
                        //ws.Cell(string.Format("{0}{1}", Char.ConvertFromUtf32(65 + valueCount), rowIndex)).Value = rowValue;
                        //ws.Cell(string.Format("{0}{1}", Char.ConvertFromUtf32(65 + valueCount), rowIndex)).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                        ws.Cell(string.Format("{0}{1}", ExcelColumnFromNumber(valueCount), rowIndex)).Value = rowValue;
                        ws.Cell(string.Format("{0}{1}", ExcelColumnFromNumber(valueCount), rowIndex)).Style.Border.OutsideBorder = XLBorderStyleValues.None;
                        ws.Cell(string.Format("{0}{1}", ExcelColumnFromNumber(valueCount), rowIndex)).Style.Font.FontSize = 7;
                        ws.Cell(string.Format("{0}{1}", ExcelColumnFromNumber(valueCount), rowIndex)).Style.Font.FontName = "Arial";
                        if (rowValue.ToString() == "Grand Total:")
                        {
                            //ws.Cell(string.Format("{0}{1}", ExcelColumnFromNumber(valueCount), rowIndex)).Style.Font.Bold = true;
                            var wsReportDeptRange = ws.Range("A" + rowIndex + ":X" + rowIndex + "");
                            wsReportDeptRange.Style.Font.Bold = true;



                        }
                        if (valueCount >= 4)
                        {
                            ws.Cell(string.Format("{0}{1}", ExcelColumnFromNumber(valueCount), rowIndex)).Style.NumberFormat.Format = "#,##0.00;-#,##0.00;-";
                        }
                        valueCount++;
                    }
                    rowIndex++;
                }
                if (counterrow)
                {
                    //ws.Row(rowIndex).InsertRowsAbove(1);
                    rowIndex++;
                }
                var wsGrandTotalRange = ws.Range("A" + rowIndex + ":Y" + rowIndex + "");
                wsGrandTotalRange.Style.Font.Bold = true;
                wsGrandTotalRange.Style.Border.OutsideBorder = XLBorderStyleValues.None;
                wsGrandTotalRange.Style.Font.FontSize = 7;
                wsGrandTotalRange.Style.Font.FontName = "Arial";
                var wsGrandTotalNumberFormatRange = ws.Range("E" + rowIndex + ":X" + rowIndex + "");
                wsGrandTotalNumberFormatRange.Style.NumberFormat.Format = "#,##0.00;-#,##0.00;-";
                


                rowIndex = rowIndex + 2;
                var wsGrandTotal1Range = ws.Range("A" + rowIndex + ":X" + rowIndex + "");
                wsGrandTotal1Range.Style.Font.FontSize = 7;
                wsGrandTotal1Range.Style.Font.FontName = "Arial";

                ws.Cell(string.Format("{0}{1}", "A", rowIndex)).Value = "Approved By:____________________";
                ws.Cell(string.Format("{0}{1}", "A", rowIndex)).Style.Border.OutsideBorder = XLBorderStyleValues.None;
                rowIndex++;
                ws.Cell(string.Format("{0}{1}", "A", rowIndex)).Value = "Prepared By:_________________";
                ws.Cell(string.Format("{0}{1}", "A", rowIndex)).Style.Border.OutsideBorder = XLBorderStyleValues.None;
                ws.Cell(string.Format("{0}{1}", "A", rowIndex)).Style.Font.FontSize = 7;
                ws.Cell(string.Format("{0}{1}", "A", rowIndex)).Style.Font.FontName = "Arial";
                rowIndex++;

                var wsGrandTotal2Range = ws.Range("A" + rowIndex + ":Y" + rowIndex + "");
                wsGrandTotal2Range.Style.Font.FontSize = 7;
                wsGrandTotal2Range.Style.Font.FontName = "Arial";

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=PayrollRegisterReport.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {

                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
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
    }
}