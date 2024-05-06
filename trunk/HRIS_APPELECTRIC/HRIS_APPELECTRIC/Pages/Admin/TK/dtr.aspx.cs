using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

namespace HRIS_APPELECTRIC.Pages.Admin.TK
{
    public partial class dtr : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Timekeeping tk = new Timekeeping();
        Common cm = new Common();
        public string empno = "";
        string empviewURL = "";
        public int gridtotalcount = 0;
        public string gridrangecount = "";
        protected void Page_Load(object sender, EventArgs e)
        {//advanceSearch_Click
         //empno = Request.QueryString["id"];
         //if (empno != Session["ACTIVE_EMPNO"].ToString())
         //{

            //    empno = Session["ACTIVE_EMPNO"].ToString();
            //    ScriptManager.RegisterStartupScript(this, this.GetType(),
            //    "alert",
            //    "alert('Injection not allowed!!!');window.location ='viewtraining.aspx?id=" + empno + "';",
            //    true);
            //}
            if (!IsPostBack)
            {
                refresh();
            }
        }

        void refresh()
        {
            DataTable dt = new DataTable();
            dt = tk.populateGridDTRMaster();
            GridViewList.DataSource = dt;
            GridViewList.DataBind();
            ViewState["EMP_GRID"] = dt;
            ViewState["SORTDR"] = null;
            summary();
        }
        void summary()
        {
            gridtotalcount = ((DataTable)ViewState["EMP_GRID"]).Rows.Count;
            int pageIndex = GridViewList.PageIndex;
            int c = (pageIndex > 0 ? 10 * pageIndex : 0) + GridViewList.Rows.Count;
            gridrangecount = (c > 0 ? c : 0) + " - " + gridtotalcount;
        }
        protected void sort_grid(string sort_args)
        {
            DataTable dt = (DataTable)ViewState["EMP_GRID"];
            if (dt.Rows.Count > 0)
            {
                if (Convert.ToString(ViewState["SORTDR"]) == "Asc")
                {
                    dt.DefaultView.Sort = sort_args + " Desc";
                    ViewState["SORTDR"] = "Desc";
                }
                else
                {
                    dt.DefaultView.Sort = sort_args + " Asc";
                    ViewState["SORTDR"] = "Asc";
                }

                GridViewList.DataSource = dt;
                GridViewList.DataBind();
                summary();

            }

        }
        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            //awong-retrieve textbox values from the grid control during runtime.
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
            string _name = ((TextBox)currentRow.FindControl("txtSearchEmp_Name")).Text;
            string _empid = ((TextBox)currentRow.FindControl("txtSearchEmpID")).Text;
            string _bussdate = ((TextBox)currentRow.FindControl("txtSearchBussDate")).Text;
            string _dateIn = ((TextBox)currentRow.FindControl("txtSearchDateIn")).Text;
            string _timeIn = ((TextBox)currentRow.FindControl("txtSearchDTimeIn")).Text;
            string _dateOut = ((TextBox)currentRow.FindControl("txtSearchDateOut")).Text;
            string _timeOut = ((TextBox)currentRow.FindControl("txtSearchDTimeOut")).Text;

