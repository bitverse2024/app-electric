using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin.Employees._201
{
    public partial class DTRSetting : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Common cm = new Common();
        public string empno = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            empno = Request.QueryString["id"];
            if (!IsPostBack)
            {
                populateUpdateField(empno);
            }
        }

        public string getname()
        {
            string name = "";
            name = emp.GetEmployeeName(empno);

            return name;

        }
        public void populateUpdateField(string id)
        {
            string GracePeriod = cm.GetSpecificDataFromDB("GracePeriod", "TBL_DTRSETTINGS", "where EmpID = " + id + "");
            string DisregardLates = cm.GetSpecificDataFromDB("DisregardLate", "TBL_DTRSETTINGS", "where EmpID = " + id + "");
            
            if (!string.IsNullOrEmpty(GracePeriod))
            {
                txtGrace.Value = GracePeriod;
            }
            if (!string.IsNullOrEmpty(DisregardLates))
            {
                if (DisregardLates == "1")
                {
                    chkLate.Checked = true;
                }
                else
                {
                    chkLate.Checked = false;
                }
            }
            

        }
        

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if (!cm.ItemExist("TBL_DTRSETTINGS", "id", "where EmpID = '" + empno + "'", ""))
                {

                    if (emp.InsertQueryCommon(saveParam(), "TBL_DTRSETTINGS"))
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Save !!!');", true);
                        populateUpdateField(empno);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Invalid Input !!!');", true);
                    }


                }
                else
                {
                    if (cm.UpdateQueryCommon(saveParam(), "TBL_DTRSETTINGS", " EmpID = '" + empno + "'"))
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Successfully Updated !!!');", true);
                        populateUpdateField(empno);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Invalid Input !!!');", true);

                    }

                }
            }
        }
        Dictionary<string, string> saveParam()
        {


            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("EmpID", "'" + empno + "'");
            param.Add("GracePeriod", "" + txtGrace.Value == "" ? "0" : txtGrace.Value + "");
            if(chkLate.Checked)
            {
                param.Add("DisregardLate", "'1'");

            }
            if (!chkLate.Checked)
            {
                param.Add("DisregardLate", "'0'");

            }

            

            return param;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            chkLate.Checked = false;
            txtGrace.Value = "0";

        }
    }
}