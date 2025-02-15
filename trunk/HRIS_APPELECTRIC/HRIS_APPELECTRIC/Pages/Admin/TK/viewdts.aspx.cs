﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HRIS_APPELECTRIC.Pages.Admin.TK
{
    public partial class viewdts : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Timekeeping tk = new Timekeeping();
        Common cm = new Common();
        public string empno = "";
        string emp_PayrollGroup = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            empno = Request.QueryString["id"];
            Session["DTRActiveEmpID"] = empno;
            if (empno == null)
            {
                empno = Session["EMP_ID"].ToString();
                Session["DTRActiveEmpID"] = empno;

            }
            if (!IsPostBack)
            {
                emp_PayrollGroup = emp.GetEmployeePayrollGroup(Session["DTRActiveEmpID"].ToString());
                DTS_BussDate.Items.AddRange(emp.GetDropDownMenuListCutOffWherePayrollGroup(emp_PayrollGroup));

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
            DateTime dtFrom = new DateTime();
            DateTime dtTo = new DateTime();
            string codate = "";
            tk.getCutoffRange(DTS_BussDate.Value, out codate, out dtFrom, out dtTo);
            dt = tk.populateGridDTS(empno, DTS_BussDate.Value, dtFrom.ToString("yyyy-MM-dd"), dtTo.ToString("yyyy-MM-dd"));
            GridViewList.DataSource = dt;
            GridViewList.DataBind();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            refresh();
            lbl1HideShow.Visible = true;
            lblHideShow2.Visible = true;
            lblHideShow2.Text = DTS_BussDate.Items[DTS_BussDate.SelectedIndex].Text;
        }

        protected void OnDataBound(object sender, EventArgs e)
        {
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            TableHeaderCell cell = new TableHeaderCell();
            cell.Attributes.Add("style", "text-align:center;padding-left:80px;padding-right:80px;font-size:10px;");
            cell.Text = "EMPLOYEE NAME";
            cell.ColumnSpan = 1;
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.Attributes.Add("style", "text-align:center;padding-left:35px;padding-right:35px;font-size:10px;");
            cell.ColumnSpan = 1;
            cell.Text = "SHIFT";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.Attributes.Add("style", "text-align:center;font-size:10px;");
            cell.ColumnSpan = 1;
            cell.Text = "DATE";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.Attributes.Add("style", "text-align:center;font-size:10px;");
            cell.ColumnSpan = 2;
            cell.Text = "Work Time";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.Attributes.Add("style", "text-align:center;font-size:10px;");
            cell.ColumnSpan = 1;
            cell.Text = "Remarks";
            row.Controls.Add(cell);
            GridViewList.Controls[0].Controls.AddAt(0, row);

            cell = new TableHeaderCell();
            cell.Attributes.Add("style", "text-align:center;font-size:10px;");
            cell.ColumnSpan = 2;
            cell.Text = "REG WORK";
            row.Controls.Add(cell);
            GridViewList.Controls[0].Controls.AddAt(0, row);

            cell = new TableHeaderCell();
            cell.Attributes.Add("style", "text-align:center;font-size:10px;");
            cell.ColumnSpan = 2;
            cell.Text = "ABSENCES";
            row.Controls.Add(cell);
            GridViewList.Controls[0].Controls.AddAt(0, row);

            cell = new TableHeaderCell();
            cell.Attributes.Add("style", "text-align:center;font-size:10px;");
            cell.ColumnSpan = 2;
            cell.Text = "LEAVES W/ PAY";
            row.Controls.Add(cell);
            GridViewList.Controls[0].Controls.AddAt(0, row);

            cell = new TableHeaderCell();
            cell.Attributes.Add("style", "text-align:center;font-size:10px;");
            cell.ColumnSpan = 2;
            cell.Text = "LEAVES W/O PAY";
            row.Controls.Add(cell);
            GridViewList.Controls[0].Controls.AddAt(0, row);

            cell = new TableHeaderCell();
            cell.Attributes.Add("style", "text-align:center;font-size:10px;");
            cell.ColumnSpan = 1;
            cell.Text = "LATES";
            row.Controls.Add(cell);
            GridViewList.Controls[0].Controls.AddAt(0, row);

            cell = new TableHeaderCell();
            cell.Attributes.Add("style", "text-align:center;font-size:10px;");
            cell.ColumnSpan = 1;
            cell.Text = "UT";
            row.Controls.Add(cell);
            GridViewList.Controls[0].Controls.AddAt(0, row);

            cell = new TableHeaderCell();
            cell.Attributes.Add("style", "text-align:center;font-size:10px;");
            cell.ColumnSpan = 2;
            cell.Text = "REG OT";
            row.Controls.Add(cell);
            GridViewList.Controls[0].Controls.AddAt(0, row);

            cell = new TableHeaderCell();
            cell.Attributes.Add("style", "text-align:center;font-size:10px;");
            cell.ColumnSpan = 3;
            cell.Text = "LEGAL HOLIDAY OT";
            row.Controls.Add(cell);
            GridViewList.Controls[0].Controls.AddAt(0, row);

            cell = new TableHeaderCell();
            cell.Attributes.Add("style", "text-align:center;font-size:10px;");
            cell.ColumnSpan = 3;
            cell.Text = "LEGAL REST DAY OT";
            row.Controls.Add(cell);
            GridViewList.Controls[0].Controls.AddAt(0, row);

            cell = new TableHeaderCell();
            cell.Attributes.Add("style", "text-align:center;font-size:10px;");
            cell.ColumnSpan = 3;
            cell.Text = "REST DAY OT";
            row.Controls.Add(cell);
            GridViewList.Controls[0].Controls.AddAt(0, row);

            cell = new TableHeaderCell();
            cell.Attributes.Add("style", "text-align:center;font-size:10px;");
            cell.ColumnSpan = 3;
            cell.Text = "SPECIAL HOLIDAY OT";
            row.Controls.Add(cell);
            GridViewList.Controls[0].Controls.AddAt(0, row);

            cell = new TableHeaderCell();
            cell.Attributes.Add("style", "text-align:center;font-size:10px;");
            cell.ColumnSpan = 3;
            cell.Text = "SPECIAL REST DAY OT";
            row.Controls.Add(cell);
            GridViewList.Controls[0].Controls.AddAt(0, row);

            cell = new TableHeaderCell();
            cell.Attributes.Add("style", "text-align:center;font-size:10px;");
            cell.ColumnSpan = 1;
            cell.Text = "SUBMITTED";
            row.Controls.Add(cell);
            GridViewList.Controls[0].Controls.AddAt(0, row);

            cell = new TableHeaderCell();
            cell.Attributes.Add("style", "text-align:center;font-size:10px;");
            cell.ColumnSpan = 1;
            cell.Text = "DATE SUBMITTED";
            row.Controls.Add(cell);
            GridViewList.Controls[0].Controls.AddAt(0, row);
        }

        protected void GridViewList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewList.PageIndex = e.NewPageIndex;
            refresh();
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (DTS_BussDate.Value != "")
            {
                DataGrid dg = new DataGrid();
                DateTime dtFrom = new DateTime();
                DateTime dtTo = new DateTime();
                string codate = "";
                tk.getCutoffRange(DTS_BussDate.Value, out codate, out dtFrom, out dtTo);
                dg.DataSource = tk.populateGridDTS(empno, DTS_BussDate.Value, dtFrom.ToString("yyyy-MM-dd"), dtTo.ToString("yyyy-MM-dd"));
                dg.DataBind();
                if (dg.Items.Count > 0)
                {
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = "application/octet-stream";
                    Response.AddHeader("content-disposition", "attachment;filename=" + empno + "DTR.xls");
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.Charset = "";
                    this.EnableViewState = false;

                    System.IO.StringWriter swriter = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter htmlwriter = new System.Web.UI.HtmlTextWriter(swriter);

                    //DataGrid dg = new DataGrid();
                    //dg.DataSource = tk.populateGridSchedule();
                    //dg.DataBind();


                    dg.RenderControl(htmlwriter);


                    Response.Write(swriter.ToString());
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " exported DTR Summary to Excel File",
                        "EXPORT", "x123", "qwg-23", "EXPORT", Session["EMP_ID"].ToString());
                    Response.End();
                    //exportTOxlsx();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                   "alert",
                   "alert('No data to export!!!');",
                   true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                   "alert",
                   "alert('Select cutoff.');",
                   true);
            }
        }
    }
}