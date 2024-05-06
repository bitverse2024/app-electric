using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Common cm = new Common();
            Session.Timeout = 32400;
            //28800 = 8hrs
            //86400 = 24hrs
            if (!IsPostBack)
            {
                if (Session["EMP_ID"] != null)
                {
                    //lblUsername.Text = Session["EMP_ID"].ToString();
                    //btnLogout.Visible = true;
                    //btnLogin.Visible = false;
                }
                else
                {
                    //string strEncode = Server.UrlEncode(HttpContext.Current.Request.Url.AbsoluteUri);
                    //string strEncode = HttpContext.Current.Request.Url.AbsoluteUri;
                    //Response.Redirect(string.Format("{0}?redirect={1}",
                    //    ConfigurationManager.AppSettings["loginPage"], strEncode));
                    Response.Redirect("~/Pages/Login.aspx");

                }


                if (Session["SHOW_EXPIRE_WARNING"] != null && Session["SHOW_EXPIRE_WARNING"].ToString() == "1")
                {
                    Session["SHOW_EXPIRE_WARNING"] = null;
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                                "alert",
                                "alert('Your password is about to expire. Please change your password');",
                                true);
                }
                if (Session["EMP_ID"] != null)
                {
                    //lblUsername.Text = Session["EMP_ID"].ToString();
                    //btnLogout.Visible = true;
                    //btnLogin.Visible = false;
                    string position = ((Session["POSITION"] == null || Session["POSITION"].ToString() == "") ? "Employee" : Session["POSITION"].ToString());
                    lblDisplayName.Text = Session["USER_DISPLAY_NAME"].ToString();
                    lblDisplayName2.Text = "Welcome," + Session["USER_DISPLAY_NAME"].ToString() + "!";
                    lblDescName.Text = Session["FULLNAME"].ToString();
                    lblPos.Text = cm.GetSpecificDataFromDB("PositionName", "TBL_POSITION", " where id = " + position + "");
                }
                else
                {
                    //string strEncode = Server.UrlEncode(HttpContext.Current.Request.Url.AbsoluteUri);
                    string strEncode = HttpContext.Current.Request.Url.AbsoluteUri;
                    //Response.Redirect(string.Format("{0}?redirect={1}",
                    //    ConfigurationManager.AppSettings["loginPage"], strEncode));
                    //Response.Redirect(string.Format("{0}?redirect={1}", "~/Pages/User/Login.aspx", strEncode));
                    //Response.Redirect("~/Pages/User/Login.aspx");

                    Response.Redirect("~/Pages/Login.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));

                }
            }
        }
        protected void btn_Logout(object sender, EventArgs e)
        {
            Session["EMP_ID"] = null;
            Session["USER_DISPLAY_NAME"] = null;
            Session["USER_DISPLAY_NAME"] = null;
            Session["AUTHEN_STATUS"] = "0";
            Session.Abandon();
            Response.Redirect("~/Pages/Login.aspx");

        }

        protected void btn_Profile(object sender, EventArgs e)
        {
            
            Session["ACTIVE_EMPNO"] = Session["EMP_ID"].ToString();
            Response.Redirect("~/Pages/Admin/Employees/EmployeeView.aspx?empid=" + Session["EMP_ID"].ToString());

        }
    }
}