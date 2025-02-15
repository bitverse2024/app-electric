﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

public class Payroll
    {   
        public class Payslip
        {
            public string empno;
            public string empname;
            public string date_covered;
            public string payrollgroup;
            public string department;
            public string basicpay;
            public string sss;
            public string cash_adv;
            public string loanbal;
            public string absentded;
            public string philhealth;
            public string lates;
            public string pagibig;
            public string totalgrossincome;
            public string totaldeduction;
            public string netpay;
            public string utded;
            public string leavepay;
            public string remainingleavecredit;
            public string otpay;
            public string holidaypay;
            public string bonus;

        public string adjustment; //12/17/2021
        public string allowance; //05/26/2022 Jan Wong
        public string adjustmentremarks; //07/18/2022 Jan Wong
        public string wtax; //08/01/2022 Jan Wong

        public double CL = 0, CLBal = 0,
                SSS = 0, SSSBal = 0, PIL = 0, PILBal = 0, PICL = 0, PICLBal = 0,
                SSSCL = 0, SSSCLBal = 0, CA = 0, CABal = 0, CA2 = 0, CABal2 = 0,
                CA3 = 0, CABal3 = 0;

        public string rdp;
    }


        Common cm = new Common();
        Timekeeping tk = new Timekeeping();
        static string connectionstring = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        //public string FileDirectory =  ConfigurationManager.AppSettings["201FileDirectory"].ToString(); 
        public SqlCommand cmd = new SqlCommand();
        public SqlConnection conn = new SqlConnection();
        public SqlDataReader dread;
        public SqlDataAdapter adpt = new SqlDataAdapter();
        public DataTable dt = new DataTable();
        //public string file201folder = @"201Filecs\";
        public string file201folder = @"~/201Files/";
    
        public DataTable populateGridPayrollRegister_TBLPAYREG()
        {
            dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[10] { new DataColumn("id"), new DataColumn("CODate"),
            new DataColumn("EmpName"), new DataColumn("GrossPay"), new DataColumn("TotDed"), new DataColumn("NetPay"),
            new DataColumn("UT"),new DataColumn("Absent"),new DataColumn("Lates"),new DataColumn("OTPay")});
            conn = new SqlConnection(connectionstring);
            conn.Open();
            //cmd = new SqlCommand("Select * from TBL_USERS where user_Status='ACTIVE'", conn);
            cmd = new SqlCommand("Select * from TBL_PAYREG Order by id", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                
                dt.Rows.Add(dread["id"].ToString(), cm.FormatDate(dread["CODate"].ToString()),
                    dread["EmpName"].ToString(),toRoundOff( dread["GrossPay"].ToString()), toRoundOff(dread["TotDed"].ToString()), toRoundOff(dread["NetPay"].ToString()),
                    toRoundOff(dread["UT"].ToString()), toRoundOff(dread["Absent"].ToString()), toRoundOff(dread["Lates"].ToString()), toRoundOff(dread["OTPay"].ToString()));
            }
            dread.Close();

        conn.Close();
        return dt;
    }
    public DataTable populateGridPayrollRegisterCol_TBLPAYREG(string expr)
    {
        string qry = "Select * from TBL_PAYREG";
        qry += (expr == "" ? "" : expr);
        string ordr = " Order by id";
        qry += ordr;
        dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[10] { new DataColumn("id"), new DataColumn("CODate"),
            new DataColumn("EmpName"), new DataColumn("GrossPay"), new DataColumn("TotDed"), new DataColumn("NetPay"),
            new DataColumn("UT"),new DataColumn("Absent"),new DataColumn("Lates"),new DataColumn("OTPay")});
        conn = new SqlConnection(connectionstring);
        conn.Open();
        //cmd = new SqlCommand("Select * from TBL_USERS where user_Status='ACTIVE'", conn);
        cmd = new SqlCommand(qry, conn);
        dread = cmd.ExecuteReader();
        while (dread.Read())
        {

            dt.Rows.Add(dread["id"].ToString(), cm.FormatDate(dread["CODate"].ToString()),
                    dread["EmpName"].ToString(), toRoundOff(dread["GrossPay"].ToString()), toRoundOff(dread["TotDed"].ToString()), toRoundOff(dread["NetPay"].ToString()),
                    toRoundOff(dread["UT"].ToString()), toRoundOff(dread["Absent"].ToString()), toRoundOff(dread["Lates"].ToString()), toRoundOff(dread["OTPay"].ToString()));
        }
        dread.Close();

        conn.Close();
        return dt;
    }
    public DataTable populateGridPayrollRegister()
    {
        dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[13] { new DataColumn("id"), new DataColumn("CODate"),
            new DataColumn("EmpName"), new DataColumn("GrossPay"),new DataColumn("SSSDed"),new DataColumn("PhilhealthDed"),new DataColumn("PagibigDed"), new DataColumn("TotDed"), new DataColumn("NetPay"),
            new DataColumn("UT"),new DataColumn("Absent"),new DataColumn("Lates"),new DataColumn("OTPay")});
        conn = new SqlConnection(connectionstring);
        conn.Open();
        //cmd = new SqlCommand("Select * from TBL_USERS where user_Status='ACTIVE'", conn);
        cmd = new SqlCommand("Select * from TBL_PAYSLIP Order by CODate DESC", conn);
        dread = cmd.ExecuteReader();
        while (dread.Read())
        {

            dt.Rows.Add(dread["id"].ToString(), cm.FormatDate(dread["CODate"].ToString()),
                dread["EmployeeName"].ToString(), toRoundOff(dread["GrossPay"].ToString()), toRoundOff(dread["SSSDed"].ToString()), toRoundOff(dread["PhilhealthDed"].ToString()), toRoundOff(dread["PagibigDed"].ToString()), toRoundOff(dread["TotDed"].ToString()), toRoundOff(dread["NetPay"].ToString()),
                toRoundOff(dread["UTDed"].ToString()), toRoundOff(dread["AbsentDed"].ToString()), toRoundOff(dread["LatesDed"].ToString()), toRoundOff(dread["OTPay"].ToString()));
        }
        dread.Close();

        conn.Close();
        return dt;
    }
    public DataTable populateGridPayrollRegisterCol(string expr)
    {
        string qry = "Select * from TBL_PAYSLIP";
        qry += (expr == "" ? "" : expr);
        string ordr = " Order by CODate DESC";
        qry += ordr;
        dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[13] { new DataColumn("id"), new DataColumn("CODate"),
            new DataColumn("EmpName"), new DataColumn("GrossPay"),new DataColumn("SSSDed"),new DataColumn("PhilhealthDed"),new DataColumn("PagibigDed"), new DataColumn("TotDed"), new DataColumn("NetPay"),
            new DataColumn("UT"),new DataColumn("Absent"),new DataColumn("Lates"),new DataColumn("OTPay")});
        conn = new SqlConnection(connectionstring);
        conn.Open();
        //cmd = new SqlCommand("Select * from TBL_USERS where user_Status='ACTIVE'", conn);
        cmd = new SqlCommand(qry, conn);
        dread = cmd.ExecuteReader();
        while (dread.Read())
        {

            dt.Rows.Add(dread["id"].ToString(), cm.FormatDate(dread["CODate"].ToString()),
                dread["EmployeeName"].ToString(), toRoundOff(dread["GrossPay"].ToString()), toRoundOff(dread["SSSDed"].ToString()), toRoundOff(dread["PhilhealthDed"].ToString()), toRoundOff(dread["PagibigDed"].ToString()), toRoundOff(dread["TotDed"].ToString()), toRoundOff(dread["NetPay"].ToString()),
                toRoundOff(dread["UTDed"].ToString()), toRoundOff(dread["AbsentDed"].ToString()), toRoundOff(dread["LatesDed"].ToString()), toRoundOff(dread["OTPay"].ToString()));
        }
        dread.Close();

        conn.Close();
        return dt;
    }
    public DataTable populateGridPayrollRegisterddl(string CreditDate)
    {
        string qry = "Select * from TBL_PAYREG where CODate = '" + CreditDate + "' Order by id";
        if(CreditDate == "all")
        {
            qry = "Select * from TBL_PAYREG Order by id";

        }
        dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[6] { new DataColumn("id"), new DataColumn("CODate"),
            new DataColumn("EmpName"), new DataColumn("GrossPay"), new DataColumn("TotDed"), new DataColumn("NetPay")});
        conn = new SqlConnection(connectionstring);
        conn.Open();
        //cmd = new SqlCommand("Select * from TBL_USERS where user_Status='ACTIVE'", conn);
        cmd = new SqlCommand(qry, conn);
        dread = cmd.ExecuteReader();
        while (dread.Read())
        {

            dt.Rows.Add(dread["id"].ToString(), cm.FormatDate(dread["CODate"].ToString()),
                dread["EmpName"].ToString(), dread["GrossPay"].ToString(), dread["TotDed"].ToString(), dread["NetPay"].ToString());
        }
        dread.Close();

        conn.Close();
        return dt;
    }
    public string build_or_like_paramPayroll(Dictionary<string, string> param)
    {
        return build_or_like_paramPayroll(false, param);
    }
    public string build_or_like_paramPayroll(bool IsFirstCondition, Dictionary<string, string> param)
    {

        string values = (IsFirstCondition ? "" : " where (");
        bool isfirstItem = true;
        string query_optr = "";
        foreach (KeyValuePair<string, string> kvp in param)
        {
            if (kvp.Value == "" || kvp.Value == "'%%'") continue;
            query_optr = (kvp.Value.Contains("'") ? "LIKE" : "=");
            values += (isfirstItem ? "" : " or ") + kvp.Key + " " + query_optr + " " + kvp.Value;
            isfirstItem = false;
        }

        values += (IsFirstCondition ? "" : " )");



        return values;

    }

    public int processpayroll(string cutoffid,bool is13thMonthEnabled)
    {
        int ret = 0;
        List<string> summaryIDs = getSummaryIDs(cutoffid);
        foreach(string s in summaryIDs)
        {
            Dictionary<string, string> deductionsDict = new Dictionary<string, string>();
            Dictionary<string, string> summaryDict = cm.GetTableDict("TBL_PAYROLLSUM", " where id = " + s + "");
            Dictionary<string, string> empDict = cm.GetTableDict("TBL_EMPLOYEE_MASTER", " where emp_EmpID = '" + summaryDict["empid"] + "'");
            if (empDict.Count <= 0)
                continue;
            computeDeduction(cutoffid,empDict, summaryDict, is13thMonthEnabled, out deductionsDict);
            string payrollGrp = cm.GetSpecificDataFromDB("PayrollGroup", "TBL_CUTOFF", "where id = " + cutoffid + "");
            #region payregparam
            Dictionary<string, string> payregparam = new Dictionary<string, string>();
            payregparam.Add("CODate", "'"+summaryDict["CODate"]+"'");
            payregparam.Add("CutoffID", cutoffid);
            payregparam.Add("PayrollGroup", payrollGrp);
            payregparam.Add("EmpID", "'" + summaryDict["empid"] + "'");
            payregparam.Add("EmpName", "'" + summaryDict["PSname"] + "'");
            payregparam.Add("AccountNo", "'########'");
            payregparam.Add("Lates", deductionsDict["LatesDed"]);
            payregparam.Add("UT", deductionsDict["UTDed"]);
            payregparam.Add("Absent", deductionsDict["AbsentDed"]);
            payregparam.Add("Leaves", deductionsDict["Leaves"]);
            payregparam.Add("OTPay", deductionsDict["OTPay"]);
            payregparam.Add("BasicPay", "'" + deductionsDict["BasicPay"] + "'");
            payregparam.Add("GrossPay", deductionsDict["GrossPay"]);
            payregparam.Add("TotDed", deductionsDict["TotDed"]);
            payregparam.Add("SSSDed", deductionsDict["SSSDed"]);
            payregparam.Add("PhilhealthDed", deductionsDict["PhilhealthDed"]);
            payregparam.Add("PagibigDed", deductionsDict["PagibigDed"]);
            payregparam.Add("NetPay", deductionsDict["NetPay"]);
            payregparam.Add("NumDays", deductionsDict["NumDays"]);
            payregparam.Add("WTax", deductionsDict["WTax"]);
            payregparam.Add("thirteenthmonth", deductionsDict["thirteenthmonth"]);
            #endregion payregparam
            Dictionary<string, string> payslipparam = new Dictionary<string, string>();


            payslipparam.Add("CODate", "'" + Convert.ToDateTime(summaryDict["CODate"]).ToString("yyyy-MM-dd") + "'");
            payslipparam.Add("CutoffID", "'"+cutoffid +"'");
            payslipparam.Add("PayrollGroup", payrollGrp);
            payslipparam.Add("EmployeeID", "'" + summaryDict["empid"] + "'");
            payslipparam.Add("EmployeeName", "'" + summaryDict["PSname"] + "'");
            
            payslipparam.Add("DateCovered", "'" + getDateCovered(cutoffid) + "'");
            string dept = cm.GetSpecificDataFromDB("DeptName", "TBL_DEPARTMENT", "where id = " + empDict["emp_Department"] + "");
            payslipparam.Add("Department", "'" + dept + "'");
            payslipparam.Add("TINNO", "'#######'");
            payslipparam.Add("AccountNo", "'########'");
            payslipparam.Add("Latesmin", "'" + summaryDict["Latesmin"] + "'");
            payslipparam.Add("UTmin", "'" + summaryDict["UTmin"] + "'");
            payslipparam.Add("LatesDed", "'" + deductionsDict["LatesDed"] + "'");
            payslipparam.Add("UTDed", "'" + deductionsDict["UTDed"] + "'");
            payslipparam.Add("AbsentCount", "'" + deductionsDict["AbsentCount"] + "'");
            payslipparam.Add("AbsentDed", "'" + deductionsDict["AbsentDed"] + "'");
            payslipparam.Add("Leaves", "'" + deductionsDict["Leaves"] + "'");

            string remainingleaves = cm.GetSpecificDataFromDB("Remaining", "TBL_LEAVES", " where EmpID = '" + summaryDict["empid"] + "' and LeaveType = '1'");

            payslipparam.Add("RemainingLeavesCredit", (remainingleaves == ""? "0": remainingleaves));
            payslipparam.Add("LeavePay",  deductionsDict["LeavesPay"]);
            payslipparam.Add("OTPay", "'" + deductionsDict["OTPay"] + "'");
            payslipparam.Add("BasicPay", "'" + deductionsDict["BasicPay"] + "'");
            payslipparam.Add("GrossPay", "'" + deductionsDict["GrossPay"] + "'");
            payslipparam.Add("TaxableAmt", "'#######'");
            
            
            payslipparam.Add("SSSDed", deductionsDict["SSSDed"]);
            payslipparam.Add("PhilhealthDed", deductionsDict["PhilhealthDed"]);
            payslipparam.Add("PagibigDed", deductionsDict["PagibigDed"]);
            payslipparam.Add("TotDed", "'"+deductionsDict["TotDed"] + "'");
            payslipparam.Add("NetPay", "'" + deductionsDict["NetPay"] + "'");
            payslipparam.Add("taxrate", "'" + deductionsDict["taxrate"] + "'");
            payslipparam.Add("WTax", "'" + deductionsDict["WTax"] + "'");
            payslipparam.Add("LoanBal", "'" + deductionsDict["LoanBalance"] + "'");
            payslipparam.Add("CashADV", "'" + deductionsDict["CashAdvance"] + "'");
            payslipparam.Add("LHWP", deductionsDict["HolidayPay"]);
            payslipparam.Add("thirteenthmonthpay", deductionsDict["thirteenthmonthpay"]);

            Dictionary<string, string> contributionparam = new Dictionary<string, string>();
            contributionparam.Add("cutoffID", "'" + cutoffid + "'");
            contributionparam.Add("empID", "'" + summaryDict["empid"] + "'");
            contributionparam.Add("sssER", "'" + deductionsDict["sssERgrp"].ToString() + "'");
            contributionparam.Add("sssEE", "'" + deductionsDict["SSSDed"] + "'");
            contributionparam.Add("sssEC", "'" + deductionsDict["sssECgrp"].ToString() + "'");
            contributionparam.Add("philhealthEE", "'" + deductionsDict["PhilhealthDed"] + "'");
            contributionparam.Add("philhealthER", "'" + deductionsDict["philhealthER"] + "'");
            contributionparam.Add("pagibigEE", "'" + deductionsDict["PagibigDed"] + "'");
            contributionparam.Add("pagibigER", "'" + deductionsDict["pagibigER"] + "'");
            contributionparam.Add("empTax", "'" + deductionsDict["WTax"] + "'");

            if (!HasDuplicate_Contribution_Entry(summaryDict["empid"], cutoffid))
            {
                if (!(cm.InsertQueryCommon(contributionparam, "TBL_CONTRIBUTION")))
                    Console.WriteLine("Failed Insert Contribution()");
            }
            else
                cm.UpdateQueryCommon(contributionparam, "TBL_CONTRIBUTION", "   cutoffID = '" + cutoffid + "' and empID = '" + summaryDict["empid"] + "' ");


            if (!HasDuplicate_PayReg_Entry(summaryDict["empid"], cutoffid))
            {
                if (!(cm.InsertQueryCommon(payregparam, "TBL_PAYREG")))
                    Console.WriteLine("Failed InsertPayroll()");
                
            }
            else
                cm.UpdateQueryCommon(payregparam, "TBL_PAYREG", "   CutoffID = " + cutoffid + " and EmpID = '" + summaryDict["empid"] + "' ");

            if (!HasDuplicate_PaySlip_Entry(summaryDict["empid"], cutoffid))
            {
                if (!(cm.InsertQueryCommon(payslipparam, "TBL_PAYSLIP")))
                    Console.WriteLine("Failed InsertPayroll()");
                
            }
            else
                cm.UpdateQueryCommon(payslipparam, "TBL_PAYSLIP", "   CutoffID = '" + cutoffid + "' and EmployeeID = '" + summaryDict["empid"] + "' ");


        }//end of foreach summaryIDs

        return ret;


    }
    List<string> getSummaryIDs(string cutoffid, string empnum)
    {
        List<string> IDs = new List<string>();
        string qry = "Select id from TBL_PAYROLLSUM where CutoffID = " + cutoffid + "";
        if (empnum != "")
            qry += " AND empid = '" + empnum + "'";

        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand(qry, conn);
        dread = cmd.ExecuteReader();
        while (dread.Read())
        {
            IDs.Add(dread[0].ToString());
        }
        dread.Close();
        conn.Close();

        return IDs;

    }
    List<string> getSummaryIDs(string cutoffid, List<string> selectedempnum)
    {
        List<string> IDs = new List<string>();
        string expr = "";
        int i = 0;
        if (selectedempnum.Count > 0)
        {
            expr += " AND (";
            foreach (string empnum in selectedempnum)
            {
                if (i > 0)
                {
                    expr += " OR ";
                }
                expr += " empid = '" + empnum + "' ";
                i++;
            }
            expr += " )";
            //expr += " AND TBL_EMPLOYEE_MASTER.emp_PayrollGroup = TBL_CUTOFF.PayrollGroup";

        }
        string qry = "Select id from TBL_PAYROLLSUM where CutoffID = " + cutoffid + " ";
        qry = qry + expr;
        //if (empnum != "")
        //    qry += " AND empid = '" + empnum + "'";

        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand(qry, conn);
        dread = cmd.ExecuteReader();
        while (dread.Read())
        {
            IDs.Add(dread[0].ToString());
        }
        dread.Close();
        conn.Close();

        return IDs;

    }
    public int processpayrollAE(string cutoffid, string empnum, bool IsfilingEnabled, bool IsLoanDeductionDisabled, bool IsGovDeductionDisabled, string GovDeductionPercentage, List<string> loanselected, bool IsEnableLeaveMonetization)
    {
        List<string> employeeselected = new List<string>();
        if (empnum != "")
        {
            employeeselected.Add(empnum);
        }


        return processpayrollAE(cutoffid, employeeselected, IsfilingEnabled, IsLoanDeductionDisabled, IsGovDeductionDisabled, GovDeductionPercentage, loanselected, IsEnableLeaveMonetization);
    }
    public int processpayrollAE(string cutoffid, List<string> selectedempnum, bool IsfilingEnabled, bool IsLoanDeductionDisabled, bool IsGovDeductionDisabled, string GovDeductionPercentage, List<string> loanselected, bool IsEnableLeaveMonetization)
    {
        conn.Close();
        int ret = 0;
        List<string> summaryIDs = new List<string>();

        summaryIDs = getSummaryIDs(cutoffid, selectedempnum);


        //summaryIDs.Add(empnum);


        foreach (string s in summaryIDs)
        {

            Dictionary<string, string> allowanceDict = new Dictionary<string, string>();
            Dictionary<string, string> deductionsDict = new Dictionary<string, string>();
            Dictionary<string, string> summaryDict = cm.GetTableDict("TBL_PAYROLLSUM", " where id = " + s + "");
            if (summaryDict.Count <= 0)
            {
                continue;
            }
            Dictionary<string, string> empDict = cm.GetTableDict("TBL_EMPLOYEE_MASTER", " where emp_EmpID = '" + summaryDict["empid"] + "'");
            if (empDict.Count <= 0)
            {
                continue;
            }
            computeDeductionAE(empDict, summaryDict, IsfilingEnabled, IsLoanDeductionDisabled, IsGovDeductionDisabled, GovDeductionPercentage, loanselected, out deductionsDict, out allowanceDict, IsEnableLeaveMonetization);
            string payrollGrp = cm.GetSpecificDataFromDB("PayrollGroup", "TBL_CUTOFF", "where id = " + cutoffid + "");
            #region payregparam
            Dictionary<string, string> payregparam = new Dictionary<string, string>();
            payregparam.Add("CODate", "'" + summaryDict["CODate"] + "'");
            payregparam.Add("CutoffID", cutoffid);
            payregparam.Add("PayrollGroup", payrollGrp);
            payregparam.Add("EmpID", "'" + summaryDict["empid"] + "'");
            //if PSName is empty get from tbl_EmployeeMaster
            payregparam.Add("EmpName", "'" + summaryDict["PSname"] + "'");
            payregparam.Add("AccountNo", "'########'");
            payregparam.Add("Lates", deductionsDict["LatesDed"]);
            payregparam.Add("UT", deductionsDict["UTDed"]);
            payregparam.Add("Absent", deductionsDict["AbsentDed"]);
            payregparam.Add("Leaves", deductionsDict["Leaves"]);
            payregparam.Add("OTPay", deductionsDict["OTPay"]);
            payregparam.Add("BasicPay", "'" + deductionsDict["BasicPay"] + "'");
            payregparam.Add("GrossPay", deductionsDict["GrossPay"]);
            payregparam.Add("TotDed", deductionsDict["TotDed"]);
            payregparam.Add("SSSDed", deductionsDict["SSSDed"]);
            payregparam.Add("PhilhealthDed", deductionsDict["PhilhealthDed"]);
            payregparam.Add("PagibigDed", deductionsDict["PagibigDed"]);
            payregparam.Add("NetPay", deductionsDict["NetPay"]);
            payregparam.Add("NumDays", deductionsDict["NumDays"]);
            payregparam.Add("WTax", deductionsDict["WTax"]);
            payregparam.Add("thirteenthmonth", deductionsDict["thirteenthmonth"]);
            #endregion payregparam
            #region allowanceparam
            Dictionary<string, string> allowanceparam = new Dictionary<string, string>();
            allowanceparam.Add("empID", "'" + allowanceDict["empID"] + "'");
            allowanceparam.Add("cutoffID", "'" + allowanceDict["cutoffID"] + "'");
            allowanceparam.Add("PayrollGroup", "'" + allowanceDict["PayrollGroup"] + "'");
            allowanceparam.Add("allowance", "" + allowanceDict["allowance"] + "");
            allowanceparam.Add("allowanceperday", "" + allowanceDict["allowanceperday"] + "");
            allowanceparam.Add("allowancepermin", "" + allowanceDict["allowancepermin"] + "");
            allowanceparam.Add("adeductionpermin", "" + allowanceDict["adeductionpermin"] + "");
            allowanceparam.Add("adeductionperday", "" + allowanceDict["adeductionperday"] + "");
            #endregion allowanceparam

            Dictionary<string, string> payslipparam = new Dictionary<string, string>();
            payslipparam.Add("CODate", "'" + cm.FormatDate(summaryDict["CODate"]) + "'");
            payslipparam.Add("CutoffID", "'" + cutoffid + "'");
            payslipparam.Add("PayrollGroup", payrollGrp);
            payslipparam.Add("EmployeeID", "'" + summaryDict["empid"] + "'");
            payslipparam.Add("EmployeeName", "'" + summaryDict["PSname"] + "'");

            payslipparam.Add("DateCovered", "'" + getDateCovered(cutoffid) + "'");
            string dept = cm.GetSpecificDataFromDB("DeptName", "TBL_DEPARTMENT", "where id = " + empDict["emp_Department"] + "");
            payslipparam.Add("Department", "'" + dept + "'");
            payslipparam.Add("TINNO", "'#######'");
            payslipparam.Add("AccountNo", "'########'");
            payslipparam.Add("Latesmin", "'" + summaryDict["Latesmin"] + "'");
            double utminplusoverbreak = 0, utmin = 0, overbreakmin = 0;
            double.TryParse(summaryDict["UTmin"], out utmin);
            double.TryParse(summaryDict["OverBreakMin"], out overbreakmin);
            utminplusoverbreak = utmin + overbreakmin;
            //payslipparam.Add("UTmin", "'" + summaryDict["UTmin"] + "'");
            payslipparam.Add("UTmin", "'" + utminplusoverbreak + "'");

            payslipparam.Add("LatesDed", "'" + deductionsDict["LatesDed"] + "'");
            payslipparam.Add("UTDed", "'" + deductionsDict["UTDed"] + "'");
            payslipparam.Add("AbsentCount", "'" + deductionsDict["AbsentCount"] + "'");
            payslipparam.Add("AbsentDed", "'" + deductionsDict["AbsentDed"] + "'");
            payslipparam.Add("Leaves", "'" + deductionsDict["Leaves"] + "'");
            string remainingleaves = cm.GetSpecificDataFromDB("Remaining", "TBL_LEAVES", " where EmpID = '" + summaryDict["empid"] + "' and LeaveType = '1'");

            payslipparam.Add("RemainingLeavesCredit", (remainingleaves == "" ? "0" : remainingleaves));
            payslipparam.Add("LeavePay", deductionsDict["LeavesPay"]);
            payslipparam.Add("OTPay", "'" + deductionsDict["OTPay"] + "'");
            payslipparam.Add("BasicPay", "'" + deductionsDict["BasicPay"] + "'");
            payslipparam.Add("GrossPay", "'" + deductionsDict["GrossPay"] + "'");
            payslipparam.Add("TaxableAmt", "'#######'");
            payslipparam.Add("SSSDed", deductionsDict["SSSDed"]);
            payslipparam.Add("PhilhealthDed", deductionsDict["PhilhealthDed"]);
            payslipparam.Add("PagibigDed", deductionsDict["PagibigDed"]);
            payslipparam.Add("TotDed", "'" + deductionsDict["TotDed"] + "'");
            payslipparam.Add("NetPay", "'" + deductionsDict["NetPay"] + "'");
            payslipparam.Add("taxrate", "'" + deductionsDict["taxrate"] + "'");
            payslipparam.Add("WTax", "'" + deductionsDict["WTax"] + "'");
            payslipparam.Add("LoanBal", "'" + deductionsDict["LoanBalance"] + "'");
            payslipparam.Add("CashADV", "'" + deductionsDict["CashAdvance"] + "'");
            payslipparam.Add("SSSLoanDed", "'" + deductionsDict["SSSLoanDed"] + "'");
            payslipparam.Add("LHWP", deductionsDict["HolidayPay"]);

            //for sv
            payslipparam.Add("RDLHOT", "'" + deductionsDict["RDLHOT"] + "'");
            payslipparam.Add("REGOT", "'" + deductionsDict["REGOT"] + "'");
            payslipparam.Add("RDOT", "'" + deductionsDict["RDOT"] + "'");
            payslipparam.Add("LHOT", "'" + deductionsDict["LHOT"] + "'");
            payslipparam.Add("RDSHOT", "'" + deductionsDict["RDSHOT"] + "'");
            payslipparam.Add("SHOT", "'" + deductionsDict["SHOT"] + "'");

            payslipparam.Add("RDP", "'" + deductionsDict["RDP"] + "'");
            payslipparam.Add("ND01", "'" + deductionsDict["ND01"] + "'");
            payslipparam.Add("LHP", "'" + deductionsDict["LHP"] + "'");
            payslipparam.Add("RDSHP", "'" + deductionsDict["RDSHP"] + "'");
            payslipparam.Add("SHP", "'" + deductionsDict["SHP"] + "'");
            payslipparam.Add("RDLHP", "'" + deductionsDict["RDLHP"] + "'");
            payslipparam.Add("TotHrs", "'" + deductionsDict["TotHrs"] + "'");

            payslipparam.Add("CL", "'" + deductionsDict["CL"] + "'");
            payslipparam.Add("SSSL", "'" + deductionsDict["SSSL"] + "'");
            payslipparam.Add("PIL", "'" + deductionsDict["PIL"] + "'");
            payslipparam.Add("PICL", "'" + deductionsDict["PICL"] + "'");
            payslipparam.Add("SSSCL", "'" + deductionsDict["SSSCL"] + "'");
            //payslipparam.Add("SSS", deductionsDict["SSS"]);
            payslipparam.Add("CA", "'" + deductionsDict["CA"] + "'");

            payslipparam.Add("ecola", "'" + deductionsDict["ecola"] + "'");//For Ecola
            payslipparam.Add("thirteenthMonthPay", "'" + deductionsDict["thirteenthMonthPay"] + "'");//For thirteenthMonthPay
            payslipparam.Add("allowance", "'" + deductionsDict["allowance"] + "'");//For Allowance. 05/26/2022 Jan Wong. 

            //08/31/2022 Jan. for payroll register
            payslipparam.Add("SPERST", "'" + deductionsDict["SPERST"] + "'");
            payslipparam.Add("LEGRST", "'" + deductionsDict["LEGRST"] + "'");
            payslipparam.Add("REGND", "'" + deductionsDict["REGND"] + "'");
            payslipparam.Add("RDND", "'" + deductionsDict["RDND"] + "'");
            payslipparam.Add("SPEND", "'" + deductionsDict["SPEND"] + "'");
            payslipparam.Add("SPERSTND", "'" + deductionsDict["SPERSTND"] + "'");
            payslipparam.Add("LEGND", "'" + deductionsDict["LEGND"] + "'");
            payslipparam.Add("LEGRSTND", "'" + deductionsDict["LEGRSTND"] + "'");
            payslipparam.Add("DOUBLEGND", "'" + deductionsDict["DOUBLEGND"] + "'");
            payslipparam.Add("DOUBLEGRSTND", "'" + deductionsDict["DOUBLEGRSTND"] + "'");
            payslipparam.Add("DOUBLEGOT", "'" + deductionsDict["DOUBLEGOT"] + "'");
            payslipparam.Add("DOUBRSTOT", "'" + deductionsDict["DOUBRSTOT"] + "'");

            payslipparam.Add("DOUBLH", "'" + deductionsDict["DOUBLH"] + "'");
            payslipparam.Add("DOUBLHRD", "'" + deductionsDict["DOUBLHRD"] + "'");
            payslipparam.Add("RegularDays", "'" + deductionsDict["RegularDays"] + "'"); 

            Dictionary<string, string> contributionparam = new Dictionary<string, string>();
            contributionparam.Add("cutoffID", "'" + cutoffid + "'");
            contributionparam.Add("empID", "'" + summaryDict["empid"] + "'");
            contributionparam.Add("sssER", "'" + deductionsDict["sssERgrp"].ToString() + "'");
            contributionparam.Add("sssEE", "'" + deductionsDict["SSSDed"] + "'");
            contributionparam.Add("sssEC", "'" + deductionsDict["sssECgrp"].ToString() + "'");
            contributionparam.Add("philhealthEE", "'" + deductionsDict["PhilhealthDed"] + "'");
            contributionparam.Add("philhealthER", "'" + deductionsDict["philhealthER"] + "'");
            contributionparam.Add("pagibigEE", "'" + deductionsDict["PagibigDed"] + "'");
            contributionparam.Add("pagibigER", "'" + deductionsDict["pagibigER"] + "'");
            contributionparam.Add("empTax", "'" + deductionsDict["WTax"] + "'");
            contributionparam.Add("sssMPFEE", "'" + deductionsDict["sssMPFEEgrp"] + "'");
            contributionparam.Add("sssMPFER", "'" + deductionsDict["sssMPFERgrp"] + "'"); 



            if (!HasDuplicate_Contribution_Entry(summaryDict["empid"], cutoffid))
            {
                if (!(cm.InsertQueryCommon(contributionparam, "TBL_CONTRIBUTION")))
                    Console.WriteLine("Failed Insert Contribution()");
            }
            else
                cm.UpdateQueryCommon(contributionparam, "TBL_CONTRIBUTION", "   cutoffID = '" + cutoffid + "' and empID = '" + summaryDict["empid"] + "' ");

            //alowance
            if (!HasDuplicate_Allowance_Entry(summaryDict["empid"], cutoffid))
            {
                if (!(cm.InsertQueryCommon(allowanceparam, "TBL_ALLOWANCE")))
                    Console.WriteLine("Failed Insert ALLOWANCE()");
            }
            else
                cm.UpdateQueryCommon(allowanceparam, "TBL_ALLOWANCE", "   cutoffID = '" + cutoffid + "' and empID = '" + summaryDict["empid"] + "' ");

            if (!HasDuplicate_PayReg_Entry(summaryDict["empid"], cutoffid))
            {
                if (!(cm.InsertQueryCommon(payregparam, "TBL_PAYREG")))
                    Console.WriteLine("Failed InsertPayroll()");

            }
            else
                cm.UpdateQueryCommon(payregparam, "TBL_PAYREG", "   CutoffID = " + cutoffid + " and EmpID = '" + summaryDict["empid"] + "' ");

            if (!HasDuplicate_PaySlip_Entry(summaryDict["empid"], cutoffid))
            {
                if (!(cm.InsertQueryCommon(payslipparam, "TBL_PAYSLIP")))
                    Console.WriteLine("Failed InsertPayroll()");

            }
            else
                cm.UpdateQueryCommon(payslipparam, "TBL_PAYSLIP", "   CutoffID = '" + cutoffid + "' and EmployeeID = '" + summaryDict["empid"] + "' ");



            }//end of foreach summaryIDs


        return ret;


    }
    public int processpayroll1(string cutoffid, string empnum, bool IsfilingEnabled, bool IsLoanDeductionDisabled, bool IsGovDeductionDisabled, bool is13thMonthEnabled, string GovDeductionPercentage, List<string> loanselected)
    {
        int ret = 0;
        //List<string> summaryIDs = getSummaryIDs(cutoffid);
        List<string> summaryIDs = new List<string>();
        summaryIDs = getSummaryIDs(cutoffid, empnum);
        foreach (string s in summaryIDs)
        {
            Dictionary<string, string> allowanceDict = new Dictionary<string, string>();
            Dictionary<string, string> deductionsDict = new Dictionary<string, string>();
            Dictionary<string, string> summaryDict = cm.GetTableDict("TBL_PAYROLLSUM", " where id = " + s + "");
            Dictionary<string, string> empDict = cm.GetTableDict("TBL_EMPLOYEE_MASTER", " where emp_EmpID = '" + summaryDict["empid"] + "'");
            if (empDict.Count <= 0)
                continue;
            //computeDeduction(cutoffid, empDict, summaryDict, is13thMonthEnabled, out deductionsDict);
            computeDeduction1(cutoffid,empDict, summaryDict, IsfilingEnabled, IsLoanDeductionDisabled, IsGovDeductionDisabled, is13thMonthEnabled, GovDeductionPercentage, loanselected, out deductionsDict, out allowanceDict);
            string payrollGrp = cm.GetSpecificDataFromDB("PayrollGroup", "TBL_CUTOFF", "where id = " + cutoffid + "");
            #region payregparam
            Dictionary<string, string> payregparam = new Dictionary<string, string>();
            payregparam.Add("CODate", "'" + summaryDict["CODate"] + "'");
            payregparam.Add("CutoffID", cutoffid);
            payregparam.Add("PayrollGroup", payrollGrp);
            payregparam.Add("EmpID", "'" + summaryDict["empid"] + "'");
            payregparam.Add("EmpName", "'" + summaryDict["PSname"] + "'");
            payregparam.Add("AccountNo", "'########'");
            payregparam.Add("Lates", deductionsDict["LatesDed"]);
            payregparam.Add("UT", deductionsDict["UTDed"]);
            payregparam.Add("Absent", deductionsDict["AbsentDed"]);
            payregparam.Add("Leaves", deductionsDict["Leaves"]);
            payregparam.Add("OTPay", deductionsDict["OTPay"]);
            payregparam.Add("BasicPay", "'" + deductionsDict["BasicPay"] + "'");
            payregparam.Add("GrossPay", deductionsDict["GrossPay"]);
            payregparam.Add("TotDed", deductionsDict["TotDed"]);
            payregparam.Add("SSSDed", deductionsDict["SSSDed"]);
            payregparam.Add("PhilhealthDed", deductionsDict["PhilhealthDed"]);
            payregparam.Add("PagibigDed", deductionsDict["PagibigDed"]);
            payregparam.Add("NetPay", deductionsDict["NetPay"]);
            payregparam.Add("NumDays", deductionsDict["NumDays"]);
            payregparam.Add("WTax", deductionsDict["WTax"]);
            payregparam.Add("thirteenthmonth", deductionsDict["thirteenthmonth"]);
            #endregion payregparam
            Dictionary<string, string> payslipparam = new Dictionary<string, string>();


            payslipparam.Add("CODate", "'" + Convert.ToDateTime(summaryDict["CODate"]).ToString("yyyy-MM-dd") + "'");
            payslipparam.Add("CutoffID", "'" + cutoffid + "'");
            payslipparam.Add("PayrollGroup", payrollGrp);
            payslipparam.Add("EmployeeID", "'" + summaryDict["empid"] + "'");
            payslipparam.Add("EmployeeName", "'" + summaryDict["PSname"] + "'");

            payslipparam.Add("DateCovered", "'" + getDateCovered(cutoffid) + "'");
            string dept = cm.GetSpecificDataFromDB("DeptName", "TBL_DEPARTMENT", "where id = " + empDict["emp_Department"] + "");
            payslipparam.Add("Department", "'" + dept + "'");
            payslipparam.Add("TINNO", "'#######'");
            payslipparam.Add("AccountNo", "'########'");
            payslipparam.Add("Latesmin", "'" + summaryDict["Latesmin"] + "'");
            payslipparam.Add("UTmin", "'" + summaryDict["UTmin"] + "'");
            payslipparam.Add("LatesDed", "'" + deductionsDict["LatesDed"] + "'");
            payslipparam.Add("UTDed", "'" + deductionsDict["UTDed"] + "'");
            payslipparam.Add("AbsentCount", "'" + deductionsDict["AbsentCount"] + "'");
            payslipparam.Add("AbsentDed", "'" + deductionsDict["AbsentDed"] + "'");
            payslipparam.Add("Leaves", "'" + deductionsDict["Leaves"] + "'");

            string remainingleaves = cm.GetSpecificDataFromDB("Remaining", "TBL_LEAVES", " where EmpID = '" + summaryDict["empid"] + "' and LeaveType = '1'");

            payslipparam.Add("RemainingLeavesCredit", (remainingleaves == "" ? "0" : remainingleaves));
            payslipparam.Add("LeavePay", deductionsDict["LeavesPay"]);
            payslipparam.Add("OTPay", "'" + deductionsDict["OTPay"] + "'");
            payslipparam.Add("BasicPay", "'" + deductionsDict["BasicPay"] + "'");
            payslipparam.Add("GrossPay", "'" + deductionsDict["GrossPay"] + "'");
            payslipparam.Add("TaxableAmt", "'#######'");


            payslipparam.Add("SSSDed", deductionsDict["SSSDed"]);
            payslipparam.Add("PhilhealthDed", deductionsDict["PhilhealthDed"]);
            payslipparam.Add("PagibigDed", deductionsDict["PagibigDed"]);
            payslipparam.Add("TotDed", "'" + deductionsDict["TotDed"] + "'");
            payslipparam.Add("NetPay", "'" + deductionsDict["NetPay"] + "'");
            payslipparam.Add("taxrate", "'" + deductionsDict["taxrate"] + "'");
            payslipparam.Add("WTax", "'" + deductionsDict["WTax"] + "'");
            payslipparam.Add("LoanBal", "'" + deductionsDict["LoanBalance"] + "'");
            payslipparam.Add("CashADV", "'" + deductionsDict["CashAdvance"] + "'");
            payslipparam.Add("LHWP", deductionsDict["HolidayPay"]);
            payslipparam.Add("thirteenthmonthpay", deductionsDict["thirteenthmonthpay"]);

            Dictionary<string, string> contributionparam = new Dictionary<string, string>();
            contributionparam.Add("cutoffID", "'" + cutoffid + "'");
            contributionparam.Add("empID", "'" + summaryDict["empid"] + "'");
            contributionparam.Add("sssER", "'" + deductionsDict["sssERgrp"].ToString() + "'");
            contributionparam.Add("sssEE", "'" + deductionsDict["SSSDed"] + "'");
            contributionparam.Add("sssEC", "'" + deductionsDict["sssECgrp"].ToString() + "'");
            contributionparam.Add("philhealthEE", "'" + deductionsDict["PhilhealthDed"] + "'");
            contributionparam.Add("philhealthER", "'" + deductionsDict["philhealthER"] + "'");
            contributionparam.Add("pagibigEE", "'" + deductionsDict["PagibigDed"] + "'");
            contributionparam.Add("pagibigER", "'" + deductionsDict["pagibigER"] + "'");
            contributionparam.Add("empTax", "'" + deductionsDict["WTax"] + "'");

            if (!HasDuplicate_Contribution_Entry(summaryDict["empid"], cutoffid))
            {
                if (!(cm.InsertQueryCommon(contributionparam, "TBL_CONTRIBUTION")))
                    Console.WriteLine("Failed Insert Contribution()");
            }
            else
                cm.UpdateQueryCommon(contributionparam, "TBL_CONTRIBUTION", "   cutoffID = '" + cutoffid + "' and empID = '" + summaryDict["empid"] + "' ");


            if (!HasDuplicate_PayReg_Entry(summaryDict["empid"], cutoffid))
            {
                if (!(cm.InsertQueryCommon(payregparam, "TBL_PAYREG")))
                    Console.WriteLine("Failed InsertPayroll()");

            }
            else
                cm.UpdateQueryCommon(payregparam, "TBL_PAYREG", "   CutoffID = " + cutoffid + " and EmpID = '" + summaryDict["empid"] + "' ");

            if (!HasDuplicate_PaySlip_Entry(summaryDict["empid"], cutoffid))
            {
                if (!(cm.InsertQueryCommon(payslipparam, "TBL_PAYSLIP")))
                    Console.WriteLine("Failed InsertPayroll()");

            }
            else
                cm.UpdateQueryCommon(payslipparam, "TBL_PAYSLIP", "   CutoffID = '" + cutoffid + "' and EmployeeID = '" + summaryDict["empid"] + "' ");


        }//end of foreach summaryIDs

        return ret;


    }
    bool HasDuplicate_PayReg_Entry(string empno, string cutoffid)
    {
        bool isduplicate = false;
        string qry = "Select * from TBL_PAYREG where EmpID = '" + empno + "' and CutoffID = " + cutoffid + "";
        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand(qry, conn);
        dread = cmd.ExecuteReader();
        dread.Read();
        if (dread.HasRows)
            isduplicate = true;

        dread.Close();
        conn.Close();


        return isduplicate;
    }
    bool HasDuplicate_Contribution_Entry(string empno, string cutoffid)
    {
        bool isduplicate = false;
        string qry = "Select * from TBL_CONTRIBUTION where empID = '" + empno + "' and cutoffID = '" + cutoffid + "'";
        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand(qry, conn);
        dread = cmd.ExecuteReader();
        dread.Read();
        if (dread.HasRows)
            isduplicate = true;

        dread.Close();
        conn.Close();


        return isduplicate;
    }
    bool HasDuplicate_PaySlip_Entry(string empno, string cutoffid)
    {
        bool isduplicate = false;
        string qry = "Select * from TBL_PAYSLIP where EmployeeID = '" + empno + "' and CutoffID = '" + cutoffid + "'";
        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand(qry, conn);
        dread = cmd.ExecuteReader();
        dread.Read();
        if (dread.HasRows)
            isduplicate = true;

        dread.Close();
        conn.Close();


        return isduplicate;
    }

    List<string> getSummaryIDs(string cutoffid)
    {
        List<string> IDs = new List<string>();
        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand("Select id from TBL_PAYROLLSUM where CutoffID = " + cutoffid + "", conn);
        dread = cmd.ExecuteReader();
        while(dread.Read())
        {
            IDs.Add(dread[0].ToString());
        }
        dread.Close();
        conn.Close();

        return IDs;

    }
    public void getDeductionAdjustment(string empno, string cutoff_id, double sss, double phil, double pagibig, out double sssded, out double philded, out double pagibigded )
    {
        conn = new SqlConnection(connectionstring);
        conn.Open();
        sssded = sss; philded = phil; pagibigded = pagibig;
        cmd = new SqlCommand("Select * from TBL_DEDUCTIONADJ where EmpID = '"+empno+"' and CutOffID =" + cutoff_id + "", conn);
        dread = cmd.ExecuteReader();
        dread.Read();
        if (dread.HasRows)
        {
            if(dread["SSSDed"] != DBNull.Value)
            {
                sssded = double.Parse(dread["SSSDed"].ToString());
            }
            if (dread["PhilDed"] != DBNull.Value)
            {
                philded = double.Parse(dread["PhilDed"].ToString());
            }
            if (dread["PagibigDed"] != DBNull.Value)
            {
                pagibigded = double.Parse(dread["PagibigDed"].ToString());
            }

            
            
        }
        
        dread.Close();
        conn.Close();


    }
    public void getCashAdvance(string empno, string cutoff_id, out double cashadvance, out double loanbalance)
    {
        cashadvance = 0;
        loanbalance = 0;
        conn = new SqlConnection(connectionstring);
        conn.Open();
        
        cmd = new SqlCommand("Select * from TBL_CASHADVANCE where EmpID = '" + empno + "' and CutOffID =" + cutoff_id + "", conn);
        dread = cmd.ExecuteReader();
        dread.Read();
        if (dread.HasRows)
        {
            if (dread["CashAdvance"] != DBNull.Value)
            {
                cashadvance = double.Parse(dread["CashAdvance"].ToString());
            }
            if (dread["LoanBalance"] != DBNull.Value)
            {
                loanbalance = double.Parse(dread["LoanBalance"].ToString());
            }
            



        }

        dread.Close();
        conn.Close();


    }
    public void getDeductionAdjustmentLates(string empno, string cutoff_id, out double latesded)
    {
        conn = new SqlConnection(connectionstring);
        conn.Open();
        latesded = 0;
        cmd = new SqlCommand("Select * from TBL_DEDUCTIONADJ where EmpID = '" + empno + "' and CutOffID =" + cutoff_id + "", conn);
        dread = cmd.ExecuteReader();
        dread.Read();
        if (dread.HasRows)
        {
            if (dread["LatesDed"] != DBNull.Value)
            {
                latesded = double.Parse(dread["LatesDed"].ToString());
            }
            
        }

        dread.Close();
        conn.Close();


    }
    void computeDeduction(string cutoffid, Dictionary<string, string> empDict, Dictionary<string, string> summaryDict, bool is13thMonthEnabled, out Dictionary<string, string> deductionsDict)
    {
        bool isMonthly = empDict["emp_PayType"] == "M";
        string getcutoffWeek = cm.GetSpecificDataFromDB("creditWeek", "TBL_CUTOFF", "where id = " + cutoffid + "");
        string islatedisregardval = "0";
        double grosspay = double.Parse(empDict["emp_BasicPay"]);
        double sssded = double.Parse(empDict["emp_SSSDed"]);
        double philhded = double.Parse(empDict["emp_PhilHealthDed"]);
        double pagibigded = double.Parse(empDict["emp_PagibigDed"]);
        double grosspaygrp = 0;
        double sssdedgrp = 0;
        double philhdedgrp = 0;
        double pagibigdedgrp = 0;
        double cashadvance = 0;
        double loanbalance = 0;
        /*Get employee work days (from TBL_EMPLYOEE_MASTER)
        */
        double getempworkdays = 0;
        double workdays = double.TryParse(empDict["emp_WorkDays"], out getempworkdays) ? getempworkdays : 0;

        double sssER = 0;
        double sssEC = 0;
        double sssERgrp = 0;
        double sssECgrp = 0;
        double philhealthER = 0;
        double philhealthERgrp = 0;
        double pagibigER = 0;
        double pagibigERgrp = 0;
        pagibigded = 100;
        pagibigER = 100;

        //sssER = tk.GetSSSERContribution(empDict["emp_BasicPay"]);
        sssded = tk.GetSSSDed(empDict["emp_BasicPay"]);
        sssER = tk.GetSSSERContribution(empDict["emp_BasicPay"]);
        sssEC = tk.GetSSSECContribution(empDict["emp_BasicPay"]);
        philhded = tk.GetPhilDed(empDict["emp_BasicPay"]);
        double LatesDed = 0;
        double TotalGovtDed = sssded + philhded + pagibigded;
        
        double TotalGovtDedpergroup = 0;
        string payrollmode = cm.GetSpecificDataFromDB("payrollmode", "TBL_PAYROLLGRP", "where id =" + empDict["emp_PayrollGroup"] + "");

        double divide = double.Parse(payrollmode);
        //grosspaygrp = grosspay / divide;
        //grosspaygrp = grosspay / 26 * double.Parse(summaryDict["PSDays"]);
        //grosspaygrp = grosspay / workdays * double.Parse(summaryDict["PSDays"]);
        grosspaygrp = grosspay / divide; // 10/25/2021 Jan
        if (getcutoffWeek == "5")
        {
            sssdedgrp = 0;
            philhdedgrp = 0;
            pagibigdedgrp = 0;
            TotalGovtDedpergroup = 0;
            pagibigERgrp = 0;
            sssECgrp = 0;
            sssERgrp = 0;
        }
        else
        {
            sssdedgrp = sssded / divide;
            sssERgrp = sssER / divide;
            sssECgrp = sssEC / divide;
            pagibigERgrp = pagibigER / divide;
            //philhdedgrp = philhded / divide / 2;
            philhdedgrp = philhded / divide;
            pagibigdedgrp = pagibigded / divide;
        }
        
        if (cm.ItemExist("TBL_DEDUCTIONADJ", "id", "where EmpID = '" + summaryDict["empid"] + "' and CutOffID =" + summaryDict["CutoffID"] + "", ""))
        { 
            getDeductionAdjustment(summaryDict["empid"], summaryDict["CutoffID"],sssdedgrp, philhdedgrp, pagibigdedgrp, out sssdedgrp, out philhdedgrp, out pagibigdedgrp);
        }
        if (cm.ItemExist("TBL_CASHADVANCE", "id", "where EmpID = '" + summaryDict["empid"] + "' and CutOffID =" + summaryDict["CutoffID"] + "", ""))
        {
            getCashAdvance(summaryDict["empid"], summaryDict["CutoffID"],out cashadvance, out loanbalance);
        }
        TotalGovtDedpergroup = sssdedgrp + philhdedgrp + pagibigdedgrp;


        double perday = 0;
        double permin = 0;
        double perhr = 0;

        #region new_AE
        double summaryLatesmin = 0; double summarypsabsent = 0;
        double summaryutmin = 0; double summarylatesmin = 0;
        double summaryTotHrs = 0; double summaryOTHrs = 0;

        bool isothrs = double.TryParse(summaryDict["OTHrs"].ToString(), out summaryOTHrs);
        bool isutmin = double.TryParse(summaryDict["UTmin"].ToString(), out summaryutmin);
        bool islatesmin = double.TryParse(summaryDict["Latesmin"].ToString(), out summarylatesmin);
        bool istothrs = double.TryParse(summaryDict["TotHrs"].ToString(), out summaryTotHrs);
        bool issummarypsabsentn = double.TryParse(summaryDict["PSabsent"].ToString(), out summarypsabsent);
        #endregion new_AE

        if (payrollmode == "4")
            perday = grosspay / workdays;
        //if (payrollmode == "4")
        //    perday = grosspay / 26;
        else if (payrollmode == "2")
            perday = grosspay * 12 / 313;
        /*if (payrollmode == "4")
            perday = grosspay / 26;
        else if (payrollmode == "2")
            perday = grosspay * 12 / 313;
         OLD PROCESS   
         */

        if (perday != 0)
            permin = perday / 8 / 60;
        if (perday != 0)
            perhr = perday / 8;



        double UTDed = isMonthly ? double.Parse(summaryDict["UTmin"]) * permin : 0;
         LatesDed = isMonthly ? double.Parse(summaryDict["Latesmin"]) * permin : 0;
        if (cm.ItemExist("TBL_DTRSETTINGS", "id", " where EmpID = '" + summaryDict["empid"] + "'", ""))
        {
            getIsLatesDisregard(summaryDict["empid"], out islatedisregardval);
            {
                if(islatedisregardval == "1")
                { 
                    LatesDed = 0;
                }
            }
            

        }
        //if (cm.ItemExist("TBL_DEDUCTIONADJ", "id", "where EmpID = '" + summaryDict["empid"] + "' and CutOffID =" + summaryDict["CutoffID"] + "", ""))
        //{
        //    getDeductionAdjustmentLates(summaryDict["empid"], summaryDict["CutoffID"], out LatesDed);
        //}
        double OTReg = double.Parse(summaryDict["OTReg"]) * permin;

        //double absentded = double.Parse(summaryDict["PSabsent"]) * perday;
        double absentded = isMonthly ? summarypsabsent * perday : 0;
        double totaldtrdeduction = isMonthly ? UTDed + LatesDed : 0;

        //double basicpay = grosspaygrp;
        //double basicpay = empDict["emp_PayType"]  == "D" ? perday * double.Parse(summaryDict["PSDays"]) : grosspay / divide;
        double totdayscount = summaryTotHrs / 9;
        //double basicpay = isMonthly ? grosspaygrp : perday * totdayscount;
        double basicpay = isMonthly ? grosspaygrp : perhr * summaryTotHrs;
        basicpay = Math.Ceiling(basicpay);
        
        double holidaypay = 0;
        //holidaypay = computeHoldayPay(summaryDict["CutoffID"], perday);

        #region new_holidaypay
        double NDPay = 0;
        double RDpay = 0; double rdothrs = 0; double RDNDPay = 0; double RDNDHrs = 0;

        double LHP = 0; double LHothrs = 0; double LHNDPay = 0; double LHNDHrs = 0;
        double LHRDpay = 0; double LHRDothrs = 0;
        double WRKLH = 0; double WRKLHothrs = 0;

        double RHpay = 0; double RHothrs = 0; double RHNDpay = 0; double RHNDHrs = 0;
        double RHRDpay = 0; double RHRDothrs = 0;

        double SHP = 0; double SHothrs = 0; double SHNDPay = 0; 
        double WRKSH = 0; double WRKSHothrs = 0;
        double SHRDpay = 0; double SHRDothrs = 0; double SHRDNDPay = 0; double SHRDNDHrs = 0;
        double REGOT = 0, RDP = 0, RDLHOT = 0, ND01 = 0, RDOT = 0, LHOT = 0, RDSHP = 0, RDSHOT = 0, SHOT = 0, RHOT = 0, RDLHP = 0;
        double doublegot = 0, doubrstot = 0;
        double SHOTND = 0, SHNDHrs = 0;
        double LHOTND = 0;
        double RDLHOTND = 0; double RDLHNDHrs = 0;

        double WRKSHRD = 0; double WRKSHRDOT = 0; double WRKLHRD = 0; double WRKLHRDOT = 0;

        RDpay = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "RDP", out rdothrs);//OK 10/05/2021 Jan
        LHRDpay = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "LHRD", out LHRDothrs);//OK 10/05/2021 Jan
        SHRDpay = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "SHRD", out SHRDothrs);
        RHRDpay = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "RHRD", out RHRDothrs);

        LHP = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "LH", out LHothrs); //OK 10/05/2021 Jan
        SHP = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "SH", out SHothrs);
        RHpay = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRKRH", out RHothrs);

        WRKSHRD = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRKSHRD", out WRKSHRDOT);//OK 10/05/2021 Jan
        WRKLHRD = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRKLHRD", out WRKLHRDOT);//OK 10/05/2021 Jan
        WRKLH = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRKLH", out WRKLHothrs); //OK 10/05/2021 Jan
        WRKSH = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRKSH", out WRKSHothrs);//OK 10/05/2021 Jan
        double totalOthers = 0;
        double totalLHP = 0;
        double totalSHP = 0;
        totalLHP = LHRDpay + LHP + WRKLHRD + WRKLH;
        totalSHP = SHRDpay + SHP + WRKSHRD + WRKSH;
        totalOthers = RDpay + LHRDpay + SHRDpay + RHRDpay + LHP + SHP + RHpay + WRKSHRD + WRKLHRD + WRKLH + WRKSH;
        #endregion new_holidaypay

        #region new_adjustment
        double AdjustmentAddPay = 0;
        double AdjustmentOthersAddPay = 0;
        double totaladjustmentpay = 0;
        string val1 = "", val2 = "";
        if (cm.ItemExist("TBL_ADJUSTMENT", "id", "where EmpID = '" + summaryDict["empid"] + "' and CutOffID =" + summaryDict["CutoffID"] + "", ""))
        {
            cm.GetTwoDataFromDB("AdjustmentAdd", "AdjustmentOthersAdd", "TBL_ADJUSTMENT", "where EmpID = '" + summaryDict["empid"] + "' and CutOffID =" + summaryDict["CutoffID"] + "", out val1, out val2);
            double.TryParse(val1, out AdjustmentAddPay);
            double.TryParse(val2, out AdjustmentOthersAddPay);
            totaladjustmentpay = AdjustmentAddPay + AdjustmentOthersAddPay;
            //TODO update iscomputed
            //cm.UpdateQueryCommon()
        }
        #endregion new_adjustment
        double grossincome = basicpay - totaldtrdeduction + totalOthers + totaladjustmentpay;
        //double grossincome = basicpay;
        double taxrate = 0;
        double wtax = computeTax(grossincome.ToString(), out taxrate);
        
        //double totaldeduction = TotalGovtDedpergroup + totaldtrdeduction + absentded + wtax;
        double totaldeduction = TotalGovtDedpergroup + absentded + wtax + cashadvance;
        double leavepay = 0; double LWPCount = 0;
        double.TryParse(summaryDict["LWP"], out LWPCount);
        //leavepay = computeLeavePay(summaryDict["CutoffID"], summaryDict["empid"], perday);
        leavepay = LWPCount * perday;
        //double otpay = 0;
        //otpay = computeOTPay(summaryDict["CutoffID"], summaryDict["empid"], perday);

        #region new_OT
        REGOT = getRegOTPay(summaryDict["RegOT"] != "" ? double.Parse(summaryDict["RegOT"]) : 0, perhr);   //OK 10/05/2021 Jan
        RDOT =  getRegOTPay(summaryDict["RDOT"] != "" ? double.Parse(summaryDict["RDOT"]) : 0, perhr, "RDOT"); //OK 10/06/2021 Jan
        RDSHOT = getRegOTPay(summaryDict["RDSHOT"] != "" ? double.Parse(summaryDict["RDSHOT"]) : 0, perhr, "RDSHOT");
        SHOT = getRegOTPay(summaryDict["SHOT"] != "" ? double.Parse(summaryDict["SHOT"]) : 0, perhr, "SHOT");//OK 10/07/2021 Jan
        LHOT = getRegOTPay(summaryDict["LHOT"] != "" ? double.Parse(summaryDict["LHOT"]) : 0, perhr, "LHOT");//OK 10/07/2021 Jan
        SHOTND = getRegOTPay(summaryDict["SHOTND"] != "" ? double.Parse(summaryDict["SHOTND"]) : 0, perhr, "SHOTND");//OK 10/07/2021 Jan
        LHOTND = getRegOTPay(summaryDict["LHOTND"] != "" ? double.Parse(summaryDict["LHOTND"]) : 0, perhr, "LHOTND");//OK 10/07/2021 Jan
        RDLHOT = getRegOTPay(summaryDict["RDLHOT"] != "" ? double.Parse(summaryDict["RDLHOT"]) : 0, perhr, "RDLHOT");//OK 10/07/2021 Jan
        RDLHOTND = getRegOTPay(summaryDict["RDLHOTND"] != "" ? double.Parse(summaryDict["RDLHOTND"]) : 0, perhr, "RDLHOTND"); //OK 10/05/2021 Jan
        SHRDNDPay = getRegOTPay(summaryDict["RDSHOTND"] != "" ? double.Parse(summaryDict["RDSHOTND"]) : 0, perhr, "RDSHOTND");//OK 10/05/2021 Jan

        //doublegot = getRegOTPay(summaryDict["DOUBLEGOT"] != "" ? double.Parse(summaryDict["DOUBLEGOT"]) : 0, perhr);
        //doubrstot = getRegOTPay(summaryDict["DOUBRSTOT"] != "" ? double.Parse(summaryDict["DOUBRSTOT"]) : 0, perhr);
        
        //for ND OT
        //SHNDPay = computeNDOTPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "SH", "SHOTND");
        RDNDPay = computeNDOTPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "RDP", "RDOTND");
        NDPay = computeNDOTPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRK", "RegOTND"); //OK 10/05/2021 Jan

        #region for_nonOTNDHrs
        double totalnonOTNDHrs = 0;
        double RDNDP = 0, RDSHNDHrsP = 0, RDLHNDHrsP = 0, LHNDHrsP = 0, SHNDHrsP = 0, RegNDHrsP = 0, doublhnd = 0, doublhrdnd = 0;
        RegNDHrsP = computeRegNDPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRK", "RegNDHrs","REG ND");//OK 10/05/2021 Jan
        SHNDHrsP = computeRegNDPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRK", "SHNDHrs", "SPE ND");//OK 10/07/2021 Jan
        LHNDHrsP = computeRegNDPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRK", "LHNDHrs", "WLEG ND");//OK 10/07/2021 Jan
        RDLHNDHrsP = computeRegNDPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRK", "RDLHNDHrs", "RST LEG ND");//OK 10/07/2021 Jan
        RDSHNDHrsP = computeRegNDPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRK", "RDSHNDHrs", "RST SPE ND");//OK 10/07/2021 Jan
        RDNDP = computeRegNDPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "RDP", "RDND", "RST ND");//OK 10/05/2021 Jan
        doublhnd = computeRegNDPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "DOUB", "DOUBLEGND", "DOUB LEG ND");
        doublhrdnd = computeRegNDPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "DOUB", "DOUBLEGRSTND", "DOUB LEG RST ND");

        totalnonOTNDHrs = RegNDHrsP + RDNDP + SHNDHrsP + RDSHNDHrsP + LHNDHrsP + doublhnd + doublhrdnd;
        #endregion for_nonOTNDHrs


        double totalOTpay = 0;
        totalOTpay = REGOT + RDOT + SHOT + RDSHOT + LHOT + RDLHOT +  RHOT + doublegot + doubrstot;
        #endregion new_OT


        #region get13thMonthPay
        double totalLates = 0, totalAbsences = 0, totalUndertime = 0, TotalDaysWorked = 0, thirteenthmonthpay = 0;
        if (is13thMonthEnabled)
        {
            
            GetTotalLatesUTAbsDeduction(summaryDict["empid"].ToString(), out totalLates, out totalAbsences, out totalUndertime);
            if(empDict["emp_PayType"] == "M")
            {
                thirteenthmonthpay = grosspay - ((totalLates + totalAbsences + totalUndertime) / 12);
            }
            else if (empDict["emp_PayType"] == "D")
            {
                GetTotalDaysWorked(summaryDict["empid"].ToString(), out TotalDaysWorked);
                thirteenthmonthpay = TotalDaysWorked * perday * 26 / 312;
            }
        }
        #endregion get13thMonthPay

        //double netpay = grossincome - totaldeduction + OTReg + leavepay + otpay + holidaypay - cashadvance;
        //double netpay = grossincome - totaldeduction + OTReg + leavepay + otpay - cashadvance;
        double netpay = grossincome - totaldeduction + OTReg + leavepay + totalOTpay + totalnonOTNDHrs;
        if(netpay < 0)
        {
            sssdedgrp = 0;
            philhdedgrp = 0;
            pagibigdedgrp = 0;
            TotalGovtDedpergroup = 0;
            pagibigERgrp = 0;
            sssECgrp = 0;
            sssERgrp = 0;
            totaldeduction = 0;
            netpay = 0;
        }
        netpay = Math.Ceiling(netpay);
        //totaldeduction += totaldtrdeduction;




        deductionsDict = new Dictionary<string, string>();
        deductionsDict.Add("LatesDed", LatesDed.ToString());
        deductionsDict.Add("UTDed", UTDed.ToString());
        deductionsDict.Add("AbsentCount",  summaryDict["PSabsent"]);
        deductionsDict.Add("AbsentDed", absentded.ToString());
        deductionsDict.Add("Leaves", "0");
        //deductionsDict.Add("OTPay", otpay.ToString());
        deductionsDict.Add("OTPay", totalOTpay.ToString()); 
        deductionsDict.Add("LeavesPay", leavepay.ToString());
        //deductionsDict.Add("HolidayPay", holidaypay.ToString());
        deductionsDict.Add("HolidayPay", totalOthers.ToString());
        deductionsDict.Add("BasicPay", basicpay.ToString());
        deductionsDict.Add("GrossPay", grossincome.ToString());
        deductionsDict.Add("TotDed", totaldeduction.ToString());
        deductionsDict.Add("SSSDed", sssdedgrp.ToString());
        deductionsDict.Add("PhilhealthDed", philhdedgrp.ToString());
        deductionsDict.Add("philhealthER", philhdedgrp.ToString());
        deductionsDict.Add("PagibigDed", pagibigdedgrp.ToString());
        deductionsDict.Add("pagibigER", pagibigERgrp.ToString());
        deductionsDict.Add("NetPay", netpay.ToString());
        deductionsDict.Add("NumDays", summaryDict["PSDays"]); 
        deductionsDict.Add("taxrate", taxrate.ToString());
        deductionsDict.Add("WTax", wtax.ToString());
        deductionsDict.Add("thirteenthmonth", "0.00");
        deductionsDict.Add("CashAdvance", cashadvance.ToString());
        deductionsDict.Add("LoanBalance", loanbalance.ToString());
        deductionsDict.Add("sssERgrp", sssERgrp.ToString());
        deductionsDict.Add("sssECgrp", sssECgrp.ToString());
        deductionsDict.Add("thirteenthmonthpay", thirteenthmonthpay.ToString());

        #region new_AE
        double SSSLoanDed = 0;
        deductionsDict.Add("SSSLoanDed", SSSLoanDed.ToString());
        deductionsDict.Add("RDLHOT", RDLHOT.ToString());
        deductionsDict.Add("REGOT", REGOT.ToString());
        deductionsDict.Add("RDOT", RDOT.ToString());
        deductionsDict.Add("LHOT", LHOT.ToString());
        deductionsDict.Add("RDSHOT", RDSHOT.ToString());
        deductionsDict.Add("SHOT", SHOT.ToString());

        deductionsDict.Add("RDP", RDpay.ToString());
        deductionsDict.Add("ND01", ND01.ToString());
        deductionsDict.Add("LHP", totalLHP.ToString());
        deductionsDict.Add("RDSHP", SHRDpay.ToString());
        deductionsDict.Add("SHP", totalSHP.ToString());
        deductionsDict.Add("RDLHP", LHRDpay.ToString());
        deductionsDict.Add("TotHrs", summaryTotHrs.ToString());
        //deductionsDict.Add("sssERgrp", sssERgrp.ToString());

        //deductionsDict.Add("WTax", wtax.ToString());



        deductionsDict.Add("RHRDpay", RHRDpay.ToString());
        #endregion new_AE

    }
    void computeDeduction1(string cutoffid,Dictionary<string, string> empDict, Dictionary<string, string> summaryDict, bool IsfilingEnabled, bool isLoanDeductionDisabled, bool isGovDeductionDisabled, bool is13thMonthEnabled, string GovDeductionPercentage, List<string> loanselected, out Dictionary<string, string> deductionsDict, out Dictionary<string, string> allowanceDict)
    {

        bool isMonthly = empDict["emp_PayType"] == "M";
        string getcutoffWeek = cm.GetSpecificDataFromDB("creditWeek", "TBL_CUTOFF", "where id = " + cutoffid + "");
        string islatedisregardval = "0";
        double grosspay = double.Parse(empDict["emp_BasicPay"]);
        double sssded = double.Parse(empDict["emp_SSSDed"]);
        double philhded = double.Parse(empDict["emp_PhilHealthDed"]);
        double pagibigded = double.Parse(empDict["emp_PagibigDed"]);
        double grosspaygrp = 0;
        double sssdedgrp = 0;
        double philhdedgrp = 0;
        double pagibigdedgrp = 0;
        double cashadvance = 0;
        double loanbalance = 0;
        /*Get employee work days (from TBL_EMPLYOEE_MASTER)
        */
        double getempworkdays = 0;
        double workdays = double.TryParse(empDict["emp_WorkDays"], out getempworkdays) ? getempworkdays : 0;

        double sssER = 0;
        double sssEC = 0;
        double sssERgrp = 0;
        double sssECgrp = 0;
        double philhealthER = 0;
        double philhealthERgrp = 0;
        double pagibigER = 0;
        double pagibigERgrp = 0;
        pagibigded = 100;
        pagibigER = 100;

        //sssER = tk.GetSSSERContribution(empDict["emp_BasicPay"]);
        sssded = tk.GetSSSDed(empDict["emp_BasicPay"]);
        sssER = tk.GetSSSERContribution(empDict["emp_BasicPay"]);
        sssEC = tk.GetSSSECContribution(empDict["emp_BasicPay"]);
        philhded = tk.GetPhilDed(empDict["emp_BasicPay"]);
        double LatesDed = 0;
        double TotalGovtDed = sssded + philhded + pagibigded;

        double TotalGovtDedpergroup = 0;
        string payrollmode = cm.GetSpecificDataFromDB("payrollmode", "TBL_PAYROLLGRP", "where id =" + empDict["emp_PayrollGroup"] + "");

        double divide = double.Parse(payrollmode);
        //grosspaygrp = grosspay / divide;
        //grosspaygrp = grosspay / 26 * double.Parse(summaryDict["PSDays"]);
        //grosspaygrp = grosspay / workdays * double.Parse(summaryDict["PSDays"]);
        grosspaygrp = grosspay / divide; // 10/25/2021 Jan
        if (getcutoffWeek == "5")
        {
            sssdedgrp = 0;
            philhdedgrp = 0;
            pagibigdedgrp = 0;
            TotalGovtDedpergroup = 0;
            pagibigERgrp = 0;
            sssECgrp = 0;
            sssERgrp = 0;
        }
        else
        {
            sssdedgrp = sssded / divide;
            sssERgrp = sssER / divide;
            sssECgrp = sssEC / divide;
            pagibigERgrp = pagibigER / divide;
            //philhdedgrp = philhded / divide / 2;
            philhdedgrp = philhded / divide;
            pagibigdedgrp = pagibigded / divide;
        }

        if (GovDeductionPercentage != "")
        {

            //sssdedgrp = sssded * double.Parse(GovDeductionPercentage);
            philhdedgrp = philhded * double.Parse(GovDeductionPercentage) / 2;
            pagibigdedgrp = pagibigded * double.Parse(GovDeductionPercentage);
            //sssERgrp = sssER * double.Parse(GovDeductionPercentage);
            pagibigERgrp = pagibigER * double.Parse(GovDeductionPercentage);


        }

        if (cm.ItemExist("TBL_DEDUCTIONADJ", "id", "where EmpID = '" + summaryDict["empid"] + "' and CutOffID =" + summaryDict["CutoffID"] + "", ""))
        {
            getDeductionAdjustment(summaryDict["empid"], summaryDict["CutoffID"], sssdedgrp, philhdedgrp, pagibigdedgrp, out sssdedgrp, out philhdedgrp, out pagibigdedgrp);
        }
        if (cm.ItemExist("TBL_CASHADVANCE", "id", "where EmpID = '" + summaryDict["empid"] + "' and CutOffID =" + summaryDict["CutoffID"] + "", ""))
        {
            getCashAdvance(summaryDict["empid"], summaryDict["CutoffID"], out cashadvance, out loanbalance);
        }
        if (isGovDeductionDisabled == true)
        {
            sssdedgrp = 0;
            philhdedgrp = 0;
            pagibigdedgrp = 0;
            TotalGovtDedpergroup = 0;
            pagibigERgrp = 0;
            sssECgrp = 0;
            sssERgrp = 0;
        }
        else
        {
            TotalGovtDedpergroup = sssdedgrp + philhdedgrp + pagibigdedgrp;
        }
        


        double perday = 0;
        double permin = 0;
        double perhr = 0;

        #region new_AE
        double summaryLatesmin = 0; double summarypsabsent = 0;
        double summaryutmin = 0; double summarylatesmin = 0;
        double summaryTotHrs = 0; double summaryOTHrs = 0;

        bool isothrs = double.TryParse(summaryDict["OTHrs"].ToString(), out summaryOTHrs);
        bool isutmin = double.TryParse(summaryDict["UTmin"].ToString(), out summaryutmin);
        bool islatesmin = double.TryParse(summaryDict["Latesmin"].ToString(), out summarylatesmin);
        bool istothrs = double.TryParse(summaryDict["TotHrs"].ToString(), out summaryTotHrs);
        bool issummarypsabsentn = double.TryParse(summaryDict["PSabsent"].ToString(), out summarypsabsent);
        #endregion new_AE

        if (payrollmode == "4")
            perday = grosspay / workdays;
        //if (payrollmode == "4")
        //    perday = grosspay / 26;
        else if (payrollmode == "2")
            perday = grosspay * 12 / 313;
        /*if (payrollmode == "4")
            perday = grosspay / 26;
        else if (payrollmode == "2")
            perday = grosspay * 12 / 313;
         OLD PROCESS   
         */

        if (perday != 0)
            permin = perday / 8 / 60;
        if (perday != 0)
            perhr = perday / 8;



        double UTDed = isMonthly ? double.Parse(summaryDict["UTmin"]) * permin : 0;
        LatesDed = isMonthly ? double.Parse(summaryDict["Latesmin"]) * permin : 0;
        if (cm.ItemExist("TBL_DTRSETTINGS", "id", " where EmpID = '" + summaryDict["empid"] + "'", ""))
        {
            getIsLatesDisregard(summaryDict["empid"], out islatedisregardval);
            {
                if (islatedisregardval == "1")
                {
                    LatesDed = 0;
                }
            }


        }
        //if (cm.ItemExist("TBL_DEDUCTIONADJ", "id", "where EmpID = '" + summaryDict["empid"] + "' and CutOffID =" + summaryDict["CutoffID"] + "", ""))
        //{
        //    getDeductionAdjustmentLates(summaryDict["empid"], summaryDict["CutoffID"], out LatesDed);
        //}
        double OTReg = double.Parse(summaryDict["OTReg"]) * permin;

        //double absentded = double.Parse(summaryDict["PSabsent"]) * perday;
        double absentded = isMonthly ? summarypsabsent * perday : 0;
        double totaldtrdeduction = isMonthly ? UTDed + LatesDed : 0;

        //double basicpay = grosspaygrp;
        //double basicpay = empDict["emp_PayType"]  == "D" ? perday * double.Parse(summaryDict["PSDays"]) : grosspay / divide;
        double totdayscount = summaryTotHrs / 9;
        //double basicpay = isMonthly ? grosspaygrp : perday * totdayscount;
        double basicpay = isMonthly ? grosspaygrp : perhr * summaryTotHrs;
        basicpay = Math.Ceiling(basicpay);

        double holidaypay = 0;
        //holidaypay = computeHoldayPay(summaryDict["CutoffID"], perday);

        #region new_holidaypay
        double NDPay = 0;
        double RDpay = 0; double rdothrs = 0; double RDNDPay = 0; double RDNDHrs = 0;

        double LHP = 0; double LHothrs = 0; double LHNDPay = 0; double LHNDHrs = 0;
        double LHRDpay = 0; double LHRDothrs = 0;
        double WRKLH = 0; double WRKLHothrs = 0;

        double RHpay = 0; double RHothrs = 0; double RHNDpay = 0; double RHNDHrs = 0;
        double RHRDpay = 0; double RHRDothrs = 0;

        double SHP = 0; double SHothrs = 0; double SHNDPay = 0;
        double WRKSH = 0; double WRKSHothrs = 0;
        double SHRDpay = 0; double SHRDothrs = 0; double SHRDNDPay = 0; double SHRDNDHrs = 0;
        double REGOT = 0, RDP = 0, RDLHOT = 0, ND01 = 0, RDOT = 0, LHOT = 0, RDSHP = 0, RDSHOT = 0, SHOT = 0, RHOT = 0, RDLHP = 0;
        double SHOTND = 0, SHNDHrs = 0;
        double LHOTND = 0;
        double RDLHOTND = 0; double RDLHNDHrs = 0;

        double WRKSHRD = 0; double WRKSHRDOT = 0; double WRKLHRD = 0; double WRKLHRDOT = 0;

        RDpay = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "RDP", out rdothrs);//OK 10/05/2021 Jan
        LHRDpay = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "LHRD", out LHRDothrs);//OK 10/05/2021 Jan
        SHRDpay = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "SHRD", out SHRDothrs);
        RHRDpay = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "RHRD", out RHRDothrs);

        LHP = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "LH", out LHothrs); //OK 10/05/2021 Jan
        SHP = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "SH", out SHothrs);
        RHpay = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRKRH", out RHothrs);

        WRKSHRD = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRKSHRD", out WRKSHRDOT);//OK 10/05/2021 Jan
        WRKLHRD = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRKLHRD", out WRKLHRDOT);//OK 10/05/2021 Jan
        WRKLH = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRKLH", out WRKLHothrs); //OK 10/05/2021 Jan
        WRKSH = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRKSH", out WRKSHothrs);//OK 10/05/2021 Jan
        double totalOthers = 0;
        double totalLHP = 0;
        double totalSHP = 0;
        totalLHP = LHRDpay + LHP + WRKLHRD + WRKLH;
        totalSHP = SHRDpay + SHP + WRKSHRD + WRKSH;
        totalOthers = RDpay + LHRDpay + SHRDpay + RHRDpay + LHP + SHP + RHpay + WRKSHRD + WRKLHRD + WRKLH + WRKSH;
        #endregion new_holidaypay
        #region new_adjustment
        double AdjustmentAddPay = 0;
        double AdjustmentOthersAddPay = 0;
        double totaladjustmentpay = 0;
        string val1 = "", val2 = "";
        if (cm.ItemExist("TBL_ADJUSTMENT", "id", "where EmpID = '" + summaryDict["empid"] + "' and CutOffID =" + summaryDict["CutoffID"] + "", ""))
        {
            cm.GetTwoDataFromDB("AdjustmentAdd", "AdjustmentOthersAdd", "TBL_ADJUSTMENT", "where EmpID = '" + summaryDict["empid"] + "' and CutOffID =" + summaryDict["CutoffID"] + "", out val1, out val2);
            double.TryParse(val1, out AdjustmentAddPay);
            double.TryParse(val2, out AdjustmentOthersAddPay);
            totaladjustmentpay = AdjustmentAddPay + AdjustmentOthersAddPay;
            //TODO update iscomputed
            //cm.UpdateQueryCommon()
        }
        #endregion new_adjustment
        double grossincome = basicpay - totaldtrdeduction + totalOthers + totaladjustmentpay;
        //double grossincome = basicpay;
        double taxrate = 0;
        double wtax = computeTax(grossincome.ToString(), out taxrate);
        
        //double totaldeduction = TotalGovtDedpergroup + totaldtrdeduction + absentded + wtax;
        if ((grossincome < TotalGovtDedpergroup) || (basicpay <= 0) || (basicpay < TotalGovtDedpergroup))
        {
            sssdedgrp = 0;
            philhdedgrp = 0;
            pagibigdedgrp = 0;
            TotalGovtDedpergroup = 0;
            pagibigERgrp = 0;
            sssECgrp = 0;
            sssERgrp = 0;
        }
        double totaldeduction = TotalGovtDedpergroup + absentded + wtax + cashadvance;
        double leavepay = 0; double LWPCount = 0;
        double.TryParse(summaryDict["LWP"], out LWPCount);
        //leavepay = computeLeavePay(summaryDict["CutoffID"], summaryDict["empid"], perday);
        leavepay = LWPCount * perday;
        //double otpay = 0;
        //otpay = computeOTPay(summaryDict["CutoffID"], summaryDict["empid"], perday);

        #region new_OT
        REGOT = getRegOTPay(summaryDict["RegOT"] != "" ? double.Parse(summaryDict["RegOT"]) : 0, perhr);   //OK 10/05/2021 Jan
        RDOT = getRegOTPay(summaryDict["RDOT"] != "" ? double.Parse(summaryDict["RDOT"]) : 0, perhr, "RDOT"); //OK 10/06/2021 Jan
        RDSHOT = getRegOTPay(summaryDict["RDSHOT"] != "" ? double.Parse(summaryDict["RDSHOT"]) : 0, perhr, "RDSHOT");
        SHOT = getRegOTPay(summaryDict["SHOT"] != "" ? double.Parse(summaryDict["SHOT"]) : 0, perhr, "SHOT");//OK 10/07/2021 Jan
        LHOT = getRegOTPay(summaryDict["LHOT"] != "" ? double.Parse(summaryDict["LHOT"]) : 0, perhr, "LHOT");//OK 10/07/2021 Jan
        SHOTND = getRegOTPay(summaryDict["SHOTND"] != "" ? double.Parse(summaryDict["SHOTND"]) : 0, perhr, "SHOTND");//OK 10/07/2021 Jan
        LHOTND = getRegOTPay(summaryDict["LHOTND"] != "" ? double.Parse(summaryDict["LHOTND"]) : 0, perhr, "LHOTND");//OK 10/07/2021 Jan
        RDLHOT = getRegOTPay(summaryDict["RDLHOT"] != "" ? double.Parse(summaryDict["RDLHOT"]) : 0, perhr, "RDLHOT");//OK 10/07/2021 Jan
        RDLHOTND = getRegOTPay(summaryDict["RDLHOTND"] != "" ? double.Parse(summaryDict["RDLHOTND"]) : 0, perhr, "RDLHOTND"); //OK 10/05/2021 Jan
        SHRDNDPay = getRegOTPay(summaryDict["RDSHOTND"] != "" ? double.Parse(summaryDict["RDSHOTND"]) : 0, perhr, "RDSHOTND");//OK 10/05/2021 Jan
        //for ND OT
        //SHNDPay = computeNDOTPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "SH", "SHOTND");
        RDNDPay = computeNDOTPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "RDP", "RDOTND");
        NDPay = computeNDOTPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRK", "RegOTND"); //OK 10/05/2021 Jan

        #region for_nonOTNDHrs
        double RDNDP = 0, RDSHNDHrsP = 0, RDLHNDHrsP = 0, LHNDHrsP = 0, SHNDHrsP = 0, RegNDHrsP = 0;
        RegNDHrsP = computeRegNDPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRK", "RegNDHrs", "REG ND");//OK 10/05/2021 Jan
        SHNDHrsP = computeRegNDPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRK", "SHNDHrs", "SPE ND");//OK 10/07/2021 Jan
        LHNDHrsP = computeRegNDPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRK", "LHNDHrs", "WLEG ND");//OK 10/07/2021 Jan
        RDLHNDHrsP = computeRegNDPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRK", "RDLHNDHrs", "RST LEG ND");//OK 10/07/2021 Jan
        RDSHNDHrsP = computeRegNDPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRK", "RDSHNDHrs", "RST SPE ND");//OK 10/07/2021 Jan
        RDNDP = computeRegNDPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "RDP", "RDND", "RST ND");//OK 10/05/2021 Jan
        #endregion for_nonOTNDHrs


        double totalOTpay = 0;
        totalOTpay = REGOT + SHOT + RDOT + RDSHOT + RHOT;
        #endregion new_OT


        #region get13thMonthPay
        double totalLates = 0, totalAbsences = 0, totalUndertime = 0, TotalDaysWorked = 0, thirteenthmonthpay = 0;
        if (is13thMonthEnabled)
        {

            GetTotalLatesUTAbsDeduction(summaryDict["empid"].ToString(), out totalLates, out totalAbsences, out totalUndertime);
            if (empDict["emp_PayType"] == "M")
            {
                thirteenthmonthpay = grosspay - ((totalLates + totalAbsences + totalUndertime) / 12);
            }
            else if (empDict["emp_PayType"] == "D")
            {
                GetTotalDaysWorked(summaryDict["empid"].ToString(), out TotalDaysWorked);
                thirteenthmonthpay = TotalDaysWorked * perday * 26 / 312;
            }
        }
        #endregion get13thMonthPay

        //double netpay = grossincome - totaldeduction + OTReg + leavepay + otpay + holidaypay - cashadvance;
        //double netpay = grossincome - totaldeduction + OTReg + leavepay + otpay - cashadvance;
        double netpay = grossincome - totaldeduction + OTReg + leavepay + totalOTpay;
        if (netpay < 0)
        {
            sssdedgrp = 0;
            philhdedgrp = 0;
            pagibigdedgrp = 0;
            TotalGovtDedpergroup = 0;
            pagibigERgrp = 0;
            sssECgrp = 0;
            sssERgrp = 0;
            totaldeduction = 0;
            netpay = 0;
        }
        netpay = Math.Ceiling(netpay);
        //totaldeduction += totaldtrdeduction;



        allowanceDict = new Dictionary<string, string>();
        deductionsDict = new Dictionary<string, string>();
        deductionsDict.Add("LatesDed", LatesDed.ToString());
        deductionsDict.Add("UTDed", UTDed.ToString());
        deductionsDict.Add("AbsentCount", summaryDict["PSabsent"]);
        deductionsDict.Add("AbsentDed", absentded.ToString());
        deductionsDict.Add("Leaves", "0");
        //deductionsDict.Add("OTPay", otpay.ToString());
        deductionsDict.Add("OTPay", REGOT.ToString());
        deductionsDict.Add("LeavesPay", leavepay.ToString());
        //deductionsDict.Add("HolidayPay", holidaypay.ToString());
        deductionsDict.Add("HolidayPay", totalOthers.ToString());
        deductionsDict.Add("BasicPay", basicpay.ToString());
        deductionsDict.Add("GrossPay", grossincome.ToString());
        deductionsDict.Add("TotDed", totaldeduction.ToString());
        deductionsDict.Add("SSSDed", sssdedgrp.ToString());
        deductionsDict.Add("PhilhealthDed", philhdedgrp.ToString());
        deductionsDict.Add("philhealthER", philhdedgrp.ToString());
        deductionsDict.Add("PagibigDed", pagibigdedgrp.ToString());
        deductionsDict.Add("pagibigER", pagibigERgrp.ToString());
        deductionsDict.Add("NetPay", netpay.ToString());
        deductionsDict.Add("NumDays", summaryDict["PSDays"]);
        deductionsDict.Add("taxrate", taxrate.ToString());
        deductionsDict.Add("WTax", wtax.ToString());
        deductionsDict.Add("thirteenthmonth", "0.00");
        deductionsDict.Add("CashAdvance", cashadvance.ToString());
        deductionsDict.Add("LoanBalance", loanbalance.ToString());
        deductionsDict.Add("sssERgrp", sssERgrp.ToString());
        deductionsDict.Add("sssECgrp", sssECgrp.ToString());
        deductionsDict.Add("thirteenthmonthpay", thirteenthmonthpay.ToString());

        #region new_AE
        double SSSLoanDed = 0;
        deductionsDict.Add("SSSLoanDed", SSSLoanDed.ToString());
        deductionsDict.Add("RDLHOT", RDLHOT.ToString());
        deductionsDict.Add("REGOT", REGOT.ToString());
        deductionsDict.Add("RDOT", RDOT.ToString());
        deductionsDict.Add("LHOT", LHOT.ToString());
        deductionsDict.Add("RDSHOT", RDSHOT.ToString());
        deductionsDict.Add("SHOT", SHOT.ToString());

        deductionsDict.Add("RDP", RDpay.ToString());
        deductionsDict.Add("ND01", ND01.ToString());
        deductionsDict.Add("LHP", totalLHP.ToString());
        deductionsDict.Add("RDSHP", SHRDpay.ToString());
        deductionsDict.Add("SHP", totalSHP.ToString());
        deductionsDict.Add("RDLHP", LHRDpay.ToString());
        deductionsDict.Add("TotHrs", summaryTotHrs.ToString());
        //deductionsDict.Add("sssERgrp", sssERgrp.ToString());

        //deductionsDict.Add("WTax", wtax.ToString());



        deductionsDict.Add("RHRDpay", RHRDpay.ToString());
        #endregion new_AE

    }
    void computeDeductionAE(Dictionary<string, string> empDict, Dictionary<string, string> summaryDict, bool IsfilingEnabled, bool isLoanDeductionDisabled, bool isGovDeductionDisabled, string GovDeductionPercentage, List<string> loanselected, out Dictionary<string, string> deductionsDict, out Dictionary<string, string> allowanceDict, bool IsEnableLeaveMonetization)
    {
        deductionsDict = new Dictionary<string, string>();
        IsfilingEnabled = true;
        string getcutoffWeek = cm.GetSpecificDataFromDB("creditWeek", "TBL_CUTOFF", "where id = " + summaryDict["CutoffID"] + "");
        double getempworkdays = 26;
        double workdays = 0;
        try
        {
            workdays = double.TryParse(empDict["emp_WorkDays"], out getempworkdays) ? getempworkdays : 26;
        }
        catch(Exception e)
        {
            string t = "asd";
        }
        
        //bool isMonthly = empDict["emp_PayType"] == "M";
        string EmpPayType = empDict["emp_PayType"];
        string islatedisregardval = "0";
        double sssEC = 0;
        double grosspay =  0; double.TryParse(empDict["emp_BasicPay"], out grosspay);
        double sssded =  0; double.TryParse(empDict["emp_SSSDed"], out sssded);
        double philhded = 0; double.TryParse(empDict["emp_PhilHealthDed"], out philhded);
        double pagibigded =  0; double.TryParse(empDict["emp_PagibigDed"], out pagibigded);
        double allowance = 0; double.TryParse(empDict["emp_BasicAllowance"], out allowance);
        double grosspaygrp = 0;
        double sssdedgrp = 0;
        double sssECgrp = 0;
        double philhdedgrp = 0;
        double pagibigdedgrp = 0;
        double cashadvance = 0;
        double loanbalance = 0;


        double SSSLoanDed = 0;
        double sssER = 0;
        double sssERgrp = 0;
        double philhealthER = 0;
        double philhealthERgrp = 0;
        double pagibigER = 0;
        double pagibigERgrp = 0;

        //07/11/2022 Jan Wong. for Mandatory Provident Fund
        double sssMPFEE = 0, sssMPFER = 0, sssMPFEEgrp = 0, sssMPFERgrp = 0;
        //sssded = tk.GetSSSDed(empDict["emp_BasicPay"]);
        //sssER = tk.GetSSSERContribution(empDict["emp_BasicPay"]);
        //sssEC = tk.GetSSSECContribution(empDict["emp_BasicPay"]);
        //philhded = tk.GetPhilDed(empDict["emp_BasicPay"]);
        //pagibigded = tk.GetPagibigDed(empDict["emp_BasicPay"], out pagibigER);
        pagibigded = 100;
        pagibigER = 100;
        double holidaypay = 0;
        Dictionary<string, string> getCutoffDict = new Dictionary<string, string>();
        getCutoffDict = cm.GetTableDict("TBL_CUTOFF", "where id = " + summaryDict["CutoffID"] + "");
        string getCODate = DateTime.Parse(getCutoffDict["CODate"]).ToString("yyyy-MM-dd");
        bool isEmpML = cm.ItemExist("TBL_MATERNITY", "id", "where EmpID = '" + summaryDict["empid"].ToString() + "' AND '" + getCODate + "' BETWEEN DateFrom AND DateTo");

        double LatesDed = 0;
        //double TotalGovtDed = sssded + philhded + pagibigded;
        double TotalGovtDedpergroup = 0;
        string payrollmode = cm.GetSpecificDataFromDB("payrollmode", "TBL_PAYROLLGRP", "where id =" + empDict["emp_PayrollGroup"] + "");

        double divide = double.Parse(payrollmode);
        grosspaygrp = grosspay / divide;
        double psdays = 0;
        double.TryParse(summaryDict["PSDays"], out psdays);


        //bool ishavepsdays = double.TryParse(summaryDict["PSDays"].ToString(), out psdays);

        //grosspaygrp = grosspay / 26 * psdays;



        if (cm.ItemExist("TBL_CASHADVANCE", "id", "where EmpID = '" + summaryDict["empid"] + "' and CutOffID =" + summaryDict["CutoffID"] + "", ""))
        {
            getCashAdvance(summaryDict["empid"], summaryDict["CutoffID"], out cashadvance, out loanbalance);
        }
        //if (cm.ItemExist("TBL_SSSLOAN", "id", "where EmpID = '" + summaryDict["empid"] + "' and CutOffID =" + summaryDict["CutoffID"] + "", ""))
        //{
        //    getSSSLoan(summaryDict["empid"], summaryDict["CutoffID"], out SSSLoanDed);
        //}




        double perday = 0;
        double permin = 0;
        double perhr = 0;


        double summaryLatesmin = 0; double summarypsabsent = 0;
        double summaryutmin = 0; double summarylatesmin = 0;
        double summaryTotHrs = 0; double summaryOTHrs = 0;
        double summaryoverbreakmin = 0;

        bool isothrs = double.TryParse(summaryDict["OTHrs"].ToString(), out summaryOTHrs);
        bool isutmin = double.TryParse(summaryDict["UTmin"].ToString(), out summaryutmin);
        bool islatesmin = double.TryParse(summaryDict["Latesmin"].ToString(), out summarylatesmin);
        bool istothrs = double.TryParse(summaryDict["TotHrs"].ToString(), out summaryTotHrs);
        bool issummarypsabsentn = double.TryParse(summaryDict["PSabsent"].ToString(), out summarypsabsent);
        bool issummaryOverbreak = double.TryParse(summaryDict["OverBreakMin"].ToString(), out summaryoverbreakmin);

        /*
        if (payrollmode == "4")
            perday = grosspay / workdays;
        //else if (payrollmode == "2")
        //    perday = grosspay * 12 / 313;
        else if (payrollmode == "2")
            perday = grosspay / workdays;

        if (perday != 0)
            permin = perday / 8 / 60;
        if (perday != 0)
            perhr = perday / 8;
            */
        if (EmpPayType == "M" || EmpPayType == "H")
        {
            if (payrollmode == "4")
                perday = grosspay / workdays;
            else if (payrollmode == "2")//07/06/2022 Jan Wong. change to x12 / 313
                perday = grosspay * 12 / 313;
            //else if (payrollmode == "2")
            //    perday = grosspay / workdays;

            if (perday != 0)
                permin = perday / 8 / 60;
            if (perday != 0)
                perhr = perday / 8;
        }
        else
        {
            perday = grosspay / workdays;

            if (perday != 0)
                permin = perday / 8 / 60;
            if (perday != 0)
                perhr = perday / 8;
        }
        double NumberDaysWorked = 0;
        double.TryParse(summaryDict["NumberDaysWorked"], out NumberDaysWorked);


        double overBreakDed = 0;
        //overBreakDed = isMonthly ? summaryoverbreakmin * permin : 0;
        overBreakDed = summaryoverbreakmin * permin;
        double UTDed = (EmpPayType == "M" || EmpPayType == "D") ? summaryutmin * permin : 0;
        LatesDed = (EmpPayType == "M" || EmpPayType == "D") ? summarylatesmin * permin : 0;
        //if (cm.ItemExist("TBL_DTRSETTINGS", "id", " where EmpID = '" + summaryDict["empid"] + "'", ""))
        //{
        //    getIsLatesDisregard(summaryDict["empid"], out islatedisregardval);
        //    {
        //        if (islatedisregardval == "1")
        //        {
        //            LatesDed = 0;
        //        }
        //    }


        //}
        //if (cm.ItemExist("TBL_DEDUCTIONADJ", "id", "where EmpID = '" + summaryDict["empid"] + "' and CutOffID =" + summaryDict["CutoffID"] + "", ""))
        //{
        //    getDeductionAdjustmentLates(summaryDict["empid"], summaryDict["CutoffID"], out LatesDed);
        //}
        //double OTReg = double.Parse(summaryDict["OTReg"]) * permin;

        //bool isMonthly = grosspay > 13962;
        //double absentded = (EmpPayType == "M") ? summarypsabsent * perday : 0;
        double absentded = (EmpPayType == "M" || EmpPayType == "D") ? summarypsabsent * perday : 0;
        double totaldtrdeduction = (EmpPayType == "M" || EmpPayType == "D") ? UTDed + LatesDed + overBreakDed : 0;
        UTDed = (EmpPayType == "M" || EmpPayType == "D") ? UTDed + overBreakDed : 0;
        //double totdayscount = summaryTotHrs / 9;
        double totdayscount = summaryTotHrs / 8;//11/22/2021
                                                //for sv
                                                //double basicpay = grosspay > 13962 ? grosspaygrp : perhr * summaryTotHrs;
                                                //double basicpay = grosspay > 13962 ? grosspaygrp : perday * totdayscount;
                                                //double basicpay = isMonthly ? grosspaygrp : perday * totdayscount;

        /*
         * 09/20/2022
         * Jan
         * New specs for OBT on restday and rate will be regular rate.
         * 
         */
        double RDRP = 0, RDRPothrs = 0;// Rest Day Regular Pay
        RDRP = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "RDRP", out RDRPothrs);

        double basicpay = 0;
        if (EmpPayType == "M")
        {
            basicpay = grosspaygrp + RDRP;
        }
        else if (EmpPayType == "D")
        {
            basicpay = perday * NumberDaysWorked + RDRP;
        }
        else if (EmpPayType == "H")
        {
            basicpay = perhr * summaryTotHrs + RDRP;
        }
        double ecola = 0;
        double.TryParse(empDict["emp_ECOLA"], out ecola);
        //double exacttotdays = Math.Round(totdayscount, MidpointRounding.AwayFromZero);
        double exacttotdays = 0;
        getTotalWorkDays(summaryDict["empid"], summaryDict["CutoffID"], out exacttotdays);
        //double totalecola = !isMonthly ? ecola /26 * exacttotdays : 0;
        double totalecola = !(EmpPayType == "M" || EmpPayType == "D") ? exacttotdays * (ecola / 26) : 0;
        //NEW
        sssded = tk.GetSSSDed(empDict["emp_BasicPay"]);
        sssER = tk.GetSSSERContribution(empDict["emp_BasicPay"]);
        sssEC = tk.GetSSSECContribution(empDict["emp_BasicPay"]);
        philhded = tk.GetPhilDed(empDict["emp_BasicPay"]);
        //sssdedgrp = sssded/ divide;
        sssMPFEE = tk.GetSSSDedMPFEE(empDict["emp_BasicPay"]);
        sssMPFER = tk.GetSSSDedMPFER(empDict["emp_BasicPay"]);

        if (empDict["emp_isEnableContriDed"] == "False")
        {
            sssded = 0;
            sssER = 0;
            sssEC = 0;
            philhded = 0;
            //sssdedgrp = sssded/ divide;
            sssMPFEE = 0;
            sssMPFER = 0;
            pagibigded = 0;
            pagibigER = 0;
        }



        philhdedgrp = philhded / divide / 2;
        pagibigdedgrp = pagibigded / divide;
        pagibigERgrp = pagibigER / divide;
        //sssERgrp = sssER / divide;
        sssERgrp = sssER;
        sssECgrp = sssEC / divide;
        if (getcutoffWeek == "5")
        {
            sssdedgrp = 0;
            philhdedgrp = 0;
            pagibigdedgrp = 0;
            TotalGovtDedpergroup = 0;
            pagibigERgrp = 0;
            sssECgrp = 0;
            sssERgrp = 0;
            sssMPFEE = 0;
            sssMPFER = 0;
        }
        else
        {
            sssdedgrp = sssded / divide;
            sssERgrp = sssER / divide;
            sssECgrp = sssEC / divide;
            pagibigERgrp = pagibigER / divide;
            //philhdedgrp = philhded / divide / 2;
            philhdedgrp = philhded / divide;
            pagibigdedgrp = pagibigded / divide;
            sssMPFEEgrp = sssMPFEE / divide;
            sssMPFERgrp = sssMPFER / divide;
        }

        if (GovDeductionPercentage != "")
        {

            sssdedgrp = sssded * double.Parse(GovDeductionPercentage);
            philhdedgrp = philhded * double.Parse(GovDeductionPercentage) / 2;
            pagibigdedgrp = pagibigded * double.Parse(GovDeductionPercentage);
            sssERgrp = sssER * double.Parse(GovDeductionPercentage);
            pagibigERgrp = pagibigER * double.Parse(GovDeductionPercentage);
            sssMPFEEgrp = sssMPFEE * double.Parse(GovDeductionPercentage);
            sssMPFERgrp = sssMPFER * double.Parse(GovDeductionPercentage);


        }
        if (cm.ItemExist("TBL_DEDUCTIONADJ", "id", "where EmpID = '" + summaryDict["empid"] + "' and CutOffID =" + summaryDict["CutoffID"] + "", ""))
        {
            getDeductionAdjustment(summaryDict["empid"], summaryDict["CutoffID"], sssERgrp, sssdedgrp, philhdedgrp, pagibigdedgrp, out sssERgrp, out sssdedgrp, out philhdedgrp, out pagibigdedgrp);
        }
        if (isGovDeductionDisabled == true)
        {
            sssdedgrp = 0;
            philhdedgrp = 0;
            pagibigdedgrp = 0;
            TotalGovtDedpergroup = 0;
            pagibigERgrp = 0;
            sssECgrp = 0;
            sssERgrp = 0;
            sssMPFEEgrp = 0;
            sssMPFERgrp = 0;
        }
        else
        {
            double sssdedgrpRounded = Math.Round(sssdedgrp,2, MidpointRounding.AwayFromZero);
            double philhdedgrpRounded = Math.Round(philhdedgrp, 2, MidpointRounding.AwayFromZero);
            double pagibigdedgrpRounded = Math.Round(pagibigdedgrp, 2, MidpointRounding.AwayFromZero);
            //TotalGovtDedpergroup = sssdedgrp + philhdedgrp + pagibigdedgrp;
            double sssMDFEEgrpRounded = Math.Round(sssMPFEEgrp, 2, MidpointRounding.AwayFromZero);
            TotalGovtDedpergroup = sssdedgrpRounded + philhdedgrpRounded + pagibigdedgrpRounded + sssMDFEEgrpRounded;
        }

        Dictionary<string, string> valuePairsHoliday = new Dictionary<string, string>();
        //SHholidaypay = computeSpecialHoldayPay(summaryDict["empid"], summaryDict["CutoffID"],"SH",perhr, perday, out valuePairsHoliday);
        //holidaypay = SHholidaypay + LHholidaypay;
        //holidaypay = computeHolidayPay(summaryDict["CutoffID"], perday);
        double NDPay = 0;
        double RDpay = 0; double rdothrs = 0; double RDNDPay = 0; double RDNDHrs = 0;

        double LHP = 0; double LHothrs = 0; double LHNDPay = 0; double LHNDHrs = 0;
        double LHRDpay = 0; double LHRDothrs = 0;
        double WRKLH = 0; double WRKLHothrs = 0;

        double RHpay = 0; double RHothrs = 0; double RHNDpay = 0; double RHNDHrs = 0;
        double RHRDpay = 0; double RHRDothrs = 0;

        double SHP = 0; double SHothrs = 0; double SHNDPay = 0;
        double WRKSH = 0; double WRKSHothrs = 0;
        double SHRDpay = 0; double SHRDothrs = 0; double SHRDNDPay = 0; double SHRDNDHrs = 0;
        double REGOT = 0, RDP = 0, RDLHOT = 0, ND01 = 0, RDOT = 0, LHOT = 0, RDSHP = 0, RDSHOT = 0, SHOT = 0, RHOT = 0, RDLHP = 0;
        double doublegot = 0, doubrstot = 0;
        double SHOTND = 0, SHNDHrs = 0;
        double LHOTND = 0;
        double RDLHOTND = 0; double RDLHNDHrs = 0;

        double WRKSHRD = 0; double WRKSHRDOT = 0; double WRKLHRD = 0; double WRKLHRDOT = 0;

        
        //double SHWOP = 0; double LHWOP = 0; double RHWOP = 0; double noOT = 0;

        double doublh = 0, doublhrd = 0;
        double doublhothrs = 0, doublhrdothrs = 0;

        if(empDict["emp_PayType"] != "M")
        {
            RDpay = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "RDP", out rdothrs);
            LHRDpay = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "LHRD", out LHRDothrs);
            SHRDpay = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "SHRD", out SHRDothrs);
            RHRDpay = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "RHRD", out RHRDothrs);

            //SHWOP = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "SHWOP", out noOT);
            //LHWOP = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "LHWOP", out noOT);
            //RHWOP = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "RHWOP", out noOT);

            LHP = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "LH", out LHothrs);
            SHP = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "SH", out SHothrs);
            RHpay = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRKRH", out RHothrs);

            //08/31/2022 Jan
            doublh = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "DOUBLH", out doublhothrs);
            doublhrd = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "DOUBLHRD", out doublhrdothrs);


            WRKSHRD = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRKSHRD", out WRKSHRDOT);
            WRKLHRD = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRKLHRD", out WRKLHRDOT);
            WRKLH = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRKLH", out WRKLHothrs);
            WRKSH = computeOtherPays(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRKSH", out WRKSHothrs);

            //RDLHOT = getRegOTPay(summaryDict["RDLHOT"] != "" ? double.Parse(summaryDict["RDLHOT"]) : 0, perday);
            RDLHOT = 0; //no formula provided
                        //LHOT = getRegOTPay(summaryDict["LHOT"] != "" ? double.Parse(summaryDict["LHOT"]) : LHothrs, perhr, "LH");
            LHOT = 0; //no formula provided
        }
        


        double sumRegOT = 0, sumRDOT = 0, sumRDSHOT = 0, sumSHOT = 0, sumRHOT = 0, DOUBLEGNDOT = 0, DOUBRSTNDOT = 0;
        double.TryParse(summaryDict["RegOT"], out sumRegOT);
        double.TryParse(summaryDict["RDOT"], out sumRDOT);
        double.TryParse(summaryDict["RDSHOT"], out sumRDSHOT);
        double.TryParse(summaryDict["SHOT"], out sumSHOT);

        #region new_OT
        REGOT = getRegOTPay(summaryDict["RegOT"] != "" ? double.Parse(summaryDict["RegOT"]) : 0, perhr);   //OK 10/05/2021 Jan
        RDOT = getRegOTPay(summaryDict["RDOT"] != "" ? double.Parse(summaryDict["RDOT"]) : 0, perhr, "RDOT"); //OK 10/06/2021 Jan
        RDSHOT = getRegOTPay(summaryDict["RDSHOT"] != "" ? double.Parse(summaryDict["RDSHOT"]) : 0, perhr, "RDSHOT");
        SHOT = getRegOTPay(summaryDict["SHOT"] != "" ? double.Parse(summaryDict["SHOT"]) : 0, perhr, "SHOT");//OK 10/07/2021 Jan
        LHOT = getRegOTPay(summaryDict["LHOT"] != "" ? double.Parse(summaryDict["LHOT"]) : 0, perhr, "LHOT");//OK 10/07/2021 Jan
        SHOTND = getRegOTPay(summaryDict["SHOTND"] != "" ? double.Parse(summaryDict["SHOTND"]) : 0, perhr, "SHOTND");//OK 10/07/2021 Jan
        LHOTND = getRegOTPay(summaryDict["LHOTND"] != "" ? double.Parse(summaryDict["LHOTND"]) : 0, perhr, "LHOTND");//OK 10/07/2021 Jan
        RDLHOT = getRegOTPay(summaryDict["RDLHOT"] != "" ? double.Parse(summaryDict["RDLHOT"]) : 0, perhr, "RDLHOT");//OK 10/07/2021 Jan
        RDLHOTND = getRegOTPay(summaryDict["RDLHOTND"] != "" ? double.Parse(summaryDict["RDLHOTND"]) : 0, perhr, "RDLHOTND"); //OK 10/05/2021 Jan
        SHRDNDPay = getRegOTPay(summaryDict["RDSHOTND"] != "" ? double.Parse(summaryDict["RDSHOTND"]) : 0, perhr, "RDSHOTND");//OK 10/05/2021 Jan
        DOUBLEGNDOT = getRegOTPay(summaryDict["DOUBLEGNDOT"] != "" ? double.Parse(summaryDict["DOUBLEGNDOT"]) : 0, perhr, "DOUBLEGNDOT");
        DOUBRSTNDOT = getRegOTPay(summaryDict["DOUBRSTNDOT"] != "" ? double.Parse(summaryDict["DOUBRSTNDOT"]) : 0, perhr, "DOUBRSTNDOT");
        doublegot = getRegOTPay(summaryDict["DOUBLEGOT"] != "" ? double.Parse(summaryDict["DOUBLEGOT"]) : 0, perhr);
        doubrstot = getRegOTPay(summaryDict["DOUBRSTOT"] != "" ? double.Parse(summaryDict["DOUBRSTOT"]) : 0, perhr);
        //for ND OT
        //SHNDPay = computeNDOTPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "SH", "SHOTND");
        RDNDPay = computeNDOTPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "RDP", "RDOTND");
        NDPay = computeNDOTPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRK", "RegOTND"); //OK 10/05/2021 Jan

        #region for_nonOTNDHrs
        double totalnonOTNDHrs = 0;
        double RDNDP = 0, RDSHNDHrsP = 0, RDLHNDHrsP = 0, LHNDHrsP = 0, SHNDHrsP = 0, RegNDHrsP = 0;
        double doublhnd = 0, doublhrdnd = 0;
        RegNDHrsP = computeRegNDPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRK", "RegNDHrs", "REG ND");//OK 10/05/2021 Jan
        SHNDHrsP = computeRegNDPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRK", "SHNDHrs", "SPE ND");//OK 10/07/2021 Jan
        LHNDHrsP = computeRegNDPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRK", "LHNDHrs", "WLEG ND");//OK 10/07/2021 Jan
        RDLHNDHrsP = computeRegNDPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRK", "RDLHNDHrs", "RST LEG ND");//OK 10/07/2021 Jan
        RDSHNDHrsP = computeRegNDPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRK", "RDSHNDHrs", "RST SPE ND");//OK 10/07/2021 Jan
        RDNDP = computeRegNDPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "RDP", "RDND", "RST ND");//OK 10/05/2021 Jan
        doublhnd = computeRegNDPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "DOUB", "DOUBLEGND", "DOUB LEG ND");
        doublhrdnd = computeRegNDPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "DOUB", "DOUBLEGRSTND", "DOUB LEG RST ND");

        totalnonOTNDHrs = RegNDHrsP + RDNDP + SHNDHrsP + RDSHNDHrsP + LHNDHrsP + doublhnd + doublhrdnd;
        //totalnonOTNDHrs = RDNDP + RDSHNDHrsP + RDLHNDHrsP + LHNDHrsP + SHNDHrsP + RegNDHrsP;
        #endregion for_nonOTNDHrs

        //total for regular ot
        double totalOTpay = 0;
        totalOTpay = REGOT + RDOT + SHOT + RDSHOT + LHOT + RDLHOT + RHOT + doublegot + doubrstot;
        #endregion new_OT
        /*
         //double.TryParse(summaryDict["RegOT"], out sumRHOT);
        REGOT = getRegOTPay(summaryDict["RegOT"] != "" ? double.Parse(summaryDict["RegOT"]) : 0, perhr);//OK
        //RDOT = getRegOTPay(summaryDict["RDOT"] != "" ? double.Parse(summaryDict["RDOT"]) : rdothrs, perhr, "RD"); //OK
        //RDSHOT = getRegOTPay(summaryDict["RDSHOT"] != "" ? double.Parse(summaryDict["RDSHOT"]) : SHRDothrs, perhr, "SHRD");
        //SHOT = getRegOTPay(summaryDict["SHOT"] != "" ? double.Parse(summaryDict["SHOT"]) : SHothrs, perhr, "SH");

        //change rdothrs,SHRDothrs, and RHothrs to 0
        RDOT = getRegOTPay(summaryDict["RDOT"] != "" ? double.Parse(summaryDict["RDOT"]) : 0, perhr, "RD"); //OK
        RDSHOT = getRegOTPay(summaryDict["RDSHOT"] != "" ? double.Parse(summaryDict["RDSHOT"]) : 0, perhr, "SHRD");
        SHOT = getRegOTPay(summaryDict["SHOT"] != "" ? double.Parse(summaryDict["SHOT"]) : 0, perhr, "SH");
        LHOT = getRegOTPay(summaryDict["LHOT"] != "" ? double.Parse(summaryDict["LHOT"]) : 0, perhr, "LH");
        //RHOT = getRegOTPay(summaryDict["SHOT"] != "" ? double.Parse(summaryDict["SHOT"]) : RHothrs, perhr, "RH");
        regND = getND01Pay(summaryDict["NDHrs"] != "" ? double.Parse(summaryDict["NDHrs"]) : 0, perhr);

        //for ND
        SHNDPay = computeNDPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "SH", "SHOTND");
        RDNDPay = computeNDPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "RD", "RDOTND");
        SHRDNDPay = computeNDPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "SHRD", "RDSHOTND");
        NDPay = computeNDPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRK", "RegOTND");
        //#region for_nonOTNDHrs
        double RDNDP = 0, RDSHNDHrsP = 0, RDLHNDHrsP = 0, LHNDHrsP = 0, SHNDHrsP = 0, RegNDHrsP = 0;
        double totalnonOTNDHrs = 0;
        RegNDHrsP = computeRegNDPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRK", "RegNDHrs", "REG ND");//OK 10/05/2021 Jan
        SHNDHrsP = computeRegNDPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRK", "SHNDHrs", "SPE ND");//OK 10/07/2021 Jan
        LHNDHrsP = computeRegNDPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRK", "LHNDHrs", "WLEG ND");//OK 10/07/2021 Jan
        RDLHNDHrsP = computeRegNDPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRK", "RDLHNDHrs", "RST LEG ND");//OK 10/07/2021 Jan
        RDSHNDHrsP = computeRegNDPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "WRK", "RDSHNDHrs", "RST SPE ND");//OK 10/07/2021 Jan
        RDNDP = computeRegNDPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "RDP", "RDND", "RST ND");//OK 10/05/2021 Jan
        totalnonOTNDHrs = RDNDP + RDSHNDHrsP + RDLHNDHrsP + LHNDHrsP + SHNDHrsP + RegNDHrsP;
        //#endregion for_nonOTNDHrs
        */


        //RHNDpay = computeNDPay(summaryDict["empid"], summaryDict["CutoffID"], perhr, "RH", "RegOTND");
        //total for holiday with ot and rd with ot
        double totalOthers = 0;
        double totalLHP = 0;
        double totalSHP = 0;
        totalLHP = LHP + WRKLH + doublh + doublhrd;
        totalSHP = SHP + WRKSH;
        //08/31/2022 Jan. For payroll register
        double sperst = 0, legrst = 0;
        legrst = LHRDpay + WRKLHRD;
        sperst = SHRDpay + WRKSHRD;
        totalOthers = RDpay + LHRDpay + SHRDpay + RHRDpay + LHP + SHP + RHpay + WRKSHRD + WRKLHRD + WRKLH + WRKSH + doublh + doublhrd;

        
        holidaypay = totalLHP + totalSHP;

        //total nd pay
        double totalNDPay = 0;
        totalNDPay = SHNDPay + RDNDPay + SHRDNDPay + NDPay + totalnonOTNDHrs + DOUBLEGNDOT + DOUBRSTNDOT;
        ND01 = totalNDPay;

        double leavepay = 0; double LWPCount = 0;
        double.TryParse(summaryDict["LWP"], out LWPCount);
        //leavepay = computeLeavePay(summaryDict["CutoffID"], summaryDict["empid"], perday);
        //leavepay = LWPCount * perday;//05/27/2022 Jan Wong. change perday to perhour
        leavepay = LWPCount * perhr;
        //double otpay = 0;
        //otpay = computeOTPay(summaryDict["CutoffID"], summaryDict["empid"], perhr, summaryOTHrs, IsfilingEnabled);
        //double ndpay = 0;
        //ndpay = computeND01Pay(summaryDict["empid"], summaryDict["CutoffID"], perhr);

        
        double bonuspay = 0;
        if (cm.ItemExist("TBL_BONUSES", "id", "where EmpID = '" + summaryDict["empid"] + "' and CutOffID ='" + summaryDict["CutoffID"] + "'", ""))
        {
            bonuspay = double.Parse(cm.GetSpecificDataFromDB("BonusPay", "TBL_BONUSES", "where EmpID = '" + summaryDict["empid"] + "' and CutOffID =" + summaryDict["CutoffID"] + ""));
        }
        double thirteenthMonthPay = 0;
        if (cm.ItemExist("TBL_THIRTEENTHMONTH", "id", "where EmpID = '" + summaryDict["empid"] + "' and CutOffID ='" + summaryDict["CutoffID"] + "'", ""))
        {
            thirteenthMonthPay = double.Parse(cm.GetSpecificDataFromDB("thirteenthMonthPay", "TBL_THIRTEENTHMONTH", "where EmpID = '" + summaryDict["empid"] + "' and CutOffID =" + summaryDict["CutoffID"] + ""));
        }
        //05/26/2022 Jan
        double getallowance = 0;
        double perdayallowance = 0;
        double absentdedforallowance = 0;
        double getallowancenumdaysworked = 0;
        if (cm.ItemExist("TBL_ALLOWANCESETTING", "id", "where EmpID = '" + summaryDict["empid"] + "'", ""))
        {
            Dictionary<string, string> getAllowanceSettingDict = new Dictionary<string, string>();
            getAllowanceSettingDict = cm.GetTableDict("TBL_ALLOWANCESETTING", "where EmpID = '" + summaryDict["empid"] + "'");
            


            if (getAllowanceSettingDict["AllowanceFrequency"] == "W4" && getcutoffWeek == "4" && payrollmode == "4")
            {
                
                double.TryParse(getAllowanceSettingDict["AllowanceAmount"], out getallowance);
                if(getAllowanceSettingDict["AllowanceType"] == "2")
                {
                    perdayallowance = (getallowance * 12) / 313;
                    
                    //DateTime dtCOFrom = new DateTime();
                    //DateTime.TryParse(getCutoffDict["COFrom"], out dtCOFrom); 
                    //absentdedforallowance = perdayallowance * getMonthAbsCount(summaryDict["empid"], dtCOFrom.Month.ToString(), dtCOFrom.Year.ToString());
                    absentdedforallowance = perdayallowance * getMonthAbsCount(summaryDict["empid"], getCutoffDict["creditMonth"], getCutoffDict["creditYear"]);
                    getallowance = getallowance - absentdedforallowance;
                    

                }
            }
            else if (getAllowanceSettingDict["AllowanceFrequency"] == "W" && payrollmode == "4")
            {
                double.TryParse(getAllowanceSettingDict["AllowanceAmount"], out getallowance);
                double.TryParse(summaryDict["NumberDaysWorkedWHoliday"], out getallowancenumdaysworked);
                if (getAllowanceSettingDict["AllowanceType"] == "2")
                {
                    //perdayallowance = (getallowance * 12) / 313;
                    perdayallowance = getallowance / getallowancenumdaysworked;
                    //DateTime dtCOFrom = new DateTime();
                    //DateTime.TryParse(getCutoffDict["COFrom"], out dtCOFrom);
                    //Note: hindi pwede mag base ang absent count PSabsent since na fflag as absent si leave.
                    absentdedforallowance = perdayallowance * getCutoffAbsCount(summaryDict["empid"], DateTime.Parse(getCutoffDict["COFrom"]).ToString("yyyy-MM-dd"), DateTime.Parse(getCutoffDict["COTo"]).ToString("yyyy-MM-dd"), summaryDict["CutoffID"],false);
                    getallowance = getallowance - absentdedforallowance;
                }
            }
            else if(getAllowanceSettingDict["AllowanceFrequency"] == "SM" && payrollmode == "2")
            {
                double.TryParse(getAllowanceSettingDict["AllowanceAmount"], out getallowance);
                //getallowance = getallowance / 2;//06/30/2022 Jan Wong
                if (getAllowanceSettingDict["AllowanceType"] == "2")
                {
                    perdayallowance = (getallowance * 12) / 313;
                    //DateTime dtCOFrom = new DateTime();
                    //DateTime.TryParse(getCutoffDict["COFrom"], out dtCOFrom);
                    absentdedforallowance = perdayallowance * getCutoffAbsCount(summaryDict["empid"], DateTime.Parse(getCutoffDict["COFrom"]).ToString("yyyy-MM-dd"), DateTime.Parse(getCutoffDict["COTo"]).ToString("yyyy-MM-dd"), summaryDict["CutoffID"],true);
                    getallowance = (getallowance / 2) - absentdedforallowance;
                    getallowance = getallowance < 0 ? 0 : getallowance;
                }
                else
                    getallowance = getallowance / 2;
            }

        }
        //05/26/2022 Jan
        double AdjustmentAddPay = 0;
        double AdjustmentOthersAddPay = 0;
        double totaladjustmentpay = 0;
        string val1 = "", val2 = "";
        if (cm.ItemExist("TBL_ADJUSTMENT", "id", "where EmpID = '" + summaryDict["empid"] + "' and CutOffID =" + summaryDict["CutoffID"] + "", ""))
        {
            cm.GetTwoDataFromDB("AdjustmentAdd", "AdjustmentOthersAdd", "TBL_ADJUSTMENT", "where EmpID = '" + summaryDict["empid"] + "' and CutOffID =" + summaryDict["CutoffID"] + "", out val1, out val2);
            double.TryParse(val1, out AdjustmentAddPay);
            double.TryParse(val2, out AdjustmentOthersAddPay);
            totaladjustmentpay = AdjustmentAddPay + AdjustmentOthersAddPay;
            //TODO update iscomputed
            //cm.UpdateQueryCommon()
        }
        double PhoneChargesDed = 0;
        double AdvanceLosDed = 0;
        double UniformDed = 0;
        double totalothersdeduction = 0;
        string strPhoneChargesDed = "", strAdvanceLosDed = "", strUniformDed = "";
        if (cm.ItemExist("TBL_OTHERSDEDUCTION", "id", "where EmpID = '" + summaryDict["empid"] + "' and CutOffID =" + summaryDict["CutoffID"] + "", ""))
        {
            cm.GetThreeDataFromDB("PhoneChargesDed", "AdvanceLosDed", "UniformDed", "TBL_OTHERSDEDUCTION", "where EmpID = '" + summaryDict["empid"] + "' and CutOffID =" + summaryDict["CutoffID"] + "", out strPhoneChargesDed, out strAdvanceLosDed, out strUniformDed);
            double.TryParse(strPhoneChargesDed, out PhoneChargesDed);
            double.TryParse(strAdvanceLosDed, out AdvanceLosDed);
            double.TryParse(strUniformDed, out UniformDed);
            totalothersdeduction = PhoneChargesDed + AdvanceLosDed + UniformDed;

            //TODO update iscomputed
            //cm.UpdateQueryCommon()
        }

        #region COMPENSATION
        double CompensationPay = 0;
        double totalcompensationpay = 0;
        string compensationremarks = "", strcompensationpay = "";
        if (cm.ItemExist("TBL_COMPENSATION", "id", "where EmpID = '" + summaryDict["empid"] + "' and CutOffID =" + summaryDict["CutoffID"] + "", ""))
        {
            cm.GetTwoDataFromDB("CompensationPay", "Remarks", "TBL_COMPENSATION", "where EmpID = '" + summaryDict["empid"] + "' and CutOffID =" + summaryDict["CutoffID"] + "", out strcompensationpay, out compensationremarks);
            double.TryParse(strcompensationpay, out CompensationPay);

            totalcompensationpay += CompensationPay;
        }
        #endregion COMPENSATION
        #region TAXREFUND
        double TaxRefundPay = 0;
        double totalTaxRefundPay = 0;
        string taxrefundremarks = "", strTaxRefundPay = "";
        if (cm.ItemExist("TBL_TAXREFUND", "id", "where EmpID = '" + summaryDict["empid"] + "' and CutOffID =" + summaryDict["CutoffID"] + "", ""))
        {
            cm.GetTwoDataFromDB("TaxRefundPay", "Remarks", "TBL_TAXREFUND", "where EmpID = '" + summaryDict["empid"] + "' and CutOffID =" + summaryDict["CutoffID"] + "", out strTaxRefundPay, out taxrefundremarks);
            double.TryParse(strcompensationpay, out TaxRefundPay);

            totalTaxRefundPay += TaxRefundPay;
        }
        #endregion TAXREFUND
        #region Allowance
        //Compute allowance
        double allowanceperday = (allowance / 26);
        double allowancepermin = allowanceperday / 8 / 60;


        double adeductionpermin = summaryLatesmin * allowancepermin;
        double adeductionperday = summarypsabsent * allowanceperday;
        double totalAllowance = (allowance / divide) - (adeductionpermin + adeductionperday);

        allowanceDict = new Dictionary<string, string>();
        allowanceDict.Add("empID", summaryDict["empid"].ToString());
        allowanceDict.Add("cutoffID", summaryDict["CutoffID"].ToString());
        allowanceDict.Add("PayrollGroup", empDict["emp_PayrollGroup"].ToString());
        allowanceDict.Add("allowance", totalAllowance.ToString());
        allowanceDict.Add("allowanceperday", allowanceperday.ToString());
        allowanceDict.Add("allowancepermin", allowancepermin.ToString());
        allowanceDict.Add("adeductionpermin", adeductionpermin.ToString());
        allowanceDict.Add("adeductionperday", adeductionperday.ToString());
        #endregion Allowance

        //06/08/2022 Jan Wong. Leave Monetization
        double LeaveBalanceToMonetize = 0;
        if (IsEnableLeaveMonetization)
        {
            LeaveBalanceToMonetize = computeLeaveMonetization(summaryDict);
            LeaveBalanceToMonetize = LeaveBalanceToMonetize * perday;
        }
        //06/08/2022 Jan Wong. End

        double grossincome = (basicpay + leavepay + bonuspay + thirteenthMonthPay + totalOthers + totalOTpay + totaladjustmentpay + totalcompensationpay + totalTaxRefundPay + totalecola + totalNDPay + getallowance + LeaveBalanceToMonetize) - totaldtrdeduction - absentded; //05/26/2022 Add getallowance Jan Wong.
        //06/09/2022 Jan Wong add LeaveBalanceToMonetize.
        double taxrate = 0;
        //double wtax = computeTax(grossincome.ToString(), out taxrate);

        Dictionary<string, string> loanentries = new Dictionary<string, string>();
        double totalloanpaymentdeduction = 0;
        double CL = 0;//1
        double SSSL = 0;//2
        double PIL = 0;//3
        double PICL = 0;//4
        double SSSCL = 0;//5
        double CA = 0;//6
        bool isHaveDed = true;
        if (isLoanDeductionDisabled == false && empDict["emp_isEnableLoanDed"] == "True")
        {
            if (!isEmpML)
            {
                //if(cm.ItemExist("TBL_LOANPAYMENTHISTORY","id","where EmpID = '"+ summaryDict["empid"].ToString() + "' AND CutOffID = '"+ summaryDict["CutoffID"].ToString() + "'"))
                //{
                //    //totalloanpaymentdeduction = GetLoanDeductionForExisiting(summaryDict, out CL, out SSSL, out PIL, out PICL, out SSSCL);
                //    DeleteLoanDeductionForExisiting(summaryDict);

                //}
                //else
                //{
                DeleteLoanDeductionForExisiting(summaryDict);
                totalloanpaymentdeduction = computeLoanDeduction(empDict, summaryDict, grossincome, TotalGovtDedpergroup, cashadvance, totalothersdeduction, loanselected, out loanentries, out CL, out SSSL, out PIL, out PICL, out SSSCL, out CA,out grossincome, out TotalGovtDedpergroup, out cashadvance, out totalothersdeduction, out isHaveDed);
                if (!isHaveDed)
                {
                    if (isGovDeductionDisabled == false)
                    {
                        sssdedgrp = 0;
                        philhdedgrp = 0;
                        pagibigdedgrp = 0;
                        TotalGovtDedpergroup = 0;
                        pagibigERgrp = 0;
                        sssECgrp = 0;
                        sssERgrp = 0;
                        sssMPFEEgrp = 0;
                        sssMPFERgrp = 0;
                    }
                }

                //}

            }

        }
        else
        {
            //if (cm.ItemExist("TBL_LOANPAYMENTHISTORY", "id", "where EmpID = '" + summaryDict["empid"].ToString() + "' AND CutOffID = '" + summaryDict["CutoffID"].ToString() + "'"))
            //{
            //totalloanpaymentdeduction = GetLoanDeductionForExisiting(summaryDict, out CL, out SSSL, out PIL, out PICL, out SSSCL);
            //DeleteLoanDeductionForExisiting(summaryDict);

            //}
            DeleteLoanDeductionForExisiting(summaryDict);
        }
        

        //double totaldeduction = TotalGovtDedpergroup + absentded + wtax + totalloanpaymentdeduction;
        //double displaytotaldeduction = TotalGovtDedpergroup + totalloanpaymentdeduction;
        if ((grossincome < TotalGovtDedpergroup) || (basicpay <= 0) || (basicpay < TotalGovtDedpergroup))
        {
            sssdedgrp = 0;
            philhdedgrp = 0;
            pagibigdedgrp = 0;
            TotalGovtDedpergroup = 0;
            pagibigERgrp = 0;
            sssECgrp = 0;
            sssERgrp = 0;
            sssMPFEEgrp = 0;
            sssMPFERgrp = 0;
        }
        totalloanpaymentdeduction = Math.Round((Double)totalloanpaymentdeduction, 2);
        double totaldeduction = TotalGovtDedpergroup + totalloanpaymentdeduction;

        double netpay = 0;

        if (isEmpML)
        {
            grossincome = grossincome + totaladjustmentpay;
            netpay = grossincome;

            basicpay = 0;
            LatesDed = 0;
            summarypsabsent = 0;
            absentded = 0;
            leavepay = 0;
            holidaypay = 0;
            totaldtrdeduction = 0;

        }
        else
        {
            netpay = grossincome - totaldeduction - cashadvance - totalothersdeduction;
        }



        //double wtax = computeIncomTax(grossincome,netpay, payrollmode);//08/01/2022 Jan Wong. Disable computeIncomeTax since Appelectric tax is computed manually by their accounting department.
        //double wtax = computeIncomTax(basicpay, netpay, payrollmode);//10/11/2021 Jan
        double wtax = 0;
        double.TryParse(empDict["emp_YTD_WTax"], out wtax);
        if (cm.ItemExist("TBL_DEDUCTIONADJ", "id", "where EmpID = '" + summaryDict["empid"] + "' and CutOffID =" + summaryDict["CutoffID"] + "", ""))
        {
            double.TryParse(cm.GetSpecificDataFromDB("empTax", "TBL_DEDUCTIONADJ", "where EmpID = '" + summaryDict["empid"] + "' and CutOffID =" + summaryDict["CutoffID"] + ""), out wtax);
        }
        totaldeduction += cashadvance + totalothersdeduction + wtax;
        netpay = netpay - wtax;
        //double displayTotDed = totaldeduction + totaldtrdeduction + absentded;
        double displayTotDed = totaldeduction;//02/21/2022 request by ma'am cris
        //double displaygrossincome = grossincome - totaldeduction - cashadvance - totalothersdeduction;


        //totaldeduction += totaldtrdeduction;LatesDed
        deductionsDict.Add("LatesDed", LatesDed.ToString());
        deductionsDict.Add("UTDed", UTDed.ToString());
        deductionsDict.Add("AbsentCount", summarypsabsent.ToString());
        deductionsDict.Add("AbsentDed", absentded.ToString());
        deductionsDict.Add("Leaves", "0");
        //deductionsDict.Add("OTPay", otpay.ToString());
        //deductionsDict.Add("OTPay", REGOT.ToString()); 
        deductionsDict.Add("OTPay", totalOTpay.ToString());
        deductionsDict.Add("OTmin", sumRegOT.ToString());
        deductionsDict.Add("LeavesPay", leavepay.ToString());
        deductionsDict.Add("HolidayPay", holidaypay.ToString());
        deductionsDict.Add("BasicPay", basicpay.ToString());//basicpay/2
        //deductionsDict.Add("GrossPay", grossincome.ToString());//change to displaygross
        deductionsDict.Add("GrossPay", grossincome.ToString());
        deductionsDict.Add("TotDed", displayTotDed.ToString());

        deductionsDict.Add("SSSDed", sssdedgrp.ToString());
        deductionsDict.Add("PhilhealthDed", philhdedgrp.ToString());
        deductionsDict.Add("philhealthER", philhdedgrp.ToString());
        deductionsDict.Add("PagibigDed", pagibigdedgrp.ToString());
        deductionsDict.Add("pagibigER", pagibigERgrp.ToString());
        deductionsDict.Add("NetPay", netpay.ToString());
        deductionsDict.Add("NumDays", psdays.ToString());
        deductionsDict.Add("taxrate", taxrate.ToString());
        deductionsDict.Add("WTax", wtax.ToString());
        deductionsDict.Add("thirteenthmonth", "0.00");
        //deductionsDict.Add("CashAdvance", cashadvance.ToString());
        deductionsDict.Add("CashAdvance", CA.ToString()); 
        deductionsDict.Add("LoanBalance", loanbalance.ToString());
        //for SV
        deductionsDict.Add("SSSLoanDed", SSSLoanDed.ToString());
        deductionsDict.Add("RDLHOT", RDLHOT.ToString());
        deductionsDict.Add("REGOT", REGOT.ToString());
        deductionsDict.Add("RDOT", RDOT.ToString());
        deductionsDict.Add("LHOT", LHOT.ToString());
        deductionsDict.Add("RDSHOT", RDSHOT.ToString());
        deductionsDict.Add("SHOT", SHOT.ToString());

        deductionsDict.Add("RDP", RDpay.ToString());
        deductionsDict.Add("ND01", ND01.ToString());
        //deductionsDict.Add("LHP", LHP.ToString());
        deductionsDict.Add("LHP", totalLHP.ToString());
        deductionsDict.Add("RDSHP", SHRDpay.ToString());
        //deductionsDict.Add("SHP", SHP.ToString());
        deductionsDict.Add("SHP", totalSHP.ToString());
        deductionsDict.Add("RDLHP", LHRDpay.ToString());
        deductionsDict.Add("TotHrs", summaryTotHrs.ToString());
        deductionsDict.Add("sssERgrp", sssERgrp.ToString());
        deductionsDict.Add("sssECgrp", sssECgrp.ToString());
        //deductionsDict.Add("sssERgrp", sssERgrp.ToString());
        deductionsDict.Add("sssMPFERgrp", sssMPFERgrp.ToString());
        deductionsDict.Add("sssMPFEEgrp", sssMPFEEgrp.ToString());

        deductionsDict.Add("RHRDpay", RHRDpay.ToString());

        deductionsDict.Add("CL", CL.ToString());
        deductionsDict.Add("SSSL", SSSL.ToString());
        deductionsDict.Add("PIL", PIL.ToString());
        deductionsDict.Add("PICL", PICL.ToString());
        deductionsDict.Add("SSSCL", SSSCL.ToString());
        deductionsDict.Add("CA", CA.ToString());

        deductionsDict.Add("RDOTmin", sumRDOT.ToString());
        deductionsDict.Add("RDSHOTmin", sumRDSHOT.ToString());
        deductionsDict.Add("SHOTmin", sumSHOT.ToString());

        //10/22/2021
        deductionsDict.Add("ecola", totalecola.ToString());//for ECOLA
        //12/15/2021
        deductionsDict.Add("thirteenthMonthPay", thirteenthMonthPay.ToString());//for thirteenthMonthPay
        //05/26/2022
        deductionsDict.Add("allowance", getallowance.ToString());//for allowance

        //08/31/2022 Jan. for payrollregister 
        deductionsDict.Add("SPERST", sperst.ToString());
        deductionsDict.Add("LEGRST", legrst.ToString());
        deductionsDict.Add("REGND", RegNDHrsP.ToString());
        deductionsDict.Add("RDND", RDNDP.ToString());
        deductionsDict.Add("SPEND", SHNDHrsP.ToString());
        deductionsDict.Add("SPERSTND", RDSHNDHrsP.ToString());
        deductionsDict.Add("LEGND", LHNDHrsP.ToString());
        deductionsDict.Add("LEGRSTND", RDLHNDHrsP.ToString());

        deductionsDict.Add("DOUBLEGND", doublhnd.ToString());
        deductionsDict.Add("DOUBLEGRSTND", doublhrdnd.ToString());
        deductionsDict.Add("DOUBLEGOT", doublegot.ToString());
        deductionsDict.Add("DOUBRSTOT", doubrstot.ToString());

        deductionsDict.Add("REGNDOT", NDPay.ToString());
        deductionsDict.Add("RSTNDOT", RDNDPay.ToString());
        deductionsDict.Add("SPENDOT", SHOTND.ToString());
        deductionsDict.Add("SPERSTNDOT", SHRDNDPay.ToString());
        deductionsDict.Add("LEGNDOT", LHOTND.ToString());
        deductionsDict.Add("LEGRSTNDOT", RDLHOTND.ToString());
        deductionsDict.Add("DOUBLEGNDOT", DOUBLEGNDOT.ToString());
        deductionsDict.Add("DOUBRSTNDOT", DOUBRSTNDOT.ToString());

        deductionsDict.Add("DOUBLH", doublh.ToString());
        deductionsDict.Add("DOUBLHRD", doublhrd.ToString());
        

        deductionsDict.Add("RegularDays", NumberDaysWorked.ToString());






    }
    double getRegOTPay(double RegOTHrs, double perhr)
    {
        return getRegOTPay(RegOTHrs, perhr, "");

    }
    double getRegOTPay(double RegOTHrs, double perhr, string ottype)
    {
        double ret = 0;
        double RegOTPay = 0;
        double otpercent = 1.25;

        if (ottype == "SHOT")
        {
            //perhr = perhr * 1.3;
            //otpercent = 1.30;
            otpercent = 1.69;
        }
        if (ottype == "LHOT")
        {
            otpercent = 2.6;
        }
        if (ottype == "SHOTND")
        {
            //mababa to kasi na compute na sa SHOT yung regular na ot plus nalang ito
            //otpercent = .169;
            otpercent = 1.859;
        }
        if (ottype == "LHOTND")
        {
            otpercent = 2.86;
        }
        if (ottype == "SHNDHrs")
        {
            //10/07/2021
            //mababa din to kasi nacompute na sa SHP yung pinasok niya na regular plus nalang din ito
            otpercent = .43;
        }
        if (ottype == "RD")
        {
            //perhr = perhr * 1.3;
            otpercent = 1.30;
        }
        if (ottype == "SHRD")
        {
            //perhr = perhr * 1.5;
            otpercent = 1.30;
        }
        if (ottype == "RH")
        {
            //perhr = perhr * 2;
            otpercent = 1.30;
        }

        if (ottype == "LH")
        {
            //perhr = perhr * 2;
            otpercent = 2;
        }
        if (ottype == "RDLHOTND")
        {
            //otpercent = 1.118;
            otpercent = 3.718;
        }
        if (ottype == "RDLHOT")
        {
            //otpercent = 0.78;
            otpercent = 3.38;
        }
        if (ottype == "RDOT")
        {
            otpercent = 1.69;
        }
        if (ottype == "RDSHOTND")
        {
            otpercent = 2.145;
        }
        if (ottype == "RDSHOT")
        {
            otpercent = 1.95;
        }
        if (ottype == "DOUBLEGOT")
        {
            otpercent = 3.9;
        }
        if (ottype == "DOUBRSTOT")
        {
            otpercent = 5.07;
        }
        if(ottype == "DOUBLEGNDOT")
        {
            otpercent = 4.29;
        }
        if (ottype == "DOUBRSTNDOT")
        {
            otpercent = 5.577;
        }








        RegOTPay = RegOTHrs * (perhr * otpercent);
        ret = RegOTPay;

        return ret;
    }
    double computeOtherPays(string empID, string cutoffid, double perhr, string otype, out double outOThrs)
    {
        /*
         * rdtype
         * WRK RD - for restday pero pumasok
         * SHRD - for special restday pero pumasok
         * LHRD - for legal pero pumasok
         * RHRD
         * */
        string qry = "Select SUM(TotHrs) as 'TotHrs', Count(id) as 'ItemCOunt' from TBL_DTSAE where EmpID = '" + empID + "' and CutoffID = " + cutoffid + " and Remarks = '" + otype + "' ";
        double totalhrs = 0;
        double rate = 1.3;
        /*
         * 08/08/2022 jan Wong.
         * on the “Holiday Pay” the amount reflected in the payslip is 
         * only the additional 30%, pls. make it Daily Rate + 30%
         */
        if (otype == "SH") rate = 1.3;//1.3 
        else if (otype == "LH") rate = 2.0; //2.0
        else if (otype == "RH") rate = 2.0;//2.0
        else if (otype == "DOUBLH") rate = 3.0; 
        else if (otype == "DOUBLHRD") rate = 3.9;

        else if (otype == "SHRD") rate = 1.5;
        else if (otype == "LHRD") rate = 2.6;
        else if (otype == "RHRD") rate = 2.0;

        else if (otype == "WRKSH") rate = 1.3;//1.3
        else if (otype == "WRKLH") rate = 2.0; //2.0
        else if (otype == "WRKRH") rate = 2.0;//2.0

        else if (otype == "WRKSHRD") rate = 1.5;//1.5
        else if (otype == "WRKLHRD") rate = 2.6;//2.6  //10/07/2021 from .6 to 1.6 kasi hindi naman nacocompute si LHP si WRK lang
        //this is for holidays na walang bayad.
        if (otype == "SHWOP") rate = 0;
        if (otype == "LHWOP") rate = 0;
        if (otype == "RHWOP") rate = 0;
        //this is for leave with holiday

        //test 10/05/2021 - Jan
        if (otype == "RDP") rate = 1.3;//1.3
        else if (otype == "LH") rate = 2.0; //2.0
        else if (otype == "WRKSH") rate = 1.3;//1.3
        else if (otype == "WRKSHRD") rate = 1.5;//1.5
        else if (otype == "WRKLHRD") rate = 2.6;//2.6

        //08/31/2022
        else if (otype == "DOUBLH") rate = 3; // DOUB LEG
        else if (otype == "DOUBLHRD") rate = 3.9; // DOUB LEG RST

        //09/20/2022 Jan
        if (otype == "RDRP") rate = 1;





        double ret = 0;
        double PayCOunt = 0, TotPay = 0, regHrs = 0, OTHrs = 0, TotalOTPay = 0;
        bool isExist = false;

        int schedID = 0;
        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand(qry, conn);
        dread = cmd.ExecuteReader();
        while (dread.Read())
        {
            bool valid = double.TryParse(dread[0].ToString(), out totalhrs);
            valid = double.TryParse(dread[1].ToString(), out PayCOunt);
            isExist = true;
        }
        dread.Close();


        regHrs += (totalhrs > 8 ? 8 : totalhrs);
        OTHrs += (totalhrs > 8 ? (totalhrs - 8) : 0);
        outOThrs = OTHrs;
        conn.Close();
        double rounded = Math.Floor(regHrs * 2) / 2;
        //TotPay = (perhr * RDrate * 8) * RDCounWithDTR;
        if (otype == "LH" || otype == "LHRD")
        {
            if (isExist)
            {
                TotPay = perhr * 8 * PayCOunt;
            }
            else
            {
                TotPay = 0;
            }
        }
        else
        {
            TotPay = perhr * rate * rounded;
        }

        //TotalOTPay = (perhr * rate) * rounded;
        ret = TotPay;
        return ret;

    }
    double computeNDOTPay(string empID, string cutoffid, double perhr, string remarkstype, string sumtype)
    {

        string qry = "Select SUM(" + sumtype + ") as '" + sumtype + "', Count(id) as 'NDCount' from TBL_DTSAE where EmpID = '" + empID + "' and CutoffID = " + cutoffid + " and Remarks like '%" + remarkstype + "%' ";
        double NDtotalhrs = 0;
        double NDpercent = .1;
        double ret = 0;
        double NDCount = 0, TotPay = 0;
        

        if (remarkstype == "SH")
            perhr = perhr * 1.3;
        if (remarkstype == "RD")
            perhr = perhr * 1.3;
        if (remarkstype == "SHRD")
            perhr = perhr * 1.5;
        if (remarkstype == "RH")
            perhr = perhr * 2;
        if (remarkstype == "LH")
            perhr = perhr * 0;
        //if (remarkstype == "WRK")
        //    perhr = perhr * 1.25; change to 1.375

        //Try 10/05/2021 Jan
        if (remarkstype == "WRK")
            perhr = perhr * 1.375;
        //Try 10/06/2021 Jan
        if (remarkstype == "RDP")
            perhr = perhr * 1.859;
        


        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand(qry, conn);
        dread = cmd.ExecuteReader();
        while (dread.Read())
        {
            bool valid = double.TryParse(dread[0].ToString(), out NDtotalhrs);
            valid = double.TryParse(dread[1].ToString(), out NDCount);
        }
        dread.Close();
        conn.Close();

        double rounded = Math.Floor(NDtotalhrs * 2) / 2;
        TotPay = (perhr * NDpercent) * rounded;

        ret = TotPay;
        return ret;

    }
   
    double computeRegNDPay(string empID, string cutoffid, double perhr, string remarkstype, string sumtype,string ratetype)
    {

        string qry = "Select SUM(" + sumtype + ") as '" + sumtype + "', Count(id) as 'NDCount' from TBL_DTSAE where EmpID = '" + empID + "' and CutoffID = " + cutoffid + " and Remarks like '%" + remarkstype + "%'";
        double NDtotalhrs = 0;
        double NDpercent = .1;
        double ret = 0;
        double NDCount = 0, TotPay = 0;



        //if (remarkstype == "WRKSH")
        //    perhr = perhr * 0.43;//1.43
        //if (remarkstype == "WRKLH")
        //    perhr = perhr * 1.2;//2.2
        //if (remarkstype == "WRKLHRD")
        //    perhr = perhr * 1.86;//2.86
        //if (remarkstype == "WRKSHRD")
        //    perhr = perhr * .65;//1.65

        //if (ratetype == "REG ND")
        //    NDpercent = 0.1;
        //if (ratetype == "SPE ND")
        //    perhr = perhr * 1.2;
        //if (ratetype == "WLEG ND")
        //    perhr = perhr * 1.86;
        //if (ratetype == "RST LEG ND")
        //    perhr = perhr * .65;
        //if (ratetype == "RST SPE ND")
        //    perhr = perhr * .65;
        //if (ratetype == "RST ND")
        //    perhr = perhr * .65;

        //Try 10/05/2021
        if (remarkstype == "RDLHNDHrs")
        {
            NDpercent = 0.26;
        }
        if (remarkstype == "RDSHNDHrs")
        {
            NDpercent = 0.15;
        }
        if (remarkstype == "RDND")
        {
            NDpercent = 0.13;
        }
        if (remarkstype == "SHNDHrs")
        {
            NDpercent = 0.13;
        }
        if (remarkstype == "LHNDHrs")
        {
            NDpercent = 0.2;
        }



        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand(qry, conn);
        dread = cmd.ExecuteReader();
        while (dread.Read())
        {
            bool valid = double.TryParse(dread[0].ToString(), out NDtotalhrs);
            valid = double.TryParse(dread[1].ToString(), out NDCount);
        }
        dread.Close();
        conn.Close();

        double rounded = Math.Floor(NDtotalhrs * 2) / 2;
        TotPay = perhr * rounded * NDpercent;

        ret = TotPay;
        return ret;

    }
    public void getIsLatesDisregard(string empno, out string islatedisregard)
    {
        conn = new SqlConnection(connectionstring);
        conn.Open();
        islatedisregard = "0";
        cmd = new SqlCommand("Select * from TBL_DTRSETTINGS where EmpID = '" + empno + "'", conn);
        dread = cmd.ExecuteReader();
        dread.Read();
        if (dread.HasRows)
        {
            if (dread["DisregardLate"] != DBNull.Value)
            {
                islatedisregard = dread["DisregardLate"].ToString();
            }
        }

        dread.Close();
        conn.Close();


    }
    double computeLeavePay(string cutoffid, string empid, double perday)
    {
        double ret = 0;
        double hrs = 0;
        string dtfrom = "", dtto = "";
        
        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand("Select * from TBL_CUTOFF where id = "+ cutoffid + "", conn);
        dread = cmd.ExecuteReader();
        while (dread.Read())
        {
            dtfrom = dread["COFrom"].ToString();
            dtto = dread["COTo"].ToString();
        }
        dread.Close();
        if(dtfrom != "" && dtto != "")
        {
            //DateFrom is the Leave Date
            cmd = new SqlCommand("select * from TBL_LEAVESAPP where EmpID = '"+empid+"' and DateFrom between '"+cm.FormatDateyyyy(dtfrom)+"' and '"+cm.FormatDateyyyy(dtto)+"'", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                hrs += double.Parse(dread["LeaveHours"].ToString());
            }

            dread.Close();
        }

        conn.Close();
        

        //get date range of cutoff from TBL_CUTOFF
        
        //get data from TBL_LEAVESAPP




        double leavepay = perday * (hrs * .125);

        ret = leavepay;
        return ret;

    }
    double getND01Pay(double NDHrs, double perhr)
    {
        double ret = 0;
        double NDHrsPay = 0;
        //NDHrsPay = perhr * (NDHrs * .125);
        NDHrsPay = (perhr * .1) * NDHrs;
        ret = NDHrsPay;

        return ret;
    }
    double computeNDPay(string empID, string cutoffid, double perhr, string remarkstype, string sumtype)
    {

        string qry = "Select SUM(" + sumtype + ") as '" + sumtype + "', Count(id) as 'NDCount' from TBL_DTSAE where EmpID = '" + empID + "' and CutoffID = " + cutoffid + " and Remarks like '%" + remarkstype + "%' ";
        double NDtotalhrs = 0;
        double rate = 1.3;
        double NDpercent = .1;
        double ret = 0;
        double NDCount = 0, TotPay = 0, regHrs = 0, OTHrs = 0, TotalOTPay = 0;
        int schedID = 0;

        if (remarkstype == "SH")
            perhr = perhr * 1.3;
        if (remarkstype == "RD")
            perhr = perhr * 1.3;
        if (remarkstype == "SHRD")
            perhr = perhr * 1.5;
        if (remarkstype == "RH")
            perhr = perhr * 2;
        if (remarkstype == "LH")
            perhr = perhr * 0;
        if (remarkstype == "WRK")
            perhr = perhr * 1.25;

        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand(qry, conn);
        dread = cmd.ExecuteReader();
        while (dread.Read())
        {
            bool valid = double.TryParse(dread[0].ToString(), out NDtotalhrs);
            valid = double.TryParse(dread[1].ToString(), out NDCount);
        }
        dread.Close();
        conn.Close();

        double rounded = Math.Floor(NDtotalhrs * 2) / 2;
        TotPay = (perhr * NDpercent) * rounded;

        ret = TotPay;
        return ret;

    }
    double getCutoffAbsCount(string empID, string cofrom, string coto,string cutoffid, bool isForSemiMonthly)
    {
        double AbsCount = 0;
        //based on month
        //string qry = "Select Count(id) as 'AbsCount' from TBL_DTSAE where (Remarks = 'ABS' or Remarks = 'NO') and EmpID = '" + empID + "' and  Month(BussDate) = "+month+" and Year(BussDate) = "+year+"";

        //based on cutofffrom and cutoffto
        //07/25/2022 Jan Wong. ** Special condition to Aquino and Tapat they are still being paid of 25php for that day 
        string qry = "";
        if(isForSemiMonthly)
        {
            qry = "Select Count(id) as 'AbsCount' from TBL_DTSAE where (Remarks = 'ABS' or Remarks = 'NO') and EmpID = '" + empID + "' and CutoffID = " + cutoffid + " AND (BussDate Between '" + cofrom + "' AND '" + coto + "')";
        }
        else
        {
            qry = "Select Count(id) as 'AbsCount' from TBL_DTSAE where (Remarks = 'ABS' or Remarks = 'NO' or (Remarks like '%LH%' and Remarks like '%WOP%') or (Remarks like '%WOP%' and Remarks like '%SH%')) and EmpID = '" + empID + "' and CutoffID = " + cutoffid + " AND (BussDate Between '" + cofrom + "' AND '" + coto + "')";
        }
        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand(qry, conn);
        dread = cmd.ExecuteReader();
        while (dread.Read())
            double.TryParse(dread[0].ToString(), out AbsCount);
            
        
        dread.Close();
        conn.Close();

        return AbsCount;

    }
    double getMonthAbsCount(string empID, string comonth, string coyear)
    {
        double AbsCount = 0;
        //based on month
        //string qry = "Select Count(id) as 'AbsCount' from TBL_DTSAE where (Remarks = 'ABS' or Remarks = 'NO') and EmpID = '" + empID + "' and  Month(BussDate) = "+month+" and Year(BussDate) = "+year+"";

        //based on cutofffrom and cutoffto
        //07/25/2022 Jan Wong. ** Special condition to Aquino and Tapat they are still being paid of 25php for that day 
        string qry = "Select Count(id) as 'AbsCount' from TBL_DTSAE where (Remarks = 'ABS' or Remarks = 'NO' or (Remarks like '%LH%' and Remarks like '%WOP%') or (Remarks like '%WOP%' and Remarks like '%SH%')) and EmpID = '" + empID + "' AND MONTH(BussDate) = "+comonth+ "   AND YEAR(BussDate) = " + coyear + "";
        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand(qry, conn);
        dread = cmd.ExecuteReader();
        while (dread.Read())
            double.TryParse(dread[0].ToString(), out AbsCount);


        dread.Close();
        conn.Close();

        return AbsCount;

    }
    double computeOTPay(string cutoffid, string empid, double perhr, double OTHrsTimeInOut)
    {
        return computeOTPay(cutoffid, empid, perhr, OTHrsTimeInOut, true);
    }
    double computeOTPay(string cutoffid, string empid, double perhr, double OTHrsTimeInOut, bool IsfilingEnabled)
    {
        double ret = 0;
        double hrs = 0;
        string dtfrom = "", dtto = "";
        if (IsfilingEnabled)
        {
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_CUTOFF where id = " + cutoffid + "", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dtfrom = dread["COFrom"].ToString();
                dtto = dread["COTo"].ToString();
            }
            dread.Close();
            if (dtfrom != "" && dtto != "")
            {

                cmd = new SqlCommand("select * from TBL_OVERTIME where EmpID = '" + empid + "' and OTDate between '" + dtfrom + "' and '" + dtto + "'", conn);
                dread = cmd.ExecuteReader();
                while (dread.Read())
                {
                    double othrs = 0;
                    bool isothrs = double.TryParse(dread["ot_hours"].ToString(), out othrs);
                    hrs += othrs;

                }

                dread.Close();
            }

            conn.Close();
        }
        else
        {
            hrs = OTHrsTimeInOut;
        }

        double otpay = hrs * (perhr * 1.25);
        ret = otpay;
        return ret;

    }
    double computeOTPayOLD(string cutoffid, string empid, double perday)
    {
        double ret = 0;
        double hrs = 0;
        string dtfrom = "", dtto = "";

        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand("Select * from TBL_CUTOFF where id = " + cutoffid + "", conn);
        dread = cmd.ExecuteReader();
        while (dread.Read())
        {
            dtfrom = dread["COFrom"].ToString();
            dtto = dread["COTo"].ToString();
        }
        dread.Close();
        if (dtfrom != "" && dtto != "")
        {
            
            cmd = new SqlCommand("select * from TBL_OVERTIME where EmpID = '" + empid + "' and OTDate between '" + cm.FormatDateyyyy(dtfrom) + "' and '" + cm.FormatDateyyyy(dtto) + "'", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                hrs += double.Parse(dread["ot_hours"].ToString());
            }

            dread.Close();
        }

        conn.Close();
        double otpay = perday * (hrs * .125);
        ret = otpay;
        return ret;

    }
    double computeHoldayPay(string cutoffid,double perday)
    {
        double ret = 0;
        double holidaycount = 0;
        string dtfrom = "", dtto = "";

        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand("Select * from TBL_CUTOFF where id = " + cutoffid + "", conn);
        dread = cmd.ExecuteReader();
        while (dread.Read())
        {
            dtfrom = dread["COFrom"].ToString();
            dtto = dread["COTo"].ToString();
        }
        dread.Close();
        if (dtfrom != "" && dtto != "")
        {
            //DateFrom is the Leave Date
            cmd = new SqlCommand("select count (id) from TBL_HOLIDAY where Holiday between '" + cm.FormatDateyyyy(dtfrom) + "' and '" + cm.FormatDateyyyy(dtto) + "'", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                holidaycount = double.Parse(dread[0].ToString()) * perday;
            }

            dread.Close();
        }

        conn.Close();


        //get date range of cutoff from TBL_CUTOFF

        //get data from TBL_LEAVESAPP




        //double leavepay = perday * (hrs * .125);

        ret = holidaycount;
        return ret;

    }
    double compute13thMonth(string empid)
    {
        double ret = 0;


        return ret;
    }

    double computeTax(string grossincome, out double taxrate)
    {
        double wtax = 0;
        double dgrossincome = double.Parse(grossincome);
        taxrate = 0;
           
        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand("select * from TBL_TAX where " + grossincome + " between GrossIncomeFrom and GrossIncomeTo", conn);
        dread = cmd.ExecuteReader();
        dread.Read();
        if(dread.HasRows)
        {
            taxrate = 0.01 * double.Parse(dread["Taxrate"].ToString());

        }
        dread.Close();
        conn.Close();

        wtax = dgrossincome * taxrate;

        return wtax;
    }

    string getDateCovered(string cutoffid)
    {
        string cdate="";DateTime dtfrom, dtto;
        tk.getCutoffRange(cutoffid, out cdate, out dtfrom, out dtto);
        string covereddate = string.Format(" {0} to {1}", cm.FormatDate(dtfrom), cm.FormatDate(dtto));
        return covereddate;

    }

    public List<Payslip> GetPayslip(string cutoffid, string empno)
    {
        List<Payslip> listps = new List<Payslip>();
        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand("select * from TBL_PAYSLIP where CutoffID = '" + cutoffid + "' and EmployeeID = '" + empno + "'  Order by EmployeeName ASC", conn);
        dread = cmd.ExecuteReader();
        
        while(dread.Read())
        {
            Payslip ps = new Payslip();
            //07/11/2022 Jan Wong. For Mandatory Provident Fund
            double dblsssMPFEE = 0 ,sssded = 0;
            double.TryParse(cm.GetSpecificDataFromDB("sssMPFEE", "TBL_CONTRIBUTION", "where cutoffID = '" + cutoffid + "' AND EmpID = '" + dread["EmployeeID"].ToString() + "'"), out dblsssMPFEE);
            double.TryParse(dread["SSSDed"].ToString(), out sssded);

            ps.empno = dread["EmployeeID"].ToString();
            ps.empname = dread["EmployeeName"].ToString();
            ps.date_covered = dread["DateCovered"].ToString();
            ps.payrollgroup = dread["PayrollGroup"].ToString();
            ps.department = dread["Department"].ToString();
            ps.basicpay = dread["BasicPay"].ToString();
            ps.sss = (sssded + dblsssMPFEE).ToString();
            ps.cash_adv = dread["CashADV"].ToString();
            ps.loanbal = dread["LoanBal"].ToString();
            ps.absentded = dread["AbsentDed"].ToString();
            ps.philhealth = dread["PhilhealthDed"].ToString();
            ps.lates = dread["LatesDed"].ToString();
            ps.pagibig = dread["PagibigDed"].ToString();
            ps.totalgrossincome = dread["GrossPay"].ToString();
            ps.totaldeduction = dread["TotDed"].ToString();
            ps.netpay = dread["NetPay"].ToString();
            //ps.lates = dread["Latesmin"].ToString();
            ps.remainingleavecredit = dread["RemainingLeavesCredit"].ToString();
            ps.leavepay = dread["LeavePay"].ToString();
            ps.utded = dread["UTDed"].ToString();
            ps.otpay = dread["OTPay"].ToString();
            ps.holidaypay = dread["LHWP"].ToString();
            //10/07/2021 Jan
            double adjustmentadd = 0, adjustmentothrsadd = 0;
            string stradjustmentadd = "", stradjustmentothrsadd = "";
            string stradjustmentremarks = "";
            cm.GetThreeDataFromDB("AdjustmentAdd", "AdjustmentOthersAdd","AdjRemarks", "TBL_PAYSLIP A, TBL_ADJUSTMENT B", " where A.CutOffID = B.CutOffID AND A.EmployeeID = B.EmpID AND A.EmployeeID = '" + dread["EmployeeID"].ToString() + "' AND A.CutoffID = '" + cutoffid + "'", out stradjustmentadd, out stradjustmentothrsadd,out stradjustmentremarks);
            double.TryParse(stradjustmentadd, out adjustmentadd);
            double.TryParse(stradjustmentothrsadd, out adjustmentothrsadd);
            ps.adjustment = (adjustmentadd + adjustmentothrsadd).ToString();
            ps.allowance = dread["allowance"].ToString(); //05/26/2022 Jan Wong
            ps.adjustmentremarks = stradjustmentremarks;
            ps.wtax = dread["WTax"].ToString();
            ps.rdp = dread["RDP"].ToString();
            List<string> loanids = new List<string>();
            loanids = cm.GetListDataFromDB("loanEntryID", "TBL_LOANPAYMENTHISTORY", "where EmpID = '" + dread["EmployeeID"].ToString() + "' and CutoffID = '" + cutoffid + "'");
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
                int CAcounter = 1;
                if (loancode == "SSS")
                {
                    ps.SSS += dblloanded;
                    ps.SSSBal += dblloanbal;
                }
                else if (loancode == "PIL")
                {
                    ps.PIL += dblloanded;
                    ps.PILBal += dblloanbal;
                }
                else if (loancode == "PICL")
                {
                    ps.PICL += dblloanded;
                    ps.PICLBal += dblloanbal;
                }
                else if (loancode == "SSSCL")
                {
                    ps.SSSCL += dblloanded;
                    ps.SSSCLBal += dblloanbal;
                }
                else if (loancode == "CA")
                {
                    if (CAcounter == 1)
                    {
                        ps.CA += dblloanded;
                        ps.CABal += dblloanbal;
                    }
                    else if (CAcounter == 2)
                    {
                        ps.CA2 += dblloanded;
                        ps.CABal2 += dblloanbal;
                    }
                    else if (CAcounter == 3)
                    {
                        ps.CA3 += dblloanded;
                        ps.CABal3 += dblloanbal;
                    }
                    CAcounter++;
                }



            }
            listps.Add(ps);

        }
        dread.Close();
        conn.Close();
        return listps;


    }

    public List<Payslip> GetPayslipBulk(string cutoffid)
    {
        List<Payslip> listps = new List<Payslip>();
        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand("select * from TBL_PAYSLIP where CutoffID = '" + cutoffid + "' Order by EmployeeName ASC", conn);
        dread = cmd.ExecuteReader();
        
        
        while (dread.Read())
        {
            Payslip ps = new Payslip();
            //07/11/2022 Jan Wong. For Mandatory Provident Fund
            double dblsssMPFEE = 0, sssded = 0;
            double.TryParse(cm.GetSpecificDataFromDB("sssMPFEE", "TBL_CONTRIBUTION", "where cutoffID = '" + cutoffid + "' AND EmpID = '" + dread["EmployeeID"].ToString() + "'"), out dblsssMPFEE);
            double.TryParse(dread["SSSDed"].ToString(), out sssded);

            ps.empno = dread["EmployeeID"].ToString();
            ps.empname = dread["EmployeeName"].ToString();
            ps.date_covered = dread["DateCovered"].ToString();
            ps.payrollgroup = dread["PayrollGroup"].ToString();
            ps.department = dread["Department"].ToString();
            ps.basicpay = dread["BasicPay"].ToString();
            ps.sss = (sssded + dblsssMPFEE).ToString();
            ps.cash_adv = dread["CashADV"].ToString();
            ps.loanbal = dread["LoanBal"].ToString();
            ps.absentded = dread["AbsentDed"].ToString();
            ps.philhealth = dread["PhilhealthDed"].ToString();
            ps.lates = dread["LatesDed"].ToString();
            ps.pagibig = dread["PagibigDed"].ToString();
            ps.totalgrossincome = dread["GrossPay"].ToString();
            ps.totaldeduction = dread["TotDed"].ToString();
            ps.netpay = dread["NetPay"].ToString();
            //ps.lates = dread["Latesmin"].ToString();
            ps.remainingleavecredit = dread["RemainingLeavesCredit"].ToString();
            ps.leavepay = dread["LeavePay"].ToString();
            ps.utded = dread["UTDed"].ToString();
            ps.otpay = dread["OTPay"].ToString();
            ps.holidaypay = dread["LHWP"].ToString();
            //ps.bonus = dread["Bonus1"].ToString();

            //Jan Wong 12/17/2021
            double adjustmentadd = 0, adjustmentothrsadd = 0;
            string stradjustmentadd = "", stradjustmentothrsadd = "";
            string stradjustmentremarks = "";
            cm.GetThreeDataFromDB("AdjustmentAdd", "AdjustmentOthersAdd", "AdjRemarks", "TBL_PAYSLIP A, TBL_ADJUSTMENT B", " where A.CutOffID = B.CutOffID AND A.EmployeeID = B.EmpID AND A.EmployeeID = '" + dread["EmployeeID"].ToString() + "' AND A.CutoffID = '" + cutoffid + "'", out stradjustmentadd, out stradjustmentothrsadd, out stradjustmentremarks);
            double.TryParse(stradjustmentadd, out adjustmentadd);
            double.TryParse(stradjustmentothrsadd, out adjustmentothrsadd);
            ps.adjustment = (adjustmentadd + adjustmentothrsadd).ToString();
            ps.allowance = dread["allowance"].ToString();
            ps.adjustmentremarks = stradjustmentremarks;
            ps.wtax = dread["WTax"].ToString();
            ps.rdp = dread["RDP"].ToString();

            List<string> loanids = new List<string>();
            loanids = cm.GetListDataFromDB("loanEntryID", "TBL_LOANPAYMENTHISTORY", "where EmpID = '" + dread["EmployeeID"].ToString() + "' and CutoffID = '" + cutoffid + "'");
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
                int CAcounter = 1;
                if (loancode == "SSS")
                {
                    ps.SSS += dblloanded;
                    ps.SSSBal += dblloanbal;
                }
                else if (loancode == "PIL")
                {
                    ps.PIL += dblloanded;
                    ps.PILBal += dblloanbal;
                }
                else if (loancode == "PICL")
                {
                    ps.PICL += dblloanded;
                    ps.PICLBal += dblloanbal;
                }
                else if (loancode == "SSSCL")
                {
                    ps.SSSCL += dblloanded;
                    ps.SSSCLBal += dblloanbal;
                }
                else if (loancode == "CA")
                {
                    if (CAcounter == 1)
                    {
                        ps.CA += dblloanded;
                        ps.CABal += dblloanbal;
                    }
                    else if (CAcounter == 2)
                    {
                        ps.CA2 += dblloanded;
                        ps.CABal2 += dblloanbal;
                    }
                    else if (CAcounter == 3)
                    {
                        ps.CA3 += dblloanded;
                        ps.CABal3 += dblloanbal;
                    }
                    CAcounter++;
                }



            }


            listps.Add(ps);
        }
        dread.Close();
        conn.Close();
        return listps;


    }
    public List<Payslip> GetspecificPayslip(string cutoffid, string empno)
    {
        List<Payslip> listps = new List<Payslip>();
        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand("select * from TBL_PAYSLIP where CutoffID = '" + cutoffid + "' and EmployeeID = '"+empno+"'", conn);
        dread = cmd.ExecuteReader();

        while (dread.Read())
        {
            Payslip ps = new Payslip();
            ps.empno = dread["EmployeeID"].ToString();
            ps.empname = dread["EmployeeName"].ToString();
            ps.date_covered = dread["DateCovered"].ToString();
            ps.payrollgroup = dread["PayrollGroup"].ToString();
            ps.department = dread["Department"].ToString();
            ps.basicpay = dread["BasicPay"].ToString();
            ps.sss = dread["SSSDed"].ToString();
            ps.cash_adv = dread["CashADV"].ToString();
            ps.loanbal = dread["LoanBal"].ToString();
            ps.absentded = dread["AbsentDed"].ToString();
            ps.philhealth = dread["PhilhealthDed"].ToString();
            ps.lates = dread["LatesDed"].ToString();
            ps.pagibig = dread["PagibigDed"].ToString();
            ps.totalgrossincome = dread["GrossPay"].ToString();
            ps.totaldeduction = dread["TotDed"].ToString();
            ps.netpay = dread["NetPay"].ToString();
            //12/17/2021 Jan
            double adjustmentadd = 0, adjustmentothrsadd = 0;
            string stradjustmentadd = "", stradjustmentothrsadd = "";
            string stradjustmentremarks = "";
            cm.GetThreeDataFromDB("AdjustmentAdd", "AdjustmentOthersAdd", "AdjRemarks", "TBL_PAYSLIP A, TBL_ADJUSTMENT B", " where A.CutOffID = B.CutOffID AND A.EmployeeID = B.EmpID AND A.EmployeeID = '" + dread["EmployeeID"].ToString() + "' AND A.CutoffID = '" + cutoffid + "'", out stradjustmentadd, out stradjustmentothrsadd, out stradjustmentremarks);
            double.TryParse(stradjustmentadd, out adjustmentadd);
            double.TryParse(stradjustmentothrsadd, out adjustmentothrsadd);
            ps.adjustment = (adjustmentadd + adjustmentothrsadd).ToString();
            ps.adjustmentremarks = stradjustmentremarks;
            listps.Add(ps);
        }
        dread.Close();
        conn.Close();
        return listps;


    }
    public string toRoundOff(string num)
    {
        return toRoundOff(false, num);
    }
    public string toRoundOff(bool isforpayslip,string num)
    {
        string numtoround = "";
        if (num != null && num != "")
        {
            numtoround = string.Format("{0:#,0.00}", double.Parse(num));
        }
        else
        {
            numtoround = "0.00";
        }
        if(isforpayslip)
        {
            if (numtoround == "0.00")
                numtoround = "-";
        }

        return numtoround;


    }

    #region UPDATE
    public bool UpdateQueryPhilhealth(string fieldToUpdate, string newValue, string tbl)
    {
        Dictionary<string, string> param = new Dictionary<string, string>();
        param.Add(fieldToUpdate, newValue);
        return UpdateQueryPhilhealth(param, tbl);
    }
    /// <summary>
    /// whereCondition = "field = 'value'"
    /// </summary>
    /// <param name="param"></param>
    /// <param name="tbl"></param>
    /// <param name="whereCondition"></param>
    /// <returns></returns>
    public bool UpdateQueryPhilhealth(Dictionary<string, string> param, string tbl)
    {

        try
        {
            string setval = "";
            bool isfirstItem = true;
            foreach (KeyValuePair<string, string> kvp in param)
            {
                setval += (isfirstItem ? "" : ",") + kvp.Key + " = " + kvp.Value;


                isfirstItem = false;
            }
            string base_query = "UPDATE " + tbl + " SET " + setval + "";

            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            cmd.ExecuteNonQuery();

            conn.Close();
            return true;
        }
        catch (Exception e)
        {
            conn.Close();
            return false;
        }
    }
    #endregion UPDATE

    #region READ
    public bool UpdateEmpPhilhealthbulk()
    {
        
        conn = new SqlConnection(connectionstring);
        conn.Open();
        //cmd = new SqlCommand("Select * from TBL_USERS where user_Status='ACTIVE'", conn);
        cmd = new SqlCommand("Select * from TBL_EMPLOYEE_MASTER  where emp_Active !='A'", conn);
        dread = cmd.ExecuteReader();
        while (dread.Read())
        {
            Dictionary<string, string> saveParam()
            {
                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("emp_PhilHealthDed", "" + tk.GetPhilDed(dread["emp_BasicPay"].ToString()) + "");
                



                return param;
            }
            cm.UpdateQueryCommon(saveParam(), "TBL_EMPLOYEE_MASTER", "emp_EmpID = " + dread["emp_EmpID"].ToString() + "");
            
            
        }
        dread.Close();

        conn.Close();
        return true;
    }
    #endregion READ

    #region 13thmonth
    void GetTotalLatesUTAbsDeduction(string empnum,out double TotalLatesDed, out double TotalAbsentDed, out double TotalUndertimeDed)
    {
        TotalLatesDed = 0;
        TotalAbsentDed = 0;
        TotalUndertimeDed = 0;
        SqlConnection conn_fn = new SqlConnection(connectionstring);
        conn_fn.Open();
        SqlDataReader dread_fn;
        SqlCommand cmd1 = new SqlCommand("select SUM(convert(float,LatesDed)) as TotalLatesDed,SUM(convert(float,AbsentDed)) as TotalAbsentDed,SUM(convert(float,UTDed)) as TotalUndertimeDed  from TBL_PAYSLIP A,TBL_CUTOFF B where A.CutoffID = B.id AND A.EmployeeID = '"+empnum+"' AND B.creditYear = '" + cm.dtnow().Year + "'", conn_fn);
        dread_fn = cmd1.ExecuteReader();
        dread_fn.Read();
        if (dread_fn.HasRows)
        {
            double.TryParse(dread_fn["TotalLatesDed"].ToString(), out TotalLatesDed);
            double.TryParse(dread_fn["TotalAbsentDed"].ToString(), out TotalAbsentDed);
            double.TryParse(dread_fn["TotalUndertimeDed"].ToString(), out TotalUndertimeDed);
        }
        dread_fn.Close();
        conn_fn.Close();


    }
    void GetTotalDaysWorked(string empnum, out double TotalDaysWorked)
    {
        TotalDaysWorked = 0;
        
        SqlConnection conn_fn = new SqlConnection(connectionstring);
        conn_fn.Open();
        SqlDataReader dread_fn;
        SqlCommand cmd1 = new SqlCommand("select  Count(A.id) as TotalDaysWorked from TBL_DTSAE A,TBL_CUTOFF B, TBL_PAYSLIP C where A.CutoffID = B.id AND A.CutoffID = C.CutoffID AND (A.Remarks = 'WRK' or A.Remarks = 'OBT' or A.Remarks = 'WRK UA' or A.LWP = 1) AND A.EmpID = '" + empnum+"' AND B.creditYear = '"+cm.dtnow().Year+"'", conn_fn);
        dread_fn = cmd1.ExecuteReader();
        dread_fn.Read();
        if (dread_fn.HasRows)
        {
            double.TryParse(dread_fn["TotalDaysWorked"].ToString(), out TotalDaysWorked);
            
        }
        dread_fn.Close();
        conn_fn.Close();


    }
    #endregion 13thmonth
    public DataTable populateAlphaListReportByCutOffs(List<string> cutoffids)
    {

        string expr = "";
        int i = 0;
        if (cutoffids.Count > 0)
        {
            expr += " where (";
            foreach (string s in cutoffids)
            {
                if (i > 0)
                {
                    expr += " OR ";
                }
                expr += " TBL_CUTOFF.id = " + s + " ";
                i++;
            }
            expr += ") AND TBL_EMPLOYEE_MASTER.emp_PayrollGroup = TBL_CUTOFF.PayrollGroup";
        }

        //expr += cutoff == "" ? "" : "where TBL_CUTOFF.id = " + cutoff + " AND TBL_EMPLOYEE_MASTER.emp_PayrollGroup = TBL_CUTOFF.PayrollGroup";
        string qry = "Select COALESCE(emp_EmpID, 'Grand Total:') AS [Emp. No.]," +
            "COALESCE((emp_Surname + ', ' +emp_FirstName + ' '+emp_MidName), '') as Name," +
            " SUM(CAST(TBL_PAYSLIP.BasicPay as float)) as 'Basic Pay', SUM(CAST(OTPay as float)) as 'Overtime Pay'," +
            "SUM(CAST(ND01 as float)) as 'Night Diff Pay', SUM((CAST(AbsentDed AS float)+ CAST(UTDed AS float)) * -1) as 'Absent/UD'," +
            "SUM(CAST(LeavePay as float)) as 'SL/VL Encash', SUM(CAST(BonusPay as float)) as 'Bonuses'," +
            " SUM(CAST(ecola as float)) as 'ECOLA', '0' as 'ALLOWANCE'," +
            "SUM(CAST(AdjustmentAdd as float)) as 'ADJUSTMENT',SUM(CAST(LHP as float)) as 'LEGAL HOLIDAY'," +
            "SUM(CAST(SHP as float)) as 'SPECIAL HOLIDAY',SUM(CAST(RDP as float)) as 'RESTDAY PREM'," +
            "SUM(CAST(RDSHP as float)) as 'RESTDAY/SPEC',SUM(CAST(RDLHP as float)) as 'RESTDAY/LEGA'," +
            "SUM(CAST(AdjustmentOthersAdd as float)) as 'ADJ - OTHERS',SUM(CAST(GrossPay as float)) as 'Total Income'," +
            "SUM(CAST(SSSDed as float)) as 'SSS  Contrib',SUM(CAST(PhilhealthDed as float)) as 'PHIC Contrib'," +
            "SUM(CAST(PagibigDed as float)) as 'HDMF Contrib',SUM(CAST(WTax as float)) as 'Withheld Tax'," +
            " SUM(CAST(SSSL as float)) as 'SSS LOAN',SUM(CAST(PIL as float)) as 'HDMF LOAN'," +
            "SUM(CAST(UniformDed as float)) as 'UNIFORM',SUM(CAST(CashAdvance as float)) as 'CA/LI/LO/EC'," +
            "SUM(CAST(PhoneChargesDed as float)) as 'PHONE CHARGE',SUM(CAST(TotDed as float)) as 'Tot Deductns'," +
            "SUM(CAST(NetPay as float)) as 'Net Pay',SUM(CAST(sssER as float)) as 'Emplyr SSSER'," +
            "SUM(CAST(CompensationPay as float)) as 'Emp Compnstn'," +
            "SUM(CAST(philhealthER as float)) as 'EmplyrPHICER'," +
            "SUM(CAST(pagibigER as float)) as 'EmplyrHDMFER'" +
            " from TBL_EMPLOYEE_MASTER " +
            "INNer join TBL_PAYSLIP on emp_EmpID = EmployeeID " +
            "inner join TBL_CUTOFF on TBL_PAYSLIP.CutoffID = TBL_CUTOFF.id " +
            "inner join TBL_POSITION on emp_Position = TBL_POSITION.id " +
            "left join TBL_BONUSES on TBL_PAYSLIP.CutoffID = TBL_BONUSES.CutoffID AND TBL_PAYSLIP.EmployeeID = TBL_BONUSES.EmpID " +
            "left join TBL_ALLOWANCE on TBL_PAYSLIP.CutoffID = TBL_ALLOWANCE.CutoffID AND TBL_PAYSLIP.EmployeeID = TBL_ALLOWANCE.EmpID " +
            "left join TBL_ADJUSTMENT on TBL_PAYSLIP.CutoffID = TBL_ADJUSTMENT.CutoffID AND TBL_PAYSLIP.EmployeeID = TBL_ADJUSTMENT.EmpID " +
            "left join TBL_OTHERSDEDUCTION on TBL_PAYSLIP.CutoffID = TBL_OTHERSDEDUCTION.CutoffID AND TBL_PAYSLIP.EmployeeID = TBL_OTHERSDEDUCTION.EmpID " +
            "left join TBL_CASHADVANCE on TBL_PAYSLIP.CutoffID = TBL_CASHADVANCE.CutoffID AND TBL_PAYSLIP.EmployeeID = TBL_CASHADVANCE.EmpID " +
            "left join TBL_CONTRIBUTION on TBL_PAYSLIP.CutoffID = TBL_CONTRIBUTION.cutoffID AND TBL_PAYSLIP.EmployeeID = TBL_CONTRIBUTION.empID " +
            "left join TBL_COMPENSATION on TBL_PAYSLIP.CutoffID = TBL_COMPENSATION.CutoffID AND TBL_PAYSLIP.EmployeeID = TBL_COMPENSATION.EmpID ";
        //if (company != "" || month != "")
        //{
        //    qry += " where";
        //}
        //if (company != "")
        //{
        //    qry += " TBL_EMPLOYEE_MASTER.emp_Assignment = " + company + "";
        //}
        //if (month != "")
        //{
        //    qry += company != "" ? " AND (month(TBL_CUTOFF.COFrom) = " + month + " AND month(TBL_CUTOFF.COTo) = " + month + ") AND (year(TBL_CUTOFF.COFrom) = " + year + " AND year(TBL_CUTOFF.COTo) = " + year + ")" : " (month(TBL_CUTOFF.COFrom) = " + month + " AND month(TBL_CUTOFF.COTo) = " + month + ") AND (year(TBL_CUTOFF.COFrom) = " + year + " AND year(TBL_CUTOFF.COTo) = " + year + ")";
        //}
        if (cutoffids.Count > 0)
        {
            qry += expr;
        }

        qry += " GROUP BY  GROUPING SETS((emp_EmpID ,(emp_Surname + ', ' +emp_FirstName + ' '+emp_MidName)), ())";
        //TBL_PAYSLIP.EmployeeID = '739' AND (month(TBL_CUTOFF.COFrom) = 4 AND month(TBL_CUTOFF.COTo) = 4)

        dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[33] { new DataColumn("Emp. No."),
            new DataColumn("Name"),new DataColumn("Basic Pay"),new DataColumn("Overtime Pay"),
            new DataColumn("Night Diff Pay"),new DataColumn("Absent/UD"),new DataColumn("SL/VL Encash"),
            new DataColumn("Bonuses"), new DataColumn("ECOLA"), new DataColumn("ALLOWANCE"),new DataColumn("ADJUSTMENT"),
            new DataColumn("LEGAL HOLIDAY"),new DataColumn("SPECIAL HOLIDAY"),new DataColumn("RESTDAY PREM"),new DataColumn("RESTDAY/SPEC"),
            new DataColumn("RESTDAY/LEGA"),new DataColumn("ADJ - OTHERS"),new DataColumn("Total Income"),new DataColumn("SSS  Contrib"),
            new DataColumn("PHIC Contrib"),new DataColumn("HDMF Contrib"),new DataColumn("Withheld Tax"),new DataColumn("SSS LOAN"),
            new DataColumn("HDMF LOAN"),new DataColumn("UNIFORM"),new DataColumn("CA/LI/LO/EC"),new DataColumn("PHONE CHARGE"),
            new DataColumn("Tot Deductns"),new DataColumn("Net Pay"),new DataColumn("Emplyr SSSER"),new DataColumn("Emp Compnstn"),
            new DataColumn("EmplyrPHICER"),new DataColumn("EmplyrHDMFER")});

        //dt.Columns.AddRange(new DataColumn[27] { new DataColumn("Emp. No."),
        //    new DataColumn("EmpName"),new DataColumn("Basic Pay"),new DataColumn("Overtime Pay"),
        //    new DataColumn("Night Diff Pay"),new DataColumn("Absent/UD"),new DataColumn("SL/VL Encash"),
        //    new DataColumn("Bonuses"), new DataColumn("ECOLA"), new DataColumn("ALLOWANCE"),new DataColumn("ADJUSTMENT"),
        //    new DataColumn("LEGAL HOLIDAY"),new DataColumn("SPECIAL HOLIDAY"),new DataColumn("RESTDAY PREM"),new DataColumn("RESTDAY/SPEC"),
        //    new DataColumn("RESTDAY/LEGA"),new DataColumn("ADJ - OTHERS"),new DataColumn("Total Income"),new DataColumn("SSS  Contrib"),
        //    new DataColumn("PHIC Contrib"),new DataColumn("HDMF Contrib"),new DataColumn("Withheld Tax"),new DataColumn("SSS LOAN"),
        //    new DataColumn("HDMF LOAN"),new DataColumn("UNIFORM"),new DataColumn("CA/LI/LO/EC"),new DataColumn("PHONE CHARGE")});

        //,new DataColumn("CA/LI/LO/EC")
        conn = new SqlConnection(connectionstring);
        conn.Open();

        //cmd = new SqlCommand("Select * from TBL_USERS where user_Status='ACTIVE'", conn);
        cmd = new SqlCommand(qry, conn);
        dread = cmd.ExecuteReader();
        while (dread.Read())
        {
            dt.Rows.Add(dread["Emp. No."].ToString(), dread["Name"].ToString(), dread["Basic Pay"].ToString(),
                dread["Overtime Pay"].ToString(), dread["Night Diff Pay"].ToString(),
                dread["Absent/UD"].ToString(), dread["SL/VL Encash"].ToString(), dread["Bonuses"].ToString(),
                dread["ECOLA"].ToString(), dread["ALLOWANCE"].ToString(), dread["ADJUSTMENT"].ToString(),
                dread["LEGAL HOLIDAY"].ToString(), dread["SPECIAL HOLIDAY"].ToString(), dread["RESTDAY PREM"].ToString(),
                dread["RESTDAY/SPEC"].ToString(), dread["RESTDAY/LEGA"].ToString(), dread["ADJ - OTHERS"].ToString(),
                dread["Total Income"].ToString(), dread["SSS  Contrib"].ToString(), dread["PHIC Contrib"].ToString(),
                dread["HDMF Contrib"].ToString(), dread["Withheld Tax"].ToString(), dread["SSS LOAN"].ToString(),
                dread["HDMF LOAN"].ToString(), dread["UNIFORM"].ToString(), dread["CA/LI/LO/EC"].ToString(),
                dread["PHONE CHARGE"].ToString(), dread["Tot Deductns"].ToString(), dread["Net Pay"].ToString(),
                dread["Emplyr SSSER"].ToString(), dread["Emp Compnstn"].ToString(), dread["EmplyrPHICER"].ToString(),
                dread["EmplyrHDMFER"].ToString());

            }
        dread.Close();

        conn.Close();
        return dt;
    }
    void DeleteLoanDeductionForExisiting(Dictionary<string, string> summaryDict)
    {
        try
        {
            conn = new SqlConnection(connectionstring);
            conn.Close();
            conn.Open();
            cmd = new SqlCommand("Select A.id as [PaymentID],A.amountPaid as [PaymentAmountPaid],B.LoanCode, B.id as [LoanID],B.amountPaid as [LoanAmountPaid], B.Balance as [LoanBalance] from TBL_LOANPAYMENTHISTORY A, TBL_LOANENTRIES B where A.EmpID = '" + summaryDict["empid"].ToString() + "' AND CutOffID = '" + summaryDict["CutoffID"].ToString() + "' AND A.loanEntryID = B.id", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {

                Dictionary<string, string> paramloanentries = new Dictionary<string, string>();
                double PaymentAmountPaid = 0;
                double LoanAmountPaid = 0;
                double LoanBalance = 0;
                double TotalLoanAmountPaid = 0;
                double TotalLoanBalance = 0;
                double.TryParse(dread["PaymentAmountPaid"].ToString(), out PaymentAmountPaid);
                double.TryParse(dread["LoanAmountPaid"].ToString(), out LoanAmountPaid);
                double.TryParse(dread["LoanBalance"].ToString(), out LoanBalance);
                TotalLoanAmountPaid = LoanAmountPaid - PaymentAmountPaid;
                TotalLoanBalance = LoanBalance + PaymentAmountPaid;
                paramloanentries.Add("amountPaid", "" + TotalLoanAmountPaid.ToString() + "");//minus dito
                paramloanentries.Add("Balance", "" + TotalLoanBalance.ToString() + "");//add dito
                cm.UpdateQueryCommon(paramloanentries, "TBL_LOANENTRIES", "id = " + dread["LoanID"].ToString() + "");
                cm.DeleteQuery("TBL_LOANPAYMENTHISTORY", " where id = " + dread["PaymentID"].ToString() + "");
            }
            dread.Close();
            conn.Close();
        }
        finally
        {
            conn.Close();
        }

    }
    double computeLoanDeduction(Dictionary<string, string> empDict, Dictionary<string, string> summaryDict, double grossincome, double TotalGovtDedpergroup, double cashadvance, double totalothersdeduction, List<string> loanselected, out Dictionary<string, string> loanentries, out double CL, out double SSS, out double PIL, out double PICL, out double SSSCL,out double CA, out double outgrossincome, out double outTotalGovtDedpergroup, out double outcashadvance, out double outtotalothersdeduction, out bool isHaveGovDed)
    {
        isHaveGovDed = true;
        outgrossincome = 0;
        outTotalGovtDedpergroup = 0;
        outcashadvance = 0;
        outtotalothersdeduction = 0;
        CL = 0;//1
        SSS = 0;//2
        PIL = 0;//3
        PICL = 0;//4
        SSSCL = 0;//5
        CA = 0;//6
        bool isloanpaymentexist = false;
        loanentries = new Dictionary<string, string>();
        double totalLoanDeduction = 0;
        double subfinaldeduction = 0;
        DateTime dtfrom = new DateTime(), dtto = new DateTime();

        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand("Select * from TBL_CUTOFF where id = " + summaryDict["CutoffID"] + "", conn);
        dread = cmd.ExecuteReader();
        while (dread.Read())
        {
            dtfrom = DateTime.Parse(dread["COFrom"].ToString());
            dtto = DateTime.Parse(dread["COTo"].ToString());
        }
        dread.Close();

        /*
         * 
         * 10/21/2021 Jan Wong
         * check loan selected
         * 
         */
        string getLoanCode = "";
        int counter = 0;
        if (loanselected.Count > 0)
        {
            getLoanCode += " AND (";
            foreach (string loancode in loanselected)
            {
                if (counter >= 1)
                {
                    getLoanCode += " OR ";
                }
                counter++;
                getLoanCode += " LoanCode = '" + loancode + "' ";

            }
            getLoanCode += " )";
        }
        cmd = new SqlCommand("Select id, DedAmount,LoanCode from TBL_LOANENTRIES where EmpID = '" + summaryDict["empid"] + "' and Loan_Status = '1' " + getLoanCode + " ", conn);
        dread = cmd.ExecuteReader();
        while (dread.Read())
        {
            //loanentries.Add(dread[0].ToString(), dread[1].ToString());
            double loanbalance = 0; double dedamount = 0;
            bool isdedamount = double.TryParse(dread[1].ToString(), out dedamount);
            bool isloanbalance = double.TryParse(cm.GetSpecificDataFromDB("Balance", "TBL_LOANENTRIES", "where id = " + dread[0].ToString() + ""), out loanbalance);
            if (loanbalance <= 0)
            {
                continue;
            }
            double getfinaldeduction = loanbalance < dedamount ? loanbalance : dedamount;
            subfinaldeduction += getfinaldeduction;
            if (subfinaldeduction > grossincome)
            {
                totalLoanDeduction += 0;
            }
            else if (subfinaldeduction <= grossincome)
            {

                if (dread[2].ToString() == "1")
                    CL += getfinaldeduction;
                else if (dread[2].ToString() == "2")
                    SSS += getfinaldeduction;
                else if (dread[2].ToString() == "3")
                    PIL += getfinaldeduction;
                else if (dread[2].ToString() == "4")
                    PICL += getfinaldeduction;
                else if (dread[2].ToString() == "5")
                    SSSCL += getfinaldeduction;
                else if (dread[2].ToString() == "6")
                    CA += getfinaldeduction;

                getfinaldeduction = Math.Round(getfinaldeduction, 2, MidpointRounding.AwayFromZero); //06/27/2022 Jan Wong
                totalLoanDeduction += getfinaldeduction;
                loanentries.Add(dread[0].ToString(), getfinaldeduction.ToString());
            }




        }
        dread.Close();

        conn.Close();

        if (grossincome - TotalGovtDedpergroup - totalothersdeduction - cashadvance - totalLoanDeduction < 0)
        {
            CL = 0;
            SSS = 0;
            PIL = 0;
            PICL = 0;
            SSSCL = 0;
            CA = 0;
            totalLoanDeduction = 0;
            outgrossincome = 0;
            outTotalGovtDedpergroup = 0;
            outtotalothersdeduction = 0;
            outcashadvance = 0;
            isHaveGovDed = false;

        }
        else
        {
            isHaveGovDed = true;
            outgrossincome = grossincome;
            outTotalGovtDedpergroup = TotalGovtDedpergroup;
            outtotalothersdeduction = totalothersdeduction;
            outcashadvance = cashadvance;
            UpdateLoanHistory(summaryDict, loanentries);
        }



        return totalLoanDeduction;


    }
    void UpdateLoanHistory(Dictionary<string, string> summaryDict, Dictionary<string, string> loanentries)
    {

        foreach (KeyValuePair<string, string> kvp in loanentries)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            Dictionary<string, string> paramloanentries = new Dictionary<string, string>();
            param.Add("loanEntryID", kvp.Key);
            param.Add("CutoffID", "'" + summaryDict["CutoffID"] + "'");
            param.Add("EmpID", "'" + summaryDict["empid"] + "'");

            param.Add("DateTrans", "'" + cm.FormatDate(cm.dtnow()) + "'");//ayusing to

            bool IsFirstPayment = !cm.ItemExist("TBL_LOANPAYMENTHISTORY", "id", "where loanEntryID = " + kvp.Key + "");
            double currentbal = 0, afterbal = 0, amountded = 0;
            double currentamountpaid = 0; double afteramountpaid = 0;
            if (!cm.ItemExist("TBL_LOANPAYMENTHISTORY", "id", "where CutoffID = '" + summaryDict["CutoffID"] + "' AND EmpID = '" + summaryDict["empid"] + "' AND loanEntryID = " + kvp.Key + ""))
            {
                if (IsFirstPayment)
                {
                    string loanamount = cm.GetSpecificDataFromDB("Balance", "TBL_LOANENTRIES", "where id = " + kvp.Key + "");
                    double.TryParse(loanamount, out currentbal);
                    string stramountpaid = cm.GetSpecificDataFromDB("AmountPaid", "TBL_LOANENTRIES", "where id = " + kvp.Key + "");
                    double.TryParse(stramountpaid, out currentamountpaid);
                }
                else
                {
                    //Dictionary<string, string> histdict = cm.GetTableDict("TBL_LOANPAYMENTHISTORY", "where loanEntryID = " + kvp.Key + " order by  DateTrans desc");

                    //double.TryParse(histdict["afterpaymentbal"], out currentbal);
                    //change to Balance from TBL_LOANENTRIES. kasi what if mag update sila ng Balance.. hindi na dapat kukuha sa afterpaymentbal
                    string loanamount = cm.GetSpecificDataFromDB("Balance", "TBL_LOANENTRIES", "where id = " + kvp.Key + "");
                    double.TryParse(loanamount, out currentbal);
                    string stramountpaid = cm.GetSpecificDataFromDB("AmountPaid", "TBL_LOANENTRIES", "where id = " + kvp.Key + "");
                    double.TryParse(stramountpaid, out currentamountpaid);
                }

                double.TryParse(kvp.Value, out amountded);
                if (amountded > currentbal)
                    amountded = currentbal;

                afterbal = currentbal - amountded;

                param.Add("amountPaid", amountded.ToString());
                param.Add("beforepaymentbal", currentbal.ToString());
                param.Add("afterpaymentbal", afterbal.ToString());
                cm.InsertQueryCommon(param, "TBL_LOANPAYMENTHISTORY");

                //for updating TBL_LOANENTRIES
                afteramountpaid = currentamountpaid + amountded;
                paramloanentries.Add("Balance", afterbal.ToString());
                paramloanentries.Add("AmountPaid", afteramountpaid.ToString());
                cm.UpdateQueryCommon(paramloanentries, "TBL_LOANENTRIES", "id = " + kvp.Key + "");
            }
        }//end of foreach

    }
    //06/08/2022 Jan Wong
    void UpdateLeaveToPayHistory( Dictionary<string, string> LeaveMonetizeEntries)
    {
        foreach (KeyValuePair<string, string> kvp in LeaveMonetizeEntries)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("isPaid", "Y");
            param.Add("cutoffID", "'"+ kvp.Value+ "'");
            cm.UpdateQueryCommon(param, "TBL_LEAVETOPAY", "id = " + kvp.Key + "");
            
        }//end of foreach

    }
    public void getTotalWorkDays(string empno, string cutoff_id, out double totwrkdays)
    {
        conn = new SqlConnection(connectionstring);
        conn.Open();
        totwrkdays = 0;
        cmd = new SqlCommand("Select COUNT(id) as totwrkdays from TBL_DTSAE where EmpID = '" + empno + "' and CutOffID =" + cutoff_id + " AND (Remarks like '%WRK%' or Remarks = 'LH' or Remarks = 'SH' or Remarks = 'RDP')", conn);
        dread = cmd.ExecuteReader();
        dread.Read();
        if (dread.HasRows)
        {
            double.TryParse(dread["totwrkdays"].ToString(), out totwrkdays);
        }

        dread.Close();
        conn.Close();


    }
    public void getDeductionAdjustment(string empno, string cutoff_id, double ssser, double sss, double phil, double pagibig, out double ssserded, out double sssded, out double philded, out double pagibigded)
    {

        conn = new SqlConnection(connectionstring);
        conn.Open();
        ssserded = ssser; sssded = sss; philded = phil; pagibigded = pagibig;
        cmd = new SqlCommand("Select * from TBL_DEDUCTIONADJ where EmpID = '" + empno + "' and CutOffID =" + cutoff_id + "", conn);
        dread = cmd.ExecuteReader();
        dread.Read();
        if (dread.HasRows)
        {
            if (dread["sssER"] != DBNull.Value)
            {
                ssserded = double.Parse(dread["sssER"].ToString());
            }
            if (dread["SSSDed"] != DBNull.Value)
            {
                sssded = double.Parse(dread["SSSDed"].ToString());
            }
            if (dread["PhilDed"] != DBNull.Value)
            {
                philded = double.Parse(dread["PhilDed"].ToString());
            }
            if (dread["PagibigDed"] != DBNull.Value)
            {
                pagibigded = double.Parse(dread["PagibigDed"].ToString());
            }






        }

        dread.Close();
        conn.Close();


    }
    double computeIncomTax(double grossincome, double netpay, string payrollgroup)
    {
        double wtax = 0;
        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand("select TOP 1 * from TBL_INCOMETAX where " + grossincome.ToString() + " between GrossIncomeFrom and GrossIncomeTo AND PayrollGroup = '" + payrollgroup + "' AND YearEffective = '" + cm.dtnow().Year + "' ORDER BY id desc", conn);
        dread = cmd.ExecuteReader();
        dread.Read();
        if (dread.HasRows)
        {
            wtax = 0;
            double WtaxOver = 0;
            double WTaxAdd = 0;
            double WTaxRate = 0;
            double.TryParse(dread["PrescribedWTaxOver"].ToString(), out WtaxOver);
            double.TryParse(dread["PrescribedWTaxAdd"].ToString(), out WTaxAdd);
            double.TryParse(dread["PrescribedWTaxRate"].ToString(), out WTaxRate);

            wtax = WTaxAdd + ((netpay - WtaxOver) * WTaxRate);

        }
        dread.Close();
        conn.Close();



        return wtax;
    }
    bool HasDuplicate_Allowance_Entry(string empno, string cutoffid)
    {
        bool isduplicate = false;
        string qry = "Select * from TBL_ALLOWANCE where empID = '" + empno + "' and cutoffID = '" + cutoffid + "'";
        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand(qry, conn);
        dread = cmd.ExecuteReader();
        dread.Read();
        if (dread.HasRows)
            isduplicate = true;

        dread.Close();
        conn.Close();


        return isduplicate;
    }
    //06/08/2022 Jan Wong
    double computeLeaveMonetization(Dictionary<string, string> summaryDict)
    {
        double totalLeaveMonetize = 0;
        Dictionary<string,string> LeaveMonetizeEntries = new Dictionary<string, string>();
        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand("Select id, EmpID,LeaveBalance,creditYear,isPaid from TBL_LEAVETOPAY where EmpID = '" + summaryDict["empid"] + "' and creditYear = '"+cm.dtnow().Year.ToString()+"' ", conn);
        dread = cmd.ExecuteReader();
        while (dread.Read())
        {
            bool isPaid = dread[4].ToString() == "N" ? false : true;
            if(isPaid)
            {
                continue;
            }
            double LeaveBalance = 0;
            double.TryParse(dread[2].ToString(), out LeaveBalance);
            totalLeaveMonetize += LeaveBalance;
            LeaveMonetizeEntries.Add(dread[0].ToString(), summaryDict["CutoffID"]);
        }
        dread.Close();
        conn.Close();
        UpdateLeaveToPayHistory(LeaveMonetizeEntries);

        return totalLeaveMonetize;


    }


    public Document genPayslip(Document doc, List<Payslip> pdffields)
    {
        //Common cm = new Common();
        BaseFont font = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
        BaseFont font1 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, false);
        BaseFont font2 = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, false);
        Font f1 = new Font(font, 8, 0, BaseColor.BLACK);
        Font f2 = new Font(font1, 15, 0, BaseColor.BLACK);
        Font f3 = new Font(font, 7, 0, BaseColor.BLACK);
        Font f4 = new Font(font2, 17, 0, BaseColor.GRAY);
        Font f5 = new Font(font, 9, 0, BaseColor.BLACK);
        Font f6 = new Font(font1, 9, 0, BaseColor.BLACK);
        Font f7 = new Font(font1, 9, 0, BaseColor.WHITE);
        int counter = 0;
        if (pdffields.Count > 0)
        {

            doc.Open();
            foreach (Payslip ps in pdffields)
            {
                counter++;

                //tableheader.SpacingBefore = 10f;

                if (counter == 4)
                {
                    doc.NewPage();
                    counter = 1;
                }

                PdfPTable table = new PdfPTable(2);
                table.WidthPercentage = 100;

                PdfPTable table1 = new PdfPTable(3);
                table1.SetWidths(new float[] { 30f, 30f, 30f });
                table1.WidthPercentage = 100;

                PdfPTable tableinfo1 = new PdfPTable(2);
                tableinfo1.WidthPercentage = 100;

                PdfPTable tableinfo2 = new PdfPTable(2);
                tableinfo2.WidthPercentage = 100;

                PdfPTable tableinfo3 = new PdfPTable(3);
                tableinfo3.WidthPercentage = 100;

                PdfPTable tabletot = new PdfPTable(6);
                tabletot.WidthPercentage = 100;
                ////iTextSharp.text.Image myImage1 = iTextSharp.text.Image.GetInstance(imgpath + "/Resources/logo2.png");

                Paragraph header1 = new Paragraph();
                Chunk h1 = new Chunk("APP ELECTRIC CORP");
                h1.Font = f3;
                header1.Add(h1);

                PdfPCell cell1 = new PdfPCell(header1);
                cell1.HorizontalAlignment = Element.ALIGN_LEFT;
                cell1.Colspan = 2;
                cell1.Border = 0;
                cell1.PaddingTop = 0f;
                table.AddCell(cell1);

                Paragraph header2 = new Paragraph();
                Chunk h2 = new Chunk(ps.empno + " " + ps.empname);
                h2.Font = f3;
                header2.Add(h2);

                PdfPCell cell2 = new PdfPCell(header2);
                cell2.HorizontalAlignment = Element.ALIGN_LEFT;
                cell2.Colspan = 2;
                cell2.Border = 0;
                cell2.PaddingTop = 0f;
                table.AddCell(cell2);

                Paragraph header3 = new Paragraph();
                Chunk h3 = new Chunk("Date Covered: " + ps.date_covered + Environment.NewLine);
                Chunk h4 = new Chunk("Payroll Group: " + ps.payrollgroup + Environment.NewLine);
                Chunk h5 = new Chunk("Department: " + ps.department);
                h3.Font = f3;
                h4.Font = f3;
                h5.Font = f3;
                header3.Add(h3);
                header3.Add(h4);
                header3.Add(h5);

                PdfPCell cell3 = new PdfPCell(header3);
                cell3.HorizontalAlignment = Element.ALIGN_LEFT;
                cell3.Colspan = 2;
                cell3.Border = 0;
                cell3.PaddingTop = 0f;
                cell3.PaddingLeft = 450f;
                table.AddCell(cell3);

                //Chunk c1 = new Chunk("Employee ID:          931231" + Environment.NewLine);
                //Chunk c2 = new Chunk("Employee Name:        EMP NAME" + Environment.NewLine);
                //Chunk c3 = new Chunk("Period Cover:         JUL 01, 2021 TO JUL 15, 2021");
                PdfPCell cell4 = new PdfPCell();
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.Border = 0;
                cell4.PaddingTop = 0f;
                tableinfo1.AddCell(cell4);

                Paragraph p1 = new Paragraph();
                Chunk c1 = new Chunk("Amount");
                c1.Font = f3;
                p1.Add(c1);

                PdfPCell cell5 = new PdfPCell(p1);
                cell5.HorizontalAlignment = Element.ALIGN_LEFT;
                cell5.Border = 0;
                cell5.PaddingTop = 0f;
                tableinfo1.AddCell(cell5);

                Paragraph p2 = new Paragraph();
                Chunk c2 = new Chunk("Basic Pay");
                c2.Font = f3;
                p2.Add(c2);

                PdfPCell cell6 = new PdfPCell(p2);
                cell6.HorizontalAlignment = Element.ALIGN_LEFT;
                cell6.Border = 0;
                cell6.PaddingTop = 0f;
                tableinfo1.AddCell(cell6);

                Paragraph p3 = new Paragraph();
                Chunk c3 = new Chunk(toRoundOff(ps.basicpay));
                c3.Font = f3;
                p3.Add(c3);

                PdfPCell cell7 = new PdfPCell(p3);
                cell7.HorizontalAlignment = Element.ALIGN_LEFT;
                cell7.Border = 0;
                cell7.PaddingTop = 0f;
                tableinfo1.AddCell(cell7);

                if (ps.rdp != "0" && ps.rdp != "")
                {
                    Paragraph p4 = new Paragraph();
                    Chunk c4 = new Chunk("Restday Pay");
                    p4.Font = f3;
                    p4.Add(c4);

                    PdfPCell cell8 = new PdfPCell(p4);
                    cell8.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell8.Border = 0;
                    cell8.PaddingTop = 0f;
                    tableinfo1.AddCell(cell8);

                    Paragraph p5 = new Paragraph();
                    Chunk c5 = new Chunk("" + toRoundOff(ps.rdp) + "");
                    c5.Font = f3;
                    p5.Add(c5);

                    PdfPCell cell9 = new PdfPCell(p5);
                    cell9.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell9.Border = 0;
                    cell9.PaddingTop = 0f;
                    tableinfo1.AddCell(cell9);
                }
                if (ps.allowance != "0" && ps.allowance != "")
                {
                    Paragraph p4 = new Paragraph();
                    Chunk c4 = new Chunk("Allowance");
                    p4.Font = f3;
                    p4.Add(c4);

                    PdfPCell cell8 = new PdfPCell(p4);
                    cell8.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell8.Border = 0;
                    cell8.PaddingTop = 0f;
                    tableinfo1.AddCell(cell8);

                    Paragraph p5 = new Paragraph();
                    Chunk c5 = new Chunk("" + toRoundOff(ps.allowance) + "");
                    c5.Font = f3;
                    p5.Add(c5);

                    PdfPCell cell9 = new PdfPCell(p5);
                    cell9.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell9.Border = 0;
                    cell9.PaddingTop = 0f;
                    tableinfo1.AddCell(cell9);
                }
                if (ps.absentded != "0" && ps.absentded != "")
                {
                    Paragraph p4 = new Paragraph();
                    Chunk c4 = new Chunk("Absences");
                    p4.Font = f3;
                    p4.Add(c4);

                    PdfPCell cell8 = new PdfPCell(p4);
                    cell8.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell8.Border = 0;
                    cell8.PaddingTop = 0f;
                    tableinfo1.AddCell(cell8);

                    Paragraph p5 = new Paragraph();
                    Chunk c5 = new Chunk("(" + toRoundOff(ps.absentded) + ")");
                    c5.Font = f3;
                    p5.Add(c5);

                    PdfPCell cell9 = new PdfPCell(p5);
                    cell9.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell9.Border = 0;
                    cell9.PaddingTop = 0f;
                    tableinfo1.AddCell(cell9);
                }

                if (ps.lates != "0" && ps.lates != "")
                {
                    Paragraph p6 = new Paragraph();
                    Chunk c6 = new Chunk("Lates");
                    c6.Font = f3;
                    p6.Add(c6);

                    PdfPCell cell10 = new PdfPCell(p6);
                    cell10.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell10.Border = 0;
                    cell10.PaddingTop = 0f;
                    tableinfo1.AddCell(cell10);

                    Paragraph p7 = new Paragraph();
                    Chunk c7 = new Chunk("(" + toRoundOff(ps.lates) + ")");
                    c7.Font = f3;
                    p7.Add(c7);

                    PdfPCell cell11 = new PdfPCell(p7);
                    cell11.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell11.Border = 0;
                    cell11.PaddingTop = 0f;
                    tableinfo1.AddCell(cell11);
                }

                if (ps.utded != "0" && ps.utded != "")
                {
                    Paragraph p8 = new Paragraph();
                    Chunk c8 = new Chunk("Undertime");
                    c8.Font = f3;
                    p8.Add(c8);

                    PdfPCell cell12 = new PdfPCell(p8);
                    cell12.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell12.Border = 0;
                    cell12.PaddingTop = 0f;
                    tableinfo1.AddCell(cell12);

                    Paragraph p9 = new Paragraph();
                    Chunk c9 = new Chunk("(" + toRoundOff(ps.utded) + ")");
                    c9.Font = f3;
                    p9.Add(c9);

                    PdfPCell cell13 = new PdfPCell(p9);
                    cell13.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell13.Border = 0;
                    cell13.PaddingTop = 0f;
                    tableinfo1.AddCell(cell13);
                }

                if (ps.otpay != "0" && ps.otpay != "")
                {
                    Paragraph p10 = new Paragraph();
                    Chunk c10 = new Chunk("Overtime");
                    c10.Font = f3;
                    p10.Add(c10);

                    PdfPCell cell14 = new PdfPCell(p10);
                    cell14.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell14.Border = 0;
                    cell14.PaddingTop = 0f;
                    tableinfo1.AddCell(cell14);

                    Paragraph p11 = new Paragraph();
                    Chunk c11 = new Chunk("" + toRoundOff(ps.otpay) + "");
                    c11.Font = f3;
                    p11.Add(c11);

                    PdfPCell cell11 = new PdfPCell(p11);
                    cell11.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell11.Border = 0;
                    cell11.PaddingTop = 0f;
                    tableinfo1.AddCell(cell11);
                }

                if (ps.leavepay != "0" && ps.leavepay != "")
                {
                    Paragraph p12 = new Paragraph();
                    Chunk c12 = new Chunk("Leave Pay");
                    c12.Font = f3;
                    p12.Add(c12);

                    PdfPCell cell15 = new PdfPCell(p12);
                    cell15.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell15.Border = 0;
                    cell15.PaddingTop = 0f;
                    tableinfo1.AddCell(cell15);

                    Paragraph p13 = new Paragraph();
                    Chunk c13 = new Chunk("" + toRoundOff(ps.leavepay) + "");
                    c13.Font = f3;
                    p13.Add(c13);

                    PdfPCell cell16 = new PdfPCell(p13);
                    cell16.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell16.Border = 0;
                    cell16.PaddingTop = 0f;
                    tableinfo1.AddCell(cell16);
                }
                

                if (ps.adjustment != "0" && ps.adjustment != "")
                {
                    Paragraph p12 = new Paragraph();
                    Chunk c12 = new Chunk(ps.adjustmentremarks);
                    c12.Font = f3;
                    p12.Add(c12);

                    PdfPCell cell15 = new PdfPCell(p12);
                    cell15.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell15.Border = 0;
                    cell15.PaddingTop = 0f;
                    tableinfo1.AddCell(cell15);

                    Paragraph p13 = new Paragraph();
                    Chunk c13 = new Chunk("" + toRoundOff(ps.adjustment) + "");
                    c13.Font = f3;
                    p13.Add(c13);

                    PdfPCell cell16 = new PdfPCell(p13);
                    cell16.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell16.Border = 0;
                    cell16.PaddingTop = 0f;
                    tableinfo1.AddCell(cell16);
                }
                if (ps.holidaypay != "0" && ps.holidaypay != "")
                {
                    Paragraph p12 = new Paragraph();
                    Chunk c12 = new Chunk("Holiday Pay");
                    c12.Font = f3;
                    p12.Add(c12);

                    PdfPCell cell15 = new PdfPCell(p12);
                    cell15.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell15.Border = 0;
                    cell15.PaddingTop = 0f;
                    tableinfo1.AddCell(cell15);

                    Paragraph p13 = new Paragraph();
                    Chunk c13 = new Chunk("(" + toRoundOff(ps.holidaypay) + ")");
                    c13.Font = f3;
                    p13.Add(c13);

                    PdfPCell cell16 = new PdfPCell(p13);
                    cell16.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell16.Border = 0;
                    cell16.PaddingTop = 0f;
                    tableinfo1.AddCell(cell16);
                }

                Paragraph blank = new Paragraph();
                Chunk cblank = new Chunk(" ");
                cblank.Font = f3;
                blank.Add(cblank);

                PdfPCell cell17 = new PdfPCell(blank);
                cell17.HorizontalAlignment = Element.ALIGN_LEFT;
                cell17.Colspan = 2;
                cell17.Border = 0;
                cell17.PaddingTop = 0f;
                tableinfo2.AddCell(cell17);                

                if (ps.sss != "0" && ps.sss != "")
                {
                    Paragraph p14 = new Paragraph();
                    Chunk c14 = new Chunk("SSS");
                    c14.Font = f3;
                    p14.Add(c14);

                    PdfPCell cell18 = new PdfPCell(p14);
                    cell18.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell18.Border = 0;
                    cell18.PaddingTop = 0f;
                    tableinfo2.AddCell(cell18);

                    Paragraph p15 = new Paragraph();
                    Chunk c15 = new Chunk(toRoundOff(ps.sss));
                    c15.Font = f3;
                    p15.Add(c15);

                    PdfPCell cell19 = new PdfPCell(p15);
                    cell19.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell19.Border = 0;
                    cell19.PaddingTop = 0f;
                    tableinfo2.AddCell(cell19);
                }

                if (ps.philhealth != "0" && ps.philhealth != "")
                {
                    Paragraph p14 = new Paragraph();
                    Chunk c14 = new Chunk("PhilHealth");
                    c14.Font = f3;
                    p14.Add(c14);

                    PdfPCell cell18 = new PdfPCell(p14);
                    cell18.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell18.Border = 0;
                    cell18.PaddingTop = 0f;
                    tableinfo2.AddCell(cell18);

                    Paragraph p15 = new Paragraph();
                    Chunk c15 = new Chunk(toRoundOff(ps.philhealth));
                    c15.Font = f3;
                    p15.Add(c15);

                    PdfPCell cell19 = new PdfPCell(p15);
                    cell19.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell19.Border = 0;
                    cell19.PaddingTop = 0f;
                    tableinfo2.AddCell(cell19);
                }

                if (ps.pagibig != "0" && ps.pagibig != "")
                {
                    Paragraph p16 = new Paragraph();
                    Chunk c16 = new Chunk("Pag-Ibig");
                    c16.Font = f3;
                    p16.Add(c16);

                    PdfPCell cell20 = new PdfPCell(p16);
                    cell20.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell20.Border = 0;
                    cell20.PaddingTop = 0f;
                    tableinfo2.AddCell(cell20);

                    Paragraph p17 = new Paragraph();
                    Chunk c17 = new Chunk(toRoundOff(ps.pagibig));
                    c17.Font = f3;
                    p17.Add(c17);

                    PdfPCell cell21 = new PdfPCell(p17);
                    cell21.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell21.Border = 0;
                    cell21.PaddingTop = 0f;
                    tableinfo2.AddCell(cell21);
                }

                if (ps.wtax != "0" && ps.wtax != "")
                {
                    Paragraph p18 = new Paragraph();
                    Chunk c18 = new Chunk("Tax");
                    c18.Font = f3;
                    p18.Add(c18);

                    PdfPCell cell22 = new PdfPCell(p18);
                    cell22.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell22.Border = 0;
                    cell22.PaddingTop = 0f;
                    tableinfo2.AddCell(cell22);

                    Paragraph p19 = new Paragraph();
                    Chunk c19 = new Chunk(toRoundOff(ps.wtax));
                    c19.Font = f3;
                    p19.Add(c19);

                    PdfPCell cell23 = new PdfPCell(p19);
                    cell23.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell23.Border = 0;
                    cell23.PaddingTop = 0f;
                    tableinfo2.AddCell(cell23);
                }

                if ((ps.PIL != 0.00 && ps.PICL.ToString() != "") || (ps.PICL != 0.00 && ps.PICL.ToString() != "") || (ps.SSS != 0.00 && ps.SSS.ToString() != "") ||
                    (ps.SSSCL != 0.00 && ps.SSSCL.ToString() != ""))
                {
                    Paragraph p20 = new Paragraph();
                    //Chunk c20 = new Chunk("Loan Balance    " + toRoundOff(ps.loanbal));
                    Chunk c20 = new Chunk("Loan Balance    ");
                    c20.Font = f3;
                    p20.Add(c20);

                    PdfPCell cell24 = new PdfPCell(p20);
                    cell24.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cell24.Colspan = 3;
                    cell24.Border = 0;
                    cell24.PaddingTop = 0f;
                    tableinfo3.AddCell(cell24);

                    

                }

                if (ps.PIL != 0.00 && ps.PICL.ToString() != "")
                {
                    Paragraph p21 = new Paragraph();
                    Chunk c21 = new Chunk("HDMF");
                    c21.Font = f3;
                    p21.Add(c21);

                    PdfPCell cell25 = new PdfPCell(p21);
                    cell25.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell25.Border = 0;
                    cell25.PaddingTop = 0f;
                    tableinfo3.AddCell(cell25);

                    Paragraph p22 = new Paragraph();
                    Chunk c22 = new Chunk(toRoundOff(ps.PIL.ToString()));
                    c22.Font = f3;
                    p22.Add(c22);

                    PdfPCell cell26 = new PdfPCell(p22);
                    cell26.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell26.Border = 0;
                    cell26.PaddingTop = 0f;
                    tableinfo3.AddCell(cell26);

                    //for balance
                    Paragraph p23 = new Paragraph();
                    Chunk c28 = new Chunk(toRoundOff(ps.PILBal.ToString()));
                    c28.Font = f3;
                    p23.Add(c28);

                    PdfPCell cell31 = new PdfPCell(p23);
                    cell31.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cell31.Border = 0;
                    cell31.PaddingTop = 0f;
                    tableinfo3.AddCell(cell31);
                }

                if (ps.PICL != 0.00 && ps.PICL.ToString() != "")
                {
                    Paragraph p23 = new Paragraph();
                    Chunk c23 = new Chunk("HDMF Cal.");
                    c23.Font = f3;
                    p23.Add(c23);

                    PdfPCell cell27 = new PdfPCell(p23);
                    cell27.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell27.Border = 0;
                    cell27.PaddingTop = 0f;
                    tableinfo3.AddCell(cell27);

                    Paragraph p24 = new Paragraph();
                    Chunk c24 = new Chunk(toRoundOff(ps.PICL.ToString()));
                    c24.Font = f3;
                    p24.Add(c24);

                    PdfPCell cell28 = new PdfPCell(p24);
                    cell28.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell28.Border = 0;
                    cell28.PaddingTop = 0f;
                    tableinfo3.AddCell(cell28);

                    //for balance
                    Paragraph ppiclbal = new Paragraph();
                    Chunk cpiclbal = new Chunk(toRoundOff(ps.PICLBal.ToString()));
                    cpiclbal.Font = f3;
                    ppiclbal.Add(cpiclbal);

                    PdfPCell cellpiclbal = new PdfPCell(ppiclbal);
                    cellpiclbal.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cellpiclbal.Border = 0;
                    cellpiclbal.PaddingTop = 0f;
                    tableinfo3.AddCell(cellpiclbal);
                }

                if (ps.SSS != 0.00 && ps.SSS.ToString() != "")
                {
                    Paragraph p25 = new Paragraph();
                    Chunk c25 = new Chunk("SSS Sal.");
                    c25.Font = f3;
                    p25.Add(c25);

                    PdfPCell cell29 = new PdfPCell(p25);
                    cell29.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell29.Border = 0;
                    cell29.PaddingTop = 0f;
                    tableinfo3.AddCell(cell29);

                    Paragraph p26 = new Paragraph();
                    Chunk c26 = new Chunk(toRoundOff(ps.SSS.ToString()));
                    c26.Font = f3;
                    p26.Add(c26);

                    PdfPCell cell30 = new PdfPCell(p26);
                    cell30.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell30.Border = 0;
                    cell30.PaddingTop = 0f;
                    tableinfo3.AddCell(cell30);

                    //for balance
                    Paragraph p27 = new Paragraph();
                    Chunk c27 = new Chunk(toRoundOff(ps.SSSBal.ToString()));
                    c27.Font = f3;
                    p27.Add(c27);

                    PdfPCell cell31 = new PdfPCell(p27);
                    cell31.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cell31.Border = 0;
                    cell31.PaddingTop = 0f;
                    tableinfo3.AddCell(cell31);
                }

                if (ps.SSSCL != 0.00 && ps.SSSCL.ToString() != "")
                {
                    Paragraph p27 = new Paragraph();
                    Chunk c27 = new Chunk("SSS Cal.");
                    c27.Font = f3;
                    p27.Add(c27);

                    PdfPCell cell31 = new PdfPCell(p27);
                    cell31.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell31.Border = 0;
                    cell31.PaddingTop = 0f;
                    tableinfo3.AddCell(cell31);

                    Paragraph p28 = new Paragraph();
                    Chunk c28 = new Chunk(toRoundOff(ps.SSSCL.ToString()));
                    c28.Font = f3;
                    p28.Add(c28);

                    PdfPCell cell32 = new PdfPCell(p28);
                    cell32.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell32.Border = 0;
                    cell32.PaddingTop = 0f;
                    tableinfo3.AddCell(cell32);

                    //for balance
                    Paragraph psssclbal = new Paragraph();
                    Chunk csssclbal = new Chunk(toRoundOff(ps.SSSCLBal.ToString()));
                    csssclbal.Font = f3;
                    psssclbal.Add(csssclbal);

                    PdfPCell cellsssclbal = new PdfPCell(psssclbal);
                    cellsssclbal.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cellsssclbal.Border = 0;
                    cellsssclbal.PaddingTop = 0f;
                    tableinfo3.AddCell(cellsssclbal);
                }

                if (ps.CA != 0.00 && ps.CA.ToString() != "")
                {
                    Paragraph p27 = new Paragraph();
                    Chunk c27 = new Chunk("Cash Adv");
                    c27.Font = f3;
                    p27.Add(c27);

                    PdfPCell cell31 = new PdfPCell(p27);
                    cell31.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell31.Border = 0;
                    cell31.PaddingTop = 0f;
                    tableinfo3.AddCell(cell31);

                    Paragraph p28 = new Paragraph();
                    Chunk c28 = new Chunk(toRoundOff(ps.CA.ToString()));
                    c28.Font = f3;
                    p28.Add(c28);

                    PdfPCell cell32 = new PdfPCell(p28);
                    cell32.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell32.Border = 0;
                    cell32.PaddingTop = 0f;
                    tableinfo3.AddCell(cell32);

                    //for balance
                    Paragraph pcabal = new Paragraph();
                    Chunk ccabal = new Chunk(toRoundOff(ps.CABal.ToString()));
                    ccabal.Font = f3;
                    pcabal.Add(ccabal);

                    PdfPCell cellcabal = new PdfPCell(pcabal);
                    cellcabal.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cellcabal.Border = 0;
                    cellcabal.PaddingTop = 0f;
                    tableinfo3.AddCell(cellcabal);
                }
                if (ps.CA2 != 0.00 && ps.CA2.ToString() != "")
                {
                    Paragraph p27 = new Paragraph();
                    Chunk c27 = new Chunk("Cash Adv");
                    c27.Font = f3;
                    p27.Add(c27);

                    PdfPCell cell31 = new PdfPCell(p27);
                    cell31.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell31.Border = 0;
                    cell31.PaddingTop = 0f;
                    tableinfo3.AddCell(cell31);

                    Paragraph p28 = new Paragraph();
                    Chunk c28 = new Chunk(toRoundOff(ps.CA2.ToString()));
                    c28.Font = f3;
                    p28.Add(c28);

                    PdfPCell cell32 = new PdfPCell(p28);
                    cell32.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell32.Border = 0;
                    cell32.PaddingTop = 0f;
                    tableinfo3.AddCell(cell32);

                    //for balance
                    Paragraph pcabal = new Paragraph();
                    Chunk ccabal = new Chunk(toRoundOff(ps.CABal2.ToString()));
                    ccabal.Font = f3;
                    pcabal.Add(ccabal);

                    PdfPCell cellcabal = new PdfPCell(pcabal);
                    cellcabal.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cellcabal.Border = 0;
                    cellcabal.PaddingTop = 0f;
                    tableinfo3.AddCell(cellcabal);
                }
                if (ps.CA3 != 0.00 && ps.CA3.ToString() != "")
                {
                    Paragraph p27 = new Paragraph();
                    Chunk c27 = new Chunk("Cash Adv");
                    c27.Font = f3;
                    p27.Add(c27);

                    PdfPCell cell31 = new PdfPCell(p27);
                    cell31.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell31.Border = 0;
                    cell31.PaddingTop = 0f;
                    tableinfo3.AddCell(cell31);

                    Paragraph p28 = new Paragraph();
                    Chunk c28 = new Chunk(toRoundOff(ps.CA3.ToString()));
                    c28.Font = f3;
                    p28.Add(c28);

                    PdfPCell cell32 = new PdfPCell(p28);
                    cell32.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell32.Border = 0;
                    cell32.PaddingTop = 0f;
                    tableinfo3.AddCell(cell32);

                    //for balance
                    Paragraph pcabal = new Paragraph();
                    Chunk ccabal = new Chunk(toRoundOff(ps.CABal3.ToString()));
                    ccabal.Font = f3;
                    pcabal.Add(ccabal);

                    PdfPCell cellcabal = new PdfPCell(pcabal);
                    cellcabal.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cellcabal.Border = 0;
                    cellcabal.PaddingTop = 0f;
                    tableinfo3.AddCell(cellcabal);
                }

                PdfPCell celltableinfo1 = new PdfPCell(tableinfo1);
                celltableinfo1.Border = 0;
                celltableinfo1.PaddingTop = 0f;

                PdfPCell celltableinfo2 = new PdfPCell(tableinfo2);
                celltableinfo2.Border = 0;
                celltableinfo2.PaddingTop = 0f;

                PdfPCell celltableinfo3 = new PdfPCell(tableinfo3);
                celltableinfo3.Border = 0;
                celltableinfo3.PaddingTop = 0f;

                PdfPCell celltableinfo4 = new PdfPCell(blank);
                celltableinfo4.Colspan = 3;
                celltableinfo4.Border = 0;
                celltableinfo4.PaddingTop = 5f;

                table1.AddCell(celltableinfo4);
                table1.AddCell(celltableinfo1);
                table1.AddCell(celltableinfo2);
                table1.AddCell(celltableinfo3);

                PdfPCell cellspace = new PdfPCell(blank);
                cellspace.HorizontalAlignment = Element.ALIGN_LEFT;
                cellspace.Colspan = 6;
                cellspace.Border = 0;
                cellspace.PaddingTop = 20f;
                tabletot.AddCell(cellspace);

                PdfPCell cell33 = new PdfPCell(blank);
                cell33.HorizontalAlignment = Element.ALIGN_LEFT;
                cell33.Border = 0;
                cell33.PaddingTop = 0f;
                tabletot.AddCell(cell33);

                Paragraph p29 = new Paragraph();
                Chunk c29 = new Chunk("Total Gross Income");
                c29.Font = f3;
                p29.Add(c29);

                PdfPCell cell34 = new PdfPCell(p29);
                cell34.HorizontalAlignment = Element.ALIGN_LEFT;
                cell34.Border = 0;
                cell34.PaddingTop = 0f;
                cell34.PaddingTop = 10f;
                cell34.PaddingBottom = 10f;
                tabletot.AddCell(cell34);

                Paragraph p30 = new Paragraph();
                Chunk c30 = new Chunk(toRoundOff(ps.totalgrossincome));
                c30.Font = f3;
                p30.Add(c30);

                PdfPCell cell35 = new PdfPCell(p30);
                cell35.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell35.Border = 0;
                cell35.BorderWidthTop = 1f;
                cell35.BorderWidthBottom = 1f;
                cell35.PaddingTop = 10f;
                cell35.PaddingBottom = 10f;
                tabletot.AddCell(cell35);

                tabletot.AddCell(cell33);

                Paragraph p31 = new Paragraph();
                Chunk c31 = new Chunk("Total Deduction");
                c31.Font = f3;
                p31.Add(c31);

                PdfPCell cell36 = new PdfPCell(p31);
                cell36.HorizontalAlignment = Element.ALIGN_LEFT;
                cell36.Border = 0;
                cell36.PaddingTop = 0f;
                cell36.PaddingTop = 10f;
                cell36.PaddingBottom = 10f;
                tabletot.AddCell(cell36);

                Paragraph p32 = new Paragraph();
                Chunk c32 = new Chunk(toRoundOff(ps.totaldeduction));
                c32.Font = f3;
                p32.Add(c32);

                PdfPCell cell37 = new PdfPCell(p32);
                cell37.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell37.Border = 0;
                cell37.BorderWidthTop = 1f;
                cell37.BorderWidthBottom = 1f;
                cell37.PaddingTop = 0f;
                cell37.PaddingTop = 10f;
                cell37.PaddingBottom = 10f;
                tabletot.AddCell(cell37);

                PdfPCell cellspace1 = new PdfPCell(blank);
                cellspace1.Border = 0;
                cellspace1.Colspan = 6;
                cellspace1.PaddingTop = 10f;
                tabletot.AddCell(cellspace1);

                PdfPCell cellspace2 = new PdfPCell(blank);
                cellspace2.Border = 0;
                cellspace2.Colspan = 4;
                tabletot.AddCell(cellspace2);

                Paragraph p33 = new Paragraph();
                Chunk c33 = new Chunk("Net Pay");
                c33.Font = f3;
                p33.Add(c33);

                PdfPCell cell38 = new PdfPCell(p33);
                cell38.HorizontalAlignment = Element.ALIGN_LEFT;
                cell38.Border = 0;
                cell38.PaddingTop = 0f;
                cell38.PaddingTop = 10f;
                cell38.PaddingBottom = 10f;
                tabletot.AddCell(cell38);

                Paragraph p34 = new Paragraph();
                Chunk c34 = new Chunk(toRoundOff(ps.netpay));
                c34.Font = f3;
                p34.Add(c34);

                PdfPCell cell39 = new PdfPCell(p34);
                cell39.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell39.Border = 0;
                cell39.BorderWidthTop = 1f;
                cell39.BorderWidthBottom = 1f;
                cell39.PaddingTop = 0f;
                cell39.PaddingTop = 10f;
                cell39.PaddingBottom = 10f;
                tabletot.AddCell(cell39);

                PdfPCell cellspace3 = new PdfPCell(blank);
                cellspace3.Border = 0;
                cellspace3.Colspan = 6;
                cellspace3.PaddingTop = 10f;
                tabletot.AddCell(cellspace3);

                Paragraph p35 = new Paragraph();
                Chunk c35 = new Chunk("I hereby acknowledge to have received the sum as full payment of my service rendered.");
                c35.Font = f3;
                p35.Add(c35);

                PdfPCell cell40 = new PdfPCell(p35);
                cell40.HorizontalAlignment = Element.ALIGN_LEFT;
                cell40.Colspan = 4;
                cell40.Border = 0;
                cell40.PaddingTop = 0f;
                tabletot.AddCell(cell40);

                Paragraph p36 = new Paragraph();
                Chunk c36 = new Chunk("Signature_________________________");
                c36.Font = f3;
                p36.Add(c36);

                PdfPCell cell41 = new PdfPCell(p36);
                cell41.HorizontalAlignment = Element.ALIGN_LEFT;
                cell41.Colspan = 2;
                cell41.Border = 0;
                cell41.PaddingTop = 0f;
                cell41.PaddingLeft = 50f;
                tabletot.AddCell(cell41);

                
                
                iTextSharp.text.pdf.draw.DottedLineSeparator dottedline = new iTextSharp.text.pdf.draw.DottedLineSeparator();
                dottedline.LineWidth = 2f;
                Chunk linesep = new Chunk(dottedline);
                Paragraph p = new Paragraph(linesep);

                PdfPCell cellspace4 = new PdfPCell(p);
                cellspace4.Border = 0;
                cellspace4.Colspan = 6;
                cellspace4.PaddingTop = 1f;
                tabletot.AddCell(cellspace4);

                doc.Add(table);
                doc.Add(table1);
                doc.Add(tabletot);
                //doc.NewPage();

            }
            doc.Close();
        }
        return doc;
    }

    public DataTable populatePayrollRegisterReport(string cutoff)
    {
        
        string expr = "";
        expr += cutoff == "" ? "" : " AND TBL_CUTOFF.id = " + cutoff + " AND TBL_EMPLOYEE_MASTER.emp_PayrollGroup = TBL_CUTOFF.PayrollGroup ";
       // expr += deptid == "" ? "" : " AND TBL_EMPLOYEE_MASTER.emp_Department = '" + deptid + "'";
        string qry = "Select COALESCE(emp_EmpID, 'Grand Total:') AS [EmpID]," +
            "COALESCE((emp_FullName), '') as 'Name'," +
            "COALESCE((PositionName), '') as 'Position'," +
            " SUM(CASE WHEN emp_PayType = 'D' THEN CAST(emp_BasicPay as float) / CAST(emp_WorkDays as float) ELSE CAST(emp_BasicPay as float) END) as 'Rate'," +
            " SUM(CAST(RegularDays as float)) as 'RegularDays'," +
            " SUM(CAST(TBL_PAYSLIP.BasicPay as float)) as 'BasicPay',  SUM(CAST(TBL_PAYSLIP.LeavePay as float)) as 'LeavePay', " +

            "SUM(CAST(TBL_PAYSLIP.RDP as float)) as 'RST', SUM(CAST(SHP as float)) as 'SPE', SUM(CAST(SPERST as float)) as 'SPERST'," +
             "SUM(CAST(TBL_PAYSLIP.LHP as float)) as 'LHP', SUM(CAST(LEGRST as float)) as 'LEGRST', SUM(CAST(DOUBLH as float)) as 'DOUBLH'," +
             "SUM(CAST(DOUBLHRD as float)) as 'DOUBLHRD'," +

             "SUM(CAST(TBL_PAYSLIP.REGND as float)) as 'REGND', SUM(CAST(RDND as float)) as 'RDND', SUM(CAST(SPEND as float)) as 'SPEND'," +
             "SUM(CAST(TBL_PAYSLIP.SPERSTND as float)) as 'SPERSTND', SUM(CAST(LEGND as float)) as 'LEGND', SUM(CAST(LEGRSTND as float)) as 'LEGRSTND'," +
             " SUM(CAST(DOUBLEGND as float)) as 'DOUBLEGND', SUM(CAST(DOUBLEGRSTND as float)) as 'DOUBLEGRSTND'," +

             "SUM(CAST(TBL_PAYSLIP.REGOT as float)) as 'REGOT', SUM(CAST(RDOT as float)) as 'RDOT', SUM(CAST(SHOT as float)) as 'SHOT'," +
             "SUM(CAST(TBL_PAYSLIP.RDSHOT as float)) as 'RDSHOT', SUM(CAST(LHOT as float)) as 'LHOT', SUM(CAST(RDLHOT as float)) as 'RDLHOT'," +
             " SUM(CAST(DOUBLEGOT as float)) as 'DOUBLEGOT', SUM(CAST(DOUBRSTOT as float)) as 'DOUBRSTOT'," +

             "SUM(CAST(TBL_PAYSLIP.REGNDOT as float)) as 'REGNDOT', SUM(CAST(RSTNDOT as float)) as 'RSTNDOT', SUM(CAST(SPENDOT as float)) as 'SPENDOT', " +
             "SUM(CAST(TBL_PAYSLIP.SPERSTNDOT as float)) as 'SPERSTNDOT', SUM(CAST(LEGNDOT as float)) as 'LEGNDOT', SUM(CAST(LEGRSTNDOT as float)) as 'LEGRSTNDOT', " +
             "SUM(CAST(DOUBLEGNDOT as float)) as 'DOUBLEGNDOT', SUM(CAST(DOUBRSTNDOT as float)) as 'DOUBRSTNDOT', " +

             " SUM(CAST(UTDed as float)) as 'UTDed', SUM(CAST(LatesDed as float)) as 'LatesDed',SUM(CAST(GrossPay as float)) as 'GrossPay', SUM(CAST(WTax as float)) as 'WHoldingTax'," +
            "SUM(CAST(SSSDed as float)) as 'SSS',SUM(CAST(PagibigDed as float)) as 'Pagibig', SUM(CAST(PhilhealthDed as float)) as 'Philhealth'," +
            "SUM(CAST(SSSL as float)) as 'SSSL',SUM(CAST(SSSCL as float)) as 'SSSCL', SUM(CAST(PIL as float)) as 'PIL', SUM(CAST(PICL as float)) as 'PICL', " +
            "SUM(CAST(CA as float)) as 'CashAdvance'," +
            "SUM(CAST(TotDed as float)) as 'TotalDeduction'," +
            " SUM(CAST(allowance as float)) as 'Allowance',SUM(CAST(AdjustmentAdd as float) + CAST(AdjustmentOthersAdd as float)) as 'adjustment', SUM(CAST(NetPay as float)) as 'NetPay'" +
            " from TBL_EMPLOYEE_MASTER " +
            "INNer join TBL_PAYSLIP on emp_EmpID = EmployeeID " +
            "inner join TBL_CUTOFF on TBL_PAYSLIP.CutoffID = TBL_CUTOFF.id  AND TBL_PAYSLIP.PayrollGroup = TBL_CUTOFF.PayrollGroup " +
            //"inner join TBL_BRANCH on emp_BranchCode = TBL_BRANCH.BranchCode " +
            "inner join TBL_POSITION on emp_Position = TBL_POSITION.id " +
            //"left join TBL_BONUSES on TBL_PAYSLIP.CutoffID = TBL_BONUSES.CutoffID AND TBL_PAYSLIP.EmployeeID = TBL_BONUSES.EmpID  AND TBL_PAYSLIP.PayrollGroup = TBL_BONUSES.PayrollGroup " +
            //"left join TBL_ALLOWANCE on TBL_PAYSLIP.CutoffID = TBL_ALLOWANCE.CutoffID AND TBL_PAYSLIP.EmployeeID = TBL_ALLOWANCE.EmpID " +
            "left join TBL_ADJUSTMENT on TBL_PAYSLIP.CutoffID = TBL_ADJUSTMENT.CutoffID AND TBL_PAYSLIP.EmployeeID = TBL_ADJUSTMENT.EmpID  AND TBL_PAYSLIP.PayrollGroup = TBL_ADJUSTMENT.PayrollGroup " +
            "left join TBL_OTHERSDEDUCTION on TBL_PAYSLIP.CutoffID = TBL_OTHERSDEDUCTION.CutoffID AND TBL_PAYSLIP.EmployeeID = TBL_OTHERSDEDUCTION.EmpID  AND TBL_PAYSLIP.PayrollGroup = TBL_OTHERSDEDUCTION.PayrollGroup " +
            //"left join TBL_CASHADVANCE on TBL_PAYSLIP.CutoffID = TBL_CASHADVANCE.CutoffID AND TBL_PAYSLIP.EmployeeID = TBL_CASHADVANCE.EmpID  AND TBL_PAYSLIP.PayrollGroup = TBL_CASHADVANCE.PayrollGroup " +
            "left join TBL_CONTRIBUTION on TBL_PAYSLIP.CutoffID = TBL_CONTRIBUTION.cutoffID AND TBL_PAYSLIP.EmployeeID = TBL_CONTRIBUTION.empID  AND TBL_PAYSLIP.PayrollGroup = TBL_CONTRIBUTION.PayrollGroup " +
            //"left join TBL_COMPENSATION on TBL_PAYSLIP.CutoffID = TBL_COMPENSATION.CutoffID AND TBL_PAYSLIP.EmployeeID = TBL_COMPENSATION.EmpID  AND TBL_PAYSLIP.PayrollGroup = TBL_COMPENSATION.PayrollGroup " +
            //"left join TBL_CADVANCEPAYMENTHISTORY CA on TBL_PAYSLIP.CutoffID = CA.CutoffID AND TBL_PAYSLIP.EmployeeID = CA.EmpID  AND TBL_PAYSLIP.PayrollGroup = CA.PayrollGroup " +
            //"left join TBL_CBONDPAYMENTHISTORY CB on TBL_PAYSLIP.CutoffID = CB.CutoffID AND TBL_PAYSLIP.EmployeeID = CB.EmpID  AND TBL_PAYSLIP.PayrollGroup = CB.PayrollGroup " +
            "where 1 = 1 ";
        if (cutoff != "")
        {
            qry += expr;
        }
        qry += " GROUP BY  GROUPING SETS((emp_EmpID ,emp_FullName,PositionName), ()) ORDER BY COALESCE(emp_FullName,'Z') ASC;";
        dt = new DataTable(); 
        dt.Columns.AddRange(new DataColumn[54] {
            new DataColumn("ID"),new DataColumn("NAME"),new DataColumn("POSITION"),
            new DataColumn("RATE"),new DataColumn("DAYS"),
            new DataColumn("BASIC PAY"),new DataColumn("LEAVE PAY"),

            new DataColumn("RST"), new DataColumn("SPE"), new DataColumn("SPE RST"),
            new DataColumn("LEG"),new DataColumn("LEG RST"),
            new DataColumn("DOUBLH"),new DataColumn("DOUBLHRD"),

            new DataColumn("REGND"),new DataColumn("RDND"),new DataColumn("SPEND"),
            new DataColumn("SPERSTND"),new DataColumn("LEGND"),new DataColumn("LEGRSTND"),
            new DataColumn("DOUBLEGND"),new DataColumn("DOUBLEGRSTND"),

            new DataColumn("REGOT"),new DataColumn("RDOT"),new DataColumn("SHOT"),
            new DataColumn("RDSHOT"),new DataColumn("LHOT"),new DataColumn("RDLHOT"),
            new DataColumn("DOUBLEGOT"),new DataColumn("DOUBRSTOT"),

            new DataColumn("REGNDOT"),new DataColumn("RSTNDOT"),new DataColumn("SPENDOT"),
            new DataColumn("SPERSTNDOT"),new DataColumn("LEGNDOT"),new DataColumn("LEGRSTNDOT"),
            new DataColumn("DOUBLEGNDOT"),new DataColumn("DOUBRSTNDOT"),

            new DataColumn("UNDERTIME"),new DataColumn("LATES"),new DataColumn("GROSS PAY"),

            new DataColumn("WTAX"),new DataColumn("SSS"),new DataColumn("PAGIBIG"),
            new DataColumn("PHILHEALTH"),new DataColumn("SSS SAL"),new DataColumn("SSS CAL"),new DataColumn("HDMF SAL"),new DataColumn("HDMF CAL"),
            new DataColumn("CASH ADVANCE"),new DataColumn("TOTAL DEDUCTIONS"),

            new DataColumn("ALLOWANCE"),new DataColumn("ADJUSTMENT"),new DataColumn("TOTAL NET PAY")});

        conn = new SqlConnection(connectionstring);
        conn.Open();
        //cmd = new SqlCommand("Select * from TBL_USERS where user_Status='ACTIVE'", conn);
        cmd = new SqlCommand(qry, conn);
        dread = cmd.ExecuteReader();
        while (dread.Read())
        {
            dt.Rows.Add(dread["EmpID"].ToString(), dread["Name"].ToString(), dread["Position"].ToString(), dread["Rate"].ToString(),
                dread["RegularDays"].ToString(),dread["BasicPay"].ToString(), dread["LeavePay"].ToString(),

                dread["RST"].ToString(), dread["SPE"].ToString(),
                dread["SPERST"].ToString(), dread["LHP"].ToString(), dread["LEGRST"].ToString(),
                dread["DOUBLH"].ToString(), dread["DOUBLHRD"].ToString(),

                dread["REGND"].ToString(), dread["RDND"].ToString(), dread["SPEND"].ToString(),
                dread["SPERSTND"].ToString(), dread["LEGND"].ToString(), dread["LEGRSTND"].ToString(),
                dread["DOUBLEGND"].ToString(), dread["DOUBLEGRSTND"].ToString(),

                dread["REGOT"].ToString(), dread["RDOT"].ToString(), dread["SHOT"].ToString(),
                dread["RDSHOT"].ToString(), dread["LHOT"].ToString(), dread["RDLHOT"].ToString(),
                dread["DOUBLEGOT"].ToString(), dread["DOUBRSTOT"].ToString(),

                dread["REGNDOT"].ToString(), dread["RSTNDOT"].ToString(), dread["SPENDOT"].ToString(),
                dread["SPERSTNDOT"].ToString(), dread["LEGNDOT"].ToString(), dread["LEGRSTNDOT"].ToString(),
                dread["DOUBLEGNDOT"].ToString(), dread["DOUBRSTNDOT"].ToString(),

                dread["UTDed"].ToString(), dread["LatesDed"].ToString(), dread["GrossPay"].ToString(), 
                dread["WHoldingTax"].ToString(), dread["SSS"].ToString(),dread["Pagibig"].ToString(), 
                dread["Philhealth"].ToString(), dread["SSSL"].ToString(), dread["SSSCL"].ToString(), dread["PIL"].ToString(), dread["PICL"].ToString(),
                dread["CashAdvance"].ToString(), dread["TotalDeduction"].ToString(),dread["Allowance"].ToString(), 
                dread["adjustment"].ToString(), dread["NetPay"].ToString());

        }
        dread.Close();

        conn.Close();
        return dt;
    }


}
