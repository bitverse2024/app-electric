using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HRIS_APPELECTRIC.Pages.Admin.Employees._201
{
    public partial class viewmovement : System.Web.UI.Page
    {
        public Employee emp = new Employee();
        public Common cm = new Common();
        public string empno = "";
        string empviewURL = "";
        public int gridtotalcount = 0;
        public string gridrangecount = "";
        string movetype;
        string effectdate;
        string branchcd;
        string rems;
        string dept;
        string pos;
        string payclass;
        string wage;
        string groupc;
        string divcode;
        Dictionary<string, string> userinfo = new Dictionary<string, string>();
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
                "alert('Injection not allowed!!!');window.location ='viewmovement.aspx?id=" + empno + "';",
                true);
            }
            if (!IsPostBack)
            {
                refresh();
                populateMenus();

            }

        }
        public string getname()
        {
            string name = "";
            name = emp.GetEmployeeName(empno);

            return name;
        }

        protected void MovementType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RequiredFieldValidator13.Enabled = false;
            if (Movement_MovementTypeCode.SelectedValue == "2")
            {
                RequiredFieldValidator13.Enabled = true;
            }
        }
        protected void GridViewList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
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
                string num = emp.GetEmployeeMovementName(e.CommandArgument.ToString());
                movetype = cm.GetSpecificDataFromDB("MovementTypeName", "TBL_MOVEMENTTYPE", "where id = " + num + "");
                emp.DeleteQuery("TBL_MOVEMENT", "where id =" + e.CommandArgument.ToString() + "");
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " removed Movement " + movetype + " for " + emp.GetEmployeeName(empno), "DELETE", "x123", "qwg-23", "DELETE", Session["EMP_ID"].ToString());
                refresh();
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Successfully Deleted');",
                true);

            }
        }
        protected void GridViewList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewList.PageIndex = e.NewPageIndex;
            refresh();
        }
        void refresh()
        {
            DataTable dt = new DataTable();
            dt = emp.populateGridMovement(empno);
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

                //GridViewList.DataSource = dt;
                //GridViewList.DataBind();
                //summary();

            }

        }
        protected void txtItem_TextChanged(object sender, EventArgs e)

        {
            //awong-retrieve textbox values from the grid control during runtime.
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
            string MovementTypeCode = ((TextBox)currentRow.FindControl("txtMovementTypeCode")).Text;
            string BranchCode = ((TextBox)currentRow.FindControl("txtBranchCode")).Text;
            string PositionCode = ((TextBox)currentRow.FindControl("txtPositionCode")).Text;
            string EffectiveDate = ((TextBox)currentRow.FindControl("txtEffectiveDate")).Text;
            string Remarks = ((TextBox)currentRow.FindControl("txtRemarks")).Text;
            string expr = emp.build_or_like_param(saveSearchParam(MovementTypeCode, BranchCode, PositionCode, EffectiveDate, Remarks));
            //string expr = "and (license_type like '%" + lictype + "%' or license_no like '%" + licno + "%' or lic_expirydate like '%" + licdate + "%')";
            //GridViewList.DataSource = emp.populateGridSearch((DataTable)ViewState["EMP_GRID"], expr);

            GridViewList.DataSource = emp.populateGridMovementCol(empno, expr);
            GridViewList.DataBind();



        }
        Dictionary<string, string> saveSearchParam(string MovementTypeCode, string BranchCode, string PositionCode, string EffectiveDate, string Remarks)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("MovementTypeName", "'%" + MovementTypeCode + "%'");
            param.Add("CoName", "'%" + BranchCode + "%'");
            param.Add("PositionName", "'%" + PositionCode + "%'");
            param.Add("EffectiveDate", "'%" + EffectiveDate + "%'");
            param.Add("Remarks", "'%" + Remarks + "%'");


            return param;


        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {

                if (emp.InsertQueryCommon(saveParam(), "TBL_MOVEMENT"))
                {
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " created Movement " + Movement_MovementTypeCode.SelectedItem.Text + " for " + emp.GetEmployeeName(empno), "CREATE", "x123", "qwg-23", "CREATE", Session["EMP_ID"].ToString());
                    Reset();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Save !!!');", true);
                    refresh();
                }
            }

        }
        void populateMenus()
        {

            //Employee_AssignmentCode
            Movement_PayClassCode.Items.AddRange(emp.GetDropDownMenuList("TBL_PAYCLASS", "PayClassName"));
            Movement_DeptCode.Items.AddRange(emp.GetDropDownMenuList("TBL_DEPARTMENT", "DeptName"));
            Movement_MovementTypeCode.Items.AddRange(emp.GetDropDownMenuList("TBL_MOVEMENTTYPE", "MovementTypeName"));
            Movement_BranchCode.Items.AddRange(emp.GetDropDownMenuList("TBL_COMPANY", "CoName"));
            Movement_PositionCode.Items.AddRange(emp.GetDropDownMenuList("TBL_POSITION", "PositionName"));
            Movement_GroupCode.Items.AddRange(emp.GetDropDownMenuList("TBL_LOCATION", "LocationName"));
            Movement_DivisionCode.Items.AddRange(emp.GetDropDownMenuList("TBL_DIVISION", "DivName"));

            upd_PayClassCode.Items.AddRange(emp.GetDropDownMenuList("TBL_PAYCLASS", "PayClassName"));
            upd_DeptCode.Items.AddRange(emp.GetDropDownMenuList("TBL_DEPARTMENT", "DeptName"));
            upd_MovementTypeCode.Items.AddRange(emp.GetDropDownMenuList("TBL_MOVEMENTTYPE", "MovementTypeName"));
            upd_BranchCode.Items.AddRange(emp.GetDropDownMenuList("TBL_COMPANY", "CoName"));
            upd_PositionCode.Items.AddRange(emp.GetDropDownMenuList("TBL_POSITION", "PositionName"));
            upd_GroupCode.Items.AddRange(emp.GetDropDownMenuList("TBL_LOCATION", "LocationName"));
            upd_DivisionCode.Items.AddRange(emp.GetDropDownMenuList("TBL_DIVISION", "DivName"));



        }
        public void populateUpdateField(string id)
        {
            upd_MovementTypeCode.Value = emp.GetEmployeeMovementName(id);
            upd_EffectiveDate.Value = cm.FormatDate(cm.GetSpecificDataFromDB("EffectiveDate", "TBL_MOVEMENT", "where id = " + id + ""));
            upd_BranchCode.Value = emp.GetEmployeeBranchName(id);
            upd_Remarks.Value = cm.GetSpecificDataFromDB("Remarks", "TBL_MOVEMENT", "where id = " + id + "");
            upd_DeptCode.Value = emp.GetEmployeeMovementDeptName(id);
            upd_PositionCode.Value = emp.GetEmployeeMovementPositionName(id);
            upd_PayClassCode.Value = emp.GetEmployeeMovementPayClassName(id);
            upd_WageType.Value = cm.GetSpecificDataFromDB("WageType", "TBL_MOVEMENT", "where id = " + id + "");
            upd_GroupCode.Value = emp.GetEmployeeMovementLocationName(id);
            upd_DivisionCode.Value = emp.GetEmployeeMovementDivisionName(id);
        }

        public void populateViewField(string id)
        {
            //view_MovementTypeCode.Value = emp.GetEmployeeMovementName(id);
            //view_EffectiveDate.Value = cm.FormatDate(cm.GetSpecificDataFromDB("EffectiveDate", "TBL_MOVEMENT", "where id = " + id + ""));
            //view_BranchCode.Value = emp.GetEmployeeBranchName(id);
            //view_Remarks.Value = cm.GetSpecificDataFromDB("Remarks", "TBL_MOVEMENT", "where id = " + id + "");
            //view_DeptCode.Value = emp.GetEmployeeMovementDeptName(id);
            //view_PositionCode.Value = emp.GetEmployeeMovementPositionName(id);
            //view_PayClassCode.Value = emp.GetEmployeeMovementPayClassName(id);
            //view_WageType.Value = cm.GetSpecificDataFromDB("WageType", "TBL_MOVEMENT", "where id = " + id + "");
            //view_GroupCode.Value = emp.GetEmployeeMovementLocationName(id);
            //view_DivisionCode.Value = emp.GetEmployeeMovementDivisionName(id);

            lblMovementTypeCode.Value = upd_MovementTypeCode.Items[upd_MovementTypeCode.SelectedIndex].Text;
            view_EffectiveDate.Value = upd_EffectiveDate.Value;
            lblBranchCode.Value = upd_BranchCode.Items[upd_BranchCode.SelectedIndex].Text;
            lblRemarks.Value = upd_Remarks.Value;
            lblDeptCode.Value = upd_DeptCode.Items[upd_DeptCode.SelectedIndex].Text;
            lblPositionCode.Value = upd_PositionCode.Items[upd_PositionCode.SelectedIndex].Text;
            lblPayClass.Value = upd_PayClassCode.Items[upd_PayClassCode.SelectedIndex].Text;
            lblWageType.Value = upd_WageType.Value;
            lblGroupCode.Value = upd_GroupCode.Items[upd_GroupCode.SelectedIndex].Text;
            lblDivisionCode.Value = upd_DivisionCode.Items[upd_DivisionCode.SelectedIndex].Text;




        }

        Dictionary<string, string> saveParam()
        {

            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("EmpID", "'" + empno + "'");
            param.Add("MovementTypeCode", "'" + Movement_MovementTypeCode.SelectedValue + "'");
            param.Add("BranchCode", "'" + Movement_BranchCode.Value + "'");
            param.Add("DeptCode", "'" + Movement_DeptCode.Value + "'");
            param.Add("PayClassCode", "'" + Movement_PayClassCode.Value + "'");
            param.Add("GroupCode", "'" + Movement_GroupCode.Value + "'");
            param.Add("DivisionCode", "'" + Movement_DivisionCode.Value + "'");
            param.Add("EffectiveDate", "'" + txtEffectiveDate.Value + "'");
            param.Add("Remarks", "'" + Movement_Remarks.Value + "'");
            param.Add("PositionCode", "'" + Movement_PositionCode.Value + "'");
            param.Add("WageType", "'" + Movement_WageType.Value + "'");

            return param;


        }
        void Reset()
        {
            Movement_MovementTypeCode.SelectedValue = "0";
            Movement_BranchCode.Value = "";
            Movement_DeptCode.Value = "";
            Movement_PayClassCode.Value = "";
            Movement_GroupCode.Value = "";
            Movement_DivisionCode.Value = "";

            txtEffectiveDate.Value = "";
            Movement_Remarks.Value = "";
            Movement_PositionCode.Value = "";
            Movement_WageType.Value = "";


        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
            //refresh();
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



        protected void lnkbtnXlist_Click(object sender, EventArgs e)
        {
            closeTransDetails();
        }

        Dictionary<string, string> saveUpdateParam(string MovementTypeCode, string BranchCode, string DeptCode, string PayClassCode, string GroupCode, string DivisionCode, string EffectiveDate, string Remarks, string PositionCode, string WageType)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("EmpID", "'" + empno + "'");
            param.Add("MovementTypeCode", "'" + upd_MovementTypeCode.Value + "'");
            param.Add("BranchCode", "'" + upd_BranchCode.Value + "'");
            param.Add("DeptCode", "'" + upd_DeptCode.Value + "'");
            param.Add("PayClassCode", "'" + upd_PayClassCode.Value + "'");
            param.Add("GroupCode", "'" + upd_GroupCode.Value + "'");
            param.Add("DivisionCode", "'" + upd_DivisionCode.Value + "'");
            param.Add("EffectiveDate", "'" + upd_EffectiveDate.Value + "'");
            param.Add("Remarks", "'" + upd_Remarks.Value + "'");
            param.Add("PositionCode", "'" + upd_PositionCode.Value + "'");
            param.Add("WageType", "'" + upd_WageType.Value + "'");

            return param;


        }

        private void getdata()
        {
            movetype = emp.GetEmployeeMovementName(HiddenEmpID.Value);
            effectdate = cm.FormatDate(cm.GetSpecificDataFromDB("EffectiveDate", "TBL_MOVEMENT", "where id = " + HiddenEmpID.Value + ""));
            branchcd = emp.GetEmployeeBranchName(HiddenEmpID.Value);
            rems = cm.GetSpecificDataFromDB("Remarks", "TBL_MOVEMENT", "where id = " + HiddenEmpID.Value + "");
            dept = emp.GetEmployeeMovementDeptName(HiddenEmpID.Value);
            pos = emp.GetEmployeeMovementPositionName(HiddenEmpID.Value);
            payclass = emp.GetEmployeeMovementPayClassName(HiddenEmpID.Value);
            wage = cm.GetSpecificDataFromDB("WageType", "TBL_MOVEMENT", "where id = " + HiddenEmpID.Value + "");
            groupc = emp.GetEmployeeMovementLocationName(HiddenEmpID.Value);
            divcode = emp.GetEmployeeMovementDivisionName(HiddenEmpID.Value);
        }

        private void addlogs()
        {
            if (movetype != upd_MovementTypeCode.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Movement TYPE CODE for " + emp.GetEmployeeName(empno) + " from " + movetype + " to " + upd_MovementTypeCode.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (effectdate != upd_EffectiveDate.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Movement EFFECTIVE DATE for " + emp.GetEmployeeName(empno) + " from " + effectdate + " to " + upd_EffectiveDate.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (branchcd != upd_BranchCode.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Movement ASSIGNMENT for " + emp.GetEmployeeName(empno) + " from " + branchcd + " to " + upd_BranchCode.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (rems != upd_Remarks.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Movement REASON for " + emp.GetEmployeeName(empno) + " from " + rems + " to " + upd_Remarks.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (dept != upd_DeptCode.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Movement DEPT CODE for " + emp.GetEmployeeName(empno) + " from " + dept + " to " + upd_DeptCode.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (pos != upd_PositionCode.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Movement POSITION for " + emp.GetEmployeeName(empno) + " from " + pos + " to " + upd_PositionCode.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (payclass != upd_PayClassCode.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Movement PAY CLASS CODE for " + emp.GetEmployeeName(empno) + " from " + payclass + " to " + upd_PayClassCode.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (wage != upd_WageType.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Movement WAGE TYPE for " + emp.GetEmployeeName(empno) + " from " + wage + " to " + upd_WageType.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (groupc != upd_GroupCode.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Movement LOCATION for " + emp.GetEmployeeName(empno) + " from " + groupc + " to " + upd_GroupCode.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
            if (divcode != upd_DivisionCode.Value)
            {
                cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " changed Movement DIVISION CODE for " + emp.GetEmployeeName(empno) + " from " + divcode + " to " + upd_DivisionCode.Value,
                    "CHANGE", "x123", "qwg-23", "CHANGE", Session["EMP_ID"].ToString());
            }
        }

        protected void btnsaveUpdate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                getdata();
                if (upd_MovementTypeCode.Value != "" && upd_EffectiveDate.Value != "" && upd_BranchCode.Value != "" && upd_PositionCode.Value != "")
                {
                    addlogs();
                    cm.UpdateQueryCommon(saveUpdateParam(upd_MovementTypeCode.Value, upd_BranchCode.Value, upd_DeptCode.Value, upd_PayClassCode.Value, upd_GroupCode.Value,
                        upd_DivisionCode.Value, upd_EffectiveDate.Value, upd_Remarks.Value, upd_PositionCode.Value, upd_WageType.Value), "TBL_MOVEMENT", "id = " + HiddenEmpID.Value + "");
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

        public void closeTransDetailsView()
        {
            upListDetails2.Update();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(string.Format(@"$('#{0}').modal('hide')", "ViewModal"));
            sb.Append(@"</script>");

            ScriptManager.RegisterStartupScript(this, this.GetType(), "ViewModal", sb.ToString(), false);

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
            //db_Emp.getUserInfo(empNo, out username, out fullname, out email, out roles);

            //upd_CompanyName.Value = "";

            //TODO dapat fullname to


            //db_Emp.getEmployeeInfo(empNo, out fname, out mname, out lname);
            ////txtbox_fname.Text = fname;
            ////txtbox_mname.Text = mname;
            ////txtbox_lname.Text = lname;




        }



        protected void lnkbtnXlistView_Click(object sender, EventArgs e)
        {
            closeTransDetailsView();
        }
    }
}