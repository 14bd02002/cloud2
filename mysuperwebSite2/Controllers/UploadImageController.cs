using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using mysuperwebSite2.Models;
using Microsoft.Azure; 
using Microsoft.WindowsAzure.Storage; 
using Microsoft.WindowsAzure.Storage.Blob; 



namespace mysuperwebSite2.Controllers
{
    public class UploadImageController : Controller
    {
        // GET: UploadImage
        public ActionResult UploadImage()
        {
            UploadedImage defaultViewModel = new UploadedImage();
            return View(defaultViewModel);

        }

        private readonly IImageService _imageService = new ImageService();

        [HttpPost]
        public async Task<ActionResult> Upload(FormCollection formCollection)
        {
            var model = new UploadedImage();
            if (Request != null)
            {
                HttpPostedFileBase file = Request.Files["uploadedFile"];
                model = await _imageService.CreateUploadedImage(file);
                await _imageService.AddImageToBlobStorageAsync(model);
            }

            return View("UploadImage", model);
        }
    }
}