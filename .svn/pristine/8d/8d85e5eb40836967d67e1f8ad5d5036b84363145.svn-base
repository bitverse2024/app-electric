using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

namespace HRIS_APPELECTRIC.Pages.Admin.Employees._201
{
    public partial class viewfiles : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Common cm = new Common();
        public string empno = "";
        string empviewURL = "";
        string fileid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ROLES"].ToString() != "admin" && Session["ROLES"].ToString() != "employee")
            {
                Response.Redirect("~/Pages/Login.aspx");
            }

            empno = Request.QueryString["id"];
            //if (empno != Session["ACTIVE_EMPNO"].ToString())
            //{

            //    empno = Session["ACTIVE_EMPNO"].ToString();
            //    ScriptManager.RegisterStartupScript(this, this.GetType(),
            //    "alert",
            //    "alert('Injection not allowed!!!');window.location ='viewfiles.aspx?id=" + empno + "';",
            //    true);
            //}


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
            dt = emp.populateGridFiles(empno);
            GridFilesList.DataSource = dt;
            GridFilesList.DataBind();
            ViewState["EMP_FILES"] = dt;
            ViewState["SORTDR"] = null;
        }
        protected void sort_grid(string sort_args)
        {
            DataTable dt = (DataTable)ViewState["EMP_FILES"];
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

                GridFilesList.DataSource = dt;
                GridFilesList.DataBind();


            }

        }
        protected void btnUploadImage_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                string filename = "";
                if (IsUploaded(out filename, empno))
                {
                    if (emp.AddFileToDB(empno, filename, drpdwnCategory.SelectedValue))
                    {
                        refresh();
                        ScriptManager.RegisterStartupScript(this, this.GetType(),
                    "alert",
                    "alert('File successfully uploaded: " + filename + "');",
                    true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                    "alert",
                    "alert('Failed to upload: " + filename + "');",
                    true);


                }
            }
        }

        bool IsUploaded(out string outfilename, string id)
        {
            bool valid = true;
            outfilename = "";
            string fileIdentifier = (id == "" ? "" : id + "_");
            string fulldirectory = Server.MapPath(emp.file201folder);
            //if (drpdwnCategory.SelectedIndex > 0)
            fulldirectory += drpdwnCategory.SelectedValue + @"\";


            if (!Directory.Exists(fulldirectory))
                Directory.CreateDirectory(fulldirectory);
            try
            {
                string filename = fileIdentifier + Path.GetFileName(fuUploader.PostedFile.FileName);
                //string fileURL = Page.ResolveUrl("~/201Files");
                string fileToUpload = fulldirectory + filename;

                outfilename = filename;
                if (!File.Exists(fileToUpload))
                    fuUploader.SaveAs(fileToUpload);
                else
                {
                    valid = false;
                    outfilename = outfilename + ":  Duplicate file name(s) are not allowed";
                }
            }
            catch (Exception ex)
            {
                valid = false;
                outfilename = outfilename + ":  " + ex.ToString();
            }
            return valid;


        }
        protected void GridFilesList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridFilesList.PageIndex = e.NewPageIndex;
            refresh();
        }
        protected void GridFilesList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sort")
            {
                sort_grid(e.CommandArgument.ToString());

            }
            if (e.CommandName == "dl_file")
            {
                downloadFile(e.CommandArgument.ToString());

            }
            if (e.CommandName == "del")
            {
                File.Delete(emp.Get201FilePath(Server.MapPath(emp.file201folder), e.CommandArgument.ToString()));
                emp.DeleteQuery("TBL_201FILES", "where id =" + e.CommandArgument.ToString() + "");
                refresh();
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Successfully Deleted');",
                true);

            }
        }

        protected void downloadFile(string fileID)
        {
            FileInfo file = new FileInfo(emp.Get201FilePath(Server.MapPath(emp.file201folder), fileID));

            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + file.Name + "");
            Response.TransmitFile(file.FullName);
            Response.End();

        }

        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            //awong-retrieve textbox values from the grid control during runtime.
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
            //string a1 = ((TextBox)GridUserList.FindControl("txtSearch1")).Text;
            //string a2 = ((TextBox)GridUserList.FindControl("txtSearch2")).Text;
            string fileId = ((TextBox)currentRow.FindControl("txtSearchFileID")).Text;
            string fname = ((TextBox)currentRow.FindControl("txtSearchFilename")).Text;
            string categ = ((TextBox)currentRow.FindControl("txtSearchCateg")).Text;


            GridFilesList.DataSource = emp.populateGridFilesCol(empno, fileId, fname, categ);
            GridFilesList.DataBind();

            #region Search per textbox
            //if (sender is TextBox)
            //{
            //    TextBox txtBox = (TextBox)sender;
            //    if (txtBox.ID == "txtSearch1")
            //    {
            //        GridUserList.DataSource = db.populateGridUserListCol(txtBox.Text, "");
            //        GridUserList.DataBind();
            //    }
            //    if (txtBox.ID == "txtSearch2")
            //    {
            //        GridUserList.DataSource = db.populateGridUserListCol("", txtBox.Text);
            //        GridUserList.DataBind();
            //    }
            //}
            #endregion

        }
    }
}