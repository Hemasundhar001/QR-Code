using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using qrcode.Models;
using QRCoder;
using static QRCoder.PayloadGenerator;

namespace qrcode.Controllers
{
    public class qrController : Controller
    {
       
        // GET: qr
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Class122());
        }
        [HttpPost]
        public ActionResult Index(Class122 class1)
        {
            try
            {


                Payload payload = new Url(class1.Qrcodetext);
                QRCodeGenerator codeGenerator = new QRCodeGenerator();
                QRCodeData qRCodeData = codeGenerator.CreateQrCode(payload);
                QRCoder.PngByteQRCode pngq = new PngByteQRCode(qRCodeData);
                var Qrbyte = pngq.GetGraphic(20);
                string base64Url = Convert.ToBase64String(Qrbyte);
                class1.Qrimageurl = "data:image/png;base64," + base64Url;
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View("Index", class1);
        }
    }
}