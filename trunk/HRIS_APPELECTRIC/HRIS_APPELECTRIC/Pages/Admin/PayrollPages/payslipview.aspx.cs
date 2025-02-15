﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin.PayrollPages
{
    public partial class payslipview : System.Web.UI.Page
    {
        Common cm = new Common();
        Payroll pr = new Payroll();
        string cutoffid;
        string empid = "";
        public string bonus1 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            cutoffid = Request.QueryString["cid"];
            empid = Request.QueryString["empid"];
        }

        public string printview()
        {
            return populatehtml(cutoffid, empid);


        }

        public string paysliphtml(Dictionary<string, string> loanentries, string empno,string empallowance)
        {
            string CL = "";
            string CLBal = "";
            string SSS = "";
            string SSSBal = "";
            string PIL = "";
            string PILBal = "";
            string PICL = "";
            string PICLBal = "";
            string SSSCL = "";
            string SSSCLBal = "";
            string CA = "";
            string CABal = "";
            if (loanentries != null && loanentries.Count > 0)
            {
                foreach (KeyValuePair<string, string> kvp in loanentries)
                {
                    if (kvp.Key == "CL")
                    {
                        CL = pr.toRoundOff(true, kvp.Value);
                        CLBal = pr.toRoundOff(true, cm.GetSpecificDataFromDB("Balance", "TBL_LOANENTRIES", "where EmpID = '" + empno + "' AND Name = '" + kvp.Key + "'"));
                    }
                    else if (kvp.Key == "SSS SAL")
                    {
                        SSS = pr.toRoundOff(true, kvp.Value);
                        SSSBal = pr.toRoundOff(true, cm.GetSpecificDataFromDB("Balance", "TBL_LOANENTRIES", "where EmpID = '" + empno + "' AND Name = '" + kvp.Key + "'"));
                    }
                    else if (kvp.Key == "HDMF SAL")
                    {
                        PIL = pr.toRoundOff(true, kvp.Value);
                        PILBal = pr.toRoundOff(true, cm.GetSpecificDataFromDB("Balance", "TBL_LOANENTRIES", "where EmpID = '" + empno + "' AND Name = '" + kvp.Key + "'"));
                    }
                    else if (kvp.Key == "HDMF-CAL")
                    {
                        PICL = pr.toRoundOff(true, kvp.Value);
                        PICLBal = pr.toRoundOff(true, cm.GetSpecificDataFromDB("Balance", "TBL_LOANENTRIES", "where EmpID = '" + empno + "' AND Name = '" + kvp.Key + "'"));
                    }
                    else if (kvp.Key == "SSS-CAL")
                    {
                        SSSCL = pr.toRoundOff(true, kvp.Value);
                        SSSCLBal = pr.toRoundOff(true, cm.GetSpecificDataFromDB("Balance", "TBL_LOANENTRIES", "where EmpID = '" + empno + "' AND Name = '" + kvp.Key + "'"));
                    }
                    else if (kvp.Key.Contains("CASH ADV"))
                    {
                        CA += pr.toRoundOff(true, kvp.Value);
                        CABal += pr.toRoundOff(true, cm.GetSpecificDataFromDB("Balance", "TBL_LOANENTRIES", "where EmpID = '" + empno + "' AND Name = '" + kvp.Key + "'"));
                    }
                    
                }
            }
            #region build_html
            string build_html = "";
            build_html += "<table id=\"yw2\" style=\"width:150%;font-family:Arial;\"><tr><td colspan='6'><span>APP ELECTRIC CORP</span></td></tr>";
            build_html += "<tr><td colspan='6'><span>" + "{0}" + "</span> <span>" + "{1}" + "</span></td></tr></table>";
            build_html += "<table id=\"yw2\" style=\"width:100%;font-family:Arial;\"><tr><td colspan='6' style=\"width: 70% \"></td><td colspan='2'></td></td><td colspan='2'><span>Date Covered: " +
                "{2}" + "</span></td><td colspan='2'></tr>";
            build_html += "<tr><td colspan='6'></td><td colspan='2'><td colspan='2'><span>Payroll Group: " +
                "{3}" + "</span></td><td colspan='2'></tr>";
            build_html += "<tr><td colspan='6'></td><td colspan='2'><td colspan='2'><span>Department: " +
                "{4}" + "</span></td><td colspan='2'></tr></table>";
            build_html += "<table id=\"yw2\" style=\"width:100%;font-family:Arial;\"><tr><td><br/></td></tr>";
            build_html += "<tr><td colspan='1'></td><td colspan='2'><span>Amount</span></td>" +
                "<td colspan='1'></td><td colspan='2'></td>" +
                "<td colspan='1'></td><td colspan='2'></td><td colspan='2'></td><td colspan='1'><span>Loan Balance</span></td></tr>";
            //put here the loan payment <span>Loan Balance</span>
            if (CA != "" && CA != "0.00" && CA != "-")
            {
                build_html += "<tr>" +
                    "<td colspan='1'><span>Basic Pay</span><br/></td>" +
                    "<td colspan='2'><span>" + "{5}" + "</span></td>" +
                    "<td colspan='1'><span>SSS</span></td>" +
                    "<td colspan='2'><span> {6}</span></td>" +
                    "<td colspan='1'><span>Cash Adv</span></td>" +
                    "<td colspan='2'><span align=\"right\">" + CA + "</span></td>" +
                "<td colspan='2'><span></span></td>" +
                    "<td colspan='1'><span align=\"right\">" + CABal + "</span></td></tr>";
            }
            else
            {
                build_html += "<tr>" +
                    "<td colspan='1'><span>Basic Pay</span><br/></td>" +
                    "<td colspan='2'><span>" + "{5}" + "</span></td>" +
                    "<td colspan='1'><span>SSS</span></td>" +
                    "<td colspan='2'><span> {6}</span></td>" +
                    "<td colspan='1'><span>Cash Adv</span></td>" +
                    "<td colspan='2'><span>-</span></td>" +
                "<td colspan='2'><span></span></td>" +
                    "<td colspan='1'><span>-</span></td></tr>";
            }
            //build_html += "<tr>" +
            //    "<td colspan='1'><span>Basic Pay</span><br/></td>" +
            //    "<td colspan='2'><span>" + "{5}" + "</span></td>" +
            //    "<td colspan='1'><span>SSS</span></td>" +
            //    "<td colspan='2'><span> {6}</span></td>" +
            //    "<td colspan='1'><span>CASH AD</span></td>" +
            //    "<td colspan='2'><span>" + "{7}" + "</span></td>" +
            //"<td colspan='2'><span></span></td>" +
            // "<td colspan='1'></td></tr>";
            if (PIL != "" && PIL != "0.00" && PIL != "-")
            {
                build_html += "<tr>" +
                "<td colspan='1'><span>Absences</span><br/></td>" +
                "<td colspan='2'><span>" + "({9})" + "</span></td>" +
                "<td colspan='1'><span>PhilHealth</span></td>" +
                "<td colspan='2'><span>" + "{10}" + "</span></td>" +
                "<td colspan='1'><span>HDMF</span></td>" +
                "<td colspan='2'><span>" + PIL + "</span></td>" +
            "<td colspan='2'></td>" +
            "<td colspan='1'><span>" + PILBal + "</span></td></tr>";
            }
            else
            {
                build_html += "<tr>" +
                "<td colspan='1'><span>Absences</span><br/></td>" +
                "<td colspan='2'><span>" + "({9})" + "</span></td>" +
                "<td colspan='1'><span>PhilHealth</span></td>" +
                "<td colspan='2'><span>" + "{10}" + "</span></td>" +
                "<td colspan='1'><span>HDMF</span></td>" +
                "<td colspan='2'><span>" + "-" + "</span></td>" +
            "<td colspan='2'></td>" +
            "<td colspan='1'><span>" + "-" + "</span></td></tr>";

            }

            if (PICL != "" && PICL != "0.00" && PICL != "-") //palitan mo na lang yung condition to hdmf value
            {
                build_html += "<tr>" +
              "<td colspan='1'><span>Lates</span><br/></td>" +
              "<td colspan='2'><span>" + "({11})" + "</span></td>" +
              "<td colspan='1'><span>Pag-Ibig</span></td>" +
              "<td colspan='2'><span>" + "{12}" + "</span></td>" +
              "<td colspan='1'><span>HDMF Cal.</span></td>" +
              "<td colspan='2'><span>" + PICL + "</span></td>" +
              "<td colspan='2'><span></span></td>" +
              "<td colspan='1'><span>" + PICLBal + "</span></td></tr>";
            }
            else
            {
                build_html += "<tr>" +
              "<td colspan='1'><span>Lates</span><br/></td>" +
              "<td colspan='2'><span>" + "({11})" + "</span></td>" +
              "<td colspan='1'><span>Pag-Ibig</span></td>" +
              "<td colspan='2'><span>" + "{12}" + "</span></td>" +
              "<td colspan='1'><span>HDMF Cal.</span></td>" +
              "<td colspan='2'><span>" + "-" + "</span></td>" +
              "<td colspan='2'><span></span></td>" +
              "<td colspan='1'><span>" + "-" + "</span></td></tr>";

            }


            //if (bonus1 != "" && bonus1 != "0.00")
            //{
            //    build_html += "<tr>" +
            //  "<td colspan='1'><span>Lates</span><br/></td>" +
            //  "<td colspan='2'><span>" + "({11})" + "</span></td>" +
            //  "<td colspan='1'><span>Pag-Ibig</span></td>" +
            //  "<td colspan='2'><span>" + "{12}" + "</span></td>" +
            //  "<td colspan='1'><span>13th Month</span></td>" +
            //  "<td colspan='2'><span>{21}</span></td>" +
            //    "<td colspan='2'><span></span></td>" +
            //    "<td colspan='1'></td></tr>";
            //}
            //else
            //{
            //    build_html += "<tr>" +
            //  "<td colspan='1'><span>Lates</span><br/></td>" +
            //  "<td colspan='2'><span>" + "({11})" + "</span></td>" +
            //  "<td colspan='1'><span>Pag-Ibig</span></td>" +
            //  "<td colspan='2'><span>" + "{12}" + "</span></td>" +
            //  "<td colspan='1'><span></span></td>" +
            //  "<td colspan='2'><span></span></td>" +
            //  "<td colspan='2'><span></span></td>" +
            //  "<td colspan='1'></td></tr>";
            //}
            if (SSS != "" && SSS != "0.00" && SSS != "-")
            {
                build_html += "<tr>" +
                    "<td colspan='1'><span>Undertime</span><br/></td>" +
                    "<td colspan='2'><span>(" + "{18}" + ")</span></td>" +
                    "<td colspan='1'><span></span></td>" +
                    "<td colspan='2'><span></span></td>" +
                    "<td colspan='1'><span>SSS Sal.</span></td>" +
                    "<td colspan='2'><span>" + SSS + "</span></td>" +
                    "<td colspan='2'><span></span></td>" +
                    "<td colspan='1'><span>" + SSSBal + "</span></td></tr>";
            }
            else
            {
                build_html += "<tr>" +
                    "<td colspan='1'><span>Undertime</span><br/></td>" +
                    "<td colspan='2'><span>(" + "{18}" + ")</span></td>" +
                    "<td colspan='1'><span></span></td>" +
                    "<td colspan='2'><span></span></td>" +
                    "<td colspan='1'><span>SSS Sal.</span></td>" +
                    "<td colspan='2'><span>" + "-" + "</span></td>" +
                    "<td colspan='2'><span></span></td>" +
                    "<td colspan='1'><span>" + "-" + "</span></td></tr>";
            }
            if (SSSCL != "" && SSSCL != "0.00" && SSSCL != "-")
            {
                build_html += "<tr>" +
             "<td colspan='1'><span>Overtime</span><br/></td>" +
             "<td colspan='2'><span>" + "{19}" + "</span></td>" +
             "<td colspan='1'><span></span></td>" +
             "<td colspan='2'><span></span></td>" +
             "<td colspan='1'><span>SSS Cal.</span></td>" +
             "<td colspan='2'><span>" + SSSCL + "</span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='1'><span>" + SSSCLBal + "</span></td></tr>";
            }
            else
            {
                build_html += "<tr>" +
             "<td colspan='1'><span>Overtime</span><br/></td>" +
             "<td colspan='2'><span>" + "{19}" + "</span></td>" +
             "<td colspan='1'><span></span></td>" +
             "<td colspan='2'><span></span></td>" +
             "<td colspan='1'><span>SSS Cal.</span></td>" +
             "<td colspan='2'><span>" + "-" + "</span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='1'><span>" + "-" + "</span></td></tr>";
            }
            build_html += "<tr>" +
         "<td colspan='1'><span>Leave Pay</span><br/></td>" +
         "<td colspan='2'><span>" + "{17}" + "</span></td>" +
         "<td colspan='1'><span></span></td>" +
         "<td colspan='2'><span></span></td>" +
         "<td colspan='1'><span></span></td>" +
         "<td colspan='2'><span></span></td>" +
            "<td colspan='2'><span></span></td>" +
            "<td colspan='1'></td></tr>";
            build_html += "<tr>" +
             "<td colspan='1'><span>Holiday Pay</span><br/></td>" +
             "<td colspan='2'><span>" + "{20}" + "</span></td>" +
             "<td colspan='1'><span></span></td>" +
             "<td colspan='2'><span></span></td>" +
             "<td colspan='1'><span></span></td>" +
             "<td colspan='2'><span></span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='1'></td></tr>";
            build_html += "<tr>" +
           "<td colspan='1'><span>" + "({24})" + "</span><br/></td>" +
           "<td colspan='2'><span>" + "{22}" + "</span></td>" +
           "<td colspan='1'><span></span></td>" +
           "<td colspan='2'><span></span></td>" +
           "<td colspan='1'><span></span></td>" +
           "<td colspan='2'><span></span></td>" +
              "<td colspan='2'><span></span></td>" +
              "<td colspan='1'></td></tr>";
            
            if(empallowance != "0")
            {
                build_html += "<tr>" +
           "<td colspan='1'><span>Allowance</span><br/></td>" +
           "<td colspan='2'><span>" + "{23}" + "</span></td>" +
           "<td colspan='1'><span></span></td>" +
           "<td colspan='2'><span></span></td>" +
           "<td colspan='1'><span></span></td>" +
           "<td colspan='2'><span></span></td>" +
              "<td colspan='2'><span></span></td>" +
              "<td colspan='1'></td></tr>";
            }
            



            //if (bonus1 != "" && bonus1 != "0.00")
            //{
            //    build_html += "<tr>" +
            // "<td colspan='1'><span>Overtime</span><br/></td>" +
            // "<td colspan='2'><span>" + "{19}" + "</span></td>" +
            // "<td colspan='1'><span>Remaining Leave Credit</span></td>" +
            // "<td colspan='2'><span>" + "({16})" + "</span></td>" +
            // "<td colspan='1'><span></span></td>" +
            // "<td colspan='2'><span></span></td>" +
            //    "<td colspan='2'><span></span></td>" +
            //    "<td colspan='1'></td></tr>";

            //}

            //10/25/2021 Jan fix
            //build_html += "<tr>" +
            // "<td colspan='1'><span>Loan Balance</span><br/></td>" +
            // "<td colspan='2'><span>" + "{8}" + "</span></td>" +
            // "<td colspan='1'><span></span></td>" +
            // "<td colspan='2'><span></span></td>" +
            // "<td colspan='1'><span></span></td>" +
            // "<td colspan='2'><span></span></td>" +
            // "<td colspan='2'><span></span></td>" +
            // "<td colspan='1'></td></tr>";

            build_html += "<tr><td><br/></td></tr></table><br/>";
            build_html += "<table style=\"width:95%;font-family:Arial\"><tr>" +
                "<td colspan='2' style=\"text-align:right;padding-right:20px;\"><span>Total Gross Income</span></td>" +
                "<td colspan='1' style=\"text-align:right;border-top:solid;border-bottom:solid;border-width:thin;padding-top:10px;padding-bottom:5px;\">" +
                "<span>" + "{13}" + "</span></td>" +
                "<td colspan='6'><span></span></td>" +
                "<td colspan='2' style=\"text-align:right;padding-right:20px;\"><span>Total Deduction</span></td>" +
                "<td colspan='1' style=\"text-align:right;border-top:solid;border-bottom:double;border-width:thin;padding-top:10px;padding-bottom:5px;\">" +
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
                "<tr><td><br/><br/></td></tr></table>";
            build_html += "<table style=\"width:100%;font-family:Arial\"><tr>" +
               "<td colspan='6'><span>I hereby ackowledge to have received the sum as full payment of my service rendered.</span></td>" +
               "<td colspan='6' style=\"text-align:right;\"><span>Signature _________________________</span></td>" +
               "</tr>" +
               "</table>";
            build_html += "<table style=\"width:150%;font-family:Arial;border-bottom:dashed\">" +
               "<tr><td><br/></td></tr></table>";
            #endregion


            //NEW
            //build_html = "<table id=\"yw2\" style=\"width:100%;font-family:Arial;\">" +
            //    "<tr>" +
            //    "<td colspan='6'><span>APP ELECTRIC CORP</span></td>" +
            //    "</tr>" +
            //    "<tr>" +
            //    "<td colspan='6'><span>{0}</span> <span>{1}</span></td>" +
            //    "</tr>" +
            //    "</table>" +
            //    "<table id=\"yw2\" style=\"width:100%;font-family:Arial;\">" +
            //    "<tr>" +
            //    "<td colspan='6' style=\"width: 70% \"></td>" +
            //    "<td colspan='2'></td>" +
            //    "<td colspan='2'><span>Date Covered: {2}</span></td>" +
            //    "<td colspan='2'>" +
            //    "</tr>" +
            //    "<tr>" +
            //    "<td colspan='6'></td>" +
            //    "<td colspan='2'>" +
            //    "<td colspan='2'><span>Payroll Group: {3}</span></td>" +
            //    "<td colspan='2'>" +
            //    "</tr>" +
            //    "<tr>" +
            //    "<td colspan='6'></td>" +
            //    "<td colspan='2'>" +
            //    "<td colspan='2'><span>Department: {4}</span></td>" +
            //    "<td colspan='2'>" +
            //    "</tr>" +
            //    "</table>" +
            //    "<table id=\"yw2\" style=\"width:100%;font-family:Arial;\">" +
            //    "<tr>" +
            //    "<td><br/></td>" +
            //    "</tr>" +
            //    "<tr>" +
            //    "<td colspan='1'></td>" +
            //    "<td colspan='2'><span>Amount</span></td>" +
            //    "<td colspan='1'></td>" +
            //    "<td colspan='2'></td>" +
            //    "<td colspan='1'></td>" +
            //    "<td colspan='2'></td>" +
            //    "</tr>" +
            //    "<tr>" +
            //    "<td colspan='1'><span>Basic Pay</span><br/></td>" +
            //    "<td colspan='2'><span>{5}</span></td>" +
            //    "<td colspan='1'><span>SSS</span></td>" +
            //    "<td colspan='2'><span> {6}</span></td>" +
            //    "<td colspan='1'><span>CASH AD</span></td>" +
            //    "<td colspan='2'><span>{7}</span></td>" +
            //    "<td colspan='2'><span></span></td>" +
            //    "<td colspan='1'></td>" +
            //    "</tr>" +
            //    "<tr>" +
            //    "<td colspan='1'><span>Absences</span>" +
            //    "<br/>" +
            //    "</td>" +
            //    "<td colspan='2'><span>({9})</span></td>" +
            //    "<td colspan='1'><span>PhilHealth</span></td>" +
            //    "<td colspan='2'><span>{10}</span></td>" +
            //    "<td colspan='1'><span>Holiday Pay</span></td>" +
            //    "<td colspan='2'><span>{20}</span></td>" +
            //    "<td colspan='2'><span></span></td>" +
            //    "<td colspan='1'></td>" +
            //    "</tr>" +
            //    "<tr>" +
            //    "<td colspan='1'><span>Lates</span><br/></td>" +
            //    "<td colspan='2'><span>({11})</span></td>" +
            //    "<td colspan='1'><span>Pag-Ibig</span></td>" +
            //    "<td colspan='2'><span>{12}</span></td>" +
            //    "<td colspan='1'><span></span></td>" +
            //    "<td colspan='2'><span></span></td>" +
            //    "<td colspan='2'><span></span></td>" +
            //    "<td colspan='1'></td>" +
            //    "</tr>" +
            //    "<tr>" +
            //    "<td colspan='1'><span>Undertime</span><br/></td>" +
            //    "<td colspan='2'><span>{18}</span></td>" +
            //    "<td colspan='1'><span>Leave Pay</span></td>" +
            //    "<td colspan='2'><span>{17}</span></td>" +
            //    "<td colspan='1'><span>Adjustment</span></td>" +
            //    "<td colspan='2'><span>{22}</span></td>" +
            //    "<td colspan='2'><span></span></td>" +
            //    "<td colspan='1'></td>" +
            //    "</tr>" +
            //    "<tr>" +
            //    "<td colspan='1'><span>Overtime</span><br/></td>" +
            //    "<td colspan='2'><span>{19}</span></td>" +
            //    "<td colspan='1'><span>Remaining Leave Credit</span></td>" +
            //    "<td colspan='2'><span>({16})</span></td>" +
            //    "<td colspan='1'><span></span></td>" +
            //    "<td colspan='2'><span></span></td>" +
            //    "<td colspan='2'><span></span></td>" +
            //    "<td colspan='1'></td>" +
            //    "</tr>" +
            //    "<tr>" +
            //    "<td colspan='1'><span>Loan Balance</span><br/></td>" +
            //    "<td colspan='2'><span>{8}</span></td>" +
            //    "<td colspan='1'><span></span></td>" +
            //    "<td colspan='2'><span></span></td>" +
            //    "<td colspan='1'><span></span></td>" +
            //    "<td colspan='2'><span></span></td>" +
            //    "<td colspan='2'><span></span></td>" +
            //    "<td colspan='1'></td>" +
            //    "</tr>" +
            //    "<tr>" +
            //    "<td><br/></td>" +
            //    "</tr>" +
            //    "</table>" +
            //    "<br/>" +
            //    "<table style=\"width:95%;font-family:Arial\">" +
            //    "<tr>" +
            //    "<td colspan='2' style=\"text-align:right;padding-right:20px;\"><span>Total Gross Income</span></td>" +
            //    "<td colspan='1' style=\"text-align:right;border-top:solid;border-bottom:solid;border-width:thin;padding-top:10px;padding-bottom:5px;\"><span>{13}</span></td>" +
            //    "<td colspan='6'><span></span></td><td colspan='2' style=\"text-align:right;padding-right:20px;\"><span>Total Deduction</span></td>" +
            //    "<td colspan='1' style=\"text-align:right;border-top:solid;border-bottom:solid;border-width:thin;padding-top:10px;padding-bottom:5px;\"><span>{14}</span></td>" +
            //    "</tr>" +
            //    "<tr>" +
            //    "<td colspan='2'><span></span></td><td colspan='1' style=\"border-top:solid;border-width:thin\"><span></span></td>" +
            //    "<td colspan='6'><span></span></td><td colspan='2'><span></span></td>" +
            //    "<td colspan='1' style=\"border-top:solid;border-width:thin\"><span></span></td>" +
            //    "</tr>" +
            //    "<tr>" +
            //    "<td><br/></td>" +
            //    "</tr>" +
            //    "<tr><td colspan='2'><span></span></td><td colspan='1'><span></span></td>" +
            //    "<td colspan='6'><span></span></td>" +
            //    "<td colspan='2' style=\"text-align:right;padding-right:70px;\"><span>Net Pay</span></td>" +
            //    "<td colspan='1' style=\"text-align:right;border-top:solid;border-bottom:solid;border-width:thin;padding-top:10px;padding-bottom:5px;\"><span style=\"font-size:150%;font-weight:bold\">{15}</span></td>" +
            //    "</tr><tr>" +
            //    "<td colspan='2'><span></span></td>" +
            //    "<td colspan='1'><span></span></td>" +
            //    "<td colspan='6'><span></span></td>" +
            //    "<td colspan='2'><span></span></td>" +
            //    "<td colspan='1' style=\"border-top:solid;border-width:thin\"><span></span></td>" +
            //    "</tr>" +
            //    "<tr>" +
            //    "<td><br/><br/></td>" +
            //    "</tr>" +
            //    "</table>" +
            //    "<table style=\"width:100%;font-family:Arial\">" +
            //    "<tr>" +
            //    "<td colspan='6'><span>I hereby ackowledge to have received the sum as full payment of my service rendered.</span></td><td colspan='6' style=\"text-align:right;\"><span>Signature _________________________</span></td>" +
            //    "</tr>" +
            //    "</table>" +
            //    "<table style=\"width:150%;font-family:Arial;border-bottom:dashed\">" +
            //    "<tr>" +
            //    "<td><br/></td>" +
            //    "</tr>" +
            //    "</table>";
            return build_html;
        }
        public string paysliphtmlNew(string empno, string empallowance, string CL, string CLBal,
            string SSS, string SSSBal, string PIL, string PILBal, string PICL, string PICLBal,
            string SSSCL, string SSSCLBal, string CA, string CABal, string CA2, string CABal2,
            string CA3, string CABal3)
        {
            
            
            #region build_html
            string build_html = "";
            build_html += "<table id=\"yw2\" style=\"width:150%;font-family:Arial;\"><tr><td colspan='6'><span>APP ELECTRIC CORP</span></td></tr>";
            build_html += "<tr><td colspan='6'><span>" + "{0}" + "</span> <span>" + "{1}" + "</span></td></tr></table>";
            build_html += "<table id=\"yw2\" style=\"width:100%;font-family:Arial;\"><tr><td colspan='6' style=\"width: 70% \"></td><td colspan='2'></td></td><td colspan='2'><span>Date Covered: " +
                "{2}" + "</span></td><td colspan='2'></tr>";
            build_html += "<tr><td colspan='6'></td><td colspan='2'><td colspan='2'><span>Payroll Group: " +
                "{3}" + "</span></td><td colspan='2'></tr>";
            build_html += "<tr><td colspan='6'></td><td colspan='2'><td colspan='2'><span>Department: " +
                "{4}" + "</span></td><td colspan='2'></tr></table>";
            build_html += "<table id=\"yw2\" style=\"width:100%;font-family:Arial;\"><tr><td><br/></td></tr>";
            build_html += "<tr><td colspan='1'></td><td colspan='2'><span>Amount</span></td>" +
                "<td colspan='1'></td><td colspan='2'></td>" +
                "<td colspan='1'></td><td colspan='2'></td><td colspan='2'></td><td colspan='1'><span>Loan Balance</span></td></tr>";
            //put here the loan payment <span>Loan Balance</span>
            if (PIL != "" && PIL != "0.00" && PIL != "-")
            {
                build_html += "<tr>" +
                    "<td colspan='1'><span>Basic Pay</span><br/></td>" +
                    "<td colspan='2'><span>" + "{5}" + "</span></td>" +
                    "<td colspan='1'><span>SSS</span></td>" +
                    "<td colspan='2'><span> {6}</span></td>" +
                    "<td colspan='1'><span>HDMF</span></td>" +
                    "<td colspan='2'><span align=\"right\">" + PIL + "</span></td>" +
                "<td colspan='2'><span></span></td>" +
                    "<td colspan='1'><span align=\"right\">" + PILBal + "</span></td></tr>";
            }
            else
            {
                build_html += "<tr>" +
                    "<td colspan='1'><span>Basic Pay</span><br/></td>" +
                    "<td colspan='2'><span>" + "{5}" + "</span></td>" +
                    "<td colspan='1'><span>SSS</span></td>" +
                    "<td colspan='2'><span> {6}</span></td>" +
                    "<td colspan='1'><span>HDMF</span></td>" +
                    "<td colspan='2'><span>-</span></td>" +
                "<td colspan='2'><span></span></td>" +
                    "<td colspan='1'><span>-</span></td></tr>";
            }
            if (PICL != "" && PICL != "0.00" && PICL != "-")
            {
                build_html += "<tr>" +
                "<td colspan='1'><span>Absences</span><br/></td>" +
                "<td colspan='2'><span>" + "({9})" + "</span></td>" +
                "<td colspan='1'><span>PhilHealth</span></td>" +
                "<td colspan='2'><span>" + "{10}" + "</span></td>" +
                "<td colspan='1'><span>HDMF Cal.</span></td>" +
                "<td colspan='2'><span>" + PICL + "</span></td>" +
            "<td colspan='2'></td>" +
            "<td colspan='1'><span>" + PICLBal + "</span></td></tr>";
            }
            else
            {
                build_html += "<tr>" +
                "<td colspan='1'><span>Absences</span><br/></td>" +
                "<td colspan='2'><span>" + "({9})" + "</span></td>" +
                "<td colspan='1'><span>PhilHealth</span></td>" +
                "<td colspan='2'><span>" + "{10}" + "</span></td>" +
                "<td colspan='1'><span>HDMF Cal.</span></td>" +
                "<td colspan='2'><span>" + "-" + "</span></td>" +
            "<td colspan='2'></td>" +
            "<td colspan='1'><span>" + "-" + "</span></td></tr>";

            }

            if (SSS != "" && SSS != "0.00" && SSS != "-") //palitan mo na lang yung condition to hdmf value
            {
                build_html += "<tr>" +
              "<td colspan='1'><span>Lates</span><br/></td>" +
              "<td colspan='2'><span>" + "({11})" + "</span></td>" +
              "<td colspan='1'><span>Pag-Ibig</span></td>" +
              "<td colspan='2'><span>" + "{12}" + "</span></td>" +
              "<td colspan='1'><span>SSS Sal.</span></td>" +
              "<td colspan='2'><span>" + SSS + "</span></td>" +
              "<td colspan='2'><span></span></td>" +
              "<td colspan='1'><span>" + SSSBal + "</span></td></tr>";
            }
            else
            {
                build_html += "<tr>" +
              "<td colspan='1'><span>Lates</span><br/></td>" +
              "<td colspan='2'><span>" + "({11})" + "</span></td>" +
              "<td colspan='1'><span>Pag-Ibig</span></td>" +
              "<td colspan='2'><span>" + "{12}" + "</span></td>" +
              "<td colspan='1'><span>SSS Sal.</span></td>" +
              "<td colspan='2'><span>" + "-" + "</span></td>" +
              "<td colspan='2'><span></span></td>" +
              "<td colspan='1'><span>" + "-" + "</span></td></tr>";

            }
            if (SSSCL != "" && SSSCL != "0.00" && SSSCL != "-")
            {
                build_html += "<tr>" +
                    "<td colspan='1'><span>Undertime</span><br/></td>" +
                    "<td colspan='2'><span>" + "({18})" + "</span></td>" +
                    "<td colspan='1'><span>Tax</span></td>" +
                    "<td colspan='2'><span>" + "{25}" + "</span></td>" +
                    "<td colspan='1'><span>SSS Cal.</span></td>" +
                    "<td colspan='2'><span>" + SSSCL + "</span></td>" +
                    "<td colspan='2'><span></span></td>" +
                    "<td colspan='1'><span>" + SSSCLBal + "</span></td></tr>";
            }
            else
            {
                build_html += "<tr>" +
                    "<td colspan='1'><span>Undertime</span><br/></td>" +
                    "<td colspan='2'><span>" + "({18})" + "</span></td>" +
                    "<td colspan='1'><span>Tax</span></td>" +
                    "<td colspan='2'><span>" + "{25}" + "</span></td>" +
                    "<td colspan='1'><span>SSS Cal.</span></td>" +
                    "<td colspan='2'><span>" + "-" + "</span></td>" +
                    "<td colspan='2'><span></span></td>" +
                    "<td colspan='1'><span>" + "-" + "</span></td></tr>";
            }
            if (CA != "" && CA != "0.00" && CA != "-")
            {
                build_html += "<tr>" +
             "<td colspan='1'><span>Overtime</span><br/></td>" +
             "<td colspan='2'><span>" + "{19}" + "</span></td>" +
             "<td colspan='1'><span></span></td>" +
             "<td colspan='2'><span></span></td>" +
             "<td colspan='1'><span>CASH ADV</span></td>" +
             "<td colspan='2'><span>" + CA + "</span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='1'><span>" + CABal + "</span></td></tr>";
            }
            else
            {
                build_html += "<tr>" +
             "<td colspan='1'><span>Overtime</span><br/></td>" +
             "<td colspan='2'><span>" + "{19}" + "</span></td>" +
             "<td colspan='1'><span></span></td>" +
             "<td colspan='2'><span></span></td>" +
             "<td colspan='1'><span></span></td>" +
             "<td colspan='2'><span></span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='1'><span></span></td></tr>";
            }

            if (CA2 != "" && CA2 != "0.00" && CA2 != "-")
            {
                build_html += "<tr>" +
                    "<td colspan='1'><span>Leave Pay</span><br/></td>" +
                    "<td colspan='2'><span>" + "{17}" + "</span></td>" +
                    "<td colspan='1'><span></span></td>" +
                    "<td colspan='2'><span></span></td>" +
                    "<td colspan='1'><span>CASH ADV</span></td>" +
                    "<td colspan='2'><span>" + CA2 + "</span></td>" +
                    "<td colspan='2'><span></span></td>" +
                    "<td colspan='1'><span>" + CABal2 + "</span></td></tr>";
            }
            else
            {
                build_html += "<tr>" +
                    "<td colspan='1'><span>Leave Pay</span><br/></td>" +
                    "<td colspan='2'><span>" + "{17}" + "</span></td>" +
                    "<td colspan='1'><span></span></td>" +
                    "<td colspan='2'><span></span></td>" +
                    "<td colspan='1'><span></span></td>" +
                    "<td colspan='2'><span></span></td>" +
                    "<td colspan='2'><span></span></td>" +
                    "<td colspan='1'></td></tr>";
            }
            if (CA3 != "" && CA3 != "0.00" && CA3 != "-")
            {
                build_html += "<tr>" +
                    "<td colspan='1'><span>Holiday Pay</span><br/></td>" +
                    "<td colspan='2'><span>" + "{20}" + "</span></td>" +
                    "<td colspan='1'><span></span></td>" +
                    "<td colspan='2'><span></span></td>" +
                    "<td colspan='1'><span>CASH ADV</span></td>" +
                    "<td colspan='2'><span>" + CA3 + "</span></td>" +
                    "<td colspan='2'><span></span></td>" +
                    "<td colspan='1'><span>" + CABal3 + "</span></td></tr>";
            }
            else
            {
                build_html += "<tr>" +
                             "<td colspan='1'><span>Holiday Pay</span><br/></td>" +
                             "<td colspan='2'><span>" + "{20}" + "</span></td>" +
                             "<td colspan='1'><span></span></td>" +
                             "<td colspan='2'><span></span></td>" +
                             "<td colspan='1'><span></span></td>" +
                             "<td colspan='2'><span></span></td>" +
                                "<td colspan='2'><span></span></td>" +
                                "<td colspan='1'></td></tr>";
            }

                
            build_html += "<tr>" +
           "<td colspan='1'><span>" + "({24})" + "</span><br/></td>" +
           "<td colspan='2'><span>" + "{22}" + "</span></td>" +
           "<td colspan='1'><span></span></td>" +
           "<td colspan='2'><span></span></td>" +
           "<td colspan='1'><span></span></td>" +
           "<td colspan='2'><span></span></td>" +
              "<td colspan='2'><span></span></td>" +
              "<td colspan='1'></td></tr>";

            if (empallowance != "0")
            {
                build_html += "<tr>" +
           "<td colspan='1'><span>Allowance</span><br/></td>" +
           "<td colspan='2'><span>" + "{23}" + "</span></td>" +
           "<td colspan='1'><span></span></td>" +
           "<td colspan='2'><span></span></td>" +
           "<td colspan='1'><span></span></td>" +
           "<td colspan='2'><span></span></td>" +
              "<td colspan='2'><span></span></td>" +
              "<td colspan='1'></td></tr>";
            }

            build_html += "<tr><td><br/></td></tr></table><br/>";
            build_html += "<table style=\"width:95%;font-family:Arial\"><tr>" +
                "<td colspan='2' style=\"text-align:right;padding-right:20px;\"><span>Total Gross Income</span></td>" +
                "<td colspan='1' style=\"text-align:right;border-top:solid;border-bottom:solid;border-width:thin;padding-top:10px;padding-bottom:5px;\">" +
                "<span>" + "{13}" + "</span></td>" +
                "<td colspan='6'><span></span></td>" +
                "<td colspan='2' style=\"text-align:right;padding-right:20px;\"><span>Total Deduction</span></td>" +
                "<td colspan='1' style=\"text-align:right;border-top:solid;border-bottom:double;border-width:thin;padding-top:10px;padding-bottom:5px;\">" +
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
                "<tr><td><br/><br/></td></tr></table>";
            build_html += "<table style=\"width:100%;font-family:Arial\"><tr>" +
               "<td colspan='6'><span>I hereby ackowledge to have received the sum as full payment of my service rendered.</span></td>" +
               "<td colspan='6' style=\"text-align:right;\"><span>Signature _________________________</span></td>" +
               "</tr>" +
               "</table>";
            build_html += "<table style=\"width:150%;font-family:Arial;border-bottom:dashed\">" +
               "<tr><td><br/></td></tr></table>";
            #endregion
            return build_html;
        }


        public string populatehtml(string cutoffid, string empno)
        {
            string finalhtml = "";
            #region string format for the html
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
                16 - remainingleavescredit
                17 - leave pay
                18 - undertime
                19 - overtime pay
                20 - holiday pay
                21 - bonus(13th month)

                22 - adjustment //12/17/2021
                23 - allowance //05/26/2022
                24 - adjustment remarks //07/18/2022 Jan Wong
                25 - wtax 08/01/2022 Jan Wong
                
            */
            #endregion string format for the html

            if (empno == null || empno == "" || empno == "ALL")
            {
                List<Payroll.Payslip> listps = new List<Payroll.Payslip>();
                listps = pr.GetPayslipBulk(cutoffid);
                int i = 0;
                foreach (Payroll.Payslip ps in listps)
                {
                    List<string> loanids = new List<string>();
                    Dictionary<string, string> loan_name_amount = new Dictionary<string, string>();
                    loanids = cm.GetListDataFromDB(" loanEntryID", "TBL_LOANPAYMENTHISTORY", "where EmpID = '" + ps.empno + "' and CutoffID = '" + cutoffid + "'");
                    double CL = 0, CLBal = 0,
                    SSS = 0, SSSBal = 0, PIL = 0, PILBal = 0, PICL = 0, PICLBal = 0,
                    SSSCL = 0, SSSCLBal = 0, CA = 0, CABal = 0, CA2 = 0, CABal2 = 0,
                    CA3 = 0, CABal3 = 0;
                    int CAcounter = 1;
                    foreach (string loanid in loanids)
                    {
                        //06/28/2022 Jan Wong
                        //string val1 = "", val2 = "";
                        //cm.GetTwoDataFromDB("A.Name", "B.AmountPaid", "TBL_LOANENTRIES A, TBL_LOANPAYMENTHISTORY B", "where A.id = B.loanEntryID AND A.id = " + loanid + " AND B.CutoffID = '" + cutoffid + "'", out val1, out val2);
                        //if (val1 != "" && val2 != "")
                        //{
                        //    loan_name_amount.Add(val1, val2);
                        //}
                        string loancode = "", loanded = "", loanbal = "";
                        double dblloanded = 0, dblloanbal = 0;
                        cm.GetThreeDataFromDB("C.LoanID", "B.AmountPaid", "B.afterpaymentbal",
                            "TBL_LOANENTRIES A, TBL_LOANPAYMENTHISTORY B, TBL_LOANS C",
                            "where A.id = B.loanEntryID AND A.LoanCode = C.id AND A.id = " + loanid + " AND B.CutoffID = '" + cutoffid + "'", out loancode, out loanded, out loanbal);
                        double.TryParse(loanded, out dblloanded);
                        double.TryParse(loanbal, out dblloanbal);
                        if (loancode == "SSS")
                        {
                            SSS += dblloanded;
                            SSSBal += dblloanbal;
                        }
                        else if (loancode == "PIL")
                        {
                            PIL += dblloanded;
                            PILBal += dblloanbal;
                        }
                        else if (loancode == "PICL")
                        {
                            PICL += dblloanded;
                            PICLBal += dblloanbal;
                        }
                        else if (loancode == "SSSCL")
                        {
                            SSSCL += dblloanded;
                            SSSCLBal += dblloanbal;
                        }
                        else if (loancode == "CA")
                        {
                            if (CAcounter == 1)
                            {
                                CA += dblloanded;
                                CABal += dblloanbal;
                            }
                            else if (CAcounter == 2)
                            {
                                CA2 += dblloanded;
                                CABal2 += dblloanbal;
                            }
                            else if (CAcounter == 3)
                            {
                                CA3 += dblloanded;
                                CABal3 += dblloanbal;
                            }
                            CAcounter++;
                        }



                    }
                    if (ps.bonus != "") bonus1 = pr.toRoundOff(true, ps.bonus);
                    else bonus1 = "";
                    i++;
                    string payrollgrpname = cm.GetSpecificDataFromDB("payrollgrpname", "TBL_PAYROLLGRP", "where id = " + ps.payrollgroup + "");
                    finalhtml += string.Format(paysliphtmlNew(ps.empno, ps.allowance, pr.toRoundOff(true, CL.ToString()),
                    pr.toRoundOff(true, CLBal.ToString()), pr.toRoundOff(true, SSS.ToString()),
                    pr.toRoundOff(true, SSSBal.ToString()), pr.toRoundOff(true, PIL.ToString()),
                    pr.toRoundOff(true, PILBal.ToString()), pr.toRoundOff(true, PICL.ToString()),
                    pr.toRoundOff(true, PICLBal.ToString()), pr.toRoundOff(true, SSSCL.ToString()),
                    pr.toRoundOff(true, SSSCLBal.ToString()), pr.toRoundOff(true, CA.ToString()),
                    pr.toRoundOff(true, CABal.ToString()), pr.toRoundOff(true, CA2.ToString()),
                    pr.toRoundOff(true, CABal2.ToString()), pr.toRoundOff(true, CA3.ToString()),
                    pr.toRoundOff(true, CABal3.ToString())), ps.empno, ps.empname, ps.date_covered, payrollgrpname,
                    ps.department, pr.toRoundOff(true, ps.basicpay), pr.toRoundOff(true, ps.sss), ps.cash_adv, ps.loanbal, pr.toRoundOff(true, ps.absentded), pr.toRoundOff(true, ps.philhealth), pr.toRoundOff(true, ps.lates), pr.toRoundOff(true, ps.pagibig),
                    pr.toRoundOff(true, ps.totalgrossincome), pr.toRoundOff(true, ps.totaldeduction), pr.toRoundOff(true, ps.netpay), ps.remainingleavecredit, pr.toRoundOff(true, ps.leavepay), pr.toRoundOff(true, ps.utded), pr.toRoundOff(true, ps.otpay), pr.toRoundOff(true, ps.holidaypay)
                    , bonus1, pr.toRoundOff(true, ps.adjustment), pr.toRoundOff(true, ps.allowance),cm.RemoveSpecialCharactersForFileName(ps.adjustmentremarks),pr.toRoundOff(true, ps.wtax));
                    if (i == 3)
                    {
                        finalhtml += "<h4 style = \"page-break-after:always\" ></h4>";
                        i = 0;
                    }

                }
            }
            else
            {
                Payroll.Payslip ps = new Payroll.Payslip();
                //ps = pr.GetPayslip(cutoffid, empno);
                if (ps == null || ps.empno == "" || ps.empno == null)
                {
                    return finalhtml = "";
                }
                List<string> loanids = new List<string>();
                //Dictionary<string, string> loan_name_amount = new Dictionary<string, string>();
                loanids = cm.GetListDataFromDB("loanEntryID", "TBL_LOANPAYMENTHISTORY", "where EmpID = '" + ps.empno + "' and CutoffID = '" + cutoffid + "'");
                double CL = 0, CLBal = 0,
                    SSS = 0, SSSBal = 0, PIL = 0, PILBal = 0, PICL = 0, PICLBal = 0,
                    SSSCL = 0, SSSCLBal = 0, CA = 0,  CABal = 0, CA2 = 0, CABal2 = 0,
                    CA3 = 0, CABal3 = 0;
                int CAcounter = 1;
                foreach (string loanid in loanids)
                {
                    //06/28/2022 Jan Wong
                    //string val1 = "", val2 = "";
                    //cm.GetTwoDataFromDB("A.Name", "B.AmountPaid", "TBL_LOANENTRIES A, TBL_LOANPAYMENTHISTORY B", "where A.id = B.loanEntryID AND A.id = " + loanid + " AND B.CutoffID = '" + cutoffid + "'", out val1, out val2);
                    //if (val1 != "" && val2 != "")
                    //{
                    //    loan_name_amount.Add(val1, val2);
                    //}
                    string loancode = "", loanded = "", loanbal = "";
                    double dblloanded = 0, dblloanbal = 0;
                    cm.GetThreeDataFromDB("C.LoanID", "B.AmountPaid", "B.afterpaymentbal",
                        "TBL_LOANENTRIES A, TBL_LOANPAYMENTHISTORY B, TBL_LOANS C", 
                        "where A.id = B.loanEntryID AND A.LoanCode = C.id AND A.id = " + loanid + " AND B.CutoffID = '" + cutoffid + "'", out loancode, out loanded,out loanbal);
                    double.TryParse(loanded, out dblloanded);
                    double.TryParse(loanbal, out dblloanbal);
                    if (loancode == "SSS")
                    {
                        SSS += dblloanded;
                        SSSBal += dblloanbal;
                    }
                    else if (loancode == "PIL")
                    {
                        PIL += dblloanded;
                        PILBal += dblloanbal;
                    }
                    else if (loancode == "PICL")
                    {
                        PICL += dblloanded;
                        PICLBal += dblloanbal;
                    }
                    else if (loancode == "SSSCL")
                    {
                        SSSCL += dblloanded;
                        SSSCLBal += dblloanbal;
                    }
                    else if(loancode == "CA")
                    {
                        if (CAcounter == 1)
                        {
                            CA += dblloanded;
                            CABal += dblloanbal;
                        }
                        else if (CAcounter == 2)
                        {
                            CA2 += dblloanded;
                            CABal2 += dblloanbal;
                        }
                        else if (CAcounter == 3)
                        {
                            CA3 += dblloanded;
                            CABal3 += dblloanbal;
                        }
                        CAcounter++;
                    }



                }
                if (ps.bonus != "") bonus1 = pr.toRoundOff(true, ps.bonus);
                else bonus1 = "";
                string payrollgrpname = cm.GetSpecificDataFromDB("payrollgrpname", "TBL_PAYROLLGRP", "where id = " + ps.payrollgroup + "");
                finalhtml += string.Format(paysliphtmlNew(ps.empno, ps.allowance, pr.toRoundOff(true, CL.ToString()), 
                    pr.toRoundOff(true, CLBal.ToString()), pr.toRoundOff(true, SSS.ToString()), 
                    pr.toRoundOff(true, SSSBal.ToString()), pr.toRoundOff(true, PIL.ToString()), 
                    pr.toRoundOff(true, PILBal.ToString()), pr.toRoundOff(true, PICL.ToString()), 
                    pr.toRoundOff(true, PICLBal.ToString()), pr.toRoundOff(true, SSSCL.ToString()), 
                    pr.toRoundOff(true, SSSCLBal.ToString()), pr.toRoundOff(true, CA.ToString()), 
                    pr.toRoundOff(true, CABal.ToString()), pr.toRoundOff(true, CA2.ToString()), 
                    pr.toRoundOff(true, CABal2.ToString()), pr.toRoundOff(true, CA3.ToString()), 
                    pr.toRoundOff(true, CABal3.ToString())), 
                    ps.empno, ps.empname, ps.date_covered, payrollgrpname,
                    ps.department, pr.toRoundOff(true, ps.basicpay), pr.toRoundOff(true, ps.sss), ps.cash_adv, ps.loanbal, pr.toRoundOff(true, ps.absentded), pr.toRoundOff(true, ps.philhealth), pr.toRoundOff(true, ps.lates), pr.toRoundOff(true, ps.pagibig),
                    pr.toRoundOff(true, ps.totalgrossincome), pr.toRoundOff(true, ps.totaldeduction), pr.toRoundOff(true, ps.netpay), ps.remainingleavecredit, pr.toRoundOff(true, ps.leavepay), pr.toRoundOff(true, ps.utded), pr.toRoundOff(true, ps.otpay), pr.toRoundOff(true, ps.holidaypay)
                    , bonus1, pr.toRoundOff(true, ps.adjustment), pr.toRoundOff(true, ps.allowance), cm.RemoveSpecialCharactersForFileName(ps.adjustmentremarks), pr.toRoundOff(true, ps.wtax));
            }



            return finalhtml;

        }

        protected void Export(object sender, EventArgs e)
        {

        }
    }
}