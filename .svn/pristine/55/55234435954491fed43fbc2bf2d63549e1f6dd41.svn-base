using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HRIS_APPELECTRIC.Pages.Admin.Employees
{
    public partial class viewloans : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Timekeeping tk = new Timekeeping();
        Common cm = new Common();
        public string empno = "";
        public int gridtotalcount = 0;
        public string gridrangecount = "";
        public Dictionary<string, string> empInfo = new Dictionary<string, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            empno = Session["EMP_ID"].ToString();
            empInfo = emp.GetEmployeeInfoDict(empno);
            if (!IsPostBack)
            {
                refresh();
            }
        }

        void refresh()
        {
            DataTable dt = new DataTable(); //GridForApproval

            dt = emp.populateGridLoans(empno);
            GridViewList.DataSource = dt;
            GridViewList.DataBind();
            ViewState["EMP_GRID1"] = dt;
            ViewState["SORTDR_1"] = null;
            summary();
        }
        public string getname()
        {
            string name = "";
            name = emp.GetEmployeeName(empno);

            return name;
        }
        void summary()
        {
            gridtotalcount = ((DataTable)ViewState["EMP_GRID1"]).Rows.Count;
            int pageIndex = GridViewList.PageIndex;
            int c = (pageIndex > 0 ? 10 * pageIndex : 0) + GridViewList.Rows.Count;
            gridrangecount = (c > 0 ? c : 0) + " - " + gridtotalcount;
        }
        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            //awong-retrieve textbox values from the grid control during runtime.
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
            string LoanCode = ((TextBox)currentRow.FindControl("txtLoanCode")).Text;
            string DedStart = ((TextBox)currentRow.FindControl("txtDedStart")).Text;
            string LoanAmount = ((TextBox)currentRow.FindControl("txtLoanAmount")).Text;
            string AmountPaid = ((TextBox)currentRow.FindControl("txtAmountPaid")).Text;
            string Balance = ((TextBox)currentRow.FindControl("txtBalance")).Text;
            string DedAmount = ((TextBox)currentRow.FindControl("txtDedAmount")).Text;
            string expr = emp.build_or_like_param(saveSearchParam(LoanCode, DedStart, LoanAmount, AmountPaid, Balance, DedAmount));
            //string expr = "and (license_type like '%" + lictype + "%' or license_no like '%" + licno + "%' or lic_expirydate like '%" + licdate + "%')";
            //GridViewList.DataSource = emp.populateGridSearch((DataTable)ViewState["EMP_GRID"], expr);

            GridViewList.DataSource = emp.populateGridLoansCol(empno, expr);
            GridViewList.DataBind();



        }
        Dictionary<string, string> saveSearchParam(string LoanCode, string DedStart, string LoanAmount, string AmountPaid, string Balance, string DedAmount)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("LoanDesc", "'%" + LoanCode + "%'");
            param.Add("DedStart", "'%" + DedStart + "%'");
            param.Add("AmountOfLoan", "'%" + LoanAmount + "%'");
            param.Add("AmountPaid", "'%" + AmountPaid + "%'");
            param.Add("Balance", "'%" + Balance + "%'");
            param.Add("DedAmount", "'%" + DedAmount + "%'");


            return param;


        }
        protected void GridViewList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewList.PageIndex = e.NewPageIndex;
            refresh();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("content-disposition", "attachment;filename= Loans" + empno + ".xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Charset = "";
            this.EnableViewState = false;

            System.IO.StringWriter swriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlwriter = new System.Web.UI.HtmlTextWriter(swriter);

            DataGrid dg = new DataGrid();
            dg.DataSource = emp.populateGridLoans(empno);
            dg.DataBind();

            dg.RenderControl(htmlwriter);


            Response.Write(swriter.ToString());
            cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " exported Loans",
            "EXPORT", "EMMPLOYEE", Session["EMP_ID"].ToString(), "EMPLOYEE", Session["EMP_ID"].ToString());
            Response.End();
            //exportTOxlsx();


        }
    }
}