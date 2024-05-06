using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin.PayrollPages
{
    public partial class createded : System.Web.UI.Page
    {
        public string empno = "";
        Employee emp = new Employee();
        Common cm = new Common();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                empno = Request.QueryString["empid"];
                if (!IsPostBack)
                {
                    if (Session["ROLES"].ToString() != "admin")
                    {
                        Session.Clear();
                        Session.Abandon();
                        Response.Redirect("~/Pages/Login.aspx");
                    }
                    string getpayrollgroup = cm.GetSpecificDataFromDB("emp_PayrollGroup", "TBL_EMPLOYEE_MASTER", "where emp_EmpID = '" + empno + "'");
                    ddlCutoff.Items.AddRange(emp.GetDropDownMenuListCutOffWhereEmployeePayrollGroup(getpayrollgroup));
                }
            }
            catch
            {
                Session.Clear();
                Session.Abandon();
                Response.Redirect("~/Pages/Login.aspx");
            }

        }
        void clearfield()
        {
            ddlCutoff.SelectedValue = "";
            txtSSS.Text = "";
            txtPhilhealth.Text = "";
            txtPagibig.Text = "";
            //txtLates.Value = "";
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (!cm.ItemExist("TBL_DEDUCTIONADJ", "id", "where EmpID = '" + empno + "' and CutOffID =" + ddlCutoff.SelectedValue + "", ""))
            {
                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {
                    if (emp.InsertQueryCommon(saveParam(), "TBL_DEDUCTIONADJ"))
                    {


                        cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " created DEDUCTION ADJUSTMENT for employee = " + empno + " Cutoff = " + ddlCutoff.SelectedValue,
                                "CREATE", "x123", "qwg-23", "CREATE", Session["EMP_ID"].ToString());
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Save !!!');", true);
                        clearfield();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Create Deduction Failed !!!');", true);
                        clearfield();
                    }
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Deduction Exist!!!');", true);
                clearfield();

            }
        }
        Dictionary<string, string> saveParam()
        {


            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("EmpID", "'" + empno + "'");
            param.Add("CutOffID", "" + ddlCutoff.SelectedValue + "");
            if (!string.IsNullOrEmpty(txtSSS.Text))
            {
                param.Add("SSSDed", "" + txtSSS.Text + "");

            }
            if (!string.IsNullOrEmpty(txtPhilhealth.Text))
            {
                param.Add("PhilDed", "" + txtPhilhealth.Text + "");

            }
            if (!string.IsNullOrEmpty(txtPagibig.Text))
            {
                param.Add("PagibigDed", "" + txtPagibig.Text + "");

            }
            if (!string.IsNullOrEmpty(txtsssER.Text))
            {
                param.Add("sssER", "" + txtsssER.Text + "");

            }
            param.Add("sssEC", "0");


            if (!string.IsNullOrEmpty(txtPhilDedER.Text))
            {
                param.Add("PhilDedER", "" + txtPhilDedER.Text + "");

            }
            if (!string.IsNullOrEmpty(txtPagibigDedER.Text))
            {
                param.Add("PagibigDedER", "" + txtPagibigDedER.Text + "");

            }
            if (!string.IsNullOrEmpty(txtempTax.Text))
            {
                param.Add("empTax", "" + txtempTax.Text + "");

            }

            //    param.Add("SSSDed", txtSSS.Value == "" ? DBNull.Value : (object)txtSSS.Value)
            ////param.Add("SSSDed", "" + txtSSS.Value == "" ? DBNull.Value : txtSSS.Value + "");
            //param.Add("PhilDed", "" + txtPhilhealth.Value == "" ? DBNull.Value.ToString() : txtPhilhealth.Value + "");
            //param.Add("PagibigDed", "" + txtPagibig.Value == "" ? DBNull.Value.ToString() : txtPagibig.Value + "");
            //param.Add("LatesDed", "" + txtLates.Value == "" ? DBNull.Value.ToString() : txtLates.Value + "");

            return param;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

        }
    }
}