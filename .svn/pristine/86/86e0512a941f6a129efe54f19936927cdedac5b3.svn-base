using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin.Employees._201
{
    public partial class AllowanceSetting : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Common cm = new Common();
        public string empno = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                empno = Request.QueryString["id"];
                if (!IsPostBack)
                {
                    if (Session["ROLES"] == null)
                    {
                        Session.Clear();
                        Session.Abandon();
                        Response.Redirect("~/Pages/Login.aspx");
                    }
                    if (Session["ROLES"].ToString() != "admin")
                    {
                        Session.Clear();
                        Session.Abandon();
                        Response.Redirect("~/Pages/Login.aspx");
                    }
                    populateUpdateField(empno);
                }
            }
            catch
            {
                Session.Clear();
                Session.Abandon();
                Response.Redirect("~/Pages/Login.aspx");
            }
        }

        public string getname()
        {
            string name = "";
            name = emp.GetEmployeeName(empno);

            return name;

        }
        public void populateUpdateField(string id)
        {
            Dictionary<string, string> getDict = new Dictionary<string, string>();
            getDict = cm.GetTableDict("TBL_ALLOWANCESETTING", " where EmpID = '" + id + "'");
            string AllowanceType = "";
            string AllowanceAmount = "0";
            string AllowanceFrequency = "";
            string AllowanceNumberOfDaysWorked = "0";
            if (getDict.Count > 0)
            {AllowanceType = getDict["AllowanceType"];
                AllowanceAmount = getDict["AllowanceAmount"];
                AllowanceFrequency = getDict["AllowanceFrequency"];
                AllowanceNumberOfDaysWorked = getDict["NumberOfDaysWorked"];
            }
            double getallowanceamt = 0, getNumberOfDaysWorked = 0;
            double.TryParse(AllowanceAmount, out getallowanceamt);
            double.TryParse(AllowanceNumberOfDaysWorked, out getNumberOfDaysWorked);
            if (AllowanceType == "1" || AllowanceType == "")
            {
                ddlAllowanceFrequency.SelectedValue = AllowanceFrequency;
                rbAllowanceType.SelectedValue = AllowanceType;
                txtAllowanceAmount.Text = "0";
                txtAllowanceAmount.Enabled = false;
            }
            else if(AllowanceType == "2")
            {
                ddlAllowanceFrequency.SelectedValue = AllowanceFrequency;
                rbAllowanceType.SelectedValue = AllowanceType;
                txtAllowanceAmount.Text = getallowanceamt.ToString();
                txtAllowanceAmount.Enabled = true;
                txtNumberOfDaysWorked.Text = getNumberOfDaysWorked.ToString();
            }
            else if (AllowanceType == "3")
            {
                ddlAllowanceFrequency.SelectedValue = AllowanceFrequency;
                rbAllowanceType.SelectedValue = AllowanceType;
                txtAllowanceAmount.Text = getallowanceamt.ToString();
                txtAllowanceAmount.Enabled = true;
                txtNumberOfDaysWorked.Text = getNumberOfDaysWorked.ToString();
            }
        }


        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string emppayrollmode = cm.GetSpecificDataFromDB("payrollmode", "TBL_EMPLOYEE_MASTER A, TBL_PAYROLLGRP B", "where A.emp_PayrollGroup = B.id AND emp_EmpID = '" + empno + "'");
            if (rbAllowanceType.SelectedValue != "1" && rbAllowanceType.SelectedValue != "")
            {
                if (ddlAllowanceFrequency.SelectedValue == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Please select allowance frequency.');", true);
                    return;
                }
                if (ddlAllowanceFrequency.SelectedValue == "W4" || ddlAllowanceFrequency.SelectedValue == "W")
                {
                    if (emppayrollmode != "4")
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Please change employee payroll group to weekly first.');", true);
                        return;
                    }
                }
                if (ddlAllowanceFrequency.SelectedValue == "SM")
                {
                    if (emppayrollmode != "2")
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Please change employee payroll group to semi-monthly first.');", true);
                        return;
                    }
                }
            }
            if (!cm.ItemExist("TBL_ALLOWANCESETTING", "id", "where EmpID = '" + empno + "'", ""))
            {


                if (rbAllowanceType.SelectedValue != "1" && rbAllowanceType.SelectedValue != "" && ddlAllowanceFrequency.SelectedValue != "")
                {
                    if (emp.InsertQueryCommon(saveParam(), "TBL_ALLOWANCESETTING"))
                    {
                        cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " created Allowance amount: " + txtAllowanceAmount.Text,
                           "CREATE", "x123", "qwg-23", "CREATE", Session["EMP_ID"].ToString());
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Save !!!');", true);
                        populateUpdateField(empno);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Invalid Input !!!');", true);
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Invalid Input !!!');", true);
                    return;
                }




            }
            else if (cm.ItemExist("TBL_ALLOWANCESETTING", "id", "where EmpID = '" + empno + "'", ""))
            {
                Dictionary<string, string> getDict = new Dictionary<string, string>();
                getDict = cm.GetTableDict("TBL_ALLOWANCESETTING", " where EmpID = '" + empno + "'");
                string AllowanceType = "";
                string AllowanceAmount = "0";
                string AllowanceFrequency = "";
                string AllowanceNumberOfDaysWorked = "0";
                if (getDict.Count > 0)
                {
                    AllowanceType = getDict["AllowanceType"];
                    AllowanceAmount = getDict["AllowanceAmount"];
                    AllowanceFrequency = getDict["AllowanceFrequency"];
                    AllowanceNumberOfDaysWorked = getDict["NumberOfDaysWorked"];
                }

                if (rbAllowanceType.SelectedValue == "1" || rbAllowanceType.SelectedValue == "")
                {
                    ddlAllowanceFrequency.SelectedValue = "";
                }
                if (cm.UpdateQueryCommon(saveParam(), "TBL_ALLOWANCESETTING", " EmpID = '" + empno + "'"))
                {
                    if (rbAllowanceType.SelectedValue != AllowanceType)
                    {
                        cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " Update Allowance Type For Employee ID: " + empno + " Allowance Type From: " + AllowanceType + " To: " + rbAllowanceType.SelectedValue + "",
                        "UPDATE", "x123", "qwg-23", "UPDATE", Session["EMP_ID"].ToString());
                    }
                    if (txtAllowanceAmount.Text != AllowanceAmount)
                    {
                        cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " Update Allowance Amount For Employee ID: " + empno + " Allowance Type From: " + AllowanceAmount + " To: " + txtAllowanceAmount.Text + "",
                        "UPDATE", "x123", "qwg-23", "UPDATE", Session["EMP_ID"].ToString());
                    }
                    if (ddlAllowanceFrequency.SelectedValue != AllowanceFrequency)
                    {
                        cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " Update Allowance Frequency For Employee ID: " + empno + " Allowance Type From: " + AllowanceFrequency + " To: " + ddlAllowanceFrequency.SelectedValue + "",
                        "UPDATE", "x123", "qwg-23", "UPDATE", Session["EMP_ID"].ToString());
                    }
                    if (txtNumberOfDaysWorked.Text != AllowanceNumberOfDaysWorked)
                    {
                        cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " Update Allowance Number of Day Worked For Employee ID: " + empno + " Allowance Type From: " + AllowanceNumberOfDaysWorked + " To: " + txtNumberOfDaysWorked.Text + "",
                        "UPDATE", "x123", "qwg-23", "UPDATE", Session["EMP_ID"].ToString());
                    }
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " Update Allowance For Employee ID: " + empno + " AllowanceAmount To: " + txtAllowanceAmount.Text,
                        "UPDATE", "x123", "qwg-23", "UPDATE", Session["EMP_ID"].ToString());
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Updated !!!');", true);
                    populateUpdateField(empno);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Invalid Input !!!');", true);

                }



            }
        }
        Dictionary<string, string> saveParam()
        {

            //TBL_ALLOWANCESETTING
            Dictionary<string, string> param = new Dictionary<string, string>();
            string AllowanceType = "1";
            string AllowanceFrequency = ddlAllowanceFrequency.SelectedValue;
            
            if (rbAllowanceType.SelectedValue == "" || rbAllowanceType.SelectedValue == "1")
            {
                AllowanceType = "1";
                AllowanceFrequency = "";
            }
            else
                AllowanceType = rbAllowanceType.SelectedValue;
            param.Add("EmpID", "'" + empno + "'");
            param.Add("AllowanceType", "'" + AllowanceType + "'");
            param.Add("AllowanceAmount", "" + txtAllowanceAmount.Text == "" ? "0" : txtAllowanceAmount.Text + "");
            param.Add("AllowanceFrequency", "'" + ddlAllowanceFrequency.SelectedValue + "'");
            param.Add("NumberOfDaysWorked", "" + txtNumberOfDaysWorked.Text + "");




            return param;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            rbAllowanceType.SelectedValue = "1";
            txtAllowanceAmount.Text = "0";
            txtNumberOfDaysWorked.Text = "0";

        }
        protected void OnRadio_Changed(object sender, EventArgs e)
        {
            
            if (rbAllowanceType.SelectedItem.Value == "1" || rbAllowanceType.SelectedItem.Value == "")
            {
                ddlAllowanceFrequency.SelectedValue = "";
                txtAllowanceAmount.Text = "0";
                txtAllowanceAmount.Enabled = false;
                txtNumberOfDaysWorked.Text = "0";
                txtNumberOfDaysWorked.Enabled = false;
            }
            else if (rbAllowanceType.SelectedItem.Value == "2")
            {
                
                txtAllowanceAmount.Text = "0";
                txtAllowanceAmount.Enabled = true;
                txtNumberOfDaysWorked.Text = "0";
                txtNumberOfDaysWorked.Enabled = true;

            }
            else if (rbAllowanceType.SelectedItem.Value == "3")
            {
                
                txtAllowanceAmount.Text = "0";
                txtAllowanceAmount.Enabled = true;
                txtNumberOfDaysWorked.Text = "0";
                txtNumberOfDaysWorked.Enabled = true;
            }

            //string message = "Value: " + rblFruits.SelectedItem.Value;
            //message += " Text: " + rblFruits.SelectedItem.Text;
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
        }
    }
}