using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.HRRecruitment
{
    public partial class applicantupdexperience : System.Web.UI.Page
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


            Applicant_Postion1.Value = applicantInfo["Postion1"];
            Applicant_Year1.Value = applicantInfo["Year1"];
            Applicant_CompanyName1.Value = applicantInfo["CompanyName1"];

            Applicant_Postion2.Value = applicantInfo["Postion2"];
            Applicant_Year2.Value = applicantInfo["Year2"];
            Applicant_CompanyName2.Value = applicantInfo["CompanyName2"];

            Applicant_Postion3.Value = applicantInfo["Postion3"];
            Applicant_Year3.Value = applicantInfo["Year3"];
            Applicant_CompanyName3.Value = applicantInfo["CompanyName3"];
        }
        Dictionary<string, string> saveUpdateParam(string Postion1, string Year1, string CompanyName1, string Postion2, string Year2, string CompanyName2, string Postion3, string Year3, string CompanyName3)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("Postion1", "'" + Postion1 + "'");
            param.Add("Year1", "'" + Year1 + "'");
            param.Add("CompanyName1", "'" + CompanyName1 + "'");
            param.Add("Postion2", "'" + Postion2 + "'");
            param.Add("Year2", "'" + Year2 + "'");
            param.Add("CompanyName2", "'" + CompanyName2 + "'");
            param.Add("Postion3", "'" + Postion3 + "'");
            param.Add("Year3", "'" + Year3 + "'");
            param.Add("CompanyName3", "'" + CompanyName3 + "'");


            return param;


        }
        protected void btnsaveUpdate_Click(object sender, EventArgs e)
        {


            cm.UpdateQueryCommon(saveUpdateParam(Applicant_Postion1.Value, Applicant_Year1.Value, Applicant_CompanyName1.Value, Applicant_Postion2.Value, Applicant_Year2.Value, Applicant_CompanyName2.Value, Applicant_Postion3.Value, Applicant_Year3.Value, Applicant_CompanyName3.Value), "TBL_APPLICANT", "id = " + applicantid + "");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Successfully Saved');window.location ='applicantupdexperience.aspx?id=" + applicantid + "';", true);



        }
    }
}