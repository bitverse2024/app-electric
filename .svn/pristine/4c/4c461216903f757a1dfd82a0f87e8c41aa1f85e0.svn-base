using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin.TK
{
    public partial class computedtr : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Timekeeping tk = new Timekeeping();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DTS_BussDate.Items.AddRange(emp.GetDropDownMenuList("TBL_CUTOFF", "CDesc"));

            }
        }

        protected void btnCompute_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            int ret = 1;
            if (tk.computeData(DTS_BussDate.Value,"", out ret))
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Computed !!!');", true);
            else
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Failed to Compute !!!');", true);
        }
    }
}