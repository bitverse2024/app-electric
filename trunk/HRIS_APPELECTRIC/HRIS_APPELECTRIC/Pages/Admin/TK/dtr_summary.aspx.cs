﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HRIS_APPELECTRIC.Pages.Admin.TK
{
    public partial class dtr_summary : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Timekeeping tk = new Timekeeping();
        Common cm = new Common();
        public int gridtotalcount = 0;
        public string gridrangecount = "";
        public string empno = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                refresh();

            }
        }

        void refresh()
        {
            DataTable dt = new DataTable();
            dt = tk.populateGridSummary();
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
            string _bussdate = ((TextBox)currentRow.FindControl("txtSearchCODate")).Text;
            string _name = ((TextBox)currentRow.FindControl("txtSearchName")).Text;
            string _empid = ((TextBox)currentRow.FindControl("txtSearchPSDays")).Text;
            string _dateIn = ((TextBox)currentRow.FindControl("txtSearchPSAbsent")).Text;
            string _timeIn = ((TextBox)currentRow.FindControl("txtSearchLates")).Text;
            string _dateOut = ((TextBox)currentRow.FindControl("txtSearchUT")).Text;
            string _timeOut = ((TextBox)currentRow.FindControl("txtSearchOT")).Text;

            string expr = emp.build_or_like_param(true, saveSearchParam(_name, _empid, _bussdate, _dateIn, _timeIn, _dateOut, _timeOut));
            //string expr = "and (license_type like '%" + lictype + "%' or license_no like '%" + licno + "%' or lic_expirydate like '%" + licdate + "%')";
            //GridViewList.DataSource = emp.populateGridSearch((DataTable)ViewState["EMP_GRID"], expr);
            GridViewList.DataSource = tk.populateGridSummaryCol(expr);
            GridViewList.DataBind();



        }
        Dictionary<string, string> saveSearchParam(string _name, string _empid, string _bussdate, string _dateIn, string _timeIn, string _dateOut, string _timeOut)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("PSName", "'%" + _name + "%'");
            param.Add("EmpID", "'%" + _empid + "%'");
            if(_bussdate != "")
                param.Add("CODate", "'%" + Convert.ToDateTime(_bussdate).ToString("yyyy-MM-dd") + "%'");
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
            if (e.CommandName == "del")
            {
                emp.DeleteQuery("TBL_PAYROLLSUM", "where id =" + e.CommandArgument.ToString() + "");
                refresh();
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Successfully Deleted');",
                true);

            }
            if (e.CommandName == "upd")
            {
                HiddenEmpID.Value = e.CommandArgument.ToString();
                populateUpdateField(e.CommandArgument.ToString());
                openTransDetails(empno);
            }
            if (e.CommandName == "view")
            {
                HiddenEmpID.Value = e.CommandArgument.ToString();
                populateUpdateField(e.CommandArgument.ToString());
                populateViewField(e.CommandArgument.ToString());
                openTransDetailsView(empno);

            }
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
        public void openTransDetails(string empNo)
        {
            upListDetails.Update();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(string.Format(@"$('#{0}').modal('show')", "listmodal"));
            sb.Append(@"</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "listmodal", sb.ToString(), false);
            string username = "", fullname = "", email = "", roles = "";
        }
        protected void lnkbtnXlist_Click(object sender, EventArgs e)
        {
            closeTransDetails();
        }
        public void populateUpdateField(string id)
        {
            updCODate.Value = cm.FormatDate(cm.GetSpecificDataFromDB("CODate", "TBL_PAYROLLSUM", "where id = " + id + ""));
            updDays.Value = cm.GetSpecificDataFromDB("PSDays", "TBL_PAYROLLSUM", "where id = " + id + "");
            updRegHrsWnd.Value = cm.GetSpecificDataFromDB("RegHrsWND", "TBL_PAYROLLSUM", "where id = " + id + "");
            updRegOT.Value = cm.GetSpecificDataFromDB("OTReg", "TBL_PAYROLLSUM", "where id = " + id + "");
            updOTWND.Value = cm.GetSpecificDataFromDB("OTRegWND", "TBL_PAYROLLSUM", "where id = " + id + "");
            updRegSun.Value = cm.GetSpecificDataFromDB("OTSunExc8Hrs", "TBL_PAYROLLSUM", "where id = " + id + "");
            updSunOT.Value = cm.GetSpecificDataFromDB("OTSun", "TBL_PAYROLLSUM", "where id = " + id + "");
            updOtlh.Value = cm.GetSpecificDataFromDB("OTLH", "TBL_PAYROLLSUM", "where id = " + id + "");
            updOtlhexc8Hrs.Value = cm.GetSpecificDataFromDB("OTLHExc8Hrs", "TBL_PAYROLLSUM", "where id = " + id + "");
            updEcola.Value = cm.GetSpecificDataFromDB("ecola", "TBL_PAYROLLSUM", "where id = " + id + "");
            updAbsent.Value = cm.GetSpecificDataFromDB("PSabsent", "TBL_PAYROLLSUM", "where id = " + id + "");
            updUndertime.Value = cm.GetSpecificDataFromDB("UTmin", "TBL_PAYROLLSUM", "where id = " + id + "");
            updLates.Value = cm.GetSpecificDataFromDB("Latesmin", "TBL_PAYROLLSUM", "where id = " + id + "");
        }
        public void openTransDetailsView(string empNo)
        {
            upListDetails2.Update();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(string.Format(@"$('#{0}').modal('show')", "ViewModal"));
            sb.Append(@"</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ViewModal", sb.ToString(), false);
            string divname = "";

        }
        public void closeTransDetailsView()
        {
            upListDetails2.Update();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(string.Format(@"$('#{0}').modal('hide')", "ViewModal"));
            sb.Append(@"</script>");

            ScriptManager.RegisterStartupScript(this, this.GetType(), "ViewModal", sb.ToString(), false);

        }
        protected void lnkbtnXlistView_Click(object sender, EventArgs e)
        {
            closeTransDetailsView();
        }
        public void populateViewField(string id)
        {
            vwCODate.Value = updCODate.Value;
            vwDays.Value = updDays.Value;
            vwRegHrsWnd.Value = updRegHrsWnd.Value;
            vwRegOT.Value = updRegOT.Value;
            vwOTWND.Value = updOTWND.Value;
            vwRegSun.Value = updRegSun.Value;
            vwSunOT.Value = updSunOT.Value;
            vwOtlh.Value = updOtlh.Value;
            vwOtlhexc8Hrs.Value = updOtlhexc8Hrs.Value;
            vwEcola.Value = updEcola.Value;
            vwAbsent.Value = updAbsent.Value;
            vwUndertime.Value = updUndertime.Value;
            vwLates.Value = updLates.Value;
        }
        Dictionary<string, string> saveUpdateParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            List<string> approver = new List<string>();
            param.Add("CODate", "'" + updCODate.Value + "'");
            param.Add("PSDays", "'" + updDays.Value + "'");
            param.Add("RegHrsWND", "'" + updRegHrsWnd.Value + "'");
            param.Add("OTReg", "'" + updEcola.Value + "'");
            param.Add("OTRegWND", "'" + updRegOT.Value + "'");
            param.Add("OTSunExc8Hrs", "'" + updOTWND.Value + "'");
            param.Add("OTSun", "'" + updRegSun.Value + "'");
            param.Add("OTLH", "'" + updSunOT.Value + "'");
            param.Add("OTLHExc8Hrs", "'" + updOtlh.Value + "'");
            param.Add("ecola", "'" + updOtlhexc8Hrs.Value + "'");
            param.Add("PSabsent", "'" + updAbsent.Value + "'");
            param.Add("UTmin", "'" + updUndertime.Value + "'");
            param.Add("Latesmin", "'" + updLates.Value + "'");

            return param;


        }
        protected void btnsaveUpdate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if (cm.UpdateQueryCommon(saveUpdateParam(), "TBL_PAYROLLSUM", "id = '" + HiddenEmpID.Value + "'"))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully updated !!!');", true);
                    closeTransDetails();
                    refresh();
                }
            }
        }
    }
}