using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.security;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.X509;
using System;
using System.IO;

namespace LianAgentPortal.Services
{
    public interface ISignPdfService
    {
        public void SignPdfFileWithKeyFromStore(string sourceDocument, string destinationPath, string certificateSubjectName, bool visible, float llx, float lly, float urx, float ury, int page);
    }
    public class SignPdfService : ISignPdfService
    {
        //public void SignPdfFile(string sourceDocument, string destinationPath, Stream privateKeyStream, string password, string reason, string location)
        //{
        //    Pkcs12Store pk12 = new Pkcs12Store(privateKeyStream, password.ToCharArray());
        //    privateKeyStream.Dispose();
        //    string alias = null;
        //    foreach (string tAlias in pk12.Aliases)
        //    {
        //        if (pk12.IsKeyEntry(tAlias))
        //        {
        //            alias = tAlias;
        //            break;
        //        }
        //    }
        //    var pk = pk12.GetKey(alias).Key;
        //    iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(sourceDocument);
        //    using (FileStream fout = new FileStream(destinationPath, FileMode.Create, FileAccess.ReadWrite))
        //    {
        //        using (iTextSharp.text.pdf.PdfStamper stamper = iTextSharp.text.pdf.PdfStamper.CreateSignature(reader, fout, '\0'))
        //        {
        //            iTextSharp.text.pdf.PdfSignatureAppearance appearance = stamper.SignatureAppearance;
        //            appearance.Reason = reason;
        //            appearance.Location = location;
        //            appearance.SetVisibleSignature(new iTextSharp.text.Rectangle(20, 10, 170, 60), 1, "Icsi-Vendor");
        //            iTextSharp.text.pdf.security.IExternalSignature es = new iTextSharp.text.pdf.security.PrivateKeySignature(pk, "SHA-256");
        //            iTextSharp.text.pdf.security.MakeSignature.SignDetached(appearance, es, new X509Certificate[] { pk12.GetCertificate(alias).Certificate }, null, null, null, 0, iTextSharp.text.pdf.security.CryptoStandard.CMS);
        //            stamper.Close();
        //        }
        //    }
        //}

        //public void SignImagePdfFileWithKeyFromStore(string sourceDocument, string destinationPath, string imagePath, string certificateSubjectName, float llx, float lly, float urx, float ury)
        //{
        //    System.Security.Cryptography.X509Certificates.X509Store store = new System.Security.Cryptography.X509Certificates.X509Store(
        //        System.Security.Cryptography.X509Certificates.StoreName.My,
        //        System.Security.Cryptography.X509Certificates.StoreLocation.LocalMachine
        //    );

        //    store.Open(System.Security.Cryptography.X509Certificates.OpenFlags.ReadOnly);

        //    IExternalSignature externalSignature = null;
        //    System.Security.Cryptography.X509Certificates.X509Certificate2 x509Certificate2 = null;

        //    foreach (System.Security.Cryptography.X509Certificates.X509Certificate2 certificate in store.Certificates)
        //    {
        //        if (certificate.SubjectName.Name == certificateSubjectName)
        //        {
        //            externalSignature = new X509Certificate2Signature(certificate, "SHA-1");
        //            x509Certificate2 = certificate;
        //            break;
        //        }
        //    }

        //    if (externalSignature == null)
        //    {
        //        throw new Exception("Signature not found");
        //    }

        //    iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(sourceDocument);
        //    using (FileStream fout = new FileStream(destinationPath, FileMode.Create, FileAccess.ReadWrite))
        //    {
        //        using (iTextSharp.text.pdf.PdfStamper stamper = iTextSharp.text.pdf.PdfStamper.CreateSignature(reader, fout, '\0'))
        //        {
        //            iTextSharp.text.pdf.PdfSignatureAppearance appearance = stamper.SignatureAppearance;

        //            System.Drawing.Image image = System.Drawing.Image.FromFile(imagePath);
        //            appearance.Image = iTextSharp.text.Image.GetInstance(image, System.Drawing.Imaging.ImageFormat.Png);
        //            appearance.Layer4Text = "";
        //            appearance.Layer2Text = "";
        //            appearance.SetVisibleSignature(new iTextSharp.text.Rectangle(llx, lly, urx, ury), 1, "Icsi-Vendor");

        //            iTextSharp.text.pdf.security.MakeSignature.SignDetached(appearance, externalSignature, new X509Certificate[] { Org.BouncyCastle.Security.DotNetUtilities.FromX509Certificate(x509Certificate2) }, null, null, null, 0, iTextSharp.text.pdf.security.CryptoStandard.CMS);
        //            stamper.Close();
        //        }
        //    }
        //}

        //public void Test()
        //{
        //    PdfDocument doc = new PdfDocument();

        //    // add a new page to the document  
        //    PdfPage page = doc.AddPage();

        //    // get image path   
        //    // the image will be used to display the digital signature over it  
        //    string imgFile = Server.MapPath("~/files/logo.png");

        //    // get certificate path  
        //    string certFile = Server.MapPath("~/files/selectpdf.pfx");

        //    // define a rendering result object  
        //    PdfRenderingResult result;

        //    // create image element from file path   
        //    PdfImageElement img = new PdfImageElement(0, 0, imgFile);
        //    result = page.Add(img);

        //    // get the #PKCS12 certificate from file  
        //    PdfDigitalCertificatesCollection certificates = PdfDigitalCertificatesStore.GetCertificates(certFile, "selectpdf");
        //    PdfDigitalCertificate certificate = certificates[0];

