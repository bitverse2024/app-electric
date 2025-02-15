﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Globalization;
using System.Data.SqlTypes;

namespace HRIS_APPELECTRIC.Pages.Admin.Employees
{
    public partial class EmployeeView : System.Web.UI.Page
    {
        Employee emp = new Employee();
        public string empno = "";
        public string civilstat = "", gender = "";
        Common cm = new Common();
        string getpermadd, getzip, getpresadd, getzip2, gettel, getcelno, getemail, getbdate, getbplace, getcstat, getgender;
        string getsss, gettin, getpagibig, getphilhealth, getdatestart, getdatesep, getbioid;
        string getwage, getbasic, getperday, getbasicall, gettaxotall, getntaxotall, getosall, getoall, getecola, getsssded,
            getloanded, getphilhealthded, getpagibigded, getaccttype, getbankcode, gettax,getcontri, getloan;
        string getMon, getTues, getWed, getThurs, getFri, getSat, getSun;
        Dictionary<string, string> empInfo = new Dictionary<string, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["ACTIVE_EMPNO"].ToString() == "")
                {
                    Session.Abandon();
                    Response.Redirect("~/Pages/Login.aspx");
                }
            }
            catch
            {
                Session.Abandon();
                Response.Redirect("~/Pages/Login.aspx");
            }
            empno = Request.QueryString["empid"];
            empInfo = emp.GetEmployeeInfoDict(Session["ACTIVE_EMPNO"].ToString());
            //TODO employee view/profile?
            try
            {
                if (Session["ACTIVE_EMPNO"].ToString() == "")
                {
                    Session.Abandon();
                    Response.Redirect("~/Pages/Login.aspx");
                }
                else if (empno != Session["ACTIVE_EMPNO"].ToString())
                {

                    empno = Session["ACTIVE_EMPNO"].ToString();
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                    "alert",
                    "alert('Injection not allowed!!!');window.location ='EmployeeView.aspx?empid=" + empno + "';",
                    true);
                }
                else
                {


                    if (!IsPostBack)
                    {
                        refresh();
                    }
                }

            }
            catch
            {
                Session.Abandon();
                Response.Redirect("~/Pages/Login.aspx");
            }



        }

        void refresh()
        {
            empInfo = emp.GetEmployeeInfoDict(empno);
            populateSchedDropdownMenu();
            populateUpdatePersonal();
            populateUpdatePersonnel();
            populateUpdatePayroll();
            populateEmpImage();

            lblFullName.Text = empInfo["emp_FullName"];
            lblPosition.Text = empInfo["PositionName"];
        }

        public string GetEmployeeData()
        {
            string[] info_arr = new string[20];
            info_arr = emp.GetEmployeeInfo(empno); ;

            string build_html = "";
            build_html += "<table class=\"detail-view table table-striped table-condensed\" id=\"yw1\"><tr class=\"odd\"><th><span class=h8>Employee No.</span></th><td><span class=h8>" + empno + "</span></td></tr>";
            build_html += "<tr class=\"even\"><th><span class=h8>Biometrics ID</span></th><td><span class=h8>" + info_arr[0] + "</span></td></tr>";
            build_html += "<tr class=\"odd\"><th><span class=h8>Last Name</span></th><td><span class=h8>" + info_arr[1] + "</span></td></tr>";
            build_html += "<tr class=\"even\"><th><span class=h8>First Name</span></th><td><span class=h8>" + info_arr[2] + "</span></td></tr>";
            build_html += "<tr class=\"odd\"><th><span class=h8>Middle Name</span></th><td><span class=h8>" + info_arr[3] + "</span></td></tr>";
            build_html += "<tr class=\"even\"><th><span class=h8>Full Name</span></th><td><span class=h8>" + info_arr[4] + "</span></td></tr>";
            build_html += "<tr class=\"odd\"><th><span class=h8>Birthdate</span></th><td><span class=h8>" + info_arr[5] + "</span></td></tr>";
            build_html += "<tr class=\"even\"><th><span class=h8>Gender</span></th><td><span class=h8>" + info_arr[6] + "</span></td></tr>";
            build_html += "<tr class=\"odd\"><th><span class=h8>Company</span></th><td><span class=h8>" + info_arr[7] + "</span></td></tr>";
            //build_html += "<tr class=\"even\"><th>Position</th><td>"+info_arr[8]+"</td></tr>";
            build_html += "<tr class=\"even\"><th><span class=h8>Position</span></th><td><span class=h8>" + emp.GetEmployeePositionName(empno) + "</span></td></tr>";
            build_html += "<tr class=\"odd\"><th><span class=h8>Rank</span></th><td><span class=h8>" + emp.GetEmployeeRnk(empno) + "</span></td></tr>";
            build_html += "<tr class=\"even\"><th><span class=h8>Status</span></th><td><span class=h8>" + emp.GetEmployeeStatus(empno) + "</span></td></tr>";
            //build_html += "<tr class=\"odd\"><th>Department</th><td>"+info_arr[11]+"</td></tr>";
            build_html += "<tr class=\"odd\"><th><span class=h8>Department</span></th><td><span class=h8>" + emp.GetEmployeeDeptName(empno) + "</span></td></tr>";
            build_html += "<tr class=\"even\"><th><span class=h8>1st Approver</span></th><td><span class=h8>" + emp.GetEmployeeApprover1(empno) + "</span></td></tr>";
            build_html += "<tr class=\"odd\"><th><span class=h8>2nd Approver</span></th><td><span class=h8>" + emp.GetEmployeeApprover2(empno) + "</span></td></tr>";
            build_html += "<tr class=\"even\"><th><span class=h8>SSS</span></th><td><span class=h8>" + info_arr[14] + "</span></td></tr>";
            build_html += "<tr class=\"odd\"><th><span class=h8>TIN</span></th><td><span class=h8>" + info_arr[15] + "</span></td></tr>";
            build_html += "<tr class=\"even\"><th><span class=h8>Pagibig MID No</span></th><td><span class=h8>" + info_arr[16] + "</span></td></tr>";
            build_html += "<tr class=\"odd\"><th><span class=h8>Phil Health No</span></th><td><span class=h8>" + info_arr[17] + "</span></td></tr>";
            build_html += "<tr class=\"even\"><th><span class=h8>Date Start</span></th><td><span class=h8>" + info_arr[18] + "</span></td></tr>";
            build_html += "<tr class=\"odd\"><th><span class=h8>Date Separated</span></th><td><span class=h8>" + info_arr[19] + "</span></td></tr></table>";

            return build_html;
        }
        public string GetPersonnel()
        {
            string build_html = "";

            build_html += "<table class=\"detail-view table table-striped table-condensed\" id=\"yw3\" ><tr class=\"odd\"><th><span class=h8>SSS</span></th><td><span class=h8>" + empInfo["emp_SSSNo"] + "</span></td></tr>";
            build_html += "<tr class=\"even\"><th><span class=h8>TIN</span></th><td><span class=h8>" + empInfo["emp_TIN"] + "</span></td></tr>";
            build_html += "<tr class=\"odd\"><th><span class=h8>Pagibig MID No</span></th><td><span class=h8>" + empInfo["emp_PagibigNo"] + "</span></td></tr>";
            build_html += "<tr class=\"even\"><th><span class=h8>Phil Health No</span></th><td><span class=h8>" + empInfo["PhilHealth_No"] + "</span></td></tr>";
            build_html += "<tr class=\"odd\"><th><span class=h8>Phil Health No</span></th><td><span class=h8>" + empInfo["PhilHealth_No"] + "</span></td></tr>";
            build_html += "<tr class=\"even\"><th><span class=h8>Date Start</span></th><td><span class=h8>" + cm.FormatDate(empInfo["emp_DateStart"]) + "</span></td></tr>";
            build_html += "<tr class=\"odd\"><th><span class=h8>Date Separated</span></th><td><span class=h8>" + cm.FormatDate(empInfo["emp_DateSeparated"]) + "</span></td></tr>";
            build_html += "<tr class=\"even\"><th><span class=h8>Biometrics ID</span></th><td><span class=h8>" + empInfo["emp_BiometricsID"] + "</span></td></tr></table>";

            return build_html;
        }

        #region addPersonnelLogs
        private void getupdPersonnel()
        {
            getsss = empInfo["emp_SSSNo"];
            gettin = empInfo["emp_TIN"];
            getpagibig = empInfo["emp_PagibigNo"];
            getphilhealth = empInfo["PhilHealth_No"];
            getdatestart = cm.FormatDate(empInfo["emp_DateStart"]);
            getdatesep = cm.FormatDate(empInfo["emp_DateSeparated"]);
            getbioid = empInfo["emp_BiometricsID"];
        }

        private void addPersonnelLogs()
        {
            if (getsss != emp_SSSNo.Text)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Personnel:SSS No. for " + empInfo["emp_FullName"] +
                    " from " + getsss + " to " + emp_SSSNo.Text, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (gettin != emp_TIN.Text)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Personnel:TIN for " + empInfo["emp_FullName"] +
                    " from " + gettin + " to " + emp_TIN.Text, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getpagibig != emp_PagibigNo.Text)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Personnel:PAG-IBIG No. for " + empInfo["emp_FullName"] +
                    " from " + getpagibig + " to " + emp_PagibigNo.Text, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getphilhealth != PhilHealth_No.Text)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Personnel:PHILHEALTH No. for " + empInfo["emp_FullName"] +
                    " from " + getphilhealth + " to " + PhilHealth_No.Text, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getdatestart != emp_DateStart.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Personnel:START DATE for " + empInfo["emp_FullName"] +
                    " from " + getdatestart + " to " + emp_DateStart.Value, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getdatesep != emp_DateSeparated.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Personnel:DATE SEPARATED for " + empInfo["emp_FullName"] +
                    " from " + getdatesep + " to " + emp_DateSeparated.Value, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getbioid != emp_BiometricsID.Text)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Personnel:BIOMETRICS ID for " + empInfo["emp_FullName"] +
                    " from " + getbioid + " to " + emp_BiometricsID.Text, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
        }
        #endregion

        public string GetPersonal()
        {
            civilstat = empInfo["emp_CivilStatus"];
            gender = empInfo["emp_Gender"];
            if (civilstat == "M")
            {
                civilstat = "Married";
            }
            if (civilstat == "S")
            {
                civilstat = "Single";
            }
            if (civilstat == "")
            {
                civilstat = "Not Set";
            }
            if (gender == "M")
            {
                gender = "Male";
            }
            if (gender == "F")
            {
                gender = "Female";
            }
            if (gender == "")
            {
                gender = "Not Set";
            }
            string build_html = "";
            build_html += "<table class=\"detail-view table table-striped table-condensed\" id=\"yw2\"><tr class=\"odd\"><th><span class=h8>Permanent Address</span></th><td><span class=h8>" + empInfo["emp_PermanentAddress"] + "</span></td></tr>";
            build_html += "<tr class=\"even\"><th><span class=h8>Zip Code/Lot</th><td><span class=h8>" + empInfo["emp_PermanentZipCode"] + "</span></td></tr>";
            build_html += "<tr class=\"odd\"><th><span class=h8>Present Address</th><td><span class=h8>" + empInfo["emp_PresentAddress"] + "</span></td></tr>";
            build_html += "<tr class=\"even\"><th><span class=h8>Zip Code</th><td><span class=h8>" + empInfo["emp_PresentZipCode"] + "</span></td></tr>";
            build_html += "<tr class=\"odd\"><th><span class=h8>Home Tel No</th><td><span class=h8>" + empInfo["emp_HomeTelNo"] + "</span></td></tr>";
            build_html += "<tr class=\"even\"><th><span class=h8>Cellphone No</th><td><span class=h8>" + empInfo["emp_CellPhoneNo"] + "</span></td></tr>";
            build_html += "<tr class=\"even\"><th><span class=h8>Email</th><td><span class=h8>" + empInfo["emp_Email"] + "</span></td></tr>";
            build_html += "<tr class=\"odd\"><th><span class=h8>Birthdate</th><td><span class=h8>" + cm.FormatDate(empInfo["emp_Birthdate"]) + "</span></td></tr>";
            build_html += "<tr class=\"even\"><th><span class=h8>Birth Place</th><td><span class=h8>" + empInfo["emp_Birthplace"] + "</span></td></tr>";
            build_html += "<tr class=\"odd\"><th><span class=h8>Civil Status</th><td><span class=h8>" + civilstat + "</span></td></tr>";
            //build_html += "<tr class=\"odd\"><th><span class=h8>Civil Status</span></th><td><select id=\"emp_CivilStat\" runat=\"server\"><option value=\"0\">Select Civil Status</option></select></td></tr>";
            build_html += "<tr class=\"even\"><th><span class=h8>Gender</th><td><span class=h8>" + gender + "</span></td></tr></table>";

            return build_html;
        }

        #region personallogs
        private void getupdPersonal()
        {
            getpermadd = empInfo["emp_PermanentAddress"];
            getzip = empInfo["emp_PermanentZipCode"];
            getpresadd = empInfo["emp_PresentAddress"];
            getzip2 = empInfo["emp_PresentZipCode"];
            gettel = empInfo["emp_HomeTelNo"];
            getcelno = empInfo["emp_CellPhoneNo"];
            getemail = empInfo["emp_Email"];
            getbdate = cm.FormatDate(empInfo["emp_Birthdate"]);
            getbplace = empInfo["emp_Birthplace"];
            getcstat = empInfo["emp_CivilStatus"];
            getgender = empInfo["emp_Gender"];
        }

        private void addPersonalLogs()
        {
            if (getpermadd != emp_PermanentAddress.Text)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Personal:PERMANENT ADDRESS for " + empInfo["emp_FullName"] +
                    " from " + getpermadd + " to " + emp_PermanentAddress.Text, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getzip != emp_PermanentZipCode.Text)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Personal:PERMANENT ADDRESS ZIP for " + empInfo["emp_FullName"] +
                    " from " + getzip + " to " + emp_PermanentZipCode.Text, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getpresadd != emp_PresentZipCode.Text)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Personal:PRESENT ADDRESS for " + empInfo["emp_FullName"] +
                    " from " + getpresadd + " to " + emp_PresentZipCode.Text, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getzip2 != emp_PresentZipCode.Text)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Personal:PRESENT ADDRESS ZIP for " + empInfo["emp_FullName"] +
                    " from " + getzip2 + " to " + emp_PresentZipCode.Text, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (gettel != emp_HomeTelNo.Text)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Personal:HOME TEL. NO. for " + empInfo["emp_FullName"] +
                    " from " + gettel + " to " + emp_HomeTelNo.Text, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getcelno != emp_CellPhoneNo.Text)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Personal:CELLPHONE NO. for " + empInfo["emp_FullName"] +
                    " from " + getcelno + " to " + emp_CellPhoneNo.Text, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getemail != emp_Email.Text)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Personal:EMAIL for " + empInfo["emp_FullName"] +
                    " from " + getemail + " to " + emp_Email.Text, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getbdate != emp_Birthdate.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Personal:BIRTHDATE for " + empInfo["emp_FullName"] +
                    " from " + getbdate + " to " + emp_Birthdate.Value, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getbplace != emp_Birthplace.Text)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Personal:BIRTHPLACE for " + empInfo["emp_FullName"] +
                    " from " + getbplace + " to " + emp_Birthplace.Text, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getcstat != emp_CivilStatus.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Personal:CIVIL STATUS for " + empInfo["emp_FullName"] +
                    " from " + getcstat + " to " + emp_CivilStatus.Value, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getgender != emp_Gender.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Personal:GENDER for " + empInfo["emp_FullName"] +
                    " from " + getgender + " to " + emp_Gender.Value, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
        }
        #endregion

        public string GetPayroll()
        {
            string build_html = "";

            //build_html += "<table class=\"detail-view table table-striped table-condensed\" id=\"yw3\"><tr class=\"odd\"><th>Wage Type</th><td>" + empInfo["emp_WageType"] + "</td></tr>";
            //build_html += "<table class=\"detail-view table table-striped table-condensed\" id=\"yw2\"><tr class=\"odd\"><th><span class=\"h8\">Wage Type</span></th><td><span class=h8>" + empInfo["emp_WageType"] + "</span></td></tr>";
            build_html += "<table class=\"detail-view table table-striped table-condensed\" id=\"yw2\"><tr class=\"odd\"><th><span class=\"h8\">Basic Pay</span></th><td><span class=h8>" + empInfo["emp_BasicPay"] + "</span></td></tr>";
            //build_html += "<tr class=\"even\"><th><span class=h8>Basic Pay</span></th><td><span class=h8>" + empInfo["emp_BasicPay"] + "</span></td></tr>";
            //build_html += "<tr class=\"odd\"><th><span class=h8>Per Day</span></th><td><span class=h8>" + empInfo["emp_PerDay"] + "</span></td></tr>";
            //build_html += "<tr class=\"even\"><th><span class=h8>Basic Allowance</span></th><td><span class=h8>" + empInfo["emp_BasicAllowance"] + "</span></td></tr>";
            ////build_html += "<tr class=\"odd\"><th>Taxable OT Allowance</th><td>" + cm.FormatDate(empInfo["emp_TaxableOTAllowance"]) + "</td></tr>";
            //build_html += "<tr class=\"odd\"><th><span class=h8>Taxable OT Allowance</span></th><td><span class=h8>" + empInfo["emp_TaxableOTAllowance"] + "</span></td></tr>";
            //build_html += "<tr class=\"even\"><th><span class=h8>Non-Taxable OT Allowance</span></th><td><span class=h8>" + empInfo["emp_NonTaxableOTAllowance"] + "</span></td></tr>";
            //build_html += "<tr class=\"odd\"><th><span class=h8>Out of Station Allowance</span></th><td><span class=h8>" + empInfo["emp_OutOfStationAllowance"] + "</span></td></tr>";

            //build_html += "<tr class=\"even\"><th><span class=h8>Other Allowance</span></th><td><span class=h8>" + empInfo["emp_OtherAllowance"] + "</span></td></tr>";
            //build_html += "<tr class=\"odd\"><th><span class=h8>ECOLA</span></th><td><span class=h8>" + empInfo["emp_ECOLA"] + "</span></td></tr>";
            build_html += "<tr class=\"even\"><th><span class=h8>SSS Deduction</span></th><td><span class=h8>" + empInfo["emp_SSSDed"] + "</span></td></tr>";
            //build_html += "<tr class=\"odd\"><th><span class=h8>Loan Deduction</span></th><td><span class=h8>" + empInfo["emp_LoanDed"] + "</span></td></tr>";
            //build_html += "<tr class=\"odd\"><th>Philhealth Deduction</th><td>" + cm.FormatDate(empInfo["emp_PhilHealthDed"]) + "</td></tr>";
            build_html += "<tr class=\"even\"><th><span class=h8>Philhealth Deduction</span></th><td><span class=h8>" + empInfo["emp_PhilHealthDed"] + "</span></td></tr>";
            build_html += "<tr class=\"odd\"><th><span class=h8>Pagibig Deduction</span></th><td><span class=h8>" + empInfo["emp_PagibigDed"] + "</span></td></tr>";
            build_html += "<tr class=\"even\"><th><span class=h8>Tax</span></th><td><span class=h8>" + empInfo["emp_YTD_WTax"] + "</span></td></tr>";
            //build_html += "<tr class=\"even\"><th><span class=h8>Acct Type</span></th><td><span class=h8>" + empInfo["emp_AcctType"] + "</span></td></tr>";
            //build_html += "<tr class=\"odd\"><th><span class=h8>Bank Code</span></th><td><span class=h8>" + empInfo["emp_BankCode"] + "</span></td></tr></table>";

            //09/06/2022 Jan. add view for emp_isEnableContriDed and emp_isEnableLoanDed
            string emp_isEnableContriDed = empInfo["emp_isEnableContriDed"] == "True" ? "Enabled" : "Disabled";
            string emp_isEnableLoanDed = empInfo["emp_isEnableLoanDed"] == "True" ? "Enabled" : "Disabled";
            build_html += "<tr class=\"odd\"><th><span class=h8>Contribution</span></th><td><span class=h8>" + emp_isEnableContriDed + "</span></td></tr>";
            build_html += "<tr class=\"even\"><th><span class=h8>Loan</span></th><td><span class=h8>" + emp_isEnableLoanDed + "</span></td></tr></table>";
            return build_html;
        }

        #region ParyrollLogs
        private void getupdPayroll()
        {
            getwage = empInfo["emp_WageType"];
            getbasic = empInfo["emp_BasicPay"];
            getperday = empInfo["emp_PerDay"];
            getbasicall = empInfo["emp_BasicAllowance"];
            gettaxotall = empInfo["emp_TaxableOTAllowance"];
            getntaxotall = empInfo["emp_NonTaxableOTAllowance"];
            getosall = empInfo["emp_OutOfStationAllowance"];
            getoall = empInfo["emp_OtherAllowance"];
            getecola = empInfo["emp_ECOLA"];
            getsssded = empInfo["emp_SSSDed"];
            getloanded = empInfo["emp_LoanDed"];
            getphilhealthded = empInfo["emp_PhilHealthDed"];
            getpagibigded = empInfo["emp_PagibigDed"];
            getaccttype = empInfo["emp_AcctType"];
            getbankcode = empInfo["emp_BankCode"];
            gettax = empInfo["emp_YTD_WTax"];
            getcontri = empInfo["emp_isEnableContriDed"];
            getloan = empInfo["emp_isEnableLoanDed"];
        }

        private void addPayrollLogs()
        {
            //if (getwage != emp_WageType.Text)
            //{
            //    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Payroll:WAGE TYPE for " + empInfo["emp_FullName"] +
            //        " from " + getwage + " to " + emp_WageType.Text, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            //}
            if (getbasic != emp_BasicPay.Text)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Payroll:BASIC PAY for " + empInfo["emp_FullName"] +
                    " from " + getbasic + " to " + emp_BasicPay.Text, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            //if (getperday != emp_PerDay.Text)
            //{
            //    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Payroll:PER DAY for " + empInfo["emp_FullName"] +
            //        " from " + getperday + " to " + emp_PerDay.Text, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            //}
            //if (getbasicall != emp_WageType.Text)
            //{
            //    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Payroll:BASIC ALLOWANCE for " + empInfo["emp_FullName"] +
            //        " from " + getbasicall + " to " + emp_BasicAllowance.Text, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            //}
            //if (gettaxotall != emp_TaxableOTAllowance.Text)
            //{
            //    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Payroll:TAXABLE OT ALLOWANCE for " + empInfo["emp_FullName"] +
            //        " from " + gettaxotall + " to " + emp_TaxableOTAllowance.Text, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            //}
            //if (getntaxotall != emp_NonTaxableOTAllowance.Text)
            //{
            //    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Payroll:NON-TAXABLE ALLOWANCE for " + empInfo["emp_FullName"] +
            //        " from " + getntaxotall + " to " + emp_NonTaxableOTAllowance.Text, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            //}
            //if (getosall != emp_OutOfStationAllowance.Text)
            //{
            //    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Payroll:OUT OF STATION ALLOWANCE for " + empInfo["emp_FullName"] +
            //        " from " + getosall + " to " + emp_OutOfStationAllowance.Text, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            //}
            //if (getoall != emp_OtherAllowance.Text)
            //{
            //    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Payroll:OTHER ALLOWANCE for " + empInfo["emp_FullName"] +
            //        " from " + getoall + " to " + emp_OtherAllowance.Text, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            //}
            //if (getecola != emp_ECOLA.Text)
            //{
            //    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Payroll:ECOLA for " + empInfo["emp_FullName"] +
            //        " from " + getecola + " to " + emp_ECOLA.Text, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            //}
            if (getsssded != emp_SSSDed.Text)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Payroll:SSS DEDUCTION for " + empInfo["emp_FullName"] +
                    " from " + getsssded + " to " + emp_SSSDed.Text, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            //if (getloanded != emp_LoanDed.Text)
            //{
            //    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Payroll:LOAN DEDUCTION for " + empInfo["emp_FullName"] +
            //        " from " + getloanded + " to " + emp_LoanDed.Text, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            //}
            if (getphilhealthded != emp_PhilHealthDed.Text)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Payroll:PHILHEALTH DEDUCTION for " + empInfo["emp_FullName"] +
                    " from " + getphilhealthded + " to " + emp_PhilHealthDed.Text, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getpagibigded != emp_PagibigDed.Text)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Payroll:PAG-IBIG DEDUCTION for " + empInfo["emp_FullName"] +
                    " from " + getpagibigded + " to " + emp_PagibigDed.Text, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            //if (getaccttype != emp_AcctType.Text)
            //{
            //    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Payroll:ACCOUNT TYPE for " + empInfo["emp_FullName"] +
            //        " from " + getaccttype + " to " + emp_AcctType.Text, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            //}
            //if (getbankcode != emp_BankCode.Text)
            //{
            //    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Payroll:BANK CODE for " + empInfo["emp_FullName"] +
            //        " from " + getbankcode + " to " + emp_BankCode.Text, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            //}
            if (gettax != emp_YTD_WTax.Text)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Payroll:Tax for " + empInfo["emp_FullName"] +
                    " from " + gettax + " to " + emp_YTD_WTax.Text, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getcontri != (emp_isEnableContriDed.Checked == true ? "True" : "False"))
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Payroll:Contribution for " + empInfo["emp_FullName"] +
                    " from " + getcontri + " to " + (emp_isEnableContriDed.Checked == true ? "True" : "False"), "CHANGED", "x123", "qwg-23", "CHANGED", Session["EMP_ID"].ToString());
            }
            if (getloan != (emp_isEnableLoanDed.Checked == true ? "True" : "False"))
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Payroll:Loan for " + empInfo["emp_FullName"] +
                    " from " + getloan + " to " + (emp_isEnableLoanDed.Checked == true ? "True" : "False"), "CHANGED", "x123", "qwg-23", "CHANGED", Session["EMP_ID"].ToString());
            }
        }
        #endregion

        public string GetUpdatePayroll()
        {
            string build_html = "";

            build_html += "<table class=\"detail-view table table-striped table-condensed\" id=\"yw4\">";
            build_html += "<tr class=\"odd\"><th>Wage Type</th><td><asp:TextBox ID=\"TextBox1\"></asp:TextBox></td></tr>";
            build_html += "<tr class=\"even\"><th>Basic Pay</th><td><asp:TextBox ID=\"TextBox2\" runat=\"server\"></asp:TextBox></td></tr>";
            build_html += "<tr class=\"odd\"><th>Per Day</th><td><asp:TextBox ID=\"TextBox3\" runat=\"server\"></asp:TextBox></td></tr>";
            build_html += "<tr class=\"even\"><th>Basic Allowance</th><td><asp:TextBox ID=\"TextBox4\" runat=\"server\"></asp:TextBox></td></tr>";
            build_html += "<tr class=\"odd\"><th>Taxable OT Allowance</th><td><asp:TextBox ID=\"TextBox5\" runat=\"server\"></asp:TextBox></td></tr>";
            build_html += "<tr class=\"even\"><th>None Taxable OT Allowance</th><td><asp:TextBox ID=\"TextBox6\" runat=\"server\"></asp:TextBox></td></tr>";
            build_html += "<tr class=\"odd\"><th>Out of Station Allowance</th><td><asp:TextBox ID=\"TextBox7\" runat=\"server\"></asp:TextBox></td></tr>";
            build_html += "<tr class=\"even\"><th>Other Allowance</th><td><asp:TextBox ID=\"TextBox8\" runat=\"server\"></asp:TextBox></td></tr>";
            build_html += "<tr class=\"odd\"><th>ECOLA</th><td><asp:TextBox ID=\"TextBox9\" runat=\"server\"></asp:TextBox></td></tr>";
            build_html += "<tr class=\"even\"><th>SSS Deduction</th><td><asp:TextBox ID=\"TextBox10\" runat=\"server\"></asp:TextBox></td></tr>";
            build_html += "<tr class=\"odd\"><th>Loan Deduction</th><td><asp:TextBox ID=\"TextBox11\" runat=\"server\"></asp:TextBox></td></tr>";
            build_html += "<tr class=\"even\"><th>Philhealth Deduction</th><td><asp:TextBox ID=\"TextBox12\" runat=\"server\"></asp:TextBox></td></tr>";
            build_html += "<tr class=\"odd\"><th>Pagibig Deduction</th><td><asp:TextBox ID=\"TextBox13\" runat=\"server\"></asp:TextBox></td></tr>";
            build_html += "<tr class=\"even\"><th>Acct Type</th><td><asp:TextBox ID=\"TextBox14\" runat=\"server\"></asp:TextBox></td></tr>";
            build_html += "<tr class=\"odd\"><th>Bank Code</th><td><asp:TextBox ID=\"TextBox15\" runat=\"server\"></asp:TextBox></td></tr></table>";

            return build_html;
        }
        public string GetSchedule()
        {
            string build_html = "";
            build_html += "<table class=\"detail-view table table-striped table-condensed\" id=\"yw4\"><tr class=\"odd\"><th><span class=h8>Monday</span></th><td><span class=h8>" + emp.GetScheduleShiftName(empInfo["emp_Monday"]) + "</span></td></tr>";
            build_html += "<tr class=\"even\"><th><span class=h8>Tuesday</span></th><td><span class=h8>" + emp.GetScheduleShiftName(empInfo["emp_Tuesday"]) + "</span></td></tr>";
            build_html += "<tr class=\"odd\"><th><span class=h8>Wednesday</span></th><td><span class=h8>" + emp.GetScheduleShiftName(empInfo["emp_Wednesday"]) + "</span></td></tr>";
            build_html += "<tr class=\"even\"><th><span class=h8>Thursday</span></th><td><span class=h8>" + emp.GetScheduleShiftName(empInfo["emp_Thursday"]) + "</span></td></tr>";
            build_html += "<tr class=\"odd\"><th><span class=h8>Friday</span></th><td><span class=h8>" + emp.GetScheduleShiftName(empInfo["emp_Friday"]) + "</span></td></tr>";
            build_html += "<tr class=\"even\"><th><span class=h8>Saturday</span></th><td><span class=h8>" + emp.GetScheduleShiftName(empInfo["emp_Saturday"]) + "</span></td></tr>";
            build_html += "<tr class=\"odd\"><th><span class=h8>Sunday</span></th><td><span class=h8>" + emp.GetScheduleShiftName(empInfo["emp_Sunday"]) + "</span></td></tr></table>";

            return build_html;
        }

        #region addScheduleLogs
        private void getupdSchedule()
        {
            getMon = empInfo["emp_Monday"];
            getTues = empInfo["emp_Tuesday"];
            getWed = empInfo["emp_Wednesday"];
            getThurs = empInfo["emp_Thursday"];
            getFri = empInfo["emp_Friday"];
            getSat = empInfo["emp_Saturday"];
            getSun = empInfo["emp_Sunday"];
        }

        private void addScheduleLogs()
        {
            if (getMon != emp_Monday.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Schedule:MONDAY for " + empInfo["emp_FullName"] +
                    " from " + getMon + " to " + emp_Monday.Value, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getTues != emp_Tuesday.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Schedule:TUESDAY for " + empInfo["emp_FullName"] +
                    " from " + getTues + " to " + emp_Tuesday.Value, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getWed != emp_Wednesday.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Schedule:WEDNESDAY for " + empInfo["emp_FullName"] +
                    " from " + getWed + " to " + emp_Wednesday.Value, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getThurs != emp_Thursday.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Schedule:THURSDAY for " + empInfo["emp_FullName"] +
                    " from " + getThurs + " to " + emp_Thursday.Value, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getFri != emp_Friday.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Schedule:FRIDAY for " + empInfo["emp_FullName"] +
                    " from " + getFri + " to " + emp_Friday.Value, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getSat != emp_Saturday.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Schedule:SATURDAY for " + empInfo["emp_FullName"] +
                    " from " + getSat + " to " + emp_Saturday.Value, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getSun != emp_Sunday.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Schedule:SUNDAY for " + empInfo["emp_FullName"] +
                    " from " + getSun + " to " + emp_Sunday.Value, "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
        }
        #endregion

        public void populateEmpImage()
        {
            string imageURL = "/../../../images/1.jpg";
            if (empInfo["emp_Gender"] == "F")
                imageURL = "~/Pages/Admin/Employee/images/49.jpg";

            if (empInfo["emp_Image"] != null && empInfo["emp_Image"] != "")
            {
                imageURL = "~/201Files/" + "EmployeeImage/" + empInfo["emp_Image"];

            }

            imageEmp.ImageUrl = imageURL;
            userimg.ImageUrl = imageURL;
        }


        public void populateUpdatePersonal()
        {
            emp_PermanentAddress.Text = empInfo[emp_PermanentAddress.ID];
            emp_PermanentZipCode.Text = empInfo[emp_PermanentZipCode.ID];
            emp_PresentAddress.Text = empInfo[emp_PresentAddress.ID];
            emp_PresentZipCode.Text = empInfo[emp_PresentZipCode.ID];
            emp_HomeTelNo.Text = empInfo[emp_HomeTelNo.ID];
            emp_CellPhoneNo.Text = empInfo[emp_CellPhoneNo.ID];
            emp_Email.Text = empInfo[emp_Email.ID];
            emp_Birthdate.Value = cm.FormatDateyyyy(empInfo[emp_Birthdate.ID]);
            emp_Birthplace.Text = empInfo[emp_Birthplace.ID];
            //emp_CivilStatus.Text = empInfo[emp_CivilStatus.ID];
            emp_Gender.Value = empInfo[emp_Gender.ID];
            emp_CivilStatus.Value = empInfo[emp_CivilStatus.ID];

        }
        public void populateUpdatePersonnel()
        {
            emp_SSSNo.Text = empInfo[emp_SSSNo.ID];
            emp_TIN.Text = empInfo[emp_TIN.ID];
            emp_PagibigNo.Text = empInfo[emp_PagibigNo.ID];
            PhilHealth_No.Text = empInfo[PhilHealth_No.ID];
            emp_DateStart.Value = cm.FormatDateyyyy(empInfo[emp_DateStart.ID]);
            emp_DateSeparated.Value = cm.FormatDateyyyy(empInfo[emp_DateSeparated.ID]);
            emp_BiometricsID.Text = empInfo[emp_BiometricsID.ID];
            emp_NationalIDNo.Text = empInfo[emp_NationalIDNo.ID];

        }

        public void populateUpdatePayroll()
        {
            //emp_WageType.Text = empInfo[emp_WageType.ID];
            emp_BasicPay.Text = empInfo[emp_BasicPay.ID];
            //emp_PerDay.Text = empInfo[emp_PerDay.ID];
            //emp_BasicAllowance.Text = empInfo[emp_BasicAllowance.ID];
            //emp_TaxableOTAllowance.Text = empInfo[emp_TaxableOTAllowance.ID];

            //emp_NonTaxableOTAllowance.Text = empInfo[emp_NonTaxableOTAllowance.ID];
            //emp_OutOfStationAllowance.Text = empInfo[emp_OutOfStationAllowance.ID];
            //emp_OtherAllowance.Text = empInfo[emp_OtherAllowance.ID];
            //emp_ECOLA.Text = empInfo[emp_ECOLA.ID];
            emp_SSSDed.Text = empInfo[emp_SSSDed.ID];

            //emp_LoanDed.Text = empInfo[emp_LoanDed.ID];
            emp_PhilHealthDed.Text = empInfo[emp_PhilHealthDed.ID];
            emp_PagibigDed.Text = empInfo[emp_PagibigDed.ID];
            //emp_AcctType.Text = empInfo[emp_AcctType.ID];
            //emp_BankCode.Text = empInfo[emp_BankCode.ID];
            emp_YTD_WTax.Text = empInfo[emp_YTD_WTax.ID];
            emp_isEnableContriDed.Checked = empInfo["emp_isEnableContriDed"] == "True" ? true : false;
            emp_isEnableLoanDed.Checked = empInfo["emp_isEnableLoanDed"] == "True" ? true : false;



        }

        public void populateSchedDropdownMenu()
        {
            emp_Monday.Items.AddRange(emp.GetDropDownMenuList("TBL_SCHEDULE", "ShiftName"));
            emp_Tuesday.Items.AddRange(emp.GetDropDownMenuList("TBL_SCHEDULE", "ShiftName"));
            emp_Wednesday.Items.AddRange(emp.GetDropDownMenuList("TBL_SCHEDULE", "ShiftName"));
            emp_Thursday.Items.AddRange(emp.GetDropDownMenuList("TBL_SCHEDULE", "ShiftName"));
            emp_Friday.Items.AddRange(emp.GetDropDownMenuList("TBL_SCHEDULE", "ShiftName"));
            emp_Saturday.Items.AddRange(emp.GetDropDownMenuList("TBL_SCHEDULE", "ShiftName"));
            emp_Sunday.Items.AddRange(emp.GetDropDownMenuList("TBL_SCHEDULE", "ShiftName"));
            setSchedDropdownMenu();
        }
        public void setSchedDropdownMenu()
        {


            emp_Monday.Value = empInfo["emp_Monday"];

            emp_Tuesday.Value = empInfo["emp_Tuesday"];

            emp_Wednesday.Value = empInfo["emp_Wednesday"];

            emp_Thursday.Value = empInfo["emp_Thursday"];

            emp_Friday.Value = empInfo["emp_Friday"];

            emp_Saturday.Value = empInfo["emp_Saturday"];

            emp_Sunday.Value = empInfo["emp_Sunday"];


        }

        Dictionary<string, string> saveUpdateSchedParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add(emp_Monday.ID, "" + emp_Monday.Value + "");
            param.Add(emp_Tuesday.ID, "" + emp_Tuesday.Value + "");
            param.Add(emp_Wednesday.ID, "" + emp_Wednesday.Value + "");
            param.Add(emp_Thursday.ID, "" + emp_Thursday.Value + "");
            param.Add(emp_Friday.ID, "" + emp_Friday.Value + "");
            param.Add(emp_Saturday.ID, "" + emp_Saturday.Value + "");
            param.Add(emp_Sunday.ID, "" + emp_Sunday.Value + "");



            return param;


        }
        Dictionary<string, string> saveUpdatePersonalParam()
        {
            var formats = new string[] { "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd" };
            DateTime bdate;
            Dictionary<string, string> param = new Dictionary<string, string>();
            if (emp_Birthdate.Value != "")
            {
                bdate = DateTime.ParseExact(emp_Birthdate.Value, formats, CultureInfo.CurrentCulture, DateTimeStyles.None);
                param.Add(emp_Birthdate.ID, "'" + cm.FormatDate(bdate.ToString()) + "'");
            }
            else
            {
                param.Add(emp_Birthdate.ID, SqlDateTime.Null.ToString());
            }
            param.Add(emp_PermanentAddress.ID, "'" + emp_PermanentAddress.Text + "'");
            param.Add(emp_PermanentZipCode.ID, "'" + emp_PermanentZipCode.Text + "'");
            param.Add(emp_PresentAddress.ID, "'" + emp_PresentAddress.Text + "'");
            param.Add(emp_PresentZipCode.ID, "'" + emp_PresentZipCode.Text + "'");
            param.Add(emp_HomeTelNo.ID, "'" + emp_HomeTelNo.Text + "'");
            param.Add(emp_CellPhoneNo.ID, "'" + emp_CellPhoneNo.Text + "'");
            param.Add(emp_Email.ID, "'" + emp_Email.Text + "'");
            param.Add(emp_Birthplace.ID, "'" + emp_Birthplace.Text + "'");
            param.Add(emp_CivilStatus.ID, "'" + emp_CivilStatus.Value + "'");
            param.Add(emp_Gender.ID, "'" + emp_Gender.Value + "'");
            return param;
        }
        Dictionary<string, string> saveUpdatePersonnelParam()
        {
            var formats = new string[] { "MM-dd-yyyy", "MM/dd/yyyy", "yyyy-MM-dd" };
            DateTime dtseparated;
            DateTime dtstart;
            Dictionary<string, string> param = new Dictionary<string, string>();
            if (emp_DateStart.Value != "")
            {
                dtstart = DateTime.ParseExact(emp_DateStart.Value, formats, CultureInfo.CurrentCulture, DateTimeStyles.None);
                param.Add(emp_DateStart.ID, "'" + cm.FormatDate(dtstart.ToString()) + "'");
            }
            else
            {
                param.Add(emp_DateStart.ID, SqlDateTime.Null.ToString());
            }
            if (emp_DateSeparated.Value != "")
            {
                dtseparated = DateTime.ParseExact(emp_DateSeparated.Value, formats, CultureInfo.CurrentCulture, DateTimeStyles.None);
                param.Add(emp_DateSeparated.ID, "'" + cm.FormatDate(dtseparated.ToString()) + "'");
            }
            else
            {
                param.Add(emp_DateSeparated.ID, SqlDateTime.Null.ToString());
            }

            param.Add(emp_SSSNo.ID, "'" + emp_SSSNo.Text + "'");
            param.Add(emp_TIN.ID, "'" + emp_TIN.Text + "'");
            param.Add(emp_PagibigNo.ID, "'" + emp_PagibigNo.Text + "'");
            param.Add(PhilHealth_No.ID, "'" + PhilHealth_No.Text + "'");
            param.Add(emp_BiometricsID.ID, "'" + emp_BiometricsID.Text + "'");

            return param;
        }

        Dictionary<string, string> saveUpdatePayrollParam()
        {

            Dictionary<string, string> param = new Dictionary<string, string>();
            //param.Add(emp_WageType.ID, "'" + emp_WageType.Text + "'");
            param.Add(emp_BasicPay.ID, "" + emp_BasicPay.Text + "");
            //param.Add(emp_PerDay.ID, "" + emp_PerDay.Text + "");
            //param.Add(emp_BasicAllowance.ID, "" + emp_BasicAllowance.Text + "");
            //param.Add(emp_TaxableOTAllowance.ID, "" + emp_TaxableOTAllowance.Text + "");
            //param.Add(emp_NonTaxableOTAllowance.ID, "" + emp_NonTaxableOTAllowance.Text + "");
            //param.Add(emp_OutOfStationAllowance.ID, "" + emp_OutOfStationAllowance.Text + "");
            //param.Add(emp_OtherAllowance.ID, "" + emp_OtherAllowance.Text + "");
            //param.Add(emp_ECOLA.ID, "" + emp_ECOLA.Text + "");
            param.Add(emp_SSSDed.ID, "" + emp_SSSDed.Text + "");
            //param.Add(emp_LoanDed.ID, "" + emp_LoanDed.Text + "");
            param.Add(emp_PhilHealthDed.ID, "" + emp_PhilHealthDed.Text + "");
            param.Add(emp_PagibigDed.ID, "" + emp_PagibigDed.Text + "");
            //param.Add(emp_AcctType.ID, "'" + emp_AcctType.Text + "'");
            //param.Add(emp_BankCode.ID, "'" + emp_BankCode.Text + "'");
            param.Add(emp_YTD_WTax.ID, "" +( emp_YTD_WTax.Text == "" ? "0" : emp_YTD_WTax.Text) + "");
            param.Add("emp_isEnableContriDed", emp_isEnableContriDed.Checked == true ? 1.ToString() : 0.ToString());
            param.Add("emp_isEnableLoanDed", emp_isEnableLoanDed.Checked == true ? 1.ToString() : 0.ToString());

            return param;
        }

        protected void btnUpdateSched_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                getupdSchedule();
                if (emp.UpdateQueryCommon(saveUpdateSchedParam(), "emp_EmpID = '" + empno + "'"))
                {
                    addScheduleLogs();
                    empInfo = emp.GetEmployeeInfoDict(empno);
                    setSchedDropdownMenu();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Updated !!!');", true);
                }
            }
        }
        protected void btnUpdatePersonal_Click(object sender, EventArgs e)
        {

            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                getupdPersonal();
                if (emp.UpdateQueryCommon(saveUpdatePersonalParam(), "emp_EmpID = '" + empno + "'"))
                {
                    addPersonalLogs();
                    empInfo = emp.GetEmployeeInfoDict(empno);
                    populateUpdatePersonal();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Updated !!!');", true);
                }
            }
        }
        protected void btnUpdatePersonnel_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                getupdPersonnel();
                if (emp.UpdateQueryCommon(saveUpdatePersonnelParam(), "emp_EmpID = '" + empno + "'"))
                {
                    addPersonnelLogs();
                    empInfo = emp.GetEmployeeInfoDict(empno);
                    populateUpdatePersonnel();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Updated !!!');", true);
                }
            }
        }

        protected void btnUpdatePayroll_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                getupdPayroll();
                if (emp.UpdateQueryCommon(saveUpdatePayrollParam(), "emp_EmpID = '" + empno + "'"))
                {
                    addPayrollLogs();
                    empInfo = emp.GetEmployeeInfoDict(empno);
                    populateUpdatePersonnel();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Updated !!!');", true);
                }
            }
        }

        protected void btnUploadImage_Click(object sender, EventArgs e)
        {
            string filename = "";
            if (IsUploaded(out filename))
            {
                if (emp.AddFileToDBEmpImage(empno, filename))
                {
                    refresh();
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Image successfully uploaded');",
                true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Failed to upload: " + filename + "');",
                true);


            }
        }

        bool IsUploaded(out string outfilename)
        {
            bool valid = true;
            outfilename = "";

            string fulldirectory = Server.MapPath(emp.file201folder);
            fulldirectory += @"EmployeeImage\";
            if (!Directory.Exists(fulldirectory))
                Directory.CreateDirectory(fulldirectory);
            try
            {
                string filename = Path.GetFileName(fuUploader.PostedFile.FileName);
                string filextension = Path.GetExtension(fuUploader.PostedFile.FileName);
                //string fileURL = Page.ResolveUrl("~/201Files");
                //string fileToUpload = fulldirectory + filename;
                string fileToUpload = fulldirectory + empno + filextension;

                outfilename = empno + filextension;
                if (!File.Exists(fileToUpload))
                    fuUploader.SaveAs(fileToUpload);
                else
                {
                    File.Delete(fileToUpload);
                    fuUploader.SaveAs(fileToUpload);

                    //valid = false;
                    //outfilename = filename + ":  Duplicate file name(s) are not allowed";
                }
            }
            catch (Exception ex)
            {
                valid = false;
                outfilename = outfilename + ":  " + ex.ToString();
            }
            return valid;


        }
    }
}