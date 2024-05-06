using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HRIS_APPELECTRIC.Pages.Admin.Employees._201
{
    public partial class viewtraining : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Common cm = new Common();
        public string empno = "";
        string empviewURL = "";
        public int gridtotalcount = 0;
        public string gridrangecount = "";
        string gettrainingcode, getdatetaken, gettopic, getvenue, getcost, 
            gethours, getspeaker, getsource, getrems;
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
                "alert('Injection not allowed!!!');window.location ='viewtraining.aspx?id=" + empno + "';",
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
            dt = emp.populateGridTraining(empno);
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
            string s_trainingcode = ((TextBox)currentRow.FindControl("txtSearchTrainingCode")).Text;
            string s_topic = ((TextBox)currentRow.FindControl("txtSearchTopic")).Text;
            string s_date = ((TextBox)currentRow.FindControl("txtSearchDateTaken")).Text;
            string s_speaker = ((TextBox)currentRow.FindControl("txtSearchSpeaker")).Text;
            string s_remarks = ((TextBox)currentRow.FindControl("txtSearchRemarks")).Text;

            string expr = emp.build_or_like_param(saveSearchParam(s_trainingcode, s_topic, s_date, s_speaker, s_remarks));
            //string expr = "and (license_type like '%" + lictype + "%' or license_no like '%" + licno + "%' or lic_expirydate like '%" + licdate + "%')";
            //GridViewList.DataSource = emp.populateGridSearch((DataTable)ViewState["EMP_GRID"], expr);
            GridViewList.DataSource = emp.populateGridTrainingCol(empno, expr);
            GridViewList.DataBind();



        }
        Dictionary<string, string> saveSearchParam(string s_trainingcode, string s_topic, string s_date, string s_speaker, string s_remarks)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add(TrainingCode.ID, "'%" + s_trainingcode + "%'");
            param.Add("DateTaken", "'%" + s_date + "%'");
            param.Add(Topic.ID, "'%" + s_topic + "%'");
            param.Add(Speaker.ID, "'%" + s_speaker + "%'");
            param.Add(Remarks.ID, "'%" + s_remarks + "%'");

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
                gettrainingcode = cm.GetSpecificDataFromDB("TrainingCode", "TBL_TRAINING", "where id = " + e.CommandArgument.ToString() + "");
                emp.DeleteQuery("TBL_TRAINING", "where id =" + e.CommandArgument.ToString() + "");
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " removed Training with TRAINING CODE " + gettrainingcode + " for " + emp.GetEmployeeName(empno),
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
            string bd = cm.GetSpecificDataFromDB("DateTaken", "TBL_TRAINING", "where id = " + id + ""); ;
            upd_TrainingCode.Value = cm.GetSpecificDataFromDB("TrainingCode", "TBL_TRAINING", "where id = " + id + "");
            upd_DateTaken.Value = cm.FormatDate(bd);
            upd_Topic.Value = cm.GetSpecificDataFromDB("Topic", "TBL_TRAINING", "where id = " + id + "");
            upd_Venue.Value = cm.GetSpecificDataFromDB("Venue", "TBL_TRAINING", "where id = " + id + "");
            upd_Cost.Value = cm.GetSpecificDataFromDB("Cost", "TBL_TRAINING", "where id = " + id + "");
            upd_TrainingHours.Value = cm.GetSpecificDataFromDB("TrainingHours", "TBL_TRAINING", "where id = " + id + "");
            upd_Speaker.Value = cm.GetSpecificDataFromDB("Speaker", "TBL_TRAINING", "where id = " + id + "");
            upd_TSource.Value = cm.GetSpecificDataFromDB("TSource", "TBL_TRAINING", "where id = " + id + "");
            upd_Remarks.Value = cm.GetSpecificDataFromDB("Remarks", "TBL_TRAINING", "where id = " + id + "");
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
            vw_TrainingCode.Value = upd_TrainingCode.Value;
            vw_DateTaken.Value = upd_DateTaken.Value;
            vw_Topic.Value = upd_Topic.Value;
            vw_Venue.Value = upd_Venue.Value;
            vw_Cost.Value = upd_Cost.Value;
            vw_TrainingHours.Value = upd_TrainingHours.Value;
            vw_Speaker.Value = upd_Speaker.Value;
            vw_TSource.Value = upd_TSource.Value;
            vw_Remarks.Value = upd_Remarks.Value;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if (emp.InsertQueryCommon(saveParam(), "TBL_TRAINING"))
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " created Training with TRAINING CODE " + TrainingCode.Value + " for " + emp.GetEmployeeName(empno),
                                    "CREATE", "x123", "qwg-23", "CREATE", Session["EMP_ID"].ToString());
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Save !!!');", true);
                    refresh();
                }
                TrainingCode.Value = "";
                txtDateTaken.Value = "";
                Topic.Value = "";
                Venue.Value = "";
                Cost.Value = "";
                TrainingHours.Value = "";
                Speaker.Value = "";
                TSource.Value = "";
                Remarks.Value = "";
            }
        }

        Dictionary<string, string> saveParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add(TrainingCode.ID, "'" + TrainingCode.Value + "'");
            param.Add("DateTaken", "'" + txtDateTaken.Value + "'");
            param.Add(Topic.ID, "'" + Topic.Value + "'");
            param.Add(Venue.ID, "'" + Venue.Value + "'");
            param.Add(Cost.ID, "" + Cost.Value + "");
            param.Add(TrainingHours.ID, "" + TrainingHours.Value + "");
            param.Add(Speaker.ID, "'" + Speaker.Value + "'");
            param.Add(TSource.ID, "'" + TSource.Value + "'");
            param.Add(Remarks.ID, "'" + Remarks.Value + "'");
            param.Add("EmpID", "'" + empno + "'");
            return param;
        }

        Dictionary<string, string> saveUpdateParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add(TrainingCode.ID, "'" + upd_TrainingCode.Value + "'");
            param.Add("DateTaken", "'" + upd_DateTaken.Value + "'");
            param.Add(Topic.ID, "'" + upd_Topic.Value + "'");
            param.Add(Venue.ID, "'" + upd_Venue.Value + "'");
            param.Add(Cost.ID, "" + upd_Cost.Value + "");
            param.Add(TrainingHours.ID, "" + upd_TrainingHours.Value + "");
            param.Add(Speaker.ID, "'" + upd_Speaker.Value + "'");
            param.Add(TSource.ID, "'" + upd_TSource.Value + "'");
            param.Add(Remarks.ID, "'" + upd_Remarks.Value + "'");
            param.Add("EmpID", "'" + empno + "'");
            return param;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            TrainingCode.Value = "";
            txtDateTaken.Value = "";
            Topic.Value = "";
            Venue.Value = "";
            Cost.Value = "";
            TrainingHours.Value = "";
            Speaker.Value = "";
            TSource.Value = "";
            Remarks.Value = "";
            refresh();
        }

        private void getdata()
        {
            gettrainingcode = cm.GetSpecificDataFromDB("TrainingCode", "TBL_TRAINING", "where id = " + HiddenEmpID.Value + "");
            getdatetaken = cm.FormatDate(cm.GetSpecificDataFromDB("DateTaken", "TBL_TRAINING", "where id = " + HiddenEmpID.Value + ""));
            gettopic = cm.GetSpecificDataFromDB("Topic", "TBL_TRAINING", "where id = " + HiddenEmpID.Value + "");
            getvenue = cm.GetSpecificDataFromDB("Venue", "TBL_TRAINING", "where id = " + HiddenEmpID.Value + "");
            getcost = cm.GetSpecificDataFromDB("Cost", "TBL_TRAINING", "where id = " + HiddenEmpID.Value + "");
            gethours = cm.GetSpecificDataFromDB("TrainingHours", "TBL_TRAINING", "where id = " + HiddenEmpID.Value + "");
            getspeaker = cm.GetSpecificDataFromDB("Speaker", "TBL_TRAINING", "where id = " + HiddenEmpID.Value + "");
            getsource = cm.GetSpecificDataFromDB("TSource", "TBL_TRAINING", "where id = " + HiddenEmpID.Value + "");
            getrems = cm.GetSpecificDataFromDB("Remarks", "TBL_TRAINING", "where id = " + HiddenEmpID.Value + "");
        }

        private void addlogs()
        {
            if (gettrainingcode != upd_TrainingCode.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Training TRAINING CODES for " + emp.GetEmployeeName(empno) + " from " + gettrainingcode + " to " + upd_TrainingCode.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getdatetaken != upd_DateTaken.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Training DATE TAKEN for " + emp.GetEmployeeName(empno) + " from " + getdatetaken + " to " + upd_DateTaken.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (gettopic != upd_Topic.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Training TOPIC for " + emp.GetEmployeeName(empno) + " from " + gettopic + " to " + upd_Topic.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getvenue != upd_Venue.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Training VENUE for " + emp.GetEmployeeName(empno) + " from " + getvenue + " to " + upd_Venue.Value,
                   "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getcost != upd_Cost.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Training TOPIC for " + emp.GetEmployeeName(empno) + " from " + getcost + " to " + upd_Cost.Value,
                   "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (gethours != upd_TrainingHours.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Training HOURS for " + emp.GetEmployeeName(empno) + " from " + gethours + " to " + upd_TrainingHours.Value,
                   "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getspeaker != upd_Speaker.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Training SPEAKER for " + emp.GetEmployeeName(empno) + " from " + getspeaker + " to " + upd_Speaker.Value,
                  "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getsource != upd_TSource.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Training HOURS for " + emp.GetEmployeeName(empno) + " from " + gethours + " to " + upd_TrainingHours.Value,
                  "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (getrems != upd_Remarks.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Training REMARKS for " + emp.GetEmployeeName(empno) + " from " + getrems + " to " + upd_Remarks.Value,
                  "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
        }

        protected void btnsaveUpdate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                getdata();
                if (cm.UpdateQueryCommon(saveUpdateParam(), "TBL_TRAINING", "id = '" + HiddenEmpID.Value + "'"))
                {
                    addlogs();
                    refresh();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully updated !!!');", true);
                    closeTransDetails();
                    refresh();
                }
            }
        }
    }
}