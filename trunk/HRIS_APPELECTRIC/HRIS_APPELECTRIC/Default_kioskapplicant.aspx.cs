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

namespace HRIS_APPELECTRIC
{
    public partial class Default_kioskapplicant : System.Web.UI.Page
    {
        Employee emp = new Employee();
        HR _hr = new HR();
        AdminLib admin = new AdminLib();

        public int gridtotalcount, gridtotalcount2, gridtotalcount3, gridtotalcount4;
        public string gridrangecount, gridrangecount2, gridrangecount3, gridrangecount4;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["EMP_ID"] != null)
                {
                    if (Session["ROLES"].ToString() == "admin" || Session["ROLES"].ToString() == "employee")
                        //lblUsername.Text = Session["EMP_ID"].ToString();
                        //btnLogout.Visible = true;
                        //btnLogin.Visible = false;
                        refresh();
                    refresh2();
                    refresh3();
                    refresh4();
                }
                else
                {
                    //string strEncode = Server.UrlEncode(HttpContext.Current.Request.Url.AbsoluteUri);
                    //string strEncode = HttpContext.Current.Request.Url.AbsoluteUri;
                    //Response.Redirect(string.Format("{0}?redirect={1}",
                    //    ConfigurationManager.AppSettings["loginPage"], strEncode));
                    Response.Redirect("~/Pages/Login.aspx");

                }
            }
        }

        void refresh()
        {
            DataTable dt = new DataTable();
            dt = _hr.populateGridApplicant();
            GridViewList.DataSource = dt;
            GridViewList.DataBind();
            ViewState["EMP_GRID"] = dt;
            ViewState["SORTDR"] = null;
            summary();
        }
        void refresh2()
        {
            DataTable dt = new DataTable();
            dt = _hr.populateGridApplicant(2);
            GridViewList2.DataSource = dt;
            GridViewList2.DataBind();
            ViewState["EMP_GRID2"] = dt;
            ViewState["SORTDR2"] = null;
            summary2();
        }
        void refresh3()
        {
            DataTable dt = new DataTable();
            dt = _hr.populateGridApplicant(3);
            GridViewList3.DataSource = dt;
            GridViewList3.DataBind();
            ViewState["EMP_GRID3"] = dt;
            ViewState["SORTDR3"] = null;
            summary3();
        }
        void refresh4()
        {
            DataTable dt = new DataTable();
            dt = _hr.populateGridApplicant(4);
            GridViewList4.DataSource = dt;
            GridViewList4.DataBind();
            ViewState["EMP_GRID4"] = dt;
            ViewState["SORTDR4"] = null;
            summary4();
        }
        void summary()
        {
            gridtotalcount = ((DataTable)ViewState["EMP_GRID"]).Rows.Count;
            int pageIndex = GridViewList.PageIndex;
            int c = (pageIndex > 0 ? 10 * pageIndex : 0) + GridViewList.Rows.Count;
            gridrangecount = (c > 0 ? c : 0) + " - " + gridtotalcount;
        }
        void summary2()
        {
            gridtotalcount2 = ((DataTable)ViewState["EMP_GRID2"]).Rows.Count;
            int pageIndex = GridViewList2.PageIndex;
            int c = (pageIndex > 0 ? 10 * pageIndex : 0) + GridViewList2.Rows.Count;
            gridrangecount2 = (c > 0 ? c : 0) + " - " + gridtotalcount2;
        }
        void summary3()
        {
            gridtotalcount3 = ((DataTable)ViewState["EMP_GRID3"]).Rows.Count;
            int pageIndex = GridViewList3.PageIndex;
            int c = (pageIndex > 0 ? 10 * pageIndex : 0) + GridViewList3.Rows.Count;
            gridrangecount3 = (c > 0 ? c : 0) + " - " + gridtotalcount3;
        }
        void summary4()
        {
            gridtotalcount4 = ((DataTable)ViewState["EMP_GRID4"]).Rows.Count;
            int pageIndex = GridViewList4.PageIndex;
            int c = (pageIndex > 0 ? 10 * pageIndex : 0) + GridViewList4.Rows.Count;
            gridrangecount4 = (c > 0 ? c : 0) + " - " + gridtotalcount4;
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
        protected void sort_grid2(string sort_args)
        {
            DataTable dt = (DataTable)ViewState["EMP_GRID2"];
            if (dt.Rows.Count > 0)
            {
                if (Convert.ToString(ViewState["SORTDR2"]) == "Asc")
                {
                    dt.DefaultView.Sort = sort_args + " Desc";
                    ViewState["SORTDR2"] = "Desc";
                }
                else
                {
                    dt.DefaultView.Sort = sort_args + " Asc";
                    ViewState["SORTDR2"] = "Asc";
                }

                GridViewList2.DataSource = dt;
                GridViewList2.DataBind();
                summary2();

            }

        }
        protected void sort_grid3(string sort_args)
        {
            DataTable dt = (DataTable)ViewState["EMP_GRID3"];
            if (dt.Rows.Count > 0)
            {
                if (Convert.ToString(ViewState["SORTDR3"]) == "Asc")
                {
                    dt.DefaultView.Sort = sort_args + " Desc";
                    ViewState["SORTDR3"] = "Desc";
                }
                else
                {
                    dt.DefaultView.Sort = sort_args + " Asc";
                    ViewState["SORTDR3"] = "Asc";
                }

                GridViewList3.DataSource = dt;
                GridViewList3.DataBind();
                summary3();

            }

        }
        protected void sort_grid4(string sort_args)
        {
            DataTable dt = (DataTable)ViewState["EMP_GRID4"];
            if (dt.Rows.Count > 0)
            {
                if (Convert.ToString(ViewState["SORTDR4"]) == "Asc")
                {
                    dt.DefaultView.Sort = sort_args + " Desc";
                    ViewState["SORTDR4"] = "Desc";
                }
                else
                {
                    dt.DefaultView.Sort = sort_args + " Asc";
                    ViewState["SORTDR4"] = "Asc";
                }

                GridViewList4.DataSource = dt;
                GridViewList4.DataBind();
                summary4();

            }

        }
        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            //awong-retrieve textbox values from the grid control during runtime.
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
            string txtSearchFullName = ((TextBox)currentRow.FindControl("txtSearchFullName")).Text;
            string txtSearchPositionDesired = ((TextBox)currentRow.FindControl("txtSearchPositionDesired")).Text;
            string txtSearchDateApplied = ((TextBox)currentRow.FindControl("txtSearchDateApplied")).Text;
            string txtSearchAddress = ((TextBox)currentRow.FindControl("txtSearchAddress")).Text;

            string expr = _hr.build_or_like_param(true, saveSearchParam(txtSearchFullName, txtSearchPositionDesired, txtSearchDateApplied, txtSearchAddress));
            //string expr = "and (license_type like '%" + lictype + "%' or license_no like '%" + licno + "%' or lic_expirydate like '%" + licdate + "%')";
            //GridViewList.DataSource = emp.populateGridSearch((DataTable)ViewState["EMP_GRID"], expr);
            GridViewList.DataSource = _hr.populateGridApplicantCol(expr);
            GridViewList.DataBind();



        }
        protected void txtItem2_TextChanged(object sender, EventArgs e)
        {
            //awong-retrieve textbox values from the grid control during runtime.
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
            string txtSearchFullName = ((TextBox)currentRow.FindControl("txtSearchFullName2")).Text;
            string txtSearchPositionDesired = ((TextBox)currentRow.FindControl("txtSearchPositionDesired2")).Text;
            string txtSearchDateApplied = ((TextBox)currentRow.FindControl("txtSearchDateApplied2")).Text;
            string txtSearchAddress = ((TextBox)currentRow.FindControl("txtSearchAddress2")).Text;

            string expr = _hr.build_or_like_param(true, saveSearchParam(txtSearchFullName, txtSearchPositionDesired, txtSearchDateApplied, txtSearchAddress));
            //string expr = "and (license_type like '%" + lictype + "%' or license_no like '%" + licno + "%' or lic_expirydate like '%" + licdate + "%')";
            //GridViewList.DataSource = emp.populateGridSearch((DataTable)ViewState["EMP_GRID"], expr);
            GridViewList2.DataSource = _hr.populateGridApplicantCol(expr, 2);
            GridViewList2.DataBind();



        }
        protected void txtItem3_TextChanged(object sender, EventArgs e)
        {
            //awong-retrieve textbox values from the grid control during runtime.
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
            string txtSearchFullName = ((TextBox)currentRow.FindControl("txtSearchFullName3")).Text;
            string txtSearchPositionDesired = ((TextBox)currentRow.FindControl("txtSearchPositionDesired3")).Text;
            string txtSearchDateApplied = ((TextBox)currentRow.FindControl("txtSearchDateApplied3")).Text;
            string txtSearchAddress = ((TextBox)currentRow.FindControl("txtSearchAddress3")).Text;

            string expr = _hr.build_or_like_param(true, saveSearchParam(txtSearchFullName, txtSearchPositionDesired, txtSearchDateApplied, txtSearchAddress));
            //string expr = "and (license_type like '%" + lictype + "%' or license_no like '%" + licno + "%' or lic_expirydate like '%" + licdate + "%')";
            //GridViewList.DataSource = emp.populateGridSearch((DataTable)ViewState["EMP_GRID"], expr);
            GridViewList3.DataSource = _hr.populateGridApplicantCol(expr, 3);
            GridViewList3.DataBind();



        }
        protected void txtItem4_TextChanged(object sender, EventArgs e)
        {
            //awong-retrieve textbox values from the grid control during runtime.
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
            string txtSearchFullName = ((TextBox)currentRow.FindControl("txtSearchFullName4")).Text;
            string txtSearchPositionDesired = ((TextBox)currentRow.FindControl("txtSearchPositionDesired4")).Text;
            string txtSearchDateApplied = ((TextBox)currentRow.FindControl("txtSearchDateApplied4")).Text;
            string txtSearchAddress = ((TextBox)currentRow.FindControl("txtSearchAddress4")).Text;

            string expr = _hr.build_or_like_param(true, saveSearchParam(txtSearchFullName, txtSearchPositionDesired, txtSearchDateApplied, txtSearchAddress));
            //string expr = "and (license_type like '%" + lictype + "%' or license_no like '%" + licno + "%' or lic_expirydate like '%" + licdate + "%')";
            //GridViewList.DataSource = emp.populateGridSearch((DataTable)ViewState["EMP_GRID"], expr);
            GridViewList4.DataSource = _hr.populateGridApplicantCol(expr, 4);
            GridViewList4.DataBind();



        }
        Dictionary<string, string> saveSearchParam(string txtSearchFullName, string txtSearchPositionDesired, string txtSearchDateApplied, string txtSearchAddress)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("FullName", "'%" + txtSearchFullName + "%'");
            param.Add("PositionDesired", "'%" + txtSearchPositionDesired + "%'");
            param.Add("DateReceived", "'%" + txtSearchDateApplied + "%'");
            param.Add("Address1", "'%" + txtSearchAddress + "%'");

            return param;
        }

        protected void GridViewList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewList.PageIndex = e.NewPageIndex;
            refresh();
        }
        protected void GridViewList2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewList2.PageIndex = e.NewPageIndex;
            refresh2();
        }
        protected void GridViewList3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewList3.PageIndex = e.NewPageIndex;
            refresh3();
        }
        protected void GridViewList4_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewList4.PageIndex = e.NewPageIndex;
            refresh4();
        }
        protected void GridViewList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sort")
            {
                sort_grid(e.CommandArgument.ToString());

            }
            if (e.CommandName == "vew")
            {
                Response.Redirect("~/Pages/HRRecruitment/applicantprofileview.aspx?id=" + e.CommandArgument.ToString());

            }
            if (e.CommandName == "del")
            {
                emp.DeleteQuery("TBL_APPLICANT", "where id =" + e.CommandArgument.ToString() + "");
                refresh();
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Successfully Deleted');",
                true);

            }
        }
        protected void GridViewList2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sort")
            {
                sort_grid(e.CommandArgument.ToString());

            }
            if (e.CommandName == "vew")
            {
                Response.Redirect("~/Pages/HRRecruitment/applicantprofileview.aspx?id=" + e.CommandArgument.ToString());

            }
            if (e.CommandName == "del")
            {
                emp.DeleteQuery("TBL_APPLICANT", "where id =" + e.CommandArgument.ToString() + "");
                refresh();
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Successfully Deleted');",
                true);

            }
        }
        protected void GridViewList3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sort")
            {
                sort_grid(e.CommandArgument.ToString());

            }
            if (e.CommandName == "vew")
            {
                Response.Redirect("~/Pages/HRRecruitment/applicantprofileview.aspx?id=" + e.CommandArgument.ToString());

            }
            if (e.CommandName == "del")
            {
                emp.DeleteQuery("TBL_APPLICANT", "where id =" + e.CommandArgument.ToString() + "");
                refresh();
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Successfully Deleted');",
                true);

            }
        }
        protected void GridViewList4_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sort")
            {
                sort_grid(e.CommandArgument.ToString());

            }
            if (e.CommandName == "vew")
            {
                Response.Redirect("~/Pages/HRRecruitment/applicantprofileview.aspx?id=" + e.CommandArgument.ToString());

            }
            if (e.CommandName == "del")
            {
                emp.DeleteQuery("TBL_APPLICANT", "where id =" + e.CommandArgument.ToString() + "");
                refresh();
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Successfully Deleted');",
                true);

            }
        }


        public string GetJobOpenings()
        {
            string ret = "";
            ret = _hr.GetJobOpenings(Session["EMP_ID"].ToString());





            return ret;
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("content-disposition", "attachment;filename= ApplicantMasterList" + ".xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Charset = "";
            this.EnableViewState = false;

            System.IO.StringWriter swriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlwriter = new System.Web.UI.HtmlTextWriter(swriter);

            DataGrid dg = new DataGrid();
            dg.DataSource = _hr.populateGridAllApplicant();
            dg.DataBind();

            dg.RenderControl(htmlwriter);


            Response.Write(swriter.ToString());
            Response.End();
            //exportTOxlsx();

        }

        protected void ExportToPDF(object sender, EventArgs e)
        {

            //Create a dummy GridView
            DataTable dt = new DataTable();
            dt = _hr.populateGridApplicant();

            GridView GridView2 = new GridView();

            GridView2.AllowPaging = false;

            GridView2.DataSource = dt;

            GridView2.DataBind();



            Response.ContentType = "application/pdf";

            Response.AddHeader("content-disposition",

                "attachment;filename=ApplicantList.pdf");

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

            Response.End();

        }
    }
}