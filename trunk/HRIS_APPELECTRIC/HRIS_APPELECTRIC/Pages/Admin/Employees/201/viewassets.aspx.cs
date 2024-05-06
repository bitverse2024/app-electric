using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HRIS_APPELECTRIC.Pages.Admin.Employees._201
{
    public partial class viewassets : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Common cm = new Common();
        public string empno = "";
        string empviewURL = "";
        public int gridtotalcount = 0;
        public string gridrangecount = "";
        string getitem;
        string getserial;
        string getbrand;
        string getmodel;
        string getquantity;
        protected void Page_Load(object sender, EventArgs e)
        {
            empno = Request.QueryString["id"];
            if (empno != Session["ACTIVE_EMPNO"].ToString())
            {

                empno = Session["ACTIVE_EMPNO"].ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Injection not allowed!!!');window.location ='viewassets.aspx?id=" + empno + "';",
                true);
            }
            if (Session["ROLES"].ToString() != "admin" && Session["ROLES"].ToString() != "employee")
            {
                Response.Redirect("~/Pages/Login.aspx");
            }
            if (!IsPostBack)
            {
                refresh();
            }
        }
        public string getname()
        {
            string name = "";
            name = emp.GetEmployeeName(empno);

            return name;

        }
        void refresh()
        {
            DataTable dt = new DataTable();
            dt = emp.populateGridAsset(empno);
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
            string s_item = ((TextBox)currentRow.FindControl("txtSearchItem")).Text;
            string s_serial_no = ((TextBox)currentRow.FindControl("txtSearchSerialNo")).Text;
            string s_model = ((TextBox)currentRow.FindControl("txtSearchModel")).Text;
            string s_brand = ((TextBox)currentRow.FindControl("txtSearchbrand")).Text;
            string s_quantity = ((TextBox)currentRow.FindControl("txtSearchqty")).Text;

            string expr = emp.build_or_like_param(saveSearchParam(s_item, s_serial_no, s_brand, s_model, s_quantity));
            //string expr = "and (license_type like '%" + lictype + "%' or license_no like '%" + licno + "%' or lic_expirydate like '%" + licdate + "%')";
            //GridViewList.DataSource = emp.populateGridSearch((DataTable)ViewState["EMP_GRID"], expr);
            GridViewList.DataSource = emp.populateGridAssetCol(empno, expr);
            GridViewList.DataBind();



        }
        Dictionary<string, string> saveSearchParam(string s_item, string s_serial_no, string s_brand, string s_model, string s_quantity)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add(item.ID, "'%" + s_item + "%'");
            param.Add(serial_no.ID, "'%" + s_serial_no + "%'");
            param.Add(brand.ID, "'%" + s_brand + "%'");
            param.Add(model.ID, "'%" + s_model + "%'");
            param.Add(quantity.ID, "" + s_quantity + "");
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
            if (e.CommandName == "view")
            {
                HiddenEmpID.Value = e.CommandArgument.ToString();
                populateUpdateField(e.CommandArgument.ToString());
                populateViewField(e.CommandArgument.ToString());
                openTransDetailsView(empno);

            }
            if (e.CommandName == "upd")
            {
                HiddenEmpID.Value = e.CommandArgument.ToString();
                populateUpdateField(e.CommandArgument.ToString());
                openTransDetails(empno);
            }
            if (e.CommandName == "del")
            {
                getitem = cm.GetSpecificDataFromDB("item", "TBL_ASSETS", "where id = " + e.CommandArgument.ToString() + "");
                emp.DeleteQuery("TBL_ASSETS", "where id =" + e.CommandArgument.ToString() + "");
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " removed Asset with ITEM: " + getitem + " for " + emp.GetEmployeeName(empno), "DELETE", "x123", "qwg-23", "DELETE", Session["EMP_ID"].ToString());
                refresh();
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Successfully Deleted');",
                true);

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
            string divname = "";
        }

        public void populateUpdateField(string id)
        {
            upd_item.Value = cm.GetSpecificDataFromDB("item", "TBL_ASSETS", "where id = " + id + "");
            upd_serial_no.Value = cm.GetSpecificDataFromDB("serial_no", "TBL_ASSETS", "where id = " + id + "");
            upd_brand.Value = cm.GetSpecificDataFromDB("brand", "TBL_ASSETS", "where id = " + id + "");
            upd_model.Value = cm.GetSpecificDataFromDB("model", "TBL_ASSETS", "where id = " + id + "");
            upd_quantity.Value = cm.GetSpecificDataFromDB("quantity", "TBL_ASSETS", "where id = " + id + "");
            string divname = "";
        }

        protected void lnkbtnXlist_Click(object sender, EventArgs e)
        {
            closeTransDetails();
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
            vw_item.Value = upd_item.Value;
            vw_serial_no.Value = upd_serial_no.Value;
            vw_model.Value = upd_model.Value;
            vw_brand.Value = upd_brand.Value;
            vw_quantity.Value = upd_quantity.Value;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if (emp.InsertQueryCommon(saveParam(), "TBL_ASSETS"))
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " created Asset with ITEM: " + item.Value + " for " + emp.GetEmployeeName(empno), "CREATE", "x123", "qwg-23", "CREATE", Session["EMP_ID"].ToString());
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Save !!!');", true);
                    refresh();
                    item.Value = "";
                    serial_no.Value = "";
                    brand.Value = "";
                    model.Value = "";
                    quantity.Value = "";
                }
            }
        }

        Dictionary<string, string> saveParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add(item.ID, "'" + item.Value + "'");
            param.Add(serial_no.ID, "'" + serial_no.Value + "'");
            param.Add(brand.ID, "'" + brand.Value + "'");
            param.Add(model.ID, "'" + model.Value + "'");
            param.Add(quantity.ID, "" + quantity.Value + "");
            param.Add("EmpID", "'" + empno + "'");
            return param;


        }
        Dictionary<string, string> saveUpdateParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add(item.ID, "'" + upd_item.Value + "'");
            param.Add(serial_no.ID, "'" + upd_serial_no.Value + "'");
            param.Add(brand.ID, "'" + upd_brand.Value + "'");
            param.Add(model.ID, "'" + upd_model.Value + "'");
            param.Add(quantity.ID, "" + upd_quantity.Value + "");
            param.Add("EmpID", "'" + empno + "'");
            return param;


        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            item.Value = "";
            serial_no.Value = "";
            brand.Value = "";
            model.Value = "";
            quantity.Value = "";
            refresh();
        }

        public void addlog()
        {
            if (getitem != upd_item.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Asset ITEM for " + emp.GetEmployeeName(empno) + " from " + getitem + " to " + upd_item.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getserial != upd_serial_no.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Asset SERIAL NUMBER for " + emp.GetEmployeeName(empno) + " from " + getserial + " to " + upd_serial_no.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getbrand != upd_brand.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Asset BRAND for " + emp.GetEmployeeName(empno) + " from " + getbrand + " to " + upd_brand.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getmodel != upd_model.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Asset MODEL for " + emp.GetEmployeeName(empno) + " from " + getmodel + " to " + upd_model.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getquantity != upd_quantity.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Asset QUANTITY for " + emp.GetEmployeeName(empno) + " from " + getquantity + " to " + upd_quantity.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
        }

        protected void btnsaveUpdate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                getitem = cm.GetSpecificDataFromDB("item", "TBL_ASSETS", "where id = " + HiddenEmpID.Value + "");
                getserial = cm.GetSpecificDataFromDB("serial_no", "TBL_ASSETS", "where id = " + HiddenEmpID.Value + "");
                getbrand = cm.GetSpecificDataFromDB("brand", "TBL_ASSETS", "where id = " + HiddenEmpID.Value + "");
                getmodel = cm.GetSpecificDataFromDB("model", "TBL_ASSETS", "where id = " + HiddenEmpID.Value + "");
                getquantity = cm.GetSpecificDataFromDB("quantity", "TBL_ASSETS", "where id = " + HiddenEmpID.Value + "");
                if (cm.UpdateQueryCommon(saveUpdateParam(), "TBL_ASSETS", "id = '" + HiddenEmpID.Value + "'"))
                {
                    addlog();
                    refresh();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully updated !!!');", true);
                    closeTransDetails();
                    refresh();
                }
            }
        }
    }
}