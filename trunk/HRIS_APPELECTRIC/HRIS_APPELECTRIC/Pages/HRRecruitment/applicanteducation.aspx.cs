using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.HRRecruitment
{
    public partial class applicanteducation : System.Web.UI.Page
    {
        public string applicantid = "";
        public Common cm = new Common();
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
            applicantid = Request.QueryString["id"];
            applicantInfo = cm.GetTableDict("TBL_APPLICANT", "where id = " + applicantid + "");


            Applicant_Elementary.Value = applicantInfo["Elementary"];
            Applicant_HighSchool.Value = applicantInfo["HighSchool"];
            Applicant_College.Value = applicantInfo["College"];
            Applicant_masterdegree.Value = applicantInfo["masterdegree"];
            Applicant_doctoraldegree.Value = applicantInfo["doctoraldegree"];

            Applicant_ElementaryYear.Value = applicantInfo["ElementaryYear"];
            Applicant_HighSchoolYear.Value = applicantInfo["HighSchoolYear"];
            Applicant_CollegeYear.Value = applicantInfo["CollegeYear"];
            Applicant_masteryear.Value = applicantInfo["masteryear"];
            Applicant_doctoralyear.Value = applicantInfo["doctoralyear"];
        }
        Dictionary<string, string> saveUpdateParam(string Elementary, string HighSchool, string College, string masterdegree, string doctoraldegree, string ElementaryYear, string HighSchoolYear, string CollegeYear, string masteryear, string doctoralyear)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("Elementary", "'" + Elementary + "'");
            param.Add("HighSchool", "'" + HighSchool + "'");
            param.Add("College", "'" + College + "'");
            param.Add("masterdegree", "'" + masterdegree + "'");
            param.Add("doctoraldegree", "'" + doctoraldegree + "'");
            param.Add("ElementaryYear", "'" + ElementaryYear + "'");
            param.Add("HighSchoolYear", "'" + HighSchoolYear + "'");
            param.Add("CollegeYear", "'" + CollegeYear + "'");
            param.Add("masteryear", "'" + masteryear + "'");
            param.Add("doctoralyear", "'" + doctoralyear + "'");

            return param;


        }
        protected void btnsaveUpdate_Click(object sender, EventArgs e)
        {


            cm.UpdateQueryCommon(saveUpdateParam(Applicant_Elementary.Value, Applicant_HighSchool.Value, Applicant_College.Value, Applicant_masterdegree.Value, Applicant_doctoraldegree.Value, Applicant_ElementaryYear.Value, Applicant_HighSchoolYear.Value, Applicant_CollegeYear.Value, Applicant_masteryear.Value, Applicant_doctoralyear.Value), "TBL_APPLICANT", "id = " + applicantid + "");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Successfully Saved');window.location ='applicanteducation.aspx?id=" + applicantid + "';", true);



        }
    }
}