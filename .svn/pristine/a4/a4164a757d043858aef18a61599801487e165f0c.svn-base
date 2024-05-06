using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.HRRecruitment
{
    public partial class applicantselrequirements : System.Web.UI.Page
    {
        public string applicantid = "";
        public HR hr = new HR();
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

        Dictionary<string, string> saveParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();

            param.Add(Diploma.ID, (Diploma.Checked ? "'Y'" : "'N'"));
            param.Add(NBI.ID, (NBI.Checked ? "'Y'" : "'N'"));
            param.Add(Medical.ID, (Medical.Checked ? "'Y'" : "'N'"));
            param.Add(Clearance.ID, (Clearance.Checked ? "'Y'" : "'N'"));
            param.Add(TOR.ID, (TOR.Checked ? "'Y'" : "'N'"));
            param.Add(BC.ID, (BC.Checked ? "'Y'" : "'N'"));
            param.Add(SSI.ID, (SSI.Checked ? "'Y'" : "'N'"));
            param.Add(ECC.ID, (ECC.Checked ? "'Y'" : "'N'"));
            param.Add(PC.ID, (PC.Checked ? "'Y'" : "'N'"));

            param.Add(Resume_CV.ID, (Resume_CV.Checked ? "'Y'" : "'N'"));
            param.Add(Cedula.ID, (Cedula.Checked ? "'Y'" : "'N'"));
            param.Add(HDMF.ID, (HDMF.Checked ? "'Y'" : "'N'"));
            param.Add(DL.ID, (DL.Checked ? "'Y'" : "'N'"));




            return param;


        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {



            if (hr.UpdateQueryCommon(saveParam(), "TBL_APPLICANT", "id = " + applicantid + ""))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Save !!!');", true);

            }

            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Failed to save file !!!');", true);


            }
        }

        public void populateUpdateField()
        {
            if (applicantInfo["Diploma"].ToString() == "Y")
            {
                Diploma.Checked = true;
            }
            if (applicantInfo["NBI"].ToString() == "Y")
            {
                NBI.Checked = true;
            }
            if (applicantInfo["Medical"].ToString() == "Y")
            {
                Medical.Checked = true;
            }
            if (applicantInfo["Clearance"].ToString() == "Y")
            {
                Clearance.Checked = true;
            }
            if (applicantInfo["TOR"].ToString() == "Y")
            {
                TOR.Checked = true;
            }
            if (applicantInfo["BC"].ToString() == "Y")
            {
                BC.Checked = true;
            }
            if (applicantInfo["SSI"].ToString() == "Y")
            {
                SSI.Checked = true;
            }
            if (applicantInfo["ECC"].ToString() == "Y")
            {
                ECC.Checked = true;
            }
            if (applicantInfo["PC"].ToString() == "Y")
            {
                PC.Checked = true;
            }
            if (applicantInfo["Resume_CV"].ToString() == "Y")
            {
                Resume_CV.Checked = true;
            }
            if (applicantInfo["Cedula"].ToString() == "Y")
            {
                Cedula.Checked = true;
            }
            if (applicantInfo["HDMF"].ToString() == "Y")
            {
                HDMF.Checked = true;
            }
            if (applicantInfo["DL"].ToString() == "Y")
            {
                DL.Checked = true;
            }
        }
    }
}