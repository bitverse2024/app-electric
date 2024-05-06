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

namespace HRIS_APPELECTRIC
{
    public partial class Test : System.Web.UI.Page
    {
        Payroll pr = new Payroll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string Payslip()
        {
            string build_html = "";
            build_html += "<table id=\"yw2\" style=\"width:150%;font-family:Arial\"><tr><td colspan='6'><span>APP ELECTRIC CORP</span></td></tr>";
            build_html += "<tr><td colspan='6'><span>" + "{0}" + "</span> <span>" + "{1}" + "</span></td></tr>";
            build_html += "<tr><td colspan='6'></td><td colspan='2'></td></td><td colspan='2'><span>Date Covered: " +
                "{2}" + "</span></td><td colspan='2'></tr>";
            build_html += "<tr><td colspan='6'></td><td colspan='2'><td colspan='2'><span>Payroll Group: " +
                "{3}" + "</span></td><td colspan='2'></tr>";
            build_html += "<tr><td colspan='6'></td><td colspan='2'><td colspan='2'><span>Department: " +
                "{4}" + "</span></td><td colspan='2'></tr>";
            build_html += "<tr><td><br/></td></tr>";
            build_html += "<tr><td colspan='1'></td><td colspan='2'><span>Amount</span></td>" +
                "<td colspan='1'></td><td colspan='2'></td>" +
                "<td colspan='1'></td><td colspan='2'></td>" +
                "<td colspan='2'>Loan Balance<span></span></td><td colspan='1'></td></tr>";
            build_html += "<tr>" +
                "<td colspan='1'><span>Basic Pay</span><br/></td>" +
                "<td colspan='2'><span>" + "{5}" + "</span></td>" +
                "<td colspan='1'><span>SSS</span></td>" +
                "<td colspan='2'><span> {6}</span></td>" +
                "<td colspan='1'><span>CASH ADV</span></td>" +
                "<td colspan='2'><span>" + "{7}" + "</span></td>" +
                "<td colspan='2'><span>" + "{8}" + "</span></td>" +
                "<td colspan='1'></td></tr>";
            build_html += "<tr>" +
                "<td colspan='1'><span>Absences</span><br/></td>" +
                "<td colspan='2'><span>" + "({9})" + "</span></td>" +
                "<td colspan='1'><span>PhilHealth</span></td>" +
                "<td colspan='2'><span>" + "{10}" + "</span></td>" +
                "<td colspan='1'><span></span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='1'></td></tr>";
            build_html += "<tr>" +
                "<td colspan='1'><span>Lates</span><br/></td>" +
                "<td colspan='2'><span>" + "({11})" + "</span></td>" +
                "<td colspan='1'><span>Pag-Ibig</span></td>" +
                "<td colspan='2'><span>" + "{12}" + "</span></td>" +
                "<td colspan='1'><span></span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='1'></td></tr>";
            build_html += "<tr><td><br/></td></tr></table><br/>";
            build_html += "<table style=\"width:95%;font-family:Arial\"><tr>" +
                "<td colspan='2' style=\"text-align:right;padding-right:20px;\"><span>Total Gross Income</span></td>" +
                "<td colspan='1' style=\"text-align:right;border-top:solid;border-bottom:solid;border-width:thin;padding-top:10px;padding-bottom:5px;\">" +
                "<span>" + "{13}" + "</span></td>" +
                "<td colspan='6'><span></span></td>" +
                "<td colspan='2' style=\"text-align:right;padding-right:20px;\"><span>Total Deduction</span></td>" +
                "<td colspan='1' style=\"text-align:right;border-top:solid;border-bottom:solid;border-width:thin;padding-top:10px;padding-bottom:5px;\">" +
                "<span>" + "{14}" + "</span></td></tr>";
            build_html += "<tr>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='1' style=\"border-top:solid;border-width:thin\"><span></span></td>" +
                "<td colspan='6'><span></span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='1' style=\"border-top:solid;border-width:thin\"><span></span></td></tr>" +
                "<tr><td><br/></td></tr>";
            build_html += "<tr>" +
               "<td colspan='2'><span></span></td>" +
               "<td colspan='1'><span></span></td>" +
               "<td colspan='6'><span></span></td>" +
               "<td colspan='2' style=\"text-align:right;padding-right:70px;\"><span>Net Pay</span></td>" +
               "<td colspan='1' style=\"text-align:right;border-top:solid;border-bottom:solid;border-width:thin;padding-top:10px;padding-bottom:5px;\">" +
               "<span style=\"font-size:150%;font-weight:bold\">{15}</span></td></tr>"; ;
            build_html += "<tr>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='1'><span></span></td>" +
                "<td colspan='6'><span></span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='1' style=\"border-top:solid;border-width:thin\"><span></span></td></tr>" +
                "<tr><td><br/></td></tr></table>";
            build_html += "<table style=\"width:100%;font-family:Arial\"><tr>" +
               "<td colspan='6'><span>I hereby ackowledge to have received the sum as full payment of my service rendered.</span></td>" +
               "<td colspan='6' style=\"text-align:right;\"><span>Signature _________________________</span></td>" +
               "</tr>" +
               "</table>";

            return build_html;
        }

