using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.AdminKiosk
{
    public partial class createofficesupplies : System.Web.UI.Page
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
            Officesupplies_item_Name.Value = "";
            Officesupplies_quantity.Value = "";

        }

        Dictionary<string, string> saveParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("item_Name", "'" + Officesupplies_item_Name.Value + "'");
            param.Add("quantity", "'" + Officesupplies_quantity.Value + "'");



            return param;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (Officesupplies_quantity.Value != "")
            {
                if (ad.InsertQueryCommon(saveParam(), "TBL_OFFICESUPPLIES"))
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