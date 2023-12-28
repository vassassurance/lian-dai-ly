using LianAgentPortal.Models.DbModels;
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
        private readonly ISignPdfService _signPdfService;
        private readonly string CertificateTemplate = "cer-template/020502-tnsp-v2.htm";

        public TnspService(IWebHostEnvironment webHostEnvironment, ISignPdfService signPdfService)
        {
            _webHostEnvironment = webHostEnvironment;
            _signPdfService = signPdfService;
        }


        public void GenCertificate(InsuranceTnspDetail model)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;

            string pathToFile = Path.Combine(webRootPath, model.CertificateDigitalLink);
            string pathToFilTemp = Path.Combine(webRootPath, model.CertificateDigitalLink);

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

                PdfDigitalCertificatesCollection certificates = PdfDigitalCertificatesStore.GetCertificates();
                PdfDigitalCertificate certificate = certificates[0];
                PdfDigitalSignatureElement signature = new PdfDigitalSignatureElement(new System.Drawing.RectangleF(350, 300, 490, 240), certificate);

                pdfDocument.Pages[0].Add(signature);


                pdfDocument.Save(pathToFile);
                pdfDocument.Close();






                //// the certificate
                //string certFile = Server.MapPath("~/files/selectpdf.pfx");

                //// load the pdf document using the advanced security manager
                //PdfSecurityManager security = new PdfSecurityManager();
                //security.Load(pathToFile);

                //// add the digital signature
                //security.Sign(certFile, "selectpdf");

                //// save pdf document
                //security.Save(Response, false, "Sample.pdf");

                //// close pdf document
                //security.Close();


                //try
                //{
                //    _signPdfService.SignPdfFileWithKeyFromStore(
                //        pathToFile, pathToFile,
                //        GeneralConstants.DIGITAL_SIGN_SUBJECT_NAME,
                //        true, 350, 300, 490, 240, 1
                //    );
                //}
                //catch
                //{

                //}
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
