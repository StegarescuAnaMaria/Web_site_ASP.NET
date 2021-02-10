using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using Starset.Models;

namespace Starset.Controllers
{
    public class GalleryController : Controller
    {
        private ApplicationDbContext _context;
        public GalleryController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Gallery
        public ActionResult Index()
        {
            var images = _context.Images.ToList();
            if (User.IsInRole(RoleName.Admin))
                return View("Full", images);

            return View("Partial", images);
        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Add()
        {

            return View("ImageForm");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Image image)
        {
            string fileName = Path.GetFileNameWithoutExtension(image.ImageFile.FileName);

            string extension = Path.GetExtension(image.ImageFile.FileName);
            fileName = fileName + extension;
            image.Path = "~/ImagesGallery/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/ImagesGallery/"), fileName);
            image.ImageFile.SaveAs(fileName);
            if (image.Id == 0)
            {
                _context.Images.Add(image);
            }
            else
            {
                var imageInDb = _context.Images.ToList().Single(v => v.Id == image.Id);
                imageInDb.Path = image.Path;
                imageInDb.ImageFile = image.ImageFile;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Gallery");
        }

        [Authorize(Roles = RoleName.Admin)]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var image = _context.Images.ToList().SingleOrDefault(v => v.Id == id);
            _context.Images.Remove(image);
            _context.SaveChanges();

            return RedirectToAction("Index", "Gallery");
        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Edit(int id)
        {
            var image = _context.Images.ToList().SingleOrDefault(v => v.Id == id);

            return View("ImageForm", image);
        }
    }
}