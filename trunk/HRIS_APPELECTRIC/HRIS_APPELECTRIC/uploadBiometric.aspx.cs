using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace HRIS_APPELECTRIC
{
    public partial class uploadBiometric : System.Web.UI.Page
    {
        Timekeeping tk = new Timekeeping();
        protected void Page_Load(object sender, EventArgs e)
        {

            foreach (string f in Request.Files.AllKeys)
            {
                HttpPostedFile file = Request.Files[f];
                //file.SaveAs(Server.MapPath("~/Uploads/" + file.FileName));
                string fileName = file.FileName.Replace(".dat", "").ToString();
                string datFilePath = Server.MapPath("~/201Files/UploadedDATFiles") + "\\" + file.FileName;

                //file.SaveAs(datFilePath);
                if (tk.processData(null, file))
                {
                    //log to database
                    //status = "success"
                    //timestamp = cm.FormatTime(datetime.now)
                    //remarks = "added new log record for " + "file.Filename 
                }
                else
                {
                    //take a second chance if it fails at first
                    StreamReader sr = new StreamReader(file.InputStream);
                    if (!tk.processData(sr))
                    {
                        ///log to database
                        //status = "failed"
                        //timestamp = cm.FormatTime(datetime.now)
                        //remarks = "failed to add new log record for " + "file.Filename 
                    }
                    else
                    {
                        //log success
                    }

                }
                //Create table TBL_BMUPLOADERLOG
                //add field id(identity), status(varchar50), timestamp(datetime), remarks(varchar 100)

            }
        }
    }
}