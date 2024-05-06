using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin
{
    public partial class createhrmr : System.Web.UI.Page
    {
        Employee emp = new Employee();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ROLES"].ToString() != "admin")
                {
                    Response.Redirect("~/Pages/Login.aspx");
                }
                populateMenus();
            }
        }
        void populateMenus()
        {

            //Employee_AssignmentCode
            Hrmr_divisionCode.Items.AddRange(emp.GetDropDownMenuList("TBL_DIVISION", "DivName"));
            Hrmr_departmentCode.Items.AddRange(emp.GetDropDownMenuList("TBL_DEPARTMENT", "DeptName"));
            Hrmr_positionCode.Items.AddRange(emp.GetDropDownMenuList("TBL_POSITION", "PositionName"));




        }
        Dictionary<string, string> saveParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("DivCode", "" + Hrmr_divisionCode.Value + "");
            param.Add("DeptId", "" + Hrmr_departmentCode.Value + "");
            param.Add("PositionCode", "" + Hrmr_positionCode.Value + "");
            param.Add("startmonth", "'" + startmonth.Value + "'");
            param.Add("hrmr_status", "'request'");
            return param;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if (emp.InsertQueryCommon(saveParam(), "TBL_HRMR"))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('HRMR Successfully Save !!!');", true);

                }
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Hrmr_divisionCode.Value = "";
            Hrmr_departmentCode.Value = "";
            Hrmr_positionCode.Value = "";
            startmonth.Value = "";
        }
    }
}