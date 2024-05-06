using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HRIS_APPELECTRIC.Pages.Announcement
{
    public partial class announcements : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Common cm = new Common();
        Timekeeping tk = new Timekeeping();
        public string empno = "";
        string empviewURL = "";
        public int gridtotalcount = 0;
        public string gridrangecount = "";
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
            dt = tk.populateGridAnnouncement();
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

            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
            string description = ((TextBox)currentRow.FindControl("txtSearchannDesc")).Text;

            string expr = emp.build_or_like_param(true, saveSearchParam(description));

            GridViewList.DataSource = tk.populateGridAnnouncementCol(expr);
            GridViewList.DataBind();



        }
        Dictionary<string, string> saveSearchParam(string description)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("description", "'%" + description + "%'");


            return param;


        }
        protected void GridViewList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewList.PageIndex = e.NewPageIndex;
            refresh();
        }
        protected void GridViewList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                emp.DeleteQuery("TBL_ANNOUNCEMENT", "where id =" + e.CommandArgument.ToString() + "");

                refresh();
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Successfully Deleted');",
                true);

            }

            if (e.CommandName == "view")
            {
                HiddenEmpID.Value = e.CommandArgument.ToString();
                populateViewField(HiddenEmpID.Value);
                openTransDetailsView();
            }

            if (e.CommandName == "upd")
            {
                HiddenEmpID.Value = e.CommandArgument.ToString();
                populateUpdateField(HiddenEmpID.Value);
                openTransDetails();
                
            }

            if (e.CommandName == "Sort")
            {
                sort_grid(e.CommandArgument.ToString());

            }

            if (e.CommandName == "Reset")
            {
                refresh();
            }
        }

        public void populateViewField(string id)
        {

            txtDescription.Value = cm.GetSpecificDataFromDB("description", "TBL_ANNOUNCEMENT", " where id = " + id + "");

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
        public void openTransDetailsView()
        {
            upListDetails2.Update();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(string.Format(@"$('#{0}').modal('show')", "ViewModal"));
            sb.Append(@"</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ViewModal", sb.ToString(), false);
        }



        protected void lnkbtnXlistView_Click(object sender, EventArgs e)
        {
            closeTransDetailsView();
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



        protected void lnkbtnXlist_Click(object sender, EventArgs e)
        {
            closeTransDetails();
        }

        Dictionary<string, string> saveUpdateParam(string desc)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("description", "'" + desc + "'");


            return param;


        }

        protected void btnsaveUpdate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                //getdata();
                if (TaDesc.Value != "")
                {

                    cm.UpdateQueryCommon(saveUpdateParam(TaDesc.Value), "TBL_ANNOUNCEMENT", "id = " + HiddenEmpID.Value + "");
                    refresh();

                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully updated !!!');", true);
                    closeTransDetails();
                    refresh();
                }
                else
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Fields should not be empty !!!');", true);
            }
        }

        public void populateUpdateField(string id)
        {
            string idval = id;
            TaDesc.Value = cm.GetSpecificDataFromDB("description", "TBL_ANNOUNCEMENT", " where id = " + id + "");

        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("content-disposition", "attachment;filename= Announcement" + ".xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Charset = "";
            this.EnableViewState = false;

            System.IO.StringWriter swriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlwriter = new System.Web.UI.HtmlTextWriter(swriter);

            DataGrid dg = new DataGrid();
            dg.DataSource = tk.populateGridAnnouncement();
            dg.DataBind();

            dg.RenderControl(htmlwriter);


            Response.Write(swriter.ToString());
            cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " exported Announcements",
            "EXPORT", "ANNOUNCEMENT", Session["EMP_ID"].ToString(), "ANNOUNCEMENT", Session["EMP_ID"].ToString());
            Response.End();
            //exportTOxlsx();


        }
    }
}