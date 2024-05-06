using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.HRRecruitment
{
    public partial class createapplicant : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Common cm = new Common();
        User _user = new User();
        string mrid = "", hrmrid = "", divid = "";

        Dictionary<string, string> userinfo = new Dictionary<string, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            mrid = Request.QueryString["mrid"]; hrmrid = Request.QueryString["hrmrid"]; divid = Request.QueryString["divid"];
            if (!IsPostBack)
            {
                if (Session["ROLES"].ToString() != "admin")
                {
                    Response.Redirect("~/Pages/Login.aspx");
                }

                if (Session["USERID"].ToString() != "")
                {
                    userinfo = _user.GetUserInfoDict(Session["USERID"].ToString());
                    Applicant_Surname.Value = userinfo["lastname"].ToUpperInvariant();
                    Applicant_FirstName.Value = userinfo["firstname"].ToUpperInvariant();
                    Applicant_Midname.Value = userinfo["midname"].ToUpperInvariant();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Please login as applicant or employee.');window.location ='../../Default_kioskapplicant.aspx';", true);

                }
            }

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if (cm.InsertQueryCommon(saveParam(), "TBL_APPLICANT"))
                {
                    Reset();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Save !!!');", true);
                }
            }
        }

        Dictionary<string, string> saveParam()
        {

            //string tagname = txtEmployee_Surname.Controls;
            //string Clienti = txtEmployee_Surname.ClientID;
            //string aaso = txtEmployee_Surname.UniqueID;


            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("userid", Session["USERID"].ToString());
            param.Add("mrid", mrid);
            param.Add("hrmrid", hrmrid);
            param.Add("division", divid);

            param.Add("SSS", "'" + Applicant_SSS.Value + "'");
            param.Add("BranchCode", "'" + Applicant_BranchCode.Value + "'");
            param.Add("EmploymentType", "'" + Applicant_EmploymentType.Value + "'");
            param.Add("PositionDesired", "'" + Applicant_PositionDesired.Value + "'");
            param.Add("DateReceived", "'" + DateReceived.Value + "'");
            param.Add("Surname", "'" + Applicant_Surname.Value + "'");
            param.Add("FirstName", "'" + Applicant_FirstName.Value + "'");
            param.Add("Midname", "'" + Applicant_Midname.Value + "'");
            param.Add("FullName", "'" + Applicant_Surname.Value + " " + Applicant_FirstName.Value + " " + Applicant_Midname.Value + "'");

            param.Add("BirthDate", "'" + BirthDate.Value + "'");
            param.Add("EmailAddress", "'" + Applicant_EmailAddress.Value + "'");
            param.Add("PhilhealthNo", "'" + Applicant_PhilhealthNo.Value + "'");
            param.Add("PagibigNo", "'" + Applicant_PagibigNo.Value + "'");
            param.Add("TinNo", "'" + Applicant_TinNo.Value + "'");
            param.Add("NationalIDNo", "'" + Applicant_NationalIDNo.Value + "'");
            param.Add("Gender", "'" + Applicant_Gender.Value + "'");
            param.Add("AStatus", "'" + Applicant_Status.Value + "'");
            param.Add("appStatus", "'" + Applicant_Status.Value + "'");
            param.Add("Celphone", "'" + Applicant_Celphone.Value + "'");
            param.Add("Address1", "'" + Applicant_Address.Value + "'");
            param.Add("Address2", "'" + Applicant_Address2.Value + "'");
            param.Add("ASource", "'" + Applicant_Source.Value + "'");

            param.Add("failed", "'0'");
            param.Add("shortlisted", "'0'");
            param.Add("Blacklist", "'0'");



            return param;


        }
        void Reset()
        {
            Applicant_SSS.Value = "";
            Applicant_BranchCode.Value = "";
            Applicant_EmploymentType.Value = "";
            Applicant_PositionDesired.Value = "";
            DateReceived.Value = "";
            Applicant_Surname.Value = "";
            Applicant_FirstName.Value = "";
            Applicant_Midname.Value = "";
            BirthDate.Value = "";
            Applicant_EmailAddress.Value = "";
            Applicant_PhilhealthNo.Value = "";
            Applicant_PagibigNo.Value = "";
            Applicant_TinNo.Value = "";
            Applicant_NationalIDNo.Value = "";
            Applicant_Gender.Value = "";
            Applicant_Status.Value = "";
            Applicant_Status.Value = "";
            Applicant_Celphone.Value = "";
            Applicant_Address.Value = "";
            Applicant_Address2.Value = "";
            Applicant_Source.Value = "";


        }
    }
}