        //public string paysliphtml()
        //{
        //    #region build_html
        //    string build_html = "";
        //    build_html += "<table id=\"yw2\" style=\"width:150%;font-family:Arial\"><tr><td colspan='6'><span>APP ELECTRIC CORP</span></td></tr>";
        //    build_html += "<tr><td colspan='6'><span>" + "{0}" + "</span> <span>" + "{1}" + "</span></td></tr>";
        //    build_html += "<tr><td colspan='6'></td><td colspan='2'></td></td><td colspan='2'><span>Date Covered: " +
        //        "{2}" + "</span></td><td colspan='2'></tr>";
        //    build_html += "<tr><td colspan='6'></td><td colspan='2'><td colspan='2'><span>Payroll Group: " +
        //        "{3}" + "</span></td><td colspan='2'></tr>";
        //    build_html += "<tr><td colspan='6'></td><td colspan='2'><td colspan='2'><span>Department: " +
        //        "{4}" + "</span></td><td colspan='2'></tr>";
        //    build_html += "<tr><td><br/></td></tr>";
        //    build_html += "<tr><td colspan='1'></td><td colspan='2'><span>Amount</span></td>" +
        //        "<td colspan='1'></td><td colspan='2'></td>" +
        //        "<td colspan='1'></td><td colspan='2'></td>" +
        //        "<td colspan='2'>Loan Balance<span></span></td><td colspan='1'></td></tr>";
        //    build_html += "<tr>" +
        //        "<td colspan='1'><span>Basic Pay</span><br/></td>" +
        //        "<td colspan='2'><span>" + "{5}" + "</span></td>" +
        //        "<td colspan='1'><span>SSS</span></td>" +
        //        "<td colspan='2'><span> {6}</span></td>" +
        //        "<td colspan='1'><span>CASH AD</span></td>" +
        //        "<td colspan='2'><span>" + "{7}" + "</span></td>" +
        //        "<td colspan='2'><span>" + "{8}" + "</span></td>" +
        //        "<td colspan='1'></td></tr>";
        //    build_html += "<tr>" +
        //        "<td colspan='1'><span>Absences</span><br/></td>" +
        //        "<td colspan='2'><span>" + "({9})" + "</span></td>" +
        //        "<td colspan='1'><span>PhilHealth</span></td>" +
        //        "<td colspan='2'><span>" + "{10}" + "</span></td>" +
        //        "<td colspan='1'><span></span></td>" +
        //        "<td colspan='2'><span></span></td>" +
        //        "<td colspan='2'><span></span></td>" +
        //        "<td colspan='1'></td></tr>";
        //    build_html += "<tr>" +
        //        "<td colspan='1'><span>Lates</span><br/></td>" +
        //        "<td colspan='2'><span>" + "({11})" + "</span></td>" +
        //        "<td colspan='1'><span>Pag-Ibig</span></td>" +
        //        "<td colspan='2'><span>" + "{12}" + "</span></td>" +
        //        "<td colspan='1'><span></span></td>" +
        //        "<td colspan='2'><span></span></td>" +
        //        "<td colspan='2'><span></span></td>" +
        //        "<td colspan='1'></td></tr>";
        //    build_html += "<tr><td><br/></td></tr></table><br/>";
        //    build_html += "<table style=\"width:95%;font-family:Arial\"><tr>" +
        //        "<td colspan='2' style=\"text-align:right;padding-right:20px;\"><span>Total Gross Income</span></td>" +
        //        "<td colspan='1' style=\"text-align:right;border-top:solid;border-bottom:solid;border-width:thin;padding-top:10px;padding-bottom:5px;\">" +
        //        "<span>" + "{13}" + "</span></td>" +
        //        "<td colspan='6'><span></span></td>" +
        //        "<td colspan='2' style=\"text-align:right;padding-right:20px;\"><span>Total Deduction</span></td>" +
        //        "<td colspan='1' style=\"text-align:right;border-top:solid;border-bottom:solid;border-width:thin;padding-top:10px;padding-bottom:5px;\">" +
        //        "<span>" + "{14}" + "</span></td></tr>";
        //    build_html += "<tr>" +
        //        "<td colspan='2'><span></span></td>" +
        //        "<td colspan='1' style=\"border-top:solid;border-width:thin\"><span></span></td>" +
        //        "<td colspan='6'><span></span></td>" +
        //        "<td colspan='2'><span></span></td>" +
        //        "<td colspan='1' style=\"border-top:solid;border-width:thin\"><span></span></td></tr>" +
        //        "<tr><td><br/></td></tr>";
        //    build_html += "<tr>" +
        //       "<td colspan='2'><span></span></td>" +
        //       "<td colspan='1'><span></span></td>" +
        //       "<td colspan='6'><span></span></td>" +
        //       "<td colspan='2' style=\"text-align:right;padding-right:70px;\"><span>Net Pay</span></td>" +
        //       "<td colspan='1' style=\"text-align:right;border-top:solid;border-bottom:solid;border-width:thin;padding-top:10px;padding-bottom:5px;\">" +
        //       "<span style=\"font-size:150%;font-weight:bold\">{15}</span></td></tr>"; ;
        //    build_html += "<tr>" +
        //        "<td colspan='2'><span></span></td>" +
        //        "<td colspan='1'><span></span></td>" +
        //        "<td colspan='6'><span></span></td>" +
        //        "<td colspan='2'><span></span></td>" +
        //        "<td colspan='1' style=\"border-top:solid;border-width:thin\"><span></span></td></tr>" +
        //        "<tr><td><br/></td></tr></table>";
        //    build_html += "<table style=\"width:100%;font-family:Arial\"><tr>" +
        //       "<td colspan='6'><span>I hereby ackowledge to have received the sum as full payment of my service rendered.</span></td>" +
        //       "<td colspan='6' style=\"text-align:right;\"><span>Signature _________________________</span></td>" +
        //       "</tr>" +
        //       "</table>";
        //    #endregion



