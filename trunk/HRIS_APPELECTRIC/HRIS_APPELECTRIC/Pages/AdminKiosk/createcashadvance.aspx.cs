using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.AdminKiosk
{
    public partial class createcashadvance : System.Web.UI.Page
    {
        AdminLib ad = new AdminLib();
        Common cm = new Common();
        User _user = new User();
        Dictionary<string, string> userinfo = new Dictionary<string, string>();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["ROLES"].ToString() != "admin")
                {
                    Response.Redirect("~/Pages/Login.aspx");
                }

                if (Session["USERID"].ToString() != "")
                {
                    userinfo = _user.GetUserInfoDict(Session["USERID"].ToString());
                    refresh();
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Please login as employee.');window.location ='admincashadvance.aspx';", true);

                }

            }
        }

        void refresh()
        {
            Cash_ref_no.Value = "";
            Cash_particular.Value = "";
            Cash_coa_acct_no.Value = "";
            Cash_amount.Value = "";
            Cash_reason.Value = "";
            Cash_type.Value = "empty";


        }

        Dictionary<string, string> saveParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("requested_by", Session["USERID"].ToString());
            param.Add("date_requested", "'" + cm.FormatDate(DateTime.Now) + "'");
            param.Add("department", "'Not Set'");
            param.Add("position", "'Not Set'");
            param.Add("ref_date", "'Not Set'");
            param.Add("ref_no", "'" + Cash_ref_no.Value + "'");
            param.Add("particular", "'" + Cash_particular.Value + "'");
            param.Add("coa_acct_no", "'" + Cash_coa_acct_no.Value + "'");
            param.Add("type", "'" + Cash_type.SelectedIndex + "'");
            param.Add("amount", "'" + Cash_amount.Value + "'");
            param.Add("reason", "'" + Cash_reason.Value + "'");
            param.Add("total", "'Not Set'");




            return param;
        }

        protected void btnRequest_Click(object sender, EventArgs e)
        {
            if (Cash_ref_no.Value != "" || Cash_particular.Value != "" || Cash_coa_acct_no.Value != "" || Cash_amount.Value != "" || Cash_type.Value != "")
            {
                if (ad.InsertQueryCommon(saveParam(), "TBL_CASH"))
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