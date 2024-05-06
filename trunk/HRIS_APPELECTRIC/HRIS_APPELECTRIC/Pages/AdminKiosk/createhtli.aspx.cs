using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.AdminKiosk
{
    public partial class createhtli : System.Web.UI.Page
    {
        AdminLib ad = new AdminLib();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ROLES"].ToString() != "admin")
                {
                    Response.Redirect("~/Pages/Login.aspx");
                }
                refresh();
            }
        }

        void refresh()
        {
            Htli_Name.Value = "";
            Htli_Position.Value = "";
            Htli_Cp_Number.Value = "";
            Htli_Phone_Number.Value = "";
            Htli_Email.Value = "";


        }

        Dictionary<string, string> saveParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("Name", "'" + Htli_Name.Value + "'");
            param.Add("Position", "'" + Htli_Position.Value + "'");
            param.Add("Cp_Number", "'" + Htli_Cp_Number.Value + "'");
            param.Add("Phone_Number", "'" + Htli_Phone_Number.Value + "'");
            param.Add("Email", "'" + Htli_Email.Value + "'");




            return param;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (Htli_Name.Value != "" || Htli_Position.Value != "" || Htli_Cp_Number.Value != "" || Htli_Phone_Number.Value != "" || Htli_Email.Value != "")
            {
                if (ad.InsertQueryCommon(saveParam(), "TBL_HTLI"))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Save !!!');", true);
                    refresh();

                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Please fill required fields');", true);
                refresh();
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

            refresh();

        }
    }
}