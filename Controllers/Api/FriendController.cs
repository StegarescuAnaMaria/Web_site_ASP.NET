using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Starset.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Starset.ViewModels;

namespace Starset.Controllers.Api
{
    public class FriendController : ApiController
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> userManager;

        private UserStore<ApplicationUser> userStore;

        public FriendController()
        {
            _context = new ApplicationDbContext();
            userStore = new UserStore<ApplicationUser>(_context);
            userManager = new UserManager<ApplicationUser>(userStore);
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET /api/users
        [HttpGet]
        public IEnumerable<FriendViewModel> GetFriends()
        {
            var userFriends = new List<FriendViewModel>();

            var currentUser = userManager.FindById(User.Identity.GetUserId());

            var friends1 = _context.Friends.ToList().FindAll(x=>x.Id1 == currentUser.Id);

            var friends2 = _context.Friends.ToList().FindAll(x => x.Id2 == currentUser.Id);


            //Get all the usernames
            foreach (var friend in friends1)
            {
                var user = userManager.FindById(friend.Id2);
                var r = new FriendViewModel
                {
                    Name = user.Name,
                    Id1 = currentUser.Id,
                    Id2 = user.Id
                };
                    userFriends.Add(r);
            }
            foreach (var friend in friends2)
            {
                var user = userManager.FindById(friend.Id1);
                var r = new FriendViewModel
                {
                    Name = user.Name,
                    Id2 = currentUser.Id,
                    Id1 = user.Id
                };
                userFriends.Add(r);
            }
            //Get all the Roles for our users
            foreach (var user in userFriends)
            {
                var roles = userManager.GetRoles(userStore.Users.First(s => s.Name == user.Name).Id);
                foreach (var role in roles)
                {
                    user.RoleName = roles.First(r => r == role);
                }
            }

            return userFriends;
        }
        [HttpPost]
        public IHttpActionResult AddFriend([FromUri]string initiatorId, [FromUri]string targetId)
        {
            var friend = new Friends
            {
                Id1 = initiatorId,
                Id2 = targetId
            };
            _context.Friends.Add(friend);

            var request = _context.FriendRequests.SingleOrDefault(c => c.InitiatorId == initiatorId && c.TargetId == targetId);

            if (request == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.FriendRequests.Remove(request);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteFriend([FromUri] string id1, [FromUri] string id2)
        {
            var friend = _context.Friends.SingleOrDefault(c => c.Id1 == id1 && c.Id2 == id2);

            if (friend == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Friends.Remove(friend);
            _context.SaveChanges();

            return Ok();
        }
    }
}
