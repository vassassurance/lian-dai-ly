using DevExpress.Pdf;
using System.IO;
using DevExpress.Office.Tsp;
using DevExpress.Office.DigitalSignatures;
using System;
using System.IO;
using DocumentFormat.OpenXml.Vml.Office;

namespace LianAgentPortal.Services
{
    public interface ISignPdfService
    {
        public void SignPdfFileWithKeyFromStore(string sourceDocument, string destinationPath, string certificateSubjectName, double left, double bottom, double right, double top, int page);
    }
    public class SignPdfService : ISignPdfService
    {

        public void SignPdfFileWithKeyFromStore(string sourceDocument, string destinationPath, string certificateSubjectName, double left, double bottom, double right, double top, int page)
        {
            System.Security.Cryptography.X509Certificates.X509Store store = new System.Security.Cryptography.X509Certificates.X509Store(
                System.Security.Cryptography.X509Certificates.StoreName.My,
                System.Security.Cryptography.X509Certificates.StoreLocation.LocalMachine
            );

            store.Open(System.Security.Cryptography.X509Certificates.OpenFlags.ReadOnly);
            System.Security.Cryptography.X509Certificates.X509Certificate2 x509Certificate2 = null;

            foreach (System.Security.Cryptography.X509Certificates.X509Certificate2 certificate in store.Certificates)
            {
                if (certificate.SubjectName.Name == certificateSubjectName)
                {
                    x509Certificate2 = certificate;
                    break;
                }
            }

            if (x509Certificate2 == null)
            {
                throw new Exception("Không tìm thấy chữ ký");
            }

            // Create a PKCS#7 signature:
            Pkcs7Signer pkcs7Signature = new Pkcs7Signer(x509Certificate2, HashAlgorithmType.SHA256);

            // Create a signature field on the first page:
            var signatureFieldInfo = new PdfSignatureFieldInfo(page);

            // Specify the field's name, location and rotation angle:
            signatureFieldInfo.Name = "SignatureField";
            signatureFieldInfo.SignatureBounds = new PdfRectangle(330, 200, 480, 320);
            signatureFieldInfo.RotationAngle = PdfAcroFormFieldRotation.Rotate90;

            // Apply a signature to a newly created signature field:
            var cooperSignature = new PdfSignatureBuilder(pkcs7Signature, signatureFieldInfo);

            // Specify an image and signer information:
            cooperSignature.Location = "VN";
            cooperSignature.Name = "*.vass.com.vn";
            cooperSignature.Reason = "Acknowledgement";

            using (var signer = new PdfDocumentSigner(sourceDocument))
            {
                signer.SaveDocument(destinationPath, cooperSignature);
            }

            FileInfo file = new FileInfo(sourceDocument);
            if (file.Exists)
            {
                file.Delete();
            }
        }
    }
}
