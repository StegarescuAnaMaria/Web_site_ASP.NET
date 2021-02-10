using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Starset.Models;

namespace Starset.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        //protected ApplicationDbContext ApplicationDbContext { get; set; }

        /// <summary>
        /// User manager - attached to application DB context
        /// </summary>
        private UserManager<ApplicationUser> UserManager { get; set; }
        public ChatController()
        {
            //this.ApplicationDbContext = new ApplicationDbContext();
            _context = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
            
        }

        private ApplicationDbContext _context;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Chat
        public ActionResult Index()
        {
            //var username = User.Identity.Name;
            var user = UserManager.FindById(User.Identity.GetUserId());

            var name = user.Name;
            if (name=="")
            {
                name = "unknown";
            }

            ViewBag.Name = name;

            return View();
        }

        public ActionResult ListUsers()
        {
            //var allUsers = _context.Users.ToList();

            return View();
        }

        public ActionResult ListFriends()
        {

            return View();
        }
        public ActionResult ListFriendRequests()
        {

            return View();
        }
    }
}