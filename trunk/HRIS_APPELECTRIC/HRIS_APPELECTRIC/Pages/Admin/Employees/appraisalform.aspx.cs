using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin.Employees
{
    public partial class appraisalform : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Common cm = new Common();
        public string empno = "";
        public int gridtotalcount = 0;
        public string gridrangecount = "";
        Dictionary<string, string> empInfo = new Dictionary<string, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            empno = Request.QueryString["empid"];
            empInfo = emp.GetEmployeeInfoDict(empno);
        }
        public string getname()
        {
            string name = "";
            name = emp.GetEmployeeName(empno);

            return name;

        }
        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
        }

        protected void GridViewList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
        }
        protected void GridViewList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {

        }
        protected void btnReset_Click(object sender, EventArgs e)
        {

        }
    }
}