        //    return build_html;
        //}
        public string paysliphtml()
        {
            #region build_html
            string build_html = "";
            build_html += "<table id=\"yw2\" style=\"width:150;font-family:Arial\"><tr><td colspan='6'><span>APP ELECTRIC CORP</span></td></tr>";
            build_html += "<tr><td colspan='6'><span>" + "{0}" + "</span> <span>" + "{1}" + "</span></td></tr>";
            build_html += "<tr><td colspan='6'></td><td colspan='2'></td></td><td colspan='2'><span>Date Covered: " +
                "{2}" + "</span></td><td colspan='2'></tr>";
            build_html += "<tr><td colspan='6'></td><td colspan='2'><td colspan='2'><span>Payroll Group: " +
                "{3}" + "</span></td><td colspan='2'></tr>";
            build_html += "<tr><td colspan='6'></td><td colspan='2'><td colspan='2'><span>Department: " +
                "{4}" + "</span></td><td colspan='2'></tr>";
            build_html += "<tr><td><br/></td></tr>";
            build_html += "<tr><td colspan='1'></td><td colspan='2'><span>Amount</span></td>" +
                "<td colspan='1'></td><td colspan='2'></td>" +
                "<td colspan='1'></td><td colspan='2'></td>" +
                "<td colspan='2'>Loan Balance<span></span></td><td colspan='1'></td></tr>";
            build_html += "<tr>" +
                "<td colspan='1'><span>Basic Pay</span><br/></td>" +
                "<td colspan='2'><span>" + "{5}" + "</span></td>" +
                "<td colspan='1'><span>SSS</span></td>" +
                "<td colspan='2'><span> {6}</span></td>" +
                "<td colspan='1'><span>CASH AD</span></td>" +
                "<td colspan='2'><span>" + "{7}" + "</span></td>" +
                "<td colspan='2'><span>" + "{8}" + "</span></td>" +
                "<td colspan='1'></td></tr>";
            build_html += "<tr>" +
                "<td colspan='1'><span>Absences</span><br/></td>" +
                "<td colspan='2'><span>" + "({9})" + "</span></td>" +
                "<td colspan='1'><span>PhilHealth</span></td>" +
                "<td colspan='2'><span>" + "{10}" + "</span></td>" +
                "<td colspan='1'><span></span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='1'></td></tr>";
            build_html += "<tr>" +
                "<td colspan='1'><span>Lates</span><br/></td>" +
                "<td colspan='2'><span>" + "({11})" + "</span></td>" +
                "<td colspan='1'><span>Pag-Ibig</span></td>" +
                "<td colspan='2'><span>" + "{12}" + "</span></td>" +
                "<td colspan='1'><span></span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='1'></td></tr>";
            build_html += "<tr><td><br/></td></tr></table><br/>";
            build_html += "<table style=\"width:95;font-family:Arial\"><tr>" +
                "<td colspan='2' style=\"text-align:right;padding-right:20px;\"><span>Total Gross Income</span></td>" +
                "<td colspan='1' style=\"text-align:right;border-top:solid;border-bottom:solid;border-width:thin;padding-top:10px;padding-bottom:5px;\">" +
                "<span>" + "{13}" + "</span></td>" +
                "<td colspan='6'><span></span></td>" +
                "<td colspan='2' style=\"text-align:right;padding-right:20px;\"><span>Total Deduction</span></td>" +
                "<td colspan='1' style=\"text-align:right;border-top:solid;border-bottom:solid;border-width:thin;padding-top:10px;padding-bottom:5px;\">" +
                "<span>" + "{14}" + "</span></td></tr>";
            build_html += "<tr>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='1' style=\"border-top:solid;border-width:thin\"><span></span></td>" +
                "<td colspan='6'><span></span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='1' style=\"border-top:solid;border-width:thin\"><span></span></td></tr>" +
                "<tr><td><br/></td></tr>";
            build_html += "<tr>" +
               "<td colspan='2'><span></span></td>" +
               "<td colspan='1'><span></span></td>" +
               "<td colspan='6'><span></span></td>" +
               "<td colspan='2' style=\"text-align:right;padding-right:70px;\"><span>Net Pay</span></td>" +
               "<td colspan='1' style=\"text-align:right;border-top:solid;border-bottom:solid;border-width:thin;padding-top:10px;padding-bottom:5px;\">" +
               "<span>{15}</span></td></tr>"; ;
            build_html += "<tr>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='1'><span></span></td>" +
                "<td colspan='6'><span></span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='1' style=\"border-top:solid;border-width:thin\"><span></span></td></tr>" +
                "<tr><td><br/></td></tr></table>";
            build_html += "<table style=\"width:100px;font-family:Arial\"><tr>" +
               "<td colspan='6'><span>I hereby ackowledge to have received the sum as full payment of my service rendered.</span></td>" +
               "<td colspan='6' style=\"text-align:right;\"><span>Signature _________________________</span></td>" +
               "</tr>" +
               "</table>";
            #endregion



            return build_html;
        }

