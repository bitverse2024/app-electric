using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

namespace HRIS_APPELECTRIC.Pages.Admin
{
    public partial class UpdateBulkData : System.Web.UI.Page
    {
        Common cm = new Common();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ROLES"].ToString() != "admin")
            {
                Response.Redirect("~/Pages/Login.aspx");
            }
        }
        protected void btnUploadFile_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            FileInfo fileInfo = new FileInfo(fuUploader.PostedFile.FileName);
            Stream filestream = fuUploader.FileContent;
            DataTable dt = new DataTable();
            int ret = cm.EmployeeBulkUpdate(filestream, out dt);
            if (ret == 1)
                //if (cm.getXLS(fuUploader.PostedFile.FileName, out dt))
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Updated !!!');", true);
            else if (ret == -1)
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Failed to upload !!!. Please create a schedule first');", true);
            else
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Failed to upload !!!');", true);
        }
    }
}