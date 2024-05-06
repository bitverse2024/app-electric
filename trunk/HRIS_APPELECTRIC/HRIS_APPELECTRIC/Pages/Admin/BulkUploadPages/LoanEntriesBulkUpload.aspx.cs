using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using ClosedXML.Excel;

namespace HRIS_APPELECTRIC.Pages.Admin.BulkUploadPages
{
    public partial class LoanEntriesBulkUpload : System.Web.UI.Page
    {
        Common cm = new Common();
        Employee emp = new Employee();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["ROLES"].ToString() != "admin" || Session["ROLES"] == null)
                {
                    Session.Abandon();
                    Session.Clear();
                    Response.Redirect("~/Pages/Login.aspx");

                }
            }
            catch
            {
                Session.Clear();
                Session.Abandon();
                Response.Redirect("~/Pages/Login.aspx");
            }


        }

        protected void btnUploadFile_Click(object sender, EventArgs e)
        {
            //Open the Excel file using ClosedXML.
            using (XLWorkbook workBook = new XLWorkbook(fuUploader.PostedFile.InputStream))
            {
                //Read the first Sheet from Excel file.
                IXLWorksheet workSheet = workBook.Worksheet(1);

                //Create a new DataTable.
                DataTable dt = new DataTable();

                //Loop through the Worksheet rows.
                bool firstRow = true;
                foreach (IXLRow row in workSheet.Rows())
                {
                    //Use the first row to add columns to DataTable.
                    if (firstRow)
                    {
                        foreach (IXLCell cell in row.Cells())
                        {
                            dt.Columns.Add(cell.Value.ToString());
                        }
                        firstRow = false;
                    }
                    else
                    {
                        //Add rows to DataTable.
                        dt.Rows.Add();
                        int i = 0;
                        //foreach (IXLCell cell in row.Cells())
                        //{
                        //    dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                        //    i++;
                        //}
                        foreach (IXLCell cell in row.Cells(1, dt.Columns.Count))
                        {
                            dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                            i++;
                        }
                    }


                }
                System.Threading.Thread.Sleep(5000);
                FileInfo fileInfo = new FileInfo(fuUploader.PostedFile.FileName);
                Stream filestream = fuUploader.FileContent;
                DataTable dtout = new DataTable();
                int ret = cm.UploadBulkLoanEntries(dt, out dtout);
                if (ret == 1)
                {
                    //if (cm.getXLS(fuUploader.PostedFile.FileName, out dt))
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Uploaded !!!');", true);
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " Upload Bulk Loan Entries",
                       "CHANGE", "BULKDATA", Session["EMP_ID"].ToString(), "BULKDATA", Session["EMP_ID"].ToString());
                }
                else if (ret == -1)
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Failed to upload, invalid column header from excel.');", true);
                else
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Failed to upload !!!');", true);
            }


        }



    }
}