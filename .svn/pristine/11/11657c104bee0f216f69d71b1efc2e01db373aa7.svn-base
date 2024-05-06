using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace HRIS_APPELECTRIC.Pages.Admin
{
    public partial class LeaveType : System.Web.UI.Page
    {
        Common cm = new Common();
        Employee emp = new Employee();
        AdminLib admin = new AdminLib();
        public string empno = "";
        string divid = "";
        public int gridtotalcount = 0;
        public string gridrangecount = "";
        string getleave;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ROLES"].ToString() != "admin")
                {
                    Response.Redirect("~/Pages/Login.aspx");
                }
                refresh();
            }
        }

        void refresh()
        {
            DataTable dt = new DataTable();
            dt = admin.populateGridLeaveType();
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
        protected void txtLeaveTypeDesc_TextChanged(object sender, EventArgs e)
        {
            //awong-retrieve textbox values from the grid control during runtime.
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
            string txtLeaveTypeDesc = ((TextBox)currentRow.FindControl("txtLeaveTypeDesc")).Text;

            string expr = emp.build_or_like_param(true, saveSearchParam(txtLeaveTypeDesc));
            //string expr = "and (license_type like '%" + lictype + "%' or license_no like '%" + licno + "%' or lic_expirydate like '%" + licdate + "%')";
            //GridViewList.DataSource = emp.populateGridSearch((DataTable)ViewState["EMP_GRID"], expr);
            GridViewList.DataSource = admin.populateGridLeaveTypeCol(expr);
            GridViewList.DataBind();
        }

        Dictionary<string, string> saveSearchParam(string txtLeaveTypeDesc)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("LeaveTypeDesc", "'%" + txtLeaveTypeDesc + "%'");

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
                getleave = cm.GetSpecificDataFromDB("LeaveTypeDesc", "TBL_LEAVETYPE", "where id = " + e.CommandArgument.ToString() + "");
                emp.DeleteQuery("TBL_LEAVETYPE", "where id =" + e.CommandArgument.ToString() + "");
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " removed Leave Type " + getleave,
                            "DELETE", "x123", "qwg-23", "DELETE", Session["EMP_ID"].ToString());
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
            //db_Emp.getUserInfo(empNo, out username, out fullname, out email, out roles);

            //upd_CompanyName.Value = "";

            //TODO dapat fullname to


            //db_Emp.getEmployeeInfo(empNo, out fname, out mname, out lname);
            ////txtbox_fname.Text = fname;
            ////txtbox_mname.Text = mname;
            ////txtbox_lname.Text = lname;




        }

        public void populateUpdateField(string id)
        {
            upd_LeaveTypeDesc.Value = cm.GetSpecificDataFromDB("LeaveTypeDesc", "TBL_LEAVETYPE", "where id = " + id + "");
            updLeaveKey.Value = cm.GetSpecificDataFromDB("LeaveKey", "TBL_LEAVETYPE", "where id = " + id + "");
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
            vw_ID.Value = cm.GetSpecificDataFromDB("id", "TBL_LEAVETYPE", "where id = " + id + "");
            vw_LeaveTypeDesc.Value = cm.GetSpecificDataFromDB("LeaveTypeDesc", "TBL_LEAVETYPE", "where id = " + id + "");
            //vw_LeaveTypeDesc.Value = upd_LeaveTypeDesc.Value;
        }

        Dictionary<string, string> saveUpdateParam(string leavename,string leavekey)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("LeaveTypeDesc", "'" + leavename + "'");
            param.Add("LeaveKey", "'" + leavekey + "'");
            



            return param;
        }
        protected void btnsaveUpdate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                getleave = cm.GetSpecificDataFromDB("LeaveTypeDesc", "TBL_LEAVETYPE", "where id = " + HiddenEmpID.Value + "");
                if (cm.UpdateQueryCommon(saveUpdateParam(upd_LeaveTypeDesc.Value,updLeaveKey.Value), "TBL_LEAVETYPE", "id = " + HiddenEmpID.Value + ""))
                {
                    if (getleave != upd_LeaveTypeDesc.Value)
                    {
                        cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Leave Type DESCRIPTION for " + getleave + " from " + getleave + " to " + upd_LeaveTypeDesc.Value,
                                "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
                    }
                    refresh();
                    //db_Emp.updateUserInfo(HiddenEmpID.Value, txtbox_username.Text, txtbox_password.Text, (drpdwn_acctstatus.SelectedValue == "1" ? true : false));
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully updated !!!');", true);
                    closeTransDetails();
                    refresh();
                }
                else
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Fields should not be empty !!!');", true);
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataGrid dg = new DataGrid();
            dg.DataSource = admin.populateGridLeaveType();
            dg.DataBind();
            if (dg.Items.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("content-disposition", "attachment;filename= LeaveType" + ".xls");
                Response.ContentType = "application/vnd.ms-excel";
                Response.Charset = "";
                this.EnableViewState = false;

                System.IO.StringWriter swriter = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlwriter = new System.Web.UI.HtmlTextWriter(swriter);

                //DataGrid dg = new DataGrid();
                //dg.DataSource = tk.populateGridSchedule();
                //dg.DataBind();


                dg.RenderControl(htmlwriter);


                Response.Write(swriter.ToString());
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " exported Leave Type List to Excel File",
                    "EXPORT", "x123", "qwg-23", "EXPORT", Session["EMP_ID"].ToString());
                Response.End();
                //exportTOxlsx();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(),
               "alert",
               "alert('No data to export!!!');",
               true);
            }
        }

        protected void ExportToPDF(object sender, EventArgs e)
        {

            //Create a dummy GridView
            DataTable dt = new DataTable();
            dt = admin.populateGridLeaveType();

            GridView GridView2 = new GridView();

            GridView2.AllowPaging = false;

            GridView2.DataSource = dt;

            GridView2.DataBind();


            if (GridView2.Rows.Count > 0)
            {
                Response.ContentType = "application/pdf";

                Response.AddHeader("content-disposition",

                    "attachment;filename=LeaveType.pdf");

                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                StringWriter sw = new StringWriter();

                HtmlTextWriter hw = new HtmlTextWriter(sw);

                GridView2.RenderControl(hw);

                StringReader sr = new StringReader(sw.ToString());

                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);

                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

                pdfDoc.Open();

                htmlparser.Parse(sr);

                pdfDoc.Close();

                Response.Write(pdfDoc);

                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " exported Leave Type List to PDF File",
                    "EXPORT", "x123", "qwg-23", "EXPORT", Session["EMP_ID"].ToString());

                Response.End();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(),
               "alert",
               "alert('No data to export!!!');",
               true);
            }
        }
    }
}