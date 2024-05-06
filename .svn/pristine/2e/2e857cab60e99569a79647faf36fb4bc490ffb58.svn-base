using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace HRIS_APPELECTRIC.Pages.Admin.Employees._201
{
    public partial class viewmedical : System.Web.UI.Page
    {
        Common cm = new Common();
        Employee emp = new Employee();
        public string empno = "";
        string empviewURL = "";
        public int gridtotalcount = 0;
        public string gridrangecount = "";
        string getxray, getcbc, geturi, getfec, getecg, getdt, getbt, getpreg, gethepb, getrefdate, getdiagnosis,
            getrems, getfulln, getfile;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ROLES"].ToString() != "admin" && Session["ROLES"].ToString() != "employee")
            {
                Response.Redirect("~/Pages/Login.aspx");
            }
            empno = Request.QueryString["id"];
            if (empno != Session["ACTIVE_EMPNO"].ToString())
            {

                empno = Session["ACTIVE_EMPNO"].ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Injection not allowed!!!');window.location ='viewmedical.aspx?id=" + empno + "';",
                true);
            }
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
            dt = emp.populateGridMedical(empno);
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
            string _RefDate = ((TextBox)currentRow.FindControl("txtSearchRefDate")).Text;
            string _Diagnosis = ((TextBox)currentRow.FindControl("txtSearchDiagnosis")).Text;
            string _FName = ((TextBox)currentRow.FindControl("txtSearchFName")).Text;
            string expr = emp.build_or_like_param(saveSearchParam(_RefDate, _Diagnosis, _FName));
            //string expr = "and (license_type like '%" + lictype + "%' or license_no like '%" + licno + "%' or lic_expirydate like '%" + licdate + "%')";
            //GridViewList.DataSource = emp.populateGridSearch((DataTable)ViewState["EMP_GRID"], expr);
            GridViewList.DataSource = emp.populateGridMedicalCol(empno, expr);
            GridViewList.DataBind();



        }

        Dictionary<string, string> saveSearchParam(string _RefDate, string _Diagnosis, string _FName)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("RefDate", "'%" + _RefDate + "%'");
            param.Add(Diagnosis.ID, "'%" + _Diagnosis + "%'");
            param.Add(FName.ID, "'%" + _FName + "%'");



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
            if (e.CommandName == "dl")
            {
                string fulldirectory = Server.MapPath(emp.file201folder);
                fulldirectory += @"MEDICAL\";
                string filename = emp.GetSpecificData("FilePath", "TBL_MEDICAL", "where id = " + e.CommandArgument + "");
                fulldirectory += filename;
                FileInfo file = new FileInfo(fulldirectory);

                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + file.Name + "");
                Response.TransmitFile(file.FullName);
                Response.End();
            }
            if (e.CommandName == "view")
            {
                HiddenEmpID.Value = e.CommandArgument.ToString();
                populateUpdateField(e.CommandArgument.ToString());
                populateViewField(e.CommandArgument.ToString());
                openTransDetailsView(empno);

            }
            if (e.CommandName == "upd")
            {
                HiddenEmpID.Value = e.CommandArgument.ToString();
                populateUpdateField(e.CommandArgument.ToString());
                openTransDetails(empno);
            }
            if (e.CommandName == "Reset")
            {
                refresh();

            }
            if (e.CommandName == "del")
            {
                getfile = cm.GetSpecificDataFromDB("FilePath", "TBL_MEDICAL", "where id = " + e.CommandArgument.ToString() + "");
                emp.DeleteQuery("TBL_MEDICAL", "where id =" + e.CommandArgument.ToString() + "");
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " removed Medical with FILE NAME: " + getfile + " for " + emp.GetEmployeeName(empno),
                                "DELETE", "x123", "qwg-23", "DELETE", Session["EMP_ID"].ToString());
                refresh();
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Successfully Deleted');",
                true);

            }
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

        public void populateUpdateField(string id)
        {
            getxray = cm.GetSpecificDataFromDB("Xray", "TBL_MEDICAL", "where id = " + id + "");
            getcbc = cm.GetSpecificDataFromDB("CBC", "TBL_MEDICAL", "where id = " + id + "");
            geturi = cm.GetSpecificDataFromDB("Urinalysis", "TBL_MEDICAL", "where id = " + id + "");
            getfec = cm.GetSpecificDataFromDB("Fecalysis", "TBL_MEDICAL", "where id = " + id + "");
            getecg = cm.GetSpecificDataFromDB("ECG", "TBL_MEDICAL", "where id = " + id + "");
            getdt = cm.GetSpecificDataFromDB("DrugTest", "TBL_MEDICAL", "where id = " + id + "");
            getbt = cm.GetSpecificDataFromDB("BloodType", "TBL_MEDICAL", "where id = " + id + "");
            getpreg = cm.GetSpecificDataFromDB("Pregnancy", "TBL_MEDICAL", "where id = " + id + "");
            gethepb = cm.GetSpecificDataFromDB("HepaB", "TBL_MEDICAL", "where id = " + id + "");
            upd_RefDate.Value = cm.FormatDate(cm.GetSpecificDataFromDB("RefDate", "TBL_MEDICAL", "where id = " + id + ""));
            upd_Diagnosis.Value = cm.GetSpecificDataFromDB("Diagnosis", "TBL_MEDICAL", "where id = " + id + "");
            upd_Remarks.Value = cm.GetSpecificDataFromDB("Remarks", "TBL_MEDICAL", "where id = " + id + "");
            upd_FName.Value = cm.GetSpecificDataFromDB("FName", "TBL_MEDICAL", "where id = " + id + "");
            if (getxray == "Y")
            {
                upd_Xray.Checked = true;
            }
            if (getcbc == "Y")
            {
                upd_CBC.Checked = true;
            }
            if (geturi == "Y")
            {
                upd_Urinalysis.Checked = true;
            }
            if (getfec == "Y")
            {
                upd_Fecalysis.Checked = true;
            }
            if (getecg == "Y")
            {
                upd_ECG.Checked = true;
            }
            if (getdt == "Y")
            {
                upd_DrugTest.Checked = true;
            }
            if (getbt == "Y")
            {
                upd_BloodType.Checked = true;
            }
            if (getpreg == "Y")
            {
                upd_Pregnancy.Checked = true;
            }
            if (gethepb == "Y")
            {
                upd_HepaB.Checked = true;
            }
        }
        protected void lnkbtnXlist_Click(object sender, EventArgs e)
        {
            closeTransDetails();
        }
        public void openTransDetailsView(string empNo)
        {
            upListDetails2.Update();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(string.Format(@"$('#{0}').modal('show')", "ViewModal"));
            sb.Append(@"</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ViewModal", sb.ToString(), false);
            string divname = "";

        }
        public void closeTransDetailsView()
        {
            upListDetails2.Update();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(string.Format(@"$('#{0}').modal('hide')", "ViewModal"));
            sb.Append(@"</script>");

            ScriptManager.RegisterStartupScript(this, this.GetType(), "ViewModal", sb.ToString(), false);

        }
        protected void lnkbtnXlistView_Click(object sender, EventArgs e)
        {
            closeTransDetailsView();
        }
        public void populateViewField(string id)
        {
            vw_RefDate.Value = upd_RefDate.Value;
            vw_Diagnosis.Value = upd_Diagnosis.Value;
            vw_FName.Value = upd_FName.Value;
            vw_Remarks.Value = upd_Remarks.Value;
            vw_FilePath.Value = cm.GetSpecificDataFromDB("FilePath", "TBL_MEDICAL", "where id = " + id + "");
            if (upd_Xray.Checked == true)
            {
                vw_Xray.Checked = true;
            }
            if (upd_CBC.Checked == true)
            {
                vw_CBC.Checked = true;
            }
            if (upd_Urinalysis.Checked == true)
            {
                vw_Urinalysis.Checked = true;
            }
            if (upd_Fecalysis.Checked == true)
            {
                vw_Fecalysis.Checked = true;
            }
            if (upd_ECG.Checked == true)
            {
                vw_ECG.Checked = true;
            }
            if (upd_DrugTest.Checked == true)
            {
                vw_DrugTest.Checked = true;
            }
            if (upd_BloodType.Checked == true)
            {
                vw_BloodType.Checked = true;
            }
            if (upd_Pregnancy.Checked == true)
            {
                vw_Pregnancy.Checked = true;
            }
            if (upd_HepaB.Checked == true)
            {
                vw_HepaB.Checked = true;
            }

        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                string filename = "";
                if (uploadFile(out filename))
                {
                    if (emp.InsertQueryCommon(saveParam(filename), "TBL_MEDICAL"))
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Save !!!');", true);
                        cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " created MEDICAL with FILE NAME: " + filename + " for " + emp.GetEmployeeName(empno),
                                        "CREATE", "x123", "qwg-23", "CREATE", Session["EMP_ID"].ToString());
                        refresh();
                    }
                    txtRefDate.Value = "";
                    Diagnosis.Value = "";
                    Remarks.Value = "";
                    FName.Value = "";
                    Xray.Checked = false;
                    CBC.Checked = false;
                    Urinalysis.Checked = false;
                    Fecalysis.Checked = false;
                    ECG.Checked = false;
                    DrugTest.Checked = false;
                    BloodType.Checked = false;
                    Pregnancy.Checked = false;
                    HepaB.Checked = false;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Failed to save file !!!');", true);
                    refresh();

                }
            }
        }

        Dictionary<string, string> saveParam(string filename)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("RefDate", "'" + txtRefDate.Value + "'");
            param.Add(Diagnosis.ID, "'" + Diagnosis.Value + "'");
            param.Add(Remarks.ID, "'" + Remarks.Value + "'");
            param.Add(FName.ID, "'" + FName.Value + "'");
            param.Add(Xray.ID, (Xray.Checked ? "'Y'" : "'N'"));
            param.Add(CBC.ID, (CBC.Checked ? "'Y'" : "'N'"));
            param.Add(Urinalysis.ID, (Urinalysis.Checked ? "'Y'" : "'N'"));
            param.Add(Fecalysis.ID, (Fecalysis.Checked ? "'Y'" : "'N'"));
            param.Add(ECG.ID, (ECG.Checked ? "'Y'" : "'N'"));
            param.Add(DrugTest.ID, (DrugTest.Checked ? "'Y'" : "'N'"));
            param.Add(BloodType.ID, (BloodType.Checked ? "'Y'" : "'N'"));
            param.Add(Pregnancy.ID, (Pregnancy.Checked ? "'Y'" : "'N'"));
            param.Add(HepaB.ID, (HepaB.Checked ? "'Y'" : "'N'"));
            param.Add("FilePath", "'" + filename + "'");

            param.Add("EmpID", "'" + empno + "'");


            return param;


        }
        Dictionary<string, string> saveUpdateParam(string filename1)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("RefDate", "'" + upd_RefDate.Value + "'");
            param.Add(Diagnosis.ID, "'" + upd_Diagnosis.Value + "'");
            param.Add(Remarks.ID, "'" + upd_Remarks.Value + "'");
            param.Add(FName.ID, "'" + upd_FName.Value + "'");
            param.Add(Xray.ID, (upd_Xray.Checked ? "'Y'" : "'N'"));
            param.Add(CBC.ID, (upd_CBC.Checked ? "'Y'" : "'N'"));
            param.Add(Urinalysis.ID, (upd_Urinalysis.Checked ? "'Y'" : "'N'"));
            param.Add(Fecalysis.ID, (upd_Fecalysis.Checked ? "'Y'" : "'N'"));
            param.Add(ECG.ID, (upd_ECG.Checked ? "'Y'" : "'N'"));
            param.Add(DrugTest.ID, (upd_DrugTest.Checked ? "'Y'" : "'N'"));
            param.Add(BloodType.ID, (upd_BloodType.Checked ? "'Y'" : "'N'"));
            param.Add(Pregnancy.ID, (upd_Pregnancy.Checked ? "'Y'" : "'N'"));
            param.Add(HepaB.ID, (upd_HepaB.Checked ? "'Y'" : "'N'"));
            if (filename1 != "")
            {
                param.Add("FilePath", "'" + filename1 + "'");
            }
            param.Add("EmpID", "'" + empno + "'");


            return param;


        }
        bool uploadFile(out string filename)
        {
            filename = "";
            if (IsUploaded(out filename))
            {
                return true;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Failed to upload: " + filename + "');",
                true);
                return false;

            }
            return false;

        }
        bool uploadFile1(out string filename1)
        {
            filename1 = "";
            if (IsUploaded1(out filename1))
            {
                return true;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Failed to upload: " + filename1 + "');",
                true);
                return false;

            }
            return false;

        }
        bool IsUploaded(out string outfilename)
        {
            bool valid = true;
            outfilename = "";

            string fulldirectory = Server.MapPath(emp.file201folder);
            fulldirectory += @"MEDICAL\";
            if (!Directory.Exists(fulldirectory))
                Directory.CreateDirectory(fulldirectory);
            try
            {
                string filename = Path.GetFileName(fuUploader.PostedFile.FileName);
                string filextension = Path.GetExtension(fuUploader.PostedFile.FileName);
                //string fileURL = Page.ResolveUrl("~/201Files");
                //string fileToUpload = fulldirectory + filename;
                string fileToUpload = fulldirectory + empno + "_" + emp.GetNewID("id", "TBL_MEDICAL") + filextension;
                outfilename = Path.GetFileName(fileToUpload);
                if (!File.Exists(fileToUpload))
                    fuUploader.SaveAs(fileToUpload);
                else
                {
                    File.Delete(fileToUpload);
                    fuUploader.SaveAs(fileToUpload);

                    //valid = false;
                    //outfilename = filename + ":  Duplicate file name(s) are not allowed";
                }
            }
            catch (Exception ex)
            {
                valid = false;
                outfilename = outfilename + ":  " + ex.ToString();
            }
            return valid;


        }
        bool IsUploaded1(out string outfilename1)
        {
            bool valid = true;
            outfilename1 = "";

            string fulldirectory = Server.MapPath(emp.file201folder);
            fulldirectory += @"MEDICAL\";
            if (!Directory.Exists(fulldirectory))
                Directory.CreateDirectory(fulldirectory);
            try
            {
                string filename = Path.GetFileName(upd_fuUploader.PostedFile.FileName);
                string filextension = Path.GetExtension(upd_fuUploader.PostedFile.FileName);
                //string fileURL = Page.ResolveUrl("~/201Files");
                //string fileToUpload = fulldirectory + filename;
                string fileToUpload = fulldirectory + empno + "_" + emp.GetNewID("id", "TBL_MEDICAL") + filextension;
                outfilename1 = Path.GetFileName(fileToUpload);
                if (!File.Exists(fileToUpload))
                    upd_fuUploader.SaveAs(fileToUpload);
                else
                {
                    File.Delete(fileToUpload);
                    upd_fuUploader.SaveAs(fileToUpload);

                    //valid = false;
                    //outfilename = filename + ":  Duplicate file name(s) are not allowed";
                }
            }
            catch (Exception ex)
            {
                valid = false;
                outfilename1 = outfilename1 + ":  " + ex.ToString();
            }
            return valid;


        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtRefDate.Value = "";
            Diagnosis.Value = "";
            FName.Value = "";
            Remarks.Value = "";
            refresh();
        }

        private void getdata()
        {
            getxray = cm.GetSpecificDataFromDB("Xray", "TBL_MEDICAL", "where id = " + HiddenEmpID.Value + "");
            getcbc = cm.GetSpecificDataFromDB("CBC", "TBL_MEDICAL", "where id = " + HiddenEmpID.Value + "");
            geturi = cm.GetSpecificDataFromDB("Urinalysis", "TBL_MEDICAL", "where id = " + HiddenEmpID.Value + "");
            getfec = cm.GetSpecificDataFromDB("Fecalysis", "TBL_MEDICAL", "where id = " + HiddenEmpID.Value + "");
            getecg = cm.GetSpecificDataFromDB("ECG", "TBL_MEDICAL", "where id = " + HiddenEmpID.Value + "");
            getdt = cm.GetSpecificDataFromDB("DrugTest", "TBL_MEDICAL", "where id = " + HiddenEmpID.Value + "");
            getbt = cm.GetSpecificDataFromDB("BloodType", "TBL_MEDICAL", "where id = " + HiddenEmpID.Value + "");
            getpreg = cm.GetSpecificDataFromDB("Pregnancy", "TBL_MEDICAL", "where id = " + HiddenEmpID.Value + "");
            gethepb = cm.GetSpecificDataFromDB("HepaB", "TBL_MEDICAL", "where id = " + HiddenEmpID.Value + "");
            getrefdate = cm.GetSpecificDataFromDB("RefDate", "TBL_MEDICAL", "where id = " + HiddenEmpID.Value + "");
            getdiagnosis = cm.GetSpecificDataFromDB("Diagnosis", "TBL_MEDICAL", "where id = " + HiddenEmpID.Value + "");
            getrems = cm.GetSpecificDataFromDB("Remarks", "TBL_MEDICAL", "where id = " + HiddenEmpID.Value + "");
            getfulln = cm.GetSpecificDataFromDB("FName", "TBL_MEDICAL", "where id = " + HiddenEmpID.Value + "");
            getfile = cm.GetSpecificDataFromDB("FilePath", "TBL_MEDICAL", "where id = " + HiddenEmpID.Value + "");
        }

        private void addlogs(string filename1)
        {
            if (cm.FormatDate(getrefdate) != upd_RefDate.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Medical REF DATE for " + emp.GetEmployeeName(empno) + " from " + cm.FormatDate(getrefdate) + " to " + upd_RefDate.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getdiagnosis != upd_Diagnosis.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Medical DIAGNOSIS for " + emp.GetEmployeeName(empno) + " from " + getdiagnosis + " to " + upd_Diagnosis.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getrems != upd_Remarks.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Medical REMARKS for " + emp.GetEmployeeName(empno) + " from " + getrems + " to " + upd_Remarks.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getfulln != upd_FName.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Medical DIAGNOSIS for " + emp.GetEmployeeName(empno) + " from " + getfulln + " to " + upd_FName.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (upd_fuUploader.HasFile)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Medical FILE PATH for " + emp.GetEmployeeName(empno) + " from " + getfile + " to " + filename1,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getxray == "Y")
            {
                if (upd_Xray.Checked == false)
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Medical XRAY for " + emp.GetEmployeeName(empno) + " from " + getxray + " to N",
                        "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
                }
            }
            if (getxray == "N")
            {
                if (upd_Xray.Checked == true)
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Medical XRAY for " + emp.GetEmployeeName(empno) + " from " + getxray + " to Y",
                        "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
                }
            }
            if (getcbc == "Y")
            {
                if (upd_CBC.Checked == false)
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Medical CBC for " + emp.GetEmployeeName(empno) + " from " + getcbc + " to N",
                        "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
                }
            }
            if (getcbc == "N")
            {
                if (upd_CBC.Checked == true)
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Medical CBC for " + emp.GetEmployeeName(empno) + " from " + getcbc + " to Y",
                        "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
                }
            }
            if (geturi == "Y")
            {
                if (upd_Urinalysis.Checked == false)
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Medical URINALYSIS for " + emp.GetEmployeeName(empno) + " from " + geturi + " to N",
                        "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
                }
            }
            if (geturi == "N")
            {
                if (upd_Urinalysis.Checked == true)
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Medical URINALYSIS for " + emp.GetEmployeeName(empno) + " from " + geturi + " to Y",
                        "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
                }
            }
            if (getfec == "Y")
            {
                if (upd_Fecalysis.Checked == false)
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Medical FECALYSIS for " + emp.GetEmployeeName(empno) + " from " + getfec + " to N",
                        "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
                }
            }
            if (getfec == "N")
            {
                if (upd_Fecalysis.Checked == true)
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Medical FECALYSIS for " + emp.GetEmployeeName(empno) + " from " + getfec + " to Y",
                        "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
                }
            }
            if (getecg == "Y")
            {
                if (upd_ECG.Checked == false)
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Medical ECG for " + emp.GetEmployeeName(empno) + " from " + getecg + " to N",
                        "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
                }
            }
            if (getecg == "N")
            {
                if (upd_ECG.Checked == true)
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Medical ECG for " + emp.GetEmployeeName(empno) + " from " + getecg + " to Y",
                        "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
                }
            }
            if (getdt == "Y")
            {
                if (upd_DrugTest.Checked == false)
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Medical DRUG TEST for " + emp.GetEmployeeName(empno) + " from " + getdt + " to N",
                        "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
                }
            }
            if (getdt == "N")
            {
                if (upd_DrugTest.Checked == true)
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Medical DRUG TEST for " + emp.GetEmployeeName(empno) + " from " + getdt + " to Y",
                        "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
                }
            }
            if (getbt == "Y")
            {
                if (upd_BloodType.Checked == false)
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Medical BLOOD TEST for " + emp.GetEmployeeName(empno) + " from " + getbt + " to N",
                       "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
                }
            }
            if (getbt == "N")
            {
                if (upd_BloodType.Checked == true)
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Medical BLOOD TEST for " + emp.GetEmployeeName(empno) + " from " + getbt + " to Y",
                        "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
                }
            }
            if (getpreg == "Y")
            {
                if (upd_Pregnancy.Checked == false)
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Medical PREGNANCY TEST for " + emp.GetEmployeeName(empno) + " from " + getpreg + " to N",
                       "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
                }
            }
            if (getpreg == "N")
            {
                if (upd_Pregnancy.Checked == true)
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Medical PREGNANCY TEST for " + emp.GetEmployeeName(empno) + " from " + getpreg + " to Y",
                        "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
                }
            }
            if (gethepb == "Y")
            {
                if (upd_HepaB.Checked == false)
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Medical HEPA B TEST for " + emp.GetEmployeeName(empno) + " from " + gethepb + " to N",
                          "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
                }
            }
            if (gethepb == "N")
            {
                if (upd_HepaB.Checked == true)
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Medical HEPA B TEST for " + emp.GetEmployeeName(empno) + " from " + gethepb + " to Y",
                        "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
                }
            }
        }

        protected void btnsaveUpdate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                string filename1;
                if (uploadFile1(out filename1))
                {
                    getdata();
                    if (cm.UpdateQueryCommon(saveUpdateParam(filename1), "TBL_MEDICAL", "id = '" + HiddenEmpID.Value + "'"))
                    {
                        refresh();
                        addlogs(filename1);
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully updated !!!');", true);
                        closeTransDetails();
                        refresh();
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Failed to save file !!!');", true);
                    refresh();

                }
            }
        }
    }
}