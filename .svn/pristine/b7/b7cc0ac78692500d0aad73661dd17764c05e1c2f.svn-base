using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.HRRecruitment
{
    public partial class signup : System.Web.UI.Page
    {
        User dbUser = new User();
        Common cm = new Common();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SignUpButton_Click(object sender, EventArgs e)
        {
            string username = "";
            //if (dbUser.InsertQueryCommon(saveUserParam(out username), "TBL_USERS"))
            if (dbUser.InsertQueryCommon(dbUser.saveUserParam(out username, SignUpForm_password.Value, SignUpForm_firstname.Value, SignUpForm_middlename.Value, SignUpForm_surname.Value, "", SignUpForm_email.Value), "TBL_USERS"))
            {
                //saveUserParam(out username);//for testing purpose only
                ScriptManager.RegisterStartupScript(this, this.GetType(),
        "alert",
        "alert('Sign Up Success. Please login your account.');window.location ='../Login.aspx?user=" + username + "';",
        true);
                //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Signed Up !!!');", true);
            }
        }
        //This is transferred to user class since this is being called several times
        //Dictionary<string, string> saveUserParam(out string usr)
        //{        
        //    string password = "password", username = "";
        //    password = SignUpForm_password.Value;
        //    username = SignUpForm_firstname.Value[0].ToString() + (SignUpForm_middlename.Value == "" ? "" : SignUpForm_middlename.Value[0].ToString()) + SignUpForm_surname.Value;
        //    username = username.ToLowerInvariant();
        //    bool IsUsernameAvailable = false;
        //    int iUsername = 0;
        //    do
        //    {
        //        IsUsernameAvailable = dbUser.IsUsernameAvailable(username);
        //        if (!IsUsernameAvailable)
        //            username = username + iUsername++;
        //    } while (IsUsernameAvailable == false);
        //    password = dbUser.GetSha1(dbUser.MD5Hash(password));

        //    Dictionary<string, string> param = new Dictionary<string, string>();

        //    param.Add("username", "'" + username + "'");
        //    param.Add("password", "'" + password + "'");
        //    param.Add("email", "'" + "" + "'");
        //    param.Add("loginAttempt", "0");
        //    param.Add("roles", "'applicant'");
        //    param.Add("accounting", "'" + "" + "'");
        //    param.Add("payroll", "'" + "" + "'");
        //    param.Add("approver", "0");
        //    //param.Add("empid", "'" + Employee_EmpID.Value + "'");//not applicable for applicant
        //    param.Add("datecreatep", "'" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
        //    param.Add("password1", "'" + password + "'");

        //    usr = username;
        //    return param;


        //}
    }
}