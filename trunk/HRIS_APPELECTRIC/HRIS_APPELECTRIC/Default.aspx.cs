﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HRIS_APPELECTRIC
{
    public partial class _Default : Page
    {
        Employee emp = new Employee();
        Timekeeping tk = new Timekeeping();
        AdminLib adlib = new AdminLib();
        Common cm = new Common();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //if (Session["AUTHEN_STATUS"] == "1")
                //{
                try
                {
                    if (Session["ROLES"].ToString() == "employee")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(),
                    "alert",
                    "alert('Please login as admin.');window.location ='Default_kiosk.aspx';", true);
                    }
                    if (Session["ROLES"].ToString() == "applicant")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(),
                    "alert",
                    "alert('Please login as admin.');window.location ='Default_kioskapplicant.aspx';", true);
                    }
                    else
                    {
                        //ResetLeaveCredit();
                        refresh();
                    }

                }
                catch
                {
                    Response.Redirect("~/Pages/Login.aspx");

                }
                    
                

                //}
                //else
                //{
                //    Response.Redirect("~/Pages/Login.aspx");
                //}

                //refresh();
            }
        }
        void refresh()
        {
            DataTable dt = new DataTable();
            dt = emp.populateGridEmployeeContEnd();
            GridExpCont.DataSource = dt;
            GridExpCont.DataBind();
            ViewState["EMP_GRID"] = dt;
            ViewState["SORTDR"] = null;

            dt = new DataTable();
            dt = tk.populateGridEmpLeave();
            GridEmpLeaves.DataSource = dt;
            GridEmpLeaves.DataBind();
            ViewState["EMP_GRID"] = dt;
            ViewState["SORTDR"] = null;

            dt = new DataTable();
            dt = emp.populateGridEmployeeBirthdate();
            GridEmpBdate.DataSource = dt;
            GridEmpBdate.DataBind();
            ViewState["EMP_GRID"] = dt;
            ViewState["SORTDR"] = null;

            dt = new DataTable();
            dt = emp.populateGridEmployee3Mos();
            Grid3Mos.DataSource = dt;
            Grid3Mos.DataBind();
            ViewState["EMP_GRID"] = dt;
            ViewState["SORTDR"] = null;

            dt = new DataTable();
            dt = emp.populateGridEmployee5Mos();
            Grid5Mos.DataSource = dt;
            Grid5Mos.DataBind();
            ViewState["EMP_GRID"] = dt;
            ViewState["SORTDR"] = null;

            dt = new DataTable();
            dt = emp.populateGridEmployeeAnniv();
            GridEmpAnniv.DataSource = dt;
            GridEmpAnniv.DataBind();
            ViewState["EMP_GRID"] = dt;
            ViewState["SORTDR"] = null;
        }
        //06/03/2022 Jan Wong. Automatic reset of leave credit
        void ResetLeaveCredit()
        {
            Dictionary<string, string> dictIDs = new Dictionary<string, string>();
            dictIDs = adlib.getLeaveIDs();
            foreach (KeyValuePair<string, string> leaveids in dictIDs)
            {
                Dictionary<string, string> getleaveDict = new Dictionary<string, string>();
                Dictionary<string, string> saveUpdateParam = new Dictionary<string, string>();
                Dictionary<string, string> saveLeaveToPayParam = new Dictionary<string, string>();
                getleaveDict = cm.GetTableDict("TBL_LEAVES", "where id = " + leaveids.Key + "");
                double getempleavecredit = 0;
                double.TryParse(cm.GetSpecificDataFromDB("LeaveCreditPerYear", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + getleaveDict["EmpID"] + "'"), out getempleavecredit);
                double leavebalance = 0;
                double.TryParse(getleaveDict["Remaining"], out leavebalance);
                DateTime dtNewExpiryDate = new DateTime();
                DateTime.TryParse(leaveids.Value, out dtNewExpiryDate);
                DateTime dtOldExpiryDate = new DateTime();
                DateTime.TryParse(getleaveDict["Expiry"], out dtOldExpiryDate);
                //dtRegDate = dtRegDate.AddYears(-1);// Jan Wong. Add -1 because Leaveids.Value is already have additional year from previous function. (getLeaveIDs)
                if (leavebalance <= 0)
                    continue;
                bool isLeaveToPayExist = cm.ItemExist("TBL_LEAVETOPAY", "id", "where EmpID = '" + getleaveDict["EmpID"] + "' AND creditYear = '" + dtOldExpiryDate.Year.ToString() + "' AND LeaveID = '" + leaveids.Key + "'");
                if (isLeaveToPayExist)
                    continue;
                if (getempleavecredit == 0)
                    continue;
                saveUpdateParam.Add("Allowed", ""+ getempleavecredit.ToString()+ "");
                saveUpdateParam.Add("Remaining", "" + getempleavecredit.ToString() + "");
                saveUpdateParam.Add("Used", "0");
                saveUpdateParam.Add("Expiry", "'" + cm.FormatDate(dtNewExpiryDate) + "'");
                saveLeaveToPayParam.Add("EmpID", "'" + getleaveDict["EmpID"] + "'");
                saveLeaveToPayParam.Add("LeaveBalance", ""+leavebalance+"");
                saveLeaveToPayParam.Add("creditYear", "'" + dtOldExpiryDate.Year.ToString() + "'");
                saveLeaveToPayParam.Add("LeaveID", "'" + leaveids.Key + "'");
                if (cm.UpdateQueryCommon(saveUpdateParam, "TBL_LEAVES", "id = " + leaveids.Key + ""))
                {
                    if(!cm.ItemExist("TBL_LEAVETOPAY","id", "where EmpID = '" + getleaveDict["EmpID"] + "' AND creditYear = '"+ dtOldExpiryDate.Year.ToString() + "' AND LeaveID = '"+ leaveids.Key + "'"))
                    {
                        if (cm.InsertQueryCommon(saveLeaveToPayParam, "TBL_LEAVETOPAY"))
                        {
                            cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " trigger auto reset of leave credit for Employee Number: "+ getleaveDict["EmpID"] + " from Allowed: "
                            + getleaveDict["Allowed"] + " to 5, Remaining: " + getleaveDict["Remaining"] + " to 5, Used: " + getleaveDict["Used"] + " to 0, " +
                            "Expiry: " + getleaveDict["Expiry"] + " to " + leaveids.Value,
                                   "UPDATE", "", "", "UPDATE", Session["EMP_ID"].ToString());
                        }
                        
                    }
                    //else
                    //{
                        //if(cm.UpdateQueryCommon(saveLeaveToPayParam,"TBL_LEAVETOPAY", " EmpID = '" + getleaveDict["EmpID"] + "' AND creditYear = '" + dtRegDate.Year + "'"))
                        //{
                        //    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " trigger auto reset of leave credit from Allowed: "
                        //    + getleaveDict["Allowed"] + " to 5, Remaining: " + getleaveDict["Remaining"] + " to 5, Used: " + getleaveDict["Used"] + " to 0, " +
                        //    "Expiry: " + getleaveDict["Expiry"] + " to " + leaveids.Value,
                        //           "UPDATE", "", "", "UPDATE", Session["EMP_ID"].ToString());
                        //}
                   // }
                    
                }

            }
        }
    }
}