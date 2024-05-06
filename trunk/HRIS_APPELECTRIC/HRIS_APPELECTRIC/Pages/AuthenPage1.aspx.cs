using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Collections.Specialized;
using System.Text.RegularExpressions;   

namespace HRIS_APPELECTRIC.Pages
{
    public partial class AuthenPage1 : System.Web.UI.Page
    {
        Common cm = new Common();
        Employee emp = new Employee();
        public static string id = "";
        public string inputcode = "";
        public static DateTime dt;
        public static string rndstr = "", codestamp = "", starttime = "", endtime = "", endtimecheck = "", userEmail = "", maskedEmail = "";
        public static double mints = 0, mintscheck = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["id"];
            if (!IsPostBack)
            {


                string email = emp.GetEmployeeEmail(id);
                string strformat = @"(?<=[\w]{1})[\w-\._\+%]*(?=[\w]{1}@)";
                string maskemail = Regex.Replace(email, strformat, m => new string('*', m.Length));

                Label4.Text = "Email address: " + maskemail + "";
                //txtCreds.Text = emp.GetEmployeeEmail(id);
            }
        }

        string sendsms()
        {
            String message = HttpUtility.UrlEncode("HI THIS IS WONG");
            using (var wb = new WebClient())
            {
                byte[] response = wb.UploadValues("https://api.txtlocal.com/send/", new NameValueCollection()
                {
                {"apikey" , "yourapiKey"},
                {"numbers" , "447123456789"},
                {"message" , message},
                {"sender" , "Jims Autos"}
                });
                string result = System.Text.Encoding.UTF8.GetString(response);
                return result;
            }
        }
        protected void btnSendCode_Click(object sender, EventArgs e)
        {

            dt = DateTime.Now;
            codestamp = dt.ToString();
            Random rndgenerator = new Random();
            rndstr = rndgenerator.Next(0, 999999).ToString("D6");
            //Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('" + sendsms() + "');", true);

            try
            {
                sendCode();
                cm.InsertQueryCommon(saveParam(), "TBL_EMAILAUTHEN");
                //show OTP//disable email
                //txtCreds.Enabled = false;
                btnSendCode.Visible = false;

                //add email to label
                //Label1.Text = "An OTP is sent to " + txtCreds.Text;
                Label1.Text = "An OTP is sent to " + Label4.Text;
                Label4.Visible = false;
                //txtCreds.Visible = false;
                Label1.Visible = true;
                div1.Visible = true;
                div2.Visible = true;
            }
            catch
            {

            }
        }
        Dictionary<string, string> saveParam()
        {

            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("emp_EmpID", "" + id + "");
            param.Add("codegenstamp", "'" + codestamp + "'");
            param.Add("seccode", "'" + rndstr + "'");


            return param;


        }
        protected void btnReSendCode_Click(object sender, EventArgs e)
        {
            endtimecheck = DateTime.Now.ToString("H:mm");
            mintscheck = cm.get_Time_Difference(starttime, endtimecheck, 2);
            if (mintscheck > 10.00)
            {
                dt = DateTime.Now;
                codestamp = dt.ToString();
                Random rndgenerator = new Random();
                rndstr = rndgenerator.Next(0, 999999).ToString("D6");

                sendCode();
                cm.InsertQueryCommon(saveParam(), "TBL_EMAILAUTHEN");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Code still available');", true);
            }
        }

        void sendCode()
        {
            //Random rndgenerator = new Random();
            //string rndstr = rndgenerator.Next(0, 999999).ToString("D6");
            string content = "Your 6 digit code is:    [" + rndstr + "]";
            string body = "<br />Please keep this email/code confidential";

            cm.GenEmail(id, "HRIS Code confirmation", content, body);
            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Code sent to email');", true);

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            inputcode = "" + TextBox1.Text + "" + TextBox2.Text + "" + TextBox3.Text + "" + TextBox4.Text + "" + TextBox5.Text + "" + TextBox6.Text + "";
            starttime = dt.ToString("H:mm");
            endtime = DateTime.Now.ToString("H:mm");
            //Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('" + sendsms() + "');", true);
            mints = cm.get_Time_Difference(starttime, endtime, 2);
            if (mints < 10.00)
            {
                if (emp.IsCorrectOTP(id, codestamp) == true)
                {
                    rndstr = cm.GetSpecificDataFromDB("seccode", "TBL_EMAILAUTHEN", " where emp_EmpID = '" + id + "' and codegenstamp = '" + codestamp + "'");
                    if (rndstr == inputcode)
                    {
                        Session["AUTHEN_STATUS"] = "1";
                        if (Session["ROLES"].ToString() == "employee")
                        {
                            Response.Redirect("~/Default_kiosk.aspx");

                        }
                        else if (Session["ROLES"].ToString() == "hrtimekeeper")
                        {
                            Response.Redirect("~/Default_kioskTK.aspx");

                        }
                        else if (Session["ROLES"].ToString() == "admin")
                        {
                            emp.DeleteQuery("TBL_ACTIVERECORDLOG", "WHERE creationdate < DATEADD(day, -183, GETDATE())");
                            Response.Redirect("~/Default.aspx");

                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Incorrect Code. Please try again');", true);
                        TextBox1.Text = "";
                        TextBox2.Text = "";
                        TextBox3.Text = "";
                        TextBox4.Text = "";
                        TextBox5.Text = "";
                        TextBox6.Text = "";
                    }
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('The code expired. you can only use the code for 10 minutes');", true);
            }

        }

        //Changing wrong email
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            //tblOTP.Visible = false;
            //txtCreds.Enabled = true;
            btnSendCode.Visible = true;
            Label4.Visible = true;
            //txtCreds.Visible = true;
            Label1.Visible = false;
            div1.Visible = false;
            div2.Visible = false;
        }
    }
}