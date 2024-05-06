using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin.TK
{
    public partial class createsummary : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Timekeeping tk = new Timekeeping();
        Common cm = new Common();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //DTS_BussDate.Items.AddRange(emp.GetDropDownMenuList("TBL_CUTOFF", "CDesc"));
                //DTS_BussDate.Items.AddRange(emp.GetDropDownMenuList("TBL_CUTOFF", "CDesc", "id", "ORDER by Company asc, CODate Desc"));
                DTS_BussDate.Items.AddRange(emp.GetDropDownMenuListOrdrBy("TBL_CUTOFF", "CDesc", "id", " ORDER by Company asc, MONTH(cofrom) asc"));
            }
        }

        protected void btncreateSummary_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            int ret = 1;
            if (tk.createSummary(DTS_BussDate.SelectedValue, ddlEmployee.SelectedValue, out ret))
            {
                reset();
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Summary Completed !!!');", true);
            }
            else
            {
                reset();
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Failed to Create Summary !!!');", true);
            }

        }
        protected void DTS_BussDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            string getPayrollGroup = cm.GetSpecificDataFromDB("PayrollGroup", "TBL_CUTOFF", "where id = " + DTS_BussDate.SelectedValue + "");
            ddlEmployee.Items.Clear();
            ddlEmployee.Items.Insert(0, new ListItem("---Select Employee---", ""));
            ddlEmployee.Items.AddRange(emp.GetDropDownMenuListEmployeeWhereCutOff(getPayrollGroup));
        }
        void reset()
        {
            DTS_BussDate.SelectedValue = "";
            ddlEmployee.Items.Clear();
            ddlEmployee.Items.Insert(0, new ListItem("---Select Employee---", ""));
        }
    }
}