            string expr = emp.build_or_like_param(true, saveSearchParam(_name, _empid, _bussdate, _dateIn, _timeIn, _dateOut, _timeOut));
            //string expr = "and (license_type like '%" + lictype + "%' or license_no like '%" + licno + "%' or lic_expirydate like '%" + licdate + "%')";
            //GridViewList.DataSource = emp.populateGridSearch((DataTable)ViewState["EMP_GRID"], expr);
            GridViewList.DataSource = tk.populateGridDTRMasterCol(expr);
            GridViewList.DataBind();



        }
        Dictionary<string, string> saveSearchParam(string _name, string _empid, string _bussdate, string _dateIn, string _timeIn, string _dateOut, string _timeOut)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("Emp_Name", "'%" + _name + "%'");
            param.Add("EmpID", "'%" + _empid + "%'");
            param.Add("BussDate", "'%" + _bussdate + "%'");
            param.Add("DateIn", "'%" + _dateIn + "%'");
            param.Add("DTimeIn", "'%" + _timeIn + "%'");
            param.Add("DateOut", "'%" + _dateOut + "%'");
            param.Add("DTimeOut", "'%" + _timeOut + "%'");

            return param;


        }
        protected void GridViewList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewList.PageIndex = e.NewPageIndex;
            refresh();
        }
        protected void GridViewList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sort")
            {
                sort_grid(e.CommandArgument.ToString());

            }
            if (e.CommandName == "Reset")
            {
                refresh();

            }
            if(e.CommandName == "upd")
            {
                HiddenEmpID.Value = e.CommandArgument.ToString();
                populateUpdateField(HiddenEmpID.Value);
                openTransDetails(HiddenEmpID.Value);



            }
            if (e.CommandName == "del")
            {
                emp.DeleteQuery("TBL_DTR", "where id =" + e.CommandArgument.ToString() + "");
                refresh();
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Successfully Deleted');",
                true);

            }
        }
       
        public void openTransDetails(string empNo)
        {
            upListDetails.Update();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(string.Format(@"$('#{0}').modal('show')", "listmodal"));
            sb.Append(@"</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "listmodal", sb.ToString(), false);
            string updempid = cm.GetSpecificDataFromDB("EmpID", "TBL_DTR", "where id = " + empNo + "");
            lblName.Text = cm.GetSpecificDataFromDB("emp_FullName", "TBL_EMPLOYEE_MASTER", " where emp_EmpID = '" + updempid + "'");
        }
        protected void btnsaveUpdate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                TimeSpan schedtimeIn = TimeSpan.Parse(upd_TimeIn.Value);
                TimeSpan schedtimeOut = TimeSpan.Parse(upd_TimeOut.Value);
                /* -1 t1 is shoter than t2
                    0 t1 is equal to t2
                    1 t1 is longer than t2
                */
                int i = TimeSpan.Compare(schedtimeIn, schedtimeOut);
                if (i == -1)
                {

                
                        if (cm.UpdateQueryCommon(saveUpdateParam(schedtimeIn.ToString(@"h\:mm"),schedtimeOut.ToString(@"h\:mm")), "TBL_DTR", "id = " + HiddenEmpID.Value + ""))
                    {
                    
                        refresh();
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully updated');", true);
                        closeTransDetails();
                        refresh();
                    }
                    else
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Fields should not be empty!');", true);
                }
                else
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Schedule time-in should be shorter than time-out');", true);
            }
        }
        protected void lnkbtnXlist_Click(object sender, EventArgs e)
        {
            closeTransDetails();
        }
        Dictionary<string, string> saveUpdateParam(string schedtimein, string schedtimeout)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            {
                param.Add("Sched_TimeIn", "'" + schedtimein + "'");
                param.Add("Sched_TimeOut", "'" + schedtimeout + "'");
            }
            
                



            return param;
        }
        public void populateUpdateField(string id)
        {
            
            TimeSpan schedtimeIn = TimeSpan.Parse(cm.GetSpecificDataFromDB("Sched_TimeIn", "TBL_DTR", "where id = " + id + ""));
            TimeSpan schedtimeOut = TimeSpan.Parse(cm.GetSpecificDataFromDB("Sched_TimeOut", "TBL_DTR", "where id = " + id + ""));

            upd_TimeIn.Value = schedtimeIn.ToString(@"hh\:mm");
            upd_TimeOut.Value = schedtimeOut.ToString(@"hh\:mm");
            
            //if (upd_TimeIn.Value == "")
            //{
            //    lblTIn.Visible = false;
            //    upd_TimeIn.Disabled = true;
            //    upd_TimeIn.Visible = false;
            //    RequiredFieldValidator3.Enabled = false;


            //    lblTOut.Visible = true;
            //    upd_TimeOut.Visible = true;
            //    upd_TimeOut.Disabled = false;
            //    RequiredFieldValidator2.Enabled = true;


            //}
            //if (upd_TimeOut.Value == "")
            //{
            //    lblTOut.Visible = false;
            //    upd_TimeOut.Visible = false;
            //    upd_TimeOut.Disabled = true;
            //    RequiredFieldValidator2.Enabled = false;


            //    lblTIn.Visible = true;
            //    upd_TimeIn.Visible = true;
            //    upd_TimeIn.Disabled = false;
            //    RequiredFieldValidator3.Enabled = true;

            //}

        }
        public void closeTransDetails()
        {
            upListDetails.Update();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(string.Format(@"$('#{0}').modal('hide')", "listmodal"));
            sb.Append(@"</script>");

            ScriptManager.RegisterStartupScript(this, this.GetType(), "listmodal", sb.ToString(), false);

        }

    }
}