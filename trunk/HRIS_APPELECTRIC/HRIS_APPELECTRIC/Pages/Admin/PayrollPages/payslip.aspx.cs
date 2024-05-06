using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRIS_APPELECTRIC.Pages.Admin.PayrollPages
{
    public partial class payslip : System.Web.UI.Page
    {
        Employee emp = new Employee();
        Common cm = new Common();
        Payroll pr = new Payroll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //ddlCredDate.Items.AddRange(emp.GetDropDownMenuList("TBL_CUTOFF", "CDesc"));
                ddlCredDate.Items.AddRange(emp.GetDropDownMenuListOrdrBy("TBL_CUTOFF", "CDesc", "id", " ORDER by Company asc, MONTH(cofrom) asc"));
                //ddlEmployee.Items.AddRange(emp.GetDropDownMenuListEmployee());
            }

        }

        protected void btnProcess2_Click(object sender, EventArgs e)
        {
            string confirmValue = "";
            confirmValue = Request.Form["confirm_value"];
            if (confirmValue.Contains("Yes"))
            {
                List<Payroll.Payslip> listps = new List<Payroll.Payslip>();
                if (ddlEmployee.SelectedValue == "ALL")
                    listps = pr.GetPayslipBulk(ddlCredDate.SelectedValue);

                else
                    listps = pr.GetPayslip(ddlCredDate.SelectedValue.ToString(), ddlEmployee.SelectedValue.ToString());

                if (listps.Count > 0)
                    genpayslip(listps);
                else
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('No data to process!!!');", true);
                //Response.Redirect("payslipview.aspx?cid=" + ddlCredDate.SelectedValue + "&empid=" + ddlEmployee.SelectedValue + "");
            }

        }
        void genpayslip(List<Payroll.Payslip> pdffields)
        {
            Response.ContentType = "application/pdf";

            Response.AddHeader("content-disposition",

                "attachment;filename=Payslip.pdf");


            Response.Cache.SetCacheability(HttpCacheability.NoCache);





            var pgSize = PageSize.LETTER;
            string text = "";

            //string imgpath = HttpRuntime.BinDirectory;
            //iTextSharp.text.Image myImage = iTextSharp.text.Image.GetInstance(imgpath + "/htland.png"); ;

            //iTextSharp.text.Image barcodeimg = iTextSharp.text.Image.GetInstance(sysbarcodeimg, System.Drawing.Imaging.ImageFormat.Png);
            //Dictionary<string, iTextSharp.text.Image> imgdict = new Dictionary<string, iTextSharp.text.Image>();
            //imgdict.Add("img", myImage);


            Document pdfDoc = new Document(pgSize, 10f, 10f, 10f, 10f);

            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

            Response.Write(pr.genPayslip(pdfDoc, pdffields));

            Response.End();



            //1-not yet used 
            //0-already used

        }
        protected void btnProcess_Click(object sender, EventArgs e)
        {
            //Response.Redirect("payslipview.aspx?cid=" + ddlCredDate.SelectedValue + "&empid=" + ddlEmployee.SelectedValue + "");
            //string confirmValue = "";
            //confirmValue = Request.Form["confirm_value"];
            //if (confirmValue.Contains("Yes"))
            //{
                List<Payroll.Payslip> listps = new List<Payroll.Payslip>();
                if (ddlEmployee.SelectedValue == "ALL")
                    listps = pr.GetPayslipBulk(ddlCredDate.SelectedValue);

                else
                    listps = pr.GetPayslip(ddlCredDate.SelectedValue.ToString(), ddlEmployee.SelectedValue.ToString());

                if (listps.Count > 0)
                    genpayslip(listps);
                else
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", " alert('No data to process!!!');", true);
                //Response.Redirect("payslipview.aspx?cid=" + ddlCredDate.SelectedValue + "&empid=" + ddlEmployee.SelectedValue + "");
            //}

        }
        protected void ddlCredDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            string getPayrollGroup = cm.GetSpecificDataFromDB("PayrollGroup", "TBL_CUTOFF", "where id = " + ddlCredDate.SelectedValue + "");
            ddlEmployee.Items.Clear();
            ddlEmployee.Items.Insert(0, new System.Web.UI.WebControls.ListItem("---ALL EMPLOYEE---", "ALL"));
            ddlEmployee.Items.AddRange(emp.GetDropDownMenuListEmployeeWhereCutOff(getPayrollGroup));
        }
    }
}