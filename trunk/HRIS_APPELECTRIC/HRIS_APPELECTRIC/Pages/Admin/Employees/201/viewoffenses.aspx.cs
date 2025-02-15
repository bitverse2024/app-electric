﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace HRIS_APPELECTRIC.Pages.Admin.Employees._201
{
    public partial class viewoffenses : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Common cm = new Common();
        public string empno = "";
        string empviewURL = "";
        public int gridtotalcount = 0;
        public int gridtotalcount1 = 0;
        public string gridrangecount = "";
        public string gridrangecount1 = "";
        string getoffcode;
        string getrecdate;
        string getdates;
        string getedate;
        string getda;
        string getins;
        string getrems;
        public string numdays = "";
        string getrenderdtfrom = "", getrenderdtto = "", getspddays = "";
        public Dictionary<string, string> empInfo = new Dictionary<string, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["ROLES"].ToString() != "admin" && Session["ROLES"].ToString() != "employee")
            {
                Response.Redirect("~/Pages/Login.aspx");
            }
            empno = Request.QueryString["id"];
            empInfo = emp.GetEmployeeInfoDict(empno);
            //if (empno != Session["ACTIVE_EMPNO"].ToString())
            //{

            //    empno = Session["ACTIVE_EMPNO"].ToString();
            //    ScriptManager.RegisterStartupScript(this, this.GetType(),
            //    "alert",
            //    "alert('Injection not allowed!!!');window.location ='viewoffenses.aspx?id=" + empno + "';",
            //    true);
            //}
            if (!IsPostBack)
            {                
                refresh();
                refreshSuspension();
                OffCode.Items.AddRange(emp.GetDropDownMenuList("TBL_OFFENSES", "offense_desc","offense_key"));
                //OffCode.Items.AddRange(emp.GetDropDownMenuList("TBL_OFFENSES", "offense_desc"));
                upd_OffCode.Items.AddRange(emp.GetDropDownMenuList("TBL_OFFENSES", "offense_desc"));
                //upd_OffNo.Items.AddRange(emp.GetDropDownMenuList("TBL_OFFENSESTYPE", "offenseDesc"));
            }
        }
        void refresh()
        {
            //SchoolName.Items.AddRange(emp.GetDropDownMenuList("TBL_SCHOOL", "SchoolName"));
            //CourseName.Items.AddRange(emp.GetDropDownMenuList("TBL_COURSE", "CourseName"));
            DataTable dt = new DataTable();
            dt = emp.populateGridOffenses(empno);
            GridViewList.DataSource = dt;
            GridViewList.DataBind();
            ViewState["EMP_GRID"] = dt;
            ViewState["SORTDR"] = null;
            summary();          
            //disablesuspensiondays();
        }
        void refreshSuspension()
        {
            
            DataTable dt = new DataTable();
            dt = emp.populateGridSuspension(empno);
            GridViewListSuspension.DataSource = dt;
            GridViewListSuspension.DataBind();
            ViewState["EMP_GRID"] = dt;
            ViewState["SORTDR"] = null;
            summary1();
            //disablesuspensiondays();
        }

        public string getname()
        {
            string name = "";
            name = emp.GetEmployeeName(empno);

            return name;

        }
        void summary()
        {
            gridtotalcount = ((DataTable)ViewState["EMP_GRID"]).Rows.Count;
            int pageIndex = GridViewList.PageIndex;
            int c = (pageIndex > 0 ? 10 * pageIndex : 0) + GridViewList.Rows.Count;
            gridrangecount = (c > 0 ? c : 0) + " - " + gridtotalcount;
        }
        void summary1()
        {
            gridtotalcount1 = ((DataTable)ViewState["EMP_GRID"]).Rows.Count;
            int pageIndex = GridViewListSuspension.PageIndex;
            int c = (pageIndex > 0 ? 10 * pageIndex : 0) + GridViewListSuspension.Rows.Count;
            gridrangecount1 = (c > 0 ? c : 0) + " - " + gridtotalcount1;
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

                //GridViewList.DataSource = dt;
                //GridViewList.DataBind();
                //summary();


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
        public void openSetSuspension(string empNo)
        {
            UpdateSetSuspension.Update();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(string.Format(@"$('#{0}').modal('show')", "listmodalSetSuspension"));
            sb.Append(@"</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "listmodalSetSuspension", sb.ToString(), false);
            
        }
        public void closeSetSuspension()
        {
            UpdateSetSuspension.Update();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(string.Format(@"$('#{0}').modal('hide')", "listmodalSetSuspension"));
            sb.Append(@"</script>");

            ScriptManager.RegisterStartupScript(this, this.GetType(), "listmodalSetSuspension", sb.ToString(), false);

        }
        protected void lnkbtnXSetSuspension_Click(object sender, EventArgs e)
        {
            closeSetSuspension();
        }

        public void populateUpdateField(string id)
        {
            string bd = cm.GetSpecificDataFromDB("RecDate", "TBL_EOFFENSES", "where id = " + id + ""); ;
            string ed = cm.GetSpecificDataFromDB("EffectiveDate", "TBL_EOFFENSES", "where id = " + id + "");
            string offcode = cm.GetSpecificDataFromDB("OffCode", "TBL_EOFFENSES", "where id = " + id + "");
            //string offno = cm.GetSpecificDataFromDB("OffNo", "TBL_EOFFENSES", "where id = " + id + "");
            upd_OffCode.SelectedIndex = upd_OffCode.Items.IndexOf(upd_OffCode.Items.FindByText(cm.GetSpecificDataFromDB("OffCode", "TBL_EOFFENSES", "where id = " + id + "")));
            //upd_OffCode.SelectedItem.Text = cm.GetSpecificDataFromDB("OffCode", "TBL_EOFFENSES", "where id = '" + id + "'");
            upd_RecDate.Value = cm.FormatDateyyyy(bd);
            //upd_Eoffenses_Dates.Value = cm.GetSpecificDataFromDB("Dates", "TBL_EOFFENSES", "where id = " + id + "");
            // upd_EffectiveDate.Value = cm.FormatDate(ed);
            //upd_Eoffenses_DA.SelectedValue = cm.GetSpecificDataFromDB("DA", "TBL_EOFFENSES", "where id = " + id + "");
            //upd_Eoffenses_Inspector.SelectedValue = cm.GetSpecificDataFromDB("Inspector", "TBL_EOFFENSES", "where id = " + id + "");
            //upd_Eoffenses_DA.SelectedValue = cm.GetSpecificDataFromDB("DA", "TBL_EOFFENSES", "where id = " + id + "");

            upd_OffNo.Items.AddRange(emp.GetDropDownMenuOffenseType("TBL_OFFENSESTYPE", "offenseDesc", "where offenseKey = '" + upd_OffCode.SelectedValue + "'", "id"));
            upd_OffNo.SelectedValue = cm.GetSpecificDataFromDB("OffNo", "TBL_EOFFENSES", "where id = " + id + "");
            upd_Remarks.Value = cm.GetSpecificDataFromDB("Remarks", "TBL_EOFFENSES", "where id = " + id + "");
            upd_suspensionDays.Value = cm.GetSpecificDataFromDB("RemSuspDays", "TBL_EOFFENSES", "where id = " + id + "");
            


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
            vw_RecDate.Text = upd_RecDate.Value;
            vw_OffCode.Text = upd_OffCode.SelectedItem.ToString();
           // vw_Eoffenses_Dates.Value = upd_Eoffenses_Dates.Value;
            //vw_EffectiveDate.Value = upd_EffectiveDate.Value;
            //vw_Eoffenses_DA.Text = upd_Eoffenses_DA.SelectedValue;
            //vw_Eoffenses_Inspector.Value = upd_Eoffenses_Inspector.SelectedItem.ToString();
            vw_Remarks.Text = upd_Remarks.Value;
            vw_OffNo.Text = upd_OffNo.Text;
            vw_SuspensionDays.Text = upd_suspensionDays.Value;
        }
        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            //awong-retrieve textbox values from the grid control during runtime.
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
            string _Dates = ((TextBox)currentRow.FindControl("txtSearchRecDate")).Text;
            string _OffCode = ((TextBox)currentRow.FindControl("txtSearchOffNo")).Text;
            string _susdays = ((TextBox)currentRow.FindControl("txtSearchRemSuspDays")).Text;
            //string _Ins = ((TextBox)currentRow.FindControl("txtSearchInspector")).Text;
            //string _DA = ((TextBox)currentRow.FindControl("txtSearchDA")).Text;
            string expr = emp.build_or_like_param(saveSearchParam(_Dates, _OffCode, _susdays));

            //string expr = "and (C.SchoolName like '%" + _schoolcode + "%' or B.CourseName like '%" + _coursecode + "%' or A.IDate like '%" + _idate + "%' or A.Remarks like '%" + _remarks + "%')";
            //GridViewList.DataSource = emp.populateGridSearch((DataTable)ViewState["EMP_GRID"], expr);
            GridViewList.DataSource = emp.populateGridOffensesCol(empno, expr);
            GridViewList.DataBind();



        }
        protected void txtItemSuspension_TextChanged(object sender, EventArgs e)
        {
            //awong-retrieve textbox values from the grid control during runtime.
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
            string SpdDtFrom = ((TextBox)currentRow.FindControl("txtSearchrenderedDtFrom")).Text;
            string SpdDtTo = ((TextBox)currentRow.FindControl("txtSearchrenderedDtTo")).Text;
            string SpdDays = ((TextBox)currentRow.FindControl("txtSearchspdDays")).Text;
            
            string expr = emp.build_or_like_param(saveSearchParamSuspension(SpdDtFrom, SpdDtTo, SpdDays));

            //string expr = "and (C.SchoolName like '%" + _schoolcode + "%' or B.CourseName like '%" + _coursecode + "%' or A.IDate like '%" + _idate + "%' or A.Remarks like '%" + _remarks + "%')";
            //GridViewList.DataSource = emp.populateGridSearch((DataTable)ViewState["EMP_GRID"], expr);
            GridViewList.DataSource = emp.populateGridOffensesCol(empno, expr);
            GridViewList.DataBind();



        }

        Dictionary<string, string> saveSearchParam(string _Dates, string _OffCode, string _susdays)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();

            param.Add("A.RecDate", "'%" + _Dates + "%'");
            param.Add("B.offenseDesc", "'%" + _OffCode + "%'");
            param.Add("A.RemSuspDays", "'%" + _susdays + "%'");

            return param;


        }
        Dictionary<string, string> saveSearchParamSuspension(string SpdDtFrom, string SpdDtTo, string SpdDays)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();

            param.Add("renderedDtFrom", "'%" + SpdDtFrom + "%'");
            param.Add("renderedDtTo", "'%" + SpdDtTo + "%'");
            param.Add("spdDays", "'%" + SpdDays + "%'");
            
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
            if (e.CommandName == "printPDF")
            {
                string offenseNo = cm.GetSpecificDataFromDB("OffNo", "TBL_EOFFENSES", "where id =" + e.CommandArgument.ToString() + "");
                string offenseCode = cm.GetSpecificDataFromDB("OffCode", "TBL_EOFFENSES", "where id =" + e.CommandArgument.ToString() + "");
                ExportToPDFComp(offenseNo, offenseCode);

            }
            if (e.CommandName == "Reset")
            {
                refresh();

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
            if (e.CommandName == "del")
            {
                if (cm.ItemExist("TBL_SUSPENSION", "id", "where offenseid = '" + e.CommandArgument.ToString() + "'", ""))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Offense is used by other.');", true);
                    return;
                }
                getoffcode = cm.GetSpecificDataFromDB("OffCode", "TBL_EOFFENSES", "where id = " + e.CommandArgument.ToString() + "");
                emp.DeleteQuery("TBL_EOFFENSES", "where id =" + e.CommandArgument.ToString() + "");
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " removed Offense with OFFENSE: " + getoffcode + " for " + emp.GetEmployeeName(empno),
                                "DELETE", "OFFENSES", Session["EMP_ID"].ToString(), "DELETE", Session["EMP_ID"].ToString());
                refresh();
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Successfully Deleted');",
                true);

            }
            if(e.CommandName == "cmd_suspension")
            {
                HiddenFieldSuspension.Value = e.CommandArgument.ToString();
                openSetSuspension(empno);
            }
        }
        protected void GridViewListSuspension_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                string[] arg = new string[2];
                arg = e.CommandArgument.ToString().Split(',');
                string eID = arg[0];
                string eOffenseID = arg[1];
                string getremspd = cm.GetSpecificDataFromDB("RemSuspDays", "TBL_EOFFENSES", "where id = " + eOffenseID + "");
                getrenderdtfrom = cm.GetSpecificDataFromDB("renderedDtFrom", "TBL_SUSPENSION", "where id = " + eID + "");
                getrenderdtto = cm.GetSpecificDataFromDB("renderedDtTo", "TBL_SUSPENSION", "where id = " + eID + "");
                getspddays = cm.GetSpecificDataFromDB("spdDays", "TBL_SUSPENSION", "where id = " + eID + "");
                double total = Convert.ToDouble(getremspd.ToString()) + Convert.ToDouble(getspddays.ToString());
                emp.DeleteQuery("TBL_SUSPENSION", "where id =" + eID + "");
                updatespdremdays(eOffenseID, empno, total);
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " removed Suspension with SUSPENSION DATE FROM: " + getrenderdtfrom + "TO "+getrenderdtto+" FOR " + emp.GetEmployeeName(empno),
                                "DELETE", "x123", "qwg-23", "DELETE", Session["EMP_ID"].ToString());
                refresh();
                refreshSuspension();
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Successfully Deleted');",
                true);

            }
        }
        void updatespdremdays(string id,string empID, double total)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("RemSuspDays", "'" + total + "'");
            
            cm.UpdateQueryCommon(param, "TBL_EOFFENSES", " EmpID = '" + empID + "' and id = " + id + "");
        }
        protected void GridViewListSuspension_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewListSuspension.PageIndex = e.NewPageIndex;
            refreshSuspension();
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string i = OffCode.SelectedValue;
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if (emp.InsertQueryCommon(saveParam(), "TBL_EOFFENSES"))
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " created Offense with OFFENSE: " + OffCode.SelectedItem.Text + " for " + emp.GetEmployeeName(empno),
                                   "CREATE", "x123", "qwg-23", "CREATE", Session["EMP_ID"].ToString());
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Save !!!');", true);
                    refresh();
                    txtRecDate.Value = "";
                    OffCode.SelectedValue = "";
                    //txtEffectiveDate.Value = "";
                    //Eoffenses_Dates.Value = "";
                    //Eoffenses_DA.SelectedValue = "";
                    //Eoffenses_Inspector.SelectedValue = "0";
                    Remarks.Value = "";
                    
                    //suspensionDays.Value = "";
                }
            }
        }

        Dictionary<string, string> saveParam()
        {
            string getSuspensionDays = cm.GetSpecificDataFromDB("suspensionDay", "TBL_OFFENSESTYPE", "where id = " + OffNo.SelectedValue + "");
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("RecDate", "'" + txtRecDate.Value + "'");
            param.Add("OffCode", "'" + OffCode.SelectedValue + "'");
            //param.Add("EffectiveDate", "'" + txtEffectiveDate.Value + "'");
            // param.Add("Dates", "'" + Eoffenses_Dates.Value + "'");
            
            //param.Add("DA", "'" + Eoffenses_DA.SelectedValue + "'");
            //param.Add("Inspector", "'" + Eoffenses_Inspector.SelectedValue + "'");
            param.Add("Remarks", "'" + Remarks.Value + "'");
            param.Add("RemSuspDays", "'" + getSuspensionDays + "'");
            param.Add("OffNo", "'" + OffNo.SelectedValue + "'");
            

            param.Add("EmpID", "'" + empno + "'");

            return param;


        }
        Dictionary<string, string> saveUpdateParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("RecDate", "'" + upd_RecDate.Value + "'");
            param.Add("OffCode", "'" + upd_OffCode.SelectedItem + "'");
           // param.Add("Dates", "'" + upd_Eoffenses_Dates.Value + "'");
            //param.Add("DA", "'" + upd_Eoffenses_DA.SelectedValue + "'");
           // param.Add("Inspector", "'" + upd_Eoffenses_Inspector.SelectedValue + "'");
            param.Add("Remarks", "'" + upd_Remarks.Value + "'");
            param.Add("RemSuspDays", "'" + upd_suspensionDays.Value + "'");
            
            param.Add("OffNo", "'" + upd_OffNo.SelectedValue + "'");
            param.Add("EmpID", "'" + empno + "'");

            return param;


        }
        Dictionary<string, string> saveSuspensionParam(out Dictionary<string, string> emailparam,out string numday, out bool IsSuspensionCountAllowed)
        {
            IsSuspensionCountAllowed = true;
            numdays = getDays(SuspensionDtFrom.Value, SuspensionDtTo.Value, out IsSuspensionCountAllowed);
            numday = numdays;
            emailparam = new Dictionary<string, string>();
            
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("offenseid", "" + HiddenFieldSuspension.Value + "");
            param.Add("empid", "'" + empno + "'");
            param.Add("renderedDtFrom", "'" + SuspensionDtFrom.Value + "'");
            param.Add("renderedDtTo", "'" + SuspensionDtTo.Value + "'");
            param.Add("spdDays", "" + numday + "");


            return param;


        }
        string getDays(string dtfrom, string dtto, out bool IsEnoughSuspensionDays)
        {
            IsEnoughSuspensionDays = true;
            double count = 0;
            DateTime bussDtFrom = Convert.ToDateTime((dtfrom));
            DateTime bussDtTo = Convert.ToDateTime((dtto));
            string getallowed = cm.GetSpecificDataFromDB("RemSuspDays", "TBL_EOFFENSES", "where EmpID = '" + empno + "' and id = "+ HiddenFieldSuspension.Value+"");

            while (bussDtFrom <= bussDtTo)
            {
                if (bussDtFrom.DayOfWeek == DayOfWeek.Monday)
                {
                    if (empInfo["emp_Monday"].ToString() == "2")
                    {
                        count = count + 1;
                        
                    }
                }
                if (bussDtFrom.DayOfWeek == DayOfWeek.Tuesday)
                {
                    if (empInfo["emp_Tuesday"].ToString() == "2")
                    {
                        count = count + 1;
                    }
                }
                if (bussDtFrom.DayOfWeek == DayOfWeek.Wednesday)
                {
                    if (empInfo["emp_Wednesday"].ToString() == "2")
                    {
                        count = count + 1;
                    }
                }
                if (bussDtFrom.DayOfWeek == DayOfWeek.Thursday)
                {
                    if (empInfo["emp_Thursday"].ToString() == "2")
                    {
                        count = count + 1;
                    }
                }
                if (bussDtFrom.DayOfWeek == DayOfWeek.Friday)
                {
                    if (empInfo["emp_Friday"].ToString() == "2")
                    {
                        count = count + 1;
                    }
                }
                if (bussDtFrom.DayOfWeek == DayOfWeek.Saturday)
                {
                    if (empInfo["emp_Saturday"].ToString() == "2")
                    {
                        count = count + 1;
                    }
                }
                if (bussDtFrom.DayOfWeek == DayOfWeek.Sunday)
                {
                    if (empInfo["emp_Sunday"].ToString() == "2")
                    {
                        count = count + 1;
                    }
                }
                bussDtFrom = bussDtFrom.AddDays(1);
            }
            
            if (count > Convert.ToDouble(getallowed))
                IsEnoughSuspensionDays = false;

            return count.ToString();

        }


        protected void btnReset_Click(object sender, EventArgs e)
        {
            //List<string> aaaa= new List<string>();
            //foreach (var asd in OffCode.Items)
            //    aaaa.Add(asd.ToString());
            //    //ListBox1.Items.Add(asd.ToString());
            //Common cm = new Common();
            //cm.WriteToTextFile(aaaa, Server.MapPath("~/SampleText.txt"));

            //string da = "";
            //foreach (var asd in Eoffenses_DA.Items)
            //    da += da + "(\"" + asd + "\"),";
            txtRecDate.Value = "";
            OffCode.SelectedValue = "";
            //txtEffectiveDate.Value = "";
            //Eoffenses_Dates.Value = "";
            //Eoffenses_DA.SelectedValue = "";
            //Eoffenses_Inspector.SelectedValue = "0";
            Remarks.Value = "";

            refresh();
        }

        private void getdata()
        {
            getrecdate = cm.FormatDate(cm.GetSpecificDataFromDB("RecDate", "TBL_EOFFENSES", "where id = " + HiddenEmpID.Value + ""));
            getedate = cm.FormatDate(cm.GetSpecificDataFromDB("EffectiveDate", "TBL_EOFFENSES", "where id = " + HiddenEmpID.Value + ""));
            getoffcode = cm.GetSpecificDataFromDB("OffCode", "TBL_EOFFENSES", "where id = " + HiddenEmpID.Value + "");
            getdates = cm.GetSpecificDataFromDB("Dates", "TBL_EOFFENSES", "where id = " + HiddenEmpID.Value + "");
            getda = cm.GetSpecificDataFromDB("DA", "TBL_EOFFENSES", "where id = " + HiddenEmpID.Value + "");
            getins = cm.GetSpecificDataFromDB("Inspector", "TBL_EOFFENSES", "where id = " + HiddenEmpID.Value + "");
            getrems = cm.GetSpecificDataFromDB("Remarks", "TBL_EOFFENSES", "where id = " + HiddenEmpID.Value + "");
        }

        private void addlogs()
        {
            if (getrecdate != upd_RecDate.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Offense DATE ISSUED for " + emp.GetEmployeeName(empno) + " from " + getrecdate + " to " + upd_RecDate.Value,
                   "CHANGE", "OFFENSES", Session["EMP_ID"].ToString(), "OFFENSES", Session["EMP_ID"].ToString());
            }
            //if (getedate != upd_EffectiveDate.Value)
            //{
            //    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Offense EFFECTIVE DATE for " + emp.GetEmployeeName(empno) + " from " + getedate + " to " + upd_EffectiveDate.Value,
            //        "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            //}
            if (getoffcode != upd_OffCode.SelectedItem.Text)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Offense OFFENSE for " + emp.GetEmployeeName(empno) + " from " + getoffcode + " to " + upd_OffCode.SelectedItem.Text,
                   "CHANGE", "OFFENSES", Session["EMP_ID"].ToString(), "OFFENSES", Session["EMP_ID"].ToString());
            }
            //if (getdates != upd_Eoffenses_Dates.Value)
            //{
            //    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Offense DATE(S) OCCURED for " + emp.GetEmployeeName(empno) + " from " + getdates + " to " + upd_Eoffenses_Dates.Value,
            //        "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            //}
            //if (getda != upd_Eoffenses_DA.SelectedItem.Text)
            //{
            //    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Offense DISCIPLINARY ACTION for " + emp.GetEmployeeName(empno) + " from " + getda + " to " + upd_Eoffenses_DA.SelectedItem.Text,
            //       "CHANGE", "OFFENSES", Session["EMP_ID"].ToString(), "OFFENSES", Session["EMP_ID"].ToString());
            //}
            //if (getins != upd_Eoffenses_Inspector.SelectedValue)
            //{
            //    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Offense REPORTED BY for " + emp.GetEmployeeName(empno) + " from " + getins + " to " + upd_Eoffenses_Inspector.SelectedValue,
            //       "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            //}
            if (getrems != upd_Remarks.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Offense REMARKS for " + emp.GetEmployeeName(empno) + " from " + getrems + " to " + upd_Remarks.Value,
                  "CHANGE", "OFFENSES", Session["EMP_ID"].ToString(), "OFFENSES", Session["EMP_ID"].ToString());
            }
        }

        protected void btnsaveUpdate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                getdata();
                if (cm.UpdateQueryCommon(saveUpdateParam(), "TBL_EOFFENSES", "id = '" + HiddenEmpID.Value + "'"))
                {
                    addlogs();
                    refresh();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully updated !!!');", true);
                    closeTransDetails();
                    refresh();
                    upd_RecDate.Value = "";
                    upd_OffCode.SelectedValue = "";
                    //upd_EffectiveDate.Value = "";
                    //upd_Eoffenses_Dates.Value = "";
                    //upd_Eoffenses_DA.SelectedValue = "";
                    upd_OffNo.SelectedIndex = 0;
                    upd_suspensionDays.Value = "";
                    //upd_Eoffenses_Inspector.SelectedValue = "0";
                    upd_Remarks.Value = "";
                }
            }
        }
        protected void btnSetSuspension_Click(object sender, EventArgs e)
        {
            
            DateTime bussDtFrom = Convert.ToDateTime(SuspensionDtFrom.Value);
            DateTime bussDtTo = Convert.ToDateTime(SuspensionDtTo.Value);
            DateTime datetoday = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Taipei Standard Time");
            double dayscount1 = 0;
            double remainingsuspension = 0;
            double getallowed1 = 0;

            Dictionary<string, string> emailparam = new Dictionary<string, string>();
            Dictionary<string, string> param = new Dictionary<string, string>();
            string dayscount = "";
            bool IsSuspensionCountAllowed = true;
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if ((bussDtTo >= bussDtFrom))
                {
                    //getdata();
                    param = saveSuspensionParam(out emailparam, out dayscount, out IsSuspensionCountAllowed);
                    if (!IsSuspensionCountAllowed)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Remaining suspension days is not enough.');", true);
                        return;
                    }
                    else
                    {
                        string getallowed = cm.GetSpecificDataFromDB("RemSuspDays", "TBL_EOFFENSES", "where EmpID = " + empno + " and id = " + HiddenFieldSuspension.Value + "");
                        dayscount1 = Convert.ToDouble(dayscount);
                        getallowed1 = Convert.ToDouble(getallowed);
                        remainingsuspension = getallowed1 - dayscount1;
                        if (cm.UpdateQueryCommon("RemSuspDays", remainingsuspension.ToString(), "TBL_EOFFENSES", "id = " + HiddenFieldSuspension.Value + " AND EmpID = '" + empno + "'"))
                        {
                            if(cm.InsertQueryCommon(param,"TBL_SUSPENSION"))
                            {
                                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Suspension applied.');", true);
                                refreshSuspension();
                                refresh();
                            }
                           
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Remaining suspension days in not enough.');", true);

                        }


                    }
                } 

            }
        }
        protected void OffenseDesc_SelectedIndexChanged(object sender, EventArgs e)
        {
            OffNo.Items.Clear();
            OffNo.Items.AddRange(emp.GetDropDownMenuOffenseType("TBL_OFFENSESTYPE", "offenseDesc","where offenseKey = '"+ OffCode.SelectedValue+ "'","id"));
            
        }

        void ExportToPDFComp(string offenseNo, string offenseCode)
        {
            #region declarations
            string imagepath = Server.MapPath("../../../../images");
            string dept = emp.GetEmployeeDeptName(empno);
            string comp = cm.GetSpecificDataFromDB("emp_Assignment", "TBL_EMPLOYEE_MASTER", "where emp_EmpID ='" + empno + "'");
            string stroffNo = cm.GetSpecificDataFromDB("offenseDesc", "TBL_OFFENSESTYPE", "where id =" + offenseNo + "");
            string stroffCode = cm.GetSpecificDataFromDB("offense_desc", "TBL_OFFENSES", "where offense_key = '" + offenseCode + "'");
            string stroffCodedetailed = cm.GetSpecificDataFromDB("offense_detaileddesc", "TBL_OFFENSES", "where offense_key = '" + offenseCode + "'");
            
            #endregion
            Response.ContentType = "application/pdf";

            Response.AddHeader("content-disposition",

                "attachment;filename=\"" + getname() + "\"Offense.pdf");


            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            Document pdfDoc = new Document(PageSize.LETTER, 50f, 50f, 50f, 0f);

            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);


            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

            pdfDoc.Open();
            //var font = new Font(Font.HELVETICA, Font.DEFAULTSIZE, Font.BOLD);
            BaseFont font = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            Font f1 = new Font(font, Font.DEFAULTSIZE, 0, BaseColor.BLACK);
            PdfPTable table = new PdfPTable(1);
            table.WidthPercentage = 100;

            PdfPCell cellimg1 = new PdfPCell();
            iTextSharp.text.Image img;
            if (comp == "1")
            {
                img = iTextSharp.text.Image.GetInstance(imagepath + "/9757-app_header.jpg");
                cellimg1 = new PdfPCell(img, true);
            }
            if (comp == "2")
            {
                img = iTextSharp.text.Image.GetInstance(imagepath + "/wais.png");
                cellimg1 = new PdfPCell(img, true);
            }
            if (comp == "3")
            {
                img = iTextSharp.text.Image.GetInstance(imagepath + "/m2b.png");
                cellimg1 = new PdfPCell(img, true);
            }
            cellimg1.BorderWidth = 0;
            cellimg1.FixedHeight = 100;
            cellimg1.HorizontalAlignment = Element.ALIGN_CENTER;
            cellimg1.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.AddCell(cellimg1);

            Paragraph p0 = new Paragraph();
            Chunk chunk0 = new Chunk("\n \n \n \nDate: " + DateTime.Now.ToLongDateString() + "\n");
            Chunk chunk1 = new Chunk("Name of Employee: " + getname() + "\n");
            Chunk chunk2 = new Chunk("Designation/Department: " + dept + "\n \n \n");
            Chunk chunk3 = new Chunk("Dear: " + getname() + "\n \n \n");
            Chunk chunk4 = new Chunk("LETTER OF EXPLANATION");
            //Chunk chunk5 = new Chunk(" \n \n \n It has come to our attention that you have committed the following act(s) of misconduct on _________________:\n \n \n");
            Chunk chunk5 = new Chunk(" \n \n \n It has come to our attention that you have committed the following act(s) of misconduct on \n " + stroffNo + ":\n \n \n");
            Chunk chunk6 = new Chunk("Rule "+ offenseCode + "."+ stroffCode + " – ");
            Chunk chunk7 = new Chunk(""+ stroffCodedetailed + " \n \n \n");
            Chunk chunk8 = new Chunk("You are hereby required to provide a written explanation for the allegations stated above on or before _________________ \n \n");
            Chunk chunk9 = new Chunk("Please take note that if your explanation is not received within 7 days from receipt of this memo, the management will assume that " +
                "you are guilty of said allegations and have no explanation to offer in your defense. \n \n \n");
            Chunk chunk10 = new Chunk("Sincrely, \n \n \n");
            Chunk chunk11 = new Chunk("_____________________ \n");
            Chunk chunk12 = new Chunk("Arielle Ong");
            chunk4.SetUnderline(1f, 0f);
            chunk4.Font = f1;
            chunk6.Font = f1;
            p0.Add(chunk0);
            p0.Add(chunk1);
            p0.Add(chunk2);
            p0.Add(chunk3);
            p0.Add(chunk4);
            p0.Add(chunk5);
            p0.Add(chunk6);
            p0.Add(chunk7);
            p0.Add(chunk8);
            p0.Add(chunk9);
            p0.Add(chunk10);
            p0.Add(chunk11);
            p0.Add(chunk12);
            PdfPCell cell1 = new PdfPCell(p0);
            cell1.BorderWidth = 0;
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            table.AddCell(cell1);

            pdfDoc.Add(table);

            pdfDoc.Close();

            Response.Write(pdfDoc);

            cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " exported COE to PDF File",
                "EXPORT", "x123", "qwg-23", "EXPORT", Session["EMP_ID"].ToString());

            Response.End();
        }

        void disablesuspensiondays()
        {
            //RequiredFieldValidator10.Enabled = false;
            //lblsuspensionDays.Visible = false;
            //lblsuspensionDays.Disabled = true;
            //suspensionDays.Disabled = true;
            //suspensionDays.Visible = false;

        }
        void enablesuspensiondays()
        {
            //RequiredFieldValidator10.Enabled = true;
            //lblsuspensionDays.Visible = true;
            //lblsuspensionDays.Disabled = false;
            //suspensionDays.Disabled = false;
            //suspensionDays.Visible = true;

        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("content-disposition", "attachment;filename= Offense" + empno + ".xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Charset = "";
            this.EnableViewState = false;

            System.IO.StringWriter swriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlwriter = new System.Web.UI.HtmlTextWriter(swriter);

            DataGrid dg = new DataGrid();
            dg.DataSource = emp.populateGridOffenses(empno);
            dg.DataBind();

            dg.RenderControl(htmlwriter);


            Response.Write(swriter.ToString());
            cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " exported Offenses",
            "EXPORT", "EMPLOYEE", Session["EMP_ID"].ToString(), "EMPLOYEE", Session["EMP_ID"].ToString());
            Response.End();
            //exportTOxlsx();


        }
    }
}