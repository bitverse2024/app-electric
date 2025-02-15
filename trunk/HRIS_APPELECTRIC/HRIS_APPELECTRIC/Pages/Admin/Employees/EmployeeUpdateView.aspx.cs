﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data.SqlTypes;


namespace HRIS_APPELECTRIC.Pages.Admin.Employees
{
    public partial class EmployeeUpdateView : System.Web.UI.Page
    {
        Employee db = new Employee();
        Common cm = new Common();
        Timekeeping tm = new Timekeeping();
        public string empno = "";
        public string ret = "";
        string getsurname, getfname, getmname, getnname, getsuffix, getfulln, geteid, getbid, getassign,
            getgender, getpaytype, getpos, getdept, getstart, getsss, gettin, getpagibig, getphilhealth, getnationalid,
            getlicno, getlicexp, getstat, getrank, getapp1, getapp2,getregdate, getleavecredit,getlocation, getpioneer;//06/15/2022 Jan add getleavecredit
        Dictionary<string, string> empInfo = new Dictionary<string, string>();
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    empno = Request.QueryString["empid"];
        //    empInfo = db.GetEmployeeInfoDict(empno);
        //    if (!IsPostBack)
        //    {
        //        //Session["empid_arg"] = Request.QueryString["empid"];

        //        populateMenus();
        //        GetValuesToUpdate();


        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ROLES"].ToString() == "employee")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(),
            "alert",
            "alert('Please login as admin.');window.location ='Default_kiosk.aspx';", true);
            }
            empno = Request.QueryString["empid"];
            empInfo = db.GetEmployeeInfoDict(empno);
            if (!IsPostBack)
            {
                //Session["empid_arg"] = Request.QueryString["empid"];

                populateMenus();
                GetValuesToUpdate();


            }
        }
        public string getname()
        {
            string name = "";
            name = db.GetEmployeeName(empno);

            return name;
        }
        void populateMenus()
        {

            //Employee_AssignmentCode
            
            //emp_DateStart.Value = "2020-10-14";
            emp_Position.Items.AddRange(db.GetDropDownMenuList("TBL_POSITION", "PositionName"));
            emp_Department.Items.AddRange(db.GetDropDownMenuList("TBL_DEPARTMENT", "DeptName"));
            emp_Status.Items.AddRange(db.GetDropDownMenuList("TBL_STATUS", "StatusDesc"));
            emp_Rank.Items.AddRange(db.GetDropDownMenuListRank("TBL_RANK", "RankName"));
            emp_Assignment.Items.AddRange(db.GetDropDownMenuList("TBL_COMPANY", "CoName"));
            emp_Approver1.Items.AddRange(db.GetDropDownMenuListApprover("TBL_EMPLOYEE_MASTER", "emp_FullName"));
            emp_Approver2.Items.AddRange(db.GetDropDownMenuListApprover("TBL_EMPLOYEE_MASTER", "emp_FullName"));
            emp_PayrollGroup.Items.AddRange(db.GetDropDownMenuList("TBL_PAYROLLGRP", "payrollgrpname"));
            emp_Location.Items.AddRange(db.GetDropDownMenuList("TBL_LOCATION", "LocationName"));
            string sepdate = cm.GetSpecificDataFromDB("emp_DateSeparated", "TBL_EMPLOYEE_MASTER", " WHERE emp_EmpID ='" + empno + "'");
            if(sepdate!="")
                emp_DateSeparated.Value = Convert.ToDateTime(sepdate).ToString("yyyy-MM-dd");
            //emp_BiometricsID.Text = cm.GetSpecificDataFromDB("emp_BiometricsID", "TBL_EMPLOYEE_MASTER", "WHERE emp_EmpID='" + empno + "'");
            
           emp_EmpID.Text = empno;
            //txtTotal.Value = cm.GetSpecificDataFromDB("emp_TotalSalary", "TBL_EMPLOYEE_MASTER", " WHERE emp_EmpID='" + empno + "'");

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            getdata();
            bool isLeaveExist = cm.ItemExist("TBL_LEAVES", "id", "where EmpID = '" + empno + "' AND Activated = '1'");
            if (isLeaveExist && emp_RegularizationDate.Value == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Please remove leave credit first.');location.href = 'EmployeeMaster.aspx';", true);
                return;
            }
            if (getregdate != "" && emp_RegularizationDate.Value == "" && isLeaveExist)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Please remove leave credit first.');location.href = 'EmployeeMaster.aspx';", true);
                return;
            }
            if (db.UpdateQueryCommon(saveParam(), "emp_EmpID = '" + empno + "'"))
            {
                cm.UpdateQueryCommon(saveParam1(), "TBL_USERS", "empid = '" + empno + "'");
                addlog();
                //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Employee with number " + empno + " succesfully updated'); parent.location.href='" + "EmployeeView.aspx?empid=" + empno + "'", true);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully updated.');location.href = 'EmployeeMaster.aspx';", true);
                //Response.Redirect("~/Pages/Admin/Employee/EmployeeView.aspx?empid=" + empno);
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Admin/Employees/EmployeeMaster.aspx");
        }
        Dictionary<string, string> saveParam()
        {
            
            var formats = new string[] { "MM-dd-yyyy", "MM/dd/yyyy", "MM/dd/yyyy HH:mm:ss" };
            DateTime dt;
            Dictionary<string, string> param = new Dictionary<string, string>();
            
            param.Add("emp_DateStart", "'" + emp_DateStart.Value + "'");
            double sssded = 0;
            double philded = 0;
            sssded = tm.GetSSSDed(emp_BasicPay.Value);
            philded = tm.GetPhilDed(emp_BasicPay.Value);
            
            param.Add("emp_Surname", "'" + emp_Surname.Value + "'");
            param.Add("emp_FirstName", "'" + emp_FirstName.Value + "'");
            param.Add("emp_MidName", "'" + emp_MidName.Value + "'");
            param.Add("emp_NickName", "'" + emp_NickName.Value + "'");
            param.Add("emp_Suffix", "'" + emp_Suffix.Value + "'");
            param.Add("emp_FullName", "'" + emp_Surname.Value + ", " + emp_FirstName.Value + " " + emp_MidName.Value + "'");
            param.Add("emp_EmpID", "'" + emp_EmpID.Text + "'");
            param.Add("emp_BiometricsID", "'" + empno + "'");
            param.Add("emp_Assignment", "'" + emp_Assignment.Value + "'");
            param.Add("emp_Gender", "'" + emp_Gender.Value + "'");
            param.Add("emp_Position", "'" + emp_Position.Value + "'");
            param.Add("emp_Department", "'" + emp_Department.Value + "'");
            param.Add("emp_PayrollGroup", "" + emp_PayrollGroup.Value + "");

            param.Add("emp_SSSNo", "'" + emp_SSSNo.Value + "'");
            param.Add("emp_TIN", "'" + emp_TIN.Value + "'");
            param.Add("emp_PagibigNo", "'" + emp_PagibigNo.Value + "'");
            param.Add("PhilHealth_No", "'" + PhilHealth_No.Value + "'");
            param.Add("emp_NationalIDNo", "'" + emp_NationalIDNo.Value + "'");
            param.Add("emp_LicNo", "'" + emp_LicNo.Value + "'");
            param.Add("emp_LicExpDate", "'" + emp_LicExpDate.Value + "'");
            param.Add("emp_Status", "'" + emp_Status.Value + "'");
            param.Add("emp_Rank", "'" + emp_Rank.Value + "'");
            param.Add("emp_Approver1", "'" + emp_Approver1.Value + "'");
            param.Add("emp_Approver2", "'" + emp_Approver2.Value + "'");
            param.Add("emp_Email", "'" + emp_Email.Value + "'");
            param.Add("emp_BasicPay", "" + emp_BasicPay.Value + "");
            param.Add("emp_WorkDays", "" + emp_WorkDays.Value + "");
            param.Add("emp_SSSDed", "" + sssded + "");
            param.Add("emp_PhilHealthDed", "" + philded + "");
            param.Add("emp_PayType", "'" + emp_PayType.Value + "'");
            param.Add("emp_Location", "'" + emp_Location.Value + "'");
            //param.Add("emp_TotalSalary", "" + txtTotal.Value + "");
            if (emp_ContractStart.Value != "")
            {
                param.Add("emp_ContractStart", "'"+ cm.FormatDate(emp_ContractStart.Value) + "'");
            }
            if (emp_ContractEnd.Value != "")
            {
                param.Add("emp_ContractEnd", "'" + cm.FormatDate(emp_ContractEnd.Value) + "'");
            }
            if (emp_ContractStart.Value != "" && emp_ContractEnd.Value != "")
            {
                double days = (Convert.ToDateTime(emp_ContractEnd.Value) - Convert.ToDateTime(emp_ContractStart.Value)).TotalDays;
                param.Add("emp_ContractDuration", "'"+ days.ToString() + "'");
            }
            if (emp_DateSeparated.Value != "")
                param.Add("emp_DateSeparated", "'" + cm.FormatDate(emp_DateSeparated.Value) + "'");

            //param.Add("emp_PagibigDed", "100");

            //06/09/2022 Jan Wong
            if (emp_RegularizationDate.Value != "")
            {
                param.Add("emp_RegularizationDate", "'" + cm.FormatDate(emp_RegularizationDate.Value) + "'");
            }
            //06/09/2022 Jan Wong

            //06/15/2022 Jan Wong. LeaveCreditPerYear as LeaveCreditPerYear
            double leavecredit = 0;
            double.TryParse(LeaveCreditPerYear.Text, out leavecredit);
            param.Add("LeaveCreditPerYear", "'" + leavecredit.ToString() + "'");
            //06/15/2022 Jan Wong. LeaveCreditPerYear as LeaveCreditPerYear
            param.Add("emp_IsPioneer", emp_IsPioneer.Checked == true ? 1.ToString() : 0.ToString());

            return param;


        }
        Dictionary<string, string> saveParam1()
        {

            var formats = new string[] { "MM-dd-yyyy", "MM/dd/yyyy", "MM/dd/yyyy HH:mm:ss" };
            DateTime dt;
            Dictionary<string, string> param = new Dictionary<string, string>();

            param.Add("lastname", "'" + emp_Surname.Value + "'");
            param.Add("firstname", "'" + emp_FirstName.Value + "'");
            param.Add("midname", "'" + emp_MidName.Value + "'");
            param.Add("fullname", "'" + emp_Surname.Value + ", " + emp_FirstName.Value + " " + emp_MidName.Value + "'");
            param.Add("empid", "'" + emp_EmpID.Text + "'");
            param.Add("email", "'" + emp_Email.Value + "'");

            return param;


        }

        void GetValuesToUpdate()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();

            param.Add("emp_Surname", "");
            param.Add("emp_FirstName", "");
            param.Add("emp_MidName", "");
            param.Add("emp_Suffix", "");
            param.Add("emp_FullName", "");
            param.Add("emp_NickName", "");
            param.Add("emp_EmpID", "");
            //param.Add("emp_BiometricsID", "");
            param.Add("emp_Assignment", "");
            param.Add("emp_Gender", "");
            param.Add("emp_PayType", "");
            param.Add("emp_Position", "");
            param.Add("emp_Department", "");
            param.Add("emp_DateStart", "");
            
            //param.Add(cm.FormatDate(empInfo[emp_DateStart.ID]), "");

            param.Add("emp_SSSNo", "");
            param.Add("emp_TIN", "");
            param.Add("emp_PagibigNo", "");
            param.Add("PhilHealth_No", "");
            param.Add("emp_NationalIDNo", "");
            param.Add("emp_LicNo", "");
            param.Add("emp_LicExpDate", "");
            param.Add("emp_Status", "");
            param.Add("emp_Rank", "");
            param.Add("emp_Approver1", "");
            param.Add("emp_Approver2", "");
            param.Add("emp_BasicPay", "");
            param.Add("emp_WorkDays", "");
            param.Add("emp_PayrollGroup", "");
            param.Add("emp_Email", "");
            param.Add("emp_ContractStart", "");
            param.Add("emp_ContractEnd", "");
            param.Add("emp_ContractDuration","");
            param.Add("emp_RegularizationDate", "");
            param.Add("LeaveCreditPerYear", "");
            param.Add("emp_Location", "");
            param.Add("emp_IsPioneer", "");

            param = db.getValuesToUpdate(param, empno);

            foreach (KeyValuePair<string, string> kvp in param)
            {
                try
                {
                    if(kvp.Key == "emp_IsPioneer")
                    {
                        emp_IsPioneer.Checked = kvp.Value == "True" ? true : false;
                    }
                    else
                    {
                        Control ctr = new Control();
                        ctr = emp_Surname.Parent;
                        ctr = ctr.FindControl(kvp.Key);

                        if (ctr is System.Web.UI.HtmlControls.HtmlInputText)
                        {
                            System.Web.UI.HtmlControls.HtmlInputText txtbox = (System.Web.UI.HtmlControls.HtmlInputText)ctr;
                            txtbox.Value = kvp.Value;
                        }
                        else if (ctr is System.Web.UI.HtmlControls.HtmlSelect)
                        {
                            System.Web.UI.HtmlControls.HtmlSelect drpdwn = (System.Web.UI.HtmlControls.HtmlSelect)ctr;
                            drpdwn.Value = kvp.Value;


                        }
                        else if (ctr is System.Web.UI.WebControls.TextBox)
                        {
                            System.Web.UI.WebControls.TextBox txtbox = (System.Web.UI.WebControls.TextBox)ctr;
                            txtbox.Text = kvp.Value;


                        }

                        else if (ctr is System.Web.UI.HtmlControls.HtmlInputGenericControl)
                        {
                            System.Web.UI.HtmlControls.HtmlInputGenericControl inputtxt = (System.Web.UI.HtmlControls.HtmlInputGenericControl)ctr;


                            if (inputtxt.ClientID == "ContentPlaceHolder1_emp_DateStart" || inputtxt.ClientID == "ContentPlaceHolder1_emp_ContractStart" ||
                                inputtxt.ClientID == "ContentPlaceHolder1_emp_ContractEnd" || inputtxt.ClientID == "ContentPlaceHolder1_emp_LicExpDate" ||
                                inputtxt.ClientID == "ContentPlaceHolder1_emp_RegularizationDate")
                            {
                                if (kvp.Value == "" || kvp.Value == "01/01/1900 12:00:00 am")
                                    continue;
                                DateTime oDate = DateTime.Parse(kvp.Value);
                                inputtxt.Value = oDate.ToString("yyyy-MM-dd");


                            }
                            else
                            {
                                inputtxt.Value = kvp.Value;
                            }


                        }
                    }
                    

                }
                catch
                {
                    break;
                }



            }


        }

        #region addlogs
        private void getdata()
        {
            /*
            getsurname = cm.GetSpecificDataFromDB("emp_Surname", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + empno + "'");
            getfname = cm.GetSpecificDataFromDB("emp_FirstName", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + empno + "'");
            getmname = cm.GetSpecificDataFromDB("emp_MidName", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + empno + "'");
            getnname = cm.GetSpecificDataFromDB("emp_NickName", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + empno + "'");
            getsuffix = cm.GetSpecificDataFromDB("emp_Suffix", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + empno + "'");
            geteid = cm.GetSpecificDataFromDB("emp_EmpID", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + empno + "'");
            getbid = cm.GetSpecificDataFromDB("emp_BiometricsID", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + empno + "'");
            getassign = cm.GetSpecificDataFromDB("emp_Assignment", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + empno + "'");
            getgender = cm.GetSpecificDataFromDB("emp_Gender", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + empno + "'");
            getpaytype = cm.GetSpecificDataFromDB("emp_PayType", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + empno + "'");
            getpos = cm.GetSpecificDataFromDB("emp_Position", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + empno + "'");
            getdept = cm.GetSpecificDataFromDB("emp_Department", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + empno + "'");
            getstart = cm.FormatDate(cm.GetSpecificDataFromDB("emp_DateStart", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + empno + "'"));
            getsss = cm.GetSpecificDataFromDB("emp_SSSNo", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + empno + "'");
            gettin = cm.GetSpecificDataFromDB("emp_TIN", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + empno + "'");
            getpagibig = cm.GetSpecificDataFromDB("emp_PagibigNo", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + empno + "'");
            getphilhealth = cm.GetSpecificDataFromDB("PhilHealth_No", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + empno + "'");
            getnationalid = cm.GetSpecificDataFromDB("emp_NationalIDNo", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + empno + "'");
            getlicno = cm.GetSpecificDataFromDB("emp_LicNo", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + empno + "'");
            getlicexp = cm.FormatDate(cm.GetSpecificDataFromDB("emp_LicExpDate", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + empno + "'"));
            getstat = cm.GetSpecificDataFromDB("emp_Status", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + empno + "'");
            getrank = cm.GetSpecificDataFromDB("emp_Rank", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + empno + "'");
            getapp1 = cm.GetSpecificDataFromDB("emp_Approver1", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + empno + "'");
            getapp2 = cm.GetSpecificDataFromDB("emp_Approver2", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + empno + "'");
            */

            Dictionary<string, string> empDict = cm.GetTableDict("TBL_EMPLOYEE_MASTER", " where emp_EmpID = '" + empno + "'");
            getsurname = empDict["emp_Surname"];
            getfname = empDict["emp_FirstName"];
            getmname = empDict["emp_MidName"];
            getnname = empDict["emp_NickName"];
            getsuffix = empDict["emp_Suffix"];
            geteid = empDict["emp_EmpID"];
            //getbid = empDict["emp_BiometricsID"];
            getassign = empDict["emp_Assignment"];
            getgender = empDict["emp_Gender"];
            getpaytype = empDict["emp_PayType"];
            getpos = empDict["emp_Position"];
            getdept = empDict["emp_Department"];
            getstart = cm.FormatDate(empDict["emp_DateStart"]);
            getsss = empDict["emp_SSSNo"];
            gettin = empDict["emp_TIN"];
            getpagibig = empDict["emp_PagibigNo"];
            getphilhealth = empDict["PhilHealth_No"];
            getnationalid = empDict["emp_NationalIDNo"];
            getlicno = empDict["emp_LicNo"];
            getlicexp = cm.FormatDate(empDict["emp_LicExpDate"]);
            getstat = empDict["emp_Status"];
            getrank = empDict["emp_Rank"];
            getapp1 = empDict["emp_Approver1"];
            getapp2 = empDict["emp_Approver2"];
            getregdate = cm.FormatDate(empDict["emp_RegularizationDate"]);
            getleavecredit = empDict["LeaveCreditPerYear"];
            getlocation = empDict["emp_Location"];
        }

        public void addlog()
        {
            if (getsurname != emp_Surname.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employee SURNAME for " + empno + " " + db.GetEmployeeName(empno) + " from " + getsurname + " to " + emp_Surname.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getfname != emp_FirstName.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employee FIRSTNAME for " + empno + " " + db.GetEmployeeName(empno) + " from " + getfname + " to " + emp_FirstName.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getmname != emp_MidName.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employee MIDDLE NAME for " + empno + " " + db.GetEmployeeName(empno) + " from " + getmname + " to " + emp_MidName.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getnname != emp_NickName.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employee NICKNAME for " + empno + " " + db.GetEmployeeName(empno) + " from " + getnname + " to " + emp_NickName.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getsuffix != emp_Suffix.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employee SUFFIX for " + empno + " " + db.GetEmployeeName(empno) + " from " + getsuffix + " to " + emp_Suffix.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (geteid != emp_EmpID.Text)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employee EMPLOYEE NO. for " + empno + " " + db.GetEmployeeName(empno) + " from " + geteid + " to " + emp_EmpID.Text,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            //if (getbid != emp_BiometricsID.Text)
            //{
            //    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employee BIOMETRICS ID for " + db.GetEmployeeName(empno) + " from " + getbid + " to " + emp_BiometricsID.Text,
            //        "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            //}
            if (getassign != emp_Assignment.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employee ASSIGNMENT for " + empno + " " + db.GetEmployeeName(empno) + " from " + getassign + " to " + emp_Assignment.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getgender != emp_Gender.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employee GENDER for " + empno + " " + db.GetEmployeeName(empno) + " from " + getgender + " to " + emp_Gender.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getpaytype != emp_PayType.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employee PAYTYPE for " + empno + " " + db.GetEmployeeName(empno) + " from " + getpaytype + " to " + emp_PayType.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getpos != emp_Position.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employee POSITION for " + empno + " " + db.GetEmployeeName(empno) + " from " + getpos + " to " + emp_Position.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getdept != emp_Department.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employee DEPARTMENT for " + empno + " " + db.GetEmployeeName(empno) + " from " + getdept + " to " + emp_Department.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getstart != cm.FormatDate(emp_DateStart.Value))
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employee START DATE for " + empno + " " + db.GetEmployeeName(empno) + " from " + getstart + " to " + emp_DateStart.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getsss != emp_SSSNo.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employee SSS NO. for " + empno + " " + db.GetEmployeeName(empno) + " from " + getsss + " to " + emp_SSSNo.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (gettin != emp_TIN.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employee TIN for " + empno + " " + db.GetEmployeeName(empno) + " from " + gettin + " to " + emp_TIN.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getpagibig != emp_PagibigNo.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employee PAGIBIG NO. for " + empno + " " + db.GetEmployeeName(empno) + " from " + getpagibig + " to " + emp_PagibigNo.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getphilhealth != PhilHealth_No.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employee PHILHEALTH NO. for " + empno + " " + db.GetEmployeeName(empno) + " from " + getphilhealth + " to " + PhilHealth_No.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getnationalid != emp_NationalIDNo.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employee NATIONAL ID NO. for " + empno + " " + db.GetEmployeeName(empno) + " from " + getnationalid + " to " + emp_NationalIDNo.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getlicno != emp_LicNo.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employee LICENSE NO. for " + empno + " " + db.GetEmployeeName(empno) + " from " + getlicno + " to " + emp_LicNo.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getlicexp != emp_LicExpDate.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employee LICENSE EXPIRATION DATE for " + empno + " " + db.GetEmployeeName(empno) + " from " + getlicexp + " to " + emp_LicExpDate.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getstat != emp_Status.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employee STATUS for " + empno + " " + db.GetEmployeeName(empno) + " from " + getstat + " to " + emp_Status.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getrank != emp_Rank.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employee RANK for " + empno + " " + db.GetEmployeeName(empno) + " from " + getrank + " to " + emp_Rank.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getapp1 != emp_Approver1.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employee APPROVER 1 for " + empno + " " + db.GetEmployeeName(empno) + " from " + getapp1 + " to " + emp_Approver1.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getapp2 != emp_Approver2.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employee APPROVER 2 for " + empno + " " + db.GetEmployeeName(empno) + " from " + getapp2 + " to " + emp_Approver2.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getregdate != emp_RegularizationDate.Value)
            {
                string getleaveexpiry = cm.GetSpecificDataFromDB("Expiry", "TBL_LEAVES", "where EmpID = '" + empno + "'");
                DateTime dtLeaveExpiry = new DateTime();
                DateTime dtRegDate = new DateTime();
                DateTime dtRegDatePlusYears = new DateTime();
                if (DateTime.TryParse(getleaveexpiry, out dtLeaveExpiry) && emp_RegularizationDate.Value != "")
                {
                    if (DateTime.TryParse(emp_RegularizationDate.Value, out dtRegDate))
                    {
                        dtRegDatePlusYears = new DateTime(dtLeaveExpiry.Year, dtRegDate.Month, dtRegDate.Day);
                        cm.UpdateQueryCommon("Expiry", "'" + cm.FormatDate(dtRegDatePlusYears) + "'", "TBL_LEAVES", "EmpID = '" + empno + "'");
                    }

                }
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employee Regularization Date for " + db.GetEmployeeName(empno) + " from " + getregdate + " to " + emp_RegularizationDate.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getleavecredit != LeaveCreditPerYear.Text)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employee Leave Credit Per Year for " + db.GetEmployeeName(empno) + " from " + getleavecredit + " to " + LeaveCreditPerYear.Text,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getlocation != emp_Location.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Employee Location for " + empno +" "+ db.GetEmployeeName(empno) + " from " + getlocation + " to " + emp_Location.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
        }
        #endregion

        public string ValidID()
        {
            string vldid = "";
            vldid = db.ValidateID(emp_EmpID.Text);
            return vldid;
        }
        //public string ValidBioID()
        //{
        //    string vldid = "";
        //    vldid = db.ValidateBioID(emp_BiometricsID.Text);
        //    return vldid;
        //}
        protected void Employee_EmpID_TextChanged(object sender, EventArgs e)
        {

            ret = ValidID();
            if (ret != "0")
            {

                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Employee ID Number " + emp_EmpID.Text + " Already Registered');", true);
                emp_EmpID.Text = empInfo["emp_EmpID"].ToString();
                //emp_BiometricsID.Text = empInfo["emp_BiometricsID"].ToString();
            }
        }
        //protected void emp_ID_TextChanged(object sender, EventArgs e)
        //{
        //    ret = ValidID();
        //    if (ret != "0")
        //    {

        //        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Employee ID Number " + emp_EmpID.Text + " Already Registered');", true);
        //        emp_EmpID.Text = empInfo["emp_EmpID"].ToString();
        //        emp_BiometricsID.Text = empInfo["emp_BiometricsID"].ToString();
        //    }
        //}
        //protected void Employee_BACode_TextChanged(object sender, EventArgs e)
        //{
        //    ret = ValidBioID();
        //    if (ret != "0")
        //    {

        //        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Biometrics ID Number " + emp_BiometricsID.Text + " is Already Registered');", true);
        //        emp_EmpID.Text = empInfo["emp_EmpID"].ToString();
        //        emp_BiometricsID.Text = empInfo["emp_BiometricsID"].ToString();
        //    }
        //}
    }
}