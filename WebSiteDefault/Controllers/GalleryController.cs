using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteDefault.Helpers;

namespace WebSiteDefault.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase image)
        {
            Bitmap imageSave = WorkImage.CreateImage(image, 800, 600);
            if (imageSave != null)
            {
                string path = Server.MapPath(ConfigurationManager.AppSettings["ImagePathGallery"]);
                string fileName = Guid.NewGuid().ToString() + ".jpg";
                imageSave.Save(path+fileName, ImageFormat.Jpeg);
            }

            return View();
        }
    }
}