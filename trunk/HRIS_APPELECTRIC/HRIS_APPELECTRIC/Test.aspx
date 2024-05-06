<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="HRIS_APPELECTRIC.Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="/dist/css/AdminLTE.min.css" />
    
     <script type="text/javascript" src="PDFLib/jspdf.min.js"></script>
    <script type="text/javascript" src="PDFLib/html2canvas.js"></script>
    <script type="text/javascript" src="PDFLib/pdfmake.min.js"></script>
    <script type="text/javascript">
    function Export() {
        html2canvas(document.getElementById('pdf2'), {
            onredered: function (canvas) {
                var data = canvas.toDataURL();
                var doc = new jsPDF();
                doc.addImage(data, 'JPEG', 20, 20);
                doc.save('asdasd.pdf');
                //var docDefinition = {
                //    content: [{
                //        image: data,
                //        width: 500
                //    }]
                //};
                //pdfMake.createPdf(docDefinition).download("asdasd.pdf")
                //alert("Downloading")

            }
        });
    }

</script>  
    <meta http-equiv="Content-Type" content="text/html"; charset="UTF-8" />
    <%--<style type="text/css">

    @media print {
        h2 {
            page-break-after: always;
                }
            }
    </style>--%>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        

<script type="text/javascript">
    var doc = new jsPDF();

 function saveDiv(divId, title) {
 doc.fromHTML(`<html><head><title>${title}</title></head><body>` + document.getElementById(divId).innerHTML + `</body></html>`);
 doc.save('div.pdf');
}

function printDiv(divId, title) {

  let mywindow = window.open('', 'PRINT', 'height=650,width=900,top=100,left=150');

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

    function genPDF() {

        html2canvas(document.getElementById("pdf"), {
            onrendered: function (canvas) {
                var img = canvas.toDataURL("image/png");
                var doc = new jsPDF();
                doc.addImage(img, 'JPEG', 20, 20);
                doc.save('payslip.pdf');
            }
        });
    }


</script>

     
<button onclick="printDiv('pdf','Title')">print div</button>
<button onclick="saveDiv('pdf','Title')">save div as pdf</button>
        <button onclick="Export()">save div as pdf1</button>
       
        <asp:Button ID="Export" runat="server" Text="Button" OnClick="Export_Click" />
        <a href="javascript:Export()">DLPDF</a>

        <div id="pdf" class="container-xl" style="border-bottom:dashed" runat="server">
       
            <%=populatehtml()%>
            <h2 style="page-break-after:always"></h2>
            <%=populatehtml()%>
            <h2 style="page-break-after:always"></h2>
            <%=populatehtml()%>
            <h2 style="page-break-after:always"></h2>
            <%=populatehtml()%>
            <h2 style="page-break-after:always"></h2>
            <%=populatehtml()%>
            <h2 style="page-break-after:always"></h2>
            <%=populatehtml()%>
            <h2 style="page-break-after:always"></h2>
            <%=populatehtml()%>
            <h2 style="page-break-after:always"></h2>
            <%=populatehtml()%>
            <br />
        </div>
        <div id ="pdf2">
            <p>
    <font size="3" color="red">print this to pdf</font>
  </p>
        </div>
    </form>
</body>
</html>