        //    // create the digital signature object  
        //    PdfDigitalSignatureElement signature =
        //        new PdfDigitalSignatureElement(result.PdfPageLastRectangle, certificate);
        //    signature.Reason = "SelectPdf";
        //    signature.ContactInfo = "SelectPdf";
        //    signature.Location = "SelectPdf";
        //    page.Add(signature);

        //    // save pdf document  
        //    doc.Save(Response, false, "Sample.pdf");

        //    // close pdf document  
        //    doc.Close();
        //}

        public void SignPdfFileWithKeyFromStore(string sourceDocument, string destinationPath, string certificateSubjectName, bool visible, float llx, float lly, float urx, float ury, int page)
        {
            System.Security.Cryptography.X509Certificates.X509Store store = new System.Security.Cryptography.X509Certificates.X509Store(
                System.Security.Cryptography.X509Certificates.StoreName.My,
                System.Security.Cryptography.X509Certificates.StoreLocation.LocalMachine
            );

            store.Open(System.Security.Cryptography.X509Certificates.OpenFlags.ReadOnly);

            IExternalSignature externalSignature = null;
            System.Security.Cryptography.X509Certificates.X509Certificate2 x509Certificate2 = null;

            foreach (System.Security.Cryptography.X509Certificates.X509Certificate2 certificate in store.Certificates)
            {
                if (certificate.SubjectName.Name == certificateSubjectName)
                {
                    externalSignature = new X509Certificate2Signature(certificate, "SHA-1");
                    x509Certificate2 = certificate;
                    break;
                }
            }

            if (externalSignature == null)
            {
                throw new Exception("Signature not found");
            }

            iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(sourceDocument);
            using (FileStream fout = new FileStream(destinationPath, FileMode.Create, FileAccess.ReadWrite))
            {
                using (iTextSharp.text.pdf.PdfStamper stamper = iTextSharp.text.pdf.PdfStamper.CreateSignature(reader, fout, '\0', null, true))
                {
                    iTextSharp.text.pdf.PdfSignatureAppearance appearance = stamper.SignatureAppearance;
                    if (visible)
                    {
                        BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
                        iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 9, 0, BaseColor.RED);

                        appearance.Layer2Font = new iTextSharp.text.Font(times);
                        appearance.Layer2Text = "Digitally signed by \nVASS ASSURANCE CORPORATION"
                            + "\nDate: " + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                        appearance.SetVisibleSignature(new iTextSharp.text.Rectangle(llx, lly, urx, ury), page, null);
                        // trigger creation of default layers contents
                        appearance.GetAppearance();

                        // Customize the layer contents
                        PdfTemplate layer0 = appearance.GetLayer(0);
                        Rectangle rect = appearance.Rect;
                        layer0.SetRGBColorStroke(255, 0, 0);
                        layer0.SetLineWidth(2);
                        layer0.Rectangle(rect.Left, rect.Bottom, rect.Width - 40, rect.Height);
                        layer0.Stroke();

                    }

                    iTextSharp.text.pdf.security.MakeSignature.SignDetached(appearance, externalSignature, new X509Certificate[] { Org.BouncyCastle.Security.DotNetUtilities.FromX509Certificate(x509Certificate2) }, null, null, null, 0, iTextSharp.text.pdf.security.CryptoStandard.CMS);
                    stamper.Close();
                }
            }
        }

        //public void SignImagePdfFile(string sourceDocument, string destinationPath,
        //    Stream privateKeyStream, string password, string imagePath)
        //{
        //    Pkcs12Store pk12 = new Pkcs12Store(privateKeyStream, password.ToCharArray());
        //    privateKeyStream.Dispose();
        //    string alias = null;
        //    foreach (string tAlias in pk12.Aliases)
        //    {
        //        if (pk12.IsKeyEntry(tAlias))
        //        {
        //            alias = tAlias;
        //            break;
        //        }
        //    }
        //    var pk = pk12.GetKey(alias).Key;
        //    iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(sourceDocument);
        //    using (FileStream fout = new FileStream(destinationPath, FileMode.Create, FileAccess.ReadWrite))
        //    {
        //        using (iTextSharp.text.pdf.PdfStamper stamper = iTextSharp.text.pdf.PdfStamper.CreateSignature(reader, fout, '\0'))
        //        {
        //            iTextSharp.text.pdf.PdfSignatureAppearance appearance = stamper.SignatureAppearance;

        //            System.Drawing.Image image = System.Drawing.Image.FromFile(imagePath);
        //            appearance.Image = iTextSharp.text.Image.GetInstance(image, System.Drawing.Imaging.ImageFormat.Png);
        //            appearance.Layer4Text = "";
        //            appearance.Layer2Text = "";
        //            appearance.SetVisibleSignature(new iTextSharp.text.Rectangle(340, 120, 460, 180), 1, "Icsi-Vendor");
        //            iTextSharp.text.pdf.security.IExternalSignature es = new iTextSharp.text.pdf.security.PrivateKeySignature(pk, "SHA-256");
        //            iTextSharp.text.pdf.security.MakeSignature.SignDetached(appearance, es, new X509Certificate[] { pk12.GetCertificate(alias).Certificate }, null, null, null, 0, iTextSharp.text.pdf.security.CryptoStandard.CMS);
        //            stamper.Close();
        //        }
        //    }
        //}
    }
}
