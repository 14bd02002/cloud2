﻿using mysuperwebSite2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace mysuperwebSite2.Controllers
{
    public class HomeController : Controller
    {

        private readonly IImageService _imageService = new ImageService();
        [HttpPost]
        public async Task<ActionResult> Upload(FormCollection formCollection)
        {
            var model = new UploadedImage();
            if (Request != null)
            {
                HttpPostedFileBase file = Request.Files["uploadedFile"];
                model = await _imageService.CreateUploadedImage(file);
            }
            return View("Index", model);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}