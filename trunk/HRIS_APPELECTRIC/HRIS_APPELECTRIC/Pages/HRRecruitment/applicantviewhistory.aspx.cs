using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HRIS_APPELECTRIC.Pages.HRRecruitment
{
    public partial class applicantviewhistory : System.Web.UI.Page
    {
        public Timekeeping tk = new Timekeeping();
        public HR hr = new HR();
        public AdminLib admin = new AdminLib();
        public Employee emp = new Employee();
        public string applicantid = "";
        public Common cm = new Common();
        public string empno = "";
        public int gridtotalcount = 0;
        public string gridrangecount = "";
        string mrid = "", hrmrid = "", divid = "";
        public Dictionary<string, string> applicantInfo = new Dictionary<string, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            applicantid = Request.QueryString["id"];
            applicantInfo = cm.GetTableDict("TBL_APPLICANT", "where id = " + applicantid + "");
            mrid = Request.QueryString["mrid"]; hrmrid = Request.QueryString["hrmrid"]; divid = Request.QueryString["divid"];
            //Applicanthistory_reason.Value = DateTime.Now.ToString("yyyy-MM-dd");
            if (!IsPostBack)
            {
                if (Session["ROLES"].ToString() != "admin")
                {
                    Response.Redirect("~/Pages/Login.aspx");
                }
                populateMenus();

                refresh();
            }
        }
        void populateMenus()
        {

            //Employee_AssignmentCode

            Applicanthistory_PositionDesired.Items.AddRange(emp.GetDropDownMenuList("TBL_POSITION", "PositionName"));
            upd_ApplicationPositionDesired.Items.AddRange(emp.GetDropDownMenuList("TBL_POSITION", "PositionName"));


        }
        void refresh()
        {
            DataTable dt = new DataTable();
            dt = hr.populateGridHistory();
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
            string txtSearchDateReceived = ((TextBox)currentRow.FindControl("txtSearchDateReceived")).Text;
            string txtSearchaction = ((TextBox)currentRow.FindControl("txtSearchaction")).Text;
            string txtSearchRemarks = ((TextBox)currentRow.FindControl("txtSearchRemarks")).Text;


            string expr = hr.build_or_like_param(true, saveSearchParam(txtSearchDateReceived, txtSearchaction, txtSearchRemarks));
            //string expr = "and (license_type like '%" + lictype + "%' or license_no like '%" + licno + "%' or lic_expirydate like '%" + licdate + "%')";
            //GridViewList.DataSource = emp.populateGridSearch((DataTable)ViewState["EMP_GRID"], expr);
            GridViewList.DataSource = hr.populateGridHistoryCol(expr);
            GridViewList.DataBind();
        }

        Dictionary<string, string> saveSearchParam(string txtSearchDateReceived, string txtSearchaction, string txtSearchRemarks)
        {

            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("DateReceived", "'%" + txtSearchDateReceived + "%'");
            param.Add("action", "'%" + txtSearchaction + "%'");
            param.Add("reason", "'%" + txtSearchRemarks + "%'");



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
            if (e.CommandName == "upd")
            {
                HiddenID.Value = e.CommandArgument.ToString();
                populateUpdateField(e.CommandArgument.ToString());
                openTransDetails(empno);

            }
            if (e.CommandName == "del")
            {
                hr.DeleteQuery("TBL_APPLICANTHISTORY", "where id =" + e.CommandArgument.ToString() + "");
                refresh();
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Successfully Deleted');",
                true);

            }
        }

        Dictionary<string, string> saveParam()
        {
            //string text = Applicanthistory_PositionDesired.Items[Applicanthistory_PositionDesired.SelectedIndex].Text;
            //string text = upd_ApplicationPositionDesired.Items[upd_ApplicationPositionDesired.SelectedIndex].Text;
            //string posdesired = upd_ApplicationPositionDesired.SelectedIndex.ToString();
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("userid", applicantid);
            param.Add("mrid", applicantInfo["mrid"]);
            param.Add("hrmrid", applicantInfo["hrmrid"]);
            param.Add("division", applicantInfo["division"]);

            param.Add("PositionDesired", "'" + Applicanthistory_PositionDesired.Items[Applicanthistory_PositionDesired.SelectedIndex].Text + "'");
            param.Add("DateReceived", "'" + cm.FormatDate(DateTime.Now) + "'");
            param.Add("FullName", "'" + applicantInfo["FullName"] + "'");
            param.Add("reason", "'" + Applicanthistory_reason.Value + "'");
            param.Add("action", "'" + applicantInfo["FullName"] + " endorsed to the position " + Applicanthistory_PositionDesired.Items[Applicanthistory_PositionDesired.SelectedIndex].Text + "'");

            return param;
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (Applicanthistory_PositionDesired.Value != "")
            {

                if (hr.InsertQueryCommon(saveParam(), "TBL_APPLICANTHISTORY"))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Successfully Saved');window.location ='applicantviewhistory.aspx?id=" + applicantid + "';", true);

                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Wrong Input');window.location ='applicantviewhistory.aspx?id=" + applicantid + "';", true);
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Applicanthistory_PositionDesired.Value = "";
            Applicanthistory_reason.Value = "";
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
            //db_Emp.getUserInfo(empNo, out username, out fullname, out email, out roles);

            //upd_CompanyName.Value = "";

            //TODO dapat fullname to


            //db_Emp.getEmployeeInfo(empNo, out fname, out mname, out lname);
            ////txtbox_fname.Text = fname;
            ////txtbox_mname.Text = mname;
            ////txtbox_lname.Text = lname;




        }

        public void populateUpdateField(string id)
        {
            //upd_ApplicationPositionDesired.Value = cm.GetSpecificDataFromDB("PositionName", "TBL_POSITION");

            upd_Reason.Value = cm.GetSpecificDataFromDB("reason", "TBL_APPLICANTHISTORY", "where id = " + id + "");
            Applicanthistory_reason.Value = cm.GetSpecificDataFromDB("reason", "TBL_APPLICANTHISTORY", "where id = " + id + ""); ;
        }

        protected void lnkbtnXlist_Click(object sender, EventArgs e)
        {
            closeTransDetails();
        }

        Dictionary<string, string> saveUpdateParam(string PositionDesired, string reason)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("PositionDesired", "'" + PositionDesired + "'");
            param.Add("reason", "'" + reason + "'");





            return param;


        }

        protected void btnsaveUpdate_Click(object sender, EventArgs e)
        {
            //string text = upd_ApplicationPositionDesired.Items[upd_ApplicationPositionDesired.SelectedIndex].Text;
            if (upd_ApplicationPositionDesired.Value != "" && upd_Reason.Value != "")
            {
                cm.UpdateQueryCommon(saveUpdateParam(upd_ApplicationPositionDesired.Items[upd_ApplicationPositionDesired.SelectedIndex].Text, upd_Reason.Value), "TBL_APPLICANTHISTORY", "id = " + HiddenID.Value + "");
                refresh();
                //db_Emp.updateUserInfo(HiddenEmpID.Value, txtbox_username.Text, txtbox_password.Text, (drpdwn_acctstatus.SelectedValue == "1" ? true : false));
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully updated !!!');", true);
                closeTransDetails();
                refresh();
            }
            else
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Fields should not be empty !!!');", true);
        }
    }
}