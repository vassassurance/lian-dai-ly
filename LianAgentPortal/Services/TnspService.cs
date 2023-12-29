using LianAgentPortal.Commons.Constants;
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
            string pathToFileTemp = Path.Combine(webRootPath, model.CertificateDigitalLink) + ".pdf";

            if (!Directory.Exists(Path.GetDirectoryName(pathToFileTemp))
                || !File.Exists(pathToFileTemp))
            {
                string pathToTemplate = Path.Combine(webRootPath, CertificateTemplate);
                Directory.CreateDirectory(Path.GetDirectoryName(pathToFileTemp));

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




                pdfDocument.Save(pathToFileTemp);
                pdfDocument.Close();




                try
                {

                    _signPdfService.SignPdfFileWithKeyFromStore(
                        pathToFileTemp,
                        pathToFile,
                        GeneralConstants.DIGITAL_SIGN_SUBJECT_NAME,
                        330, 200, 480, 320, 1
                    );
                }
                catch (Exception ex)
                {

                }
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
            html = (string)html.Replace("{SignDate}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt K"));
            html = (string)html.Replace("{FromDate}", model.FromDate.ToString("dd/MM/yyyy"));
            html = (string)html.Replace("{ToDate}", model.ToDate.ToString("dd/MM/yyyy"));

            return html;
        }

    }
}
