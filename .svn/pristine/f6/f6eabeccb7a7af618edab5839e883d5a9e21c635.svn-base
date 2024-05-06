using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HRIS_APPELECTRIC.Pages.Admin.Employees
{
    public partial class viewdtrlist : System.Web.UI.Page
    {
        public string empNo = "";
        Employee db_Emp = new Employee();
        Common cm = new Common();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                empNo = Session["EMP_ID"].ToString();
                refresh();

            }
        }

        void refresh()
        {

            DataTable dt = new DataTable();
            dt = db_Emp.populateGridEmpDTR(empNo);
            GridUserList.DataSource = dt;
            GridUserList.DataBind();
            ViewState["EMP_MASTER"] = dt;
            ViewState["SORTDR"] = null;

        }


        protected void GridUserList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridUserList.PageIndex = e.NewPageIndex;
            refresh();
        }


        protected void sort_grid(string sort_args)
        {
            DataTable dt = (DataTable)ViewState["EMP_MASTER"];
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

                GridUserList.DataSource = dt;
                GridUserList.DataBind();

            }

        }

        protected void txtItem_TextChanged(object sender, EventArgs e)
        {
            GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent;
            string a1 = ((TextBox)currentRow.FindControl("txtSearchEmp_Name")).Text;
            string a2 = ((TextBox)currentRow.FindControl("txtSearchEmpID")).Text;
            string a3 = ((TextBox)currentRow.FindControl("txtSearchBussDate")).Text;
            string a4 = ((TextBox)currentRow.FindControl("txtSearchDateIn")).Text;
            string a5 = ((TextBox)currentRow.FindControl("txtSearchDTimeIn")).Text;
            string a6 = ((TextBox)currentRow.FindControl("txtSearchDateOut")).Text;
            string a7 = ((TextBox)currentRow.FindControl("txtSearchDTimeOut")).Text;
            string expr = db_Emp.build_or_like_param(saveSearchParam(a1, a2, a3, a4, a5, a6, a7));
            GridUserList.DataSource = db_Emp.populateGridEmployeelistCol(expr);
            GridUserList.DataBind();
        }

        Dictionary<string, string> saveSearchParam(string a1, string a2, string a3, string a4, string a5, string a6, string a7)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("Emp_Name", "'%" + a1 + "%'");
            param.Add("EmpID", "'%" + a2 + "%'");
            param.Add("BussDate", "'%" + a3 + "%'");
            param.Add("DateIn", "'%" + a4 + "%'");
            param.Add("DTimeIn", "'%" + a5 + "%'");
            param.Add("DateOut", "'%" + a6 + "%'");
            param.Add("DTimeOut", "'%" + a7 + "%'");
            return param;
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("content-disposition", "attachment;filename= EmployeeMasterList" + ".xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Charset = "";
            this.EnableViewState = false;

            System.IO.StringWriter swriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlwriter = new System.Web.UI.HtmlTextWriter(swriter);

            DataGrid dg = new DataGrid();
            dg.DataSource = db_Emp.populateGridEmpDTR(empNo);
            dg.DataBind();

            dg.RenderControl(htmlwriter);


            Response.Write(swriter.ToString());
            cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " exported DTR",
            "EXPORT", "EMPLOYEE", Session["EMP_ID"].ToString(), "EMPLOYEE", Session["EMP_ID"].ToString());
            Response.End();
            //exportTOxlsx();


        }
    }
}