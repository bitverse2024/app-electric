using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HRIS_APPELECTRIC.Pages.Admin
{
    public partial class userview : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Common cm = new Common();
        User user = new User();
        public string empno = "";
        public string empid = "";
        public int gridtotalcount = 0;
        public string gridrangecount = "";
        public string newpwd = "";
        public string newpwdSha1MD5 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            empno = Request.QueryString["empid"];
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
            dt = user.populateGridUser(empno);
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
        Dictionary<string, string> saveParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("password", "'" + newpwdSha1MD5 + "'");
            param.Add("datecreatep", "'" + DateTime.Now.Date + "'");
            return param;
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            empid = Session["ACTIVE_EMPNO"].ToString();
            newpwd = "password";
            newpwdSha1MD5 = user.GetSha1(user.MD5Hash(newpwd));

            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if (cm.UpdateQueryCommon(saveParam(), "TBL_USERS", "empid = '" + empid + "'"))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Password Changed');", true);

                }
            }
        }
    }
}