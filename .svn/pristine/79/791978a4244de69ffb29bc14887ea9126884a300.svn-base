using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Announcement
{
    public partial class addannouncement : System.Web.UI.Page
    {
        Employee db = new Employee();
        User dbUser = new User();
        Common cm = new Common();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ROLES"].ToString() == "employee")
                {
                    Response.Redirect("~/Pages/Login.aspx");
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if (Announcements_description.Value == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Description is required !!!');", true);
                    return;
                }


                if (db.InsertQueryCommon(saveParam(), "TBL_ANNOUNCEMENT"))
                {

                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Added !!!');", true);
                    Announcements_description.Value = "";
                }
            }
        }

        Dictionary<string, string> saveParam()
        {


            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("description", "'" + Announcements_description.Value + "'");


            return param;


        }
    }
}