using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Data;

namespace HRIS_APPELECTRIC.Pages.Admin.Reports
{
    public partial class forms : System.Web.UI.Page
    {
        Common cm = new Common();
        Employee db_Emp = new Employee();
        public string empno = "";
        string id, type, empfname,empComp,empDept,empDeptid;
        protected void Page_Load(object sender, EventArgs e)
        {
            empno = Session["EMP_ID"].ToString();
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

        protected void GridUserList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ClaimedLeave")
            {
                id = e.CommandArgument.ToString();
                empfname = cm.GetSpecificDataFromDB("emp_FullName", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = " + id + "");
                empComp = cm.GetSpecificDataFromDB("emp_Assignment", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = " + id + "");
                empDeptid = cm.GetSpecificDataFromDB("emp_Department", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = " + id + "");
                empDept = cm.GetSpecificDataFromDB("DeptName", "TBL_DEPARTMENT", "where id = " + empDeptid + "");
                ClaimedLeave(id);                
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " generated " + type + "Claimed Leave Approval Form for " + empfname,
                                "EXPORT", "x123", "qwg-23", "EXPORT", Session["EMP_ID"].ToString());
            }
            if (e.CommandName == "CashAd")
            {
                id = e.CommandArgument.ToString();
                empfname = cm.GetSpecificDataFromDB("emp_FullName", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = " + id + "");
                empComp = cm.GetSpecificDataFromDB("emp_Assignment", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = " + id + "");
                empDeptid = cm.GetSpecificDataFromDB("emp_Department", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = " + id + "");
                empDept = cm.GetSpecificDataFromDB("DeptName", "TBL_DEPARTMENT", "where id = " + empDeptid + "");
                CashAd(id);
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " generated " + type + "Claimed Leave Approval Form for " + empfname,
                                "EXPORT", "x123", "qwg-23", "EXPORT", Session["EMP_ID"].ToString());
            }
            if (e.CommandName == "AbsentFrm")
            {
                id = e.CommandArgument.ToString();
                empfname = cm.GetSpecificDataFromDB("emp_FullName", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = " + id + "");
                empComp = cm.GetSpecificDataFromDB("emp_Assignment", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = " + id + "");
                empDeptid = cm.GetSpecificDataFromDB("emp_Department", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = " + id + "");
                empDept = cm.GetSpecificDataFromDB("DeptName", "TBL_DEPARTMENT", "where id = " + empDeptid + "");
                AbsentFrm(id);
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " generated " + type + "Claimed Leave Approval Form for " + empfname,
                                "EXPORT", "x123", "qwg-23", "EXPORT", Session["EMP_ID"].ToString());
            }
        }
        protected void ClaimedLeave(string id)
        {
            Response.ContentType = "application/pdf";

            Response.AddHeader("content-disposition",

                "attachment;filename=claimedleavesform.pdf");

            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            var pgSize = new iTextSharp.text.Rectangle(612, 936);
            string text = "";
            BaseFont font = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            BaseFont font1 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, false);
            Font f1 = new Font(font1    , 16, 0, BaseColor.BLACK);
            Font f2 = new Font(font, 14, 0, BaseColor.BLACK);
            Font f3 = new Font(font, 14, 0, BaseColor.BLACK);
            Document document = new Document(PageSize.LEGAL, 60f, 60f, 60f, 60f);
            HTMLWorker htmlparser = new HTMLWorker(document);
            PdfWriter.GetInstance(document, Response.OutputStream);
            //string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //PdfWriter.GetInstance(document, new FileStream(path + "/claimedleavesform.pdf", FileMode.Create, FileAccess.Write));
            document.Open();
            PdfPTable table = new PdfPTable(1);
            //table.SetWidths(new float[] { 391, 5, 396 });
            table.WidthPercentage = 100;
            string imgpath = Server.MapPath("../../../images");

            iTextSharp.text.Image myimage1 = iTextSharp.text.Image.GetInstance(imgpath + "/9757-app_header.jpg");
            if (empComp == "1")
            {
                myimage1 = iTextSharp.text.Image.GetInstance(imgpath + "/9757-app_header.jpg");
            }
            if (empComp == "2")
            {
                myimage1 = iTextSharp.text.Image.GetInstance(imgpath + "/m2b.png");
            }
            if (empComp == "3")
            {
                myimage1 = iTextSharp.text.Image.GetInstance(imgpath + "/wais.png");
            }
            myimage1.ScaleAbsolute(280f, 100f);
            PdfPCell cell0 = new PdfPCell(myimage1);
            cell0.BorderWidth = 0;
            cell0.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(new PdfPCell(cell0));

            Paragraph p0 = new Paragraph();
            Paragraph p1 = new Paragraph();
            Chunk c0 = new Chunk("CLAIMED LEAVE APPROVAL FORM \n\n");
            Chunk c1 = new Chunk("NAME: "+ empfname +"	    DATE TODAY: " + DateTime.Now.ToString("MMMM dd, yyyy") + "\n" +
               "DEPARTMENT: " + empDept + "               \n\n" +
               "DATE OF CONCERN: ______________	FROM: ________ TO: ________ \n" +
               "REASON:                                                \n" +
               "   _____________________________________________________________\n" +
               "______________________________________________________________\n" +
               "______________________________________________________________\n" +
               "WHO DID YOU INFORM? HOW?_________________________________\n" +
               "WHEN & WHAT TIME DID YOU INFORM? ________________________\n\n" +
               "                                                            		                   ______________________\n" +
               "                                                                                       Signature of Employee\n" +
               "Endorse by: _______________                     Approved by:_____________");
           
            f3.IsUnderlined();
            c0.Font = f1;
            c1.Font = f2;
           
            p0.Add(c0);
            p1.Add(c1);
            
            p1.SetLeading(14, 0);
            PdfPCell cell1 = new PdfPCell(p0);
            cell1.BorderWidth = 0;
            cell1.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(new PdfPCell(cell1));

            PdfPCell cell2 = new PdfPCell(p1);
            cell2.BorderWidth = 0;
            //cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(new PdfPCell(cell2));

            table.SpacingAfter = 20f;
            document.Add(table);
            document.Add(table);
            document.Close();
            Response.Write(document);

            cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " generated Claimed Leaves Forms",
                "EXPORT", "x123", "qwg-23", "EXPORT", Session["EMP_ID"].ToString());

            Response.End();
        }
        protected void CashAd(string id)
        {
            Response.ContentType = "application/pdf";

            Response.AddHeader("content-disposition",

                "attachment;filename=cashadvanceform.pdf");

            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            var pgSize = new iTextSharp.text.Rectangle(612, 936);
            string text = "";
            BaseFont font = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, false);
            BaseFont font1 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            Font f1 = new Font(font, 14, 0, BaseColor.BLACK);
            Font f2 = new Font(font1, 12, 0, BaseColor.BLACK);
            Document document = new Document(PageSize.LETTER, 30f, 30f, 30f, 30f);
            HTMLWorker htmlparser = new HTMLWorker(document);
            PdfWriter.GetInstance(document, Response.OutputStream);
            //string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //PdfWriter.GetInstance(document, new FileStream(path + "/claimedleavesform.pdf", FileMode.Create, FileAccess.Write));
            document.Open();
            PdfPTable table = new PdfPTable(1);
            table.WidthPercentage = 100;
            PdfPTable table1 = new PdfPTable(1);
            table1.WidthPercentage = 100;
            string imgpath = Server.MapPath("../../../images");


            iTextSharp.text.Image myimage1 = iTextSharp.text.Image.GetInstance(imgpath + "/9757-app_header.jpg");
            if (empComp == "1")
            {
                myimage1 = iTextSharp.text.Image.GetInstance(imgpath + "/9757-app_header.jpg");
            }
            if (empComp == "2")
            {
                myimage1 = iTextSharp.text.Image.GetInstance(imgpath + "/m2b.png");
            }
            if (empComp == "3")
            {
                myimage1 = iTextSharp.text.Image.GetInstance(imgpath + "/wais.png");
            }
            myimage1.ScaleAbsolute(280f, 100f);
            PdfPCell cell0 = new PdfPCell(myimage1);
            cell0.PaddingTop = 15f;
            cell0.BorderWidth = 0;
            cell0.HorizontalAlignment = Element.ALIGN_CENTER;
            table1.AddCell(new PdfPCell(cell0));

            Paragraph p0 = new Paragraph();
            Paragraph p1 = new Paragraph();
            Chunk c0 = new Chunk("CASH ADVANCE FORM \n\n");
            Chunk c1 = new Chunk("Date Today: ");
            Chunk c2 = new Chunk(DateTime.Now.ToString("MMMM dd, yyyy") + "	                        \n\n");
            Chunk c3 = new Chunk("Name: ");
            Chunk c4 = new Chunk(empfname + "                 ");
            Chunk c5 = new Chunk("Department: ");
            Chunk c6 = new Chunk(empDept + "  \n\n" +
                "Amount of Vale: ______________ \n\n" +
                "Reason for Vale: _________________________________________________________\n\n" +
                "_______________________________________________________________________\n\n" +
                "Payment Plan:_______________(kaltas/week)              Kaltas Starting:______________\n\n" +
                "Endorse Signature:                                                           Approver Signature:\n\n" +
                "__________________                                                     ________________");
            c0.Font = f1;
            c1.Font = f2;
            c2.Font = f2;
            c3.Font = f2;
            c4.Font = f2;
            c5.Font = f2;
            c6.Font = f2;
            p0.Add(c0);
            p1.Add(c1);
            p1.Add(c2);
            p1.Add(c3);
            p1.Add(c4);
            p1.Add(c5);
            p1.Add(c6);
            PdfPCell cell1 = new PdfPCell(p0);
            cell1.BorderWidth = 0;
            cell1.HorizontalAlignment = Element.ALIGN_CENTER;

            table1.AddCell(new PdfPCell(cell1));

            PdfPCell cell2 = new PdfPCell(p1);
            cell2.BorderWidth = 0;
            //cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            table1.AddCell(new PdfPCell(cell2));

            PdfPCell cell3 = new PdfPCell(table1);
            cell3.HorizontalAlignment = Element.ALIGN_CENTER;
            cell3.PaddingLeft = 60f;
            cell3.PaddingRight = 60f;
            cell3.PaddingBottom = 10f;
            cell3.BorderWidth = 1f;
            table.AddCell(new PdfPCell(cell3));

            table.SpacingAfter = 20f;
            document.Add(table);
            document.Add(table);
            document.Close();
            Response.Write(document);

            cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " generated Cash Advance Form",
                "EXPORT", "x123", "qwg-23", "EXPORT", Session["EMP_ID"].ToString());

            Response.End();
        }

        protected void AbsentFrm(string id)
        {
            Response.ContentType = "application/pdf";

            Response.AddHeader("content-disposition",

                "attachment;filename=absentform.pdf");

            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            var pgSize = new iTextSharp.text.Rectangle(612, 936);
            string text = "";
            BaseFont font = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, false);
            BaseFont font1 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            Font f1 = new Font(font1, 9, 0, BaseColor.BLACK);
            Font f2 = new Font(font1, 13, 0, BaseColor.BLACK);
            Document document = new Document(PageSize.LETTER, 60f, 50f, 0f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(document);
            PdfWriter.GetInstance(document, Response.OutputStream);
            //string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //PdfWriter.GetInstance(document, new FileStream(path + "/claimedleavesform.pdf", FileMode.Create, FileAccess.Write));
            document.Open();
            PdfPTable table = new PdfPTable(1);
            table.WidthPercentage = 100;
            PdfPTable table1 = new PdfPTable(6);
            table1.WidthPercentage = 100;
            table1.SetWidths(new float[] { 15, 150, 15, 150, 15, 100 });
            string imgpath = Server.MapPath("../../../images");


            iTextSharp.text.Image myimage1 = iTextSharp.text.Image.GetInstance(imgpath + "/9757-app_header.jpg");
            if (empComp == "1")
            {
                myimage1 = iTextSharp.text.Image.GetInstance(imgpath + "/9757-app_header.jpg");
            }
            if (empComp == "2")
            {
                myimage1 = iTextSharp.text.Image.GetInstance(imgpath + "/m2b.png");
            }
            if (empComp == "3")
            {
                myimage1 = iTextSharp.text.Image.GetInstance(imgpath + "/wais.png");
            }
            myimage1.ScaleAbsolute(280f, 100f);
            PdfPCell cell0 = new PdfPCell(myimage1);
            cell0.BorderWidth = 0;
            cell0.PaddingTop = 2f;
            cell0.HorizontalAlignment = Element.ALIGN_CENTER;
            cell0.VerticalAlignment = Element.ALIGN_TOP;
            table.AddCell(new PdfPCell(cell0));

            PdfPCell cell1 = new PdfPCell();
            cell1.BorderWidth = 1f;
            table1.AddCell(new PdfPCell(cell1));

            Chunk c0 = new Chunk("ABSENT");
            c0.Font = f2;
            Paragraph p0 = new Paragraph(c0);
            PdfPCell cell2 = new PdfPCell(p0);
            cell2.BorderWidth = 0;
            cell2.FixedHeight = 10f;
            table1.AddCell(new PdfPCell(cell2));

            PdfPCell cell3 = new PdfPCell();
            cell3.BorderWidth = 1f;
            table1.AddCell(new PdfPCell(cell3));

            Chunk c1 = new Chunk("HALFDAY/UNDERTIME \n # OF HOURS ____");
            c1.Font = f1;
            Paragraph p1 = new Paragraph(c1);
            PdfPCell cell4 = new PdfPCell(p1);
            cell4.BorderWidth = 0;
            table1.AddCell(new PdfPCell(cell4));

            PdfPCell cell5 = new PdfPCell();
            cell5.BorderWidth = 1f;
            table1.AddCell(new PdfPCell(cell5));

            Chunk c2 = new Chunk("LEAVE FORM");
            c2.Font = f2;
            Paragraph p2 = new Paragraph(c2);
            PdfPCell cell6 = new PdfPCell(p2);
            cell6.BorderWidth = 0;
            table1.AddCell(new PdfPCell(cell6));

            PdfPCell cell7 = new PdfPCell(table1);
            cell7.BorderWidth = 0;
            cell7.PaddingTop = 10f;
            cell7.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(new PdfPCell(cell7));

            Paragraph p3 = new Paragraph();
            Chunk c7 = new Chunk("NAME: " + empfname + "             DATE TODAY: " + DateTime.Now.ToString("MMMM dd, yyyy") + "   \n" +
                "DEPARTMENT: " + empDept + " \n\n" +
                "DATE OF CONCERN: ________________ FROM: __________ TO: __________\n" +
                "REASON:\n" +
                "       __________________________________________________________\n\n" +
                "       __________________________________________________________\n\n" +
                "       __________________________________________________________\n\n" +
                "WHO DID YOU INFORM? HOW?______________________________________\n" +
                "WHEN & WHAT TIME DID YOU INFORM? ______________________________\n\n" +
                "                                                          		                               ____________________\n" +
                "                                                                                           Signature of Employee\n\n" +
                "Endorse by: _______________                               Approved by:_____________");
            c7.Font = f2;
            p3.Add(c7);
            PdfPCell cell8 = new PdfPCell(p3);
            cell8.BorderWidth = 0;
            cell8.HorizontalAlignment = Element.ALIGN_LEFT;
            table.AddCell(new PdfPCell(cell8));

            document.Add(table);
            document.Add(table);
            document.Close();
            Response.Write(document);

            cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " generated Absent Form",
                "EXPORT", "x123", "qwg-23", "EXPORT", Session["EMP_ID"].ToString());

            Response.End();
        }
      
    }
}