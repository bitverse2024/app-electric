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

namespace HRIS_APPELECTRIC.Pages.Admin.TK
{
    public partial class cutoff : System.Web.UI.Page
    {
        Timekeeping tk = new Timekeeping();
        Common cm = new Common();
        Employee emp = new Employee();
        public string empno = "";
        public int gridtotalcount = 0;
        public string gridrangecount = "";
        string getcod, getcof, getcot, getdesc;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateMenus();
                refresh();
                
            }
        }
        void refresh()
        {
            DataTable dt = new DataTable();
            dt = tk.populateGridCutOff();
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
            string s_codate = ((TextBox)currentRow.FindControl("txtSearchCODate")).Text;
            string s_cofrom = ((TextBox)currentRow.FindControl("txtSearchCOFrom")).Text;
            string s_coto = ((TextBox)currentRow.FindControl("txtSearchCOTo")).Text;
            string s_codesc = ((TextBox)currentRow.FindControl("txtSearchCDesc")).Text;
            


            string expr = emp.build_or_like_param(true, saveSearchParam(s_codate, s_cofrom, s_coto, s_codesc));
            //string expr = "and (license_type like '%" + lictype + "%' or license_no like '%" + licno + "%' or lic_expirydate like '%" + licdate + "%')";
            //GridViewList.DataSource = emp.populateGridSearch((DataTable)ViewState["EMP_GRID"], expr);
            GridViewList.DataSource = tk.populateGridCutOffCol(expr);
            GridViewList.DataBind();



        }
        Dictionary<string, string> saveSearchParam(string s_codate, string s_cofrom, string s_coto, string s_codesc)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            if(s_codate != "")
                param.Add("CODate", "'%" + Convert.ToDateTime(s_codate).ToString("yyyy-MM-dd") + "%'");
            if(s_cofrom != "")
                param.Add("COFrom", "'%" + Convert.ToDateTime(s_cofrom).ToString("yyyy-MM-dd") + "%'");
            if(s_coto != "")
                param.Add("COTo", "'%" + Convert.ToDateTime(s_coto).ToString("yyyy-MM-dd") + "%'");
            param.Add("CDesc", "'%" + s_codesc + "%'");

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
                getdesc = cm.GetSpecificDataFromDB("CDesc", "TBL_CUTOFF", "where id = " + e.CommandArgument.ToString() + "");
                emp.DeleteQuery("TBL_CUTOFF", "where id =" + e.CommandArgument.ToString() + "");
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " removed CUT OFF " + getdesc,
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
        void populateMenus()
        {
            upd_PayrollGroup.Items.AddRange(emp.GetDropDownMenuList("TBL_PAYROLLGRP", "payrollgrpname"));
        }
        public void populateUpdateField(string id)
        {
            string cod = cm.GetSpecificDataFromDB("CODate", "TBL_CUTOFF", "where id = " + id + "");
            string cof = cm.GetSpecificDataFromDB("COFrom", "TBL_CUTOFF", "where id = " + id + "");
            string cot = cm.GetSpecificDataFromDB("COTo", "TBL_CUTOFF", "where id = " + id + "");
            upd_CODate.Value = cm.FormatDate(cod);
            upd_COFrom.Value = cm.FormatDate(cof);
            upd_COTo.Value = cm.FormatDate(cot);
            upd_CODesc.Value = cm.GetSpecificDataFromDB("CDesc", "TBL_CUTOFF", "where id = " + id + "");
            upd_PayrollGroup.Value = cm.GetSpecificDataFromDB("PayrollGroup", "TBL_CUTOFF", "where id = " + id + "");
            //monthlydt.Value = cm.GetSpecificDataFromDB("CreditMonth", "TBL_CUTOFF", "where id = " + id + "");
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
            Dictionary<string, string> getDict = new Dictionary<string, string>();
            getDict = cm.GetTableDict("TBL_CUTOFF", "where id = " + id + "");
            vw_ID.Value = getDict["id"]; 
            vw_CODate.Value = getDict["CODate"]; 
            vw_COFrom.Value = getDict["COFrom"]; 
            vw_COTo.Value = getDict["COTo"]; 
            vw_CODesc.Value = getDict["CDesc"]; 
            vw_creditMonth.Value = getDict["creditMonth"];
            vw_creditYear.Value = getDict["creditYear"];
        }

        private void getdata()
        {
            getcod = cm.FormatDate(cm.GetSpecificDataFromDB("CODate", "TBL_CUTOFF", "where id = " + HiddenEmpID.Value + ""));
            getcof = cm.FormatDate(cm.GetSpecificDataFromDB("COFrom", "TBL_CUTOFF", "where id = " + HiddenEmpID.Value + ""));
            getcot = cm.FormatDate(cm.GetSpecificDataFromDB("COTo", "TBL_CUTOFF", "where id = " + HiddenEmpID.Value + ""));
            getdesc = cm.GetSpecificDataFromDB("CDesc", "TBL_CUTOFF", "where id = " + HiddenEmpID.Value + "");
        }

        private void addlogs()
        {
            if (getcod != cm.FormatDate(upd_CODate.Value))
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Cut Off CREDIT DATE for " + getdesc + " from " + getcod + " to " + upd_CODate.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getcof != cm.FormatDate(upd_COFrom.Value))
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Cut Off DATE FROM for " + getdesc + " from " + getcof + " to " + upd_COFrom.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getcot != cm.FormatDate(upd_COTo.Value))
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Cut Off DATE TO for " + getdesc + " from " + getcot + " to " + upd_COTo.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getdesc != upd_CODesc.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Cut Off DESCRIPTION for " + getdesc + " from " + getdesc + " to " + upd_CODesc.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
        }

        protected void btnsaveUpdate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                getdata();
                if (cm.UpdateQueryCommon(saveUpdateParam(), "TBL_CUTOFF", "id = " + HiddenEmpID.Value + ""))
                {
                    addlogs();
                    refresh();
                    //db_Emp.updateUserInfo(HiddenEmpID.Value, txtbox_username.Text, txtbox_password.Text, (drpdwn_acctstatus.SelectedValue == "1" ? true : false));
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully updated !!!');", true);
                    closeTransDetails();
                    refresh();
                }
            }
        }
        Dictionary<string, string> saveUpdateParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("CODate", "'" + upd_CODate.Value + "'");
            param.Add("COFrom", "'" + upd_COFrom.Value + "'");
            param.Add("COTo", "'" + upd_COTo.Value + "'");
            param.Add("CDesc", "'" + upd_CODesc.Value + "'");
            param.Add("PayrollGroup", "" + upd_PayrollGroup.Value + "");

            return param;
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataGrid dg = new DataGrid();
            dg.DataSource = tk.populateGridCutOff();
            dg.DataBind();
            if (dg.Items.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("content-disposition", "attachment;filename= CutOff" + ".xls");
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
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " exported Cut OFf List to Excel File",
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
            dt = tk.populateGridCutOff();

            GridView GridView2 = new GridView();

            GridView2.AllowPaging = false;

            GridView2.DataSource = dt;

            GridView2.DataBind();


            if (GridView2.Rows.Count > 0)
            {
                Response.ContentType = "application/pdf";

                Response.AddHeader("content-disposition",

                    "attachment;filename=CutOff.pdf");

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

                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " exported Cutt Off List to PDF File",
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