﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Globalization;


    public class Timekeeping
    {
        public Timekeeping()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    
        static string connectionstring = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        //public string FileDirectory = ConfigurationManager.AppSettings["201FileDirectory"].ToString();
        public SqlCommand cmd = new SqlCommand();
        public SqlConnection conn = new SqlConnection();
        public SqlDataReader dread;
        public SqlDataAdapter adpt = new SqlDataAdapter();
        public DataTable dt = new DataTable();
        public string file201folder = @"201Files\";
        Employee emp = new Employee();
        Common cm = new Common();
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
                conn.Close();
                return false;
            }
        }
        #endregion Create

        #region Read
        public DataTable populateGridOBT(string empno)
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[14] { new DataColumn("id"), new DataColumn("OBT_Status"), new DataColumn("DateFiled"),
            new DataColumn("DateFrom"),new DataColumn("DateTo"), new DataColumn("TimeIn"), new DataColumn("TimeOut"),
            new DataColumn("Reason"), new DataColumn("Approver1"), new DataColumn("DateApproved1"),
            new DataColumn("Approver2"), new DataColumn("DateApproved2"), new DataColumn("reasons2"), new DataColumn("DateApproved") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_OBT where EmpID = '" + empno + "' ORDER BY id DESC", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
            dt.Rows.Add(dread["id"].ToString(), GetLeaveStatus(dread["OBT_Status"].ToString()), dread["DateFiled"].ToString(),
                    cm.FormatDate(dread["DateFrom"].ToString()), cm.FormatDate(dread["DateTo"].ToString()), timetoampm(dread["TimeIn"].ToString()), timetoampm(dread["TimeOut"].ToString()),
                    dread["Reason"].ToString(), emp.GetEmployeeApprover1(empno), cm.FormatDate(dread["DateApproved1"].ToString()),
                    emp.GetEmployeeApprover2(empno), cm.FormatDate(dread["DateApproved2"].ToString()), dread["reasons2"].ToString(), dread["DateApproved"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }
    public string timetoampm(string timeinout)
    {
        string ret = "";
        TimeSpan tstimeinout = TimeSpan.Parse(timeinout);
        DateTime dttimeinout = DateTime.Today.Add(tstimeinout);
        string strtimeinout = dttimeinout.ToString("h:mm tt");

        ret = strtimeinout;

        return ret;

    }

        public DataTable populateGridOBTCol(string empno, string expr)
        {
            //string base_query = "Select * from TBL_LICENSE where EmpID = '" + empno + "' and (license_type = '" + lictype + "' or license_no = '" + licno + "' or lic_expirydate = '" + licdate + "')";
            string base_query = "Select * from TBL_OBT where EmpID = '" + empno + "' " + expr + "";

            dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[14] { new DataColumn("id"), new DataColumn("OBT_Status"), new DataColumn("DateFiled"),
            new DataColumn("DateFrom"),new DataColumn("DateTo"), new DataColumn("TimeIn"), new DataColumn("TimeOut"),
            new DataColumn("Reason"), new DataColumn("Approver1"), new DataColumn("DateApproved1"),
            new DataColumn("Approver2"), new DataColumn("DateApproved2"), new DataColumn("reasons2"), new DataColumn("DateApproved") });
        conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
        {
            dt.Rows.Add(dread["id"].ToString(), GetLeaveStatus(dread["OBT_Status"].ToString()), dread["DateFiled"].ToString(),
                    cm.FormatDate(dread["DateFrom"].ToString()), cm.FormatDate(dread["DateTo"].ToString()), timetoampm(dread["TimeIn"].ToString()), timetoampm(dread["TimeOut"].ToString()),
                    dread["Reason"].ToString(), emp.GetEmployeeApprover1(empno), cm.FormatDate(dread["DateApproved1"].ToString()),
                    emp.GetEmployeeApprover2(empno), cm.FormatDate(dread["DateApproved2"].ToString()), dread["reasons2"].ToString(), dread["DateApproved"].ToString());
        }
        dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridOvertime(string empno)
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[13] { new DataColumn("id"), new DataColumn("ot_Status"), new DataColumn("DateFiled"),
            new DataColumn("OTDate"), new DataColumn("ot_Time"), new DataColumn("ot_TimeOut"), new DataColumn("ot_hours"),
            new DataColumn("Reason"), new DataColumn("Approver1"), new DataColumn("DateApproved1"),
            new DataColumn("Approver2"), new DataColumn("DateApproved2"), new DataColumn("DateApproved") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_OVERTIME where EmpID = '" + empno + "' ORDER BY id DESC", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), GetLeaveStatus(dread["ot_Status"].ToString()), cm.FormatDate(dread["DateFiled"].ToString()),
                    cm.FormatDate(dread["OTDate"].ToString()), dread["ot_Time"].ToString(), dread["ot_TimeOut"].ToString(), dread["ot_hours"].ToString(),
                    dread["Reason"].ToString(), emp.GetEmployeeApprover1(empno), dread["DateApproved1"].ToString(),
                    emp.GetEmployeeApprover2(empno), dread["DateApproved2"].ToString(), dread["DateApproved"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridOvertimeCol(string empno, string expr)
        {
            //string base_query = "Select * from TBL_LICENSE where EmpID = '" + empno + "' and (license_type = '" + lictype + "' or license_no = '" + licno + "' or lic_expirydate = '" + licdate + "')";
            string base_query = "Select * from TBL_OVERTIME where EmpID = '" + empno + "' " + expr + "";

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[13] { new DataColumn("id"), new DataColumn("ot_Status"), new DataColumn("DateFiled"),
            new DataColumn("OTDate"), new DataColumn("ot_Time"), new DataColumn("ot_TimeOut"), new DataColumn("ot_hours"),
            new DataColumn("Reason"), new DataColumn("Approver1"), new DataColumn("DateApproved1"),
            new DataColumn("Approver2"), new DataColumn("DateApproved2"), new DataColumn("DateApproved") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["ot_Status"].ToString(), cm.FormatDate(dread["DateFiled"].ToString()),
                    cm.FormatDate(dread["OTDate"].ToString()), dread["ot_Time"].ToString(), dread["ot_TimeOut"].ToString(), dread["ot_hours"].ToString(),
                    dread["Reason"].ToString(), dread["Approver1"].ToString(), dread["DateApproved1"].ToString(),
                    dread["Approver2"].ToString(), dread["DateApproved2"].ToString(), dread["DateApproved"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridFTS(string empno)
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[13] { new DataColumn("id"), new DataColumn("fts_status"), new DataColumn("DateFiled"),
            new DataColumn("buss_date"), new DataColumn("ftime"), new DataColumn("fts_type"),
            new DataColumn("Reason"), new DataColumn("Approver1"), new DataColumn("DateApproved1"),
            new DataColumn("Approver2"), new DataColumn("DateApproved2"), new DataColumn("DateApproved"), new DataColumn("reasons2"), });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_FTS where EmpID = '" + empno + "' ORDER BY id DESC", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), GetLeaveStatus(dread["fts_status"].ToString()), dread["DateFiled"].ToString(),
                    cm.FormatDate(dread["buss_date"].ToString()), dread["ftime"].ToString(), dread["fts_type"].ToString(),
                    dread["Reason"].ToString(), emp.GetEmployeeApprover1(empno), dread["DateApproved1"].ToString(),
                    emp.GetEmployeeApprover2(empno), dread["DateApproved2"].ToString(), dread["DateApproved"].ToString(),
                     dread["reasons2"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridFTSCol(string empno, string expr)
        {
            //string base_query = "Select * from TBL_LICENSE where EmpID = '" + empno + "' and (license_type = '" + lictype + "' or license_no = '" + licno + "' or lic_expirydate = '" + licdate + "')";
            string base_query = "Select * from TBL_FTS where EmpID = '" + empno + "' " + expr + "";

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[12] { new DataColumn("id"), new DataColumn("fts_status"), new DataColumn("DateFiled"),
            new DataColumn("buss_date"), new DataColumn("ftime"), new DataColumn("fts_type"),
            new DataColumn("Reason"), new DataColumn("Approver1"), new DataColumn("DateApproved1"),
            new DataColumn("Approver2"), new DataColumn("DateApproved2"), new DataColumn("DateApproved") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["fts_status"].ToString(), dread["DateFiled"].ToString(),
                     cm.FormatDate(dread["buss_date"].ToString()), dread["ftime"].ToString(), dread["fts_type"].ToString(),
                     dread["Reason"].ToString(), dread["Approver1"].ToString(), dread["DateApproved1"].ToString(),
                     dread["Approver2"].ToString(), dread["DateApproved2"].ToString(), dread["DateApproved"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridLeaves(string empno)
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[6] { new DataColumn("id"), new DataColumn("LeaveType"), new DataColumn("Allowed"),
            new DataColumn("Used"), new DataColumn("Remaining"), new DataColumn("Expiry") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_LEAVES A, TBL_LEAVETYPE B where A.LeaveType = B.id and EmpID = '" + empno + "'", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["LeaveTypeDesc"].ToString(), dread["Allowed"].ToString(),
                    dread["Used"].ToString(), dread["Remaining"].ToString(), cm.FormatDate(dread["Expiry"].ToString()));
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridLeavesCol(string empno, string expr)
        {
            //string base_query = "Select * from TBL_LICENSE where EmpID = '" + empno + "' and (license_type = '" + lictype + "' or license_no = '" + licno + "' or lic_expirydate = '" + licdate + "')";
            string base_query = "Select * from TBL_LEAVES A, TBL_LEAVETYPE B where A.LeaveType = B.id and A.EmpID = '" + empno + "' " + expr + "";

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[6] { new DataColumn("id"), new DataColumn("LeaveType"), new DataColumn("Allowed"),
            new DataColumn("Used"), new DataColumn("Remaining"), new DataColumn("Expiry") });

            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["LeaveTypeDesc"].ToString(), dread["Allowed"].ToString(),
                    dread["Used"].ToString(), dread["Remaining"].ToString(), cm.FormatDate(dread["Expiry"].ToString()));
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridLeavesApp(string empno)
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[14] { new DataColumn("id"), new DataColumn("LeaveStatus"), new DataColumn("LeaveTypeDesc"),
            new DataColumn("DateFrom"), new DataColumn("DateTo"), new DataColumn("LeaveHours"), new DataColumn("DateFiled"), new DataColumn("Approver1"), new DataColumn("DateApproved1"),
            new DataColumn("Approver2"), new DataColumn("DateApproved2"),
            new DataColumn("Reason"), new DataColumn("reasons2"), new DataColumn("DateApproved") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_LEAVESAPP A, TBL_LEAVETYPE B where A.LeaveType = B.id and EmpID = '" + empno + "' ORDER BY A.id DESC", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), GetLeaveStatus(dread["LeaveStatus"].ToString()), dread["LeaveTypeDesc"].ToString(),
                    cm.FormatDate(dread["DateFrom"].ToString()), cm.FormatDate(dread["DateTo"].ToString()), dread["LeaveHours"].ToString(), cm.FormatDate(dread["DateFiled"].ToString()),
                    emp.GetEmployeeApprover1(empno), cm.FormatDate(dread["DateApproved1"].ToString()), emp.GetEmployeeApprover2(empno),
                    cm.FormatDate(dread["DateApproved2"].ToString()), dread["Reason"].ToString(), dread["reasons2"].ToString(), dread["DateApproved"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridLeavesAppCol(string empno, string expr)
        {
            //string base_query = "Select * from TBL_LICENSE where EmpID = '" + empno + "' and (license_type = '" + lictype + "' or license_no = '" + licno + "' or lic_expirydate = '" + licdate + "')";
            string base_query = "Select * from TBL_LEAVESAPP A, TBL_LEAVETYPE B where A.LeaveType = B.id and EmpID = '" + empno + "' " + expr + "";

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[15] { new DataColumn("id"), new DataColumn("LeaveStatus"), new DataColumn("LeaveTypeDesc"),
            new DataColumn("DateFrom"), new DataColumn("DateTo"), new DataColumn("NumberOfDays"), new DataColumn("DateFiled"), new DataColumn("Approver1"), new DataColumn("DateApproved1"),
            new DataColumn("Approver2"), new DataColumn("DateApproved2"),
            new DataColumn("Reason"), new DataColumn("reasons2"), new DataColumn("LeaveHours"), new DataColumn("DateApproved") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), GetLeaveStatus(dread["LeaveStatus"].ToString()), dread["LeaveTypeDesc"].ToString(),
                    cm.FormatDate(dread["DateFrom"].ToString()), dread["LeaveHours"].ToString(), dread["NumberOfDays"].ToString(), cm.FormatDate(dread["DateFiled"].ToString()),
                    dread["Approver1"].ToString(), dread["DateApproved1"].ToString(), dread["Approver2"].ToString(),
                    dread["DateApproved2"].ToString(), dread["Reason"].ToString(), dread["reasons2"].ToString(), dread["LeaveHours"].ToString(), dread["DateApproved"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridEmpLeave()
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("id"), new DataColumn("Leave_EmpName") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            string date = cm.FormatDate(DateTime.Now.ToShortDateString());
            cmd = new SqlCommand("Select * from TBL_LEAVESAPP WHERE DateFrom = '" + date + "' AND LeaveStatus = '1'", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["FullName"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridLeavesForApproval(string empno)
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[14] { new DataColumn("id"), new DataColumn("LeaveStatus"), new DataColumn("FullName"), new DataColumn("LeaveTypeDesc"),
            new DataColumn("DateFrom"), new DataColumn("DateTo"), new DataColumn("NumberOfDays"), new DataColumn("DateFiled"), new DataColumn("DateApproved1"),
            new DataColumn("DateApproved2"), new DataColumn("reasons2"), new DataColumn("EmpID"), new DataColumn("App1"), new DataColumn("App2") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_LEAVESAPP A, TBL_LEAVETYPE B where A.LeaveType = B.id and (A.Approver1 = '" + empno + "' or A.Approver2 = '" + empno + "') ORDER BY A.ID Desc", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), GetLeaveStatus(dread["LeaveStatus"].ToString()), dread["FullName"].ToString(), dread["LeaveTypeDesc"].ToString(),
                    cm.FormatDate(dread["DateFrom"].ToString()), cm.FormatDate(dread["DateTo"].ToString()), dread["NumberOfDays"].ToString(), cm.FormatDate(dread["DateFiled"].ToString()),
                    dread["DateApproved1"].ToString(), dread["DateApproved2"].ToString(), dread["reasons2"].ToString(), dread["EmpID"].ToString(),
                    dread["Approver1"].ToString(), dread["Approver2"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridOBTForApproval(string empno)
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[13] { new DataColumn("id"), new DataColumn("OBT_Status"), new DataColumn("FullName"),
            new DataColumn("DateFrom"),new DataColumn("DateTo"), new DataColumn("TimeIn"), new DataColumn("TimeOut"), new DataColumn("DateFiled"), new DataColumn("DateApproved1"),
            new DataColumn("DateApproved2"), new DataColumn("reasons2"), new DataColumn("App1"), new DataColumn("App2") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_OBT where (Approver1 = '" + empno + "' or  Approver2 = '" + empno + "') ORDER BY ID Desc", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), GetLeaveStatus(dread["OBT_Status"].ToString()), dread["FullName"].ToString(),
                    cm.FormatDate(dread["DateFrom"].ToString()), cm.FormatDate(dread["DateTo"].ToString()), dread["TimeIn"].ToString(), dread["TimeOut"].ToString(),dread["DateFiled"].ToString(),
                    cm.FormatDate(dread["DateApproved1"].ToString()), cm.FormatDate(dread["DateApproved2"].ToString()), dread["reasons2"].ToString(),
                    dread["Approver1"].ToString(), dread["Approver2"].ToString());
            }



            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridFTSForApproval(string empno)
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[12] { new DataColumn("id"), new DataColumn("fts_status"), new DataColumn("FullName"), new DataColumn("fts_type"),
            new DataColumn("buss_date"), new DataColumn("ftime"), new DataColumn("DateFiled"), new DataColumn("DateApproved1"),
            new DataColumn("DateApproved2"), new DataColumn("reasons2"), new DataColumn("App1"), new DataColumn("App2") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_FTS where (Approver1 = '" + empno + "' or  Approver2 = '" + empno + "') ORDER BY ID Desc", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), GetLeaveStatus(dread["fts_status"].ToString()), dread["FullName"].ToString(), dread["fts_type"].ToString(),
                    cm.FormatDate(dread["buss_date"].ToString()), dread["ftime"].ToString(), dread["DateFiled"].ToString(),
                    cm.FormatDate(dread["DateApproved1"].ToString()), cm.FormatDate(dread["DateApproved2"].ToString()), dread["reasons2"].ToString(),
                    dread["Approver1"].ToString(), dread["Approver2"].ToString());
            }


            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridOTForApproval(string empno)
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[12] { new DataColumn("id"), new DataColumn("ot_Status"), new DataColumn("FullName"),
            new DataColumn("OTDate"), new DataColumn("ot_Time"), new DataColumn("ot_hours"), new DataColumn("DateFiled"), new DataColumn("DateApproved1"),
            new DataColumn("DateApproved2"), new DataColumn("reasons2"),new DataColumn("App1"), new DataColumn("App2") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_OVERTIME where (Approver1 = '" + empno + "' or Approver2 = '" + empno + "') ORDER BY ID Desc", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), GetLeaveStatus(dread["ot_Status"].ToString()), dread["FullName"].ToString(),
                    cm.FormatDate(dread["OTDate"].ToString()), dread["ot_Time"].ToString(), dread["ot_hours"].ToString(), dread["DateFiled"].ToString(),
                    cm.FormatDate(dread["DateApproved1"].ToString()), cm.FormatDate(dread["DateApproved2"].ToString()), dread["reasons2"].ToString(),
                    dread["Approver1"].ToString(), dread["Approver2"].ToString());
            }

            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridDTS(string empno, string cutoffID, string dtFrom, string dtTo)
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[36] { new DataColumn("id"), new DataColumn("Emp_Name"), new DataColumn("ShiftName"),
                new DataColumn("BussDate"), new DataColumn("DTimeIn"),new DataColumn("DTimeOut"), new DataColumn("Remarks"),
                new DataColumn("AbsentDays"), new DataColumn("LWPDays"), new DataColumn("LWOPDays"), new DataColumn("Lates"),
                new DataColumn("UT"), new DataColumn("RegOT"), new DataColumn("RegOTND"), new DataColumn("LHOT"),
                new DataColumn("LHOT8Hrs"), new DataColumn("LHOTND"), new DataColumn("RDLHOT"), new DataColumn("RDLHOT8Hrs"),
                new DataColumn("RDLHOTND"), new DataColumn("RDOT"), new DataColumn("RDOT8Hrs"), new DataColumn("RDOTND"),
                new DataColumn("SHOT"), new DataColumn("SHOT8Hrs"), new DataColumn("SHOTND"), new DataColumn("RDSHOT"),
                new DataColumn("RDSHOT8Hrs"), new DataColumn("RDSHOTND"), new DataColumn("Submit"), new DataColumn("DateSubmit"),
                new DataColumn("TotHrs"), new DataColumn("TotDays"), new DataColumn("AbsHrs"), new DataColumn("LWPHrs"),
                new DataColumn("LWOPHrs")});
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_DTSAE where EmpID = '" + empno + "' AND CutOffID = " + cutoffID + " and (BussDate Between '" + dtFrom + "' and '" + dtTo + "') order by BussDate ASC", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["Emp_Name"].ToString(), dread["ShiftName"].ToString(),
                    cm.FormatDate(dread["BussDate"].ToString()), dread["DTimeIn"].ToString(), dread["DTimeOut"].ToString(),
                    dread["Remarks"].ToString(), dread["DAbsent"] == DBNull.Value ? "0" : dread["DAbsent"].ToString(),
                    dread["LWP"] == DBNull.Value ? "0" : (Convert.ToDouble(dread["LWP"].ToString()) / 8).ToString(),
                    dread["LWOP"] == DBNull.Value ? "0" : dread["LWOP"].ToString(),
                    dread["Lates"].ToString(), dread["UT"].ToString(), dread["RegOT"].ToString(), dread["RegOTND"].ToString(),
                    dread["LHOT"].ToString(), dread["LHOT8HRS"].ToString(), dread["LHOTND"].ToString(), dread["RDLHOT"].ToString(),
                    dread["RDLHOT8HRS"].ToString(), dread["RDLHOTND"].ToString(), dread["RDOT"].ToString(), dread["RDOT8HRS"].ToString(),
                    dread["RDOTND"].ToString(), dread["SHOT"].ToString(), dread["SHOT8HRS"].ToString(), dread["SHOTND"].ToString(),
                    dread["RDSHOT"].ToString(), dread["RDSHOT8HRS"].ToString(), dread["RDSHOTND"].ToString(), dread["Submit"].ToString(),
                    dread["DateSubmitted"].ToString(), dread["TotHrs"] == DBNull.Value ? "0" : dread["TotHrs"].ToString(),
                    dread["TotHrs"] == DBNull.Value ? "0" : (Convert.ToDouble(dread["TotHrs"].ToString()) / 8).ToString(),
                    dread["DAbsent"] == DBNull.Value ? "0" : (Convert.ToDouble(dread["DAbsent"].ToString()) * 8).ToString(),
                    dread["LWP"] == DBNull.Value ? "0" : (Convert.ToDouble(dread["LWP"].ToString())).ToString(),
                    dread["LWOP"] == DBNull.Value ? "0" : (Convert.ToDouble(dread["LWOP"].ToString())).ToString());
            }
            dread.Close();

            conn.Close();
            return dt;
        }

        public DataTable populateGridDTS()
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[6] { new DataColumn("id"), new DataColumn("Emp_Name"), new DataColumn("ShiftName"),
            new DataColumn("BussDate"), new DataColumn("DTimeIn"),
            new DataColumn("DTimeOut")});
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_DTSAE", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["Emp_Name"].ToString(), dread["ShiftName"].ToString(),
                    cm.FormatDate(dread["BussDate"].ToString()), dread["DTimeIn"].ToString(), dread["DTimeOut"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridDTRMaster()
        {
        try
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[8] { new DataColumn("id"), new DataColumn("Emp_Name"), new DataColumn("EmpID"),
            new DataColumn("BussDate"), new DataColumn("DateIn"),
            new DataColumn("DTimeIn"), new DataColumn("DateOut"),
            new DataColumn("DTimeOut") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_DTR", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["Emp_Name"].ToString(), dread["EmpID"].ToString(),
                    cm.FormatDate(dread["BussDate"].ToString()), cm.FormatDate(dread["DateIn"].ToString()), dread["DTimeIn"].ToString(),
                    cm.FormatDate(dread["DateOut"].ToString()), dread["DTimeOut"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;
        }
        finally
        {
            conn.Close();
        }

    }

        public DataTable populateGridDTRMasterCol(string expr)
        {
            //string base_query = "Select * from TBL_LICENSE where EmpID = '" + empno + "' and (license_type = '" + lictype + "' or license_no = '" + licno + "' or lic_expirydate = '" + licdate + "')";
            string base_query = "Select * from TBL_DTR where " + expr + "";

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[8] { new DataColumn("id"), new DataColumn("Emp_Name"), new DataColumn("EmpID"),
            new DataColumn("BussDate"), new DataColumn("DateIn"),
            new DataColumn("DTimeIn"), new DataColumn("DateOut"),
            new DataColumn("DTimeOut") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["Emp_Name"].ToString(), dread["EmpID"].ToString(),
                    cm.FormatDate(dread["BussDate"].ToString()), cm.FormatDate(dread["DateIn"].ToString()), dread["DTimeIn"].ToString(),
                    cm.FormatDate(dread["DateOut"].ToString()), dread["DTimeOut"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridAnnouncement()
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("id"), new DataColumn("description") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_ANNOUNCEMENT", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["description"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridAnnouncementCol(string expr)
        {

            string base_query = "Select * from TBL_ANNOUNCEMENT where " + expr + "";

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("id"), new DataColumn("description") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["description"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }


        public DataTable populateGridCutOff()
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[6] { new DataColumn("id"),new DataColumn("payrollgrpname"), new DataColumn("CODate"), new DataColumn("COFrom"),
            new DataColumn("COTo"), new DataColumn("CDesc") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_CUTOFF A , TBL_PAYROLLGRP B where A.PayrollGroup = B.id ORDER BY A.id DESC", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["payrollgrpname"].ToString(), cm.FormatDate(dread["CODate"].ToString()), cm.FormatDate(dread["COFrom"].ToString()), cm.FormatDate(dread["COTo"].ToString()), dread["CDesc"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridCutOffCol(string expr)
        {
            //string base_query = "Select * from TBL_LICENSE where EmpID = '" + empno + "' and (license_type = '" + lictype + "' or license_no = '" + licno + "' or lic_expirydate = '" + licdate + "')";
            string base_query = "Select * from TBL_CUTOFF A , TBL_PAYROLLGRP B where A.PayrollGroup = B.id AND " + expr + "";

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[6] { new DataColumn("id"),new DataColumn("payrollgrpname"), new DataColumn("CODate"), new DataColumn("COFrom"),
            new DataColumn("COTo"), new DataColumn("CDesc") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["payrollgrpname"].ToString(), cm.FormatDate(dread["CODate"].ToString()), cm.FormatDate(dread["COFrom"].ToString()), cm.FormatDate(dread["COTo"].ToString()), dread["CDesc"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridSchedule()
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("id"), new DataColumn("Sched_TimeIn"), new DataColumn("Sched_TimeOut"),
            new DataColumn("ShiftName") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_SCHEDULE", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["Sched_TimeIn"].ToString(), dread["Sched_TimeOut"].ToString(), dread["ShiftName"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridScheduleCol(string expr)
        {
            //string base_query = "Select * from TBL_LICENSE where EmpID = '" + empno + "' and (license_type = '" + lictype + "' or license_no = '" + licno + "' or lic_expirydate = '" + licdate + "')";
            string base_query = "Select * from TBL_SCHEDULE where " + expr + "";

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("id"), new DataColumn("Sched_TimeIn"), new DataColumn("Sched_TimeOut"),
            new DataColumn("ShiftName") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), dread["Sched_TimeIn"].ToString(), dread["Sched_TimeOut"].ToString(), dread["ShiftName"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridSummary()
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[8] { new DataColumn("id"), new DataColumn("CODate"), new DataColumn("PSName"),
            new DataColumn("PSDays"), new DataColumn("PSabsent"),
            new DataColumn("Latesmin"), new DataColumn("UTmin"),
            new DataColumn("OTReg") });
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_PAYROLLSUM ORDER BY PSname aSC, CODate dESC", conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["id"].ToString(), cm.FormatDateDay(dread["CODate"].ToString()), dread["PSName"].ToString(),
                    dread["PSDays"].ToString(), dread["PSabsent"].ToString(), dread["Latesmin"].ToString(),
                    dread["UTmin"].ToString(), dread["OTReg"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridSummaryCol(string expr)
        {
            //string base_query = "Select * from TBL_LICENSE where EmpID = '" + empno + "' and (license_type = '" + lictype + "' or license_no = '" + licno + "' or lic_expirydate = '" + licdate + "')";
            string base_query = "Select * from TBL_EMPLOYEE_MASTER A, TBL_POSITION B, TBL_PAYROLLSUM C where  A.emp_Position = b.id AND A.emp_EmpID = C.empid AND C." + expr + "";

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[32] { new DataColumn("id"), new DataColumn("PositionName"), new DataColumn("CODate"), new DataColumn("PSName"),
            new DataColumn("Days"), new DataColumn("Hours"), new DataColumn("LDays"), new DataColumn("LHours"),
            new DataColumn("LWOPDays"), new DataColumn("LWOPHrs"), new DataColumn("PSabsent"), new DataColumn("AbsHrs"),
            new DataColumn("Latesmin"), new DataColumn("UTmin"),
            new DataColumn("OTReg"), new DataColumn("OTRegNDO"), new DataColumn("Lhot8"), new DataColumn("Lhot"),
            new DataColumn("LhotNDO"), new DataColumn("Shot8"), new DataColumn("Shot"), new DataColumn("ShotNDO"),
            new DataColumn("Rdot8"), new DataColumn("Rdot"), new DataColumn("RdotNDO"), new DataColumn("RdlHot8"),
            new DataColumn("RdlHot"), new DataColumn("RdlHotNDO"), new DataColumn("RdShot8"), new DataColumn("RdShot"),
            new DataColumn("RdShotNDO"), new DataColumn("PSDays")});
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();

            while (dread.Read())
            {
                double lhrs = 0, pshrs = 0, lwophrs = 0, abshrs = 0;
                pshrs = Convert.ToDouble(dread["PSDays"].ToString()) * 8;
                if (dread["LWP"].ToString() != "")
                {
                    lhrs = Convert.ToDouble(dread["LWP"].ToString()) * 8;
                }
                if (dread["LWOP"].ToString() != "")
                {
                    lwophrs = Convert.ToDouble(dread["LWOP"].ToString()) * 8;
                }
                if (dread["PSabsent"].ToString() != "")
                {
                    abshrs = Convert.ToDouble(dread["PSabsent"].ToString()) * 8;
                }

                dt.Rows.Add(dread["id"].ToString(), dread["PositionName"].ToString(), cm.FormatDate(dread["CODate"].ToString()),
                    dread["PSName"].ToString(), dread["PSDays"].ToString(), pshrs.ToString(), dread["LWP"].ToString(),
                    lhrs.ToString(), dread["LWOP"].ToString(), lwophrs.ToString(), dread["PSabsent"].ToString(), abshrs.ToString(), dread["Latesmin"].ToString(),
                    dread["UTmin"].ToString(), dread["RegOT"].ToString(), dread["RegOTND"].ToString(), dread["LHOT8HRS"].ToString(),
                    dread["LHOT"].ToString(), dread["LHOTND"].ToString(), dread["SHOT8HRS"].ToString(), dread["SHOT"].ToString(),
                    dread["SHOTND"].ToString(), dread["RDOT8HRS"].ToString(), dread["RDOT"].ToString(), dread["RDOTND"].ToString(),
                    dread["RDLHOT8HRS"].ToString(), dread["RDLHOT"].ToString(), dread["RDLHOTND"].ToString(),
                    dread["RDSHOT8HRS"].ToString(), dread["RDSHOT"].ToString(), dread["RDSHOTND"].ToString());
            }
            dread.Close();
            //dt.Columns.Remove("CODate");
            //dt.Columns.Remove("id");
            conn.Close();
            return dt;

        }

        public string GetLeaveType(string id)
        {
            string base_query = "Select * from TBL_LEAVETYPE where id = " + id + "";
            string ret = "";

            SqlCommand cmd2 = new SqlCommand(base_query, conn);
            SqlDataReader dread2 = cmd2.ExecuteReader();
            while (dread2.Read())
            {
                ret = dread["LeaveTypeDesc"].ToString();
            }
            dread2.Close();


            return ret;
        }

        public string GetLeaveStatus(string id)
        {

            string ret = "";
            switch (id)
            {
                case "1":
                    ret = "APPROVED";
                    break;
                case "2":
                    ret = "PENDING";
                    break;
                case "3":
                    ret = "DENIED";
                    break;
                case "4":
                    ret = "ONGOING";
                    break;

            }


            return ret;
        }

        public int GetLeaveTypeIDApp(string empno)
        {
            string base_query = "Select * from TBL_LEAVEAPP where EmpID = '" + empno + "' and LeaveStatus = '1'";
            int ret = -1;

            SqlCommand cmd2 = new SqlCommand(base_query, conn);
            SqlDataReader dread2 = cmd2.ExecuteReader();
            while (dread2.Read())
            {
                ret = int.Parse(dread["LeaveType"].ToString());
            }
            dread2.Close();


            return ret;


        }

        public DataTable populateGridOBTSummaryCol(string expr)
        {
            //string base_query = "Select * from TBL_LICENSE where EmpID = '" + empno + "' and (license_type = '" + lictype + "' or license_no = '" + licno + "' or lic_expirydate = '" + licdate + "')";
            string base_query = "Select * from TBL_EMPLOYEE_MASTER A , TBL_OBT B, TBL_POSITION C, TBL_COMPANY D, TBL_DEPARTMENT E WHERE A.emp_EmpID = B.EmpID and A.emp_Position = C.id and A.emp_Assignment = d.id and A.emp_Department = e.id and " + expr + "";

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[6] { new DataColumn("Name"), new DataColumn("Position"),new DataColumn("Department"),
            new DataColumn("TripDate"), new DataColumn("ApproveDate"), new DataColumn("Status")});
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["emp_FullName"].ToString(), dread["PositionName"].ToString(), dread["DeptName"].ToString(),
                    cm.FormatDate(dread["DateFrom"].ToString()) + "-" + cm.FormatDate(dread["DateTo"].ToString()), cm.FormatDate(dread["DateApproved"].ToString()), GetLeaveStatus(dread["OBT_Status"].ToString()));
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridOTSummaryCol(string expr)
        {
        //string base_query = "Select * from TBL_LICENSE where EmpID = '" + empno + "' and (license_type = '" + lictype + "' or license_no = '" + licno + "' or lic_expirydate = '" + licdate + "')";
            string base_query = "Select * from TBL_EMPLOYEE_MASTER A , TBL_OVERTIME B, TBL_POSITION C, TBL_COMPANY D, TBL_DEPARTMENT E, TBL_DTSAE F  " +
           "WHERE A.emp_EmpID = B.EmpID and A.emp_Position = C.id and A.emp_Assignment = d.id and A.emp_Department = e.id and b.EmpID = f.EmpID and B.OTDate = F.BussDate and " + expr + "";

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[25] { new DataColumn("Name"), new DataColumn("Position"),new DataColumn("Department"),
                new DataColumn("OTDate"), new DataColumn("Reason"), new DataColumn("RegOT"), new DataColumn("RegOTND"), new DataColumn("LHOT"),
                new DataColumn("LHOT8Hrs"), new DataColumn("LHOTND"), new DataColumn("RDLHOT"), new DataColumn("RDLHOT8Hrs"),
                new DataColumn("RDLHOTND"), new DataColumn("RDOT"), new DataColumn("RDOT8Hrs"), new DataColumn("RDOTND"),
                new DataColumn("SHOT"), new DataColumn("SHOT8Hrs"), new DataColumn("SHOTND"), new DataColumn("RDSHOT"),
                new DataColumn("RDSHOT8Hrs"), new DataColumn("RDSHOTND"), new DataColumn("Hours"), new DataColumn("DateApproved1"), new DataColumn("Status")});
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["emp_FullName"].ToString(), dread["PositionName"].ToString(), dread["DeptName"].ToString(),
                    cm.FormatDate(dread["OTDate"].ToString()), dread["Reason"].ToString(), dread["RegOT"].ToString(), dread["RegOTND"].ToString(),
                    dread["LHOT"].ToString(), dread["LHOT8HRS"].ToString(), dread["LHOTND"].ToString(), dread["RDLHOT"].ToString(),
                    dread["RDLHOT8HRS"].ToString(), dread["RDLHOTND"].ToString(), dread["RDOT"].ToString(), dread["RDOT8HRS"].ToString(),
                    dread["RDOTND"].ToString(), dread["SHOT"].ToString(), dread["SHOT8HRS"].ToString(), dread["SHOTND"].ToString(),
                    dread["RDSHOT"].ToString(), dread["RDSHOT8HRS"].ToString(), dread["RDSHOTND"].ToString(), dread["ot_hours"].ToString(),
                    cm.FormatDate(dread["DateApproved1"].ToString()), GetLeaveStatus(dread["ot_Status"].ToString()));
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridLeavesSummaryCol(string expr)
        {
        //string base_query = "Select * from TBL_LICENSE where EmpID = '" + empno + "' and (license_type = '" + lictype + "' or license_no = '" + licno + "' or lic_expirydate = '" + licdate + "')";
            string base_query = "Select * from TBL_EMPLOYEE_MASTER A, TBL_LEAVES B, TBL_LEAVESAPP C, TBL_POSITION D, TBL_DEPARTMENT E, TBL_COMPANY F, TBL_LEAVETYPE G " +
           "WHERE A.emp_EmpID = B.EmpID AND A.emp_EmpID = c.EmpID AND B.LeaveType = G.id AND C.LeaveType = G.id AND A.emp_Position = d.id AND A.emp_Assignment = F.id AND a.emp_Department = e.id AND " + expr + "";

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[18] { new DataColumn("Name"), new DataColumn("DateFrom"),new DataColumn("LeaveHours"),
                new DataColumn("Earned"), new DataColumn("Used"), new DataColumn("Balance"), new DataColumn("LeaveType"), new DataColumn("leaveKey"),
                new DataColumn("Reason"),new DataColumn("Status"),new DataColumn("DateFiled"),new DataColumn("DateApproved1"),
                new DataColumn("Approver1"),new DataColumn("DateApproved2"), new DataColumn("Approver2"),new DataColumn("Days"),
                new DataColumn("Position"),new DataColumn("Department")});
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                string leaveKey = "";
                if (dread["LeaveKey"].ToString() == "SL" || dread["LeaveKey"].ToString() == "VL")
                    leaveKey = "With Pay";
                else
                    leaveKey = "Without Pay";
                dt.Rows.Add(dread["emp_FullName"].ToString(), cm.FormatDate(dread["DateFrom"].ToString()), dread["LeaveHours"].ToString(),
                    dread["Allowed"].ToString(), dread["Used"].ToString(), dread["Remaining"].ToString(), dread["LeaveTypeDesc"].ToString(), leaveKey,
                    dread["Reason"].ToString(), GetLeaveStatus(dread["LeaveStatus"].ToString()), dread["DateFiled"].ToString(), dread["DateApproved1"].ToString(),
                    dread["Approver1"].ToString(), dread["DateApproved2"].ToString(), dread["Approver2"].ToString(), dread["NumberOfDays"].ToString(),
                    dread["PositionName"].ToString(), dread["DeptName"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }
    public DataTable populateLoanReportExport(string loanmonth, string loanyear, string company, string empnum, string loantype)
    {
        string expr = "";
        string contritypeexpr = "";
        string base_query = "";
        string getloantype = "";
        string getloantypeno = "";
        //getloantype = cm.GetSpecificDataFromDB("LoanDesc","TBL_LOANS","where LoanID = '"+loantype+"'");
        //getloantype = getloantype != "" ? getloantype+ "," : "";

        //expr += loanmonth == "" ? "" : "AND Month(E.CODate) = '" + loanmonth + "' ";
        expr += loanmonth == "" ? "" : "AND Month(E.COFrom) = '" + loanmonth + "' ";
        expr += loanyear == "" ? "" : "AND year(E.COFrom) = " + loanyear + " ";
        expr += company == "" ? "" : "AND D.emp_Assignment = " + company + " ";
        expr += empnum == "" ? "" : "AND A.empID = '" + empnum + "' ";

        if (loantype == "SSS" || loantype == "SSSCL")
        {
            contritypeexpr = "emp_SSSNo as [SSS No.], ";
            getloantype = " AND C.LoanID = '" + loantype + "'";


        }
        else if (loantype == "PIL" || loantype == "PICL")
        {
            contritypeexpr = "emp_PagibigNo as [HDMF No.], ";
            getloantype = " AND C.LoanID = '" + loantype + "'";
        }
        else if (loantype == "CA" || loantype == "CA")
        {
            getloantype = " AND C.LoanID = '" + loantype + "'";
        }
        else if (loantype == "")
            contritypeexpr = "emp_SSSNo as [SSS No.],emp_PagibigNo as [HDMF No.], ";

        base_query = "Select A.EmpID as [Employee Number], emp_FullName as [Full Name], " +
            "" + contritypeexpr + "C.LoanDesc as [Type of Loan], B.DateFiled as [Date Filed]," +
            "B.LoanAmount as [Original Amount],B.Balance as [Balance]," +
            "A.amountPaid as [Amount Paid],A.DateTrans as [Date Transact] " +
            "from TBL_LOANPAYMENTHISTORY A, TBL_LOANENTRIES B, TBL_LOANS C, " +
            "TBL_EMPLOYEE_MASTER D, TBL_CUTOFF E where A.loanEntryID = B.id AND " +
            "B.LoanCode = C.id AND A.EmpID = D.emp_EmpID AND A.CutOffID = E.id " + expr + " " + getloantype + "";
        dt = new DataTable();

        conn = new SqlConnection(connectionstring);
        conn.Open();
        adpt = new SqlDataAdapter(base_query, conn);
        adpt.Fill(dt);

        conn.Close();


        return dt;

    }

    public DataTable populateGridUASummaryCol(string expr)
        {
            //string base_query = "Select * from TBL_LICENSE where EmpID = '" + empno + "' and (license_type = '" + lictype + "' or license_no = '" + licno + "' or lic_expirydate = '" + licdate + "')";
            string base_query = "Select * from TBL_EMPLOYEE_MASTER A , TBL_FTS B, TBL_POSITION C, TBL_DEPARTMENT D, TBL_COMPANY E WHERE " +
                "a.emp_EmpID = b.EmpID AND A.emp_Position = C.id AND A.emp_Department = D.id AND A.emp_Assignment = E.id AND " + expr + "";

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[6] { new DataColumn("Name"), new DataColumn("Position"),new DataColumn("Department"),
            new DataColumn("Date"), new DataColumn("DateApproved"), new DataColumn("Status")});
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["emp_FullName"].ToString(), dread["PositionName"].ToString(), dread["DeptName"].ToString(),
                    cm.FormatDate(dread["buss_date"].ToString()), cm.FormatDate(dread["DateApproved"].ToString()), GetLeaveStatus(dread["fts_Status"].ToString()));
            }
            dread.Close();

            conn.Close();
            return dt;

        }

        public DataTable populateGridLateSummaryCol(string expr)
        {
            //string base_query = "Select * from TBL_LICENSE where EmpID = '" + empno + "' and (license_type = '" + lictype + "' or license_no = '" + licno + "' or lic_expirydate = '" + licdate + "')";
            string base_query = "Select * from TBL_EMPLOYEE_MASTER A , TBL_PAYROLLSUM B, TBL_POSITION C, TBL_DEPARTMENT D, TBL_COMPANY E WHERE " +
                "a.emp_EmpID = b.EmpID AND A.emp_Position = C.id AND A.emp_Department = D.id AND A.emp_Assignment = E.id AND " + expr + "";

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[5] { new DataColumn("Name"), new DataColumn("Position"),new DataColumn("Department"),
            new DataColumn("Minutes"), new DataColumn("Absent")});
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["emp_FullName"].ToString(), dread["PositionName"].ToString(), dread["DeptName"].ToString(),
                    dread["Latesmin"].ToString(), dread["PSabsent"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }
    public DataTable populateGridAbsentSummaryCol(string company, string department, string startdate, string enddate)
    {
        string expr = "";
        expr += company == "" ? "" : " AND E.id = " + company + "";
        expr += department == "" ? "" : " AND D.id = " + department + "";
        expr += (startdate == "" || enddate == "") ? "" : " AND (B.CODate BETWEEN '" + startdate + "' AND '" + enddate + "')";
        string base_query = "Select * from TBL_EMPLOYEE_MASTER A , TBL_PAYROLLSUM B, TBL_POSITION C, TBL_DEPARTMENT D, TBL_COMPANY E WHERE " +
            "a.emp_EmpID = b.EmpID AND A.emp_Position = C.id AND A.emp_Department = D.id AND A.emp_Assignment = E.id AND B.PSabsent != '0' AND B.PSabsent is not null " + expr + "";
        base_query += " order by A.emp_FullName asc, B.CODate asc";

        dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[5] { new DataColumn("Name"), new DataColumn("Position"),new DataColumn("Department"),
            new DataColumn("Minutes"), new DataColumn("Absent")});
        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand(base_query, conn);
        dread = cmd.ExecuteReader();
        while (dread.Read())
        {
            dt.Rows.Add(dread["emp_FullName"].ToString(), dread["PositionName"].ToString(), dread["DeptName"].ToString(),
                dread["Latesmin"].ToString(), dread["PSabsent"].ToString());
        }
        dread.Close();

        conn.Close();
        return dt;

    }
    public DataTable populateGridContributionCol(string contrimonth, string contriyear, string contripaygroup, string contriemp)
        {
            string expr = "";
            string base_query = "";
            expr += contrimonth == "" ? "" : "AND G.creditMonth = '" + contrimonth + "' ";
            expr += contriyear == "" ? "" : "AND year(G.CODate) = " + contriyear + " ";
            expr += contripaygroup == "" ? "" : "AND G.PayrollGroup = " + contripaygroup + " ";
            expr += contriemp == "" ? "" : "AND A.empID = '" + contriemp + "' ";
            
               base_query = "Select * from TBL_CONTRIBUTION A,TBL_EMPLOYEE_MASTER B, TBL_PAYSLIP C, TBL_POSITION D, TBL_DEPARTMENT E," +
                "TBL_COMPANY F, TBL_CUTOFF G WHERE A.empID = B.emp_EmpID AND A.empID = C.EmployeeID AND B.emp_Position = D.id AND B.emp_Department = E.id AND C.CutoffID = G.id AND A.cutoffID = G.id " + expr + "";
            
            

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[10] { new DataColumn("empID"), new DataColumn("emp_FullName"),new DataColumn("CODate"),
                new DataColumn("sssER"), new DataColumn("sssEE"), new DataColumn("sssEC"),
                new DataColumn("philhealthEE"), new DataColumn("philhealthER"),new DataColumn("pagibigEE")
                ,new DataColumn("pagibigER")});
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                dt.Rows.Add(dread["empID"].ToString(),dread["emp_FullName"].ToString(), cm.FormatDate(dread["CODate"].ToString()), dread["sssER"].ToString(), dread["sssEE"].ToString(), dread["sssEC"].ToString(),
                    dread["philhealthEE"].ToString(), dread["philhealthER"].ToString(), dread["pagibigEE"].ToString(), dread["pagibigER"].ToString());
            }
            dread.Close();

            conn.Close();
            return dt;

        }
    public DataTable populateLatesReportCol(string empno,string year,string month)
    {
        string expr = "";
        string base_query = "";
        expr += month == "" ? "" : "AND month(BussDate) = '" + month + "' ";
        expr += year == "" ? "" : "AND year(BussDate) = " + year + " ";
        //expr += contripaygroup == "" ? "" : "AND G.PayrollGroup = " + contripaygroup + " ";
        expr += empno == "" ? "" : "AND emp_EmpID = '" + empno + "' ";

        base_query = "SELECT emp_FullName as [Name],BussDate as [Date Log],ShiftName as [ShiftName],DTimeIn as [Time In], DTimeOut as [Time Out], Latesmin as [Lates Minuite] FROM TBL_DTSAE A, TBL_EMPLOYEE_MASTER B where A.EmpID = B.emp_EmpID AND emp_Active != 'N' AND DATALENGTH(Latesmin) > 0 AND Latesmin != 0 " + expr + "";



        dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[6] { new DataColumn("Name"), new DataColumn("Date Log"),new DataColumn("ShiftName"),
                new DataColumn("Time In"), new DataColumn("Time Out"), new DataColumn("Lates Minuite")});
        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand(base_query, conn);
        dread = cmd.ExecuteReader();
        while (dread.Read())
        {
            dt.Rows.Add(dread["Name"].ToString(), dread["Date Log"].ToString(),dread["ShiftName"].ToString(),
                dread["Time In"].ToString(), dread["Time Out"].ToString(), dread["Lates Minuite"].ToString());
        }
        dread.Close();

        conn.Close();
        return dt;

    }

    #endregion Read

    #region Update

    #endregion Update

    #region Delete
    #endregion Delete




    #region DTR processing
    //public bool processData(string path)
    //{
    //    return processData(path, null);
    //}
    //public bool processData(string path, HttpPostedFile postedfile)
    public bool processData(StreamReader srReader)
        {
            return processData(srReader, null);
        }
        public bool processData(StreamReader srReader, HttpPostedFile postedfile)
        {

            //try
            //{
            conn = new SqlConnection(connectionstring);
            conn.Open();
            string str_qry = "";
            DataTable tempdb = new DataTable();
            tempdb.Columns.Add("EmpID");
            tempdb.Columns.Add("DateTime");
            tempdb.Columns.Add("TimeIN_OUT");
            tempdb.Columns.Add("TimeIN");
            tempdb.Columns.Add("TimeOUT");
            tempdb.Columns.Add("Flag");
            tempdb.Columns.Add("Action");
            if (postedfile != null)
            {
                using (StreamReader sr = new StreamReader(postedfile.InputStream))
                {


                    while (!sr.EndOfStream)
                    {
                        //string[] rows1 = sr.ReadLine().Split(new Char[] { '\t' });
                        string[] rows = sr.ReadLine().Split(new Char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        DataRow dr = tempdb.NewRow();
                        dr["EmpID"] = rows[0].Trim();
                        dr["DateTime"] = rows[1];
                        dr["TimeIN_OUT"] = rows[2];
                        dr["Flag"] = (rows[4] == "0" ? "I" : "O");
                        tempdb.Rows.Add(dr);
                    }
                }
            }
            else
            {
                //using (StreamReader sr = new StreamReader(path))
                using (srReader)
                {


                    while (!srReader.EndOfStream)
                    {
                        //string[] rows1 = sr.ReadLine().Split(new Char[] { '\t' });
                        string[] rows = srReader.ReadLine().Split(new Char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        DataRow dr = tempdb.NewRow();
                        dr["EmpID"] = rows[0].Trim();
                        dr["DateTime"] = rows[1];
                        dr["TimeIN_OUT"] = rows[2];
                        dr["Flag"] = (rows[4] == "0" ? "I" : "O");
                        tempdb.Rows.Add(dr);
                    }
                }
            }

            var AllInRecords = (from row in tempdb.AsEnumerable()
                                where row.Field<string>("Flag") == "I"
                                select new
                                {
                                    EmpID = row.Field<string>("EmpID"),
                                    Datetime = row.Field<string>("DateTime"),
                                    Timeinout = row.Field<string>("TimeIN_OUT"),
                                    Flag = row.Field<string>("Flag")
                                });
            var FilteredInRecs =
                            (from h in AllInRecords
                             group h by new
                             {
                                 h.EmpID,
                                 h.Datetime
                             } into g //Pull out the unique indexes
                             let f = g.FirstOrDefault()
                             where f != null

                             select new
                             {
                                 EmpID = f.EmpID,
                                 BussDate = f.Datetime,
                                 In = g.Min(c => c.Timeinout),
                             });

            var AllOutRecords = (from row in tempdb.AsEnumerable()
                                 where row.Field<string>("Flag") == "O"
                                 select new
                                 {
                                     EmpID = row.Field<string>("EmpID"),
                                     Datetime = row.Field<string>("DateTime"),
                                     Timeinout = row.Field<string>("TimeIN_OUT"),
                                     Flag = row.Field<string>("Flag")
                                 });



            Dictionary<string, string> empinfo = new Dictionary<string, string>();
            foreach (var inrec in FilteredInRecs)
            {
                empinfo.Clear();

                if (get_emp_info(inrec.EmpID, DateTime.Parse(inrec.BussDate), out empinfo))
                {
                    string bussdate = (DateTime.Parse(inrec.BussDate)).ToString("MM/dd/yyyy");
                    SqlCommand cmdCheck; bool IsUploaded = false;
                    cmdCheck = new SqlCommand("Select * from TBL_DTR where EmpID = '" + inrec.EmpID + "' and BussDate = '" + bussdate + "' and Flag = 'I'", conn);
                    dread = cmdCheck.ExecuteReader();
                    dread.Read();
                    IsUploaded = dread.HasRows;
                    dread.Close();

                    if (!empinfo.ContainsKey("Sched_TimeIn"))
                        continue;

                    if (!IsUploaded)
                    {
                        str_qry = "INSERT INTO TBL_DTR (EmpID, BussDate, Emp_Name, DateIn, DTimeIn, Flag, Sched_TimeIn, Sched_TimeOut) VALUES('" + inrec.EmpID + "','" + bussdate + "','" + empinfo["emp_FullName"] + "','" + inrec.BussDate + "','" +
                            inrec.In + "','I','" + empinfo["Sched_TimeIn"] + "','" + empinfo["Sched_TimeOut"] + "')";
                        cmd = new SqlCommand(str_qry, conn);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        str_qry = "UPDATE TBL_DTR SET  DTimeIn = '" +
                            inrec.In + "' , Sched_TimeIn = '" + empinfo["Sched_TimeIn"] + "' , Sched_TimeOut = '" + empinfo["Sched_TimeOut"] + "' where EmpID = '" + inrec.EmpID + "' and BussDate = '" + bussdate + "' and Flag = 'I'";

                        cmd = new SqlCommand(str_qry, conn);
                        cmd.ExecuteNonQuery();
                    }
                }




                Console.WriteLine(inrec.ToString());
                var outrec1 = (from r in AllOutRecords.AsEnumerable()
                               where r.EmpID == inrec.EmpID && checkDate(inrec.In, inrec.BussDate, r.Timeinout, r.Datetime)
                               group r by new
                               {
                                   r.EmpID,
                                   r.Datetime
                               } into g
                               select new
                               {
                                   EmpID = g.Key.EmpID,
                                   BussDate = g.Key.Datetime,
                                   Out = g.Max(c => c.Timeinout)

                               });
                if (outrec1.Count() > 0)
                {
                    foreach (var resout in outrec1)
                    {
                        //dtr = dtrdb.NewRow();
                        //dtr["EmpID"] = inrec.EmpID;
                        //dtr["BusinessDate"] = inrec.BussDate;
                        //dtr["DateTime"] = resout.BussDate;
                        //dtr["TimeIN_OUT"] = resout.Out;
                        //dtr["Flag"] = "O";
                        //dtr["Action"] = "OUT";
                        //dtr["TimeOUT"] = resout.Out;
                        //dtrdb.Rows.Add(dtr);

                        if (get_emp_info(inrec.EmpID, DateTime.Parse(inrec.BussDate), out empinfo))
                        {
                            string bussdate = (DateTime.Parse(inrec.BussDate)).ToString("MM/dd/yyyy");
                            SqlCommand cmdCheck; bool IsUploaded = false;
                            cmdCheck = new SqlCommand("Select * from TBL_DTR where EmpID = '" + inrec.EmpID + "' and BussDate = '" + bussdate + "' and Flag = 'O'", conn);
                            dread = cmdCheck.ExecuteReader();
                            dread.Read();
                            IsUploaded = dread.HasRows;
                            dread.Close();
                            if (!IsUploaded)
                            {
                                str_qry = "INSERT INTO TBL_DTR (EmpID, BussDate, Emp_Name, DateOut, DTimeOut, Flag, Sched_TimeIn, Sched_TimeOut) VALUES('" + inrec.EmpID + "','" + bussdate + "','" + empinfo["emp_FullName"] + "','" + resout.BussDate + "','" + resout.Out + "','O','" + empinfo["Sched_TimeIn"] + "','" + empinfo["Sched_TimeOut"] + "')";
                                cmd = new SqlCommand(str_qry, conn);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
                //else
                //{
                //    dtr = dtrdb.NewRow();
                //    dtr["EmpID"] = inrec.EmpID;
                //    dtr["BusinessDate"] = inrec.BussDate;
                //    dtr["DateTime"] = "";
                //    dtr["TimeIN_OUT"] = "NO-OUT";
                //    dtr["Flag"] = "O";
                //    dtr["Action"] = "OUT";
                //    dtr["TimeOUT"] = "NO-OUT";
                //    dtrdb.Rows.Add(dtr);
                //}


            }

            //return tempdb;
            conn.Close();
            return true;
            //}
            //catch
            //{
            //    return false;

            //}
        }

        public bool processData(DataTable xpsDb)
        {

            //try
            //{
            conn = new SqlConnection(connectionstring);
            conn.Open();
            string str_qry = "";
            DataTable tempdb = xpsDb;
            //tempdb.Columns.Add("EmpID");
            //tempdb.Columns.Add("DateTime");
            //tempdb.Columns.Add("TimeIN_OUT");
            //tempdb.Columns.Add("TimeIN");
            //tempdb.Columns.Add("TimeOUT");
            //tempdb.Columns.Add("Flag");
            //tempdb.Columns.Add("Action");
            //if (postedfile != null)
            //{
            //    using (StreamReader sr = new StreamReader(postedfile.InputStream))
            //    {


            //        while (!sr.EndOfStream)
            //        {
            //            //string[] rows1 = sr.ReadLine().Split(new Char[] { '\t' });
            //            string[] rows = sr.ReadLine().Split(new Char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //            DataRow dr = tempdb.NewRow();
            //            dr["EmpID"] = rows[0].Trim();
            //            dr["DateTime"] = rows[1];
            //            dr["TimeIN_OUT"] = rows[2];
            //            dr["Flag"] = (rows[4] == "0" ? "I" : "O");
            //            tempdb.Rows.Add(dr);
            //        }
            //    }
            //}
            //else
            //{
            //    //using (StreamReader sr = new StreamReader(path))
            //    using (srReader)
            //    {


            //        while (!srReader.EndOfStream)
            //        {
            //            //string[] rows1 = sr.ReadLine().Split(new Char[] { '\t' });
            //            string[] rows = srReader.ReadLine().Split(new Char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //            DataRow dr = tempdb.NewRow();
            //            dr["EmpID"] = rows[0].Trim();
            //            dr["DateTime"] = rows[1];
            //            dr["TimeIN_OUT"] = rows[2];
            //            dr["Flag"] = (rows[4] == "0" ? "I" : "O");
            //            tempdb.Rows.Add(dr);
            //        }
            //    }
            //}

            var AllInRecords = (from row in tempdb.AsEnumerable()
                                where row.Field<string>("Flag") == "I"
                                select new
                                {
                                    EmpID = row.Field<string>("EmpID"),
                                    Datetime = row.Field<string>("DateTime"),
                                    Timeinout = row.Field<string>("TimeIN_OUT"),
                                    Flag = row.Field<string>("Flag")
                                });
            var FilteredInRecs =
                            (from h in AllInRecords
                             group h by new
                             {
                                 h.EmpID,
                                 h.Datetime
                             } into g //Pull out the unique indexes
                             let f = g.FirstOrDefault()
                             where f != null

                             select new
                             {
                                 EmpID = f.EmpID,
                                 BussDate = f.Datetime,
                                 In = g.Min(c => c.Timeinout),
                             });

            var AllOutRecords = (from row in tempdb.AsEnumerable()
                                 where row.Field<string>("Flag") == "O"
                                 select new
                                 {
                                     EmpID = row.Field<string>("EmpID"),
                                     Datetime = row.Field<string>("DateTime"),
                                     Timeinout = row.Field<string>("TimeIN_OUT"),
                                     Flag = row.Field<string>("Flag")
                                 });



            Dictionary<string, string> empinfo = new Dictionary<string, string>();
            foreach (var inrec in FilteredInRecs)
            {
            

            empinfo.Clear();

                if (get_emp_info(inrec.EmpID, DateTime.Parse(inrec.BussDate), out empinfo))
                {
                    string bussdate = (DateTime.Parse(inrec.BussDate)).ToString("MM/dd/yyyy");
                    SqlCommand cmdCheck; bool IsUploaded = false;
                    cmdCheck = new SqlCommand("Select * from TBL_DTR where EmpID = '" + inrec.EmpID + "' and BussDate = '" + bussdate + "' and Flag = 'I'", conn);
                    dread = cmdCheck.ExecuteReader();
                    dread.Read();
                    IsUploaded = dread.HasRows;
                    dread.Close();

                    if (!empinfo.ContainsKey("Sched_TimeIn"))
                        continue;

                    if (!IsUploaded)
                    {
                        str_qry = "INSERT INTO TBL_DTR (EmpID, BussDate, Emp_Name, DateIn, DTimeIn, Flag, Sched_TimeIn, Sched_TimeOut) VALUES('" + inrec.EmpID + "','" + bussdate + "','" + empinfo["emp_FullName"] + "','" + inrec.BussDate + "','" +
                            inrec.In + "','I','" + empinfo["Sched_TimeIn"] + "','" + empinfo["Sched_TimeOut"] + "')";
                        cmd = new SqlCommand(str_qry, conn);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        str_qry = "UPDATE TBL_DTR SET  DTimeIn = '" +
                            inrec.In + "' , Sched_TimeIn = '" + empinfo["Sched_TimeIn"] + "' , Sched_TimeOut = '" + empinfo["Sched_TimeOut"] + "' where EmpID = '" + inrec.EmpID + "' and BussDate = '" + bussdate + "' and Flag = 'I'";

                        cmd = new SqlCommand(str_qry, conn);
                        cmd.ExecuteNonQuery();
                    }
                }




                Console.WriteLine(inrec.ToString());
                var outrec1 = (from r in AllOutRecords.AsEnumerable()
                               where r.EmpID == inrec.EmpID && checkDate(inrec.In, inrec.BussDate, r.Timeinout, r.Datetime)
                               group r by new
                               {
                                   r.EmpID,
                                   r.Datetime
                               } into g
                               select new
                               {
                                   EmpID = g.Key.EmpID,
                                   BussDate = g.Key.Datetime,
                                   Out = g.Max(c => c.Timeinout)

                               });
                if (outrec1.Count() > 0)
                {
                    foreach (var resout in outrec1)
                    {
                        //dtr = dtrdb.NewRow();
                        //dtr["EmpID"] = inrec.EmpID;
                        //dtr["BusinessDate"] = inrec.BussDate;
                        //dtr["DateTime"] = resout.BussDate;
                        //dtr["TimeIN_OUT"] = resout.Out;
                        //dtr["Flag"] = "O";
                        //dtr["Action"] = "OUT";
                        //dtr["TimeOUT"] = resout.Out;
                        //dtrdb.Rows.Add(dtr);

                        if (get_emp_info(inrec.EmpID, DateTime.Parse(inrec.BussDate), out empinfo))
                        {
                            string bussdate = (DateTime.Parse(inrec.BussDate)).ToString("MM/dd/yyyy");
                            SqlCommand cmdCheck; bool IsUploaded = false;
                            cmdCheck = new SqlCommand("Select * from TBL_DTR where EmpID = '" + inrec.EmpID + "' and BussDate = '" + bussdate + "' and Flag = 'O'", conn);
                            dread = cmdCheck.ExecuteReader();
                            dread.Read();
                            IsUploaded = dread.HasRows;
                            dread.Close();
                            if (!IsUploaded)
                            {
                                str_qry = "INSERT INTO TBL_DTR (EmpID, BussDate, Emp_Name, DateOut, DTimeOut, Flag, Sched_TimeIn, Sched_TimeOut) VALUES('" + inrec.EmpID + "','" + bussdate + "','" + empinfo["emp_FullName"] + "','" + resout.BussDate + "','" + resout.Out + "','O','" + empinfo["Sched_TimeIn"] + "','" + empinfo["Sched_TimeOut"] + "')";
                                cmd = new SqlCommand(str_qry, conn);
                                cmd.ExecuteNonQuery();
                            }
                        else
                        {
                            str_qry = UpdateDTRQueryBuilder(inrec.EmpID, bussdate, empinfo["emp_FullName"], bussdate, resout.Out, "O", empinfo["Sched_TimeIn"], empinfo["Sched_TimeOut"]);

                            cmd = new SqlCommand(str_qry, conn);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    }
                }
                //else
                //{
                //    dtr = dtrdb.NewRow();
                //    dtr["EmpID"] = inrec.EmpID;
                //    dtr["BusinessDate"] = inrec.BussDate;
                //    dtr["DateTime"] = "";
                //    dtr["TimeIN_OUT"] = "NO-OUT";
                //    dtr["Flag"] = "O";
                //    dtr["Action"] = "OUT";
                //    dtr["TimeOUT"] = "NO-OUT";
                //    dtrdb.Rows.Add(dtr);
                //}


            }

            //return tempdb;
            conn.Close();
            return true;
            //}
            //catch
            //{
            //    return false;

            //}
        }
    string UpdateDTRQueryBuilder(string EmpID, string BussDate, string Emp_Name, string DateLog, string TimeLog, string Flag, string Sched_TimeIn, string Sched_TimeOut)
    {
        string qry = "UPDATE TBL_DTR SET Emp_Name = '" + Emp_Name + "', DTimeOut = '" +
                        TimeLog + "' , Sched_TimeIn = '" + Sched_TimeIn + "' , Sched_TimeOut = '" + Sched_TimeOut + "' where EmpID = '" + EmpID + "' and BussDate = '" + BussDate + "' and Flag = '" + Flag + "'";


        return qry;

    }

    public bool mergeData(string cutoff_id, string empnum, out int ret)
        {
        conn.Close();
        string ftstimeinout = "", ftstype = "";
            bool valid = true;
            ret = 1;
            DateTime coto = new DateTime();
            DateTime cofrom = new DateTime();
            string codate = "", payrollgroupid = "";
            //List<string> employeeIds = getEmployeeIDs();
            getCutoffRange(cutoff_id, out codate, out cofrom, out coto, out payrollgroupid);
        List<string> employeeIds = new List<string>();
        if (empnum == "")
            {
            //cm.DeleteQuery("TBL_DTSAE", "where CutOffID = " + cutoff_id + "");
            employeeIds = getEmployeeIDs1("AND emp_PayrollGroup = " + payrollgroupid + "");
            }
            else
            {
                employeeIds.Add(empnum);
                //cm.DeleteQuery("TBL_DTSAE", "where EmpID = '" + empnum + "' AND CutoffID = " + cutoff_id + "");
            }
        foreach (string empno in employeeIds)
            {
            if (!(payrollgroupid == cm.GetSpecificDataFromDB("emp_PayrollGroup", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + empno + "'")))
                continue;   //dont merge if not included in the payroll group
                for (DateTime date = cofrom; date.Date <= coto.Date; date = date.AddDays(1))
                {
                    Dictionary<string, string> empSchedInfo = new Dictionary<string, string>();
                try
                {
                    conn = new SqlConnection(connectionstring);
                    conn.Open();
                    get_emp_info(empno, date, out empSchedInfo, false);
                }
                finally
                {
                    conn.Close();
                }
                //Check if holiday
                string holidaydesc = "";
                    string holidaytype = "";
                bool isdoublelh = false;
                if (IsDateHoliday(empno,date, out holidaydesc,out holidaytype, out isdoublelh))
                    {
                        InsertDTSHoliday(date, empno, empSchedInfo, holidaydesc,holidaytype, codate, cutoff_id, isdoublelh);
                    continue;
                    }
                    //Checking of filed Leave
                    string leave_reason = "", leavekey = "", ampm = "", leavehours = "";//05/27/2022 Jan Wong. change ampm to leavehours
                string obt_reason = "";
                string obttimein = "", obttimeout = "";
                string fts_reason = "";
                    DataTable DTR_DT = new DataTable();
                    int leavetypeID = -1;
                //if (HasFiledLeave(date, empno, out leave_reason, out leavetypeID))
                //{
                //    InsertDTSLeave(date, empno, leave_reason, empSchedInfo, codate, cutoff_id, leavetypeID);
                //}

                if (HasFiledLeave(date, empno, empSchedInfo, out leave_reason, out leavetypeID, out leavekey, out ampm, out leavehours))
                {
                    InsertDTSLeave(date, empno, leave_reason, empSchedInfo, codate, cutoff_id, leavetypeID, leavekey, ampm, leavehours);
                }
                //if (HasFiledLeave1(date, empno, empSchedInfo, out leave_reason, out leavetypeID, out leavekey))
                //{
                //    //InsertDTSLeave(date, empno, leave_reason, empSchedInfo, codate, cutoff_id, leavetypeID, leavekey, ampm);
                //    InsertDTSLeave1(date, empno, leave_reason, empSchedInfo, codate, cutoff_id, leavetypeID, leavekey);
                //}
                else if (HasFiledOBT(date, empno, out obt_reason, out obttimein, out obttimeout))
                        InsertDTSOBT(date, empno, leave_reason, empSchedInfo, codate, cutoff_id, obttimein, obttimeout);

                //Checking of filed FTS
                    
                    else if (HasFiledFTS(date, empno, out fts_reason,out ftstimeinout, out ftstype))
                    InsertDTSFTS(date, empno, fts_reason, empSchedInfo, codate, cutoff_id);
                //InsertDTSFTS(date, empno, fts_reason, empSchedInfo, codate, cutoff_id, ftstimeinout, ftstype);

                    //Check on DTR

                    else if (HasFiledTIME_IN_OUT(date, empno, out DTR_DT))
                        InsertDTSfromDTR(DTR_DT, codate, cutoff_id,empSchedInfo);
                else
                {
                    Dictionary<string, string> empSchedInfo_1 = new Dictionary<string, string>();
                    conn.Open();
                    get_emp_info(empno, date, out empSchedInfo_1, false);
                    conn.Close();
                    InsertDTSNOEntry(date, empno, "ABS", empSchedInfo_1, codate, cutoff_id);
                    
                }
                if (HasFiledSuspension(date, empno))
                {
                    InsertDTSSuspension(date, empno, empSchedInfo, codate, cutoff_id);
                }
            }
        }


            conn.Close();   //make sure to close connection though this is a bad design
            return valid;

        }
    bool HasFiledLeave1(DateTime date, string empno, Dictionary<string, string> _empinfo, out string reason, out int leavetypeID, out string leavekey)
    {
        bool HasLeave = false;
        leavetypeID = -1;
        leavekey = "";
        reason = "";
        string schedIn = ""; string schedOut = "";
        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand("Select * from TBL_LEAVESAPP where LeaveStatus = '1' and EmpID = '" + empno + "' and '" + date.ToString("yyyy-MM-dd") + "' BETWEEN TBL_LEAVESAPP.DateFrom AND TBL_LEAVESAPP.DateTo", conn);
        //cmd = new SqlCommand("Select * from TBL_LEAVESAPP where LeaveStatus = '1' and EmpID = '" + empno + "' and TBL_LEAVESAPP.DateFrom = '" + date.ToString("yyyy-MM-dd") + "'", conn);
        dread = cmd.ExecuteReader();
        dread.Read();
        if (dread.HasRows)
        {
            //leavekey = cm.GetSpecificDataFromDB("LeaveKey", "TBL_LEAVETYPE", "where id = " + dread["LeaveType"].ToString() + "");
            leavekey = dread["LeaveKey"].ToString();
            reason = dread["Reason"].ToString();
            leavetypeID = int.Parse(dread["LeaveType"].ToString());
            if (_empinfo.Count > 3 && _empinfo.ContainsKey("Sched_TimeIn") && _empinfo.ContainsKey("Sched_TimeOut"))
            {
                schedIn = _empinfo["Sched_TimeIn"];
                schedOut = _empinfo["Sched_TimeOut"];
                if (schedIn != "RD" && schedOut != "RD")
                    HasLeave = true;
                else
                    HasLeave = false;


            }

        }
        dread.Close();
        conn.Close();

        return HasLeave;
    }
    void InsertDTSLeave(DateTime date, string empno, string reason, Dictionary<string, string> _empinfo, string codate, string CutoffID, int leavetypeID, string leavekey)
    {
        //I CHANGE REASON TO LEAVEKEY
        Dictionary<string, string> param = new Dictionary<string, string>();

        DateTime dtTryparse;
        string bussdate = date.ToString("yyyy-MM-dd");
        string sched_TimeIn = "";
        string sched_TimeOut = "";

        if (_empinfo.Count > 1 && _empinfo.ContainsKey("Sched_TimeIn") && _empinfo.ContainsKey("Sched_TimeOut"))
        {
            sched_TimeIn = _empinfo["Sched_TimeIn"];
            sched_TimeOut = _empinfo["Sched_TimeOut"];

        }
        //bool tryDt;
        param.Clear();
        //DateTime DbussDate = DateTime.Parse(dr["BussDate"].ToString());
        //string bussdate = DbussDate.ToString("yyyy-MM-dd");
        //string insertDateIn = DateTime.Parse(dr["DateIn"].ToString()).ToString("yyyy-MM-dd");
        //tryDt = DateTime.TryParse(dr["DateIn"].ToString(), out dtTryparse);
        //string insertDateOut = dtTryparse.ToString("yyyy-MM-dd");
        //bool noOut = false;
        //if (dr["DateOut"].ToString() == null || dr["DateOut"].ToString() == "")
        //    noOut = true;
        param.Add("BussDate", "'" + bussdate + "'");
        param.Add("BussDate2", "'" + bussdate + "'");
        param.Add("ShiftName", "'" + get_shiftname(empno, date) + "'");
        param.Add("EndDate", "'" + bussdate + "'");
        //param.Add("DateIn","'"+insertDateIn+"'");
        //param.Add("DateOut","'"+insertDateOut+"'");
        param.Add("EmpID", "'" + empno + "'");
        param.Add("Emp_Name", "'" + _empinfo["emp_FullName"] + "'");
        //param.Add("AssignmentCode","'"++"'");
        param.Add("Sched_TimeIn", "'" + sched_TimeIn + "'");
        param.Add("Sched_TimeOut", "'" + sched_TimeOut + "'");
        //param.Add("Sched_RestDay","'"+dr["Sched_RestDay"].ToString()+"'");
        //param.Add("DTimeIn","'"+dr["DTimeIn"].ToString()+"'");
        //param.Add("DTimeOut","'"+dr["DTimeOut"].ToString()+"'");

        //if (!noOut)
        //{
        //    string strdtin = dr["DateIn"].ToString();
        //    string strdtout = dr["DateOut"].ToString();
        //    TimeSpan timein = TimeSpan.Parse(dr["DTimeIn"].ToString());
        //    TimeSpan timeout = TimeSpan.Parse(dr["DTimeOut"].ToString());
        //    DateTime dt = DateTime.Parse(strdtin) + timein;
        //    DateTime dtout = DateTime.Parse(strdtout) + timeout;
        //    double totalhrs = (dtout - dt).TotalHours;
        //    param.Add("TotHrs", "" + Math.Round(totalhrs, 0) + "");
        //}
        //else
        //    param.Add("TotHrs", "0");

        double manhrs = cm.get_Time_Difference(sched_TimeIn, sched_TimeOut);
        param.Add("ManHrs", "" + Math.Round(manhrs, 0) + "");
        param.Add("PayPeriod", "'" + codate + "'");
        //param.Add("Remarks", (noOut? "'NO OUT'":"'WRK'"));
        param.Add("ActivityCode", "'" + empno + "'");
        param.Add("ActivityName", "'" + _empinfo["emp_FullName"] + "'");
        
        param.Add("Reason", "'" + reason + "'");
        param.Add("Remarks", "'" + leavekey + "'");
        

        param.Add("DDayName", "'" + date.ToString("dddd") + " REG'");
        //param.Add("Submit", "'N'");
        param.Add("Submit", "'Y'");
        param.Add("CutoffID", CutoffID);
        param.Add("allowance", "0");
        param.Add("DAbsent", "1");
        //if (leavetypeID == 5 || leavetypeID == 7)
        //    param.Add("LWOP", "1");
        //else if (leavetypeID == -1)
        //    goto PROCEED;
        //else
        //    param.Add("LWP", "1");
        #region old
        //if (leavekey == "PLWOP" || leavekey == "SLWOP")
        //{
        //    param.Add("LWOP", "1");
        //}
        //else
        //{
        //    param.Add("LWP", "1");
        //}
        #endregion old
        if (leavekey == "SLWOP" || leavekey == "LWOP" || leavekey == "MTWOP"
            || leavekey == "PTWOP")
        {
            param.Add("LWOP", "1");
        }
        else
        {
            param.Add("LWP", "1");
        }
    /*
     * 
     * 
     * 
     * 
     * */
    PROCEED:
        if (!HasDuplicate_DTS_Entry(empno, bussdate, CutoffID))
        {
            if (!(InsertQueryCommon(param, "TBL_DTSAE")))
                Console.WriteLine("Failed InsertDTSLeave()");
        }
        else
        {
            UpdateDTSEntryParam(param, out param);
            cm.UpdateQueryCommon(param, "TBL_DTSAE", "BussDate = '" + bussdate + "' and CutoffID = " + CutoffID + " and EmpID = '" + empno + "' ");
        }
            


    }
    void InsertDTSLeave(DateTime date, string empno, string reason, Dictionary<string, string> _empinfo, string codate, string CutoffID, int leavetypeID, string leavekey, string ampm,string strleavehours)
    {
        //I CHANGE REASON TO LEAVEKEY
        Dictionary<string, string> param = new Dictionary<string, string>();
        //05/27/2022 Jan Wong
        double leavehours = 0;
        if(!double.TryParse(strleavehours, out leavehours))
        {
            if (ampm == "DAY")
            {
                leavehours = 8;
            }
            else if (ampm == "AM" || ampm == "PM" || ampm == "")
            {
                leavehours = 4;
            }
        }
        else
        {
            double.TryParse(strleavehours, out leavehours);
        }
        //05/27/2022 Jan Wong END
        DateTime dtTryparse;
        string bussdate = date.ToString("yyyy-MM-dd");
        string sched_TimeIn = "";
        string sched_TimeOut = "";
        string dabsent = "1";

        if (_empinfo.Count > 1)
        {
            sched_TimeIn = _empinfo["Sched_TimeIn"];
            sched_TimeOut = _empinfo["Sched_TimeOut"];

        }
        //bool tryDt;
        param.Clear();
        //DateTime DbussDate = DateTime.Parse(dr["BussDate"].ToString());
        //string bussdate = DbussDate.ToString("yyyy-MM-dd");
        //string insertDateIn = DateTime.Parse(dr["DateIn"].ToString()).ToString("yyyy-MM-dd");
        //tryDt = DateTime.TryParse(dr["DateIn"].ToString(), out dtTryparse);
        //string insertDateOut = dtTryparse.ToString("yyyy-MM-dd");
        //bool noOut = false;
        //if (dr["DateOut"].ToString() == null || dr["DateOut"].ToString() == "")
        //    noOut = true;
        param.Add("BussDate", "'" + bussdate + "'");
        param.Add("BussDate2", "'" + bussdate + "'");
        param.Add("ShiftName", "'" + get_shiftname(empno, date) + "'");
        param.Add("EndDate", "'" + bussdate + "'");
        //param.Add("DateIn","'"+insertDateIn+"'");
        //param.Add("DateOut","'"+insertDateOut+"'");
        param.Add("EmpID", "'" + empno + "'");
        param.Add("Emp_Name", "'" + _empinfo["emp_FullName"] + "'");
        //param.Add("AssignmentCode","'"++"'");
        param.Add("Sched_TimeIn", "'" + sched_TimeIn + "'");
        param.Add("Sched_TimeOut", "'" + sched_TimeOut + "'");
        double manhrs = cm.get_Time_Difference(sched_TimeIn, sched_TimeOut);
        param.Add("ManHrs", "" + Math.Round(manhrs, 0) + "");
        param.Add("PayPeriod", "'" + codate + "'");
        //param.Add("Remarks", (noOut? "'NO OUT'":"'WRK'"));
        param.Add("ActivityCode", "'" + empno + "'");
        param.Add("ActivityName", "'" + _empinfo["emp_FullName"] + "'");
        //checking for holiday
        string holidaydesc = "";
        string holidaytype = "";
        if (IsDateHoliday(empno, date, out holidaytype))
        {
            DateTime dateplusone = date.AddDays(1);
            DateTime dateminusone = date.AddDays(-1);
            if (holidaytype == "LH")
            {
                //if (HasFiledTIME_IN_OUT(dateplusone, empno) || HasFiledTIME_IN_OUT(dateminusone, empno))
                //{
                    param.Add("Reason", "'" + cm.replaceSingleQuote(reason) + "'");
                    param.Add("Remarks", "'" + holidaytype + leavekey + "'");
                //}
                //else
                //{
                //    //holidaytype = holidaytype + "WOP";
                //    //param.Add("Reason", "'" + reason + "'");
                //    //param.Add("Remarks", "'" + holidaytype + leavekey + "'");
                //    param.Add("Reason", "'" + cm.replaceSingleQuote(reason) + "'");
                //    param.Add("Remarks", "'" + leavekey + "'");
                //}

            }
            else
            {

                param.Add("Reason", "'" + cm.replaceSingleQuote(reason) + "'");
                param.Add("Remarks", "'" + leavekey + "'");
            }

        }
        //else
        //{

        //    param.Add("Reason", "'" + cm.replaceSingleQuote(reason) + "'");
        //    param.Add("Remarks", "'" + leavekey + "'");
        //}

        param.Add("DDayName", "'" + date.ToString("dddd") + " REG'");
        //param.Add("Submit", "'N'");
        param.Add("Submit", "'Y'");
        param.Add("CutoffID", CutoffID);
        param.Add("allowance", "0");


        if (leavekey == "SLWOP" || leavekey == "LWOP" || leavekey == "MTWOP"
            || leavekey == "PTWOP")
        {

            if (ampm == "DAY" || ampm == "")
            {
                dabsent = "1";
                //param.Add("DAbsent", "1");
                param.Add("LWOP", "1");

            }
            else
            {
                string obtreason = "", obttimeout = "", obttimein = "";
                DataTable DTR_DT = new DataTable();
                string uareason = "", uain = "", uaout = "", ualunchin = "", ualunchout = "";
                var formats = new string[] { "hh:mmtt", "HH:mm", "HH:mm:ss", "H:mm", "h:mm tt", "h:mmtt", "h:mm TT", "h:mmTT" };
                if (HasFiledOBT(date, empno, out obtreason, out obttimein, out obttimeout))
                {
                    DateTime obtin = new DateTime();
                    DateTime obtout = new DateTime();

                    obtin = DateTime.ParseExact(obttimein, formats, CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
                    obtout = DateTime.ParseExact(obttimeout, formats, CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
                    TimeSpan tsIn = obtin.TimeOfDay;
                    TimeSpan tsOut = obtout.TimeOfDay;
                    param.Add("DTimeIn", "'" + tsIn + "'");
                    param.Add("DTimeOut", "'" + tsOut + "'");
                    param.Add("DateIn", "'" + bussdate + "'");
                    param.Add("DateOut", "'" + bussdate + "'");
                    dabsent = "0";
                    //dabsent = "0.5";
                    leavekey += "WRK";


                }
                else if (HasFiledTIME_IN_OUT(date, empno, out DTR_DT))
                {
                    foreach (DataRow dr in DTR_DT.Rows)
                    {
                        bool noOut = false;
                        //bool noLunchInOut = false;
                        //if (dr["LunchIn"].ToString() == null || dr["LunchIn"].ToString() == "" || dr["LunchOut"].ToString() == null || dr["LunchOut"].ToString() == "")
                        //    noLunchInOut = true;
                        if (dr["DTimeIn"].ToString() == null || dr["DTimeIn"].ToString() == "" || dr["DTimeOut"].ToString() == null || dr["DTimeOut"].ToString() == "")
                            noOut = true;
                        if (dr["DTimeIn"].ToString() == "" || dr["DTimeIn"].ToString() == null)
                            noOut = true;
                        if (!noOut)
                        {
                            param.Add("DateIn", "'" + bussdate + "'");
                            param.Add("DateOut", "'" + bussdate + "'");
                            param.Add("DTimeIn", "'" + dr["DTimeIn"].ToString() + "'");
                            param.Add("DTimeOut", "'" + dr["DTimeOut"].ToString() + "'");

                        }
                        //if (!noLunchInOut)
                        //{
                        //    param.Add("LunchOut", "'" + dr["LunchOut"].ToString() + "'");
                        //    param.Add("LunchIn", "'" + dr["LunchIn"].ToString() + "'");
                        //}
                        if (!noOut)
                        {
                            dabsent = "0";
                            //dabsent = "0.5";
                            leavekey += "WRK";
                        }
                        

                    }

                }
                else if (HasFiledFTS(date, empno, out uareason, out uain, out uaout, out ualunchout, out ualunchin))
                {
                    DateTime bussIn = DateTime.ParseExact(uain, formats, CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
                    DateTime bussOut = DateTime.ParseExact(uaout, formats, CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
                    TimeSpan tsIn = bussIn.TimeOfDay;
                    TimeSpan tsOut = bussOut.TimeOfDay;
                    param.Add("DTimeIn", "'" + tsIn + "'");
                    param.Add("DTimeOut", "'" + tsOut + "'");
                    param.Add("DateIn", "'" + bussdate + "'");
                    param.Add("DateOut", "'" + bussdate + "'");
                    //dabsent = "0";
                    //dabsent = "0.5";
                    leavekey += "WRK";
                }
            }
        }
        else
        {
            if (ampm == "DAY" || ampm == "")
            {
                //param.Add("DAbsent", "1");
                dabsent = "1";
                //param.Add("LWP", "1");
                param.Add("LWP", leavehours.ToString());//05/27/2022 Jan Wong.

            }
            else
            {
                string obtreason = "", obttimeout = "", obttimein = "";
                DataTable DTR_DT = new DataTable();
                string uareason = "", uain = "", uaout = "", ualunchin = "", ualunchout = "";
                var formats = new string[] { "hh:mmtt", "HH:mm", "HH:mm:ss", "H:mm", "h:mm tt", "h:mmtt", "h:mm TT", "h:mmTT" };
                if (HasFiledOBT(date, empno, out obtreason, out obttimein, out obttimeout))
                {
                    DateTime obtin = new DateTime();
                    DateTime obtout = new DateTime();

                    obtin = DateTime.ParseExact(uain, formats, CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
                    obtout = DateTime.ParseExact(uaout, formats, CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
                    TimeSpan tsIn = obtin.TimeOfDay;
                    TimeSpan tsOut = obtout.TimeOfDay;
                    param.Add("DTimeIn", "'" + tsIn + "'");
                    param.Add("DTimeOut", "'" + tsOut + "'");
                    param.Add("DateIn", "'" + bussdate + "'");
                    param.Add("DateOut", "'" + bussdate + "'");
                    dabsent = "0";


                }
                else if (HasFiledTIME_IN_OUT(date, empno, out DTR_DT))
                {
                    foreach (DataRow dr in DTR_DT.Rows)
                    {
                        bool noOut = false;
                        //bool noLunchInOut = false;
                        //if (dr["LunchIn"].ToString() == null || dr["LunchIn"].ToString() == "" || dr["LunchOut"].ToString() == null || dr["LunchOut"].ToString() == "")
                        //    noLunchInOut = true;
                        if (dr["DTimeIn"].ToString() == null || dr["DTimeIn"].ToString() == "" || dr["DTimeOut"].ToString() == null || dr["DTimeOut"].ToString() == "")
                            noOut = true;
                        if (dr["DTimeIn"].ToString() == "" || dr["DTimeIn"].ToString() == null)
                            noOut = true;
                        if (!noOut)
                        {
                            param.Add("DateIn", "'" + bussdate + "'");
                            param.Add("DateOut", "'" + bussdate + "'");
                            param.Add("DTimeIn", "'" + dr["DTimeIn"].ToString() + "'");
                            param.Add("DTimeOut", "'" + dr["DTimeOut"].ToString() + "'");

                        }
                        if (!noOut)
                        {
                            dabsent = "0";
                            //dabsent = "0.5";
                            leavekey += "WRK";
                        }
                        else if(ampm == "PM")
                        {
                            dabsent = "0";
                            param.Add("Lates", "4");
                            param.Add("Latesmin", "240");
                        }
                        else if (ampm == "AM")
                        {
                            dabsent = "0";
                            param.Add("UT", "4");
                            param.Add("UTmin", "240");
                        }

                    }

                }
                else if (HasFiledFTS(date, empno, out uareason, out uain, out uaout, out ualunchout, out ualunchin))
                {
                    DateTime bussIn = DateTime.ParseExact(uain, formats, CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
                    DateTime bussOut = DateTime.ParseExact(uaout, formats, CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
                    TimeSpan tsIn = bussIn.TimeOfDay;
                    TimeSpan tsOut = bussOut.TimeOfDay;
                    param.Add("DTimeIn", "'" + tsIn + "'");
                    param.Add("DTimeOut", "'" + tsOut + "'");
                    param.Add("DateIn", "'" + bussdate + "'");
                    param.Add("DateOut", "'" + bussdate + "'");
                    dabsent = "0";
                }
                //param.Add("LWP", "0.5");
                param.Add("LWP", leavehours.ToString());//05/27/2022 Jan Wong.
            }

        }

        param.Add("DAbsent", dabsent);
        //param.Add("LWOP", "0.5");

        param.Add("Reason", "'" + cm.replaceSingleQuote(reason) + "'");
        param.Add("Remarks", "'" + leavekey + "'");
    PROCEED:
        if (!HasDuplicate_DTS_Entry(empno, bussdate, CutoffID))
        {
            if (!(InsertQueryCommon(param, "TBL_DTSAE")))
                Console.WriteLine("Failed InsertDTSLeave()");
        }
        else
        {
            UpdateDTSEntryParam(param, out param);
            cm.UpdateQueryCommon(param, "TBL_DTSAE", "BussDate = '" + bussdate + "' and CutoffID = " + CutoffID + " and EmpID = '" + empno + "' ");
        }


    }
    
    public bool computeData(string cutoff_id, string empnum, out int ret)
        {
        conn.Close();
        bool valid = true;
            ret = 1;
            DateTime coto = new DateTime();
            DateTime cofrom = new DateTime();
            string codate = "", payrollgroupid = "";
            //List<string> employeeIds = getEmployeeIDs();
            getCutoffRange(cutoff_id, out codate, out cofrom, out coto, out payrollgroupid);
            List<string> employeeIds = new List<string>();
            if (empnum == "")
            {
                employeeIds = getEmployeeIDs1("AND emp_PayrollGroup = " + payrollgroupid + "");
            }
            else
            {
                employeeIds.Add(empnum);
            }
        foreach (string empno in employeeIds)
            {
            if (!(payrollgroupid == cm.GetSpecificDataFromDB("emp_PayrollGroup", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + empno + "'")))
                continue;
            for (DateTime date = cofrom; date.Date <= coto.Date; date = date.AddDays(1))
                {
                    Dictionary<string, string> param = new Dictionary<string, string>();
                    Dictionary<string, string> empSchedInfo = new Dictionary<string, string>();
                    Dictionary<string, string> dtsInfo = new Dictionary<string, string>();
                    conn = new SqlConnection(connectionstring);
                    conn.Open();
                    get_emp_info(empno, date, out empSchedInfo, false);
                    conn.Close();

                    get_dts_info(empno, date, out dtsInfo);
                    if (dtsInfo.Count < 1)
                        continue;
                    bool IsOverTime = false;
                bool isdoublh = dtsInfo["Remarks"].Contains("DOUB");
                    param = compute_Work_Hours(dtsInfo, param, date, out IsOverTime);
                if(dtsInfo["Remarks"].Contains("WRK") || dtsInfo["Remarks"].Contains("OBT") || dtsInfo["Remarks"].Contains("UA") || dtsInfo["Remarks"].Contains("RDP") || dtsInfo["Remarks"].Contains("RDRP"))
                {
                    // esmon commendted out - error on compiling - common does not have this object.
                    //if (cm.IsValidTimeFormat(dtsInfo["DTimeIn"]) && !cm.IsValidTimeFormat(dtsInfo["DTimeOut"]))
                    //e{
                    //e    if (!param.ContainsKey("Remarks")) param.Add("Remarks", "'NO'");
                    //e    if (!param.ContainsKey("Reason")) param.Add("Reason", "'NO'");
                    //e}
                }
                    if (!IsOverTime)
                        goto EXIT_LOOP;

                    //Check if restday
                    if (IsDateRD(date, empno, empSchedInfo, codate))
                    {
                        param = UpdateDTSRestDay(date, dtsInfo, param, isdoublh);
                        goto EXIT_LOOP;
                    }
                    //Check if holiday
                    string holidaytype = "";
                    if (IsDateHoliday(empno, date, out holidaytype))
                    {
                        param = UpdateDTSHoliday(date, dtsInfo, param, holidaytype, isdoublh);
                        goto EXIT_LOOP;
                        //InsertDTSHoliday(date, empno, empSchedInfo, holidaydesc, codate);
                    }

                    //Regular day
                    param = UpdateDTSReg(date, dtsInfo, param, isdoublh);

                EXIT_LOOP:
                    cm.UpdateQueryCommon(param, "TBL_DTSAE", " EmpID = '" + empno + "' and BussDate = '" + date.ToString("yyyy-MM-dd") + "'");

                }
            }



            return valid;

        }

        public bool createSummary(string cutoff_id, string empnum, out int ret)
        {
            bool valid = false;
            bool tempvalid = false;
            string codate = "";
        //getCutoffRange(cutoff_id, out codate, out cofrom, out coto);
        //getCutoffRange(cutoff_id, out codate);
        DateTime coto = new DateTime();
        DateTime cofrom = new DateTime();
        string payrollgroupid = "";
        getCutoffRange(cutoff_id, out codate, out cofrom, out coto, out payrollgroupid);
            //List<string> employeeIds = getEmployeeIDs1("AND emp_PayrollGroup = " + payrollgroupid + "");
        List<string> employeeIds = new List<string>();
        if (empnum == "")
        {
            //cm.DeleteQuery("TBL_PAYROLLSUM", "where CutOffID = " + cutoff_id + "");
            employeeIds = getEmployeeIDs1("AND emp_PayrollGroup = " + payrollgroupid + "");
        }
        else
        {
            //cm.DeleteQuery("TBL_PAYROLLSUM", "where EmpID = '" + empnum + "'");
            employeeIds.Add(empnum);
        }
        ret = 1;

            foreach (string empno in employeeIds)
            {
                conn = new SqlConnection(connectionstring);
                conn.Open();
                string qry = "";
            string qry_not_in_use = "";
            #region summary string query
            qry = "Select EmpID as 'empid', Submit as 'Submit', Emp_Name as 'PSname', PayPeriod as 'CODate', SUM(ManHrs) as 'ManHrs', " +
                    //"SUM(ManHrs)/8 as 'PSDays', " +
                    "SUM(ManHrs)/9 as 'PSDays', " +
                    "SUM(TotHrs) as 'TotHrs', " +
                "SUM(TotHrs)/8 as 'ActualTotalDays', " +    //Based from the Total hours worked
                    "SUM(OTReg) as 'OTReg', " +
                    "SUM(RegOT) as 'RegOT', " +
                    "SUM(RegOTND) as 'RegOTND', " +
                    "SUM(OTRegWND) as 'OTRegWND', " +
                    "SUM(LHOT) as 'LHOT', " +
                    "SUM(LHOT8HRS) as 'LHOT8HRS', " +
                    "SUM(LHOTND) as 'LHOTND', " +
                    "SUM(SHOT) as 'SHOT', " +
                    "SUM(SHOT8HRS) as 'SHOT8HRS', " +
                    "SUM(SHOTND) as 'SHOTND', " +
                    "SUM(RDOT) as 'RDOT', " +
                    "SUM(RDOT8HRS) as 'RDOT8HRS', " +
                    "SUM(RDOTND) as 'RDOTND', " +
                    "SUM(RDLHOT) as 'RDLHOT', " +
                    "SUM(RDLHOT8HRS) as 'RDLHOT8HRS', " +
                    "SUM(RDLHOTND) as 'RDLHOTND', " +
                    "SUM(RDSHOT) as 'RDSHOT', " +
                    "SUM(RDSHOT8HRS) as 'RDSHOT8HRS', " +
                    "SUM(RDSHOTND) as 'RDSHOTND', " +
                    "SUM(DAbsent) as 'PSabsent', " +
                    "SUM(UTmin) as 'UTmin', " +
                    "SUM(Latesmin) as 'Latesmin', " +
                    "SUM(CASE WHEN Latesmin > 0  THEN 1 END) as 'LateCount', " +
                    "SUM(CASE WHEN UTmin > 0  THEN 1 END) as 'UnderTimeCount', " +
                    "Count(id) as 'RegDays', " +
                    "SUM(LWP) as 'LWP', " +
                    "SUM(LWOP) as 'LWOP', " + 
                    "SUM(CASE WHEN  ((Remarks LIKE '%OBT%' or Remarks LIKE '%WRK%' or Remarks LIKE '%ABS%' or Remarks LIKE '%SL%' or Remarks LIKE '%VL%') AND Remarks NOT LIKE '%SH%' AND Remarks NOT LIKE '%LH%') THEN 1 END) as 'NumberDaysWorked', " +
                    "SUM(CASE WHEN  (Remarks LIKE '%OBT%' or Remarks LIKE '%WRK%' or Remarks LIKE '%ABS%' or Remarks LIKE '%SL%' or Remarks LIKE '%VL%') then 1 end ) as 'NumberDaysWorkedWHoliday', " +
                    "SUM(DOUBLEGOT) as 'DOUBLEGOT',  " +
                    "SUM(DOUBRSTOT) as 'DOUBRSTOT',  " +
                    "SUM(DOUBLEGNDOT) as 'DOUBLEGNDOT',  " +
                    "SUM(DOUBRSTNDOT) as 'DOUBRSTNDOT'  " +
                    //"SUM(RegNDHrs) as 'RegNDHrs'  " +
                    //") AND Remarks not like '%WOP%') THEN 1 END) as 'NumberDaysWorked' " +
                    "from TBL_DTSAE where EmpID = '" + empno + "' and PayPeriod = '" + codate + "' and CutoffID = " + cutoff_id + " and (Remarks LIKE '%RDP%' or Remarks LIKE '%WRK%' or Remarks LIKE '%ABS%' " +
                    "or Remarks LIKE '%VL%' or Remarks LIKE '%SL%' or Remarks LIKE '%MT%' or Remarks LIKE '%PT%' or Remarks LIKE '%UT%' " +
                    "or Remarks LIKE '%OTH%' or Remarks LIKE '%OBT%')" +
                    "group by EmpID, Submit, Emp_Name, PayPeriod";
            #endregion summary string query
            cmd = new SqlCommand(qry, conn);
                var reader = cmd.ExecuteReader();
                Dictionary<string, string> tempParam = new Dictionary<string, string>();
                while (reader.Read())
                {
                    if (reader["Submit"].ToString() == "N")
                        continue;

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        double val = 0;
                        string inputval = "";
                        if (reader[i].ToString() == "" || reader.GetName(i) == "Submit")
                            continue;
                        else if (double.TryParse(reader[i].ToString(), out val) && reader.GetName(i) != "empid")
                            inputval = reader[i].ToString();
                        else
                            inputval = "'" + reader[i].ToString() + "'";


                        tempParam.Add(reader.GetName(i), inputval);
                    }
                }
                conn.Close(); //ensure the connection is closed.
                tempParam.Add("CutoffID", cutoff_id);
                if (!HasDuplicate_Summary_Entry(empno, cutoff_id))
                    valid = cm.InsertQueryCommon(tempParam, "TBL_PAYROLLSUM");
            else
                valid = cm.UpdateQueryCommon(tempParam, "TBL_PAYROLLSUM", "   CutoffID = " + cutoff_id + " and empid = '" + empno + "' ");
            if (valid == true)
                    tempvalid = true;
                conn.Close();
            }











            valid = tempvalid;
            return valid;
        }

        public bool checkDate(string _timeIn, string _dateIn, string _timeOut, string _dateOut)
        {
            bool valid = false;
            DateTime dateTime3pm = DateTime.ParseExact("03:00:00",
                                    "hh:mm:ss", CultureInfo.InvariantCulture);
            DateTime dateTimeIn = Convert.ToDateTime(_dateIn + " " + _timeIn);
            DateTime nextDay = dateTimeIn.Date.AddDays(1);
            DateTime dateTimeOut = Convert.ToDateTime(_dateOut + " " + _timeOut);
            int i = TimeSpan.Compare(dateTimeOut.TimeOfDay, dateTime3pm.TimeOfDay);
            if (nextDay == dateTimeOut.Date)
            {
                if (dateTimeOut.Hour <= 3)
                    return true;
            }
            if (dateTimeIn.Date == dateTimeOut.Date && dateTimeIn < dateTimeOut)
                return true;


            return valid;

        }
        public bool get_emp_info(string empno, DateTime bussdate, out Dictionary<string, string> empinfo)
        {
            return get_emp_info(empno, bussdate, out empinfo, false);

        }
    public bool get_emp_info(string empno, DateTime bussdate, out Dictionary<string, string> empinfo, bool isforDTS)
    {
            empinfo = new Dictionary<string, string>();
            //IsEmpIncluded = false;
            bool IsEmpIncluded = false;//for testing only
        bool IsPioneer = false;
        int schedID = 0;
            cmd = new SqlCommand("Select * from TBL_EMPLOYEE_MASTER where emp_EmpID = '" + empno + "'", conn);
            dread = cmd.ExecuteReader();
            dread.Read();
            if (dread.HasRows)
            {
            string test = dread["emp_IsPioneer"].ToString();
            IsPioneer = dread["emp_IsPioneer"].ToString() == "True" ? true : false;
                empinfo.Add("emp_FullName", dread["emp_FullName"].ToString());
                empinfo.Add("emp_PayrollGroup", dread["emp_PayrollGroup"].ToString());
            //empinfo.Add("emp_IsPioneer", dread["emp_IsPioneer"].ToString());
            empinfo.Add("emp_Location", dread["emp_Location"].ToString());
            schedID = int.Parse(dread[get_buss_day(bussdate)].ToString());
                IsEmpIncluded = true;
            }
            dread.Close();
        if (isforDTS)
            {
            string strschedtimein = ""; string strschedtimeout = "";
            if (cm.ItemExist("TBL_FLEXISCHED", "id", "where EmpID = '" + empno + "' AND BussDate = '" + cm.FormatDate(bussdate) + "'"))
            {
                cm.GetTwoDataFromDB("Sched_TimeIn", "Sched_TimeOut", "TBL_FLEXISCHED", "where EmpID = '" + empno + "' AND BussDate = '" + cm.FormatDate(bussdate) + "'", out strschedtimein, out strschedtimeout);
                empinfo.Add("Sched_TimeIn", strschedtimein);
                empinfo.Add("Sched_TimeOut", strschedtimeout);
                goto EXITRET;
            }
            cmd = new SqlCommand("Select * from TBL_DTR where BussDate = '" + cm.FormatDate(bussdate) + "' and EmpID = '" + empno + "'", conn);
            
            dread = cmd.ExecuteReader();
                dread.Read();
                if (dread.HasRows)
                {
                    empinfo.Add("Sched_TimeIn", dread["Sched_TimeIn"].ToString());
                    empinfo.Add("Sched_TimeOut", dread["Sched_TimeOut"].ToString());
                }
                else
                {
                    dread.Close();
                    cmd = new SqlCommand("Select * from TBL_SCHEDULE where id = " + schedID + "", conn);
                    dread = cmd.ExecuteReader();
                    dread.Read();
                    if (dread.HasRows)
                    {
                        empinfo.Add("Sched_TimeIn", dread["Sched_TimeIn"].ToString());
                        empinfo.Add("Sched_TimeOut", dread["Sched_TimeOut"].ToString());
                    }
                    dread.Close();
                }

            dread.Close();
            }
            else
            {
            string strschedtimein = ""; string strschedtimeout = "";
            if (cm.ItemExist("TBL_FLEXISCHED", "id", "where EmpID = '" + empno + "' AND BussDate = '" + cm.FormatDate(bussdate) + "'"))
            {
                cm.GetTwoDataFromDB("Sched_TimeIn", "Sched_TimeOut", "TBL_FLEXISCHED", "where EmpID = '" + empno + "' AND BussDate = '" + cm.FormatDate(bussdate) + "'", out strschedtimein, out strschedtimeout);
                empinfo.Add("Sched_TimeIn", strschedtimein);
                empinfo.Add("Sched_TimeOut", strschedtimeout);
                goto EXITRET;
            }

            cmd = new SqlCommand("Select * from TBL_SCHEDULE where id = " + schedID + "", conn);
                dread = cmd.ExecuteReader();
                dread.Read();
                if (dread.HasRows)
                {
                    empinfo.Add("Sched_TimeIn", dread["Sched_TimeIn"].ToString());
                    empinfo.Add("Sched_TimeOut", dread["Sched_TimeOut"].ToString());
                }
                dread.Close();
            }

    EXITRET:
        
        empinfo.Add("emp_IsPioneer", IsPioneer ?  "True" : "False");
        empinfo.Add("schedID", schedID.ToString());
            return IsEmpIncluded;
        }
    public bool get_emp_info_with_conn(string empno, DateTime bussdate, out Dictionary<string, string> empinfo, bool isforDTS)
    {
        try
        {
            conn = new SqlConnection(connectionstring);
            conn.Open();
            empinfo = new Dictionary<string, string>();
            //IsEmpIncluded = false;
            bool IsEmpIncluded = false;//for testing only
            int schedID = 0;
            cmd = new SqlCommand("Select * from TBL_EMPLOYEE_MASTER where emp_EmpID = '" + empno + "'", conn);
            dread = cmd.ExecuteReader();
            dread.Read();
            if (dread.HasRows)
            {
                empinfo.Add("emp_FullName", dread["emp_FullName"].ToString());
                empinfo.Add("emp_PayrollGroup", dread["emp_PayrollGroup"].ToString());
                schedID = int.Parse(dread[get_buss_day(bussdate)].ToString());
                IsEmpIncluded = true;
            }
            dread.Close();


            if (isforDTS)
            {
                string strschedtimein = ""; string strschedtimeout = "";
                if (cm.ItemExist("TBL_FLEXISCHED", "id", "where EmpID = '" + empno + "' AND BussDate = '" + bussdate.ToString("yyyy-MM-dd") + "'"))
                {
                    cm.GetTwoDataFromDB("Sched_TimeIn", "Sched_TimeOut", "TBL_FLEXISCHED", "where EmpID = '" + empno + "' AND BussDate = '" + bussdate.ToString("yyyy-MM-dd") + "'", out strschedtimein, out strschedtimeout);
                    empinfo.Add("Sched_TimeIn", strschedtimein);
                    empinfo.Add("Sched_TimeOut", strschedtimeout);
                    goto EXITRET;
                }
                cmd = new SqlCommand("Select * from TBL_DTR where BussDate = '" + bussdate.ToString("yyyy-MM-dd") + "' and EmpID = '" + empno + "'", conn);

                dread = cmd.ExecuteReader();
                dread.Read();
                if (dread.HasRows)
                {
                    empinfo.Add("Sched_TimeIn", dread["Sched_TimeIn"].ToString());
                    empinfo.Add("Sched_TimeOut", dread["Sched_TimeOut"].ToString());
                }
                else
                {
                    dread.Close();
                    cmd = new SqlCommand("Select * from TBL_SCHEDULE where id = " + schedID + "", conn);
                    dread = cmd.ExecuteReader();
                    dread.Read();
                    if (dread.HasRows)
                    {
                        empinfo.Add("Sched_TimeIn", dread["Sched_TimeIn"].ToString());
                        empinfo.Add("Sched_TimeOut", dread["Sched_TimeOut"].ToString());
                    }
                    else
                    {
                        empinfo.Add("Sched_TimeIn", "RD");
                        empinfo.Add("Sched_TimeOut", "RD");
                    }
                    dread.Close();
                }

                dread.Close();
            }
            else
            {
                string strschedtimein = ""; string strschedtimeout = "";
                if (cm.ItemExist("TBL_FLEXISCHED", "id", "where EmpID = '" + empno + "' AND BussDate = '" + bussdate.ToString("yyyy-MM-dd") + "'"))
                {
                    cm.GetTwoDataFromDB("Sched_TimeIn", "Sched_TimeOut", "TBL_FLEXISCHED", "where EmpID = '" + empno + "' AND BussDate = '" + bussdate.ToString("yyyy-MM-dd") + "'", out strschedtimein, out strschedtimeout);
                    empinfo.Add("Sched_TimeIn", strschedtimein);
                    empinfo.Add("Sched_TimeOut", strschedtimeout);
                    goto EXITRET;
                }
                cmd = new SqlCommand("Select * from TBL_SCHEDULE where id = " + schedID + "", conn);
                dread = cmd.ExecuteReader();
                dread.Read();
                if (dread.HasRows)
                {
                    empinfo.Add("Sched_TimeIn", dread["Sched_TimeIn"].ToString());
                    empinfo.Add("Sched_TimeOut", dread["Sched_TimeOut"].ToString());
                }
                else
                {
                    empinfo.Add("Sched_TimeIn", "RD");
                    empinfo.Add("Sched_TimeOut", "RD");

                }
                dread.Close();

            }
        EXITRET:
            empinfo.Add("schedID", schedID.ToString());
            return IsEmpIncluded;
        }
        finally
        {
            conn.Close();
        }

    }

    public void get_dts_info(string empno, DateTime bussdate, out Dictionary<string, string> dtsinfo)
        {
            dtsinfo = cm.GetTableDict("TBL_DTSAE", " where EmpID = '" + empno + "' and BussDate = '" + bussdate.ToString("yyyy-MM-dd") + "'");
            //conn = new SqlConnection(connectionstring);
            //conn.Open();
            //dtsinfo = new Dictionary<string, string>();
            //int schedID = 0;
            //cmd = new SqlCommand("Select * from TBL_DTSAE where EmpID = '" + empno + "' and BussDate = '" + bussdate + "'", conn);
            //dread = cmd.ExecuteReader();
            //dread.Read();
            //if (dread.HasRows)
            //{
            //    dtsinfo.Add("emp_FullName", dread["emp_FullName"].ToString());
            //    schedID = int.Parse(dread[get_buss_day(bussdate)].ToString());
            //}
            //dread.Close();
            //conn.Close();
        }

        public string get_shiftname(string empno, DateTime bussdate)
        {
            conn.Close();
            conn.Open();
            //IsEmpIncluded = false;
            string ret = "08:30 AM - 05:30 PM";
            int schedID = 0;
            cmd = new SqlCommand("Select * from TBL_EMPLOYEE_MASTER where emp_EmpID = '" + empno + "'", conn);
            dread = cmd.ExecuteReader();
            dread.Read();
            if (dread.HasRows)
            {
                schedID = int.Parse(dread[get_buss_day(bussdate)].ToString());

            }

            dread.Close();

            cmd = new SqlCommand("Select * from TBL_SCHEDULE where id = " + schedID + "", conn);
            dread = cmd.ExecuteReader();
            dread.Read();
            if (dread.HasRows)
            {
                ret = dread["ShiftName"].ToString();
            }
            dread.Close();
            if (schedID <= 0)
                ret = "Rest Day";



            return ret;
        }

        public string get_buss_day(DateTime bussdate)
        {
            string _field = "";
            string dayname = bussdate.ToString("dddd");
            switch (dayname)
            {
                case "Monday":
                    _field = "emp_Monday";
                    break;
                case "Tuesday":
                    _field = "emp_Tuesday";
                    break;
                case "Wednesday":
                    _field = "emp_Wednesday";
                    break;
                case "Thursday":
                    _field = "emp_Thursday";
                    break;
                case "Friday":
                    _field = "emp_Friday";
                    break;
                case "Saturday":
                    _field = "emp_Saturday";
                    break;
                case "Sunday":
                    _field = "emp_Sunday";
                    break;



            }


            return _field;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<string> getEmployeeIDs()
        {

            return getEmployeeIDs("");

        }
        /// <summary>
        /// eg. string paramcondition = " and emp_Assignment = '1'"
        /// getEmployeeIDs(paramcondition);
        /// </summary>
        /// <param name="addcondition"></param>
        /// <returns></returns>
        List<string> getEmployeeIDs(string paramcondition)
        {
            List<string> ret = new List<string>();
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select emp_EmpID from TBL_EMPLOYEE_MASTER where emp_Active ='Y' ", conn);
            dread = cmd.ExecuteReader();

            while (dread.Read())
            {
                ret.Add(dread[0].ToString());
            }
            dread.Close();
            conn.Close();
            return ret;


        }
    List<string> getEmployeeIDs1(string paramcondition)
    {
        List<string> ret = new List<string>();
        string qry = "Select emp_EmpID from TBL_EMPLOYEE_MASTER where emp_Active ='Y' ";
        if (paramcondition != "")
        {
            qry += paramcondition;
        }
        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand(qry, conn);
        dread = cmd.ExecuteReader();

        while (dread.Read())
        {
            ret.Add(dread[0].ToString());
        }
        dread.Close();
        conn.Close();
        return ret;


    }
    public void getCutoffRange(string cutoff_id, out string codate)
        {
            DateTime coto = new DateTime();
            DateTime cofrom = new DateTime();

            List<string> employeeIds = getEmployeeIDs();
            getCutoffRange(cutoff_id, out codate, out cofrom, out coto);
        }

        public void getCutoffRange(string cutoff_id, out string codate, out DateTime dtFrom, out DateTime dtTo)
        {
            string payrollgroupid;
            getCutoffRange(cutoff_id, out codate, out dtFrom, out dtTo, out payrollgroupid);

        }
        public void getCutoffRange(string cutoff_id, out string codate, out DateTime dtFrom, out DateTime dtTo, out string payrollgroupid)
        {
        try
        {
            conn = new SqlConnection(connectionstring);
            conn.Open();
            dtFrom = new DateTime(); dtTo = new DateTime();
            codate = ""; payrollgroupid = "";
            cmd = new SqlCommand("Select * from TBL_CUTOFF where id =" + cutoff_id + "", conn);
            dread = cmd.ExecuteReader();
            dread.Read();
            if (dread.HasRows)
            {
                dtFrom = DateTime.Parse(dread["COFrom"].ToString());
                dtTo = DateTime.Parse(dread["COTo"].ToString());
                codate = (DateTime.Parse(dread["COTo"].ToString())).ToString("yyyy-MM-dd");
                payrollgroupid = dread["PayrollGroup"].ToString();
            }
            dread.Close();
            conn.Close();

        }
        finally
        {
            conn.Close();
        }

        }


        bool IsDateHolidayOLD(DateTime date, out string holidaytype)
        {
            string holidaydesc = "";
            holidaytype = "";
            return IsDateHolidayOLD(date, out holidaydesc, out holidaytype);
        }
        bool IsDateHolidayOLD(DateTime date, out string holidaydesc, out string holidaytype)
        {
            bool isholiday = false;
            holidaydesc = "";
            holidaytype = "";
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_HOLIDAY where Holiday = '" + date.ToString("yyyy-MM-dd") + "'", conn);
            dread = cmd.ExecuteReader();
            dread.Read();
            if (dread.HasRows)
            {
                holidaydesc = dread["HDescription"].ToString();
                holidaytype = dread["HType"].ToString();
                isholiday = true;
            }
            dread.Close();
            conn.Close();

            return isholiday;
        }
    bool IsDateHoliday(string empnum, DateTime date, out string holidaytype)
    {
        string holidaydesc = "";
        bool isdoublelh = false;
        //holidaytype = "";
        return IsDateHoliday(empnum, date, out holidaydesc, out holidaytype, out isdoublelh);
    }
    bool IsDateHolidayOLD(string empnum, DateTime date, out string holidaydesc, out string holidaytype)
    {

        string emplocation = cm.GetSpecificDataFromDB("emp_Location", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + empnum + "'");
        //string paytype = cm.GetSpecificDataFromDB("emp_PayType", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + empnum + "'");
        //bool isMonthly = paytype == "M" ? true : false;
        bool isholiday = false;
        holidaydesc = "";
        holidaytype = "";
        //if(!isMonthly)
       // {
            conn = new SqlConnection(connectionstring);
            conn.Close();
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_HOLIDAY where Holiday = '" + date.ToString("yyyy-MM-dd") + "' AND (HLocation = '" + emplocation + "' OR HLocation = 'ALL')", conn);
            dread = cmd.ExecuteReader();
            dread.Read();
            if (dread.HasRows)
            {
                holidaydesc = dread["HDescription"].ToString();
                holidaytype = dread["HType"].ToString();
                isholiday = true;
            }

            dread.Close();
            conn.Close();
        //}
        
            
        
        
        return isholiday;
    }
    bool IsDateHoliday(string empnum, DateTime date, out string holidaydesc, out string holidaytype, out bool isdoublelh)
    {

        string emplocation = cm.GetSpecificDataFromDB("emp_Location", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + empnum + "'");
        //string paytype = cm.GetSpecificDataFromDB("emp_PayType", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + empnum + "'");
        //bool isMonthly = paytype == "M" ? true : false;
        bool isholiday = false;
        holidaydesc = "";
        holidaytype = "";
        isdoublelh = false; 
        int lhcounter = 0;
        //if(!isMonthly)
        // {
        conn = new SqlConnection(connectionstring);
        conn.Close();
        conn.Open();
        cmd = new SqlCommand("Select * from TBL_HOLIDAY where Holiday = '" + date.ToString("yyyy-MM-dd") + "' AND (HLocation = '" + emplocation + "' OR HLocation = 'ALL')", conn);
        dread = cmd.ExecuteReader();
        //dread.Read();
        while (dread.Read())
        {
            if(dread["HType"].ToString() == "LH")
            {
                lhcounter = lhcounter++;
            }
            holidaydesc = dread["HDescription"].ToString();
            holidaytype = dread["HType"].ToString();
            isholiday = true;
        }

        dread.Close();
        conn.Close();
        //}

        isdoublelh = lhcounter >= 2 ? true : false;


        return isholiday;
    }
    bool IsDateRD(DateTime date, string empno, Dictionary<string, string> _empinfo, string codate)
        {
            bool ret = false;
            Dictionary<string, string> param = new Dictionary<string, string>();
            string sched_TimeIn = "";
            string sched_TimeOut = "";

            if (_empinfo.Count > 1)
            {
            if (_empinfo.ContainsKey("Sched_TimeIn") && _empinfo.ContainsKey("Sched_TimeOut"))
            {
                sched_TimeIn = _empinfo["Sched_TimeIn"];
                sched_TimeOut = _empinfo["Sched_TimeOut"];
                ret = false;
                if (_empinfo["Sched_TimeIn"] == "RD" || _empinfo["Sched_TimeOut"] == "RD") ret = true;
            }
            else
            {
                ret = true;
            }
        }
            else
            {
                ret = true;
            }


            return ret;


        }
    bool HasFiledLeaveforAMPM(DateTime date, string empno, Dictionary<string, string> _empinfo, out string reason, out int leavetypeID, out string leavekey, out string ampm)
    {
        bool HasLeave = false;
        leavetypeID = -1;
        leavekey = "";
        reason = "";
        string schedIn = ""; string schedOut = "";
        ampm = "";
        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand("Select * from TBL_LEAVESAPP where LeaveStatus = '1' and EmpID = '" + empno + "' and '" + date.ToString("yyyy-MM-dd") + "' BETWEEN TBL_LEAVESAPP.DateFrom AND TBL_LEAVESAPP.DateTo", conn);
        //cmd = new SqlCommand("Select * from TBL_LEAVESAPP where LeaveStatus = '1' and EmpID = '" + empno + "' and TBL_LEAVESAPP.DateFrom = '" + date.ToString("yyyy-MM-dd") + "'", conn);
        dread = cmd.ExecuteReader();
        dread.Read();
        if (dread.HasRows)
        {
            //leavekey = cm.GetSpecificDataFromDB("LeaveKey", "TBL_LEAVETYPE", "where id = " + dread["LeaveType"].ToString() + "");
            leavekey = dread["LeaveKey"].ToString();
            reason = dread["Reason"].ToString();
            ampm = dread["ampm"].ToString();
            leavetypeID = int.Parse(dread["LeaveType"].ToString());
            if (_empinfo.Count > 1 && _empinfo.ContainsKey("Sched_TimeIn") && _empinfo.ContainsKey("Sched_TimeOut"))
            {
                schedIn = _empinfo["Sched_TimeIn"];
                schedOut = _empinfo["Sched_TimeOut"];
                if (schedIn != "RD" && schedOut != "RD")
                    HasLeave = true;
                else
                    HasLeave = false;


            }

        }
        dread.Close();
        conn.Close();

        return HasLeave;
    }
    bool HasFiledLeave(DateTime date, string empno, Dictionary<string, string> _empinfo, out string reason, out int leavetypeID, out string leavekey, out string ampm, out string leavehours)
    {
        bool HasLeave = false;
        leavetypeID = -1;
        leavekey = "";
        reason = "";
        ampm = "";
        string schedIn = ""; string schedOut = "";
        leavehours = "0";
        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand("Select * from TBL_LEAVESAPP where LeaveStatus = '1' and EmpID = '" + empno + "' and '" + date.ToString("yyyy-MM-dd") + "' BETWEEN TBL_LEAVESAPP.DateFrom AND TBL_LEAVESAPP.DateTo", conn);
        //cmd = new SqlCommand("Select * from TBL_LEAVESAPP where LeaveStatus = '1' and EmpID = '" + empno + "' and TBL_LEAVESAPP.DateFrom = '" + date.ToString("yyyy-MM-dd") + "'", conn);
        dread = cmd.ExecuteReader();
        dread.Read();
        if (dread.HasRows)
        {
            //leavekey = cm.GetSpecificDataFromDB("LeaveKey", "TBL_LEAVETYPE", "where id = " + dread["LeaveType"].ToString() + "");
            leavekey = dread["LeaveKey"].ToString();
            reason = dread["Reason"].ToString();
            leavehours = dread["LeaveHours"].ToString();
            leavetypeID = int.Parse(dread["LeaveType"].ToString());
            ampm = dread["ampm"].ToString();
            if (_empinfo.Count > 1 && _empinfo.ContainsKey("Sched_TimeIn") && _empinfo.ContainsKey("Sched_TimeOut"))
            {
                schedIn = _empinfo["Sched_TimeIn"];
                schedOut = _empinfo["Sched_TimeOut"];
                if (schedIn != "RD" && schedOut != "RD")
                    HasLeave = true;
                else
                    HasLeave = false;


            }

        }
        dread.Close();
        conn.Close();

        return HasLeave;
    }
    bool HasFiledSuspension(DateTime date, string empno)
        {
            bool HasSuspension = false;
            
            
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_SUSPENSION where empid = '" + empno + "' and '" + date.ToString("yyyy-MM-dd") + "' BETWEEN TBL_SUSPENSION.renderedDtFrom AND TBL_SUSPENSION.renderedDtTo", conn);

            dread = cmd.ExecuteReader();
            dread.Read();
            if (dread.HasRows)
            {
                HasSuspension = true;
            }
            dread.Close();
            conn.Close();

            return HasSuspension;
        }
    bool HasFiledOBT(DateTime date, string empno, out string reason, out string timein, out string timeout)
        {
            bool HasOBT = false;
            reason = "";
            timein = "";
            timeout = "";
            conn = new SqlConnection(connectionstring);
            conn.Open();
        cmd = new SqlCommand("Select * from TBL_OBT where OBT_Status = '1' and EmpID = '" + empno + "' and ('" + date.ToString("yyyy-MM-dd") + "' BETWEEN TBL_OBT.DateFrom AND TBL_OBT.DateTo)", conn);
        //cmd = new SqlCommand("Select * from TBL_OBT where OBT_Status = 'Approved' and EmpID = '" + empno + "' and '" + date.ToString("yyyy-MM-dd") + "' BETWEEN TBL_OBT.TripDate AND TBL_OBT.EndDate", conn);
        //cmd = new SqlCommand("Select * from TBL_OBT where OBT_Status = '1' and EmpID = '" + empno + "' and TripDate = '" + date.ToString("yyyy-MM-dd") + "' ", conn);

        dread = cmd.ExecuteReader();
            dread.Read();
            if (dread.HasRows)
            {
                reason = dread["Reason"].ToString();
                timein = dread["TimeIn"].ToString();
                timeout = dread["TimeOut"].ToString();
            
                HasOBT = true;
            }
            dread.Close();
            conn.Close();

            return HasOBT;
        }
    bool HasFiledFTS(DateTime date, string empno, out string reason, out string uain, out string uaout, out string ua_lunchOut, out string ua_lunchIn)
    {
        bool HasFTS = false;
        reason = "";
        uain = "";
        uaout = "";
        ua_lunchOut = "";
        ua_lunchIn = "";
        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand("Select * from TBL_FTS where fts_Status = '1' and EmpID = '" + empno + "' and buss_date ='" + date.ToString("yyyy-MM-dd") + "'", conn);

        dread = cmd.ExecuteReader();
        dread.Read();
        if (dread.HasRows)
        {
            reason = dread["Reason"].ToString();
            uain = dread["uain"].ToString();
            uaout = dread["uaout"].ToString();
            ua_lunchOut = dread["lunchOut"].ToString();
            ua_lunchIn = dread["lunchIn"].ToString();
            HasFTS = true;
        }
        dread.Close();
        conn.Close();

        return HasFTS;
    }
    bool HasFiledFTS(DateTime date, string empno, out string reason, out string ftstimeinout, out string ftstype)
        {
            bool HasFTS = false;
            reason = "";
            ftstimeinout = "";
            ftstype = "";
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand("Select * from TBL_FTS where fts_Status = '1' and EmpID = '" + empno + "' and buss_date ='" + date.ToString("yyyy-MM-dd") + "'", conn);

            dread = cmd.ExecuteReader();
            dread.Read();
            if (dread.HasRows)
            {
                reason = dread["Reason"].ToString();
                ftstimeinout = dread["ftime"].ToString();
                ftstype = dread["fts_type"].ToString();
            HasFTS = true;
            }
            dread.Close();
            conn.Close();

            return HasFTS;
        }
    
    bool HasFiledTIME_IN_OUT(DateTime date, string empno, out DataTable DTR_DT)
        {
        try
        {
            DTR_DT = new DataTable();
            bool HasTIME_IN_OUT = false;
            string ret = "";
            string qry = "SELECT EmpID,AssignmentCode,BussDate,min(DateIn) as 'DateIn',min(DTimeIn) as 'DTimeIn',min(DateOut) as 'DateOut',min(DTimeOut) as 'DTimeOut',min(DateIn2) as 'DateIn2',min(TimeIn2) as 'TimeIn2',min(DateOut2) as 'DateOut2',min(TimeOut2) as 'TimeOut2',min(Sched_TimeIn) as 'Sched_TimeIn',min(Sched_TimeOut) as 'Sched_TimeOut',min(ActivityCode) as 'ActivityCode',min(RestDay) as 'RestDay',Emp_Name,min(ODateIn) as 'ODateIn',min(OTimeIn) as 'OTimeIn',min(ODateOut) as 'ODateOut',min(OTimeOut) as 'OTimeOut',min(ODateIn2) as 'ODateIn2',min(OTimeIn2) as 'OTimeIn2',min(ODateOut2) as 'ODateOut2',min(OTimeOut2) as 'OTimeOut2' " +
                    " FROM TBL_DTR" +
                    " where BussDate = '" + date.ToString("yyyy-MM-dd") + "' and EmpID = '" + empno + "'" +
                    " Group by EmpID, BussDate, AssignmentCode, Emp_Name" +
                    " Order by EmpID";
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(qry, conn);
            dread = cmd.ExecuteReader();
            dread.Read();
            if (dread.HasRows)
                HasTIME_IN_OUT = true;
            dread.Close();
            adpt = new SqlDataAdapter(cmd);
            adpt.Fill(DTR_DT);

            conn.Close();

            return HasTIME_IN_OUT;

        }
        finally
        {
            conn.Close();
        }
        }
        bool HasDuplicate_DTS_Entry(string empno, string bussdate, string CutoffID)
        {
        try
        {
            conn.Close();
            bool isduplicate = false;
            string qry = "Select * from TBL_DTSAE where EmpID = '" + empno + "' and CutoffID = " + CutoffID + " and BussDate = '" + bussdate + "'";
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(qry, conn);
            dread = cmd.ExecuteReader();
            dread.Read();
            if (dread.HasRows)
                isduplicate = true;

            dread.Close();
            conn.Close();


            return isduplicate;
        }
        finally
        {
            conn.Close();

        }
    }
    void UpdateDTSEntryParam(Dictionary<string, string> param, out Dictionary<string, string> dparam)
    {
        dparam = new Dictionary<string, string>();
        //Dictionary<string, string> dparam = new Dictionary<string, string>();
        dparam = param;

        //dparam.Add("id","NULL");
        //dparam.Add("CutoffID","NULL");
        //dparam.Add("BussDate","NULL");
        //dparam.Add("BussDate2","NULL");

        //if (!param.ContainsKey("ShiftName")) dparam.Add("ShiftName", "NULL");
        if (!dparam.ContainsKey("EndDate")) dparam.Add("EndDate", "NULL");
        if (!dparam.ContainsKey("DateIn")) dparam.Add("DateIn", "NULL");
        if (!dparam.ContainsKey("DateOut")) dparam.Add("DateOut", "NULL");
        //dparam.Add("EmpID","NULL");
        //dparam.Add("Emp_Name","NULL");
        if (!dparam.ContainsKey("AssignmentCode")) dparam.Add("AssignmentCode", "NULL");
        //dparam.Add("Sched_TimeIn","NULL");
        //dparam.Add("Sched_TimeOut","NULL");
        if (!dparam.ContainsKey("Sched_RestDay")) dparam.Add("Sched_RestDay", "NULL");
        if (!dparam.ContainsKey("DTimeIn")) dparam.Add("DTimeIn", "NULL");
        if (!dparam.ContainsKey("DTimeOut")) dparam.Add("DTimeOut", "NULL");
        if (!dparam.ContainsKey("LunchOut")) dparam.Add("LunchOut", "NULL");
        if (!dparam.ContainsKey("LunchIn")) dparam.Add("LunchIn", "NULL");
        if (!dparam.ContainsKey("OverBreak")) dparam.Add("OverBreak", "NULL");
        if (!dparam.ContainsKey("Lates")) dparam.Add("Lates", "NULL");
        if (!dparam.ContainsKey("CorrectedTimeIn")) dparam.Add("CorrectedTimeIn", "NULL");
        if (!dparam.ContainsKey("CorrectedTimeOut")) dparam.Add("CorrectedTimeOut", "NULL");
        if (!dparam.ContainsKey("TotHrs")) dparam.Add("TotHrs", "NULL");
        if (!dparam.ContainsKey("DAbsent")) dparam.Add("DAbsent", "NULL");
        if (!dparam.ContainsKey("ExcHrs")) dparam.Add("ExcHrs", "NULL");
        if (!dparam.ContainsKey("LatesCount")) dparam.Add("LatesCount", "NULL");
        if (!dparam.ContainsKey("Latesmin")) dparam.Add("Latesmin", "NULL");
        if (!dparam.ContainsKey("LateRate")) dparam.Add("LateRate", "NULL");
        if (!dparam.ContainsKey("UT")) dparam.Add("UT", "NULL");
        if (!dparam.ContainsKey("UTmin")) dparam.Add("UTmin", "NULL");
        if (!dparam.ContainsKey("UTRate")) dparam.Add("UTRate", "NULL");
        if (!dparam.ContainsKey("RegHrs")) dparam.Add("RegHrs", "NULL");
        if (!dparam.ContainsKey("OTHrs")) dparam.Add("OTHrs", "NULL");
        if (!dparam.ContainsKey("RegHrsWND")) dparam.Add("RegHrsWND", "NULL");
        if (!dparam.ContainsKey("OTReg")) dparam.Add("OTReg", "NULL");
        if (!dparam.ContainsKey("OTRegWND")) dparam.Add("OTRegWND", "NULL");
        if (!dparam.ContainsKey("OTSun")) dparam.Add("OTSun", "NULL");
        if (!dparam.ContainsKey("OTSunExc8Hrs")) dparam.Add("OTSunExc8Hrs", "NULL");
        if (!dparam.ContainsKey("OTLH")) dparam.Add("OTLH", "NULL");
        if (!dparam.ContainsKey("OTLHExc8Hrs")) dparam.Add("OTLHExc8Hrs", "NULL");
        if (!dparam.ContainsKey("LHWO")) dparam.Add("LHWO", "NULL");
        if (!dparam.ContainsKey("LHND")) dparam.Add("LHND", "NULL");
        if (!dparam.ContainsKey("LHNDES")) dparam.Add("LHNDES", "NULL");
        if (!dparam.ContainsKey("COHol")) dparam.Add("COHol", "NULL");
        if (!dparam.ContainsKey("SunND")) dparam.Add("SunND", "NULL");
        if (!dparam.ContainsKey("SunNDOT")) dparam.Add("SunNDOT", "NULL");
        if (!dparam.ContainsKey("OTPay")) dparam.Add("OTPay", "NULL");
        if (!dparam.ContainsKey("LateDed")) dparam.Add("LateDed", "NULL");
        if (!dparam.ContainsKey("UTDed")) dparam.Add("UTDed", "NULL");
        if (!dparam.ContainsKey("Reason")) dparam.Add("Reason", "NULL");
        if (!dparam.ContainsKey("ActivityCode")) dparam.Add("ActivityCode", "NULL");
        if (!dparam.ContainsKey("ActivityName")) dparam.Add("ActivityName", "NULL");
        if (!dparam.ContainsKey("ManHrs")) dparam.Add("ManHrs", "NULL");
        //dparam.Add("PayPeriod","NULL");
        //dparam.Add("Remarks","NULL");
        //dparam.Add("DDayName","NULL");
        //dparam.Add("allowance","NULL");
        //dparam.Add("Submit","NULL");
        //dparam.Add("DateSubmitted","NULL");
        if (!dparam.ContainsKey("RegOT")) dparam.Add("RegOT", "NULL");
        if (!dparam.ContainsKey("RegOTND")) dparam.Add("RegOTND", "NULL");
        if (!dparam.ContainsKey("LHOT")) dparam.Add("LHOT", "NULL");
        if (!dparam.ContainsKey("LHOT8HRS")) dparam.Add("LHOT8HRS", "NULL");
        if (!dparam.ContainsKey("LHOTND")) dparam.Add("LHOTND", "NULL");
        if (!dparam.ContainsKey("SHOT")) dparam.Add("SHOT", "NULL");
        if (!dparam.ContainsKey("SHOT8HRS")) dparam.Add("SHOT8HRS", "NULL");
        if (!dparam.ContainsKey("SHOTND")) dparam.Add("SHOTND", "NULL");
        if (!dparam.ContainsKey("RDOTND")) dparam.Add("RDOTND", "NULL");
        if (!dparam.ContainsKey("RDOT")) dparam.Add("RDOT", "NULL");
        if (!dparam.ContainsKey("RDOT8HRS")) dparam.Add("RDOT8HRS", "NULL");
        if (!dparam.ContainsKey("RDLHOT")) dparam.Add("RDLHOT", "NULL");
        if (!dparam.ContainsKey("RDLHOT8HRS")) dparam.Add("RDLHOT8HRS", "NULL");
        if (!dparam.ContainsKey("RDLHOTND")) dparam.Add("RDLHOTND", "NULL");
        if (!dparam.ContainsKey("RDSHOT")) dparam.Add("RDSHOT", "NULL");
        if (!dparam.ContainsKey("RDSHOT8HRS")) dparam.Add("RDSHOT8HRS", "NULL");
        if (!dparam.ContainsKey("RDSHOTND")) dparam.Add("RDSHOTND", "NULL");
        if (!dparam.ContainsKey("LWP")) dparam.Add("LWP", "NULL");
        if (!dparam.ContainsKey("LWOP")) dparam.Add("LWOP", "NULL");
        if (!dparam.ContainsKey("NDHrs")) dparam.Add("NDHrs", "NULL");
        if (!dparam.ContainsKey("RegNDHrs")) dparam.Add("RegNDHrs", "NULL");
        if (!dparam.ContainsKey("SHNDHrs")) dparam.Add("SHNDHrs", "NULL");
        if (!dparam.ContainsKey("LHNDHrs")) dparam.Add("LHNDHrs", "NULL");
        if (!dparam.ContainsKey("RDLHNDHrs")) dparam.Add("RDLHNDHrs", "NULL");
        if (!dparam.ContainsKey("RDSHNDHrs")) dparam.Add("RDSHNDHrs", "NULL");
        if (!dparam.ContainsKey("RDND")) dparam.Add("RDND", "NULL");
        if (!dparam.ContainsKey("NumberDaysWorked")) dparam.Add("NumberDaysWorked", "NULL");
    }

        bool HasDuplicate_Summary_Entry(string empno, string CutoffID)
        {
            bool isduplicate = false;
            string qry = "Select * from TBL_PAYROLLSUM where empid = '" + empno + "' and CutoffID = '" + CutoffID + "'";
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(qry, conn);
            dread = cmd.ExecuteReader();
            dread.Read();
            if (dread.HasRows)
                isduplicate = true;

            dread.Close();
            conn.Close();


            return isduplicate;
        }

        void InsertDTSHolidayOld(DateTime date, string empno, Dictionary<string, string> _empinfo, string holidaydesc,string holidaytype, string codate, string CutoffID)
        {
        string remark = "";
        string wrk = "WRK";
        Dictionary<string, string> param = new Dictionary<string, string>();

            DateTime dtTryparse;
            DataTable dtr_DT;
            string bussdate = date.ToString("yyyy-MM-dd");
            string sched_TimeIn = "";
            string sched_TimeOut = "";

        if (_empinfo.Count > 3 && _empinfo.ContainsKey("Sched_TimeIn") && _empinfo.ContainsKey("Sched_TimeOut"))
        {
            try
            {
                sched_TimeIn = _empinfo["Sched_TimeIn"];
                sched_TimeOut = _empinfo["Sched_TimeOut"];
            }
            catch
            {
                conn = new SqlConnection(connectionstring);
                conn.Open();
                
                cmd = new SqlCommand("Select * from TBL_SCHEDULE where id = '" + _empinfo["schedID"] + "'", conn);
                dread = cmd.ExecuteReader();
                dread.Read();
                if (dread.HasRows)
                {
                    sched_TimeIn = dread["Sched_TimeIn"].ToString();
                    sched_TimeOut = dread["Sched_TimeOut"].ToString();
                    if (sched_TimeIn == "" || sched_TimeOut == "") remark = "RD";
                    else
                        remark = "";
                    

                }
                dread.Close();


            }
            dread.Close();

        }
            //bool tryDt;
            param.Clear();
            //DateTime DbussDate = DateTime.Parse(dr["BussDate"].ToString());
            //string bussdate = DbussDate.ToString("yyyy-MM-dd");
            //string insertDateIn = DateTime.Parse(dr["DateIn"].ToString()).ToString("yyyy-MM-dd");
            //tryDt = DateTime.TryParse(dr["DateIn"].ToString(), out dtTryparse);
            //string insertDateOut = dtTryparse.ToString("yyyy-MM-dd");
            //bool noOut = false;
            //if (dr["DateOut"].ToString() == null || dr["DateOut"].ToString() == "")
            //    noOut = true;
            param.Add("BussDate", "'" + bussdate + "'");
            param.Add("BussDate2", "'" + bussdate + "'");
            param.Add("ShiftName", "'" + get_shiftname(empno, date) + "'");
            param.Add("EndDate", "'" + bussdate + "'");
            //param.Add("DateIn","'"+insertDateIn+"'");
            //param.Add("DateOut","'"+insertDateOut+"'");
            param.Add("EmpID", "'" + empno + "'");
            param.Add("Emp_Name", "'" + _empinfo["emp_FullName"] + "'");
            //param.Add("AssignmentCode","'"++"'");
            param.Add("Sched_TimeIn", "'" + sched_TimeIn + "'");
            param.Add("Sched_TimeOut", "'" + sched_TimeOut + "'");
            //param.Add("Sched_RestDay","'"+dr["Sched_RestDay"].ToString()+"'");
            //param.Add("DTimeIn","'"+dr["DTimeIn"].ToString()+"'");
            //param.Add("DTimeOut","'"+dr["DTimeOut"].ToString()+"'");

            //if (!noOut)
            //{
            //    string strdtin = dr["DateIn"].ToString();
            //    string strdtout = dr["DateOut"].ToString();
            //    TimeSpan timein = TimeSpan.Parse(dr["DTimeIn"].ToString());
            //    TimeSpan timeout = TimeSpan.Parse(dr["DTimeOut"].ToString());
            //    DateTime dt = DateTime.Parse(strdtin) + timein;
            //    DateTime dtout = DateTime.Parse(strdtout) + timeout;
            //    double totalhrs = (dtout - dt).TotalHours;
            //    param.Add("TotHrs", "" + Math.Round(totalhrs, 0) + "");
            //}
            //else
            //    param.Add("TotHrs", "0");
             if (HasFiledTIME_IN_OUT(date, empno, out dtr_DT))
            {

                foreach (DataRow dr in dtr_DT.Rows)
                {
                    bool tryDt;
                
                    string insertDateIn = DateTime.Parse(dr["DateIn"].ToString()).ToString("yyyy-MM-dd");
                    tryDt = DateTime.TryParse(dr["DateIn"].ToString(), out dtTryparse);
                    string insertDateOut = dtTryparse.ToString("yyyy-MM-dd");
                param.Add("DateIn", "'" + insertDateIn + "'");
                param.Add("DateOut", "'" + insertDateOut + "'");
                param.Add("DTimeIn", "'" + dr["DTimeIn"].ToString() + "'");
                param.Add("DTimeOut", "'" + dr["DTimeOut"].ToString() + "'");


                bool noOut = false;
                if (dr["DateOut"].ToString() == null || dr["DateOut"].ToString() == "")
                    noOut = true;
                if (!noOut)
                {
                    string strdtin = dr["DateIn"].ToString();
                    string strdtout = dr["DateOut"].ToString();
                    TimeSpan timein = TimeSpan.Parse(dr["DTimeIn"].ToString());
                    TimeSpan timeout = TimeSpan.Parse(dr["DTimeOut"].ToString());
                    DateTime dt = DateTime.Parse(strdtin) + timein;
                    DateTime dtout = DateTime.Parse(strdtout) + timeout;
                    double totalhrs = (dtout - dt).TotalHours;
                    param.Add("TotHrs", "" + Math.Round(totalhrs, 0) + "");
                }
                else
                {
                    param.Add("TotHrs", "0");
                }
                double manhrs = cm.get_Time_Difference(sched_TimeIn, sched_TimeOut);
                param.Add("ManHrs", "" + Math.Round(manhrs, 0) + "");



            }

            }
            else
            {
                wrk = "";
                param.Add("ManHrs", "0");
                param.Add("TotHrs", "0");

            }
            
            param.Add("PayPeriod", "'" + codate + "'");
            //param.Add("Remarks", (noOut? "'NO OUT'":"'WRK'"));
            param.Add("ActivityCode", "'" + empno + "'");
            param.Add("ActivityName", "'" + _empinfo["emp_FullName"] + "'");
            param.Add("Reason", "'" + holidaytype + "'");
        remark = wrk + holidaytype + remark;
        param.Add("Remarks", "'" + remark + "'");
            param.Add("DDayName", "'" + date.ToString("dddd") + " REG'");
            //param.Add("Submit", "'N'");
            param.Add("Submit", "'Y'");
            param.Add("allowance", "0");
            param.Add("CutoffID", CutoffID);

            /*
             * 
             * 
             * 
             * 
             * */
            if (!HasDuplicate_DTS_Entry(empno, bussdate, CutoffID))
            {
                if (!(InsertQueryCommon(param, "TBL_DTSAE")))
                    Console.WriteLine("Failed InsertDTSHoliday()");
            }
        else
        {
            UpdateDTSEntryParam(param, out param);
            cm.UpdateQueryCommon(param, "TBL_DTSAE", "BussDate = '" + bussdate + "' and CutoffID = " + CutoffID + " and EmpID = '" + empno + "' ");
        }

    }
    void InsertDTSHoliday(DateTime date, string empno, Dictionary<string, string> _empinfo, string holidaydesc, string holidaytype, string codate, string CutoffID, bool isdoublelh)
    {
        
        bool isPiooner = _empinfo["emp_IsPioneer"] == "True" ? true : false;
        holidaytype = isdoublelh ? "DOUB" + holidaytype : holidaytype;
        Dictionary<string, string> param = new Dictionary<string, string>();

        DateTime dtTryparse;
        DataTable dtr_DT;
        string bussdate = date.ToString("yyyy-MM-dd");
        string sched_TimeIn = "";
        string sched_TimeOut = "";
        string remark = "";
        string wrk = "WRK";
        if (_empinfo.Count > 3 && _empinfo.ContainsKey("Sched_TimeIn") && _empinfo.ContainsKey("Sched_TimeOut"))
        {
            try
            {
                sched_TimeIn = _empinfo["Sched_TimeIn"];
                sched_TimeOut = _empinfo["Sched_TimeOut"];
                if (sched_TimeIn == "RD" || sched_TimeOut == "RD") remark = "RD";
                else if (sched_TimeIn != "RD" || sched_TimeOut != "RD") remark = "";
            }
            catch
            {
                conn = new SqlConnection(connectionstring);
                conn.Open();

                cmd = new SqlCommand("Select * from TBL_SCHEDULE where id = '" + _empinfo["schedID"] + "'", conn);
                dread = cmd.ExecuteReader();
                dread.Read();
                if (dread.HasRows)
                {
                    sched_TimeIn = dread["Sched_TimeIn"].ToString();
                    sched_TimeOut = dread["Sched_TimeOut"].ToString();

                }
                dread.Close();


            }
            dread.Close();

        }
        param.Clear();
        param.Add("BussDate", "'" + bussdate + "'");
        param.Add("BussDate2", "'" + bussdate + "'");
        param.Add("ShiftName", "'" + get_shiftname(empno, date) + "'");
        param.Add("EndDate", "'" + bussdate + "'");
        param.Add("EmpID", "'" + empno + "'");
        param.Add("Emp_Name", "'" + _empinfo["emp_FullName"] + "'");
        string obt_reason = "";
        string obttimein = "";
        string obttimeout = "";
        string fts_reason = "";
        string ftstimein = "";
        string ftstimeout = "";
        string ftslunchout = "";
        string ftslunchin = "";

        //06/17/2022 Jan Wong. check nearest working date from date.
        //DateTime dateplusone = date;//06/17/2022 Jan Wong. Check only day before
        DateTime dateminusone = date;
        bool isDtWork = false;
        int counter = 0;
        while (!isDtWork && counter <= 7)
        {
            counter++;
            dateminusone = dateminusone.AddDays(-1);
            Dictionary<string, string> empSchedInfo = new Dictionary<string, string>();
            get_emp_info_with_conn(empno, dateminusone, out empSchedInfo, true);
            if (empSchedInfo["Sched_TimeIn"] != "RD" && empSchedInfo["Sched_TimeOut"] != "RD") isDtWork = true;

        }//06/17/2022 Jan Wong. check nearest working date from date.
        DateTime dateplusone = dateminusone;

        if (HasFiledOBT(date, empno, out obt_reason, out obttimein, out obttimeout))
        {
            param.Add("DateIn", "'" + bussdate + "'");
            param.Add("DateOut", "'" + bussdate + "'");
            param.Add("DTimeIn", "'" + obttimein + "'");
            param.Add("DTimeOut", "'" + obttimeout + "'");
            param.Add("Sched_TimeIn", "'" + sched_TimeIn + "'");
            param.Add("Sched_TimeOut", "'" + sched_TimeOut + "'");
            string strdtin = bussdate;
            string strdtout = bussdate;
            TimeSpan timein = TimeSpan.Parse(obttimein);
            TimeSpan timeout = TimeSpan.Parse(obttimeout);
            DateTime dt = DateTime.Parse(strdtin) + timein;
            DateTime dtout = DateTime.Parse(strdtout) + timeout;
            double manhrs = cm.get_Time_Difference(sched_TimeIn, sched_TimeOut);
            param.Add("ManHrs", "" + Math.Round(manhrs, 0) + "");
            //DateTime dateplusone = date.AddDays(1);
            //DateTime dateminusone = date.AddDays(1);
            if (holidaytype == "LH")
            {
                if (HasFiledTIME_IN_OUT(dateplusone, empno) || HasFiledTIME_IN_OUT(dateminusone, empno) ||
                    HasFiledFTSForBeforeAfter(dateplusone, empno) || HasFiledFTSForBeforeAfter(dateminusone, empno) ||
                    HasFiledLeaveForBeforeAfter(dateplusone, empno) || HasFiledLeaveForBeforeAfter(dateminusone, empno) ||
                    HasFiledOBTForBeforeAfter(dateplusone, empno) || HasFiledOBTForBeforeAfter(dateminusone, empno) || isPiooner)
                {

                    param.Add("TotHrs", "0");
                    //wrk = "";
                }
                else
                {
                    holidaytype = holidaytype + "WOP";
                    param.Add("TotHrs", "0");
                    wrk = "";
                }
            }
            else
            {
                //holidaytype = holidaytype + "WOP";
                param.Add("TotHrs", "0");
                //wrk = "";

            }
            
            
            


        }
        else if (HasFiledFTS(date, empno, out fts_reason, out ftstimein, out ftstimeout, out ftslunchout, out ftslunchin))
        {
            
            param.Add("DateIn", "'" + bussdate + "'");
            param.Add("DateOut", "'" + bussdate + "'");
            param.Add("DTimeIn", "'" + ftstimein + "'");
            param.Add("DTimeOut", "'" + ftstimeout + "'");
            param.Add("LunchOut", "'" + ftslunchout + "'");
            param.Add("LunchIn", "'" + ftslunchin + "'");
            param.Add("Sched_TimeIn", "'" + sched_TimeIn + "'");
            param.Add("Sched_TimeOut", "'" + sched_TimeOut + "'");
            string strdtin = bussdate;
            string strdtout = bussdate;
            TimeSpan timein = TimeSpan.Parse(ftstimein);
            TimeSpan timeout = TimeSpan.Parse(ftstimeout);
            DateTime dt = DateTime.Parse(strdtin) + timein;
            DateTime dtout = DateTime.Parse(strdtout) + timeout;
            double manhrs = cm.get_Time_Difference(sched_TimeIn, sched_TimeOut);
            param.Add("ManHrs", "" + Math.Round(manhrs, 0) + "");
            //DateTime dateplusone = date.AddDays(1);
            //DateTime dateminusone = date.AddDays(1);
            if (holidaytype == "LH")
            {
                if (HasFiledTIME_IN_OUT(dateplusone, empno) || HasFiledTIME_IN_OUT(dateminusone, empno) ||
            IsDateHolidayBeforeAfter(empno, dateplusone) || IsDateHolidayBeforeAfter(empno, dateminusone) ||
            HasFiledFTSForBeforeAfter(dateplusone, empno) || HasFiledFTSForBeforeAfter(dateminusone, empno) ||
            HasFiledLeaveForBeforeAfter(dateplusone, empno) || HasFiledLeaveForBeforeAfter(dateminusone, empno) ||
            HasFiledOBTForBeforeAfter(dateplusone, empno) || HasFiledOBTForBeforeAfter(dateminusone, empno) || isPiooner)
                {

                    param.Add("TotHrs", "0");
                    //wrk = "";
                }
                else
                {
                    holidaytype = holidaytype + "WOP";
                    param.Add("TotHrs", "0");
                    wrk = "";
                }
            }
            else
            {
                //holidaytype = holidaytype + "WOP";
                param.Add("TotHrs", "0");
                //wrk = "";

            }
            


        }

        else if (HasFiledTIME_IN_OUT(date, empno, out dtr_DT))
        {
            foreach (DataRow dr in dtr_DT.Rows)
            {

                bool tryDt;

                string insertDateIn = DateTime.Parse(dr["DateIn"].ToString()).ToString("yyyy-MM-dd");
                tryDt = DateTime.TryParse(dr["DateIn"].ToString(), out dtTryparse);
                string insertDateOut = dtTryparse.ToString("yyyy-MM-dd");
                param.Add("DateIn", "'" + insertDateIn + "'");
                param.Add("DateOut", "'" + insertDateOut + "'");
                param.Add("DTimeIn", "'" + dr["DTimeIn"].ToString() + "'");
                param.Add("DTimeOut", "'" + dr["DTimeOut"].ToString() + "'");
                //sched_TimeIn = ((dr["Sched_TimeIn"].ToString() == "RD") ? dr["DTimeIn"].ToString() : dr["Sched_TimeIn"].ToString());
                //sched_TimeOut = ((dr["Sched_TimeOut"].ToString() == "RD") ? dr["DTimeOut"].ToString() : dr["Sched_TimeOut"].ToString());
                //if (dr["Sched_TimeIn"].ToString() == "RD" || dr["Sched_TimeOut"].ToString() == "RD") remark = "RD";
                param.Add("Sched_TimeIn", "'" + sched_TimeIn + "'");
                param.Add("Sched_TimeOut", "'" + sched_TimeOut + "'");
                //bool noLunchInOut = false;
                //if (dr["LunchIn"].ToString() == null || dr["LunchIn"].ToString() == "" || dr["LunchOut"].ToString() == null || dr["LunchOut"].ToString() == "")
                //    noLunchInOut = true;
                //param.Add("LunchOut", "'" + dr["LunchOut"].ToString() + "'");
                //param.Add("LunchIn", "'" + dr["LunchIn"].ToString() + "'");
                //if (!noLunchInOut)
                //{
                //    string strdtin = dr["DateIn"].ToString();
                //    string strdtout = dr["DateIn"].ToString();
                //    TimeSpan Lunchtimein = TimeSpan.Parse(dr["LunchIn"].ToString());//C
                //    TimeSpan Lunchtimeout = TimeSpan.Parse(dr["LunchOut"].ToString());//B
                //    DateTime LunchdtIn = DateTime.Parse(strdtin) + Lunchtimein;
                //    DateTime LunchdtOut = DateTime.Parse(strdtout) + Lunchtimeout;
                //    if (Lunchtimein <= Lunchtimeout)
                //    {
                //        LunchdtOut.AddDays(1);
                //    }
                //    double BreakTimeMins = (LunchdtIn - LunchdtOut).TotalMinutes;
                //    if (BreakTimeMins > 60)
                //    {
                //        double overBreak = BreakTimeMins - 60;
                //        param.Add("OverBreak", "" + overBreak + "");
                //    }
                //    else
                //        param.Add("OverBreak", "0");
                //}
                //else
                //    param.Add("OverBreak", "0");


                bool noOut = false;
                bool noIn = false;
                if (dr["DateIn"].ToString() == null || dr["DateIn"].ToString() == "" || dr["DTimeOut"] == null || dr["DTimeOut"].ToString() == "")
                {
                    noOut = true;
                }
                if (dr["DateIn"].ToString() == null || dr["DateIn"].ToString() == "" || dr["DTimeIn"] == null || dr["DTimeIn"].ToString() == "")
                {
                    noIn = true;
                }
                if (!noOut && !noIn)
                {
                    string strdtin = dr["DateIn"].ToString();
                    string strdtout = dr["DateIn"].ToString();
                    TimeSpan timein = TimeSpan.Parse(dr["DTimeIn"].ToString());
                    TimeSpan timeout = TimeSpan.Parse(dr["DTimeOut"].ToString());
                    DateTime dt = DateTime.Parse(strdtin) + timein;
                    DateTime dtout = DateTime.Parse(strdtout) + timeout;
                    double totalhrs = (dtout - dt).TotalHours;
                    //param.Add("TotHrs", "" + Math.Round(totalhrs, 0) + "");
                    double manhrs = cm.get_Time_Difference(sched_TimeIn, sched_TimeOut);
                    param.Add("ManHrs", "" + Math.Round(manhrs, 0) + "");
                   // DateTime dateplusone = date.AddDays(1);
                    //DateTime dateminusone = date.AddDays(1);
                    if (holidaytype == "LH")
                    {
                        if (HasFiledTIME_IN_OUT(dateplusone, empno) || HasFiledTIME_IN_OUT(dateminusone, empno) ||
                        IsDateHolidayBeforeAfter(empno, dateplusone) || IsDateHolidayBeforeAfter(empno, dateminusone) ||
                        HasFiledFTSForBeforeAfter(dateplusone, empno) || HasFiledFTSForBeforeAfter(dateminusone, empno) ||
                        HasFiledLeaveForBeforeAfter(dateplusone, empno) || HasFiledLeaveForBeforeAfter(dateminusone, empno) ||
                        HasFiledOBTForBeforeAfter(dateplusone, empno) || HasFiledOBTForBeforeAfter(dateminusone, empno) || isPiooner)
                        {

                            param.Add("TotHrs", "0");
                            //wrk = "";
                        }
                        else
                        {
                            holidaytype = holidaytype + "WOP";
                            param.Add("TotHrs", "0");
                            wrk = "";
                        }
                    }
                    else
                    {
                        //holidaytype = holidaytype + "WOP";
                        param.Add("TotHrs", "0");
                        //wrk = "";

                    }
                }
                else
                {
                    //DateTime dateplusone = date.AddDays(1);
                    //DateTime dateminusone = date.AddDays(1);
                    if (holidaytype == "LH")
                    {if (HasFiledTIME_IN_OUT(dateplusone, empno) || HasFiledTIME_IN_OUT(dateminusone, empno) ||
                        IsDateHolidayBeforeAfter(empno, dateplusone) || IsDateHolidayBeforeAfter(empno, dateminusone) ||
                        HasFiledFTSForBeforeAfter(dateplusone, empno) || HasFiledFTSForBeforeAfter(dateminusone, empno) ||
                        HasFiledLeaveForBeforeAfter(dateplusone, empno) || HasFiledLeaveForBeforeAfter(dateminusone, empno) ||
                        HasFiledOBTForBeforeAfter(dateplusone, empno) || HasFiledOBTForBeforeAfter(dateminusone, empno) || isPiooner)
                        {

                            param.Add("TotHrs", "0");
                            //wrk = "";
                        }
                        else
                        {
                            holidaytype = holidaytype + "WOP";
                            param.Add("TotHrs", "0");
                            wrk = "";
                        }
                    }
                    else
                    {
                        holidaytype = holidaytype + "WOP";
                        param.Add("TotHrs", "0");
                        wrk = "";
                    }

                }
            }
        }
        else
        {
            //DateTime dateplusone = date.AddDays(-1);
            //DateTime dateminusone = date.AddDays(-1);

            if (holidaytype == "LH")
            {
                //check dtr
                //check holiday
                //check isRestDay
                //check UA
                //check Leave
                //check OBT
                if (HasFiledTIME_IN_OUT(dateplusone, empno) || HasFiledTIME_IN_OUT(dateminusone, empno) ||
                IsDateHolidayBeforeAfter(empno, dateplusone) || IsDateHolidayBeforeAfter(empno, dateminusone) ||
                HasFiledFTSForBeforeAfter(dateplusone, empno) || HasFiledFTSForBeforeAfter(dateminusone, empno) ||
                HasFiledLeaveForBeforeAfter(dateplusone, empno) || HasFiledLeaveForBeforeAfter(dateminusone, empno) ||
                HasFiledOBTForBeforeAfter(dateplusone, empno) || HasFiledOBTForBeforeAfter(dateminusone, empno) || isPiooner)
                {

                    param.Add("TotHrs", "0");
                    wrk = "";
                }
                else
                {
                    holidaytype = holidaytype + "WOP";
                    param.Add("TotHrs", "0");
                    wrk = "";
                }

            }
            else if (holidaytype == "SH")
            {
                //if(!isMonthly)
                //{
                holidaytype = holidaytype + "WOP";
                param.Add("TotHrs", "0");
                wrk = "";
                //}
                //else
                //{
                //    param.Add("TotHrs", "0");
                //    wrk = "";
                //}

            }
            else
            {
                //param.Add("ManHrs", "0");
                param.Add("TotHrs", "0");
                wrk = "";
            }
            


        }
        




        param.Add("PayPeriod", "'" + codate + "'");
        //param.Add("Remarks", (noOut? "'NO OUT'":"'WRK'"));
        param.Add("ActivityCode", "'" + empno + "'");
        param.Add("ActivityName", "'" + _empinfo["emp_FullName"] + "'");
        param.Add("Reason", "'" + holidaytype + "'");
        remark = wrk + holidaytype + remark;
        param.Add("Remarks", "'" + remark + "'");
        param.Add("DDayName", "'" + date.ToString("dddd") + " REG'");
        //param.Add("Submit", "'N'");
        param.Add("Submit", "'Y'");
        param.Add("allowance", "0");
        param.Add("CutoffID", CutoffID);
        if (!HasDuplicate_DTS_Entry(empno, bussdate, CutoffID))
        {
            if (!(InsertQueryCommon(param, "TBL_DTSAE")))
                Console.WriteLine("Failed InsertDTSHoliday()");
        }
        else
        {
            UpdateDTSEntryParam(param, out param);
            cm.UpdateQueryCommon(param, "TBL_DTSAE", "BussDate = '" + bussdate + "' and CutoffID = " + CutoffID + " and EmpID = '" + empno + "' ");
        }

    }
    void InsertDTSSuspension(DateTime date, string empno, Dictionary<string, string> _empinfo, string codate, string CutoffID)
    {
        Dictionary<string, string> param = new Dictionary<string, string>();

        
        string bussdate = date.ToString("yyyy-MM-dd");
        string sched_TimeIn = "";
        string sched_TimeOut = "";

        if (_empinfo.Count > 3 && _empinfo.ContainsKey("Sched_TimeIn") && _empinfo.ContainsKey("Sched_TimeOut"))
        {
            sched_TimeIn = _empinfo["Sched_TimeIn"];
            sched_TimeOut = _empinfo["Sched_TimeOut"];

        }
        
        param.Clear();
        
        param.Add("BussDate", "'" + bussdate + "'");
        param.Add("BussDate2", "'" + bussdate + "'");
        param.Add("ShiftName", "'" + get_shiftname(empno, date) + "'");
        param.Add("EndDate", "'" + bussdate + "'");
        param.Add("EmpID", "'" + empno + "'");
        param.Add("Emp_Name", "'" + _empinfo["emp_FullName"] + "'");
        param.Add("Sched_TimeIn", "'" + sched_TimeIn + "'");
        param.Add("Sched_TimeOut", "'" + sched_TimeOut + "'");
        double manhrs = cm.get_Time_Difference(sched_TimeIn, sched_TimeOut);
        param.Add("ManHrs", "" + Math.Round(manhrs, 0) + "");
        param.Add("PayPeriod", "'" + codate + "'");
        param.Add("ActivityCode", "'" + empno + "'");
        param.Add("ActivityName", "'" + _empinfo["emp_FullName"] + "'");
        param.Add("DDayName", "'" + date.ToString("dddd") + " REG'");
        //param.Add("Submit", "'N'");
        param.Add("Submit", "'Y'");
        param.Add("CutoffID", CutoffID);
        param.Add("allowance", "0");
        param.Add("Remarks", "'SPD'");
        param.Add("DAbsent", "1");
    /*
     * 
     * 
     * 
     * 
     * */
    PROCEED:
        if (!HasDuplicate_DTS_Entry(empno, bussdate, CutoffID))
        {
            if (!(InsertQueryCommon(param, "TBL_DTSAE")))
                Console.WriteLine("Failed InsertDTSLeave()");
        }
        else
        {
            UpdateDTSEntryParam(param, out param);
            cm.UpdateQueryCommon(param, "TBL_DTSAE", "BussDate = '" + bussdate + "' and CutoffID = " + CutoffID + " and EmpID = '" + empno + "' ");
        }


    }
    //void InsertDTSLeave(DateTime date, string empno, string reason, Dictionary<string, string> _empinfo, string codate, string CutoffID, int leavetypeID, string leavekey)
    //{
    //    Dictionary<string, string> param = new Dictionary<string, string>();

    //    DateTime dtTryparse;
    //    string bussdate = date.ToString("yyyy-MM-dd");
    //    string sched_TimeIn = "";
    //    string sched_TimeOut = "";

    //    if (_empinfo.Count > 1)
    //    {
    //        sched_TimeIn = _empinfo["Sched_TimeIn"];
    //        sched_TimeOut = _empinfo["Sched_TimeOut"];

    //    }
    //    //bool tryDt;
    //    param.Clear();
    //    //DateTime DbussDate = DateTime.Parse(dr["BussDate"].ToString());
    //    //string bussdate = DbussDate.ToString("yyyy-MM-dd");
    //    //string insertDateIn = DateTime.Parse(dr["DateIn"].ToString()).ToString("yyyy-MM-dd");
    //    //tryDt = DateTime.TryParse(dr["DateIn"].ToString(), out dtTryparse);
    //    //string insertDateOut = dtTryparse.ToString("yyyy-MM-dd");
    //    //bool noOut = false;
    //    //if (dr["DateOut"].ToString() == null || dr["DateOut"].ToString() == "")
    //    //    noOut = true;
    //    param.Add("BussDate", "'" + bussdate + "'");
    //    param.Add("BussDate2", "'" + bussdate + "'");
    //    param.Add("ShiftName", "'" + get_shiftname(empno, date) + "'");
    //    param.Add("EndDate", "'" + bussdate + "'");
    //    //param.Add("DateIn","'"+insertDateIn+"'");
    //    //param.Add("DateOut","'"+insertDateOut+"'");
    //    param.Add("EmpID", "'" + empno + "'");
    //    param.Add("Emp_Name", "'" + _empinfo["emp_FullName"] + "'");
    //    //param.Add("AssignmentCode","'"++"'");
    //    param.Add("Sched_TimeIn", "'" + sched_TimeIn + "'");
    //    param.Add("Sched_TimeOut", "'" + sched_TimeOut + "'");
    //    //param.Add("Sched_RestDay","'"+dr["Sched_RestDay"].ToString()+"'");
    //    //param.Add("DTimeIn","'"+dr["DTimeIn"].ToString()+"'");
    //    //param.Add("DTimeOut","'"+dr["DTimeOut"].ToString()+"'");

    //    //if (!noOut)
    //    //{
    //    //    string strdtin = dr["DateIn"].ToString();
    //    //    string strdtout = dr["DateOut"].ToString();
    //    //    TimeSpan timein = TimeSpan.Parse(dr["DTimeIn"].ToString());
    //    //    TimeSpan timeout = TimeSpan.Parse(dr["DTimeOut"].ToString());
    //    //    DateTime dt = DateTime.Parse(strdtin) + timein;
    //    //    DateTime dtout = DateTime.Parse(strdtout) + timeout;
    //    //    double totalhrs = (dtout - dt).TotalHours;
    //    //    param.Add("TotHrs", "" + Math.Round(totalhrs, 0) + "");
    //    //}
    //    //else
    //    //    param.Add("TotHrs", "0");

    //    double manhrs = cm.get_Time_Difference(sched_TimeIn, sched_TimeOut);
    //    param.Add("ManHrs", "" + Math.Round(manhrs, 0) + "");
    //    param.Add("PayPeriod", "'" + codate + "'");
    //    //param.Add("Remarks", (noOut? "'NO OUT'":"'WRK'"));
    //    param.Add("ActivityCode", "'" + empno + "'");
    //    param.Add("ActivityName", "'" + _empinfo["emp_FullName"] + "'");
    //    param.Add("Reason", "'" + reason + "'");
    //    param.Add("Remarks", "'" + reason + "'");
    //    param.Add("DDayName", "'" + date.ToString("dddd") + " REG'");
    //    //param.Add("Submit", "'N'");
    //    param.Add("Submit", "'Y'");
    //    param.Add("CutoffID", CutoffID);
    //    param.Add("allowance", "0");
    //    param.Add("DAbsent", "1");
    //    //if (leavetypeID == 5 || leavetypeID == 7)
    //    //    param.Add("LWOP", "1");
    //    //else if (leavetypeID == -1)
    //    //    goto PROCEED;
    //    //else
    //    //    param.Add("LWP", "1");
    //    if (leavekey == "PLWOP" || leavekey == "SLWOP")
    //    {
    //        param.Add("LWOP", "1");
    //    }
    //    else
    //    {
    //        param.Add("LWP", "1");
    //    }
    ///*
    // * 
    // * 
    // * 
    // * 
    // * */
    //PROCEED:
    //    if (!HasDuplicate_DTS_Entry(empno, bussdate, CutoffID))
    //    {
    //        if (!(InsertQueryCommon(param, "TBL_DTSAESV")))
    //            Console.WriteLine("Failed InsertDTSLeave()");
    //    }
    //    else
    //        cm.UpdateQueryCommon(param, "TBL_DTSAESV", "BussDate = '" + bussdate + "' and CutoffID = " + CutoffID + " and EmpID = '" + empno + "' ");


    //}
    void InsertDTSFTS(DateTime date, string empno, string reason, Dictionary<string, string> _empinfo, string codate,string CutoffID)
    {
        Dictionary<string, string> param = new Dictionary<string, string>();
        string sched_TimeIn = "";
        string sched_TimeOut = "";

        if (_empinfo.Count > 1 && _empinfo.ContainsKey("Sched_TimeIn") && _empinfo.ContainsKey("Sched_TimeOut"))
        {
            sched_TimeIn = _empinfo["Sched_TimeIn"];
            sched_TimeOut = _empinfo["Sched_TimeOut"];

        }
        if (sched_TimeIn == "" || sched_TimeOut == "")
        {
            sched_TimeIn = "RD";
            sched_TimeOut = "RD";

            //goto AddtoDTS;
        }
        DateTime dtTryparse;
        string bussdate = date.ToString("yyyy-MM-dd");

        //string id = cm.GetSpecificDataFromDB("id", "TBL_FTS", "where EmpID='" + empno + "' and buss_date='" + date.ToString("yyyy-MM-dd") + "'").ToString();
        List<string> idrecs = new List<string>();
        idrecs = GetSpecificDataFromDBList1("id", "TBL_FTS", "where EmpID='" + empno + "' and buss_date='" + date.ToString("yyyy-MM-dd") + "' AND fts_Status = '1'");
        //idrecs = 

        foreach (string id in idrecs)
        {
            string type = cm.GetSpecificDataFromDB("fts_type", "TBL_FTS", "where id=" + id);
            string time = cm.GetSpecificDataFromDB("ftime", "TBL_FTS", "where id=" + id);
            #region param add
            //bool tryDt;
            param.Clear();
            //DateTime DbussDate = DateTime.Parse(dr["BussDate"].ToString());
            //string bussdate = DbussDate.ToString("yyyy-MM-dd");
            //string insertDateIn = DateTime.Parse(dr["DateIn"].ToString()).ToString("yyyy-MM-dd");
            //tryDt = DateTime.TryParse(dr["DateIn"].ToString(), out dtTryparse);
            //string insertDateOut = dtTryparse.ToString("yyyy-MM-dd");
            //bool noOut = false;
            //if (dr["DateOut"].ToString() == null || dr["DateOut"].ToString() == "")
            //    noOut = true;
            param.Add("BussDate", "'" + bussdate + "'");
            param.Add("BussDate2", "'" + bussdate + "'");
            param.Add("ShiftName", "'" + get_shiftname(empno, date) + "'");
            param.Add("EndDate", "'" + bussdate + "'");
            //param.Add("DateIn","'"+insertDateIn+"'");
            //param.Add("DateOut","'"+insertDateOut+"'");
            param.Add("EmpID", "'" + empno + "'");
            param.Add("Emp_Name", "'" + _empinfo["emp_FullName"] + "'");
            //param.Add("AssignmentCode","'"++"'");
            param.Add("Sched_TimeIn", "'" + sched_TimeIn + "'");
            param.Add("Sched_TimeOut", "'" + sched_TimeOut + "'");
            //param.Add("Sched_RestDay","'"+dr["Sched_RestDay"].ToString()+"'");
            if (type == "In")
            {
                param.Add("DateIn", "'" + bussdate + "'");
                param.Add("DateOut", "'" + bussdate + "'");
                if (!param.ContainsKey("DTimeIn")) param.Add("DTimeIn", "'" + time + "'");

                string dtimeout = cm.GetSpecificDataFromDB("DTimeOut", "TBL_DTR", " where BussDate = '" + bussdate + "' and EmpID = '" + empno + "' and Flag = 'O'");
                if (dtimeout != "") param.Add("DTimeOut", "'" + dtimeout + "'");
            }
            if (type == "Out")
            {
                param.Add("DateIn", "'" + bussdate + "'");
                param.Add("DateOut", "'" + bussdate + "'");
                if (!param.ContainsKey("DTimeOut")) param.Add("DTimeOut", "'" + time + "'");
                string dtimein = cm.GetSpecificDataFromDB("DTimeIn", "TBL_DTR", " where BussDate = '" + bussdate + "' and EmpID = '" + empno + "' and Flag = 'I'");
                if (dtimein != "") param.Add("DTimeIn", "'" + dtimein + "'");
            }

            //if (!noOut)
            //{
            //    string strdtin = dr["DateIn"].ToString();
            //    string strdtout = dr["DateOut"].ToString();
            //    TimeSpan timein = TimeSpan.Parse(dr["DTimeIn"].ToString());
            //    TimeSpan timeout = TimeSpan.Parse(dr["DTimeOut"].ToString());
            //    DateTime dt = DateTime.Parse(strdtin) + timein;
            //    DateTime dtout = DateTime.Parse(strdtout) + timeout;
            //    double totalhrs = (dtout - dt).TotalHours;
            //    param.Add("TotHrs", "" + Math.Round(totalhrs, 0) + "");
            //}
            //else
            //    param.Add("TotHrs", "0");

            double manhrs = cm.get_Time_Difference(sched_TimeIn, sched_TimeOut);
            param.Add("ManHrs", "" + Math.Round(manhrs, 0) + "");
            param.Add("PayPeriod", "'" + codate + "'");
            //param.Add("Remarks", (noOut? "'NO OUT'":"'WRK'"));
            param.Add("ActivityCode", "'" + empno + "'");
            param.Add("ActivityName", "'" + _empinfo["emp_FullName"] + "'");

            //TODO 10/09/2020
            string leave_reason = "";
            int leavetypeID;
            string leavekey = "";
            string ampm = "";
            bool isforleave = false;
            //param.Add("Reason", "'WRK UA'");
            //param.Add("Remarks", "'WRK UA'");

            if (((sched_TimeIn == "RD" && sched_TimeOut == "RD") || (sched_TimeIn == "" && sched_TimeOut == ""))
                    && date.DayOfWeek == DayOfWeek.Saturday && _empinfo["emp_Location"] == "1")
            { 
                param.Add("Reason", "'RDRP'");
                param.Add("Remarks", "'RDRP'");
            }
            else if (sched_TimeIn == "RD" && sched_TimeOut == "RD")
            {
                param.Add("Reason", "'RDP'");
                param.Add("Remarks", "'RDP'");
            }
            else
            {
                param.Add("Reason", "'WRK UA'");
                param.Add("Remarks", "'WRK UA'");
            }


            param.Add("DDayName", "'" + date.ToString("dddd") + " REG'");
            param.Add("Submit", "'Y'");
            //param.Add("Submit", "'N'");
            param.Add("allowance", "0");
            param.Add("CutoffID", CutoffID);

            /*
             * 
             * 
             * 
             * 
             * */
            if (!HasDuplicate_DTS_Entry(empno, bussdate))
            {
                if (!(InsertQueryCommon(param, "TBL_DTSAE")))
                    Console.WriteLine("Failed InsertDTSFTS()");
            }
            else
            {
                UpdateDTSEntryParam(param, out param);
                cm.UpdateQueryCommon(param, "TBL_DTSAE", "BussDate = '" + bussdate + "' and EmpID = '" + empno + "' ");
            }
                

            #endregion param add
        }//end of foreach

    }
    void InsertDTSFTS_not_in_use(DateTime date, string empno, string reason, Dictionary<string, string> _empinfo, string codate, string CutoffID, string ftstimeinout, string ftstype)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            string sched_TimeIn = "";
            string sched_TimeOut = "";
        string dtimein = "";
        string dtimeout = "";
        double totalhrs = 0;

        if (_empinfo.Count > 1 && _empinfo.ContainsKey("Sched_TimeIn") && _empinfo.ContainsKey("Sched_TimeOut"))
        {
                sched_TimeIn = _empinfo["Sched_TimeIn"];
                sched_TimeOut = _empinfo["Sched_TimeOut"];

            }
            DateTime dtTryparse;
            string bussdate = date.ToString("yyyy-MM-dd");

            //bool tryDt;
            param.Clear();
            //DateTime DbussDate = DateTime.Parse(dr["BussDate"].ToString());
            //string bussdate = DbussDate.ToString("yyyy-MM-dd");
            //string insertDateIn = DateTime.Parse(dr["DateIn"].ToString()).ToString("yyyy-MM-dd");
            //tryDt = DateTime.TryParse(dr["DateIn"].ToString(), out dtTryparse);
            //string insertDateOut = dtTryparse.ToString("yyyy-MM-dd");
            //bool noOut = false;
            //if (dr["DateOut"].ToString() == null || dr["DateOut"].ToString() == "")
            //    noOut = true;
            param.Add("BussDate", "'" + bussdate + "'");
            param.Add("BussDate2", "'" + bussdate + "'");
            param.Add("ShiftName", "'" + get_shiftname(empno, date) + "'");
            param.Add("EndDate", "'" + bussdate + "'");
            //param.Add("DateIn","'"+insertDateIn+"'");
            //param.Add("DateOut","'"+insertDateOut+"'");
            param.Add("EmpID", "'" + empno + "'");
            param.Add("Emp_Name", "'" + _empinfo["emp_FullName"] + "'");
            //param.Add("AssignmentCode","'"++"'");
            param.Add("Sched_TimeIn", "'" + sched_TimeIn + "'");
            param.Add("Sched_TimeOut", "'" + sched_TimeOut + "'");
            if(ftstype == "In")
            {
                param.Add("DTimeIn", "'" + ftstimeinout + "'");
            dtimeout = cm.GetSpecificDataFromDB("ftime", "TBL_FTS", " where EmpID = '" + empno + "' AND buss_date = '" + bussdate + "' AND fts_Status = 1");
            TimeSpan timeout = TimeSpan.Parse(dtimeout);
            TimeSpan timein = TimeSpan.Parse(ftstimeinout);
            totalhrs = (timeout - timein).TotalHours;


        }
            else if (ftstype == "Out")
            {
                param.Add("DTimeOut", "'" + ftstimeinout + "'");
                dtimein = cm.GetSpecificDataFromDB("DTimeIn", "TBL_DTSAE", " where EmpID = '" + empno + "' AND BussDate = '" + bussdate + "'");
                TimeSpan timeout = TimeSpan.Parse(ftstimeinout);
                TimeSpan timein = TimeSpan.Parse(dtimein);
                totalhrs = (timeout - timein).TotalHours;

        }

        //TimeSpan timein = TimeSpan.Parse(ftstimeinout);
        //DateTime dt = DateTime.Parse(bussdate) + timein;
        //TimeSpan timeout = TimeSpan.Parse(ftstimeinout);
        //DateTime dtout = DateTime.Parse(bussdate) + timeout;
        
        param.Add("TotHrs", "" + Math.Round(totalhrs, 0) + "");
        //param.Add("Sched_RestDay","'"+dr["Sched_RestDay"].ToString()+"'");
        //param.Add("DTimeIn","'"+dr["DTimeIn"].ToString()+"'");
        //param.Add("DTimeOut","'"+dr["DTimeOut"].ToString()+"'");

        //if (!noOut)
        //{
        //    string strdtin = dr["DateIn"].ToString();
        //    string strdtout = dr["DateOut"].ToString();
        //    TimeSpan timein = TimeSpan.Parse(dr["DTimeIn"].ToString());
        //    TimeSpan timeout = TimeSpan.Parse(dr["DTimeOut"].ToString());
        //    DateTime dt = DateTime.Parse(strdtin) + timein;
        //    DateTime dtout = DateTime.Parse(strdtout) + timeout;
        //    double totalhrs = (dtout - dt).TotalHours;
        //    param.Add("TotHrs", "" + Math.Round(totalhrs, 0) + "");
        //}
        //else
        //    param.Add("TotHrs", "0");

        double manhrs = cm.get_Time_Difference(sched_TimeIn, sched_TimeOut);
            param.Add("ManHrs", "" + Math.Round(manhrs, 0) + "");
            param.Add("PayPeriod", "'" + codate + "'");
            //param.Add("Remarks", (noOut? "'NO OUT'":"'WRK'"));
            param.Add("ActivityCode", "'" + empno + "'");
            param.Add("ActivityName", "'" + _empinfo["emp_FullName"] + "'");
            param.Add("Reason", "'FTS'");
            param.Add("Remarks", "'FTS'");
            param.Add("DDayName", "'" + date.ToString("dddd") + " REG'");
            //param.Add("Submit", "'N'");
            param.Add("Submit", "'Y'");
            param.Add("allowance", "0");
             param.Add("CutoffID", CutoffID);
        /*
         * 
         * 
         * 
         * 
         * */
            if (!HasDuplicate_DTS_Entry(empno, bussdate, CutoffID))
            {
                if (!(InsertQueryCommon(param, "TBL_DTSAE")))
                    Console.WriteLine("Failed InsertDTSFTS()");
            }
        else
        {
            UpdateDTSEntryParam(param, out param);
            cm.UpdateQueryCommon(param, "TBL_DTSAE", "BussDate = '" + bussdate + "' and CutoffID = " + CutoffID + " and EmpID = '" + empno + "' ");
        }

    }

        void getDTRTimeinout(string bussdate, string empno, out string dtrTimein, out string dtrTimeout)
        {
            dtrTimein = ""; dtrTimeout = "";
            string base_query = "Select * from TBL_DTR where EmpID = '"+empno+ "' and BussDate = '"+bussdate+"'";
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(base_query, conn);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
            if(dread["DTimeIn"].ToString() != "")
            {
                dtrTimein = dread["DTimeIn"].ToString();

            }
            if (dread["DTimeOut"].ToString() != "")
            {
                dtrTimeout = dread["DTimeOut"].ToString();

            }
            
            }
            dread.Close();

            conn.Close();


    }
    void InsertDTSOBT(DateTime date, string empno, string reason, Dictionary<string, string> _empinfo, string codate, string CutoffID, string otimein, string otimeout)
    {
        try
        {


            DateTime dtrin = new DateTime();
            DateTime dtrout = new DateTime();
            DateTime obtin = new DateTime();
            DateTime obtout = new DateTime();

            Dictionary<string, string> param = new Dictionary<string, string>();
            string sched_TimeIn = "";
            string sched_TimeOut = "";
            string dtin = "";
            string dtout = "";


            if (_empinfo.Count > 1 && _empinfo.ContainsKey("Sched_TimeIn") && _empinfo.ContainsKey("Sched_TimeOut"))
            {
                if (_empinfo.ContainsKey("Sched_TimeIn") && _empinfo.ContainsKey("Sched_TimeOut"))
                {
                    sched_TimeIn = _empinfo["Sched_TimeIn"];
                    sched_TimeOut = _empinfo["Sched_TimeOut"];
                }
            }
            if (sched_TimeIn == "" || sched_TimeOut == "")
            {
                sched_TimeIn = "RD";
                sched_TimeOut = "RD";

                //goto AddtoDTS;
            }

            DateTime dtTryparse;

            //09/06/2022 Jan. RD must no schedule assigned
            //if (sched_TimeIn == "" && sched_TimeOut == "")
            //{
            //    sched_TimeIn = otimein;

            //    sched_TimeOut = otimeout;

            //    //goto AddtoDTS;
            //}



            string bussdate = date.ToString("yyyy-MM-dd");

            //bool tryDt;
            param.Clear();
            //DateTime DbussDate = DateTime.Parse(dr["BussDate"].ToString());
            //string bussdate = DbussDate.ToString("yyyy-MM-dd");
            //string insertDateIn = DateTime.Parse(dr["DateIn"].ToString()).ToString("yyyy-MM-dd");
            //tryDt = DateTime.TryParse(dr["DateIn"].ToString(), out dtTryparse);
            //string insertDateOut = dtTryparse.ToString("yyyy-MM-dd");
            //bool noOut = false;
            //if (dr["DateOut"].ToString() == null || dr["DateOut"].ToString() == "")
            //    noOut = true;
            param.Add("BussDate", "'" + bussdate + "'");
            //param.Add("BussDate2", "'" + bussdate + "'");
            param.Add("ShiftName", "'" + get_shiftname(empno, date) + "'");
            param.Add("EndDate", "'" + bussdate + "'");
            //param.Add("DateIn","'"+insertDateIn+"'");
            //param.Add("DateOut","'"+insertDateOut+"'");
            param.Add("EmpID", "'" + empno + "'");
            param.Add("Emp_Name", "'" + _empinfo["emp_FullName"] + "'");
            //param.Add("AssignmentCode","'"++"'");
            param.Add("Sched_TimeIn", "'" + sched_TimeIn + "'");
            param.Add("Sched_TimeOut", "'" + sched_TimeOut + "'");
            param.Add("DAbsent", "0");
            //param.Add("Sched_RestDay","'"+dr["Sched_RestDay"].ToString()+"'");
            //iopen mo ulit ito
            string dtrtimein = "", dtrtimeout = "";
            getDTRTimeinout(bussdate, empno, out dtrtimein, out dtrtimeout);

            #region forOBT
            //dtr IN/OUT
            if (dtrtimein != "" && dtrtimeout != "")
            {
                dtrin = Convert.ToDateTime(dtrtimein);
                dtrout = Convert.ToDateTime(dtrtimeout);
                //OBT IN/OUT
                obtin = Convert.ToDateTime(otimein);
                obtout = Convert.ToDateTime(otimeout);

                if (TimeSpan.Compare(obtin.TimeOfDay, dtrin.TimeOfDay) == -1)
                {
                    dtin = otimein;

                }
                else
                {
                    dtin = dtrtimein;
                }
                if (TimeSpan.Compare(obtout.TimeOfDay, dtrout.TimeOfDay) == 1)
                {
                    dtout = otimeout;

                }
                else
                {
                    dtout = dtrtimeout;
                }
            }
            else
            {
                dtin = otimein;
                dtout = otimeout;
            }

        #endregion forOBT



        AddtoDTS:
            param.Add("DTimeIn", "'" + dtin + "'");
            param.Add("DTimeOut", "'" + dtout + "'");
            param.Add("DateIn", "'" + bussdate + "'");
            param.Add("DateOut", "'" + bussdate + "'");

            

            double manhrs = cm.get_Time_Difference(sched_TimeIn, sched_TimeOut);
            param.Add("ManHrs", "" + Math.Round(manhrs, 0) + "");
            param.Add("PayPeriod", "'" + codate + "'");
            //param.Add("Remarks", (noOut? "'NO OUT'":"'WRK'"));
            param.Add("ActivityCode", "'" + empno + "'");
            param.Add("ActivityName", "'" + _empinfo["emp_FullName"] + "'");

            //10/07/2021 put validation if holiday - Jan
            string remark = "WRK OBT";
            string holidaydesc = "", holidaytype = "";
            if (IsDateHoliday(empno, date, out holidaytype))
            {
                if (holidaytype == "LH")
                {
                    if (sched_TimeIn == "RD" && sched_TimeOut == "RD")
                    {
                        param.Add("Reason", "'WRKLHRD'");
                        param.Add("Remarks", "'WRKLHRD'");
                    }
                    else
                    {
                        param.Add("Reason", "'WRKLH'");
                        param.Add("Remarks", "'WRKLH'");
                    }
                }
                else if (holidaytype == "SH")
                {
                    if ((sched_TimeIn == "RD" && sched_TimeOut == "RD"))
                    {
                        param.Add("Reason", "'WRKSHRD'");
                        param.Add("Remarks", "'WRKSHRD'");
                    }
                    else
                    {
                        param.Add("Reason", "'WRKSH'");
                        param.Add("Remarks", "'WRKSH'");
                    }
                }

            }
            else
            {
                if (((sched_TimeIn == "RD" && sched_TimeOut == "RD") || (sched_TimeIn == "" && sched_TimeOut == "")) 
                    && date.DayOfWeek == DayOfWeek.Saturday && _empinfo["emp_Location"] == "1")
                {
                    param.Add("Reason", "'RDRP'");//Rest Day Regular Pay
                    param.Add("Remarks", "'RDRP'");
                }
                else if (sched_TimeIn == "RD" && sched_TimeOut == "RD" || (sched_TimeIn == "" && sched_TimeOut == ""))
                {
                    param.Add("Reason", "'RDP'");
                    param.Add("Remarks", "'RDP'");
                }
                else
                {
                    param.Add("Reason", "'" + remark + "'");
                    param.Add("Remarks", "'" + remark + "'");
                }

            }
            //param.Add("Reason", "'" + remark + "'");
            //param.Add("Remarks", "'" + remark + "'");
            param.Add("DDayName", "'" + date.ToString("dddd") + " REG'");
            //param.Add("Submit", "'N'");
            param.Add("Submit", "'Y'");
            param.Add("allowance", "0");
            param.Add("CutoffID", CutoffID);

            

            
            //param.Add("isMerged", "'Y'");
            if (!HasDuplicate_DTS_Entry(empno, bussdate, CutoffID))
            {
                if (!(InsertQueryCommon(param, "TBL_DTSAE")))
                    Console.WriteLine("Failed InsertDTSOBT()");
            }
            else
            {
                UpdateDTSEntryParam(param, out param);
                cm.UpdateQueryCommon(param, "TBL_DTSAE", "BussDate = '" + bussdate + "' and CutoffID = " + CutoffID + " and EmpID = '" + empno + "' ");
            }


        }
        finally
        {
            conn.Close();
        }
    }
    void InsertDTSOBTOLD(DateTime date, string empno, string reason, Dictionary<string, string> _empinfo, string codate, string CutoffID, string otimein, string otimeout)
        {
            DateTime dtrin = new DateTime();
            DateTime dtrout = new DateTime();
            DateTime obtin = new DateTime();
            DateTime obtout = new DateTime();

        Dictionary<string, string> param = new Dictionary<string, string>();
            string sched_TimeIn = "";
            string sched_TimeOut = "";
            string dtin = "";
            string dtout = "";


        if (_empinfo.Count > 1 && _empinfo.ContainsKey("Sched_TimeIn") && _empinfo.ContainsKey("Sched_TimeOut"))
        {
                sched_TimeIn = _empinfo["Sched_TimeIn"];
                sched_TimeOut = _empinfo["Sched_TimeOut"];
            //dtin = _empinfo["DTimeIn"];
            //dtout = _empinfo["DTimeOut"];

        }
        
        DateTime dtTryparse;

        if (sched_TimeIn == "" && sched_TimeOut == "")
        {
            sched_TimeIn = otimein;

            sched_TimeOut = otimeout;

            //goto AddtoDTS;
        }


        
        string bussdate = date.ToString("yyyy-MM-dd");

            //bool tryDt;
            param.Clear();
            //DateTime DbussDate = DateTime.Parse(dr["BussDate"].ToString());
            //string bussdate = DbussDate.ToString("yyyy-MM-dd");
            //string insertDateIn = DateTime.Parse(dr["DateIn"].ToString()).ToString("yyyy-MM-dd");
            //tryDt = DateTime.TryParse(dr["DateIn"].ToString(), out dtTryparse);
            //string insertDateOut = dtTryparse.ToString("yyyy-MM-dd");
            //bool noOut = false;
            //if (dr["DateOut"].ToString() == null || dr["DateOut"].ToString() == "")
            //    noOut = true;
            param.Add("BussDate", "'" + bussdate + "'");
            //param.Add("BussDate2", "'" + bussdate + "'");
            param.Add("ShiftName", "'" + get_shiftname(empno, date) + "'");
            param.Add("EndDate", "'" + bussdate + "'");
            //param.Add("DateIn","'"+insertDateIn+"'");
            //param.Add("DateOut","'"+insertDateOut+"'");
            param.Add("EmpID", "'" + empno + "'");
            param.Add("Emp_Name", "'" + _empinfo["emp_FullName"] + "'");
            //param.Add("AssignmentCode","'"++"'");
            param.Add("Sched_TimeIn", "'" + sched_TimeIn + "'");
            param.Add("Sched_TimeOut", "'" + sched_TimeOut + "'");
        //param.Add("Sched_RestDay","'"+dr["Sched_RestDay"].ToString()+"'");
        //iopen mo ulit ito
        string dtrtimein = "", dtrtimeout = "";
        getDTRTimeinout(bussdate, empno, out dtrtimein, out dtrtimeout);

        #region forOBT
        //dtr IN/OUT
        if (dtrtimein != "" && dtrtimeout != "")
        {
            dtrin = Convert.ToDateTime(dtrtimein);
            dtrout = Convert.ToDateTime(dtrtimeout);
            //OBT IN/OUT
            obtin = Convert.ToDateTime(otimein);
            obtout = Convert.ToDateTime(otimeout);

            if (TimeSpan.Compare(obtin.TimeOfDay, dtrin.TimeOfDay) == -1)
            {
                dtin = otimein;

            }
            else
            {
                dtin = dtrtimein;
            }
            if (TimeSpan.Compare(obtout.TimeOfDay, dtrout.TimeOfDay) == 1)
            {
                dtout = otimeout;

            }
            else
            {
                dtout = dtrtimeout;
            }
        }
        else
        {
            dtin = otimein;
            dtout = otimeout;
        }
    #endregion forOBT



    AddtoDTS:
        param.Add("DTimeIn", "'" + dtin + "'");
        param.Add("DTimeOut", "'" + dtout + "'");
        param.Add("DateIn", "'" + bussdate + "'");
        param.Add("DateOut", "'" + bussdate + "'");

        //if (!noOut)
        //{
        //    string strdtin = dr["DateIn"].ToString();
        //    string strdtout = dr["DateOut"].ToString();
        //    TimeSpan timein = TimeSpan.Parse(dr["DTimeIn"].ToString());
        //    TimeSpan timeout = TimeSpan.Parse(dr["DTimeOut"].ToString());
        //    DateTime dt = DateTime.Parse(strdtin) + timein;
        //    DateTime dtout = DateTime.Parse(strdtout) + timeout;
        //    double totalhrs = (dtout - dt).TotalHours;
        //    param.Add("TotHrs", "" + Math.Round(totalhrs, 0) + "");
        //}
        //else
        //    param.Add("TotHrs", "0");

        double manhrs = cm.get_Time_Difference(sched_TimeIn, sched_TimeOut);
            param.Add("ManHrs", "" + Math.Round(manhrs, 0) + "");
            param.Add("PayPeriod", "'" + codate + "'");
            //param.Add("Remarks", (noOut? "'NO OUT'":"'WRK'"));
            param.Add("ActivityCode", "'" + empno + "'");
            param.Add("ActivityName", "'" + _empinfo["emp_FullName"] + "'");
            param.Add("Reason", "'OBT'");
            param.Add("Remarks", "'OBT'");
            param.Add("DDayName", "'" + date.ToString("dddd") + " REG'");
            //param.Add("Submit", "'N'");
            param.Add("Submit", "'Y'");
            param.Add("allowance", "0");
            param.Add("CutoffID", CutoffID);

        /*
         * 
         * 
         * 
         * 
         * */
            if (!HasDuplicate_DTS_Entry(empno, bussdate, CutoffID))
            {
                if (!(InsertQueryCommon(param, "TBL_DTSAE")))
                    Console.WriteLine("Failed InsertDTSOBT()");
            }
        else
        {
            UpdateDTSEntryParam(param, out param);
            cm.UpdateQueryCommon(param, "TBL_DTSAE", "BussDate = '" + bussdate + "' and CutoffID = " + CutoffID + " and EmpID = '" + empno + "' ");
        }

    }
        

        void InsertDTSfromDTR(DataTable dtr_DT, string codate, string CutoffID, Dictionary<string, string> _empinfo)
        {
            #region DTR To DTS direct

            Dictionary<string, string> param = new Dictionary<string, string>();
            foreach (DataRow dr in dtr_DT.Rows)
            {
            string remark = "WRK";
            DateTime dtTryparse;
                bool tryDt;
                param.Clear();
                DateTime DbussDate = DateTime.Parse(dr["BussDate"].ToString());
                string bussdate = DbussDate.ToString("yyyy-MM-dd");
                string insertDateIn = DateTime.Parse(dr["DateIn"].ToString()).ToString("yyyy-MM-dd");
                tryDt = DateTime.TryParse(dr["DateIn"].ToString(), out dtTryparse);
                string insertDateOut = dtTryparse.ToString("yyyy-MM-dd");
                bool noOut = false;
                if (dr["DateOut"].ToString() == null || dr["DateOut"].ToString() == "")
                    noOut = true;
                param.Add("BussDate", "'" + bussdate + "'");
                param.Add("BussDate2", "'" + bussdate + "'");
                param.Add("ShiftName", "'" + get_shiftname(dr["EmpID"].ToString(), DbussDate) + "'");
                param.Add("EndDate", "'" + bussdate + "'");
                param.Add("DateIn", "'" + insertDateIn + "'");
                param.Add("DateOut", "'" + insertDateOut + "'");
                param.Add("EmpID", "'" + dr["EmpID"].ToString() + "'");
                param.Add("Emp_Name", "'" + dr["Emp_Name"].ToString() + "'");
            //param.Add("AssignmentCode","'"++"'");
            string schedtimein = ((dr["Sched_TimeIn"].ToString() == "RD") ? dr["DTimeIn"].ToString() : dr["Sched_TimeIn"].ToString());
            string schedtimeout = ((dr["Sched_TimeOut"].ToString() == "RD") ? dr["DTimeOut"].ToString() : dr["Sched_TimeOut"].ToString());
                schedtimein = _empinfo["Sched_TimeIn"];
                schedtimeout = _empinfo["Sched_TimeOut"];
            if (schedtimein == "RD" || schedtimeout == "RD" || schedtimein == "" || schedtimeout == "")
            {
                schedtimein = dr["DTimeIn"].ToString();
                schedtimeout = dr["DTimeOut"].ToString();
                if (DbussDate.DayOfWeek == DayOfWeek.Saturday && _empinfo["emp_Location"] == "1")
                {
                    remark = "RDRP";
                }
            }
            else
            {
                remark = "WRK";
            }
            //param.Add("Sched_TimeIn", "'" + dr["Sched_TimeIn"].ToString() + "'");
                //param.Add("Sched_TimeOut", "'" + dr["Sched_TimeOut"].ToString() + "'");
            param.Add("Sched_TimeIn", "'" + schedtimein + "'");
            param.Add("Sched_TimeOut", "'" + schedtimeout + "'");
            //param.Add("Sched_RestDay","'"+dr["Sched_RestDay"].ToString()+"'");
            param.Add("DTimeIn", "'" + dr["DTimeIn"].ToString() + "'");
                param.Add("DTimeOut", "'" + dr["DTimeOut"].ToString() + "'");

                if (!noOut)
                {
                    string strdtin = dr["DateIn"].ToString();
                    string strdtout = dr["DateOut"].ToString();
                    TimeSpan timein = TimeSpan.Parse(dr["DTimeIn"].ToString());
                    TimeSpan timeout = TimeSpan.Parse(dr["DTimeOut"].ToString());
                    DateTime dt = DateTime.Parse(strdtin) + timein;
                    DateTime dtout = DateTime.Parse(strdtout) + timeout;
                    double totalhrs = (dtout - dt).TotalHours;
                    param.Add("TotHrs", "" + Math.Round(totalhrs, 0) + "");
                }
                else
                    param.Add("TotHrs", "0");

                double manhrs = cm.get_Time_Difference(dr["Sched_TimeIn"].ToString(), dr["Sched_TimeOut"].ToString());
                param.Add("ManHrs", "" + Math.Round(manhrs, 0) + "");
                param.Add("PayPeriod", "'" + codate + "'");
                param.Add("ActivityCode", "'" + dr["EmpID"].ToString() + "'");
                param.Add("ActivityName", "'" + dr["Emp_Name"].ToString() + "'");
                param.Add("Reason", (noOut ? "'NO'" : "'"+ remark + "'"));
                param.Add("Remarks", (noOut ? "'NO'" : "'"+ remark + "'"));
            param.Add("DAbsent", "0");//10/22/2021

            param.Add("DDayName", "'" + DbussDate.ToString("dddd") + " REG'");
                //param.Add("Submit", "'N'");
                param.Add("Submit", "'Y'");
                param.Add("allowance", "0");
                param.Add("CutoffID", CutoffID);

            /*
             * 
             * 
             * 
             * 
             * */
            if (!HasDuplicate_DTS_Entry(dr["EmpID"].ToString(), bussdate, CutoffID))
            {
                        if (!(InsertQueryCommon(param, "TBL_DTSAE")))
                            Console.WriteLine("Failed InsertDTSfromDTR()");
                    }
            else
            {
                UpdateDTSEntryParam(param, out param);
                cm.UpdateQueryCommon(param, "TBL_DTSAE", "BussDate = '" + bussdate + "' and CutoffID = " + CutoffID + " and EmpID = '" + dr["EmpID"].ToString() + "' ");
            }



                }
            #endregion DTR To DTS direct

        }

        void InsertDTSNOEntry(DateTime date, string empno, string reason, Dictionary<string, string> _empinfo, string codate, string CutoffID)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            string sched_TimeIn = "";
            string sched_TimeOut = "";

        if (_empinfo.Count > 3 && _empinfo.ContainsKey("Sched_TimeIn") && _empinfo.ContainsKey("Sched_TimeOut"))
        {
                sched_TimeIn = _empinfo["Sched_TimeIn"];
                sched_TimeOut = _empinfo["Sched_TimeOut"];

            }
            if (_empinfo["schedID"] == "0")
                reason = "RD";

            DateTime dtTryparse;
            string bussdate = date.ToString("yyyy-MM-dd");

            //bool tryDt;
            param.Clear();
            //DateTime DbussDate = DateTime.Parse(dr["BussDate"].ToString());
            //string bussdate = DbussDate.ToString("yyyy-MM-dd");
            //string insertDateIn = DateTime.Parse(dr["DateIn"].ToString()).ToString("yyyy-MM-dd");
            //tryDt = DateTime.TryParse(dr["DateIn"].ToString(), out dtTryparse);
            //string insertDateOut = dtTryparse.ToString("yyyy-MM-dd");
            //bool noOut = false;
            //if (dr["DateOut"].ToString() == null || dr["DateOut"].ToString() == "")
            //    noOut = true;
            param.Add("BussDate", "'" + bussdate + "'");
            param.Add("BussDate2", "'" + bussdate + "'");
            param.Add("ShiftName", "'" + get_shiftname(empno, date) + "'");
            param.Add("EndDate", "'" + bussdate + "'");
            //param.Add("DateIn","'"+insertDateIn+"'");
            //param.Add("DateOut","'"+insertDateOut+"'");
            param.Add("EmpID", "'" + empno + "'");
            param.Add("Emp_Name", "'" + _empinfo["emp_FullName"] + "'");
            //param.Add("AssignmentCode","'"++"'");
            param.Add("Sched_TimeIn", "'" + sched_TimeIn + "'");
            param.Add("Sched_TimeOut", "'" + sched_TimeOut + "'");
        param.Add("CutoffID", CutoffID);
        //param.Add("Sched_RestDay","'"+dr["Sched_RestDay"].ToString()+"'");
        //param.Add("DTimeIn","'"+dr["DTimeIn"].ToString()+"'");
        //param.Add("DTimeOut","'"+dr["DTimeOut"].ToString()+"'");

        //if (!noOut)
        //{
        //    string strdtin = dr["DateIn"].ToString();
        //    string strdtout = dr["DateOut"].ToString();
        //    TimeSpan timein = TimeSpan.Parse(dr["DTimeIn"].ToString());
        //    TimeSpan timeout = TimeSpan.Parse(dr["DTimeOut"].ToString());
        //    DateTime dt = DateTime.Parse(strdtin) + timein;
        //    DateTime dtout = DateTime.Parse(strdtout) + timeout;
        //    double totalhrs = (dtout - dt).TotalHours;
        //    param.Add("TotHrs", "" + Math.Round(totalhrs, 0) + "");
        //}
        //else
        //    param.Add("TotHrs", "0");

        double manhrs = cm.get_Time_Difference(sched_TimeIn, sched_TimeOut);
            param.Add("ManHrs", "" + Math.Round(manhrs, 0) + "");
            param.Add("PayPeriod", "'" + codate + "'");
            //param.Add("Remarks", (noOut? "'NO OUT'":"'WRK'"));
            param.Add("ActivityCode", "'" + empno + "'");
            param.Add("ActivityName", "'" + _empinfo["emp_FullName"] + "'");
            param.Add("Reason", "'" + reason + "'");
            param.Add("Remarks", "'" + reason + "'");
            param.Add("DDayName", "'" + date.ToString("dddd") + " REG'");
            //param.Add("Submit", "'N'");//Default submit to 'N'
            param.Add("Submit", "'Y'");
            param.Add("allowance", "0");
            param.Add("DAbsent", reason=="ABS"? "1":"0");
            

        /*
         * 
         * 
         * 
         * 
         * */
        if (!HasDuplicate_DTS_Entry(empno, bussdate, CutoffID))
        {
                if (!(InsertQueryCommon(param, "TBL_DTSAE")))
                    Console.WriteLine("Failed InsertDTSLeave()");
            }
        else
        {
            UpdateDTSEntryParam(param, out param);
            cm.UpdateQueryCommon(param, "TBL_DTSAE", "BussDate = '" + bussdate + "' and CutoffID = " + CutoffID + " and EmpID = '" + empno + "' ");
        }
            

        }



        Dictionary<string, string> UpdateDTSRestDay(DateTime date, Dictionary<string, string> dtsinfo, Dictionary<string, string> param,bool isdoublh)
        {
        string holidaytype = "";
        bool IsMoreThan8hrs = false;
        double OTNDHours = 0;
        double RegNDHrs = getRegNDHrs(dtsinfo);
        //double ot_HoursAM = get_OT_HoursAM(date, dtsinfo["EmpID"]);
        double ot_Hours = get_OT_HoursNew(date, dtsinfo["EmpID"], out IsMoreThan8hrs, out OTNDHours);
        if (IsDateHoliday(dtsinfo["EmpID"], date, out holidaytype))
        {
            if (holidaytype == "LH")
            {
                if (isdoublh)
                {
                    param.Add("DOUBRSTOT", "" + ot_Hours + "");
                    param.Add("DOUBLEGRSTND", "" + RegNDHrs + "");
                    param.Add("DOUBRSTNDOT", "" + OTNDHours + "");
                }
                    
                else
                {
                    param.Add("RDLHOT", "" + ot_Hours + "");
                    param.Add("RDLHNDHrs", "" + RegNDHrs + "");
                    param.Add("RDLHOTND", "" + OTNDHours + "");
                }
                    
                param.Add("RDLHOT8HRS", "" + (IsMoreThan8hrs ? 8 : ot_Hours) + "");
               

                //param.Add("RDLHOTAM", "" + Math.Round(ot_HoursAM) + "");
                //param.Add("RDLHOTNDAM", "" + Math.Round(ot_HoursAM) + "");
                
                    

            }
            else if (holidaytype == "SH")
            {
                param.Add("RDSHOT", "" + ot_Hours + "");
                param.Add("RDSHOT8HRS", "" + (IsMoreThan8hrs ? 8 : ot_Hours) + "");
                param.Add("RDSHOTND", "" + OTNDHours + "");

                //param.Add("RDSHOTAM", "" + Math.Round(ot_HoursAM) + "");
                //param.Add("RDSHOTNDAM", "" + Math.Round(ot_HoursAM) + "");
                param.Add("RDSHNDHrs", "" + RegNDHrs + "");

            }
            else
            {
                param.Add("RDOT", "" +ot_Hours + "");
                param.Add("RDOT8HRS", "" + (IsMoreThan8hrs ? 8 : ot_Hours) + "");
                param.Add("RDOTND", "" + OTNDHours + "");

                //param.Add("RDOTAM", "" + Math.Round(ot_HoursAM) + "");
                //param.Add("RDOTNDAM", "" + Math.Round(ot_HoursAM) + "");
                param.Add("RDND", "" + RegNDHrs + "");
            }
        }
        else
        {
            param.Add("RDOT", "" + ot_Hours + "");
            param.Add("RDOT8HRS", "" + (IsMoreThan8hrs ? 8 : ot_Hours) + "");
            param.Add("RDOTND", "" + OTNDHours + "");
            param.Add("RDND", "" + RegNDHrs + "");
        }
        return param;
    }
    Dictionary<string, string> UpdateDTSHoliday(DateTime date, Dictionary<string, string> dtsinfo, Dictionary<string, string> param, string holidaytype, bool isdoublh)
    {
        bool IsMoreThan8hrs = false;
        double NDOTHours = 0;
        double RegNDHrs = getRegNDHrs(dtsinfo);
        //double ot_HoursAM = get_OT_HoursAM(date, dtsinfo["EmpID"]);
        double ot_Hours = get_OT_HoursNew(date, dtsinfo["EmpID"], out IsMoreThan8hrs, out NDOTHours);
        if (holidaytype == "LH")
        {
            
            if (isdoublh)
            {
                param.Add("DOUBLEGOT", "" + ot_Hours + "");
                param.Add("DOUBLEGND", "" + RegNDHrs + "");
                param.Add("DOUBLEGNDOT", "" + NDOTHours + "");
            }
            else
            {
                param.Add("LHOT", "" + ot_Hours + "");
                param.Add("LHNDHrs", "" + RegNDHrs + "");
                param.Add("LHOTND", "" + NDOTHours + "");
            }
                
            param.Add("LHOT8HRS", "" + (IsMoreThan8hrs ? 8 : ot_Hours) + "");
            


            //param.Add("LHOTAM", "" + Math.Round(ot_HoursAM) + "");
            //param.Add("LHOTNDAM", "" + Math.Round(ot_HoursAM) + "");
           
                

        }

        if (holidaytype == "SH")
        {
            param.Add("SHOT", "" + ot_Hours + "");
            param.Add("SHOT8HRS", "" + (IsMoreThan8hrs ? 8 : ot_Hours) + "");
            param.Add("SHOTND", "" + NDOTHours + "");
            param.Add("SHNDHrs", "" + RegNDHrs + "");

            //param.Add("SHOTAM", "" + Math.Round(ot_HoursAM) + "");
            //param.Add("SHOTNDAM", "" + Math.Round(ot_HoursAM) + "");
        }

        return param;
    }

    Dictionary<string, string> UpdateDTSReg(DateTime date, Dictionary<string, string> dtsinfo, Dictionary<string, string> param, bool isdoublh)
    {
        bool IsMoreThan8hrs = false;
        double NDOTHours = 0;
        double RegNDHrs = getRegNDHrs(dtsinfo);
        //double ot_HoursAM = get_OT_HoursAM(date, dtsinfo["EmpID"]);
        double ot_Hours = get_OT_HoursNew(date, dtsinfo["EmpID"], out IsMoreThan8hrs, out NDOTHours);

        param.Add("RegOT", "" + ot_Hours + "");//total othrs including ND if meron
        //param.Add("RegOT8HRS", "" + Math.Round((IsMoreThan8hrs ? 8 : ot_Hours)) + "");
        param.Add("RegOTND", "" + NDOTHours + "");//total ND Hrs exclude yung RegOT dito 
        //param.Add("RegOTAM", "" + Math.Round(ot_HoursAM) + "");
        //param.Add("RegOTNDAM", "" + Math.Round(ot_HoursAM) + "");
        param.Add("RegNDHrs", "" + RegNDHrs + "");//RegNDHrs is based sa schedtimein and schedtimeout

        return param;

    }

    double get_OT_HoursAM(DateTime date, string empno)
    {
        double ot_hrs = 0;
        Dictionary<string, string> OT_info = new Dictionary<string, string>();
        OT_info = cm.GetTableDict("TBL_OVERTIME", " where EmpID = '" + empno + "' and OTDate = '" + date.ToString("yyyy-MM-dd") + "' AND ot_Status = '1' AND ot_Type = 'IN'");
        if (OT_info.Count < 1)
        {
            goto EXIT_RET;
        }
        string strHrs = OT_info["ot_hours"];
        ot_hrs = Convert.ToDouble(strHrs);
    EXIT_RET:
        return ot_hrs;
    }
    double get_OT_Hours(DateTime date, string empno, out bool IsMoreThan8hrs, out double NDHours)
        {
            IsMoreThan8hrs = false;
            NDHours = 0;
            double ot_hrs = 0;
            Dictionary<string, string> OT_info = new Dictionary<string, string>();
        //OT_info = cm.GetTableDict("TBL_OVERTIME", " where EmpID = '" + empno + "' and OTDate = '" + date.ToString("yyyy-MM-dd") + "'");
        OT_info = cm.GetTableDict("TBL_OVERTIME", " where EmpID = '" + empno + "' and OTDate = '" + date.ToString("yyyy-MM-dd") + "' AND ot_Status = '1' AND ot_Type = 'OUT'");
        if (OT_info.Count < 1)
            {
                goto EXIT_RET;
            }
            string strHrs = OT_info["ot_hours"];
            ot_hrs = Convert.ToDouble(strHrs);
            if (ot_hrs > 8)
                IsMoreThan8hrs = true;
        DateTime timeout = DateTime.Parse(OT_info["OTDate"]);
            TimeSpan ts10 = new TimeSpan(22, 0, 0);
            DateTime timeout10 = timeout.Date + ts10;
            TimeSpan ts = TimeSpan.Parse(OT_info["ot_TimeOut"]);
            timeout = timeout.Date + ts;

            if (timeout > timeout10)
            {
                NDHours = timeout.Subtract(timeout10).TotalHours;
            }

        EXIT_RET:
            return ot_hrs;
        }
    double get_OT_HoursNew(DateTime date, string empno, out bool IsMoreThan8hrs, out double NDHours)
    {
        IsMoreThan8hrs = false;
        NDHours = 0;
        double ot_hrs = 0;
        Dictionary<string, string> OT_info = new Dictionary<string, string>();
        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand("Select * from TBL_OVERTIME where EmpID = '" + empno + "' and OTDate = '" + date.ToString("yyyy-MM-dd") + "' AND ot_Status = '1'", conn);
        dread = cmd.ExecuteReader();
        while (dread.Read())
        {
            string strHrs = dread["ot_hours"].ToString();
            ot_hrs = ot_hrs + Convert.ToDouble(strHrs);
            if (ot_hrs > 8)
                IsMoreThan8hrs = true;

            //IN
            DateTime timein = DateTime.Parse(dread["OTDate"].ToString());
            TimeSpan tsTimeIn = TimeSpan.Parse(dread["ot_Time"].ToString());
            TimeSpan ts6 = new TimeSpan(6, 0, 0);
            DateTime timein6 = timein.Date + ts6;
            timein = timein.Date + tsTimeIn;


            //OUT
            DateTime timeout = DateTime.Parse(dread["OTDate"].ToString());
            TimeSpan ts10 = new TimeSpan(22, 0, 0);
            DateTime timeout10 = timeout.Date + ts10;
            TimeSpan ts = TimeSpan.Parse(dread["ot_TimeOut"].ToString());
            timeout = timeout.Date + ts;

            if (timeout > timeout10)
            {
                NDHours = NDHours + timeout.Subtract(timeout10).TotalHours;
            }
            if (timein < timein6)
            {
                NDHours = NDHours + timein6.Subtract(timein).TotalHours;
            }

        }
        dread.Close();
        conn.Close();
        ot_hrs = ot_hrs - NDHours;
    EXIT_RET:
        return ot_hrs;
    }
    double getRegNDHrs(Dictionary<string, string> dtsInfo)
    {
        double NDHrs = 0;
        bool noOut = false;
        if (dtsInfo["DTimeOut"] == null || dtsInfo["DTimeOut"] == "" || dtsInfo["DateIn"] == null || dtsInfo["DateIn"] == "" || dtsInfo["DateOut"] == null || dtsInfo["DateOut"] == "" || dtsInfo["DTimeIn"] == null || dtsInfo["DTimeIn"] == "")
            noOut = true;
        if (!noOut)
        {
            TimeSpan schedtimein = new TimeSpan();
            TimeSpan schedtimeout = new TimeSpan();
            string strdtin = dtsInfo["DateIn"];
            string strdtout = dtsInfo["DateOut"];
            string strsched_TimeIn = dtsInfo["Sched_TimeIn"];
            string strsched_TimeOut = dtsInfo["Sched_TimeOut"];
            TimeSpan timein = TimeSpan.Parse(dtsInfo["DTimeIn"]);
            TimeSpan timeout = TimeSpan.Parse(dtsInfo["DTimeOut"]);
            if (strsched_TimeIn == "RD" || strsched_TimeOut == "RD")
            {
                schedtimein = TimeSpan.Parse(dtsInfo["DTimeIn"]);
                schedtimeout = TimeSpan.Parse(dtsInfo["DTimeOut"]);
            }
            else
            {
                schedtimein = TimeSpan.Parse(dtsInfo["Sched_TimeIn"]);
                schedtimeout = TimeSpan.Parse(dtsInfo["Sched_TimeOut"]);
            }
            DateTime dt = DateTime.Parse(strdtin) + (timein >= schedtimein ? timein : schedtimein);
            DateTime dtout = DateTime.Parse(strdtout) + (timeout <= schedtimeout ? timeout : schedtimeout);
            if (timein > timeout)
            {
                dtout = dtout.AddDays(1);
            }
            if (timeout > schedtimeout)
            {
                
                TimeSpan ts10 = new TimeSpan(22, 0, 0);
                DateTime timeout10 = DateTime.Parse(strdtin).Date + ts10;
                if (dtout > timeout10)
                {
                    NDHrs = dtout.Subtract(timeout10).TotalHours;
                }
            }
            if (timein < schedtimein)
            {
                TimeSpan ts6 = new TimeSpan(6, 0, 0);
                DateTime timein6 = dt.Date + ts6;
                if (dt < timein6)
                {
                    NDHrs = NDHrs + timein6.Subtract(dt).TotalHours;
                }
            }
        }

        return NDHrs;
    }
    Dictionary<string, string> compute_Work_Hours(Dictionary<string, string> dtsInfo, Dictionary<string, string> tempParam, DateTime datenow, out bool IsOverTime)
        {

        //TotHrs - Total Hours -> (no of hours)
        //Lates - Lates ? = datetime? -> (no of hours)
        //Latesmin - late minutes = 8 minutes
        //UT - undertime? = datetime? -> (no of hours)
        //UTmin - undertime minutes = 8 minutes
        //OTHrs - Total number of overtime rendered -> (no of hours)
        double manhrs = cm.get_Time_Difference(dtsInfo["Sched_TimeIn"], dtsInfo["Sched_TimeOut"]);
        double NDHrs = 0;
        IsOverTime = false;
            bool noOut = false;
            //if (dtsInfo["DTimeOut"] == null || dtsInfo["DTimeOut"] == "")
            //    noOut = true;
        if (dtsInfo["DTimeOut"] == null || dtsInfo["DTimeOut"] == "" || dtsInfo["DateIn"] == null || dtsInfo["DateIn"] == "" || dtsInfo["DateOut"] == null || dtsInfo["DateOut"] == "" || dtsInfo["DTimeIn"] == null || dtsInfo["DTimeIn"] == "")
            noOut = true;

        if (!noOut)
            {
            TimeSpan schedtimein = new TimeSpan();
            TimeSpan schedtimeout = new TimeSpan();
            string strdtin = dtsInfo["DateIn"];
                string strdtout = dtsInfo["DateOut"];
                string strsched_TimeIn = dtsInfo["Sched_TimeIn"];
                string strsched_TimeOut = dtsInfo["Sched_TimeOut"];

            //07/25/2022 Jan Wong. remove seconds on time in time out
            //string strtimein = string.Format("{0:00}:{1:00}", ts.Hours, ts.Minutes) // it should display 02:05
            //    string strtimeout = string.Format("{0:00}:{1:00}", ts.Hours, ts.Minutes) // it should display 02:05
                TimeSpan timein = TimeSpan.Parse(dtsInfo["DTimeIn"]);
                TimeSpan timeout = TimeSpan.Parse(dtsInfo["DTimeOut"]);
            timein = new TimeSpan(timein.Hours, timein.Minutes, 0);
            timeout = new TimeSpan(timeout.Hours, timeout.Minutes, 0);
            if (strsched_TimeIn == "RD" || strsched_TimeOut == "RD" || strsched_TimeIn == "" || strsched_TimeOut == "")
            {
                schedtimein = TimeSpan.Parse(dtsInfo["DTimeIn"]);
                schedtimeout = TimeSpan.Parse(dtsInfo["DTimeOut"]);
            }
            else
            {
                schedtimein = TimeSpan.Parse(dtsInfo["Sched_TimeIn"]);
                schedtimeout = TimeSpan.Parse(dtsInfo["Sched_TimeOut"]);
            }

            /*
             * 
             * OLD
             * 
             * 
            DateTime dt = DateTime.Parse(strdtin) + (timein >= schedtimein ? timein : schedtimein);
                DateTime dtout = DateTime.Parse(strdtout) + (timeout <= schedtimeout ? timeout : schedtimeout);
            if (timein > timeout)
            {
                dtout = dtout.AddDays(1);
            }
            */

            DateTime defaultdt = DateTime.Parse(strdtin) + (timein);
            DateTime defaultdtout = DateTime.Parse(strdtout) + (timeout);
            DateTime scheddt = DateTime.Parse(strdtin) + (schedtimein);
            DateTime scheddtout = DateTime.Parse(strdtout) + (schedtimeout);
            if (timein >= timeout)
            {
                defaultdtout = defaultdtout.AddDays(1);
            }
            if (schedtimein >= schedtimeout)
            {
                scheddtout = scheddtout.AddDays(1);
            }
            DateTime dt = DateTime.Parse(strdtin) + (defaultdt >= scheddt ? timein : schedtimein);
            DateTime dtout = (defaultdtout <= scheddtout ? defaultdtout : scheddtout);

            //New 04/20/2022
            TimeSpan start = new TimeSpan(12, 0, 0); //12 o'clock
            TimeSpan end = new TimeSpan(13, 10, 0); //1 o'clock
            TimeSpan tsdtin = dt.TimeOfDay;
            TimeSpan tsdtout = dtout.TimeOfDay;

            if ((tsdtin >= start) && (tsdtin <= end))
            {
                //TimeSpan ts = new TimeSpan(13, 00, 0);
                TimeSpan ts = new TimeSpan(12, 00, 0);//07/18/2022 Jan Wong
                dt = dt.Date + ts;
                timein = ts;
            }
            if ((tsdtout >= start) && (tsdtout <= end))
            {
                //TimeSpan ts = new TimeSpan(13, 00, 0); 08/30/2022 Jan change from 1:00PM to 1:10PM
                TimeSpan ts = new TimeSpan(13, 00, 0);

                dtout = dtout.Date + ts;
                timeout = ts;
            }
            //END New 04/20/2022

            //10/07/2021 put validation and exception for RDP - Jan
            //double totalhrs = (dtout - dt).TotalHours;
            double totalhrs = 0;
            if (dtsInfo["Remarks"].ToString() == "RDP" || (strsched_TimeIn == "RD" && strsched_TimeOut == "RD"))
            {
                //totalhrs = (dtout - dt).TotalHours;
                //totalhrs = totalhrs >= 5 ? totalhrs - 1 : totalhrs;
                //totalhrs = totalhrs < 0 ? 0 : totalhrs;
                if (cm.ItemExist("TBL_OBT", "id", "where EmpID = '" + dtsInfo["EmpID"].ToString() + "' AND OBT_Status = '1' AND '" + datenow.ToString("yyyy-MM-dd") + "' between DateFrom AND DateTo"))
                {
                    totalhrs = (dtout - dt).TotalHours >= 5 ? (dtout - dt).TotalHours - 1 : (dtout - dt).TotalHours;
                    totalhrs = totalhrs < 0 ? 0 : totalhrs;
                }
                else if (cm.ItemExist("TBL_FTS", "id", "where EmpID = '" + dtsInfo["EmpID"].ToString() + "' AND fts_Status = '1' AND buss_date = '" + datenow.ToString("yyyy-MM-dd") + "'"))
                {
                    totalhrs = (dtout - dt).TotalHours >= 5 ? (dtout - dt).TotalHours - 1 : (dtout - dt).TotalHours;
                    totalhrs = totalhrs < 0 ? 0 : totalhrs;
                }
                else
                {
                    //totalhrs = (dtout - dt).TotalHours < 0 ? 0 : (dtout - dt).TotalHours;
                    totalhrs = (dtout - dt).TotalHours >= 5 ? (dtout - dt).TotalHours - 1 : (dtout - dt).TotalHours;
                    totalhrs = totalhrs < 0 ? 0 : totalhrs;

                }
            }
            else
            {
                totalhrs = (dtout - dt).TotalHours > manhrs ? manhrs : (dtout - dt).TotalHours;
                totalhrs = totalhrs >= 5 ? totalhrs - 1 : totalhrs;
                totalhrs = totalhrs < 0 ? 0 : totalhrs;
            }
            
                double Lates = 0;
                double Latesmin = 0;
                double UT = 0;
                double UTmin = 0;
                double OTHrs = 0;//this will be disabled due to AMPM
            //double OTHrsAM = 0;
            //double OTHrsPM = 0;
            
            double graceperiod = 0;

                if (timein > schedtimein)
                {

                    Lates = (timein - schedtimein).TotalHours;
                //Latesmin = (timein - schedtimein).TotalMinutes;
                /* remove second from LatesMin*/
                var LateminutesPassed = (int)(timein - schedtimein).TotalMinutes;
                Latesmin = LateminutesPassed;
                if (cm.ItemExist("TBL_DTRSETTINGS", "id", " where EmpID = '" + dtsInfo["EmpID"] + "' AND DisregardLate = '1'", ""))
                {
                    Latesmin = 0;
                    Lates = 0;

                }
                else if (cm.ItemExist("TBL_DTRSETTINGS", "id", " where EmpID = '" + dtsInfo["EmpID"] + "' and GracePeriod != 0", ""))
                {
                    getDTRSettings(dtsInfo["EmpID"], graceperiod, out graceperiod);
                    Latesmin = (Latesmin <= graceperiod ? 0 : Latesmin);
                    Lates = (Latesmin == 0 ? 0 : Lates);
                    if (Latesmin >= 60)
                    {
                        UT += Lates;
                        UTmin += Latesmin;
                        Latesmin = 0;
                        Lates = 0;
                    }

                }
                else
                {
                   // NEW JAN 03212022
                    string getgraceperiod = "";
                    //double graceperiod = 0;
                    getgraceperiod = cm.GetSpecificDataFromDB("GracePeriod", "TBL_EMPLOYEE_MASTER A, TBL_RANK B", " where A.emp_Rank = B.id AND  emp_EmpID = '" + dtsInfo["EmpID"].ToString() + "'");
                    double.TryParse(getgraceperiod, out graceperiod);
                    Latesmin = (Latesmin <= graceperiod ? 0 : Latesmin);
                    Lates = (Latesmin == 0 ? 0 : Lates);
                    if (Latesmin >= 60)
                    {
                        UT += Lates;
                        UTmin += Latesmin;
                        Latesmin = 0;
                        Lates = 0;
                    }
                }
                //latesmin = (latesmin <= graceperiod? 0 : latesmin);
                //Lates = (latesmin == 0? 0 : Lates);
            }

                if (timeout < schedtimeout)
                {
                //TimeSpan span = schedtimeout - timeout;
                //double totalMinutes = span.TotalMinutes;

                //UT = (timeout - schedtimeout).TotalHours;
                //UTmin = (timeout - schedtimeout).TotalMinutes;
                UT += (schedtimeout - timeout).TotalHours;
                //UTmin = (schedtimeout - timeout).TotalMinutes;
                /* remove second from UTmin*/
                var UndertimeminutesPassed = (int)(schedtimeout - timeout).TotalMinutes;
                UTmin += UndertimeminutesPassed;
            }

            if (timeout > schedtimeout)
            {
                //OTHrsPM = (timeout - schedtimeout).TotalHours;
                //for sv (Night Diff)
                TimeSpan ts10 = new TimeSpan(22, 0, 0);
                DateTime timeout10 = DateTime.Parse(strdtin).Date + ts10;
                //DateTime timeoutforND = DateTime.Parse(strdtin);
                //timeoutforND = timeoutforND.Date + timeout;
                if (dtout > timeout10)
                {
                    NDHrs = dtout.Subtract(timeout10).TotalHours;
                }

                IsOverTime = true;

            }
            //for AM
            if (timein < schedtimein)
            {
                //OTHrsAM = (schedtimein - timein).TotalHours;
                TimeSpan ts6 = new TimeSpan(6, 0, 0);
                DateTime timein6 = dt.Date + ts6;
                if (dt < timein6)
                {
                    NDHrs = NDHrs + timein6.Subtract(dt).TotalHours;
                }
                IsOverTime = true;

            }
            if (cm.ItemExist("TBL_OVERTIME", "id", " where EmpID = '" + dtsInfo["EmpID"] + "' and ot_Status = '1' AND OTDate = '" + datenow.ToString("yyyy-MM-dd") + "'", ""))
            {
                IsOverTime = true;

            }
            //04/05/2022 Jan for halfday leave
            //if (cm.ItemExist("TBL_LEAVESAPP", "id", " where EmpID = '" + dtsInfo["EmpID"] + "' and LeaveStatus = '1' AND ('" + datenow.ToString("yyyy-MM-dd") + "' Between DateFrom AND DateTo) AND (ampm = 'AM' OR ampm = 'PM')", ""))
            //{
            //    string getleaveampm = cm.GetSpecificDataFromDB("ampm", "TBL_LEAVESAPP", " where EmpID = '" + dtsInfo["EmpID"].ToString() + "' and LeaveStatus = '1' AND ('" + datenow.ToString("yyyy-MM-dd") + "' Between DateFrom AND DateTo) AND (ampm = 'AM' OR ampm = 'PM')");
            //    if(getleaveampm == "AM")
            //    {
            //        Lates = 4;
            //        Latesmin = 240;
            //    }
            //    else if (getleaveampm == "PM")
            //    {
            //        UT = 4;
            //        UTmin = 240;
            //    }
            //}

            /*
             * 09/30/2022
             * Jan
             * if undertime is greater than or equal to 5 hours then deduct 1 hour for lunch break.
             */
             if(UT >= 5)
            {
                UT = UT - 1;
                UTmin = UTmin - 60;
            }
            tempParam.Add("TotHrs", "" + Math.Round(totalhrs, 2) + "");
                tempParam.Add("Lates", "" + Math.Round(Lates, 2) + "");
                tempParam.Add("Latesmin", "" + Math.Round(Latesmin, 2) + "");
                tempParam.Add("UT", "" + Math.Round(UT, 2) + "");
                tempParam.Add("UTmin", "" + Math.Round(UTmin, 2) + "");
            
            //tempParam.Add("OTHrs", "" + Math.Round(OTHrs, 2) + "");

            //AMPM
            //tempParam.Add("OTHrsAM", "" + Math.Round(OTHrsAM, 2) + "");
            //tempParam.Add("OTHrsPM", "" + Math.Round(OTHrsPM, 2) + "");
            //tempParam.Add("NDHrs", "" + Math.Round(NDHrs, 2) + "");
        }
            else
            {
            string Lates = "0";
            string Latesmin = "0";
            string UT = "0";
            string UTmin = "0";
            //04/05/2022 Jan for halfday leave
            if (cm.ItemExist("TBL_LEAVESAPP", "id", " where EmpID = '" + dtsInfo["EmpID"] + "' and LeaveStatus = '1' AND ('" + datenow.ToString("yyyy-MM-dd") + "' Between DateFrom AND DateTo) AND (ampm = 'AM' OR ampm = 'PM')", ""))
            {

                string getleaveampm = cm.GetSpecificDataFromDB("ampm", "TBL_LEAVESAPP", " where EmpID = '" + dtsInfo["EmpID"].ToString() + "' and LeaveStatus = '1' AND ('" + datenow.ToString("yyyy-MM-dd") + "' Between DateFrom AND DateTo) AND (ampm = 'AM' OR ampm = 'PM')");
                if (getleaveampm == "AM")
                {
                    Lates = "4";
                    Latesmin = "240";
                }
                else if (getleaveampm == "PM")
                {
                    UT = "4";
                    UTmin = "240";
                }
            }
            if (cm.ItemExist("TBL_OVERTIME", "id", " where EmpID = '" + dtsInfo["EmpID"] + "' and ot_Status = '1' AND OTDate = '" + datenow.ToString("yyyy-MM-dd") + "'", ""))
            {
                IsOverTime = true;

            }
            tempParam.Add("TotHrs", "0");
                tempParam.Add("Lates", Lates);
                tempParam.Add("Latesmin", Latesmin);
                tempParam.Add("UT", UT);
                tempParam.Add("UTmin", UTmin);
                tempParam.Add("OTHrs", "0");
            //tempParam.Add("NDHrs", "" + Math.Round(NDHrs, 2) + "");
        }
            //double manhrs = cm.get_Time_Difference(dtsInfo["Sched_TimeIn"], dtsInfo["Sched_TimeOut"]);
            tempParam.Add("ManHrs", "" + Math.Round(manhrs, 2) + "");



            return tempParam;

        }
    public void getDTRSettings(string empno, double graceperiod, out double graceperiodval)
    {
        conn = new SqlConnection(connectionstring);
        conn.Open();
        graceperiodval = graceperiod;
        cmd = new SqlCommand("Select * from TBL_DTRSETTINGS where EmpID = '" + empno + "'", conn);
        dread = cmd.ExecuteReader();
        dread.Read();
        if (dread.HasRows)
        {
            if (dread["GracePeriod"] != DBNull.Value)
            {
                graceperiodval = double.Parse(dread["GracePeriod"].ToString());
            }
        }

        dread.Close();
        conn.Close();


    }
    //this is unused due to change of logic in merging data
    public DataTable get_DTR_DATA(string cutoff_id, out string codate, out int ret, out DateTime dtFrom, out DateTime dtTo)
        {
            ret = 1;
            DataTable dt = new DataTable();
            dtFrom = new DateTime(); dtTo = new DateTime();
            codate = "";
            conn = new SqlConnection(connectionstring);
            conn.Open();

            cmd = new SqlCommand("Select * from TBL_CUTOFF where id =" + cutoff_id + "", conn);
            dread = cmd.ExecuteReader();
            dread.Read();
            if (dread.HasRows)
            {
                dtFrom = DateTime.Parse(dread["COFrom"].ToString());
                dtTo = DateTime.Parse(dread["COTo"].ToString());
                codate = (DateTime.Parse(dread["COTo"].ToString())).ToString("yyyy-MM-dd");
            }
            else
            {
                ret = -2;
                dread.Close();
                conn.Close();
                goto EXIT;
            }
            dread.Close();
            string qry = "SELECT EmpID,AssignmentCode,BussDate,min(DateIn) as 'DateIn',min(DTimeIn) as 'DTimeIn',min(DateOut) as 'DateOut',min(DTimeOut) as 'DTimeOut',min(DateIn2) as 'DateIn2',min(TimeIn2) as 'TimeIn2',min(DateOut2) as 'DateOut2',min(TimeOut2) as 'TimeOut2',min(Sched_TimeIn) as 'Sched_TimeIn',min(Sched_TimeOut) as 'Sched_TimeOut',min(ActivityCode) as 'ActivityCode',min(RestDay) as 'RestDay',Emp_Name,min(ODateIn) as 'ODateIn',min(OTimeIn) as 'OTimeIn',min(ODateOut) as 'ODateOut',min(OTimeOut) as 'OTimeOut',min(ODateIn2) as 'ODateIn2',min(OTimeIn2) as 'OTimeIn2',min(ODateOut2) as 'ODateOut2',min(OTimeOut2) as 'OTimeOut2' " +
                    " FROM TBL_DTR" +
                    " where BussDate BETWEEN '" + dtFrom.ToString("yyyy-MM-dd") + "' and '" + dtTo.ToString("yyyy-MM-dd") + "'" +
                    " Group by EmpID, BussDate, AssignmentCode, Emp_Name" +
                    " Order by EmpID";
            //cmd = new SqlCommand("Select * from TBL_DTR where BussDate BETWEEN '" + dtFrom.ToString("yyyy-MM-dd") + "' and '" + dtTo.ToString("yyyy-MM-dd") + "'", conn);
            cmd = new SqlCommand(qry, conn);
            adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dt);
        EXIT:
            return dt;

        }

        public bool submitDTR(string cutoff_id, string empno, out int ret)
        {
            bool valid = false;
            ret = 1;
            DateTime coto = new DateTime();
            DateTime cofrom = new DateTime();
            string codate = "";
            getCutoffRange(cutoff_id, out codate, out cofrom, out coto);
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("Submit", "'Y'");
            valid = cm.UpdateQueryCommon(param, "TBL_DTSAE", "PayPeriod = '" + codate + "' and EmpID = '" + empno + "'");
        EXIT_RET:
            return valid;
        }
        #endregion DTR processing

        #region PAYROLL PROCESSING
        public int processPayroll(string codate, string companyCode)
        {
            List<string> employeeIds = getEmployeeIDs(" and emp_Assignment = " + companyCode + "");
            foreach (string empno in employeeIds)
            {
                Dictionary<string, string> summaryDict = cm.GetTableDict("TBL_PAYROLLSUM", " where empid = '" + empno + "' and CODate = '" + codate + "'");

                string regOT = summaryDict["RegOT"];

            }
            return 0;

        }

    #endregion PAYROLL PROCESSING
    public double GetSSSDed(string basicpay)
    {

        double bscpy = double.Parse(basicpay, System.Globalization.CultureInfo.InvariantCulture);
        double ret = 0;
        if (cm.dtnow().Year == 2020)
        {
            if (bscpy < 2250)
            {
                ret = 80;
            }
            if (bscpy >= 2250 && bscpy <= 2749.99)
            {
                ret = 100;
            }
            if (bscpy >= 2750 && bscpy <= 3249.99)
            {
                ret = 120;
            }
            if (bscpy >= 3250 && bscpy <= 3749.99)
            {
                ret = 140;
            }
            if (bscpy >= 3750 && bscpy <= 4249.99)
            {
                ret = 160;
            }
            if (bscpy >= 4250 && bscpy <= 4749.99)
            {
                ret = 180;
            }
            if (bscpy >= 4750 && bscpy <= 5249.99)
            {
                ret = 200;
            }
            if (bscpy >= 5250 && bscpy <= 5749.99)
            {
                ret = 220;
            }
            if (bscpy >= 5750 && bscpy <= 6249.99)
            {
                ret = 240;
            }
            if (bscpy >= 6250 && bscpy <= 6749.99)
            {
                ret = 260;
            }
            if (bscpy >= 6750 && bscpy <= 7249.99)
            {
                ret = 280;
            }
            if (bscpy >= 7250 && bscpy <= 7749.99)
            {
                ret = 300;
            }
            if (bscpy >= 7750 && bscpy <= 8249.99)
            {
                ret = 320;
            }
            if (bscpy >= 8250 && bscpy <= 8749.99)
            {
                ret = 340;
            }
            if (bscpy >= 8750 && bscpy <= 9249.99)
            {
                ret = 360;
            }
            if (bscpy >= 9250 && bscpy <= 9749.99)
            {
                ret = 380;
            }
            if (bscpy >= 9750 && bscpy <= 10249.99)
            {
                ret = 400;
            }
            if (bscpy >= 10250 && bscpy <= 10749.99)
            {
                ret = 420;
            }
            if (bscpy >= 10750 && bscpy <= 11249.99)
            {
                ret = 440;
            }
            if (bscpy >= 11250 && bscpy <= 11749.99)
            {
                ret = 460;
            }
            if (bscpy >= 11750 && bscpy <= 12249.99)
            {
                ret = 480;
            }
            if (bscpy >= 12250 && bscpy <= 12749.99)
            {
                ret = 500;
            }
            if (bscpy >= 12750 && bscpy <= 13249.99)
            {
                ret = 520;
            }
            if (bscpy >= 13250 && bscpy <= 13749.99)
            {
                ret = 540;
            }
            if (bscpy >= 13750 && bscpy <= 14249.99)
            {
                ret = 560;
            }
            if (bscpy >= 14250 && bscpy <= 14749.99)
            {
                ret = 580;
            }
            if (bscpy >= 14750 && bscpy <= 15249.99)
            {
                ret = 600;
            }
            if (bscpy >= 15250 && bscpy <= 15749.99)
            {
                ret = 620;
            }
            if (bscpy >= 15750 && bscpy <= 16249.99)
            {
                ret = 640;
            }
            if (bscpy >= 16250 && bscpy <= 16749.99)
            {
                ret = 660;
            }
            if (bscpy >= 16750 && bscpy <= 17249.99)
            {
                ret = 680;
            }
            if (bscpy >= 17250 && bscpy <= 17749.99)
            {
                ret = 700;
            }
            if (bscpy >= 17750 && bscpy <= 18249.99)
            {
                ret = 720;
            }
            if (bscpy >= 18250 && bscpy <= 18749.99)
            {
                ret = 740;
            }
            if (bscpy >= 18750 && bscpy <= 19249.99)
            {
                ret = 760;
            }
            if (bscpy >= 19250 && bscpy <= 19749.99)
            {
                ret = 780;
            }
            if (bscpy >= 19750)
            {
                ret = 800;
            }
        }
        else if (cm.dtnow().Year == 2021 || cm.dtnow().Year == 2022)
        {
            if (bscpy < 3250)
            {
                ret = 135;
            }
            if (bscpy >= 3250 && bscpy <= 3749.99)
            {
                ret = 157;
            }
            if (bscpy >= 3750 && bscpy <= 4249.99)
            {
                ret = 180;
            }
            if (bscpy >= 4250 && bscpy <= 4749.99)
            {
                ret = 202.50;
            }
            if (bscpy >= 4750 && bscpy <= 5249.99)
            {
                ret = 225;
            }
            if (bscpy >= 5250 && bscpy <= 5749.99)
            {
                ret = 247.50;
            }
            if (bscpy >= 5750 && bscpy <= 6249.99)
            {
                ret = 270;
            }
            if (bscpy >= 6250 && bscpy <= 6749.99)
            {
                ret = 292.50;
            }
            if (bscpy >= 6750 && bscpy <= 7249.99)
            {
                ret = 315;
            }
            if (bscpy >= 7250 && bscpy <= 7749.99)
            {
                ret = 337.50;
            }
            if (bscpy >= 7750 && bscpy <= 8249.99)
            {
                ret = 360;
            }
            if (bscpy >= 8250 && bscpy <= 8749.99)
            {
                ret = 382.50;
            }
            if (bscpy >= 8750 && bscpy <= 9249.99)
            {
                ret = 405;
            }
            if (bscpy >= 9250 && bscpy <= 9749.99)
            {
                ret = 427.50;
            }
            if (bscpy >= 9750 && bscpy <= 10249.99)
            {
                ret = 450;
            }
            if (bscpy >= 10250 && bscpy <= 10749.99)
            {
                ret = 472.50;
            }
            if (bscpy >= 10750 && bscpy <= 11249.99)
            {
                ret = 495;
            }
            if (bscpy >= 11250 && bscpy <= 11749.99)
            {
                ret = 517.50;
            }
            if (bscpy >= 11750 && bscpy <= 12249.99)
            {
                ret = 540;
            }
            if (bscpy >= 12250 && bscpy <= 12749.99)
            {
                ret = 562.50;
            }
            if (bscpy >= 12750 && bscpy <= 13249.99)
            {
                ret = 585;
            }
            if (bscpy >= 13250 && bscpy <= 13749.99)
            {
                ret = 607.50;
            }
            if (bscpy >= 13750 && bscpy <= 14249.99)
            {
                ret = 630;
            }
            if (bscpy >= 14250 && bscpy <= 14749.99)
            {
                ret = 652.50;
            }
            if (bscpy >= 14750 && bscpy <= 15249.99)
            {
                ret = 675;
            }
            if (bscpy >= 15250 && bscpy <= 15749.99)
            {
                ret = 697.50;
            }
            if (bscpy >= 15750 && bscpy <= 16249.99)
            {
                ret = 720;
            }
            if (bscpy >= 16250 && bscpy <= 16749.99)
            {
                ret = 742.50;
            }
            if (bscpy >= 16750 && bscpy <= 17249.99)
            {
                ret = 765;
            }
            if (bscpy >= 17250 && bscpy <= 17749.99)
            {
                ret = 787.50;
            }
            if (bscpy >= 17750 && bscpy <= 18249.99)
            {
                ret = 810;
            }
            if (bscpy >= 18250 && bscpy <= 18749.99)
            {
                ret = 832.50;
            }
            if (bscpy >= 18750 && bscpy <= 19249.99)
            {
                ret = 855;
            }
            if (bscpy >= 19250 && bscpy <= 19749.99)
            {
                ret = 877.50;
            }
            if (bscpy >= 19750 && bscpy <= 20249.99)
            {
                ret = 900;
            }
            if (bscpy >= 20250 && bscpy <= 20749.99)
            {
                ret = 900;
            }
            if (bscpy >= 20750 && bscpy <= 21249.99)
            {
                ret = 900;
            }
            if (bscpy >= 21250 && bscpy <= 21749.99)
            {
                ret = 900;
            }
            if (bscpy >= 21750 && bscpy <= 22249.99)
            {
                ret = 900;
            }
            if (bscpy >= 22250 && bscpy <= 22749.99)
            {
                ret = 900;
            }
            if (bscpy >= 22750 && bscpy <= 23249.99)
            {
                ret = 900;
            }
            if (bscpy >= 23250 && bscpy <= 23749.99)
            {
                ret = 900;
            }
            if (bscpy >= 23750 && bscpy <= 24249.99)
            {
                ret = 900;
            }
            if (bscpy >= 24250 && bscpy <= 24749.99)
            {
                ret = 900;
            }
            if (bscpy >= 24750)
            {
                ret = 900;
            }
        }
        return ret;


    }
    public double GetSSSDedMPFER(string basicpay)
    {

        double bscpy = double.Parse(basicpay, System.Globalization.CultureInfo.InvariantCulture);
        double ret = 0;
        if (cm.dtnow().Year == 2022 || cm.dtnow().Year == 2023)
        {
            
            if (bscpy >= 20250 && bscpy <= 20749.99)
            {
                ret = 42.50;
            }
            else if (bscpy >= 20750 && bscpy <= 21249.99)
            {
                ret = 85.00;
            }
            else if (bscpy >= 21250 && bscpy <= 21749.99)
            {
                ret = 127.50;
            }
            else if (bscpy >= 21750 && bscpy <= 22249.99)
            {
                ret = 170;
            }
            else if (bscpy >= 22250 && bscpy <= 22749.99)
            {
                ret = 212.50;
            }
            else if (bscpy >= 22750 && bscpy <= 23249.99)
            {
                ret = 255;
            }
            else if (bscpy >= 23250 && bscpy <= 23749.99)
            {
                ret = 297.50;
            }
            else if (bscpy >= 23750 && bscpy <= 24249.99)
            {
                ret = 340;
            }
            else if (bscpy >= 24250 && bscpy <= 24749.99)
            {
                ret = 382.50;
            }
            else if (bscpy >= 24750)
            {
                ret = 425;
            }
        }
        return ret;
    }
    public double GetSSSDedMPFEE(string basicpay)
    {

        double bscpy = double.Parse(basicpay, System.Globalization.CultureInfo.InvariantCulture);
        double ret = 0;
        if (cm.dtnow().Year == 2022 || cm.dtnow().Year == 2023)
        {

            if (bscpy >= 20250 && bscpy <= 20749.99)
            {
                ret = 22.50;
            }
            else if (bscpy >= 20750 && bscpy <= 21249.99)
            {
                ret = 45.00;
            }
            else if (bscpy >= 21250 && bscpy <= 21749.99)
            {
                ret = 67.50;
            }
            else if (bscpy >= 21750 && bscpy <= 22249.99)
            {
                ret = 90;
            }
            else if (bscpy >= 22250 && bscpy <= 22749.99)
            {
                ret = 112.50;
            }
            else if (bscpy >= 22750 && bscpy <= 23249.99)
            {
                ret = 135;
            }
            else if (bscpy >= 23250 && bscpy <= 23749.99)
            {
                ret = 157.50;
            }
            else if (bscpy >= 23750 && bscpy <= 24249.99)
            {
                ret = 180;
            }
            else if (bscpy >= 24250 && bscpy <= 24749.99)
            {
                ret = 202.50;
            }
            else if (bscpy >= 24750)
            {
                ret = 225;
            }
        }
        return ret;
    }

    public double GetSSSERContribution(string basicpay)
    {

        double bscpy = double.Parse(basicpay, System.Globalization.CultureInfo.InvariantCulture);
        double ret = 0;
        if (cm.dtnow().Year == 2020)
        {
            if (bscpy < 2250)
            {
                ret = 160;
            }
            if (bscpy >= 2250 && bscpy <= 2749.99)
            {
                ret = 200;
            }
            if (bscpy >= 2750 && bscpy <= 3249.99)
            {
                ret = 240;
            }
            if (bscpy >= 3250 && bscpy <= 3749.99)
            {
                ret = 280;
            }
            if (bscpy >= 3750 && bscpy <= 4249.99)
            {
                ret = 320;
            }
            if (bscpy >= 4250 && bscpy <= 4749.99)
            {
                ret = 360;
            }
            if (bscpy >= 4750 && bscpy <= 5249.99)
            {
                ret = 400;
            }
            if (bscpy >= 5250 && bscpy <= 5749.99)
            {
                ret = 440;
            }
            if (bscpy >= 5750 && bscpy <= 6249.99)
            {
                ret = 480;
            }
            if (bscpy >= 6250 && bscpy <= 6749.99)
            {
                ret = 520;
            }
            if (bscpy >= 6750 && bscpy <= 7249.99)
            {
                ret = 560;
            }
            if (bscpy >= 7250 && bscpy <= 7749.99)
            {
                ret = 600;
            }
            if (bscpy >= 7750 && bscpy <= 8249.99)
            {
                ret = 640;
            }
            if (bscpy >= 8250 && bscpy <= 8749.99)
            {
                ret = 680;
            }
            if (bscpy >= 8750 && bscpy <= 9249.99)
            {
                ret = 720;
            }
            if (bscpy >= 9250 && bscpy <= 9749.99)
            {
                ret = 760;
            }
            if (bscpy >= 9750 && bscpy <= 10249.99)
            {
                ret = 800;
            }
            if (bscpy >= 10250 && bscpy <= 10749.99)
            {
                ret = 840;
            }
            if (bscpy >= 10750 && bscpy <= 11249.99)
            {
                ret = 880;
            }
            if (bscpy >= 11250 && bscpy <= 11749.99)
            {
                ret = 920;
            }
            if (bscpy >= 11750 && bscpy <= 12249.99)
            {
                ret = 960;
            }
            if (bscpy >= 12250 && bscpy <= 12749.99)
            {
                ret = 1000;
            }
            if (bscpy >= 12750 && bscpy <= 13249.99)
            {
                ret = 1040;
            }
            if (bscpy >= 13250 && bscpy <= 13749.99)
            {
                ret = 1080;
            }
            if (bscpy >= 13750 && bscpy <= 14249.99)
            {
                ret = 1120;
            }
            if (bscpy >= 14250 && bscpy <= 14749.99)
            {
                ret = 1160;
            }
            if (bscpy >= 14750 && bscpy <= 15249.99)
            {
                ret = 1200;
            }
            if (bscpy >= 15250 && bscpy <= 15749.99)
            {
                ret = 1240;
            }
            if (bscpy >= 15750 && bscpy <= 16249.99)
            {
                ret = 1280;
            }
            if (bscpy >= 16250 && bscpy <= 16749.99)
            {
                ret = 1320;
            }
            if (bscpy >= 16750 && bscpy <= 17249.99)
            {
                ret = 1360;
            }
            if (bscpy >= 17250 && bscpy <= 17749.99)
            {
                ret = 1400;
            }
            if (bscpy >= 17750 && bscpy <= 18249.99)
            {
                ret = 1440;
            }
            if (bscpy >= 18250 && bscpy <= 18749.99)
            {
                ret = 1480;
            }
            if (bscpy >= 18750 && bscpy <= 19249.99)
            {
                ret = 1520;
            }
            if (bscpy >= 19250 && bscpy <= 19749.99)
            {
                ret = 1560;
            }
            if (bscpy >= 19750)
            {
                ret = 1600;
            }
        }
        else if (cm.dtnow().Year == 2021 || cm.dtnow().Year == 2022)
        {
            if (bscpy < 3250)
            {
                ret = 255;
            }
            if (bscpy >= 3250 && bscpy <= 3749.99)
            {
                ret = 297.50;
            }
            if (bscpy >= 3750 && bscpy <= 4249.99)
            {
                ret = 340;
            }
            if (bscpy >= 4250 && bscpy <= 4749.99)
            {
                ret = 382.50;
            }
            if (bscpy >= 4750 && bscpy <= 5249.99)
            {
                ret = 425;
            }
            if (bscpy >= 5250 && bscpy <= 5749.99)
            {
                ret = 467.50;
            }
            if (bscpy >= 5750 && bscpy <= 6249.99)
            {
                ret = 510;
            }
            if (bscpy >= 6250 && bscpy <= 6749.99)
            {
                ret = 552.50;
            }
            if (bscpy >= 6750 && bscpy <= 7249.99)
            {
                ret = 595;
            }
            if (bscpy >= 7250 && bscpy <= 7749.99)
            {
                ret = 637.50;
            }
            if (bscpy >= 7750 && bscpy <= 8249.99)
            {
                ret = 680;
            }
            if (bscpy >= 8250 && bscpy <= 8749.99)
            {
                ret = 722.50;
            }
            if (bscpy >= 8750 && bscpy <= 9249.99)
            {
                ret = 765;
            }
            if (bscpy >= 9250 && bscpy <= 9749.99)
            {
                ret = 807.50;
            }
            if (bscpy >= 9750 && bscpy <= 10249.99)
            {
                ret = 850;
            }
            if (bscpy >= 10250 && bscpy <= 10749.99)
            {
                ret = 892.50;
            }
            if (bscpy >= 10750 && bscpy <= 11249.99)
            {
                ret = 935;
            }
            if (bscpy >= 11250 && bscpy <= 11749.99)
            {
                ret = 977.50;
            }
            if (bscpy >= 11750 && bscpy <= 12249.99)
            {
                ret = 1020;
            }
            if (bscpy >= 12250 && bscpy <= 12749.99)
            {
                ret = 1062.50;
            }
            if (bscpy >= 12750 && bscpy <= 13249.99)
            {
                ret = 1105;
            }
            if (bscpy >= 13250 && bscpy <= 13749.99)
            {
                ret = 1147.50;
            }
            if (bscpy >= 13750 && bscpy <= 14249.99)
            {
                ret = 1190;
            }
            if (bscpy >= 14250 && bscpy <= 14749.99)
            {
                ret = 1232.50;
            }
            if (bscpy >= 14750 && bscpy <= 15249.99)
            {
                ret = 1275;
            }
            if (bscpy >= 15250 && bscpy <= 15749.99)
            {
                ret = 1317.50;
            }
            if (bscpy >= 15750 && bscpy <= 16249.99)
            {
                ret = 1360;
            }
            if (bscpy >= 16250 && bscpy <= 16749.99)
            {
                ret = 1402.50;
            }
            if (bscpy >= 16750 && bscpy <= 17249.99)
            {
                ret = 1445;
            }
            if (bscpy >= 17250 && bscpy <= 17749.99)
            {
                ret = 1487.50;
            }
            if (bscpy >= 17750 && bscpy <= 18249.99)
            {
                ret = 1530;
            }
            if (bscpy >= 18250 && bscpy <= 18749.99)
            {
                ret = 1572.50;
            }
            if (bscpy >= 18750 && bscpy <= 19249.99)
            {
                ret = 1615;
            }
            if (bscpy >= 19250 && bscpy <= 19749.99)
            {
                ret = 1657.50;
            }
            if (bscpy >= 19750 && bscpy <= 20249.99)
            {
                ret = 1700;
            }
            if (bscpy >= 20250 && bscpy <= 20749.99)
            {
                ret = 1700;
            }
            if (bscpy >= 20750 && bscpy <= 21249.99)
            {
                ret = 1700;
            }
            if (bscpy >= 21250 && bscpy <= 21749.99)
            {
                ret = 1700;
            }
            if (bscpy >= 21750 && bscpy <= 22249.99)
            {
                ret = 1700;
            }
            if (bscpy >= 22250 && bscpy <= 22749.99)
            {
                ret = 1700;
            }
            if (bscpy >= 22750 && bscpy <= 23249.99)
            {
                ret = 1700;
            }
            if (bscpy >= 23250 && bscpy <= 23749.99)
            {
                ret = 1700;
            }
            if (bscpy >= 23750 && bscpy <= 24249.99)
            {
                ret = 1700;
            }
            if (bscpy >= 24250 && bscpy <= 24749.99)
            {
                ret = 1700;
            }
            if (bscpy >= 24750)
            {
                ret = 1700;
            }
        }




        return ret;


    }
    public double GetSSSECContribution(string basicpay)
    {

        double bscpy = double.Parse(basicpay, System.Globalization.CultureInfo.InvariantCulture);
        double ret = 0;
        if (cm.dtnow().Year == 2021)
        {
            if (bscpy < 3250)
            {
                ret = 10;
            }
            if (bscpy >= 3250 && bscpy <= 3749.99)
            {
                ret = 10;
            }
            if (bscpy >= 3750 && bscpy <= 4249.99)
            {
                ret = 10;
            }
            if (bscpy >= 4250 && bscpy <= 4749.99)
            {
                ret = 10;
            }
            if (bscpy >= 4750 && bscpy <= 5249.99)
            {
                ret = 10;
            }
            if (bscpy >= 5250 && bscpy <= 5749.99)
            {
                ret = 10;
            }
            if (bscpy >= 5750 && bscpy <= 6249.99)
            {
                ret = 10;
            }
            if (bscpy >= 6250 && bscpy <= 6749.99)
            {
                ret = 10;
            }
            if (bscpy >= 6750 && bscpy <= 7249.99)
            {
                ret = 10;
            }
            if (bscpy >= 7250 && bscpy <= 7749.99)
            {
                ret = 10;
            }
            if (bscpy >= 7750 && bscpy <= 8249.99)
            {
                ret = 10;
            }
            if (bscpy >= 8250 && bscpy <= 8749.99)
            {
                ret = 10;
            }
            if (bscpy >= 8750 && bscpy <= 9249.99)
            {
                ret = 10;
            }
            if (bscpy >= 9250 && bscpy <= 9749.99)
            {
                ret = 10;
            }
            if (bscpy >= 9750 && bscpy <= 10249.99)
            {
                ret = 10;
            }
            if (bscpy >= 10250 && bscpy <= 10749.99)
            {
                ret = 10;
            }
            if (bscpy >= 10750 && bscpy <= 11249.99)
            {
                ret = 10;
            }
            if (bscpy >= 11250 && bscpy <= 11749.99)
            {
                ret = 10;
            }
            if (bscpy >= 11750 && bscpy <= 12249.99)
            {
                ret = 10;
            }
            if (bscpy >= 12250 && bscpy <= 12749.99)
            {
                ret = 10;
            }
            if (bscpy >= 12750 && bscpy <= 13249.99)
            {
                ret = 10;
            }
            if (bscpy >= 13250 && bscpy <= 13749.99)
            {
                ret = 10;
            }
            if (bscpy >= 13750 && bscpy <= 14249.99)
            {
                ret = 10;
            }
            if (bscpy >= 14250 && bscpy <= 14749.99)
            {
                ret = 10;
            }
            if (bscpy >= 14750 && bscpy <= 15249.99)
            {
                ret = 30;
            }
            if (bscpy >= 15250 && bscpy <= 15749.99)
            {
                ret = 30;
            }
            if (bscpy >= 15750 && bscpy <= 16249.99)
            {
                ret = 30;
            }
            if (bscpy >= 16250 && bscpy <= 16749.99)
            {
                ret = 30;
            }
            if (bscpy >= 16750 && bscpy <= 17249.99)
            {
                ret = 30;
            }
            if (bscpy >= 17250 && bscpy <= 17749.99)
            {
                ret = 30;
            }
            if (bscpy >= 17750 && bscpy <= 18249.99)
            {
                ret = 30;
            }
            if (bscpy >= 18250 && bscpy <= 18749.99)
            {
                ret = 30;
            }
            if (bscpy >= 18750 && bscpy <= 19249.99)
            {
                ret = 30;
            }
            if (bscpy >= 19250 && bscpy <= 19749.99)
            {
                ret = 30;
            }
            if (bscpy >= 19750 && bscpy <= 20249.99)
            {
                ret = 30;
            }
            if (bscpy >= 20250 && bscpy <= 20749.99)
            {
                ret = 30;
            }
            if (bscpy >= 20750 && bscpy <= 21249.99)
            {
                ret = 30;
            }
            if (bscpy >= 21250 && bscpy <= 21749.99)
            {
                ret = 30;
            }
            if (bscpy >= 21750 && bscpy <= 22249.99)
            {
                ret = 30;
            }
            if (bscpy >= 22250 && bscpy <= 22749.99)
            {
                ret = 30;
            }
            if (bscpy >= 22750 && bscpy <= 23249.99)
            {
                ret = 30;
            }
            if (bscpy >= 23250 && bscpy <= 23749.99)
            {
                ret = 30;
            }
            if (bscpy >= 23750 && bscpy <= 24249.99)
            {
                ret = 30;
            }
            if (bscpy >= 24250 && bscpy <= 24749.99)
            {
                ret = 30;
            }
            if (bscpy >= 24750)
            {
                ret = 30;
            }
        }




        return ret;


    }
    public double GetPhilDed(string basicpay)
    {

        //double bscpy = double.Parse(basicpay, System.Globalization.CultureInfo.InvariantCulture);
        double bscpy = 0;
        double.TryParse(basicpay, out bscpy);
        double ret = 0;
        double dedpercent = 0;
        double.TryParse(cm.GetSpecificDataFromDB("philDedPercent", "TBL_PHILHEALTH"), out dedpercent);


        //if (bscpy <= 10000)
        //{
        //    ret = 350;
        //    return ret;
        //}

        //ret = bscpy * double.Parse(ded == "" ? "0" : ded, System.Globalization.CultureInfo.InvariantCulture);
        //if (bscpy <= 10000)
        //{
        //    ret = 350;
        //    return ret;
        //}

        ret = bscpy * dedpercent;



        return ret;


    }
    #region new
    bool HasFiledTIME_IN_OUT(DateTime date, string empno)
    {
        try
        {
            bool HasTIME_IN_OUT = false;
            string ret = "";
            string qry = "SELECT [EmpID],[AssignmentCode],[BussDate],(Select BussDate from[dbo].[TBL_DTR]" +
                "where EmpID = '" + empno + "' and BussDate = '" + date.ToString("yyyy-MM-dd") + "' and Flag = 'I') as DTimeIn," +
                "(Select Top 1 BussDate from[dbo].[TBL_DTR] where EmpID = '" + empno + "' and BussDate = '" + date.ToString("yyyy-MM-dd") + "' and Flag like '%O%' order by id desc) as DTimeOut," +
                "(Select Top 1 BussDate from[dbo].[TBL_DTR] where EmpID = '" + empno + "' and BussDate = '" + date.ToString("yyyy-MM-dd") + "' and Flag like '%B%' order by id desc) as LunchOut," +
                "(Select Top 1 BussDate from[dbo].[TBL_DTR] where EmpID = '" + empno + "' and BussDate = '" + date.ToString("yyyy-MM-dd") + "' and Flag like '%C%' order by id desc) as LunchIn," +
                " min(Sched_TimeIn) as 'Sched_TimeIn',min(Sched_TimeOut) as 'Sched_TimeOut',min(ActivityCode) as 'ActivityCode', " +
                "min(RestDay) as 'RestDay',Emp_Name,min(ODateIn) as 'ODateIn', min(OTimeIn) as 'OTimeIn', min(ODateOut) as 'ODateOut', " +
                "min(OTimeOut) as 'OTimeOut', min(ODateIn2) as 'ODateIn2', min(OTimeIn2) as 'OTimeIn2', min(ODateOut2) as 'ODateOut2', " +
                "min(OTimeOut2) as 'OTimeOut2'FROM[dbo].[TBL_DTR] A where EmpID = '" + empno + "' and BussDate = '" + date.ToString("yyyy-MM-dd") + "' Group by EmpID, BussDate, AssignmentCode, Emp_Name Order by EmpID";
            conn = new SqlConnection(connectionstring);
            conn.Open();
            cmd = new SqlCommand(qry, conn);
            dread = cmd.ExecuteReader();
            dread.Read();
            if (dread.HasRows)
                HasTIME_IN_OUT = true;
            dread.Close();
            conn.Close();
            return HasTIME_IN_OUT;
        }
        finally
        {
            dread.Close();
            conn.Close();


        }



    }
    public DataTable populateGridFlexiSchedPermonth(string empno, string month)
    {
        dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[5] { new DataColumn("id"), new DataColumn("EmpID"), new DataColumn("BussDate"),
            new DataColumn("Sched_TimeIn"), new DataColumn("Sched_TimeOut") });
        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand("Select * from TBL_FLEXISCHED A where EmpID = '" + empno + "' and month(BussDate)= " + month + " and year(BussDate)= " + DateTime.Now.Year + "  ORDER BY BussDate Desc", conn);
        dread = cmd.ExecuteReader();
        while (dread.Read())
        {
            
            
            string schedtimein = dread["Sched_TimeIn"].ToString() == "RD" ? "Restday" : FormatTimeAMPM(dread["Sched_TimeIn"].ToString());
            string schedtimeout = dread["Sched_TimeOut"].ToString() == "RD" ? "Restday" : FormatTimeAMPM(dread["Sched_TimeOut"].ToString());
            dt.Rows.Add(dread["id"].ToString(), dread["EmpID"].ToString(), FormatDateddMMMMyyyy(dread["BussDate"].ToString()),
                schedtimein, schedtimeout);
        }
        dread.Close();

        conn.Close();
        return dt;

    }
    public DataTable populateGridFlexiSched(string empno)
    {
        dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[5] { new DataColumn("id"), new DataColumn("EmpID"), new DataColumn("BussDate"),
            new DataColumn("Sched_TimeIn"), new DataColumn("Sched_TimeOut") });
        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand("Select * from TBL_FLEXISCHED  where EmpID = '" + empno + "' ORDER BY BussDate Desc", conn);
        dread = cmd.ExecuteReader();
        while (dread.Read())
        {
            string schedtimein = dread["Sched_TimeIn"].ToString() == "RD" ? "Restday" : FormatTimeAMPM(dread["Sched_TimeIn"].ToString());
            string schedtimeout = dread["Sched_TimeOut"].ToString() == "RD" ? "Restday" : FormatTimeAMPM(dread["Sched_TimeOut"].ToString());
            dt.Rows.Add(dread["id"].ToString(), dread["EmpID"].ToString(), FormatDateddMMMMyyyy(dread["BussDate"].ToString()),
                schedtimein, schedtimeout);
        }
        dread.Close();

        conn.Close();
        return dt;

    }
    public string FormatTimeAMPM(string strtime)
    {

        TimeSpan time;
        if (!TimeSpan.TryParse(strtime, out time))
        {
            // handle validation error
        }

        DateTime dttime = DateTime.Today.Add(time);

        string displayTime = dttime.ToString("h:mm tt");
        string ret = displayTime.ToUpper();
        return ret;
    }
    public string FormatDateddMMMMyyyy(string strdate)
    {
        DateTime date = new DateTime();
        if (!DateTime.TryParse(strdate, out date))
            return "";
        return FormatDateddMMMMyyyy(date);

    }
    public string FormatDateddMMMMyyyy(DateTime date)
    {
        DateTime dttemp = new DateTime();
        dttemp = date;
        string ret = dttemp.ToString("MMMM dd, yyyy");
        return ret;
    }
    public List<string> GetSpecificDataFromDBList1(string field, string tbl, string condition)
    {
        List<string> ret = new List<string>();
        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand("Select " + field + " from " + tbl + " " + condition + "", conn);
        dread = cmd.ExecuteReader();

        while (dread.Read())
        {
            ret.Add(dread[0].ToString());
        }
        dread.Close();
        conn.Close();
        return ret;


    }
    bool HasDuplicate_DTS_Entry(string empno, string bussdate)
    {
        bool isduplicate = false;
        string qry = "Select * from TBL_DTSAE where EmpID = '" + empno + "' and BussDate = '" + bussdate + "'";
        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand(qry, conn);
        dread = cmd.ExecuteReader();
        dread.Read();
        if (dread.HasRows)
            isduplicate = true;

        dread.Close();
        conn.Close();


        return isduplicate;
    }
    bool IsDateHolidayBeforeAfter(string empnum, DateTime date)
    {
        bool isholiday = false;
        //conn = new SqlConnection(connectionstring);
        //conn.Open();
        //cmd = new SqlCommand("Select * from TBL_HOLIDAY where Holiday = '" + date.ToString("yyyy-MM-dd") + "'", conn);
        //dread = cmd.ExecuteReader();
        //dread.Read();
        //if (dread.HasRows)
        //{
        //    isholiday = true;
        //}
        //dread.Close();
        //conn.Close();

        return isholiday;
    }
    bool IsDateRDForHoliday(DateTime date, string empno)
    {
        bool ret = false;
        Dictionary<string, string> param = new Dictionary<string, string>();
        string sched_TimeIn = "";
        string sched_TimeOut = "";
        Dictionary<string, string> empSchedInfo = new Dictionary<string, string>();
        try
        {
            conn = new SqlConnection(connectionstring);
            conn.Open();
            get_emp_info(empno, date, out empSchedInfo, true);
        }
        finally
        {
            conn.Close();
        }
        if (empSchedInfo.Count > 1)
        {
            if (empSchedInfo.ContainsKey("Sched_TimeIn") && empSchedInfo.ContainsKey("Sched_TimeOut"))
            {
                sched_TimeIn = empSchedInfo["Sched_TimeIn"];
                sched_TimeOut = empSchedInfo["Sched_TimeOut"];
                ret = false;
                if (empSchedInfo["Sched_TimeIn"] == "RD" || empSchedInfo["Sched_TimeOut"] == "RD") ret = true;
            }
            else
            {
                ret = true;
            }

        }
        else
        {
            ret = true;
        }


        return ret;


    }
    bool HasFiledFTSForBeforeAfter(DateTime date, string empno)
    {
        bool HasFTS = false;
        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand("Select * from TBL_FTS where fts_Status = '1' and EmpID = '" + empno + "' and buss_date ='" + date.ToString("yyyy-MM-dd") + "'", conn);

        dread = cmd.ExecuteReader();
        dread.Read();
        if (dread.HasRows)
        {
            HasFTS = true;
        }
        dread.Close();
        conn.Close();

        return HasFTS;
    }
    bool HasFiledLeaveForBeforeAfter(DateTime date, string empno)
    {
        bool HasLeave = false;
        string schedIn = ""; string schedOut = "";
        Dictionary<string, string> empSchedInfo = new Dictionary<string, string>();
        try
        {
            conn = new SqlConnection(connectionstring);
            conn.Open();
            get_emp_info(empno, date, out empSchedInfo, true);
        }
        finally
        {
            conn.Close();
        }
        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand("Select * from TBL_LEAVESAPP where LeaveStatus = '1' and LeaveKey NOT LIKE '%WOP%' and EmpID = '" + empno + "' and '" + date.ToString("yyyy-MM-dd") + "' BETWEEN TBL_LEAVESAPP.DateFrom AND TBL_LEAVESAPP.DateTo", conn);

        dread = cmd.ExecuteReader();
        dread.Read();
        if (dread.HasRows)
        {
            if (empSchedInfo.Count > 1)
            {
                schedIn = empSchedInfo["Sched_TimeIn"];
                schedOut = empSchedInfo["Sched_TimeOut"];
                if (schedIn != "RD" && schedOut != "RD")
                    HasLeave = true;
                else
                    HasLeave = false;


            }

        }
        dread.Close();
        conn.Close();

        return HasLeave;
    }
    bool HasFiledOBTForBeforeAfter(DateTime date, string empno)
    {
        bool HasOBT = false;

        conn = new SqlConnection(connectionstring);
        conn.Open();
        cmd = new SqlCommand("Select * from TBL_OBT where OBT_Status = '1' and EmpID = '" + empno + "' and ('" + date.ToString("yyyy-MM-dd") + "' BETWEEN TBL_OBT.DateFrom AND TBL_OBT.DateTo)", conn);
        //cmd = new SqlCommand("Select * from TBL_OBT where OBT_Status = '1' and EmpID = '" + empno + "' and TripDate = '" + date.ToString("yyyy-MM-dd") + "' ", conn);

        dread = cmd.ExecuteReader();
        dread.Read();
        if (dread.HasRows)
        {
            HasOBT = true;
        }
        dread.Close();
        conn.Close();

        return HasOBT;
    }

    #endregion new
}
