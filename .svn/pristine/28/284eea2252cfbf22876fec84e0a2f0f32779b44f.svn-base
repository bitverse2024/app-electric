using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace HRIS_APPELECTRIC.Pages.HRRecruitment
{
    public partial class applicantuploadfiles : System.Web.UI.Page
    {
        public string applicantid = "";
        public Common cm = new Common();
        public HR hr = new HR();
        Employee emp = new Employee();
        public string empno = "";
        string empviewURL = "";
        public Dictionary<string, string> applicantInfo = new Dictionary<string, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            applicantid = Request.QueryString["id"];
            applicantInfo = cm.GetTableDict("TBL_APPLICANT", "where id = " + applicantid + "");

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
            dt = hr.populateGridFiles(applicantid);
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
            string filename = "";
            if (IsUploaded(out filename, applicantid))
            {
                if (hr.AddFileToDB(applicantid, filename, drpdwnCategory.SelectedValue))
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
                    outfilename = outfilename + ":  Filename not available. Please use another filename";
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
                emp.DeleteQuery("TBL_201FILES", "where id =" + applicantid + "");
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


            GridFilesList.DataSource = hr.populateGridFilesCol(applicantid, fileId, fname, categ);
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