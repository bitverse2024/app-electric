﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{
    static string connectionstring = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
    string pwdexpry = ConfigurationManager.AppSettings["passwordexpry"];
    public SqlCommand cmd = new SqlCommand();
    public SqlConnection conn = new SqlConnection();
    public SqlDataReader dread;
    public SqlDataAdapter adpt = new SqlDataAdapter();
    public DataTable dt = new DataTable();

    public bool Connect()
    {
        try
        {
            conn = new SqlConnection(connectionstring);
            conn.Open();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool Disconnect()
    {
        conn.Close();
        return false;

    }

    #region Create
    public bool InsertQueryCommon(Dictionary<string, string> param, string tbl)
    {

        try
        {
            string cols = "";
            string values = "";
            bool isfirstItem = true;
            foreach (KeyValuePair<string, string> kvp in param)
            {
                cols += (isfirstItem ? "" : ",") + kvp.Key;
                values += (isfirstItem ? "" : ",") + kvp.Value;
                isfirstItem = false;
            }
            string base_query = "INSERT INTO " + tbl + " (" + cols + ") VALUES(" + values + ")";

            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            cmd.ExecuteNonQuery();

            conn.Close();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public Dictionary<string, string> saveUserParam(string pwd, string fname, string mname, string lastname, string empid, string email)
    {
        string val = "";
        return saveUserParam(out val, pwd, fname, mname, lastname, empid, email);


    }

    public Dictionary<string, string> saveUserParam(out string usr, string pwd, string fname, string mname, string lastname, string empid, string email)
    {
        string password = "password", username = "";
        password = pwd;
        username = fname[0].ToString() + (mname == "" ? "" : mname[0].ToString()) + lastname;
        username = username.ToLowerInvariant();
        bool IsUserAvailable = false;
        int iUsername = 0;
        do
        {

            IsUserAvailable = IsUsernameAvailable(username);
            if (!IsUserAvailable)
                username = username + iUsername++;
        } while (IsUserAvailable == false);
        password = GetSha1(MD5Hash(password));

        Dictionary<string, string> param = new Dictionary<string, string>();



        param.Add("firstname", "'" + fname + "'");
        param.Add("midname", "'" + mname + "'");
        param.Add("lastname", "'" + lastname + "'");
        string fullname = lastname + ", " + fname + " " + mname;
        param.Add("fullname", "'" + fullname + "'");

        param.Add("username", "'" + username + "'");
        param.Add("password", "'" + password + "'");
        param.Add("email", "'" + email + "'");
        param.Add("loginAttempt", "0");
        param.Add("roles", "'employee'");
        param.Add("accounting", "'" + "" + "'");
        param.Add("payroll", "'" + "" + "'");
        param.Add("approver", "0");
        param.Add("validdays", "90");
        param.Add("empid", "'" + empid + "'");//not applicable for applicant
        param.Add("datecreatep", "'" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
        param.Add("password1", "'" + password + "'");

        usr = username;
        return param;


    }
    #endregion Create

    #region Read
    /// <summary>
    /// Get all user account from database
    /// </summary>
    /// <returns>Datatable</returns>
    public DataTable populateGridUserList()
    {
        dt = new DataTable();
        conn = new SqlConnection(connectionstring);
        conn.Open();
        adpt = new SqlDataAdapter("Select * from TBL_USERS", conn);
        adpt.Fill(dt);

        conn.Close();
        return dt;
    }

    /// <summary>
    /// Get all employee from database
    /// Columns all programmatically defined
    /// </summary>
    /// <returns>Datatable</returns>
    public DataTable populateGridUserListCol()
    {
        dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[5] { new DataColumn("Profile"), new DataColumn("EmployeeNo"),
            new DataColumn("Username"), new DataColumn("Email"), new DataColumn("Account Status") });
        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand("Select * from TBL_USERS U, TBL_EMPLOYEE_MASTER E where E.emp_Active !='A' and U.empid = E.emp_EmpID", conn);
        dread = cmd.ExecuteReader();
        while (dread.Read())
        {
            string acctStatus = (int.Parse(dread["loginAttempt"].ToString()) >= 3 ? "LOCKED" : "ACTIVE");
            dt.Rows.Add(dread["emp_FullName"].ToString(), dread["emp_EmpID"].ToString(),
                dread["username"].ToString(), dread["email"].ToString(), acctStatus);


        }
        dread.Close();

        conn.Close();
        return dt;



    }
    //public DataTable populateGridUserListCol(string expr)
    //{

    //    string base_query = "Select * from TBL_USERS U, TBL_EMPLOYEE_MASTER E where U.empid = E.emp_EmpID and " + expr + "";

    //    dt = new DataTable();
    //    dt.Columns.AddRange(new DataColumn[5] { new DataColumn("Profile"), new DataColumn("EmployeeNo"),
    //        new DataColumn("Username"), new DataColumn("Email"), new DataColumn("Account Status") });
    //    conn = new SqlConnection(connectionstring);
    //    conn.Open();
    //    cmd = new SqlCommand(base_query, conn);
    //    dread = cmd.ExecuteReader();
    //    while (dread.Read())
    //    {
    //        string acctStatus = (int.Parse(dread["loginAttempt"].ToString()) >= 3 ? "LOCKED" : "");
    //        dt.Rows.Add(dread["emp_FullName"].ToString(), dread["emp_EmpID"].ToString(), dread["username"].ToString()
    //            , dread["email"].ToString(), acctStatus);
    //    }
    //    dread.Close();

    //    conn.Close();
    //    return dt;


    //}
    public DataTable populateGridUser(string empNo)
    {
        dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Emp_Name"), new DataColumn("Username"),
            new DataColumn("Email"), new DataColumn("Role")});
        conn = new SqlConnection(connectionstring);
        conn.Open();
        //cmd = new SqlCommand("Select * from TBL_USERS where user_Status='ACTIVE'", conn);
        cmd = new SqlCommand("Select * from TBL_USERS where empid = '" + empNo + "'", conn);
        dread = cmd.ExecuteReader();
        while (dread.Read())
        {

            dt.Rows.Add(dread["fullname"].ToString(), dread["username"].ToString(),
                dread["email"].ToString(), dread["roles"].ToString());
        }
        dread.Close();

        conn.Close();
        return dt;
    }

    /// <summary>
    /// Get all employee from database based on the conditions of the query
    /// </summary>
    /// <param name="empid"></param>
    /// <param name="username"></param>
    /// <param name="userFname"></param>
    /// <param name="userMname"></param>
    /// <param name="userLname"></param>
    /// <returns></returns>
    //public DataTable populateGridUserListCol(string fullname, string empid, string username, string email, string lockCondition)
    //{
    //    int sd = 0;
    //    if (!int.TryParse(empid, out sd) || empid == "")
    //    {
    //        empid = "";

    //    }
    //    dt = new DataTable();
    //    dt.Columns.AddRange(new DataColumn[5] { new DataColumn("Profile"), new DataColumn("EmployeeNo"),
    //        new DataColumn("Username"), new DataColumn("Email"), new DataColumn("Account Status") });
    //    conn = new SqlConnection(connectionstring);
    //    conn.Open();
    //    cmd = new SqlCommand("Select * from TBL_USERS U, TBL_EMPLOYEE_MASTER E where (emp_FullName = '" + fullname + "' or emp_EmpID = '" + empid + "' or username = '" + username + "' or email = '" + email + "' or loginAttempt " + lockCondition + ") and U.id = E.emp_EmpID", conn);
    //    dread = cmd.ExecuteReader();
    //    while (dread.Read())
    //    {
    //        string acctStatus = (int.Parse(dread["loginAttempt"].ToString()) >= 3 ? "LOCKED" : "");
    //        dt.Rows.Add(dread["emp_FullName"].ToString(), dread["emp_EmpID"].ToString(),
    //            dread["username"].ToString(), dread["email"].ToString(), acctStatus);


    //    }
    //    dread.Close();

    //    conn.Close();
    //    return dt;



    //}
    public DataTable populateGridUserListCol(string expr)
    {

        string base_query = "Select * from TBL_USERS U, TBL_EMPLOYEE_MASTER E where U.empid = E.emp_EmpID and " + expr + "";

        dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[5] { new DataColumn("Profile"), new DataColumn("EmployeeNo"),
            new DataColumn("Username"), new DataColumn("Email"), new DataColumn("Account Status") });
        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand(base_query, conn);
        dread = cmd.ExecuteReader();
        while (dread.Read())
        {
            string acctStatus = (int.Parse(dread["loginAttempt"].ToString()) >= 3 ? "LOCKED" : "");
            dt.Rows.Add(dread["emp_FullName"].ToString(), dread["emp_EmpID"].ToString(), dread["username"].ToString()
                , dread["email"].ToString(), acctStatus);
        }
        dread.Close();

        conn.Close();
        return dt;


    }

    /// <summary>
    /// Get login attempt count
    /// </summary>
    /// <param name="usrname"></param>
    /// <returns></returns>
    public int GetLoginAttempt(string usrname)
    {
        int loginAttempt = 0;
        try
        {
            conn = new SqlConnection(connectionstring);
            conn.Open();

            cmd = new SqlCommand("Select loginAttempt from TBL_USERS where username='" + usrname + "'", conn);
            dread = cmd.ExecuteReader();

            while (dread.Read())
            {
                loginAttempt = int.Parse(dread["loginAttempt"].ToString());
            }
            dread.Close();
            conn.Close();
            return loginAttempt;

        }
        catch
        {
            conn.Close();
        }
        conn.Close();
        return loginAttempt;


    }

    /// <summary>
    /// Get user account details
    /// </summary>
    /// <param name="usrname"></param>
    /// <returns>
    /// string username
    /// string fullname
    /// </returns>
    public void getUserInfo(string empNo, out string username, out string fullname, out string email, out string roles)
    {
        username = "";
        fullname = "";
        email = "";
        roles = "";
        try
        {

            conn = new SqlConnection(connectionstring);
            conn.Open();

            cmd = new SqlCommand("Select U.username, E.emp_FullName from TBL_USERS U, TBL_EMPLOYEE_MASTER E where U.empid=" + empNo + " and U.empid = E.emp_EmpID", conn);
            dread = cmd.ExecuteReader();

            while (dread.Read())
            {
                username = dread["username"].ToString();
                fullname = dread["emp_FullName"].ToString();
                username = dread["email"].ToString();
                fullname = dread["roles"].ToString();

            }
        }
        catch
        {
            conn.Close();
        }
        conn.Close();


    }

    /// <summary>
    /// Check user login
    /// </summary>
    /// <param name="usrname"></param>
    /// <param name="usrpwd"></param>
    /// <param name="empNo"></param>
    /// <returns></returns>
    public int CheckUser(string usrname, string usrpwd, out string empNo, out string user_FirstName,out string userposition, out string userroles, out string userid, out string user_FullName, out string emp_Rank, out string company)
    {
        userposition = "";
        empNo = "";
        user_FirstName = "";
        userroles = "";
        userid = "";
        user_FullName = "";
        emp_Rank = "";
        company = "";
        string vDay = "";
        bool isapplicant = false;
        try
        {

            conn = new SqlConnection(connectionstring);
            conn.Open();

            cmd = new SqlCommand("Select * from TBL_EMPLOYEE_MASTER E, TBL_USERS U where U.username='" + usrname + "' and U.password='" + usrpwd + "' and U.empid=E.emp_EmpID", conn);
            dread = cmd.ExecuteReader();
            if (!dread.HasRows)
            {
                dread.Close();
                cmd = new SqlCommand("Select * from TBL_USERS U where U.username='" + usrname + "' and U.password='" + usrpwd + "'", conn);
                dread = cmd.ExecuteReader();
                if (dread.HasRows)
                    isapplicant = true;
            }

            #region EMPLOYEE CHECKER
            while (dread.Read())
            {
                if (usrname == dread["username"].ToString() && usrpwd == dread["password"].ToString())
                {
                    empNo = (isapplicant ? "-----" : dread["empid"].ToString());
                    user_FirstName = (isapplicant ? dread["firstname"].ToString() : dread["emp_FirstName"].ToString());
                    userroles = (isapplicant ? "applicant" : dread["roles"].ToString());
                    userid = dread["id"].ToString();
                    vDay = dread["validdays"].ToString();
                    user_FullName = (isapplicant ? dread["fullname"].ToString() : dread["emp_FullName"].ToString());
                    //emp_Rank = dread["emp_Rank"].ToString();
                    emp_Rank = (isapplicant ? "-----" : dread["emp_Rank"].ToString());
                    company = dread["emp_Assignment"].ToString();
                    userposition = dread["emp_Position"].ToString();
                }
                DateTime dt = DateTime.Now;
                bool validDate = DateTime.TryParse(dread["datecreatep"].ToString(), out dt);
                int dayexpry = int.Parse(vDay);
                int warningday = dayexpry - 10;
                TimeSpan ts = (DateTime.Now - dt);
                if (ts > TimeSpan.FromDays(dayexpry))
                {
                    conn.Close();
                    return -1;
                }
                if (ts > TimeSpan.FromDays(warningday) && ts < TimeSpan.FromDays(dayexpry))
                {
                    conn.Close();
                    return 2;
                }
                conn.Close();
                return 1;



            }
            #endregion EMPLOYEE CHECKER
        }
        catch
        {
            conn.Close();
        }
        conn.Close();
        return 0;


    }

    /// <summary>
    /// Check username availability
    /// </summary>
    /// <param name="usrname"></param>

    /// <returns>bool true. If username is available</returns>
    public bool IsUsernameAvailable(string usrname)
    {
        try
        {

            conn = new SqlConnection(connectionstring);
            conn.Open();

            cmd = new SqlCommand("Select * from TBL_USERS where username='" + usrname + "'", conn);
            dread = cmd.ExecuteReader();
            dread.Read();
            if (dread.HasRows)
            {
                conn.Close();
                return false;
            }
            else
            {
                conn.Close();
                return true;

            }
        }
        catch
        {
            conn.Close();
            return true;
        }
        conn.Close();
        return true;


    }

    public Dictionary<string, string> GetUserInfoDict(string userid)
    {
        Dictionary<string, string> userInfo = new Dictionary<string, string>();
        List<string> cols = new List<string>();
        try
        {


            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'TBL_USERS' ORDER BY ORDINAL_POSITION", conn);
            dread = cmd.ExecuteReader();

            while (dread.Read())
            {
                cols.Add(dread["COLUMN_NAME"].ToString());
            }
            dread.Close();

            //cmd = new SqlCommand("Select * from TBL_EMPLOYEE_MASTER E, TBL_USERS U where E.emp_EmpID =" + empNo + " and E.emp_EmpID = U.empid", conn);
            //cmd = new SqlCommand("SELECT * from TBL_EMPLOYEE_MASTER E, TBL_POSITION P where E.emp_EmpID = '"+empNo+"' and P.PositionCode = E.emp_Position", conn);
            cmd = new SqlCommand("SELECT * from TBL_USERS where id = " + userid + "", conn);
            dread = cmd.ExecuteReader();

            while (dread.Read())
            {
                foreach (string strcols in cols)
                {
                    userInfo.Add(strcols, dread[strcols].ToString());

                }
            }
            dread.Close();




            conn.Close();
            return userInfo;
        }
        catch (Exception e)
        {
            return userInfo;
        }

    }
    #endregion Read

    #region Update
    /// <summary>
    /// Update user account info to database
    /// </summary>
    /// <param name="empNo"></param>
    /// <param name="fname"></param>
    /// <param name="mname"></param>
    /// <param name="lname"></param>
    public void updateUserInfo(string empNo, string username, string password, bool reset)
    {
        try
        {
            conn = new SqlConnection(connectionstring);
            conn.Open();

            cmd = new SqlCommand("Update TBL_USERS SET username = '" + username + "', password = '" + password + "', loginAttempt = " + (reset ? "0" : "") + " where empid='" + empNo + "'", conn);
            cmd.ExecuteNonQuery();
        }
        catch
        {
            conn.Close();
        }
        conn.Close();

    }

    /// <summary>
    ///update login attempt
    ///reset if login is successful && attempt < 4
    /// </summary>
    /// <param name="usrname"></param>
    /// <param name="loginAttempt"></param>
    /// <returns></returns>
    public Boolean UpdateLoginAttempt(string usrname, int loginAttempt)
    {
        try
        {
            conn = new SqlConnection(connectionstring);
            conn.Open();

            cmd = new SqlCommand("Update TBL_USERS SET loginAttempt = " + loginAttempt + " where username='" + usrname + "'", conn);
            cmd.ExecuteNonQuery();
        }
        catch
        {
            conn.Close();
        }
        conn.Close();
        return false;


    }
    #endregion Update

    #region Delete
    #endregion Delete










    public string MD5Hash(string input)
    {
        StringBuilder hash = new StringBuilder();
        MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
        byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

        for (int i = 0; i < bytes.Length; i++)
        {
            hash.Append(bytes[i].ToString("x2"));
        }
        return hash.ToString();
    }
    public string GetSha1(string value)
    {
        var data = Encoding.ASCII.GetBytes(value);
        var hashData = new SHA1Managed().ComputeHash(data);
        var hash = string.Empty;
        foreach (var b in hashData)
        {
            hash += b.ToString("X2");
        }
        return hash;
    }

    public string DecryptMD5Hash(string input)
    {
        var hash = string.Empty;
        string ret = "";
        byte[] data = Convert.FromBase64String(input); // decrypt the incrypted text
        using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
        {
            byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
            {
                ICryptoTransform transform = tripDes.CreateDecryptor();
                byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                ret = UTF8Encoding.UTF8.GetString(results);
            }
        }
        return ret;
    }
}
