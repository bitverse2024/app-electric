using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin
{
    public partial class philHealth : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Common cm = new Common();
        Payroll pr = new Payroll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ROLES"].ToString() != "admin")
                {
                    Response.Redirect("~/Pages/Login.aspx");
                }
                populate();
            }

        }

        Dictionary<string, string> saveParam()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("philDedPercent", "" + philDedPercent.Value + "");
            param.Add("philDedYear", "'" + philDedYear.Value + "'");



            return param;
        }


        protected void refresh()
        {
            philDedPercent.Value = "";
            philDedYear.Value = "";

        }
        void populate()
        {
            philDedPercent.Value = cm.GetSpecificDataFromDB("philDedPercent", "TBL_PHILHEALTH");
            philDedYear.Value = cm.GetSpecificDataFromDB("philDedYear", "TBL_PHILHEALTH");
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                if (philDedPercent.Value != "")
                {
                    if(cm.GetCount("TBL_PHILHEALTH") == "0")
                    {
                        cm.InsertQueryCommon(saveParam(), "TBL_PHILHEALTH");
                        if (pr.UpdateEmpPhilhealthbulk())
                        {
                            cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " updated PHILHEALTH DEDUCTION PERCENTAGE " + philDedPercent.Value,
                                    "UPDATE", "x123", "qwg-23", "UPDATE", Session["EMP_ID"].ToString());
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert(' Successfully Updated !!!');", true);
                            //refresh();
                            populate();
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Please provide required field!');", true);
                            //refresh();
                            populate();
                        }

                    }
                    else if(cm.UpdateQueryCommon(saveParam(),"TBL_PHILHEALTH"," id = 1"))
                    {
                        if(pr.UpdateEmpPhilhealthbulk())
                        { 
                        cm.AddLog("User " + Session["USER_DISPLAY_NAME"].ToString().ToUpper() + " updated PHILHEALTH DEDUCTION PERCENTAGE " + philDedPercent.Value,
                                "UPDATE", "x123", "qwg-23", "UPDATE", Session["EMP_ID"].ToString());
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert(' Successfully Updated !!!');", true);
                        //refresh();
                        populate();
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Please provide required field!');", true);
                            //refresh();
                            populate();
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('Please provide required field!');", true);
                    //refresh();
                    populate();
                }
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            refresh();
        }
    }
}