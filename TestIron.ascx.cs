using CMS.PortalEngine.Web.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IronPdf;

public partial class CMSWebParts_CustomWebparts_TestIron : CMSAbstractWebPart
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btnCreatePDF_Click(object sender, EventArgs e)
    {
        var Renderer = new IronPdf.HtmlToPdf();
        var PDF = Renderer.RenderHtmlAsPdf("<h1>Hello IronPdf</h1>");
        var OutputPath = "C:\\Users\\Aisha\\Desktop\\TEST\\HtmlToPDF.pdf";
        PDF.SaveAs(OutputPath);
        // This neat trick opens our PDF file so we can see the result in our default PDF viewer
        System.Diagnostics.Process.Start(OutputPath);

        Response.AppendHeader("Content-Disposition", "attachment; filename=" + OutputPath);
        Response.ContentType = "application/pdf";
        Response.TransmitFile(OutputPath);
        Response.End();
    }
}