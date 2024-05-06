using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.HRRecruitment
{
    public partial class applicantprofileview : System.Web.UI.Page
    {
        public string applicantid = "";
        public Common cm = new Common();
        public Dictionary<string, string> applicantInfo = new Dictionary<string, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ROLES"].ToString() != "admin")
            {
                Response.Redirect("~/Pages/Login.aspx");
            }
            applicantid = Request.QueryString["id"];
            refresh();

        }
        void refresh()
        {
            applicantInfo = cm.GetTableDict("TBL_APPLICANT", "where id = " + applicantid + "");

        }
        protected void btn_MarkShortListed_Click(object sender, EventArgs e)
        {
            cm.UpdateQueryCommon("shortlisted", "'1'", "TBL_APPLICANT", "id = " + applicantid + "");
            refresh();
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Updated !!!');", true);


        }

        public string getRemarks(string remark)
        {
            string ret = "";
            if (remark.ToLowerInvariant() == "c")
            {
                ret = "Conditional";
            }
            if (remark.ToLowerInvariant() == "f")
            {
                ret = "Failed";
            }
            if (remark.ToLowerInvariant() == "p")
            {
                ret = "Passed";
            }
            return ret;
        }
    }
}