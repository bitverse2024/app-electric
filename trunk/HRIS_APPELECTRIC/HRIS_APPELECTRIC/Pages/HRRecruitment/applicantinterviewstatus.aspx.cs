using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.HRRecruitment
{
    public partial class applicantinterviewstatus : System.Web.UI.Page
    {
        public string applicantid = "";
        public Common cm = new Common();
        HR hr = new HR();
        public Dictionary<string, string> applicantInfo = new Dictionary<string, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            applicantid = Request.QueryString["id"];
            applicantInfo = cm.GetTableDict("TBL_APPLICANT", "where id = " + applicantid + "");
            if (!IsPostBack)
            {
                if (Session["ROLES"].ToString() != "admin")
                {
                    Response.Redirect("~/Pages/Login.aspx");
                }

                populateUpdateField();
            }



        }

        public void populateUpdateField()
        {
            //upd_ApplicationPositionDesired.Value = cm.GetSpecificDataFromDB("PositionName", "TBL_POSITION");

            Applicant_Interviewer1.Value = cm.GetSpecificDataFromDB("emp_FullName", "TBL_EMPLOYEE_MASTER", "WHERE emp_EmpID = '" + applicantInfo["Interviewer1"] + "'");
            Applicant_Interviewer2.Value = cm.GetSpecificDataFromDB("emp_FullName", "TBL_EMPLOYEE_MASTER", "WHERE emp_EmpID = '" + applicantInfo["Interviewer2"] + "'");
            Applicant_Interviewer3.Value = cm.GetSpecificDataFromDB("emp_FullName", "TBL_EMPLOYEE_MASTER", "WHERE emp_EmpID = '" + applicantInfo["Interviewer3"] + "'");
            Applicant_I1Remarks.Value = cm.GetSpecificDataFromDB("I1Remarks", "TBL_APPLICANT", "WHERE id = '" + applicantid + "'");
            Applicant_I2Remarks.Value = cm.GetSpecificDataFromDB("I2Remarks", "TBL_APPLICANT", "WHERE id = '" + applicantid + "'");
            Applicant_I3Remarks.Value = cm.GetSpecificDataFromDB("I3Remarks", "TBL_APPLICANT", "WHERE id = '" + applicantid + "'");
            Applicant_I1.Value = cm.GetSpecificDataFromDB("I1", "TBL_APPLICANT", " where id = " + applicantid + "");
            Applicant_I2.Value = cm.GetSpecificDataFromDB("I2", "TBL_APPLICANT", " where id = " + applicantid + "");
            Applicant_I3.Value = cm.GetSpecificDataFromDB("I3", "TBL_APPLICANT", " where id = " + applicantid + "");

        }

        Dictionary<string, string> saveParam1(string Applicant_I1Remarks, string Applicant_I1)
        {

            Dictionary<string, string> param1 = new Dictionary<string, string>();

            param1.Add("I1Remarks", "'" + Applicant_I1Remarks + "'");
            param1.Add("I1", "'" + Applicant_I1 + "'");




            return param1;
        }
        Dictionary<string, string> saveParam2(string Applicant_I2Remarks, string Applicant_I2)
        {

            Dictionary<string, string> param2 = new Dictionary<string, string>();

            param2.Add("I2Remarks", "'" + Applicant_I2Remarks + "'");
            param2.Add("I2", "'" + Applicant_I2 + "'");


            return param2;
        }
        Dictionary<string, string> saveParam3(string Applicant_I3Remarks, string Applicant_I3)
        {

            Dictionary<string, string> param3 = new Dictionary<string, string>();
            param3.Add("I3Remarks", "'" + Applicant_I3Remarks + "'");
            param3.Add("I3", "'" + Applicant_I3 + "'");

            return param3;
        }
        protected void btnsaveUpdate1_Click(object sender, EventArgs e)
        {


            if (cm.UpdateQueryCommon(saveParam1(Applicant_I1Remarks.Value, Applicant_I1.Value), "TBL_APPLICANT", " id = '" + applicantid + "'"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Successfully Saved');window.location ='applicantinterviewstatus.aspx?id=" + applicantid + "';", true);

            }

            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Wrong Input');window.location ='applicantinterviewstatus.aspx?id=" + applicantid + "';", true);
            }
        }

        protected void btnsaveUpdate2_Click(object sender, EventArgs e)
        {


            if (cm.UpdateQueryCommon(saveParam2(Applicant_I2Remarks.Value, Applicant_I2.Value), "TBL_APPLICANT", " id = '" + applicantid + "'"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Successfully Saved');window.location ='applicantinterviewstatus.aspx?id=" + applicantid + "';", true);

            }

            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Wrong Input');window.location ='applicantinterviewstatus.aspx?id=" + applicantid + "';", true);
            }
        }

        protected void btnsaveUpdate3_Click(object sender, EventArgs e)
        {


            if (cm.UpdateQueryCommon(saveParam3(Applicant_I3Remarks.Value, Applicant_I3.Value), "TBL_APPLICANT", " id = '" + applicantid + "'"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Successfully Saved');window.location ='applicantinterviewstatus.aspx?id=" + applicantid + "';", true);

            }

            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Wrong Input');window.location ='applicantinterviewstatus.aspx?id=" + applicantid + "';", true);
            }
        }
    }
}