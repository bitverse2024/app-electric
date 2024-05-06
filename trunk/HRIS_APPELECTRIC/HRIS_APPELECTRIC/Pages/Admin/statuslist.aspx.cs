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
    public partial class statuslist : System.Web.UI.Page
    {
        Common cm = new Common();
        Timekeeping tk = new Timekeeping();
        Employee emp = new Employee();
        AdminLib admin = new AdminLib();
        public string empno = "";
        public int gridtotalcount = 0;
        public string gridrangecount = "";
        string getstat, getstatdesc, getsssref, getdpm, getdpy, getmpy, getvarref;
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
            dt = admin.populateGridStatus();
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
            string txtSearchStatusDesc = ((TextBox)currentRow.FindControl("txtSearchStatusDesc")).Text;
            string txtSearchSSSRef = ((TextBox)currentRow.FindControl("txtSearchSSSRef")).Text;
            string txtSearchDaysPerMonth = ((TextBox)currentRow.FindControl("txtSearchDaysPerMonth")).Text;
            string txtSearchDaysPerYear = ((TextBox)currentRow.FindControl("txtSearchDaysPerYear")).Text;

            string expr = emp.build_or_like_param(true, saveSearchParam(txtSearchStatusDesc, txtSearchSSSRef, txtSearchDaysPerMonth, txtSearchDaysPerYear));
            //string expr = "and (license_type like '%" + lictype + "%' or license_no like '%" + licno + "%' or lic_expirydate like '%" + licdate + "%')";
            //GridViewList.DataSource = emp.populateGridSearch((DataTable)ViewState["EMP_GRID"], expr);
            GridViewList.DataSource = admin.populateGridStatusCol(expr);
            GridViewList.DataBind();



        }
        Dictionary<string, string> saveSearchParam(string txtSearchStatusDesc, string txtSearchSSSRef, string txtSearchDaysPerMonth, string txtSearchDaysPerYear)
        {

            double testval = 0;
            Dictionary<string, string> param = new Dictionary<string, string>();

            param.Add("StatusDesc", "'%" + txtSearchStatusDesc + "%'");
            param.Add("SSSRef", "'%" + txtSearchSSSRef + "%'");
            if (double.TryParse(txtSearchDaysPerMonth, out testval)) param.Add("DaysPerMonth", "" + txtSearchDaysPerMonth + "");
            if (double.TryParse(txtSearchDaysPerYear, out testval)) param.Add("DaysPerYear", "" + txtSearchDaysPerYear + "");


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
                getstatdesc = cm.GetSpecificDataFromDB("StatusDesc", "TBL_STATUS", "where id = " + e.CommandArgument.ToString() + "");
                emp.DeleteQuery("TBL_STATUS", "where id =" + e.CommandArgument.ToString() + "");
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " removed STATUS " + getstatdesc,
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
            upd_EmpStatus.Value = cm.GetSpecificDataFromDB("EmpStatus", "TBL_STATUS", "where id = " + id + "");
            upd_StatusDesc.Value = cm.GetSpecificDataFromDB("StatusDesc", "TBL_STATUS", "where id = " + id + "");
            upd_SSSRef.Value = cm.GetSpecificDataFromDB("SSSRef", "TBL_STATUS", "where id = " + id + "");
            upd_DaysPerMonth.Value = cm.GetSpecificDataFromDB("DaysPerMonth", "TBL_STATUS", "where id = " + id + "");
            upd_DaysPerYear.Value = cm.GetSpecificDataFromDB("DaysPerYear", "TBL_STATUS", "where id = " + id + "");
            upd_MonthPerYear.Value = cm.GetSpecificDataFromDB("MonthPerYear", "TBL_STATUS", "where id = " + id + "");
            upd_VarRef.Value = cm.GetSpecificDataFromDB("VarRef", "TBL_STATUS", "where id = " + id + "");
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
            vw_ID.Value = cm.GetSpecificDataFromDB("id", "TBL_STATUS", "where id = " + id + "");
            vw_EmpStatus.Value = upd_EmpStatus.Value;
            vw_StatusDesc.Value = upd_StatusDesc.Value;
            vw_SSSRef.Value = upd_SSSRef.Value;
            vw_DaysPerMonth.Value = upd_DaysPerMonth.Value;
            vw_DaysPerYear.Value = upd_DaysPerYear.Value;
            vw_MonthPerYear.Value = upd_MonthPerYear.Value;
            vw_VarRef.Value = upd_VarRef.Value;
        }

        Dictionary<string, string> saveUpdateParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("EmpStatus", "'" + upd_EmpStatus.Value + "'");
            param.Add("StatusDesc", "'" + upd_StatusDesc.Value + "'");
            param.Add("SSSRef", "'" + upd_SSSRef.Value + "'");
            param.Add("DaysPerMonth", "" + upd_DaysPerMonth.Value + "");
            param.Add("DaysPerYear", "" + upd_DaysPerYear.Value + "");
            param.Add("MonthPerYear", "" + upd_MonthPerYear.Value + "");
            param.Add("VarRef", "'" + upd_VarRef.Value + "'");

            return param;
        }

        private void getdata()
        {
            getstat = cm.GetSpecificDataFromDB("EmpStatus", "TBL_STATUS", "where id = " + HiddenEmpID.Value + "");
            getstatdesc = cm.GetSpecificDataFromDB("StatusDesc", "TBL_STATUS", "where id = " + HiddenEmpID.Value + "");
            getsssref = cm.GetSpecificDataFromDB("SSSRef", "TBL_STATUS", "where id = " + HiddenEmpID.Value + "");
            getdpm = cm.GetSpecificDataFromDB("DaysPerMonth", "TBL_STATUS", "where id = " + HiddenEmpID.Value + "");
            getdpy = cm.GetSpecificDataFromDB("DaysPerYear", "TBL_STATUS", "where id = " + HiddenEmpID.Value + "");
            getmpy = cm.GetSpecificDataFromDB("MonthPerYear", "TBL_STATUS", "where id = " + HiddenEmpID.Value + "");
            getvarref = cm.GetSpecificDataFromDB("VarRef", "TBL_STATUS", "where id = " + HiddenEmpID.Value + "");
        }

        private void addlogs()
        {
            if (getstat != upd_EmpStatus.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Status EMPLOYEE STATUS for " + getstatdesc + " from " + getstat + " to " + upd_EmpStatus.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getstatdesc != upd_StatusDesc.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Status DESCRIPTION for " + getstatdesc + " from " + getstatdesc + " to " + upd_StatusDesc.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getsssref != upd_SSSRef.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Status SSSREF for " + getstatdesc + " from " + getsssref + " to " + upd_SSSRef.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getdpm != upd_DaysPerMonth.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Status DAYS PER MONTH for " + getstatdesc + " from " + getdpm + " to " + upd_DaysPerMonth.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getdpy != upd_DaysPerYear.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Status DAYS PER YEAR for " + getstatdesc + " from " + getdpy + " to " + upd_DaysPerYear.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getmpy != upd_MonthPerYear.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Status EMPLOYEE STATUS for " + getstatdesc + " from " + getmpy + " to " + upd_MonthPerYear.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getvarref != upd_VarRef.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Status EMPLOYEE STATUS for " + getstatdesc + " from " + getstat + " to " + upd_EmpStatus.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
        }

        protected void btnsaveUpdate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                getdata();
                if (cm.UpdateQueryCommon(saveUpdateParam(), "TBL_STATUS", "id = " + HiddenEmpID.Value + ""))
                {
                    addlogs();
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
            dg.DataSource = admin.populateGridStatus();
            dg.DataBind();
            if (dg.Items.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("content-disposition", "attachment;filename= StatusList" + ".xls");
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
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " exported Status List to Excel File",
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
            dt = admin.populateGridStatus();

            GridView GridView2 = new GridView();

            GridView2.AllowPaging = false;

            GridView2.DataSource = dt;

            GridView2.DataBind();


            if (GridView2.Rows.Count > 0)
            {
                Response.ContentType = "application/pdf";

                Response.AddHeader("content-disposition",

                    "attachment;filename=StatusList.pdf");

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

                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " exported Status List to PDF File",
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