        public string populatehtml()
        {
            /* Do not delete this
             * This is the reference for the string format.
                0 - empno
                1 - name
                2 - date covered
                3 - payrollgroup
                4 - department
                5 - basic pay
                6 - sss
                7 - cash adv
                8 - loan bal
                9 - absentded
                10 - philhealth
                11 - lates
                12 - pagibig
                13 - total gross income
                14 - total deduction
                15 - net pay
            */
            Payroll.Payslip ps = new Payroll.Payslip();
            //ps = pr.GetPayslip("3", "56");


            string payslipformat = string.Format(paysliphtml(), ps.empno, ps.empname, ps.date_covered, ps.payrollgroup,
                ps.department, ps.basicpay, ps.sss, ps.cash_adv, ps.loanbal, ps.absentded, ps.philhealth, ps.lates, ps.pagibig,
                ps.totalgrossincome, ps.totaldeduction, ps.netpay);

            return payslipformat;

        }

       

       

        protected void Export_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=div.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
            pdf.RenderControl(htmlTextWriter);

            StringReader stringReader = new StringReader(stringWriter.ToString());
            Document Doc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(Doc);
            PdfWriter.GetInstance(Doc, Response.OutputStream);

            Doc.Open();
            htmlparser.Parse(stringReader);
            Doc.Close();
            Response.Write(Doc);
            Response.End();
        }
    }
}