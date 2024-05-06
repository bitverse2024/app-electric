using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC
{
    public partial class TestMacAddress : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMachineName1.Text = Environment.MachineName;
            lblMachineName2.Text = System.Net.Dns.GetHostName();
            lblMachineName3.Text = Request.ServerVariables["REMOTE_HOST"].ToString();//ip
            lblMachineName4.Text = System.Environment.GetEnvironmentVariable("COMPUTERNAME");
            lblMachineName5.Text = Request.UserHostAddress;//ip
            lblMachineName6.Text = Request.UserHostName;//ip
        }
        protected void btnTestLocation_Click(object sender, EventArgs e)
        {
            string latlondata = "";
            latlondata = hfid1.Value;
            lblLocation.Text = hfid1.Value;
            if (hfid3.Value == "1")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Please allow the site to access your location.');", true);
                return;
            }
            if (hfid3.Value == "2")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Location information is unavailable. Please try again.');", true);
                return;
            }
            if (hfid3.Value == "3")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('The request to get user location timed out.');", true);
                return;
            }
            if (hfid3.Value == "4")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Internet problem occurred. Please try again.');", true);
                return;
            }
            if (hfid1.Value == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Please allow the site to access your location');", true);
                return;
            }

        }
    }
}