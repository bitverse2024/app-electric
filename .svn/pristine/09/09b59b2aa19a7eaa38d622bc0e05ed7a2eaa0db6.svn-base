using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin.TK
{
    public partial class mergedtr : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Timekeeping tk = new Timekeeping();
        Common cm = new Common();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //DTS_BussDate.Items.AddRange(emp.GetDropDownMenuList("TBL_CUTOFF", "CDesc","id","ORDER by Company asc, CODate Desc"));
                DTS_BussDate.Items.AddRange(emp.GetDropDownMenuListOrdrBy("TBL_CUTOFF", "CDesc", "id", " ORDER by Company asc, MONTH(cofrom) asc"));
                //DTS_PayrollGroup.Items.AddRange(emp.GetDropDownMenuList("TBL_PAYROLLGRP", "payrollgrpname"));

            }
        }
        protected void DTS_BussDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DTS_BussDate.SelectedValue != "")
            {
                string getPayrollGroup = cm.GetSpecificDataFromDB("PayrollGroup", "TBL_CUTOFF", "where id = " + DTS_BussDate.SelectedValue + "");
                ddlEmployee.Items.Clear();
                ddlEmployee.Items.Insert(0, new ListItem("---Select Employee---", ""));
                ddlEmployee.Items.AddRange(emp.GetDropDownMenuListEmployeeWhereCutOff(getPayrollGroup));
            }
        }

        protected void btnMerge_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            int ret = 1;
            if (tk.mergeData(DTS_BussDate.SelectedValue, ddlEmployee.SelectedValue, out ret))
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Merged !!!');", true);
            else
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Failed to Merged !!!');", true);
        }

        protected void btmCompleteMerge_Click(object sender, EventArgs e)
        {
            if (DTS_BussDate.SelectedValue != "")
            {
                System.Threading.Thread.Sleep(5000);
                int ret = 1;
                bool mergeSuccess = false, computeSucess = false;

                if (tk.mergeData(DTS_BussDate.SelectedValue, ddlEmployee.SelectedValue, out ret))
                    mergeSuccess = true;
                else
                    goto NOTIFY;//dont bother to compute since merging already failed

                if (tk.computeData(DTS_BussDate.SelectedValue, ddlEmployee.SelectedValue, out ret))
                    computeSucess = true;

                NOTIFY:
                if (mergeSuccess && computeSucess)
                {
                    reset();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Merged !!!');", true);
                    cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " Merged DTR for Pay Period:" + DTS_BussDate.SelectedItem.Text,
                        "MERGE", "x123", "qwg-23", "MERGE", Session["EMP_ID"].ToString());

                }
                else if (mergeSuccess && !computeSucess)
                {
                    reset();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Merged - Failed to Compute Data !!!');", true);
                }

                else
                {
                    reset();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Failed to Merged !!!');", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Select cutoff.');", true);
            }
        }
        void reset()
        {
            DTS_BussDate.SelectedValue = "";
            ddlEmployee.Items.Clear();
            ddlEmployee.Items.Insert(0, new ListItem("---Select Employee---", ""));
        }

    }
}