﻿using System;
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

namespace HRIS_APPELECTRIC.Pages.Admin.PayrollPages
{
    public partial class printpayslip : System.Web.UI.Page
    {
        Payroll pr = new Payroll();
        Payroll.Payslip ps = new Payroll.Payslip();
        Employee emp = new Employee();
        Timekeeping tk = new Timekeeping();
        Common cm = new Common();
        public string empno = "";
        string empviewURL = "";
        public int gridtotalcount = 0;
        public string gridrangecount = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCredDate.Items.AddRange(emp.GetDropDownMenuList("TBL_CUTOFF", "CDesc"));
                refresh();
                
            }
        }
        void refresh()
        {
            DataTable dt = new DataTable();
            dt = emp.populateGridDTSMaster();
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
            string _empno = ((TextBox)currentRow.FindControl("txtSearchempid")).Text;
            string _fname = ((TextBox)currentRow.FindControl("txtSearchFullName")).Text;
            string _company = ((TextBox)currentRow.FindControl("txtSearchCompany")).Text;
            string expr = emp.build_or_like_param(saveSearchParam(_empno, _fname, _company));

            //string expr = "and (C.SchoolName like '%" + _schoolcode + "%' or B.CourseName like '%" + _coursecode + "%' or A.IDate like '%" + _idate + "%' or A.Remarks like '%" + _remarks + "%')";
            //GridViewList.DataSource = emp.populateGridSearch((DataTable)ViewState["EMP_GRID"], expr);
            GridViewList.DataSource = emp.populateGridDTSMasterCol(expr);
            GridViewList.DataBind();



        }

        Dictionary<string, string> saveSearchParam(string _empno, string _fname, string _company)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();

            param.Add("emp_EmpID", "'%" + _empno + "%'");
            param.Add("emp_FullName", "'%" + _fname + "%'");
            param.Add("emp_Assignment", "'%" + _company + "%'");
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
            if (e.CommandName == "dwnld")
            {
                
                //if (pr.processpayroll(ddlCredDate.SelectedValue,isChecked) < 0)
                //{
                    
                    
                //    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Payroll Failed !!!');", true);
                    
                //}
                
                    //ps = pr.GetPayslip(ddlCredDate.SelectedValue, e.CommandArgument.ToString());
                ExportToPDF1();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Payroll Successful !!!');", true);
                
                    

            }
        }
        protected void btnProcess_Click(object sender, EventArgs e)
        {
            
        }
        protected void ExportToPDF()
        {

            //Create a dummy GridView
            //DataTable dt = new DataTable();
            //dt = admin.populateGridDivision();

            //GridView GridView2 = new GridView();

            //GridView2.AllowPaging = false;

            //GridView2.DataSource = dt;

            //GridView2.DataBind();


            //if (GridView2.Rows.Count > 0)
            //{
                Response.ContentType = "application/pdf";

                Response.AddHeader("content-disposition",

                    "attachment;filename=Payslip.pdf");

                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                StringWriter sw = new StringWriter();

            #region swwrite
            sw.Write("<table id=\"yw1\" style=\"width:100%;font-family:Arial;font-size:10px\"><tr><td colspan='6'><span>APP ELECTRIC CORP</span></td></tr>");
            sw.Write("<tr><td colspan='6'><span>" + ps.empno + "</span> <span>" + ps.empname + "</span></td></tr>");
            sw.Write("<tr><td colspan='6'></td><td colspan='2'></td><td colspan='2'></td><td colspan='2'>" +
                "<span>Date Covered: " + "02/13/2020 TO 02/19/2020" + "</span><br/>" +
                "<span>Payroll Group: " + "Watts App-Week" + "</span><br/>" +
                "<span>Department: " + "ADMIN" + "</span></td></tr></table><br/>");
            sw.Write("<table id=\"yw2\" style=\"width:100%;font-family:Arial;font-size:10px\"><tr><td colspan='2'></td><td colspan='2'><span>Amount</span></td>" +
                "<td colspan='2'></td><td colspan='2'></td>" +
                "<td colspan='2'></td><td colspan='2'></td>" +
                "<td colspan='2'>Loan Balance<span></span></td><td colspan='1'></td></tr>");
            sw.Write("<tr>" +
                "<td colspan='2'><span>Basic Pay</span><br/></td>" +
                "<td colspan='2'><span>" + "3,222.00" + "</span></td>" +
                "<td colspan='2'><span>SSS</span></td>" +
                "<td colspan='2'><span>" + "140.00" + "</span></td>" +
                "<td colspan='2'><span>CASH AD</span></td>" +
                "<td colspan='2'><span>" + "500.00" + "</span></td>" +
                "<td colspan='2'><span>" + "1,500.00" + "</span></td>" +
                "<td colspan='1'></td></tr>");
            sw.Write("<tr>" +
                "<td colspan='2'><span>Absences</span><br/></td>" +
                "<td colspan='2'><span>" + "(537.00)" + "</span></td>" +
                "<td colspan='2'><span>PhilHealth</span></td>" +
                "<td colspan='2'><span>" + "52.36" + "</span></td>" +
                "<td colspan='2'><span>Holiday Pay</span></td>" +
                "<td colspan='2'><span>" + "650" + "</span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='1'></td></tr>");
            sw.Write("<tr>" +
                "<td colspan='2'><span>Lates</span><br/></td>" +
                "<td colspan='2'><span>" + "(8.95)" + "</span></td>" +
                "<td colspan='2'><span>Pag-Ibig</span></td>" +
                "<td colspan='2'><span>" + "25.00" + "</span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='1'></td></tr>");
            sw.Write("<tr>" +
               "<td colspan='2'><span>Undertime</span><br/></td>" +
               "<td colspan='2'><span>" + "(8.95)" + "</span></td>" +
               "<td colspan='2'><span>Leave Pay</span></td>" +
               "<td colspan='2'><span>" + "(8.95)" + "</span></td>" +
               "<td colspan='2'><span></span></td>" +
               "<td colspan='2'><span></span></td>" +
               "<td colspan='2'><span></span></td>" +
               "<td colspan='2'></td></tr>");
            sw.Write("<tr>" +
                "<td colspan='2'><span>Overtime</span><br/></td>" +
                "<td colspan='2'><span>" + "(8.95)" + "</span></td>" +
                "<td colspan='2'><span>Remaining Leave Credit</span></td>" +
                "<td colspan='2'><span>" + "(8.95)" + "</span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='2'></td></tr>");
            sw.Write("<tr><td><br/></td></tr></table><br/>");
            sw.Write("<table style=\"width:100%;font-family:Arial;font-size:10px\"><tr>" +
                "<td colspan='2'></td>" +
                "<td colspan='3' style=\"text-align:center;\"><span>Total Gross Income</span></td>" +
                "<td colspan='3' style=\"text-align:right;vertical-align:bottom;\">" +
                "<span style=\"vertical-align:bottom;\">––––––––––––––––––</span><br/>" +
                "<span style=\"vertical-align:bottom;\">" + "200,676.05" + "</span><br/>" +
                "<span style=\"vertical-align:top;\">––––––––––––––––––</span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='3' style=\"text-align:right;padding-right:20px;\"><span>Total Deduction</span></td>" +
                "<td colspan='3'style=\"text-align:right;vertical-align:bottom;\">" +
                "<span style=\"vertical-align:bottom;\">––––––––––––––––––</span><br/>" +
                "<span style=\"vertical-align:bottom;\">" + "717.36" + "</span><br/>" +
                "<span style=\"vertical-align:top;\">––––––––––––––––––</span></td></tr>");
            sw.Write("<tr>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='3'><span></span></td>" +
                "<td colspan='5'><span></span></td>" +
                "<td colspan='3'><span></span></td>" +
                "<td colspan='3'><span></span></td></tr>" +
                "<tr><td><br/></td></tr>");
            sw.Write("<tr>" +
               "<td colspan='2'><span></span></td>" +
               "<td colspan='3'><span></span></td>" +
               "<td colspan='5'><span></span></td>" +
               "<td colspan='2' style=\"text-align:right;padding-right:70px;\"><span>Net Pay</span></td>" +
               "<td colspan='3' style=\"text-align:right;vertical-align:bottom;\">" +
               "<span style=\"vertical-align:bottom;\">––––––––––––––––––</span><br/>" +
               "<span style=\"vertical-align:bottom;font-size:14px;;font-weight:bold;\">" + "1,958.69" + "</span><br/>" +
               "<span style=\"vertical-align:top;\">––––––––––––––––––</span></td></tr></table><br/>");
            sw.Write("<table style=\"width:100%;font-family:Arial;font-size:10px\"><tr>" +
               "<td colspan='6'><span>I hereby ackowledge to have received the sum as full payment of my service rendered.</span></td>" +
               "<td colspan='6' style=\"text-align:right;\"><span>Signature _________________________</span></td>" +
               "</tr>" +
               "</table>");
            #endregion
            HtmlTextWriter hw = new HtmlTextWriter(sw);

                //GridView2.RenderControl(hw);

                StringReader sr = new StringReader(sw.ToString());

                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);

                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

                pdfDoc.Open();

                htmlparser.Parse(sr);

                pdfDoc.Close();

                Response.Write(pdfDoc);

                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " exported Payslip to PDF File",
                    "EXPORT", "x123", "qwg-23", "EXPORT", Session["EMP_ID"].ToString());

                Response.End();
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(),
            //   "alert",
            //   "alert('No data to export!!!');",
            //   true);
            //}
        }
         void ExportToPDF1()
        {

            //Create a dummy GridView
            //DataTable dt = new DataTable();
            //dt = admin.populateGridDivision();

            //GridView GridView2 = new GridView();

            //GridView2.AllowPaging = false;

            //GridView2.DataSource = dt;

            //GridView2.DataBind();


            //if (GridView2.Rows.Count > 0)
            //{
            Response.ContentType = "application/pdf";

            Response.AddHeader("content-disposition",

                "attachment;filename=Payslip.pdf");

            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            StringWriter sw = new StringWriter();

            #region swwrite
            sw.Write("<table id=\"yw1\" style=\"width:100%;font-family:Arial;font-size:10px\"><tr><td colspan='6'><span>APP ELECTRIC CORP</span></td></tr>");
            sw.Write("<tr><td colspan='6'><span>" + ps.empno + "</span> <span>" + ps.empname + "</span></td></tr>");
            sw.Write("<tr><td colspan='6'></td><td colspan='2'></td><td colspan='2'></td><td colspan='2'>" +
                "<span>Date Covered: " + ps.date_covered + "</span><br/>" +
                "<span>Payroll Group: " + ps.payrollgroup + "</span><br/>" +
                "<span>Department: " + ps.department + "</span></td></tr></table><br/>");
            sw.Write("<table id=\"yw2\" style=\"width:100%;font-family:Arial;font-size:10px\"><tr><td colspan='2'></td><td colspan='2'><span>Amount</span></td>" +
                "<td colspan='2'></td><td colspan='2'></td>" +
                "<td colspan='2'></td><td colspan='2'></td>" +
                "<td colspan='2'>Loan Balance<span></span></td><td colspan='1'></td></tr>");
            sw.Write("<tr>" +
                "<td colspan='2'><span>Basic Pay</span><br/></td>" +
                "<td colspan='2'><span>" + pr.toRoundOff(ps.basicpay) + "</span></td>" +
                "<td colspan='2'><span>SSS</span></td>" +
                "<td colspan='2'><span>" + pr.toRoundOff(ps.sss) + "</span></td>" +
                "<td colspan='2'><span>CASH AD</span></td>" +
                "<td colspan='2'><span>" + ps.cash_adv + "</span></td>" +
                "<td colspan='2'><span>" + ps.loanbal + "</span></td>" +
                "<td colspan='1'></td></tr>");
            sw.Write("<tr>" +
                "<td colspan='2'><span>Absences</span><br/></td>" +
                "<td colspan='2'><span>" + ps.absentded + "</span></td>" +
                "<td colspan='2'><span>PhilHealth</span></td>" +
                "<td colspan='2'><span>" + pr.toRoundOff(ps.philhealth) + "</span></td>" +
                "<td colspan='2'><span>Holiday Pay</span></td>" +
                "<td colspan='2'><span>" + pr.toRoundOff(ps.holidaypay) + "</span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='1'></td></tr>");
            sw.Write("<tr>" +
                "<td colspan='2'><span>Lates</span><br/></td>" +
                "<td colspan='2'><span>(" + ps.lates + ")</span></td>" +
                "<td colspan='2'><span>Pag-Ibig</span></td>" +
                "<td colspan='2'><span>" + pr.toRoundOff(ps.pagibig) + "</span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='1'></td></tr>");
            sw.Write("<tr>" +
             "<td colspan='2'><span>Undertime</span><br/></td>" +
             "<td colspan='2'><span>" + pr.toRoundOff(ps.utded) + "</span></td>" +
             "<td colspan='2'><span>Leave Pay</span></td>" +
             "<td colspan='2'><span>" + pr.toRoundOff(ps.leavepay) + "</span></td>" +
             "<td colspan='2'><span>" + cm.RemoveSpecialCharactersForFileName(ps.adjustmentremarks.Trim()) + "</span></td>" +
             "<td colspan='2'><span>" + pr.toRoundOff(ps.adjustment) + "</span></td>" +
             "<td colspan='2'><span></span></td>" +
             "<td colspan='2'></td></tr>");
            sw.Write("<tr>" +
                "<td colspan='2'><span>Overtime</span><br/></td>" +
                "<td colspan='2'><span>" + pr.toRoundOff(ps.otpay) + "</span></td>" +
                "<td colspan='2'><span>Remaining Leave Credit</span></td>" +
                "<td colspan='2'><span>" + ps.remainingleavecredit + "</span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='1'></td></tr>");
            sw.Write("<tr><td><br/></td></tr></table><br/>");
            sw.Write("<table style=\"width:100%;font-family:Arial;font-size:10px\"><tr>" +
                "<td colspan='2'></td>" +
                "<td colspan='3' style=\"text-align:center;\"><span>Total Gross Income</span></td>" +
                "<td colspan='3' style=\"text-align:right;vertical-align:bottom;\">" +
                "<span style=\"vertical-align:bottom;\">––––––––––––––––––</span><br/>" +
                "<span style=\"vertical-align:bottom;\">" + pr.toRoundOff(ps.totalgrossincome) + "</span><br/>" +
                "<span style=\"vertical-align:top;\">––––––––––––––––––</span></td>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='3' style=\"text-align:right;padding-right:20px;\"><span>Total Deduction</span></td>" +
                "<td colspan='3'style=\"text-align:right;vertical-align:bottom;\">" +
                "<span style=\"vertical-align:bottom;\">––––––––––––––––––</span><br/>" +
                "<span style=\"vertical-align:bottom;\">" + pr.toRoundOff(ps.totaldeduction) + "</span><br/>" +
                "<span style=\"vertical-align:top;\">––––––––––––––––––</span></td></tr>");
            sw.Write("<tr>" +
                "<td colspan='2'><span></span></td>" +
                "<td colspan='3'><span></span></td>" +
                "<td colspan='5'><span></span></td>" +
                "<td colspan='3'><span></span></td>" +
                "<td colspan='3'><span></span></td></tr>" +
                "<tr><td><br/></td></tr>");
            sw.Write("<tr>" +
               "<td colspan='2'><span></span></td>" +
               "<td colspan='3'><span></span></td>" +
               "<td colspan='5'><span></span></td>" +
               "<td colspan='2' style=\"text-align:right;padding-right:70px;\"><span>Net Pay</span></td>" +
               "<td colspan='3' style=\"text-align:right;vertical-align:bottom;\">" +
               "<span style=\"vertical-align:bottom;\">––––––––––––––––––</span><br/>" +
               "<span style=\"vertical-align:bottom;font-size:14px;;font-weight:bold;\">" + pr.toRoundOff(ps.netpay) + "</span><br/>" +
               "<span style=\"vertical-align:top;\">––––––––––––––––––</span></td></tr></table><br/>");
            sw.Write("<table style=\"width:100%;font-family:Arial;font-size:10px\"><tr>" +
               "<td colspan='6'><span>I hereby ackowledge to have received the sum as full payment of my service rendered.</span></td>" +
               "<td colspan='6' style=\"text-align:right;\"><span>Signature _________________________</span></td>" +
               "</tr>" +
               "</table>");
            #endregion
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //GridView2.RenderControl(hw);

            StringReader sr = new StringReader(sw.ToString());

            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);

            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

            pdfDoc.Open();

            htmlparser.Parse(sr);

            pdfDoc.Close();

            Response.Write(pdfDoc);

            cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " exported Payslip to PDF File",
                "EXPORT", "x123", "qwg-23", "EXPORT", Session["EMP_ID"].ToString());

            Response.End();
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(),
            //   "alert",
            //   "alert('No data to export!!!');",
            //   true);
            //}
        }
    }
}