using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin
{
    public partial class viewOffensesType : System.Web.UI.Page
    {
        public AdminLib adlib = new AdminLib();
        public Common cm = new Common();
        public Employee emp = new Employee();
        public string offenseno = "";
        string empviewURL = "";
        public int gridtotalcount = 0;
        public string gridrangecount = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            offenseno = Request.QueryString["id"];
            if (!IsPostBack)
            {
                refresh();
                

            }
        }
        void refresh()
        {
            DataTable dt = new DataTable();
            dt = adlib.populateGridOffenseType(offenseno);
            GridViewList.DataSource = dt;
            GridViewList.DataBind();
            ViewState["EMP_GRID"] = dt;
            ViewState["SORTDR"] = null;

            offenseDesc.Value = "";
            txtsuspensionDay.Value = "";

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

                

            }

        }
        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            //awong-retrieve textbox values from the grid control during runtime.
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
            string txtoffenseDesc = ((TextBox)currentRow.FindControl("txtoffenseDesc")).Text;
            string txtsuspensionDay = ((TextBox)currentRow.FindControl("txtsuspensionDay")).Text;


            string expr = emp.build_or_like_param(true, saveSearchParam(txtoffenseDesc, txtsuspensionDay));
            //string expr = "and (license_type like '%" + lictype + "%' or license_no like '%" + licno + "%' or lic_expirydate like '%" + licdate + "%')";
            //GridViewList.DataSource = emp.populateGridSearch((DataTable)ViewState["EMP_GRID"], expr);
            GridViewList.DataSource = adlib.populateGridOffenseTypeCol(offenseno,expr);
            GridViewList.DataBind();



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
                HiddenEmpIDView.Value = e.CommandArgument.ToString();
                populateViewField(e.CommandArgument.ToString());
                openTransDetailsView();

            }
            if (e.CommandName == "upd")
            {
                HiddenEmpID.Value = e.CommandArgument.ToString();
                populateUpdateField(e.CommandArgument.ToString());
                openTransDetails();

            }
            if (e.CommandName == "del")
            {
                string getOffenseDesc = cm.GetSpecificDataFromDB("offenseDesc", "TBL_OFFENSESTYPE", "where id = " + e.CommandArgument.ToString() + "");
                emp.DeleteQuery("TBL_OFFENSESTYPE", "where id =" + e.CommandArgument.ToString() + "");
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " removed OFFENSE TYPE " + getOffenseDesc,
                    "DELETE", "x123", "qwg-23", "DELETE", Session["EMP_ID"].ToString());
                refresh();
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Successfully Deleted');",
                true);


            }
        }
        public void populateUpdateField(string id)
        {
            UPD_OffenseDesc.Value = cm.GetSpecificDataFromDB("offenseDesc", "TBL_OFFENSESTYPE", "where id = " + id + "");
            UPD_SuspensionDays.Value = cm.GetSpecificDataFromDB("suspensionDay", "TBL_OFFENSESTYPE", "where id = " + id + "");
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
        public void closeTransDetails()
        {
            upListDetails.Update();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(string.Format(@"$('#{0}').modal('hide')", "listmodal"));
            sb.Append(@"</script>");

            ScriptManager.RegisterStartupScript(this, this.GetType(), "listmodal", sb.ToString(), false);

        }
        protected void lnkbtnXlist_Click(object sender, EventArgs e)
        {
            closeTransDetails();
        }
        protected void lnkbtnXlistView_Click(object sender, EventArgs e)
        {
            closeTransDetailsView();
        }
        
        public void populateViewField(string id)
        {
            VW_OffenseDesc.Text = cm.GetSpecificDataFromDB("offenseDesc", "TBL_OFFENSESTYPE", "where id = " + id + "");
            VW_SuspensionDays.Text = cm.GetSpecificDataFromDB("suspensionDay", "TBL_OFFENSESTYPE", "where id = " + id + "");

        }
        public void openTransDetailsView()
        {
            vwListDetails.Update();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(string.Format(@"$('#{0}').modal('show')", "ViewModal"));
            sb.Append(@"</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ViewModal", sb.ToString(), false);
            

        }
        public void closeTransDetailsView()
        {
            vwListDetails.Update();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(string.Format(@"$('#{0}').modal('hide')", "ViewModal"));
            sb.Append(@"</script>");

            ScriptManager.RegisterStartupScript(this, this.GetType(), "ViewModal", sb.ToString(), false);

        }
        Dictionary<string, string> saveSearchParam(string txtoffense_desc, string txtsuspensionDay)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("offenseDesc", "'%" + txtoffense_desc + "%'");
            param.Add("suspensionDay", "'%" + txtsuspensionDay + "%'");
            return param;
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if(cm.ItemExist("TBL_OFFENSESTYPE","id", "where offenseKey = '"+offenseno+ "' and offenseDesc = '"+offenseDesc.Value+"'",""))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Offense type already exist.');", true);
                    refresh();
                    return;
                }
                if (cm.InsertQueryCommon(saveParam(), "TBL_OFFENSESTYPE"))
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " created OFFENSE TYPE " + offenseDesc.Value,
                           "CREATE", "x123", "qwg-23", "CREATE", Session["EMP_ID"].ToString());
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Offense type successfully save.');", true);
                    refresh();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Please provide required field.');", true);
                    refresh();
                }
            }
        }
        protected void btnsaveUpdate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                string getoffenseKey = cm.GetSpecificDataFromDB("offenseKey", "TBL_OFFENSESTYPE", "where id = " + HiddenEmpID.Value + "");
                if (cm.ItemExist("TBL_OFFENSESTYPE", "offenseDesc", "where offenseDesc = '"+UPD_OffenseDesc.Value+"' AND id != "+HiddenEmpID.Value+" AND offenseKey = '"+ getoffenseKey + "'",""))
                {
                    refresh();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Offense description already exist in this policy');", true);
                    return;
                }
                string getOffenseDesc = cm.GetSpecificDataFromDB("offenseDesc", "TBL_OFFENSESTYPE", "where id = " + HiddenEmpID.Value + "");
                string getSuspensionDay = cm.GetSpecificDataFromDB("suspensionDay", "TBL_OFFENSESTYPE", "where id = " + HiddenEmpID.Value + "");
                if (cm.UpdateQueryCommon(saveUpdateParam(), "TBL_OFFENSESTYPE", "id = " + HiddenEmpID.Value + ""))
                {
                    if (getOffenseDesc != UPD_OffenseDesc.Value)
                    {
                        cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed OFFENSE DESCRIPTION for " + getOffenseDesc + " from " + getOffenseDesc + " to " + UPD_OffenseDesc.Value,
                                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
                    }
                    if (getSuspensionDay != UPD_SuspensionDays.Value)
                    {
                        cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed OFFENSE SUSPENSION DAY for " + getSuspensionDay + " from " + getSuspensionDay + " to " + UPD_SuspensionDays.Value,
                                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
                    }
                    refresh();
                    
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully updated !!!');", true);
                    closeTransDetails();
                    refresh();
                }
                else
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Fields should not be empty !!!');", true);
            }
        }
        Dictionary<string, string> saveParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("offenseKey", "'" + offenseno + "'");
            param.Add("offenseDesc", "'" + offenseDesc.Value + "'");
            param.Add("suspensionDay", "" + (txtsuspensionDay.Value == "" ? "0" : txtsuspensionDay.Value) + "");
            return param;
        }
        Dictionary<string, string> saveUpdateParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("offenseDesc", "'" + UPD_OffenseDesc.Value + "'");
            param.Add("suspensionDay", "" + UPD_SuspensionDays.Value + "");

            return param;


        }

    }
}