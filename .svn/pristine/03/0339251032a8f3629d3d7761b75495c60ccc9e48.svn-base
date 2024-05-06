using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Windows.Xps.Packaging;
using System.IO.Packaging;
using System.Globalization;

namespace HRIS_APPELECTRIC.Pages.Admin.TK
{
    public partial class uploaddtr : System.Web.UI.Page
    {
        Timekeeping tk = new Timekeeping();
        Employee emp = new Employee();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000);
            //FileInfo fileInfo = new FileInfo(fuUploader.PostedFile.FileName);
            //string fileName = fileInfo.Name.Replace(".dat", "").ToString();
            //string datFilePath = Server.MapPath("~/201Files/UploadedDATFiles") + "\\" + fileInfo.Name;
            //fuUploader.SaveAs(datFilePath);

            ////Fetch the location of CSV file   
            //string filePath = Server.MapPath("~/201Files/UploadedDATFiles") + "\\";

            //if (tk.processData(datFilePath))
            //    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Uploaded !!!');", true);
            //else
            //    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Failed to upload !!!');", true);

            //StreamReader sr;
            Stream strm;
            if (fuUploader.HasFile)
            {
                //sr = new StreamReader(fuUploader.FileContent);
                strm = fuUploader.FileContent;
                //if (tk.processData(sr))
                if (tk.processData(ExtractTextFromXpsFiltered(strm)))
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Uploaded !!!');", true);
                else
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Failed to upload !!!');", true);


            }
        }

        private DataTable ExtractTextFromXpsFiltered(Stream strmcontent)
        {
            DataTable tempdb = new DataTable();
            tempdb.Columns.Add("EmpID");
            tempdb.Columns.Add("EmpName");
            tempdb.Columns.Add("DateTime");
            tempdb.Columns.Add("TimeIN_OUT");
            tempdb.Columns.Add("Flag");
            var pkg = Package.Open(strmcontent);


            var xpsDocument = new XpsDocument(pkg, CompressionOption.SuperFast);
            var fixedDocSeqReader = xpsDocument.FixedDocumentSequenceReader;
            if (fixedDocSeqReader == null)
                return null;

            const string UnicodeString = "UnicodeString";
            const string GlyphsString = "Glyphs";

            //var textLists = new List<List<string>>();
            var textLists = new Dictionary<string, Dictionary<string, List<string>>>();

            string empinfo = "";
            string empname = "";
            string bioID = "";
            string datetime = "";
            string timeinout = "";
            string flag = "";
            string newempinfo = "";

            foreach (IXpsFixedDocumentReader fixedDocumentReader in fixedDocSeqReader.FixedDocuments)
            {
                foreach (IXpsFixedPageReader pageReader in fixedDocumentReader.FixedPages)
                {
                    var texts = new List<string>();

                    var pageContentReader = pageReader.XmlReader;
                    if (pageContentReader == null)
                        continue;

                    //var texts = new List<string>();
                    while (pageContentReader.Read())
                    {
                        if (pageContentReader.Name != GlyphsString)
                            continue;
                        if (!pageContentReader.HasAttributes)
                            continue;
                        if (pageContentReader.GetAttribute(UnicodeString) != null)
                        {
                            string dataToadd = pageContentReader.GetAttribute(UnicodeString);
                            
                             if (dataToadd == "C/Out:" || dataToadd == "C/In:" || dataToadd == "Lister:")
                                continue;
                            //if (!(dataToadd.Contains("Record") || dataToadd.Contains("-") || dataToadd.Contains("Department") || dataToadd.Contains("COMPANY") ))//07/04/2022 Jan Wong
                                if (!(dataToadd.Contains("Record") || (dataToadd.Contains("-") && dataToadd.Contains("Temp")) || (dataToadd.Contains("-") && char.IsDigit(dataToadd[0])) || dataToadd.Contains("Department") || dataToadd.Contains("COMPANY")))
                                {
                                bool IsDate = false; DateTime dt;
                                bool IsAction = (dataToadd == "C/Out" || dataToadd == "C/In");
                                int tryint = 0;
                                bool IsInt = int.TryParse(dataToadd, out tryint);
                                //IsDate = DateTime.TryParse(dataToadd, out dt);
                                //IsDate = DateTime.TryParseExact(dataToadd, "M/d/yyyy h:mm:ss tt", null, DateTimeStyles.None, out dt);
                                var formats = new string[] { "MM-dd-yyyy h:mm:ss tt", "yyyyMMdd h:mm:ss tt", "yyyy-MM-dd h:mm:ss tt", "MM/dd/yyyy h:mm:ss tt", "MM/dd/yyyy h:mm:ss tt", "M/dd/yyyy h:mm:ss tt", "MM/d/yyyy h:mm:ss tt", "MM/dd/yyyy h:mm:ss tt", "M/dd/yyyy h:mm:ss tt", "dd/MM/yyyy H:mm:ss tt", "dd/MM/yyyy h:mm:ss tt", "M/d/yyyy h:mm:ss tt" };
                                var formats2 = new string[] { "MM-dd-yyyy", "yyyyMMdd", "yyyy-MM-dd", "MM/dd/yyyy", "MM/dd/yyyy", "M/dd/yyyy", "MM/d/yyyy", "M/d/yyyy" };
                                IsDate = DateTime.TryParseExact(dataToadd, formats, null, DateTimeStyles.None, out dt);

                                DateTime dummyDt;
                                bool Isvalidentry = true;
                                Isvalidentry = !DateTime.TryParseExact(dataToadd, formats2, null, DateTimeStyles.None, out dummyDt);

                                bool IsName = (!IsDate && !IsAction && !IsInt);

                                if (IsName && Isvalidentry)
                                {
                                    try
                                    {
                                        empinfo = dataToadd;
                                        int nameIndex = dataToadd.IndexOf('(');
                                        int bioNoIndex = dataToadd.IndexOf(')');
                                        empname = dataToadd.Substring(0, nameIndex);
                                        bioID = GetSubstringByString(dataToadd);
                                    }
                                    catch
                                    {
                                       

                                    }
                                }
                                if (IsDate)
                                {
                                    datetime = FormatDateyyyy(dt);
                                    timeinout = dt.ToString("HH:mm:ss");
                                }
                                if (IsAction)
                                {
                                    if (dataToadd.Contains("In"))
                                        flag = "I";
                                    else
                                        flag = "O";

                                    DataRow dr = tempdb.NewRow();
                                    dr["EmpID"] = bioID;
                                    dr["EmpName"] = empname;
                                    dr["DateTime"] = datetime;
                                    dr["TimeIN_OUT"] = timeinout;
                                    dr["Flag"] = flag;
                                    tempdb.Rows.Add(dr);
                                }




                                texts.Add(pageContentReader.GetAttribute(UnicodeString));
                            }

                        }

                    }
                    //textLists.Add(texts);
                }
            }
            xpsDocument.Close();
            return tempdb;
        }

        public string GetSubstringByString(string c)
        {
            string a = "(";
            string b = ")";
            if (!c.Contains(a) || !c.Contains(b))
                return "";
            return c.Substring((c.IndexOf(a) + a.Length), (c.IndexOf(b) - c.IndexOf(a) - a.Length));
        }

        public string FormatDateyyyy(DateTime date)
        {
            DateTime dttemp = new DateTime();
            dttemp = date;
            string ret = dttemp.ToString("yyyy'-'MM'-'dd");
            return ret;
        }

        public string FormatDateyyyy(string strdate)
        {
            DateTime date = new DateTime();
            if (!DateTime.TryParse(strdate, out date))
                return "";
            return FormatDateyyyy(date);

        }
    }
}