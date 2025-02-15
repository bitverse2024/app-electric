﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data.SqlClient;

namespace HRIS_APPELECTRIC.Pages.Admin.Employees
{
    public partial class CreateEmployee : System.Web.UI.Page
    {
        Employee db = new Employee();
        User dbUser = new User();
        Common cm = new Common();
        Timekeeping tm = new Timekeeping();
        public string apprvr1 = "";
        public string apprvr2 = "";
        public string ret = "";        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateMenus();
            }
        }

        void populateMenus()
        {

            //Employee_AssignmentCode

            Employee_PositionCode.Items.AddRange(db.GetDropDownMenuList("TBL_POSITION", "PositionName"));
            Employee_PayrollGrpCode.Items.AddRange(db.GetDropDownMenuList("TBL_PAYROLLGRP", "payrollgrpname"));
            Employee_DeptCode.Items.AddRange(db.GetDropDownMenuList("TBL_DEPARTMENT", "DeptName"));
            Employee_Status.Items.AddRange(db.GetDropDownMenuList("TBL_STATUS", "StatusDesc"));
            Employee_RankCode.Items.AddRange(db.GetDropDownMenuListRank("TBL_RANK", "RankName"));
            Employee_AssignmentCode.Items.AddRange(db.GetDropDownMenuList("TBL_COMPANY", "CoName"));
            //Employee_Approver1.Items.AddRange(db.GetDropDownMenuList("TBL_EMPLOYEE_MASTER", "emp_FullName"));
            //Employee_Approver2.Items.AddRange(db.GetDropDownMenuList("TBL_EMPLOYEE_MASTER", "emp_FullName"));
            Employee_Approver1.Items.AddRange(db.GetDropDownMenuListApprover("TBL_EMPLOYEE_MASTER", "emp_FullName"));
            Employee_Approver2.Items.AddRange(db.GetDropDownMenuListApprover("TBL_EMPLOYEE_MASTER", "emp_FullName"));
            emp_Location.Items.AddRange(db.GetDropDownMenuList("TBL_LOCATION", "LocationName"));

        }
        private void empID()
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            #region Input Validation
            if (txtEmployee_Surname.Value == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Surname is required !!!');", true);
                return;
            }
            if (Employee_FirstName.Value == "")
                return;
            //if (Employee_EmpID.Text == "")
            //    return;

            #endregion Input Validation

            //string confirmValue = Request.Form["confirm_value"];

            //if (confirmValue == "Yes")
            //{
                if (db.InsertQueryCommon(saveParam(), "TBL_EMPLOYEE_MASTER"))
                {
                    dbUser.InsertQueryCommon(saveUserParam(), "TBL_USERS");
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Save !!!');", true);
                    reset();
                }
            //}
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Admin/Employees/EmployeeMaster.aspx");
        }

        protected void reset()
        {
            txtEmployee_Surname.Value = "";
            Employee_FirstName.Value = "";
            Employee_MidName.Value = "";
            Employee_NickName.Value = "";
            Employee_EmpID.Text = "";
            //Employee_BACode.Text = "";
            Employee_AssignmentCode.Value = "";
            Employee_Gender.Value = "";
            Employee_DeptCode.Value = "";
            Employee_PositionCode.Value = "";
            Employee_DeptCode.Value = "";
            Employee_DateStart.Value = "";
            Employee_SSSNo.Value = "";
            Employee_TIN.Value = "";
            Employee_PagibigNo.Value = "";
            Employee_PhilHealth_No.Value = "";
            Employee_NationalIDNo.Value = "";
            Employee_LicNo.Value = "";
            Employee_LicExpDate.Value = "";
            Employee_Status.Value = "";
            Employee_RankCode.Value = "";
            Employee_Approver1.Value = "";
            Employee_Approver2.Value = "";
            Employee_PayrollGrpCode.Value = "";
            Employee_Email.Value = "";
            txtBasicPay.Value = "";
            ContEnd.Value = "";
            ContStart.Value = "";
            emp_RegularizationDate.Value = "";
            LeaveCreditPerYear.Text = "0";
            emp_Location.Value = "";
            emp_IsPioneer.Checked = false;
        }


        Dictionary<string, string> saveParam()
        {

            //string tagname = txtEmployee_Surname.Controls;
            //string Clienti = txtEmployee_Surname.ClientID;
            //string aaso = txtEmployee_Surname.UniqueID;
            int count = 0; string num = "0"; string deptcode = ""; string compvar = "A-";string fixNum = "00";

            if (Employee_AssignmentCode.SelectedIndex == 1)
                compvar = "A-";
            else if (Employee_AssignmentCode.SelectedIndex == 2)
                compvar = "M-";
            else
                compvar = "W-";
            num = db.getempcount().ToString();

            count = Convert.ToInt32(num) + 00;
            int count1 =  Convert.ToInt32(num) + 1;
            // var yearhired = DateTime.Now.ToString("yy");
            string contractyear = Convert.ToDateTime(Employee_DateStart.Value).ToString("yyyy-MM-dd");
            string yearhired = Convert.ToDateTime(contractyear).ToString("yy");
            deptcode = db.GetSpecificDeptID("id", "TBL_DEPARTMENT", "" + Employee_DeptCode.Value + "");
            string customEmpID = "";
            if (count.ToString().Length == 1)            
                customEmpID = compvar + deptcode + fixNum + yearhired + "0" + count.ToString();
            
            else if(count.ToString().Length > 1)
                customEmpID = compvar + deptcode + fixNum + yearhired + count.ToString();

            double sssded = 0;
            double philded = 0;                        
            sssded = tm.GetSSSDed(txtBasicPay.Value);
            philded = tm.GetPhilDed(txtBasicPay.Value);
            apprvr1 = db.GetSpecificEmpID("emp_EmpID", "TBL_EMPLOYEE_MASTER", "" + Employee_Approver1.Value + "");
            apprvr2 = db.GetSpecificEmpID("emp_EmpID", "TBL_EMPLOYEE_MASTER", "" + Employee_Approver2.Value + "");
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("emp_Surname", "'" + txtEmployee_Surname.Value + "'");
            param.Add("emp_FirstName", "'" + Employee_FirstName.Value + "'");
            param.Add("emp_MidName", "'" + Employee_MidName.Value + "'");
            param.Add("emp_NickName", "'" + Employee_NickName.Value + "'");
            param.Add("emp_Suffix", "'" + Employee_Suffix.Value + "'");
            param.Add("emp_FullName", "'" + txtEmployee_Surname.Value + ", " + Employee_FirstName.Value + " " + Employee_MidName.Value + "'");
            if (Employee_EmpID.Text != "")
                param.Add("emp_EmpID", "'" + Employee_EmpID.Text + "'");
            else
                param.Add("emp_EmpID", "'" + customEmpID + "'");
            
            //param.Add("emp_BiometricsID", "'" + customEmpID + "'");
            param.Add("emp_Assignment", "'" + Employee_AssignmentCode.Value + "'");
            param.Add("emp_Gender", "'" + Employee_Gender.Value + "'");
            param.Add("emp_Division", "" + db.GetEmployeeDivisionID(Employee_DeptCode.Value) + "");
            param.Add("emp_Position", "" + Employee_PositionCode.Value + "");
            param.Add("emp_Department", "" + Employee_DeptCode.Value + "");
            param.Add("emp_PayrollGroup", "" + Employee_PayrollGrpCode.Value + "");
            param.Add("emp_DateStart", "'" + cm.FormatDate(Employee_DateStart.Value) + "'");
            param.Add("emp_SSSNo", "'" + Employee_SSSNo.Value + "'");
            param.Add("emp_TIN", "'" + Employee_TIN.Value + "'");
            param.Add("emp_PagibigNo", "'" + Employee_PagibigNo.Value + "'");
            param.Add("PhilHealth_No", "'" + Employee_PhilHealth_No.Value + "'");
            param.Add("emp_NationalIDNo", "'" + Employee_NationalIDNo.Value + "'");
            param.Add("emp_LicNo", "'" + Employee_LicNo.Value + "'");
            param.Add("emp_LicExpDate", "'" + Employee_LicExpDate.Value + "'");
            param.Add("emp_Status", "'" + Employee_Status.Value + "'");
            param.Add("emp_Rank", "'" + Employee_RankCode.Value + "'");
            param.Add("emp_Approver1", "'" + Employee_Approver1.Value + "'");
            param.Add("emp_Approver2", "'" + Employee_Approver2.Value + "'");
            param.Add("emp_Monday", "2");
            param.Add("emp_Tuesday", "2");
            param.Add("emp_Wednesday", "2");
            param.Add("emp_Thursday", "2");
            param.Add("emp_Friday", "2");
            param.Add("emp_Saturday", "2");
            param.Add("emp_Sunday", "0");
            param.Add("emp_Active", "'Y'");
            param.Add("emp_Email", "'" + Employee_Email.Value + "'");
            param.Add("emp_BasicPay", "" + txtBasicPay.Value + "");
            param.Add("emp_WorkDays", "" + emp_WorkDays.Value + "");
            param.Add("emp_SSSDed", "" + sssded + "");
            param.Add("emp_PhilHealthDed", "" + philded + "");
            param.Add("emp_PagibigDed", "100");
            param.Add("emp_PayType", "'" + emp_PayType.Value + "'");
            param.Add("emp_Location", "'" + emp_Location.Value + "'");
            //param.Add("emp_TotalSalary", "" + txtTotal.Value + "");
            if (ContStart.Value != "")
            {
                param.Add("emp_ContractStart", "'" + cm.FormatDate(ContStart.Value) + "'");
            }
            if (ContEnd.Value != "")
            {
                param.Add("emp_ContractEnd", "'" + cm.FormatDate(ContEnd.Value) + "'");
            }
            if (ContStart.Value != "" && ContEnd.Value != "")
            {
                double days = (Convert.ToDateTime(ContEnd.Value) - Convert.ToDateTime(ContStart.Value)).TotalDays;
                param.Add("emp_ContractDuration", "'" + days.ToString() + "'");
            }
            if (emp_RegularizationDate.Value != "")
            {
                param.Add("emp_RegularizationDate", "'" + cm.FormatDate(emp_RegularizationDate.Value) + "'");
            }
            //06/15/2022 Jan Wong. LeaveCreditPerYear as LeaveCreditPerYear
            double leavecredit = 0;
            double.TryParse(LeaveCreditPerYear.Text, out leavecredit);
            param.Add("LeaveCreditPerYear", "'" + leavecredit.ToString() + "'");
            //06/15/2022 Jan Wong. LeaveCreditPerYear as LeaveCreditPerYear
            param.Add("emp_IsPioneer", emp_IsPioneer.Checked == true ? 1.ToString() : 0.ToString());
            param.Add("emp_isEnableContriDed", 1.ToString());
            param.Add("emp_isEnableLoanDed", 1.ToString());
            return param;


        }
        Dictionary<string, string> saveUserParam()
        {
            int count = 0; string num = "0"; string deptcode = ""; string compvar = "A-"; string fixNum = "00";

            if (Employee_AssignmentCode.SelectedIndex == 1)
                compvar = "A-";
            else if (Employee_AssignmentCode.SelectedIndex == 2)
                compvar = "M-";
            else
                compvar = "W-";
            num = db.getempcount().ToString();

            count = Convert.ToInt32(num) + 00;
            int count1 = Convert.ToInt32(num) + 1;
            // var yearhired = DateTime.Now.ToString("yy");
            string contractyear = Convert.ToDateTime(Employee_DateStart.Value).ToString("yyyy-MM-dd");
            string yearhired = Convert.ToDateTime(contractyear).ToString("yy");
            deptcode = db.GetSpecificDeptID("id", "TBL_DEPARTMENT", "" + Employee_DeptCode.Value + "");
            string customEmpID = "";
            if (count.ToString().Length == 1)
                customEmpID = compvar + deptcode + fixNum + yearhired + "0" + count.ToString();

            else if (count.ToString().Length > 1)
                customEmpID = compvar + deptcode + fixNum + yearhired + count.ToString();
            if(Employee_EmpID.Text != "")
                return dbUser.saveUserParam("password", Employee_FirstName.Value, Employee_MidName.Value, txtEmployee_Surname.Value, Employee_EmpID.Text, Employee_Email.Value);
            else
                return dbUser.saveUserParam("password", Employee_FirstName.Value, Employee_MidName.Value, txtEmployee_Surname.Value, customEmpID, Employee_Email.Value);
        }


        public string ValidID()
        {
            string vldid = "";
            vldid = db.ValidateID(Employee_EmpID.Text);
            return vldid;
        }
        public string ValidBioID()
        {
            string vldid = "";
            vldid = db.ValidateBioID(Employee_EmpID.Text);
            return vldid;
        }


        protected void Employee_EmpID_TextChanged(object sender, EventArgs e)
        {

            ret = ValidID();
            if (ret != "0")
            {

                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Employee ID Number " + Employee_EmpID.Text + " Already Registered');", true);
                Employee_EmpID.Text = "";
            }
        }

        //protected void Employee_BACode_TextChanged(object sender, EventArgs e)
        //{

        //    ret = ValidBioID();
        //    if (ret != "0")
        //    {

        //        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Biometrics ID Number " + Employee_BACode.Text + " is Already Registered');", true);
        //        //Employee_BACode.Text = "";
        //    }
        //}
    }
}