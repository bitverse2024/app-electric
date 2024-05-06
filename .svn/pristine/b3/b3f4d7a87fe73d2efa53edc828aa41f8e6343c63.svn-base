using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin.TK
{
    public partial class submitdtr : System.Web.UI.Page
    {
        Timekeeping tk = new Timekeeping();
        Employee emp = new Employee();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DTS_BussDate.Items.AddRange(emp.GetDropDownMenuList("TBL_CUTOFF", "CDesc"));

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            int ret = 1;
            if (tk.submitDTR(DTS_BussDate.Value, Session["DTRActiveEmpID"].ToString(), out ret))
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Submitted DTR !!!');", true);
            else
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Failed to Submit !!!');", true);
        }
    }
}