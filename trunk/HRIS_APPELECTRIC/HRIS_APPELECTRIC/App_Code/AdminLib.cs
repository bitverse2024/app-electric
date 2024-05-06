using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace HRIS_APPELECTRIC
{
    public class AdminLib
    {
        static string connectionstring = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        string emailSMTP = ConfigurationManager.AppSettings["SMTP"];
        string emailUSERNAME = ConfigurationManager.AppSettings["mailUserName"];
        string emailPASSWORD = ConfigurationManager.AppSettings["mailPassword"];
        public SqlCommand cmd = new SqlCommand();
        public SqlConnection conn = new SqlConnection();
        public SqlDataReader dread;
        public SqlDataAdapter adpt = new SqlDataAdapter();
        public DataTable dt = new DataTable();
        Common cm = new Common();

        #region READ


        public DataTable populateGridMovementtype()
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("id"), new DataColumn("MovementTypeName"), new DataColumn("MovementClass") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_MOVEMENTTYPE", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["MovementTypeName"].ToString(), dread["MovementClass"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridMovementtypeCol(string expr)
        {
            //string base_query = "Select * from TBL_LICENSE where EmpID = '" + empno + "' and (license_type = '" + lictype + "' or license_no = '" + licno + "' or lic_expirydate = '" + licdate + "')";
            string base_query = "Select * from TBL_MOVEMENTTYPE where " + expr + "";

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("id"), new DataColumn("MovementTypeName"), new DataColumn("MovementClass") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["MovementTypeName"].ToString(), dread["MovementClass"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridDivision()
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("id"), new DataColumn("DivName") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_DIVISION", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["DivName"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }



        public DataTable populateGridDivisionCol(string expr)
        {
            //string base_query = "Select * from TBL_LICENSE where EmpID = '" + empno + "' and (license_type = '" + lictype + "' or license_no = '" + licno + "' or lic_expirydate = '" + licdate + "')";
            string base_query = "Select * from TBL_DIVISION where " + expr + "";

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("id"), new DataColumn("DivName") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["DivName"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridRank()
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[5] { new DataColumn("id"), new DataColumn("RankName"), new DataColumn("GracePeriod"), new DataColumn("allowance1"), new DataColumn("allowance2") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_RANK", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["RankName"].ToString(), dread["GracePeriod"].ToString(), dread["allowance1"].ToString(), dread["allowance2"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridRankCol(string expr)
        {
            //string base_query = "Select * from TBL_LICENSE where EmpID = '" + empno + "' and (license_type = '" + lictype + "' or license_no = '" + licno + "' or lic_expirydate = '" + licdate + "')";
            string base_query = "Select * from TBL_RANK where " + expr + "";

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[5] { new DataColumn("id"), new DataColumn("RankName"), new DataColumn("GracePeriod"), new DataColumn("allowance1"), new DataColumn("allowance2") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["RankName"].ToString(), dread["GracePeriod"].ToString(), dread["allowance1"].ToString(), dread["allowance2"].ToString());
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

        public DataTable populateGridAllOfficeSupplies()
        {
            dt = new DataTable();
            conn = new SqlConnection(connectionstring);
            conn.Open();
            adpt = new SqlDataAdapter("Select * from TBL_OFFICESUPPLIES", conn);
            adpt.Fill(dt);

            conn.Close();
            return dt;
        }
        public DataTable populateGridOfficeSupplies()
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("id"), new DataColumn("item_Name"), new DataColumn("quantity") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_OFFICESUPPLIES", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["item_Name"].ToString(), dread["quantity"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridOfficeSuppliesCol(string expr)
        {
            //string base_query = "Select * from TBL_LICENSE where EmpID = '" + empno + "' and (license_type = '" + lictype + "' or license_no = '" + licno + "' or lic_expirydate = '" + licdate + "')";
            string base_query = "Select * from TBL_OFFICESUPPLIES where " + expr + "";

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("id"), new DataColumn("item_Name"), new DataColumn("quantity") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["item_Name"].ToString(), dread["quantity"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridAllHTLI()
        {
            dt = new DataTable();
            conn = new SqlConnection(connectionstring);
            conn.Open();
            adpt = new SqlDataAdapter("Select * from TBL_HTLI", conn);
            adpt.Fill(dt);

            conn.Close();
            return dt;
        }
        public DataTable populateGridHTLI()
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[6] { new DataColumn("id"), new DataColumn("Name"), new DataColumn("Position"), new DataColumn("Cp_Number"), new DataColumn("Phone_Number"), new DataColumn("Email") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_HTLI", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["Name"].ToString(), dread["Position"].ToString(), dread["Cp_Number"].ToString(), dread["Phone_Number"].ToString(), dread["Email"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridHTLICol(string expr)
        {
            //string base_query = "Select * from TBL_LICENSE where EmpID = '" + empno + "' and (license_type = '" + lictype + "' or license_no = '" + licno + "' or lic_expirydate = '" + licdate + "')";
            string base_query = "Select * from TBL_HTLI where " + expr + "";

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[6] { new DataColumn("id"), new DataColumn("Name"), new DataColumn("Position"), new DataColumn("Cp_Number"), new DataColumn("Phone_Number"), new DataColumn("Email") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["Name"].ToString(), dread["Position"].ToString(), dread["Cp_Number"].ToString(), dread["Phone_Number"].ToString(), dread["Email"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridAllCashAdvance()
        {
            dt = new DataTable();
            conn = new SqlConnection(connectionstring);
            conn.Open();
            adpt = new SqlDataAdapter("Select * from TBL_CASH", conn);
            adpt.Fill(dt);

            conn.Close();
            return dt;
        }
        public DataTable populateGridCashAdvance()
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[5] { new DataColumn("id"), new DataColumn("date_requested"), new DataColumn("type"), new DataColumn("amount"), new DataColumn("reason") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_CASH", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["date_requested"].ToString(), dread["type"].ToString(), dread["amount"].ToString(), dread["reason"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridCashAdvanceCol(string expr)
        {
            //string base_query = "Select * from TBL_LICENSE where EmpID = '" + empno + "' and (license_type = '" + lictype + "' or license_no = '" + licno + "' or lic_expirydate = '" + licdate + "')";
            string base_query = "Select * from TBL_CASH where " + expr + "";

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[5] { new DataColumn("id"), new DataColumn("date_requested"), new DataColumn("type"), new DataColumn("amount"), new DataColumn("reason") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["date_requested"].ToString(), dread["type"].ToString(), dread["amount"].ToString(), dread["reason"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridAllSupplyRequest()
        {
            dt = new DataTable();
            conn = new SqlConnection(connectionstring);
            conn.Open();
            adpt = new SqlDataAdapter("Select * from TBL_SUPPLYREQUEST", conn);
            adpt.Fill(dt);

            conn.Close();
            return dt;
        }

        public DataTable populateGridSupplyRequest()
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[7] { new DataColumn("id"), new DataColumn("department"), new DataColumn("item_Name"), new DataColumn("quantity"), new DataColumn("requested_By"), new DataColumn("date_Requested"), new DataColumn("status") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_SUPPLYREQUEST", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["department"].ToString(), dread["item_Name"].ToString(), dread["quantity"].ToString(), dread["requested_By"].ToString(), dread["date_Requested"].ToString(), dread["status"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridSupplyRequestCol(string expr)
        {
            //string base_query = "Select * from TBL_LICENSE where EmpID = '" + empno + "' and (license_type = '" + lictype + "' or license_no = '" + licno + "' or lic_expirydate = '" + licdate + "')";
            string base_query = "Select * from TBL_OFFICESUPPLIES where " + expr + "";

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[7] { new DataColumn("id"), new DataColumn("department"), new DataColumn("item_Name"), new DataColumn("quantity"), new DataColumn("requested_By"), new DataColumn("date_Requested"), new DataColumn("status") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["department"].ToString(), dread["item_Name"].ToString(), dread["quantity"].ToString(), dread["requested_By"].ToString(), dread["date_Requested"].ToString(), dread["status"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }
        public DataTable populateGridAllLocation()
        {
            dt = new DataTable();
            conn = new SqlConnection(connectionstring);
            conn.Open();
            adpt = new SqlDataAdapter("Select * from TBL_LOCATION", conn);
            adpt.Fill(dt);

            conn.Close();
            return dt;
        }
        public DataTable populateGridLocation()
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("id"), new DataColumn("LocationName"), new DataColumn("MinimumWage") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_LOCATION", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["LocationName"].ToString(), dread["MinimumWage"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridLocationCol(string expr)
        {
            //string base_query = "Select * from TBL_LICENSE where EmpID = '" + empno + "' and (license_type = '" + lictype + "' or license_no = '" + licno + "' or lic_expirydate = '" + licdate + "')";
            string base_query = "Select * from TBL_LOCATION where " + expr + "";

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("id"), new DataColumn("LocationName"), new DataColumn("MinimumWage") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["LocationName"].ToString(), dread["MinimumWage"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridStatus()
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[5] { new DataColumn("id"), new DataColumn("StatusDesc"), new DataColumn("SSSRef"), new DataColumn("DaysPerMonth"), new DataColumn("DaysPerYear") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_STATUS", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["StatusDesc"].ToString(), dread["SSSRef"].ToString(), dread["DaysPerMonth"].ToString(), dread["DaysPerYear"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridStatusCol(string expr)
        {
            //string base_query = "Select * from TBL_LICENSE where EmpID = '" + empno + "' and (license_type = '" + lictype + "' or license_no = '" + licno + "' or lic_expirydate = '" + licdate + "')";
            string base_query = "Select * from TBL_STATUS where " + expr + "";

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[5] { new DataColumn("id"), new DataColumn("StatusDesc"), new DataColumn("SSSRef"), new DataColumn("DaysPerMonth"), new DataColumn("DaysPerYear") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["StatusDesc"].ToString(), dread["SSSRef"].ToString(), dread["DaysPerMonth"].ToString(), dread["DaysPerYear"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }


        public DataTable populateGridProvince()
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("id"), new DataColumn("ProvinceName"), new DataColumn("ProvinceInclude") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_PROVINCE", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["ProvinceName"].ToString(), dread["ProvinceInclude"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridProvinceCol(string expr)
        {
            //string base_query = "Select * from TBL_LICENSE where EmpID = '" + empno + "' and (license_type = '" + lictype + "' or license_no = '" + licno + "' or lic_expirydate = '" + licdate + "')";
            string base_query = "Select * from TBL_PROVINCE where " + expr + "";

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("id"), new DataColumn("ProvinceName"), new DataColumn("ProvinceInclude") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["ProvinceName"].ToString(), dread["ProvinceInclude"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridCourse()
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("CourseCode"), new DataColumn("CourseName"), new DataColumn("IncludeField") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_COURSE", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["CourseCode"].ToString(), dread["CourseName"].ToString(), dread["IncludeField"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridCourseCol(string expr)
        {
            //string base_query = "Select * from TBL_LICENSE where EmpID = '" + empno + "' and (license_type = '" + lictype + "' or license_no = '" + licno + "' or lic_expirydate = '" + licdate + "')";
            string base_query = "Select * from TBL_COURSE where " + expr + "";

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("CourseCode"), new DataColumn("CourseName"), new DataColumn("IncludeField") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["CourseCode"].ToString(), dread["CourseName"].ToString(), dread["IncludeField"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }
        public DataTable populateGridOffenseType(string offenseno)
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("id"), new DataColumn("offenseKey"), new DataColumn("offenseDesc"), new DataColumn("suspensionDay") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_OFFENSESTYPE where offenseKey = '"+ offenseno +"'", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["offenseKey"].ToString(), dread["offenseDesc"].ToString(), dread["suspensionDay"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridOffenseTypeCol(string offenseno,string expr)
        {
            //string base_query = "Select * from TBL_LICENSE where EmpID = '" + empno + "' and (license_type = '" + lictype + "' or license_no = '" + licno + "' or lic_expirydate = '" + licdate + "')";
            string base_query = "Select * from TBL_OFFENSESTYPE where offenseKey = '"+ offenseno +"' AND " + expr + "";

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("id"), new DataColumn("offenseKey"), new DataColumn("offenseDesc"), new DataColumn("suspensionDay") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["offenseKey"].ToString(), dread["offenseDesc"].ToString(), dread["suspensionDay"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridOffense()
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("id"), new DataColumn("offenseKey"), new DataColumn("offense_desc") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_OFFENSES", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["offense_key"].ToString(), dread["offense_desc"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridOffenseCol(string expr)
        {
            //string base_query = "Select * from TBL_LICENSE where EmpID = '" + empno + "' and (license_type = '" + lictype + "' or license_no = '" + licno + "' or lic_expirydate = '" + licdate + "')";
            string base_query = "Select * from TBL_OFFENSES where " + expr + "";

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("id"), new DataColumn("offenseKey"), new DataColumn("offense_desc") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["offense_key"].ToString(), dread["offense_desc"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }


        public DataTable populateGridHoliday()
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("id"), new DataColumn("Holiday"), new DataColumn("HDescription") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_HOLIDAY", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), cm.FormatDate(dread["Holiday"].ToString()), dread["HDescription"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }



        public DataTable populateGridHolidayCol(string expr)
        {
            //string base_query = "Select * from TBL_LICENSE where EmpID = '" + empno + "' and (license_type = '" + lictype + "' or license_no = '" + licno + "' or lic_expirydate = '" + licdate + "')";
            string base_query = "Select * from TBL_HOLIDAY where " + expr + "";

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("id"), new DataColumn("Holiday"), new DataColumn("HDescription") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), cm.FormatDate(dread["Holiday"].ToString()), dread["HDescription"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }
        public bool IsDateHoliday(string dt)
        {
            return IsDateHoliday(dt, "");
        }
        public bool IsDateHoliday(string dateFrom, string dateTo)
        {
            bool ret = false;

            string qry = "Select * from TBL_HOLIDAY where Holiday  Between '" + dateFrom + "' and '" + dateTo + "'";
            if (dateTo == "")
                qry = "Select * from TBL_HOLIDAY where Holiday  = '" + dateFrom + "'";
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(qry, conn);
            dread = cmd.ExecuteReader();
            dread.Read();
            if (dread.HasRows)
                ret = true;
            dread.Close();

            conn.Close();
            return ret;

        }

        public DataTable populateGridLeaveType()
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("id"), new DataColumn("LeaveTypeDesc") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_LEAVETYPE", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["LeaveTypeDesc"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }



        public DataTable populateGridLeaveTypeCol(string expr)
        {
            //string base_query = "Select * from TBL_LICENSE where EmpID = '" + empno + "' and (license_type = '" + lictype + "' or license_no = '" + licno + "' or lic_expirydate = '" + licdate + "')";
            string base_query = "Select * from TBL_LEAVETYPE where " + expr + "";

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("id"), new DataColumn("LeaveTypeDesc") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["LeaveTypeDesc"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridLoans()
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("id"), new DataColumn("LoanID"), new DataColumn("LoanDesc") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_LOANS", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["LoanID"].ToString(), dread["LoanDesc"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }



        public DataTable populateGridLoansCol(string expr)
        {
            //string base_query = "Select * from TBL_LICENSE where EmpID = '" + empno + "' and (license_type = '" + lictype + "' or license_no = '" + licno + "' or lic_expirydate = '" + licdate + "')";
            string base_query = "Select * from TBL_LOANS where " + expr + "";

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("id"), new DataColumn("LoanID"), new DataColumn("LoanDesc") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["LoanID"].ToString(), dread["LoanDesc"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridPayClass()
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("id"), new DataColumn("PayClassCode"), new DataColumn("PayClassName"), new DataColumn("Level") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_PAYCLASS", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["PayClassCode"].ToString(), dread["PayClassName"].ToString(), dread["Level"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }



        public DataTable populateGridPayClassCol(string expr)
        {
            //string base_query = "Select * from TBL_LICENSE where EmpID = '" + empno + "' and (license_type = '" + lictype + "' or license_no = '" + licno + "' or lic_expirydate = '" + licdate + "')";
            string base_query = "Select * from TBL_PAYCLASS where " + expr + "";

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("id"), new DataColumn("PayClassCode"), new DataColumn("PayClassName"), new DataColumn("Level") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["PayClassCode"].ToString(), dread["PayClassName"].ToString(), dread["Level"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }
        public DataTable populateGridPayrollGroup()
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("id"), new DataColumn("payrollgrpname"), new DataColumn("payrollmode"), new DataColumn("grplocation") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_PAYROLLGRP", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["payrollgrpname"].ToString(), dread["payrollmode"].ToString(), dread["grplocation"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }



        public DataTable populateGridPayrollGroupCol(string expr)
        {
            //string base_query = "Select * from TBL_LICENSE where EmpID = '" + empno + "' and (license_type = '" + lictype + "' or license_no = '" + licno + "' or lic_expirydate = '" + licdate + "')";
            string base_query = "Select * from TBL_PAYROLLGRP where " + expr + "";

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("id"), new DataColumn("payrollgrpname"), new DataColumn("payrollmode"), new DataColumn("grplocation") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["payrollgrpname"].ToString(), dread["payrollmode"].ToString(), dread["grplocation"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridRoleManagement(string emprole)
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("empid"), new DataColumn("fullname"), new DataColumn("roles") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_USERS A where A.roles = '" + emprole + "'", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["empid"].ToString(), dread["fullname"].ToString(), dread["roles"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridRoleManagementCol(string emprole, string expr)
        {
            string qry = "Select * from TBL_USERS A where A.roles = '" + emprole + "'";
            qry += (expr == "" ? "" : expr);

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("empid"), new DataColumn("fullname"), new DataColumn("roles") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(qry, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["fullname"].ToString(), dread["roles"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }
        public DataTable populateGridOBTMasterSlct(string emprole)
        {
            string qry = "Select * from TBL_USERS A where A.roles = '" + emprole + "'";
            //qry += (expr == "" ? "" : expr);

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("id"), new DataColumn("fullname"), new DataColumn("roles") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(qry, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["fullname"].ToString(), dread["roles"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        #endregion READ
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
        #endregion CREATE
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
        #region NEW_SPECS
        public void IsUpdateEmployeeNumberFormat()
        {

            /*  Employee ID's with below 4 character count. */
            List<string> employeeIds = new List<string>();
            employeeIds = getEmployeeIDs();
            foreach (string empno in employeeIds)
            {

                //var newString = empno.PadLeft(4, '0');
                //Dictionary<string, string> param = new Dictionary<string, string>();
                //param.Clear();
                //param.Add("emp_EmpID", "'"+ newString + "'");
                //param.Add("emp_BiometricsID", "'" + newString + "'");
                //cm.UpdateQueryCommon(param, "TBL_EMPLOYEE_MASTER", "emp_EmpID = '" + empno + "' ");
                //cm.UpdateQueryCommon("EmpID", "'"+ newString + "'", "TBL_ADJUSTMENT", "EmpID = '" + empno + "' ");
                //cm.UpdateQueryCommon("EmpID", "'" + newString + "'", "TBL_BONUSES", "EmpID = '" + empno + "' ");
                //cm.UpdateQueryCommon("empID", "'" + newString + "'", "TBL_CONTRIBUTION", "empID = '" + empno + "' ");
                //cm.UpdateQueryCommon("EmpID", "'" + newString + "'", "TBL_FLEXISCHED", "EmpID = '" + empno + "' ");
                //cm.UpdateQueryCommon("EmpID", "'" + newString + "'", "TBL_FTS", "EmpID = '" + empno + "' ");
                //cm.UpdateQueryCommon("EmpID", "'" + newString + "'", "TBL_LEAVES", "EmpID = '" + empno + "' ");
                //cm.UpdateQueryCommon("EmpID", "'" + newString + "'", "TBL_LEAVESAPP", "EmpID = '" + empno + "' ");
                //cm.UpdateQueryCommon("EmpID", "'" + newString + "'", "TBL_LOANENTRIES", "EmpID = '" + empno + "' ");
                //cm.UpdateQueryCommon("EmpID", "'" + newString + "'", "TBL_LOANPAYMENTHISTORY", "EmpID = '" + empno + "' ");
                //cm.UpdateQueryCommon("EmpID", "'" + newString + "'", "TBL_MANAGERBRANCHES", "EmpID = '" + empno + "' ");
                //cm.UpdateQueryCommon("EmpID", "'" + newString + "'", "TBL_OBT", "EmpID = '" + empno + "' ");
                //cm.UpdateQueryCommon("EmpID", "'" + newString + "'", "TBL_OVERTIME", "EmpID = '" + empno + "' ");
                //cm.UpdateQueryCommon("empid", "'" + newString + "'", "TBL_PAYROLLSUM", "empid = '" + empno + "' ");
                //cm.UpdateQueryCommon("EmployeeID", "'" + newString + "'", "TBL_PAYSLIP", "EmployeeID = '" + empno + "' ");
                //cm.UpdateQueryCommon("empid", "'" + newString + "'", "TBL_USERS", "empid = '" + empno + "' ");
                //cm.UpdateQueryCommon("EmpID", "'" + newString + "'", "TBL_DTSSV", "EmpID = '" + empno + "' ");
                //cm.UpdateQueryCommon("emp_Approver1", "'" + newString + "'", "TBL_EMPLOYEE_MASTER", "emp_Approver1 = '" + empno + "' ");
                //cm.UpdateQueryCommon("emp_Approver2", "'" + newString + "'", "TBL_EMPLOYEE_MASTER", "emp_Approver2 = '" + empno + "' ");
                //cm.UpdateQueryCommon("Approver1", "'" + newString + "'", "TBL_LEAVESAPP", "Approver1 = '" + empno + "' ");
                //cm.UpdateQueryCommon("Approver2", "'" + newString + "'", "TBL_LEAVESAPP", "Approver2 = '" + empno + "' ");
                //cm.UpdateQueryCommon("Approver1", "'" + newString + "'", "TBL_FTS", "Approver1 = '" + empno + "' ");
                //cm.UpdateQueryCommon("Approver2", "'" + newString + "'", "TBL_FTS", "Approver2 = '" + empno + "' ");
                //cm.UpdateQueryCommon("Approver1", "'" + newString + "'", "TBL_OVERTIME", "Approver1 = '" + empno + "' ");
                //cm.UpdateQueryCommon("Approver2", "'" + newString + "'", "TBL_OVERTIME", "Approver2 = '" + empno + "' ");
                //cm.UpdateQueryCommon("Approver1", "'" + newString + "'", "TBL_OBT", "Approver1 = '" + empno + "' ");
                //cm.UpdateQueryCommon("Approver2", "'" + newString + "'", "TBL_OBT", "Approver2 = '" + empno + "' ");
                cm.UpdateQueryCommon("username", "'" + empno + "'", "TBL_USERS", "empid = '" + empno + "' ");

            }
        }
        //06/03/2022 Jan Wong.
        List<string> getEmployeeIDs()
        {
            List<string> ret = new List<string>();
            string qry = "SELECT emp_EmpID,emp_RegularizationDate FROM TBL_EMPLOYEE_MASTER WHERE emp_RegularizationDate is not null AND emp_RegularizationDate != '' AND emp_Active = 'Y' ORDER BY emp_EmpID asc";
            //string qry = "SELECT empid FROM TBL_USERS ORDER BY id DESC";
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(qry, conn);
            dread = cmd.ExecuteReader();

            while (dread.Read())
            {
                if (dread[1] != DBNull.Value)
                {
                    ret.Add(dread[0].ToString());
                }
                
            }
            dread.Close();
            conn.Close();
            return ret;


        }
        public Dictionary<string, string> getLeaveIDs()
        {
            Dictionary<string,string> getLeaveIDs = new Dictionary<string,string>();
            string qry = "SELECT A.emp_EmpID,A.emp_RegularizationDate,B.id, B.Expiry FROM TBL_EMPLOYEE_MASTER A, TBL_LEAVES B WHERE A.emp_EmpID = B.EmpID AND B.Activated = '1' " +
                "AND A.emp_RegularizationDate is not null AND A.emp_RegularizationDate != '' AND A.emp_Active = 'Y' ORDER BY emp_EmpID asc";
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(qry, conn);
            dread = cmd.ExecuteReader();

            while (dread.Read())
            {
                
                //if (dtExpiry.Date >= cm.dtnow().Date)
                //{
                //    continue;
                //}
                if (dread[1] != DBNull.Value)
                {
                    DateTime dtExpiry = new DateTime();
                    DateTime.TryParse(dread[3].ToString(), out dtExpiry);

                    DateTime dtRegDate = new DateTime();
                    DateTime.TryParse(dread[1].ToString(), out dtRegDate);
                    DateTime dtRegDatePlusYears = new DateTime(cm.dtnow().Year,dtRegDate.Month, dtRegDate.Day);
                    //if (cm.dtnow().Date >= dtRegDatePlusYears.Date && dtExpiry.Date < cm.dtnow().Date)
                    if (dtExpiry.Date <= cm.dtnow().Date)
                    {
                        int counter = 1;
                        while (dtExpiry.Date <= cm.dtnow().Date)
                        {
                            dtExpiry = dtExpiry.AddYears(counter);
                            //counter++;
                        }
                        dtRegDatePlusYears = dtRegDatePlusYears.AddYears(1);
                        getLeaveIDs.Add(dread[2].ToString(), cm.FormatDate(dtExpiry));
                    }
                        
                    
                }
            }
            dread.Close();
            conn.Close();
            return getLeaveIDs;


        }
        
        #endregion NEW_SPECS
    }
}