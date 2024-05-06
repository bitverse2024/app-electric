<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="payslipview.aspx.cs" Inherits="HRIS_APPELECTRIC.Pages.Admin.PayrollPages.payslipview" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <link rel="stylesheet" type="text/css" href="/dist/css/AdminLTE.min.css" />
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
                <%--<p>don't print this to pdf</p>
                    <div id="pdf">
                      <p>
                        <font size="3" color="red">print this to pdf</font>
                      </p>
                    </div>--%>

<script type="text/javascript">
        var doc = new jsPDF();

        function saveDiv(divId, title) {
         doc.fromHTML(`<html><head><title>${title}</title></head><body>` + document.getElementById(divId).innerHTML + `</body></html>`);
         doc.save('div.pdf');
        }

        function printDiv(divId,
          title) {

            let mywindow = window.open('', 'PRINT', 'height=1200,width=900,top=100,left=150');
            //let mywindow = window.open('', 'PRINT', 'height=400,width=600');

          mywindow.document.write(`<html><head><title>${title}</title>`);
          mywindow.document.write('</head><body >');
          mywindow.document.write(document.getElementById(divId).innerHTML);
          mywindow.document.write('</body></html>');

          mywindow.document.close(); // necessary for IE >= 10
          mywindow.focus(); // necessary for IE >= 10*/

          mywindow.print();
          mywindow.close();

          return true;
        }
    </script>
        <%--<div class="card-header">
            <a href="#" class="btn btn-default" onclick="printDiv('pdf','PRINT PAYSLIP')"><i class="fa fa-print"></i><span class="h6">PRINT</span></a>
        </div>--%>

<%--<button onclick="saveDiv('pdf','Title')">save div as pdf</button>--%>
        
        <div id ="pdf" class="container-xl">
            <%=printview()%>
            
            <br />
        </div>
    </form>
</body>
    
</html>




