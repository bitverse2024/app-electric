using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin.PayrollPages
{
    public partial class contributions : System.Web.UI.Page
    {
        Employee db = new Employee();
        User dbUser = new User();
        Common cm = new Common();
        Timekeeping tk = new Timekeeping();
        string contrimonth = "", contriyear = "", contripaygroup = "", contriemp = "";
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
            ddlPayrollGroup.Items.AddRange(db.GetDropDownMenuList("TBL_PAYROLLGRP", "payrollgrpname"));
            ddlEmp.Items.AddRange(db.GetDropDownMenuList("TBL_EMPLOYEE_MASTER", "emp_FullName","emp_EmpID"));
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

                GridContributionList.DataSource = dt;
                GridContributionList.DataBind();
                //summary();

            }

        }

        protected void GridContributionList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sort")
            {
                sort_grid(e.CommandArgument.ToString());

            }
        }

        protected void GridContributionList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridContributionList.PageIndex = e.NewPageIndex;
            refresh();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            contrimonth = ddlMonth.SelectedValue;
            contriyear = ddlYear.SelectedValue;
            contripaygroup = ddlPayrollGroup.SelectedValue;
            contriemp = ddlEmp.SelectedValue;
            DataTable dt = new DataTable();
            dt = tk.populateGridContributionCol(contrimonth, contriyear, contripaygroup, contriemp);
            GridContributionList.DataSource = dt;
            GridContributionList.DataBind();
            ViewState["EMP_GRID"] = dt;
            ViewState["SORTDR"] = null;
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataGrid dg = new DataGrid();
            
            contrimonth = ddlMonth.SelectedValue;
            contriyear = ddlYear.SelectedValue;
            contripaygroup = ddlPayrollGroup.SelectedValue;
            contriemp = ddlEmp.SelectedValue;
            dg.DataSource = tk.populateGridContributionCol(contrimonth, contriyear, contripaygroup, contriemp);
            dg.DataBind();
            if (dg.Items.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("content-disposition", "attachment;filename= Contribution Summary.xls");
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