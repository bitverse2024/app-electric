using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace HRIS_APPELECTRIC
{
    public class HR
    {
        static string connectionstring = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        static SqlCommand cmd = new SqlCommand();
        static SqlConnection conn = new SqlConnection();
        static SqlDataReader dread;
        static SqlDataAdapter adpt = new SqlDataAdapter();
        static DataTable dt = new DataTable();
        Common cm = new Common();
        Employee emp = new Employee();


        #region CREATE

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

        public bool AddFileToDB(string applicantID, string filename, string categ)
        {
            try
            {
                string base_query = "INSERT INTO TBL_201FILES VALUES('" + applicantID + "', '" + filename + "', '" + DateTime.Now.ToString("MM/dd/yyyy") + "','" + categ + "')";

                conn = new SqlConnection(connectionstring);
                conn.Open();
                cmd = new SqlCommand(base_query, conn);
                cmd.ExecuteNonQuery();

                conn.Close();
                return true;
            }
            catch
            {
                return false;

            }

        }
        #endregion CREATE
        #region READ

        public DataTable populateGridAllApplicant()
        {
            dt = new DataTable();
            conn = new SqlConnection(connectionstring);
            conn.Open();
            adpt = new SqlDataAdapter("Select * from TBL_APPLICANT", conn);
            adpt.Fill(dt);

            conn.Close();
            return dt;
        }




        public DataTable populateGridMedical(string empno)
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("id"), new DataColumn("RefDate"), new DataColumn("FName"),
            new DataColumn("Diagnosis") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_MEDICAL where EmpID = '" + empno + "'", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), cm.FormatDate(dread["RefDate"].ToString()), dread["FName"].ToString(), dread["Diagnosis"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridMedicalCol(string empno, string expr)
        {
            //string base_query = "Select * from TBL_LICENSE where EmpID = '" + empno + "' and (license_type = '" + lictype + "' or license_no = '" + licno + "' or lic_expirydate = '" + licdate + "')";
            string base_query = "Select * from TBL_MEDICAL where EmpID = '" + empno + "' " + expr + "";

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("id"), new DataColumn("RefDate"), new DataColumn("FName"),
            new DataColumn("Diagnosis") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), cm.FormatDate(dread["RefDate"].ToString()), dread["FName"].ToString(), dread["Diagnosis"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridFiles(string applicantid)
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("FileID"), new DataColumn("Filename"),
            new DataColumn("Category") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            //cmd = new SqlCommand("Select * from TBL_USERS where user_Status='ACTIVE'", conn);
            cmd = new SqlCommand("Select * from TBL_201FILES where EmpID = '" + applicantid + "'", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["Filename"].ToString(), dread["Category"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridFilesCol(string applicantid, string fileid, string fname, string categ)
        {
            string base_query = "Select * from TBL_201FILES where EmpID = '" + applicantid + "' and Filename = '" + fname + "'";
            int id = 0;
            if (int.TryParse(fileid, out id))
            {
                base_query += " or id = " + fileid + "";
            }
            int sd = 0;
            if (!int.TryParse(applicantid, out sd) || applicantid == "")
            {
                applicantid = "";

            }

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("FileID"), new DataColumn("Filename"),
            new DataColumn("Category") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["Filename"].ToString(), dread["Category"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public string GetJobOpenings(string empno)
        {
            string ret = "";
            string build_html = "";
            build_html += "<div class=\"btn btn-success col-lg-6\" style=\"padding:0px;\"><h4>Recent Job opennings!</h4></div><br /><br /><br />";
            build_html += "<div class=\"col-lg-12\" style=\"background:#f3f0f0;margin-bottom:10px;border-radius:3px;\">";
            build_html += "<a href=\"{4}\"><h3 style=\"text-transform:uppercases;\"><span style=\"color:black;\">Position: {0}</span> </h3></a>";
            build_html += "<h4 style=\"text-indent:0px;color:#428cc0;text-transform:uppercases;\"><span style=\"color:black;\">Division: </span>";
            build_html += "{1} </h4><h5 style=\"text-indent:0px;color:#428cc0;text-transform:uppercase;font-weight:bold;\">Work Experience: </h5>";
            build_html += "<p style=\"text-indent:0px;text-align:justify;\">{2} </p>";
            build_html += "<h5 style=\"text-indent:0px;color:#428cc0;text-transform:uppercase;font-weight:bold;\">Skills: </h5><p style=\"text-indent:0px;text-align:justify;\">";
            build_html += "{3}</p><a href=\"{4}\" class=\"btn btn-primary pull-right\" style=\"margin:2px 2px 8px 2px;\">APPLY NOW</a></div>";

            conn = new SqlConnection(connectionstring);
            conn.Open();

            cmd = new SqlCommand("Select * from TBL_MR where mr_status = 'hiring'", conn);
            dread = cmd.ExecuteReader();
            if (!dread.HasRows)
            {
                ret = "<div class=\"btn btn-danger col-lg-6\" style=\"padding:0px;\"><h4>No Job openings this time!</h4></div>";
                goto EXIT;
            }

            while (dread.Read())
            {
                string queryID = String.Format("mrid={0}&hrmrid={1}&divid={2}", dread["id"].ToString(), dread["hrmrid"].ToString(), dread["DivCode"].ToString());
                ret += "\n" + String.Format(build_html, cm.GetSpecificDataFromDB("PositionName", "TBL_POSITION", "where id = " + dread["PositionCode"].ToString() + ""),
                    cm.GetSpecificDataFromDB("PositionName", "TBL_POSITION", "where id = " + dread["PositionCode"].ToString() + ""),
                    dread["workexperience"].ToString(), dread["skills"].ToString(), "Pages/HRRecruitment/createapplicant.aspx?" + queryID + "");

            }

        EXIT:
            dread.Close();
            conn.Close();
            return ret;
        }
        public DataTable populateGridApplicant()
        {
            return populateGridApplicant(1);
        }
        public DataTable populateGridApplicant(int searchType)
        {
            string query = "Select * from TBL_APPLICANT";

            if (searchType == 2)
                query = "Select * from TBL_APPLICANT where shortlisted = '1'";

            if (searchType == 3)
                query = "Select * from TBL_APPLICANT where failed = '1'";

            if (searchType == 4)
                query = "Select * from TBL_APPLICANT where Blacklist = '1'";

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[5] { new DataColumn("id"), new DataColumn("FullName"), new DataColumn("PositionDesired"), new DataColumn("DateReceived"), new DataColumn("Address1") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["FullName"].ToString(), dread["PositionDesired"].ToString(), cm.FormatDate(dread["DateReceived"].ToString()), dread["Address1"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }//populate Recruitment Applicant

        public DataTable populateGridApplicantCol(string expr)
        {
            return populateGridApplicantCol(expr, 1);
        }
        public DataTable populateGridApplicantCol(string expr, int searchType)
        {
            string base_query = "Select * from TBL_APPLICANT where " + expr + "";

            if (searchType == 2)
                base_query = "Select * from TBL_APPLICANT where shortlisted = '1' AND (" + expr + ")";

            if (searchType == 3)
                base_query = "Select * from TBL_APPLICANT where failed = '1' AND (" + expr + ")";

            if (searchType == 4)
                base_query = "Select * from TBL_APPLICANT where Blacklist = '1' AND (" + expr + ")";
            //string base_query = "Select * from TBL_LICENSE where EmpID = '" + empno + "' and (license_type = '" + lictype + "' or license_no = '" + licno + "' or lic_expirydate = '" + licdate + "')";


            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[5] { new DataColumn("id"), new DataColumn("FullName"), new DataColumn("PositionDesired"), new DataColumn("DateReceived"), new DataColumn("Address1") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["FullName"].ToString(), dread["PositionDesired"].ToString(), cm.FormatDate(dread["DateReceived"].ToString()), dread["Address1"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }


        public DataTable populateGridShortlistedApp()
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[5] { new DataColumn("id"), new DataColumn("FullName"), new DataColumn("PositionDesired"), new DataColumn("DateReceived"), new DataColumn("Address1") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_APPLICANT", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["FullName"].ToString(), dread["PositionDesired"].ToString(), cm.FormatDate(dread["DateReceived"].ToString()), dread["Address1"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }//populate Recruitment Applicant

        public DataTable populateGridShortlistedAppCol(string expr)
        {
            //string base_query = "Select * from TBL_LICENSE where EmpID = '" + empno + "' and (license_type = '" + lictype + "' or license_no = '" + licno + "' or lic_expirydate = '" + licdate + "')";
            string base_query = "Select * from TBL_APPLICANT where " + expr + "";

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[5] { new DataColumn("id"), new DataColumn("FullName"), new DataColumn("PositionDesired"), new DataColumn("DateReceived"), new DataColumn("Address1") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["FullName"].ToString(), dread["PositionDesired"].ToString(), cm.FormatDate(dread["DateReceived"].ToString()), dread["Address1"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }
        //populate Recruitment Applicant History
        public DataTable populateGridHistory()
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("id"), new DataColumn("DateReceived"), new DataColumn("action"), new DataColumn("reason") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_APPLICANTHISTORY", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), cm.FormatDate(dread["DateReceived"].ToString()), dread["action"].ToString(), dread["reason"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }//populate Recruitment Applicant

        public DataTable populateGridHistoryCol(string expr)
        {
            //string base_query = "Select * from TBL_LICENSE where EmpID = '" + empno + "' and (license_type = '" + lictype + "' or license_no = '" + licno + "' or lic_expirydate = '" + licdate + "')";
            string base_query = "Select * from TBL_APPLICANTHISTORY where " + expr + "";

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("id"), new DataColumn("DateReceived"), new DataColumn("action"), new DataColumn("reason") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), cm.FormatDate(dread["DateReceived"].ToString()), dread["action"].ToString(), dread["reason"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }
        public string build_or_like_param(Dictionary<string, string> param)
        {
            return build_or_like_param(false, param);
        }



        public string build_or_like_param(bool IsFirstCondition, Dictionary<string, string> param)
        {

            string values = (IsFirstCondition ? "" : "and(");
            bool isfirstItem = true;
            string query_optr = "";
            foreach (KeyValuePair<string, string> kvp in param)
            {
                if (kvp.Value == "" || kvp.Value == "'%%'") continue;
                query_optr = (kvp.Value.Contains("'") ? "LIKE" : "=");
                values += (isfirstItem ? "" : " or ") + kvp.Key + " " + query_optr + " " + kvp.Value;
                isfirstItem = false;
            }

            values += (IsFirstCondition ? "" : " )");



            return values;

        }





        #endregion READ
        #region UPDATE
        /// <summary>
        /// whereCondition = "field = 'value'"
        /// </summary>
        /// <param name="fieldToUpdate"></param>
        /// <param name="newValue"></param>
        /// <param name="tbl"></param>
        /// <param name="whereCondition"></param>
        /// <returns></returns>
        public bool UpdateQueryCommon(string fieldToUpdate, string newValue, string tbl, string whereCondition)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add(fieldToUpdate, newValue);
            return UpdateQueryCommon(param, tbl, whereCondition);
        }
        /// <summary>
        /// whereCondition = "field = 'value'"
        /// </summary>
        /// <param name="param"></param>
        /// <param name="tbl"></param>
        /// <param name="whereCondition"></param>
        /// <returns></returns>
        public bool UpdateQueryCommon(Dictionary<string, string> param, string tbl, string whereCondition)
        {

            try
            {
                string setval = "";
                bool isfirstItem = true;
                foreach (KeyValuePair<string, string> kvp in param)
                {
                    setval += (isfirstItem ? "" : ",") + kvp.Key + " = " + kvp.Value;


                    isfirstItem = false;
                }
                string base_query = "UPDATE " + tbl + " SET " + setval + " where " + whereCondition;

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
        #endregion UPDATE
        #region DELETE

        public void DeleteQuery(string tbl, string where)
        {
            try
            {
                conn = new SqlConnection(connectionstring);
                conn.Open();

                cmd = new SqlCommand("DELETE from " + tbl + " " + where + "", conn);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                conn.Close();
            }
            conn.Close();


        }
        #endregion DELETE
    }
}