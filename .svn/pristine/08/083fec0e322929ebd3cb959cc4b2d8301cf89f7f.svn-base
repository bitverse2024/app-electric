using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin.PayrollPages
{
    public partial class employeeded : System.Web.UI.Page
    {
        public int gridtotalcount = 0;
        public string gridrangecount = "";
        public static string empno = "";
        Employee emp = new Employee();
        Common cm = new Common();
        protected void Page_Load(object sender, EventArgs e)
        {
            empno = Request.QueryString["empid"];
            if (!IsPostBack)
            {
                if(Session["ROLES"] == null)
                {
                    Session.Clear();
                    Session.Abandon();
                    Response.Redirect("~/Pages/Login.aspx");
                }
                if (Session["ROLES"].ToString() != "admin")
                {
                    Session.Clear();
                    Session.Abandon();
                    Response.Redirect("~/Pages/Login.aspx");
                }
                refresh();
            }

        }
        void refresh()
        {
            DataTable dt = new DataTable();
            dt = emp.populateGridEmployeeAdjustment(empno);
            GridViewList.DataSource = dt;
            GridViewList.DataBind();
            ViewState["EMP_GRID"] = dt;
            ViewState["SORTDR"] = null;
            summary();
        }
        Dictionary<string, string> saveSearchParam(string _cutoffid, string _sssded, string _philded, string _pabibigded, string _tax)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();

            param.Add("CutOffID", "'%" + _cutoffid + "%'");
            param.Add("SSSDed", "'%" + _sssded + "%'");
            param.Add("PhilDed", "'%" + _philded + "%'");
            param.Add("PagibigDed", "'%" + _pabibigded + "%'");
            param.Add("empTax", "'%" + _tax + "%'");
            return param;


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
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
            string _cutoffid = ((TextBox)currentRow.FindControl("txtCutOffID")).Text;
            string _sssded = ((TextBox)currentRow.FindControl("txtSSSDed")).Text;
            string _philded = ((TextBox)currentRow.FindControl("txtPhilDed")).Text;
            string _pabibigded = ((TextBox)currentRow.FindControl("txtPagibigDed")).Text;
            string _empTax = ((TextBox)currentRow.FindControl("txtempTax")).Text;
            string expr = emp.build_or_like_param(saveSearchParam(_cutoffid, _sssded, _philded, _pabibigded, _empTax));
            GridViewList.DataSource = emp.populateGridEmployeeAdjustmentCol(expr, empno);
            GridViewList.DataBind();
            summary();
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
            if (e.CommandName == "view")
            {
                //Session["ACTIVE_EMPNO"] = e.CommandArgument.ToString();
                //Response.Redirect("~/Pages/Admin/PayrollPages/viewdts.aspx?id=" + e.CommandArgument.ToString());

            }
            if (e.CommandName == "upd")
            {
                HiddenEmpID.Value = e.CommandArgument.ToString();
                populateUpdateField(e.CommandArgument.ToString());
                openTransDetails();

            }
        }

        public void populateUpdateField(string id)
        {
            Dictionary<string, string> getDict = new Dictionary<string, string>();
            getDict = cm.GetTableDict("TBL_DEDUCTIONADJ", "where id = " + id + "");
            string sssupd = getDict["SSSDed"];
            string philupd = getDict["PhilDed"];
            string pagibigupd = getDict["PagibigDed"];
            string emptaxupd = getDict["empTax"];
            if (!string.IsNullOrEmpty(sssupd))
            {
                updSSS.Text = sssupd;
            }
            if (!string.IsNullOrEmpty(philupd))
            {
                updPhilhealth.Text = philupd;
            }
            if (!string.IsNullOrEmpty(pagibigupd))
            {
                updPagibig.Text = pagibigupd;
            }
            if (!string.IsNullOrEmpty(emptaxupd))
            {
                updTax.Text = emptaxupd;
            }

        }
        protected void btnsaveUpdate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                Dictionary<string, string> getDict = new Dictionary<string, string>();
                getDict = cm.GetTableDict("TBL_DEDUCTIONADJ", "where id = " + HiddenEmpID.Value + "");
                if (cm.UpdateQueryCommon(saveUpdateParam(), "TBL_DEDUCTIONADJ", "id = " + HiddenEmpID.Value + ""))
                {
                    refresh();
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " update DEDUCTION ADJUSTMENT for employee = " + empno + " Cutoff = " + getDict["CutOffID"],
                                "CREATE", "x123", "qwg-23", "CREATE", Session["EMP_ID"].ToString());
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully updated !!!');", true);
                    closeTransDetails();
                    refresh();
                }
                else
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Fields should not be empty !!!');", true);
            }
        }
        Dictionary<string, string> saveUpdateParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(updSSS.Text))
            {
                param.Add("SSSDed", "" + updSSS.Text + "");

            }
            if (!string.IsNullOrEmpty(updPhilhealth.Text))
            {
                param.Add("PhilDed", "" + updPhilhealth.Text + "");

            }
            if (!string.IsNullOrEmpty(updPagibig.Text))
            {
                param.Add("PagibigDed", "" + updPagibig.Text + "");

            }
            if (!string.IsNullOrEmpty(updTax.Text))
            {
                param.Add("empTax", "" + updTax.Text + "");

            }



            return param;


        }
        protected void lnkbtnXlist_Click(object sender, EventArgs e)
        {
            closeTransDetails();
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
        public void openTransDetails()
        {
            upListDetails.Update();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(string.Format(@"$('#{0}').modal('show')", "listmodal"));
            sb.Append(@"</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "listmodal", sb.ToString(), false);
        }
    }
}