using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin.Employees
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Common cm = new Common();
        User dbconn = new User();
        public string empid = "";
        public string empno = "";
        public string newpwd = "";
        public string pswrd = "";
        public string oldpwd = "";
        public string newpwdSha1MD5 = "";
        public string oldpwdSha1MD5 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            empno = Session["ACTIVE_EMPNO"].ToString();
            if (!IsPostBack)
            {
                if (Session["EMP_ID"] != null)
                {
                    empno = Session["ACTIVE_EMPNO"].ToString();
                    lblDisplayName2.Text = Session["USER_DISPLAY_NAME"].ToString();

                }
            }
        }

        Dictionary<string, string> saveParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("password", "'" + newpwdSha1MD5 + "'");
            return param;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            empid = Session["EMP_ID"].ToString();
            oldpwd = passwrd.Value;
            newpwd = newpasswrd.Value;
            oldpwdSha1MD5 = dbconn.GetSha1(dbconn.MD5Hash(oldpwd));
            newpwdSha1MD5 = dbconn.GetSha1(dbconn.MD5Hash(newpwd));
            pswrd = cm.GetSpecificDataFromDB("password", "TBL_USERS", "where empid = " + empid + "");

            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if (oldpwdSha1MD5 == pswrd)
                {
                    if (newpwdSha1MD5 != pswrd)
                    {

                        if (cm.UpdateQueryCommon(saveParam(), "TBL_USERS", "empid = '" + empid + "'"))
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Password Changed. Please restart your session.');", true);
                            newpasswrd.Value = "";
                            passwrd.Value = "";
                            Response.Redirect("~/Pages/Login.aspx");

                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Do not use previous password.');", true);
                        newpasswrd.Value = "";
                        passwrd.Value = "";
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Wrong Password.');", true);
                    newpasswrd.Value = "";
                    passwrd.Value = "";
                }
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            newpasswrd.Value = "";
        }

        protected void btn_Profile(object sender, EventArgs e)
        {
            Session["ACTIVE_EMPNO"] = Session["EMP_ID"].ToString();
            Response.Redirect("~/Pages/Admin/Employee/EmployeeView.aspx?empid=" + Session["EMP_ID"].ToString());

        }
    }
}