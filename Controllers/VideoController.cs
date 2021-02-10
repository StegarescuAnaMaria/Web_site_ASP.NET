using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Starset.Models;

namespace Starset.Controllers
{
    public class VideoController : Controller
    {
        private ApplicationDbContext _context;
        public VideoController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Video
        public ActionResult Index()
        {
            var videos = _context.Videos.ToList();
            if (User.IsInRole(RoleName.Admin))
                return View("Full", videos);

            return View("Partial", videos);
        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Add()
        {
            return View("VideoForm");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Video video)
        {
            var uri = new Uri(video.Url);

            // you can check host here => uri.Host <= "www.youtube.com"

            var query = HttpUtility.ParseQueryString(uri.Query);


            var videoId = string.Empty;

            if (query.AllKeys.Contains("v"))
            {
                videoId = query["v"];
            }
            else
            {
                videoId = uri.Segments.Last();
            }
            video.VideoId = videoId;
            video.Url = "https://www.youtube.com/watch?v=" + video.VideoId;
            video.ImgLink = "https://i.ytimg.com/vi/"+video.VideoId+"/maxresdefault.jpg";
            if (video.Id == 0)
            {
                _context.Videos.Add(video);
            }
            else
            {
                var videoInDb = _context.Videos.ToList().Single(v => v.Id == video.Id);
                videoInDb.Url = video.Url;
                videoInDb.VideoId = video.VideoId;
                videoInDb.ImgLink = video.ImgLink;
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index", "Video");
        }
        //[ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Admin)]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var video = _context.Videos.ToList().SingleOrDefault(v => v.Id == id);
            _context.Videos.Remove(video);
            _context.SaveChanges();

            return RedirectToAction("Index", "Video");
        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Edit(int id)
        {
            var video = _context.Videos.ToList().SingleOrDefault(v => v.Id == id);

            return View("VideoForm", video);
        }


    }
}