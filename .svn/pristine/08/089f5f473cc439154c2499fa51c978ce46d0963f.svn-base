using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC
{
    public partial class Default_kiosk : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["AUTHEN_STATUS"] == "1")
                {
                    if (Session["ROLES"].ToString() != "admin" && Session["ROLES"].ToString() != "employee")
                    {
                        Response.Redirect("~/Pages/Login.aspx");
                    }
                }
                else
                {



                }
            }
        }
    }
}