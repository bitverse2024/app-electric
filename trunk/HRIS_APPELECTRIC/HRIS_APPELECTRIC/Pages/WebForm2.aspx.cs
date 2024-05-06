using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Payslip();
        }

        public string Payslip()
        {
            string build_html = "";
            build_html += "<table id=\"yw2\" style=\"width:150%;font-family:Arial\"><tr><td colspan='6'><span>APP ELECTRIC CORP</span></td></tr>";
            build_html += "<tr><td colspan='6'><span>" + "2018 - 0081" + "</span> <span>" + "Ignacio, Alexa Zyra"+ "</span></td></tr>";
            build_html += "<tr><td colspan='6'></td><td colspan='2'></td></td><td colspan='2'><span>Date Covered: " + 
                "02/13/2020 TO 02/19/2020" + "</span></td><td colspan='2'></tr>";
            build_html += "<tr><td colspan='6'></td><td colspan='2'><td colspan='2'><span>Payroll Group: " +
                "Watts App-Week" + "</span></td><td colspan='2'></tr>";
            build_html += "<tr><td colspan='6'></td><td colspan='2'><td colspan='2'><span>Department: " +
                "ADMIN" + "</span></td><td colspan='2'></tr>";
            build_html += "<tr><td><br/></td></tr>";
            build_html += "<tr><td colspan='1'></td><td colspan='2'><span>Amount</span></td>" +
                "<td colspan='1'></td><td colspan='2'></td>" +
                "<td colspan='1'></td><td colspan='2'></td>" +
                "<td colspan='2'>Loan Balance<span></span></td><td colspan='1'></td></tr>";
            build_html += "<tr>" +
                "<td colspan='1'><span>Basic Pay</span><br/></td>" +
                "<td colspan='2'><span>" + "3,222.00" + "</span></td>" +
                "<td colspan='1'><span>SSS</span></td>" +
                "<td colspan='2'><span> 140.00</span></td>" +
                "<td colspan='1'><span>CASH AD</span></td>" +
                "<td colspan='2'><span>" + "500.00" + "</span></td>" +
                "<td colspan='2'><span>" + "1,500.00" + "</span></td>" +
                "<td colspan='1'></td></tr>";
            build_html += "<tr>" +
                "<td colspan='1'><span>Absences</span><br/></td>" +
                "<td colspan='2'><span>" + "(537.00)" + "</span></td>" +
                "<td colspan='1'><span>PhilHealth</span></td>" +
                "<td colspan='2'><span>" + "52.36" + "</span></td>" +
                "<td colspan='1'><span></span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='1'></td></tr>";
            build_html += "<tr>" +
                "<td colspan='1'><span>Lates</span><br/></td>" +
                "<td colspan='2'><span>" + "(8.95)" + "</span></td>" +
                "<td colspan='1'><span>Pag-Ibig</span></td>" +
                "<td colspan='2'><span>" + "25.00" + "</span></td>" +
                "<td colspan='1'><span></span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='1'></td></tr>";
            build_html += "<tr><td><br/></td></tr></table><br/>";
            build_html += "<table style=\"width:95%;font-family:Arial\"><tr>" +
                "<td colspan='2' style=\"text-align:right;padding-right:20px;\"><span>Total Gross Income</span></td>" +
                "<td colspan='1' style=\"text-align:right;border-top:solid;border-bottom:solid;border-width:thin;padding-top:10px;padding-bottom:5px;\">" +
                "<span>" + "2,676.05" +"</span></td>" +
                "<td colspan='6'><span></span></td>" +
                "<td colspan='2' style=\"text-align:right;padding-right:20px;\"><span>Total Deduction</span></td>" +
                "<td colspan='1' style=\"text-align:right;border-top:solid;border-bottom:solid;border-width:thin;padding-top:10px;padding-bottom:5px;\">" +
                "<span>" + "717.36" + "</span></td></tr>";
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
               "<span style=\"font-size:150%;font-weight:bold\">" + "1,958.69" + "</span></td></tr>";               ;
            build_html += "<tr>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='1'><span></span></td>" +
                "<td colspan='6'><span></span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='1' style=\"border-top:solid;border-width:thin\"><span></span></td></tr>" +
                "<tr><td><br/></td></tr></table>";
            build_html += "<table style=\"width:100%;font-family:Arial\"><tr>" +
               "<td colspan='6'><span>I hereby ackowledge to have recived the sum as full payment of my service rendered.</span></td>" +
               "<td colspan='6' style=\"text-align:right;\"><span>Signature _________________________</span></td>" +
               "</tr>" +
               "</table>";

            return build_html;
        }
    }
}