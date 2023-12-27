using AutoMapper;
using Hangfire;
using LianAgentPortal.Commons;
using LianAgentPortal.Commons.Constants;
using LianAgentPortal.Data;
using LianAgentPortal.Models.DbModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using SelectPdf;

namespace LianAgentPortal.Services
{

    public interface ITnspService
    {
        void GenCertificate(InsuranceTnspDetail model);
    }

    public class TnspService : ITnspService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string CertificateTemplate = "cer-template/020502-tnsp.htm";

        public TnspService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }


        public void GenCertificate(InsuranceTnspDetail model)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;

            string pathToFile = Path.Combine(webRootPath, model.CertificateDigitalLink);

            if (!Directory.Exists(Path.GetDirectoryName(pathToFile))
                || !File.Exists(pathToFile))
            {
                string pathToTemplate = Path.Combine(webRootPath, CertificateTemplate);
                Directory.CreateDirectory(Path.GetDirectoryName(pathToFile));

                HtmlToPdf htmlToPdf = new HtmlToPdf();
                htmlToPdf.Options.PdfPageSize = PdfPageSize.A4;
                htmlToPdf.Options.PdfPageOrientation = PdfPageOrientation.Portrait;

                htmlToPdf.Options.WebPageWidth = 600;
                htmlToPdf.Options.WebPageHeight = 0;
                htmlToPdf.Options.WebPageFixedSize = false;

                htmlToPdf.Options.AutoFitWidth = HtmlToPdfPageFitMode.AutoFit;
                htmlToPdf.Options.AutoFitHeight = HtmlToPdfPageFitMode.AutoFit;
                PdfDocument pdfDocument = new SelectPdf.PdfDocument();
                string html = this.GetHtmlCertificate(pathToTemplate, model);
                pdfDocument = htmlToPdf.ConvertHtmlString(html);
                pdfDocument.Save(pathToFile);
                pdfDocument.Close();

                //this.DigitalSigner.Sign(pathToFile, new SignaturePosition(350, 300, 490, 240));
            }
        }

        private string GetHtmlCertificate(string templatePath, InsuranceTnspDetail model)
        {
            string html = File.ReadAllText(templatePath);
            html = File.ReadAllText(templatePath);

            html = (string)html.Replace("{PolicyNumber}", model.InsuranceNo);
            html = (string)html.Replace("{CustomerName}", model.CustomerName);
            html = (string)html.Replace("{OrderId}", model.OrderId);
            html = (string)html.Replace("{IdentityNumber}", model.IdentityNumber);
            html = (string)html.Replace("{IssueDate}", DateTime.Now.ToString("dd/MM/yyyy"));
            html = (string)html.Replace("{FromDate}", model.FromDate.ToString("dd/MM/yyyy"));
            html = (string)html.Replace("{ToDate}", model.ToDate.ToString("dd/MM/yyyy"));

            return html;
        }

    }
}
