using HiQPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HiqpdfDemo.Controllers
{
    public class ConvertHtmlToPdfController : Controller
    {
        // GET: ConvertHtmlToPdf
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ConvertToPdf(FormCollection collection)
        {
            // create the HTML to PDF converter
            HtmlToPdf htmlToPdfConverter = new HtmlToPdf();

            // set PDF page size and orientation
            htmlToPdfConverter.Document.PageSize = PdfPageSize.A4;
            htmlToPdfConverter.Document.PageOrientation = PdfPageOrientation.Portrait;

            // set PDF page margins
            htmlToPdfConverter.Document.Margins = new PdfMargins(0);

            // convert HTML to PDF
            byte[] pdfBuffer = null;
            string htmlCode = collection["htmlText"];
            pdfBuffer = htmlToPdfConverter.ConvertHtmlToMemory(htmlCode, null);

            FileResult fileResult = new FileContentResult(pdfBuffer, "application/pdf");            
            fileResult.FileDownloadName = "HtmlToPdf.pdf";
            return fileResult;
        }

    }
}