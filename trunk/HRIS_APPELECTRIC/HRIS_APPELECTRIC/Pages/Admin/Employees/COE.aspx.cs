﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
//using System.Drawing;

namespace HRIS_APPELECTRIC.Pages.Admin.Employees
{
    public partial class COE : System.Web.UI.Page
    {
        Employee db_Emp = new Employee();
        Common cm = new Common();
        public string id, type, empno;        
        protected void Page_Load(object sender, EventArgs e)
        {
            refresh();
        }
        void refresh()
        {
            //w
            //GridUserList.DataSource = db.populateGridUserList();
            //GridUserList.DataBind();
            DataTable dt = new DataTable();
            dt = db_Emp.populateGridCOE();
            GridUserList.DataSource = dt;
            GridUserList.DataBind();
            ViewState["EMP_GRID"] = dt;
            ViewState["SORTDR"] = null;

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

                GridUserList.DataSource = dt;
                GridUserList.DataBind();


            }

        }

        protected void GridUserList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "WCompensation")
            {
                id = e.CommandArgument.ToString();
                HiddenEmpID.Value = e.CommandArgument.ToString();
                type = "With Compensation";
                hdnType.Value = type;
                openTransDetails(id);
                
                
            }
            if (e.CommandName == "WOCompensation")
            {
                id = e.CommandArgument.ToString();
                string empfname = cm.GetSpecificDataFromDB("emp_FullName", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = " + id + "");
                ExportToPDFwoComp(id);
                type = "Without Compensation";
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " generated " + type + "COE for " + empfname,
                                "EXPORT", "x123", "qwg-23", "EXPORT", Session["EMP_ID"].ToString());
            }
            if (e.CommandName == "Separated")
            {
                id = e.CommandArgument.ToString();
                HiddenEmpID.Value = e.CommandArgument.ToString();
                type = "Separated";
                hdnType.Value = type;
                openTransDetailsSep(id);                
            }
            if (e.CommandName == "Others")
            {
               
            }
        }
        protected void GridUserList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridUserList.PageIndex = e.NewPageIndex;
            refresh();
        }
        protected void txtItem_TextChanged(object sender, EventArgs e)
        {

            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
            string a1 = ((TextBox)currentRow.FindControl("txtSearchFullName")).Text;
            string a2 = ((TextBox)currentRow.FindControl("txtSearchCompany")).Text;

            string expr = db_Emp.build_or_like_param(saveSearchParam(a1, a2));
            GridUserList.DataSource = db_Emp.populateGridCOECol(expr);
            GridUserList.DataBind();

        }
        Dictionary<string, string> saveSearchParam(string a1, string a2)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("emp_FullName", "'%" + a1 + "%'");
            param.Add("emp_Assignment", "'%" + a2 + "%'");
            return param;


        }

        #region export

        protected void ExportToPDFwComp(string id)
        {
            #region declarations
            string imagepath = Server.MapPath("../../../images"),
                empfname = cm.GetSpecificDataFromDB("emp_FirstName", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + id + "'"),
                empsname = cm.GetSpecificDataFromDB("emp_Surname", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + id + "'"),
                empmname = cm.GetSpecificDataFromDB("LEFT(emp_MidName, 1)", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + id + "'"),
                empgen = cm.GetSpecificDataFromDB("emp_Gender", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + id + "'"),
                datestart = cm.GetSpecificDataFromDB("emp_DateStart", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + id + "'"),
                emp_company = cm.GetSpecificDataFromDB("emp_Assignment", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + id + "'"),
                emp_stat = cm.GetSpecificDataFromDB("emp_Status", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + id + "'"),
                emp_pos = cm.GetSpecificDataFromDB("emp_Position", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + id + "'"),
                coname = cm.GetSpecificDataFromDB("CoName", "TBL_COMPANY", "where id = '" + emp_company + "'"),
                stat = cm.GetSpecificDataFromDB("StatusDesc", "TBL_STATUS", "where id = '" + emp_stat + "'"),
                pos = cm.GetSpecificDataFromDB("PositionName", "TBL_POSITION", "where id = '" + emp_pos + "'"),
                salary = String.Format("{0:n0}", Convert.ToDouble(cm.GetSpecificDataFromDB("emp_BasicPay", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + id + "'"))),
                gen = "", gen1 = "", gen2="", gen3="", filename="";
            if (empgen.ToString() == "F")
            {
                gen = "her";
                gen1 = "Ms.";
                gen2 = "her";
                gen3 = "Her";
            }
            if (empgen.ToString() == "M")
            {
                gen = "him";
                gen1 = "Mr.";
                gen2 = "his";
                gen3 = "His";
            }
            if(emp_company == "1")
            {
                filename = "9757-app_header.jpg";
            }
            else if (emp_company == "2")
            {
                filename = "m2b.png";
            }
            else if (emp_company == "3")
            {
                filename = "wais.png";
            }
            #endregion

            DateTime sdate = Convert.ToDateTime(datestart);

            Response.ContentType = "application/pdf";

            Response.AddHeader("content-disposition",

                "attachment;filename=COE" + id + ".pdf");


            Response.Cache.SetCacheability(HttpCacheability.NoCache);


            Document pdfDoc = new Document(PageSize.LETTER, 100f, 100f, 50f, 50f);

            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

            pdfDoc.Open();
            BaseFont font = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            BaseFont font1 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, false);
            BaseFont font2 = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, false);
            Font f1 = new Font(font, Font.DEFAULTSIZE, 0, BaseColor.BLACK);
            Font f2 = new Font(font1, 24, 0, BaseColor.BLACK);
            Font f3 = new Font(font2, Font.DEFAULTSIZE, 0, BaseColor.BLACK);
            Font f4 = new Font(font, 9, 0, BaseColor.BLACK);
            PdfPTable table = new PdfPTable(1);
            table.WidthPercentage = 100;
            //String.Format("{0:n0}", 9876);
            Paragraph p0 = new Paragraph();
            Paragraph p1 = new Paragraph();
            Paragraph p2 = new Paragraph();
            Chunk c1 = new Chunk("\n\n\n\n\nCertificate of Employment \n\n\n\n");
            Chunk c2 = new Chunk("To Whom It May Concern: \n\n\n");
            Chunk c3 = new Chunk("This is to certify that ");
            Chunk c4 = new Chunk(gen1 + empfname + " " + empmname + ". " + empsname);
            Chunk c5 = new Chunk(" is an employee of ");
            Chunk c6 = new Chunk(coname);
            Chunk c7 = new Chunk(", holding a position of ");
            Chunk c8 = new Chunk(pos);
            Chunk c9 = new Chunk(" from " + Convert.ToDateTime(datestart).ToString("dd MMMM yyyy") + " to present." + gen3 +
                " salary per month is PHP" +  salary + ".\n\n");
            Chunk c10 = new Chunk("This certification is issued upon the request of the latter for " + gen2 + " " + COEReason.Value + ".\n\n" +
                "Done this " + cm.dtnow().ToString("dd MMMM yyyy") + " at Unit 1209 España Tower 2203 España Blvd. cor Josefina St. Sampaloc, Manila \n\n\n\n\n\n\n" +
                "____________________________\n" +
                "Arielle Ong \n" +
                "Human Resource Manager \n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
            Chunk c11 = new Chunk("Unit 1209 España Tower 2203 España Blvd. cor Josefina St. Sampaloc, Manila \n" +
                "Tel. # 5310-0687 • 8353-7552  • 8567-6016 • 8567-6602 • Fax: 5310-06-88");
            c1.Font = f2;
            c2.Font = f1;
            c3.Font = f1;
            c4.Font = f3;
            c5.Font = f1;
            c6.Font = f3;
            c7.Font = f1;
            c8.Font = f3;
            c9.Font = f1;
            c10.Font = f1;
            c11.Font = f4;
            p1.Add(c1);
            p0.Add(c2);
            p0.Add(c3);
            p0.Add(c4);
            p0.Add(c5);
            p0.Add(c6);
            p0.Add(c7);
            p0.Add(c8);
            p0.Add(c9);
            p0.Add(c10);
            p2.Add(c11);            

            PdfPCell cell1 = new PdfPCell(p1);
            cell1.BorderWidth = 0;
            cell1.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell1);

            PdfPCell cell2 = new PdfPCell(p0);
            cell2.BorderWidth = 0;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            table.AddCell(cell2);

            PdfPCell cell3 = new PdfPCell(p2);
            cell3.BorderWidth = 0;
            cell3.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell3);


            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(imagepath + "/" + filename);
            img.ScaleAbsolute(504f, 120f);
            img.SetAbsolutePosition(55, 630);

            pdfDoc.Add(img);
            pdfDoc.Add(table);

            pdfDoc.Close();

            Response.Write(pdfDoc);

            cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " exported COE to PDF File",
                "EXPORT", "x123", "qwg-23", "EXPORT", Session["EMP_ID"].ToString());

            Response.End();
        }
        protected void ExportToPDFwoComp(string id)
        {
            #region declarations
            string imagepath = Server.MapPath("../../../images"),
                empfname = cm.GetSpecificDataFromDB("emp_FirstName", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + id + "'"),
                empsname = cm.GetSpecificDataFromDB("emp_Surname", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + id + "'"),
                empmname = cm.GetSpecificDataFromDB("LEFT(emp_MidName, 1)", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + id + "'"),
                empgen = cm.GetSpecificDataFromDB("emp_Gender", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + id + "'"),
                datestart = cm.GetSpecificDataFromDB("emp_DateStart", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + id + "'"),
                emp_company = cm.GetSpecificDataFromDB("emp_Assignment", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + id + "'"),
                emp_stat = cm.GetSpecificDataFromDB("emp_Status", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + id + "'"),
                emp_pos = cm.GetSpecificDataFromDB("emp_Position", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + id + "'"),
                coname = cm.GetSpecificDataFromDB("CoName", "TBL_COMPANY", "where id = '" + emp_company + "'"),
                stat = cm.GetSpecificDataFromDB("StatusDesc", "TBL_STATUS", "where id = '" + emp_stat + "'"),
                pos = cm.GetSpecificDataFromDB("PositionName", "TBL_POSITION", "where id = '" + emp_pos + "'"),
                gen = "", gen1 = "", filename="";
            if (empgen.ToString() == "F")
            {
                gen = "her";
                gen1 = "Ms.";
            }
            if (empgen.ToString() == "M")
            {
                gen = "him";
                gen1 = "Mr.";
            }
            if (emp_company == "1")
            {
                filename = "9757-app_header.jpg";
            }
            else if (emp_company == "2")
            {
                filename = "m2b.png";
            }
            else if (emp_company == "3")
            {
                filename = "wais.png";
            }
            #endregion

            DateTime sdate = Convert.ToDateTime(datestart);

            Response.ContentType = "application/pdf";

            Response.AddHeader("content-disposition",

                "attachment;filename=COE" + id + ".pdf");


            Response.Cache.SetCacheability(HttpCacheability.NoCache);


            Document pdfDoc = new Document(PageSize.LETTER, 100f, 100f, 50f, 50f);

            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

            pdfDoc.Open();
            BaseFont font = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            BaseFont font1 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, false);
            BaseFont font2 = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, false);
            Font f1 = new Font(font, Font.DEFAULTSIZE, 0, BaseColor.BLACK);
            Font f2 = new Font(font1, 24, 0, BaseColor.BLACK);
            Font f3 = new Font(font2, Font.DEFAULTSIZE, 0, BaseColor.BLACK);
            Font f4 = new Font(font, 9, 0, BaseColor.BLACK);
            PdfPTable table = new PdfPTable(1);
            table.WidthPercentage = 100;

            Paragraph p0 = new Paragraph();
            Paragraph p1 = new Paragraph();
            Paragraph p2 = new Paragraph();
            Chunk c1 = new Chunk("\n\n\n\n\nCertificate of Employment \n\n\n\n");
            Chunk c2 = new Chunk("To Whom It May Concern: \n\n\n");
            Chunk c3 = new Chunk("This is to certify that ");
            Chunk c4 = new Chunk(gen1 + empfname + " " + empmname + ". " + empsname);
            Chunk c5 = new Chunk(" is an employee of ");
            Chunk c6 = new Chunk(coname);
            Chunk c7 = new Chunk(", holding a position of ");
            Chunk c8 = new Chunk(pos);
            Chunk c9 = new Chunk(" from " + Convert.ToDateTime(datestart).ToString("dd MMMM yyyy") + " to present.\n\n");
            Chunk c10 = new Chunk("This certification is issued upon the request of the latter for whatever legal purpose it may serve " + gen +".\n\n" +
                "Done this " + cm.dtnow().ToString("dd MMMM yyyy") + " at Unit 1209 España Tower 2203 España Blvd. cor Josefina St. Sampaloc, Manila \n\n\n\n\n\n\n" +
                "____________________________\n" +
                "Arielle Ong \n" +
                "Human Resource Manager \n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
            Chunk c11 = new Chunk("Unit 1209 España Tower 2203 España Blvd. cor Josefina St. Sampaloc, Manila \n" +
                "Tel. # 5310-0687 • 8353-7552  • 8567-6016 • 8567-6602 • Fax: 5310-06-88");            
            c1.Font = f2;
            c2.Font = f1;
            c3.Font = f1;
            c4.Font = f3;
            c5.Font = f1;
            c6.Font = f3;
            c7.Font = f1;
            c8.Font = f3;
            c9.Font = f1;
            c10.Font = f1;
            c11.Font = f4;
            p1.Add(c1);
            p0.Add(c2);
            p0.Add(c3);
            p0.Add(c4);
            p0.Add(c5);
            p0.Add(c6);
            p0.Add(c7);
            p0.Add(c8);
            p0.Add(c9);
            p0.Add(c10);
            p2.Add(c11);

            PdfPCell cell1 = new PdfPCell(p1);
            cell1.BorderWidth = 0;
            cell1.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell1);

            PdfPCell cell2 = new PdfPCell(p0);
            cell2.BorderWidth = 0;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            table.AddCell(cell2);

            PdfPCell cell3 = new PdfPCell(p2);
            cell3.BorderWidth = 0;
            cell3.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell3);


            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(imagepath + "/" + filename);
            img.ScaleAbsolute(504f, 120f);
            img.SetAbsolutePosition(55, 630);

            pdfDoc.Add(img);
            pdfDoc.Add(table);

            pdfDoc.Close();

            Response.Write(pdfDoc);

            cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " exported COE to PDF File",
                "EXPORT", "x123", "qwg-23", "EXPORT", Session["EMP_ID"].ToString());

            Response.End();
        }

        protected void ExportToPDFSep(string id)
        {
            #region declarations
            string date="", empfrom="",empto="", position="";
            string imagepath = Server.MapPath("../../../images"),
                empfname = cm.GetSpecificDataFromDB("emp_FirstName", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + id + "'"),
                empsname = cm.GetSpecificDataFromDB("emp_Surname", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + id + "'"),
                empmname = cm.GetSpecificDataFromDB("LEFT(emp_MidName, 1)", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + id + "'"),
                empgen = cm.GetSpecificDataFromDB("emp_Gender", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + id + "'"),
                datestart = cm.GetSpecificDataFromDB("emp_DateStart", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + id + "'"),
                emp_company = cm.GetSpecificDataFromDB("emp_Assignment", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + id + "'"),
                emp_stat = cm.GetSpecificDataFromDB("emp_Status", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + id + "'"),
                emp_pos = cm.GetSpecificDataFromDB("emp_Position", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + id + "'"),
                datesep = cm.GetSpecificDataFromDB("emp_DateSeparated", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + id + "'"),
                coname = cm.GetSpecificDataFromDB("CoName", "TBL_COMPANY", "where id = '" + emp_company + "'"),
                stat = cm.GetSpecificDataFromDB("StatusDesc", "TBL_STATUS", "where id = '" + emp_stat + "'"),
                pos = cm.GetSpecificDataFromDB("PositionName", "TBL_POSITION", "where id = '" + emp_pos + "'"),
                gen = "", gen1 = "", filename="";
            if (empgen.ToString() == "F")
            {
                gen = "her";
                gen1 = "Ms.";
            }
            if (empgen.ToString() == "M")
            {
                gen = "him";
                gen1 = "Mr.";
            }
            if (emp_company == "1")
            {
                filename = "9757-app_header.jpg";
            }
            else if (emp_company == "2")
            {
                filename = "m2b.png";
            }
            else if (emp_company == "3")
            {
                filename = "wais.png";
            }
            if(datesep == "")
            {
                datesep = DateTime.Now.ToString();
            }
            if (empmname != "")
                empmname = empmname + ".";
            else
                empmname = "";

            if (txtDate.Value != "")
                date = Convert.ToDateTime(txtDate.Value).ToString("dd MMMM yyyy");
            else
                cm.dtnow().ToString("dd MMMM yyyy");

            if (txtFrom.Value != "")
                empfrom = Convert.ToDateTime(txtFrom.Value).ToString("dd MMMM yyyy");
            else
                Convert.ToDateTime(datestart).ToString("dd MMMM yyyy");

            if (txtTo.Value != "")
                empto = Convert.ToDateTime(txtTo.Value).ToString("dd MMMM yyyy");
            else
                empto = Convert.ToDateTime(datesep).ToString("dd MMMM yyyy");

            if (txtPostion.Value != "")
                position = txtPostion.Value;
            else
                position = pos;
            #endregion

            DateTime sdate = Convert.ToDateTime(datestart);

            Response.ContentType = "application/pdf";

            Response.AddHeader("content-disposition",

                "attachment;filename=COE" + id + ".pdf");


            Response.Cache.SetCacheability(HttpCacheability.NoCache);


            Document pdfDoc = new Document(PageSize.LETTER, 100f, 100f, 50f, 50f);

            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

            pdfDoc.Open();
            BaseFont font = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            BaseFont font1 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, false);
            BaseFont font2 = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, false);
            Font f1 = new Font(font, Font.DEFAULTSIZE, 0, BaseColor.BLACK);
            Font f2 = new Font(font1, 24, 0, BaseColor.BLACK);
            Font f3 = new Font(font2, Font.DEFAULTSIZE, 0, BaseColor.BLACK);
            Font f4 = new Font(font, 9, 0, BaseColor.BLACK);
            PdfPTable table = new PdfPTable(1);
            table.WidthPercentage = 100;

            Paragraph p0 = new Paragraph();
            Paragraph p1 = new Paragraph();
            Paragraph p2 = new Paragraph();
            Chunk c1 = new Chunk("\n\n\n\n\nCertificate of Employment \n\n\n\n");
            Chunk c2 = new Chunk("To Whom It May Concern: \n\n\n");
            Chunk c3 = new Chunk("This is to certify that ");
            Chunk c4 = new Chunk(gen1 + empfname + " " + empmname + " " + empsname);
            Chunk c5 = new Chunk(" is an employee of ");
            Chunk c6 = new Chunk(coname);
            Chunk c7 = new Chunk(", holding a position of ");
            Chunk c8 = new Chunk(position);
            Chunk c9 = new Chunk(" from " + empfrom + " to " + empto + ".\n\n");
            Chunk c10 = new Chunk("This certification is issued upon the request of " + gen1 + empfname + " " + empmname + ". " + empsname +" for whatever legal purpose it may serve " + gen + " best.\n\n" +
                txtRemarks.Value.ToString() + "\n\n" +
                "Done this " + date + " at Unit 1209 España Tower 2203 España Blvd. cor Josefina St. Sampaloc, Manila \n\n\n\n\n\n\n" +
                "____________________________\n" +
                "Arielle Ong \n" +
                "Human Resource Manager \n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
            Chunk c11 = new Chunk("Unit 1209 España Tower 2203 España Blvd. cor Josefina St. Sampaloc, Manila \n" +
                "Tel. # 5310-0687 • 8353-7552  • 8567-6016 • 8567-6602 • Fax: 5310-06-88");
            c1.Font = f2;
            c2.Font = f1;
            c3.Font = f1;
            c4.Font = f3;
            c5.Font = f1;
            c6.Font = f3;
            c7.Font = f1;
            c8.Font = f3;
            c9.Font = f1;
            c10.Font = f1;
            c11.Font = f4;
            p1.Add(c1);
            p0.Add(c2);
            p0.Add(c3);
            p0.Add(c4);
            p0.Add(c5);
            p0.Add(c6);
            p0.Add(c7);
            p0.Add(c8);
            p0.Add(c9);
            p0.Add(c10);
            p2.Add(c11);

            PdfPCell cell1 = new PdfPCell(p1);
            cell1.BorderWidth = 0;
            cell1.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell1);

            PdfPCell cell2 = new PdfPCell(p0);
            cell2.BorderWidth = 0;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            table.AddCell(cell2);

            PdfPCell cell3 = new PdfPCell(p2);
            cell3.BorderWidth = 0;
            cell3.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell3);


            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(imagepath + "/" + filename);
            img.ScaleAbsolute(504f, 120f);
            img.SetAbsolutePosition(55, 630);

            pdfDoc.Add(img);
            pdfDoc.Add(table);

            pdfDoc.Close();

            Response.Write(pdfDoc);

            cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " exported COE to PDF File",
                "EXPORT", "x123", "qwg-23", "EXPORT", Session["EMP_ID"].ToString());

            Response.End();
        }
        #endregion

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

        public void closeTransDetailsSep()
        {
            upListSep.Update();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(string.Format(@"$('#{0}').modal('hide')", "sepmodal"));
            sb.Append(@"</script>");

            ScriptManager.RegisterStartupScript(this, this.GetType(), "sepmodal", sb.ToString(), false);

        }
        public void openTransDetailsSep(string empNo)
        {
            upListSep.Update();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(string.Format(@"$('#{0}').modal('show')", "sepmodal"));
            sb.Append(@"</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "sepmodal", sb.ToString(), false);
            string divname = "";
        }
        protected void lnkbtnClose_Click(object sender, EventArgs e)
        {
            closeTransDetailsSep();
        }
        protected void btnSaveSep_Click(object sender, EventArgs e)
        {
            ExportToPDFSep(HiddenEmpID.Value);
            string empfname = cm.GetSpecificDataFromDB("emp_FullName", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = " + id + "");


            cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " generated " + type + "COE for " + empfname,
                            "EXPORT", "x123", "qwg-23", "EXPORT", Session["EMP_ID"].ToString());
        }        

        protected void btnsaveUpdate_Click(object sender, EventArgs e)
        {           
            ExportToPDFwComp(HiddenEmpID.Value);
            string empfname = cm.GetSpecificDataFromDB("emp_FullName", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = " + id + "");


            cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " generated " + type + "COE for " + empfname,
                            "EXPORT", "x123", "qwg-23", "EXPORT", Session["EMP_ID"].ToString());
            
            //Response.Redirect("COEOThers.aspx");
            
        }

        protected void OnDataBound(object sender, EventArgs e)
        {
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            TableHeaderCell cell = new TableHeaderCell();
            cell.Text = "";
            cell.ColumnSpan = 1;
            row.Controls.Add(cell);

            GridUserList.HeaderRow.Parent.Controls.AddAt(0, row);
        }
    }
}