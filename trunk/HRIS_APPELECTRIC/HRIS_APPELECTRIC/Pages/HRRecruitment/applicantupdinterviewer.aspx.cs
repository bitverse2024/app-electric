using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.HRRecruitment
{
    public partial class applicantupdinterviewer : System.Web.UI.Page
    {
        public string applicantid = "";
        public Common cm = new Common();
        public Employee emp = new Employee();
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


                populateMenus();
            }
            //setDropdownValues();
        }
        void populateMenus()
        {
            Applicant_Interviewer1.Items.AddRange(cm.GetDropDownMenuList("TBL_EMPLOYEE_MASTER", "emp_FullName", "emp_EmpID"));
            Applicant_Interviewer1.Value = cm.GetSpecificDataFromDB("Interviewer1", "TBL_APPLICANT", " where id = " + applicantid + "");
            Applicant_Interviewer2.Items.AddRange(cm.GetDropDownMenuList("TBL_EMPLOYEE_MASTER", "emp_FullName", "emp_EmpID"));
            Applicant_Interviewer2.Value = cm.GetSpecificDataFromDB("Interviewer2", "TBL_APPLICANT", " where id = " + applicantid + "");
            Applicant_Interviewer3.Items.AddRange(cm.GetDropDownMenuList("TBL_EMPLOYEE_MASTER", "emp_FullName", "emp_EmpID"));
            Applicant_Interviewer3.Value = cm.GetSpecificDataFromDB("Interviewer3", "TBL_APPLICANT", " where id = " + applicantid + "");

        }

        Dictionary<string, string> saveUpdateParam(string Interviewer1, string Interviewer2, string Interviewer3)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("Interviewer1", "'" + Interviewer1 + "'");
            param.Add("Interviewer2", "'" + Interviewer2 + "'");
            param.Add("Interviewer3", "'" + Interviewer3 + "'");

            return param;

        }

        protected void btnsaveUpdate_Click(object sender, EventArgs e)
        {
            if (Applicant_Interviewer1.Value != "" && Applicant_Interviewer2.Value != "" && Applicant_Interviewer3.Value != "")
            {
                cm.UpdateQueryCommon(saveUpdateParam(Applicant_Interviewer1.Value, Applicant_Interviewer2.Value, Applicant_Interviewer1.Value), "TBL_APPLICANT", "id = " + applicantid + "");

                //db_Emp.updateUserInfo(HiddenEmpID.Value, txtbox_username.Text, txtbox_password.Text, (drpdwn_acctstatus.SelectedValue == "1" ? true : false));
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully updated !!!');", true);


            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Fields should not be empty !!!');", true);
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Applicant_Interviewer1.Value = "";
            Applicant_Interviewer2.Value = "";
            Applicant_Interviewer3.Value = "";
        }
    }
}