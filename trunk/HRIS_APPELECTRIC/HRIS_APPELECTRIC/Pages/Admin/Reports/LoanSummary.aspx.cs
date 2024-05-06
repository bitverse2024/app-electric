using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin.Reports
{
    public partial class LoanSummary : System.Web.UI.Page
    {
        Employee db = new Employee();
        User dbUser = new User();
        Common cm = new Common();
        Timekeeping tk = new Timekeeping();
        string loanmonth = "", loanyear = "", loancompany = "", loanemp = "", loantype = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                refresh();
            }
        }
        void refresh()
        {
            int year = DateTime.Now.Year;
            for (int i = year - 5; i <= year + 5; i++)
            {
                ListItem li = new ListItem(i.ToString());
                ddlYear.Items.Add(li);
            }
            ddlYear.Items.FindByText(year.ToString()).Selected = true;
            ddlCompany.Items.AddRange(db.GetDropDownMenuList("TBL_COMPANY", "CoName", "id", "order by CoName asc"));
            ddlEmp.Items.AddRange(db.GetDropDownMenuList("TBL_EMPLOYEE_MASTER", "emp_FullName", "emp_EmpID", "ORDER BY emp_FullName ASC"));
            ddlLoanType.Items.AddRange(db.GetDropDownMenuList("TBL_LOANS", "LoanDesc", "LoanID", "ORDER BY LoanDesc ASC"));
        }
        protected void GridContributionList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridContributionList.PageIndex = e.NewPageIndex;
            refresh();
        }
        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    loantype = ddlLoanType.SelectedValue;
        //    loanmonth = ddlMonth.SelectedValue;
        //    loanyear = ddlYear.SelectedValue;
        //    loancompany = ddlCompany.SelectedValue;
        //    loanemp = ddlEmp.SelectedValue;
        //    GridContributionList.DataSource = tk.populateGridContributionCol(loanmonth, loanyear, loancompany, loanemp);
        //    GridContributionList.DataBind();
        //}
        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataGrid dg = new DataGrid();
            loantype = ddlLoanType.SelectedValue;
            loanmonth = ddlMonth.SelectedValue;
            loanyear = ddlYear.SelectedValue;
            loancompany = ddlCompany.SelectedValue;
            loanemp = ddlEmp.SelectedValue;
            dg.DataSource = tk.populateLoanReportExport(loanmonth, loanyear, loancompany, loanemp, loantype);
            dg.DataBind();
            if (dg.Items.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("content-disposition", "attachment;filename= LoanSummary" + cm.dtnow() + ".xls");
                Response.ContentType = "application/vnd.ms-excel";
                Response.Charset = "";
                this.EnableViewState = false;
                System.IO.StringWriter swriter = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlwriter = new System.Web.UI.HtmlTextWriter(swriter);
                dg.RenderControl(htmlwriter);
                Response.Write(swriter.ToString());
                Response.End();

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(),
               "alert",
               "alert('No data to export!!!');",
               true);
            }
        }
    }
}