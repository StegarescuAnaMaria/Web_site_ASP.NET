using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Starset.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Starset.Models;

namespace Starset.Controllers.Api
{
    public class FriendRequestsController : ApiController
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> userManager;

        private UserStore<ApplicationUser> userStore;

        public FriendRequestsController()
        {
            _context = new ApplicationDbContext();
            userStore = new UserStore<ApplicationUser>(_context);
            userManager = new UserManager<ApplicationUser>(userStore);
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET : /api/friendrequests
        public IEnumerable<FriendRequestViewModel> GetFriendRequests()
        {
            var currentUser = userManager.FindById(User.Identity.GetUserId());
            var friendRequests = _context.FriendRequests.ToList().FindAll(x => (x.TargetId == currentUser.Id) && (x.Waiting == true));
            var friendRequestViewModels = new List<FriendRequestViewModel>();

            foreach (var request in friendRequests)
            {
                //var user = userManager.FindById(request.InitiatorId);

                var friendRequestViewModel = new FriendRequestViewModel
                {
                    InitiatorId = request.InitiatorId,
                    TargetId = request.TargetId,
                    InitiatorName = userManager.FindById(request.InitiatorId).Name
            };
                friendRequestViewModels.Add(friendRequestViewModel);
            }


            return friendRequestViewModels;
        }

        // DELETE : /api/friendrequests/1
        [HttpDelete]
        public IHttpActionResult DeleteFriendRequest([FromUri]string initiatorId, [FromUri]string targetId)
        {
            var request = _context.FriendRequests.SingleOrDefault(c => c.InitiatorId == initiatorId && c.TargetId == targetId);

            if (request == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.FriendRequests.Remove(request);
            _context.SaveChanges();

            return Ok();
        }

        // POST: /api/friendrequests/
        //[HttpPost]
        public IHttpActionResult PostFriendRequest([FromUri]string userInitiatorId, [FromUri]string userTargetId)
        {

        //var a = new Random(DateTime.Now.Ticks.GetHashCode());
            var friendRequest = new FriendRequest
            {
                InitiatorId = userInitiatorId,
                TargetId = userTargetId,
                Waiting = true,
                Approved = false
            };

            _context.FriendRequests.Add(friendRequest);
            _context.SaveChanges();

            //return Request.CreateResponse(HttpStatusCode.Created, "Friend request sent");
            return Created(new Uri(Url.Link("Default" , new { Id = friendRequest.Id.ToString() })), friendRequest);
        }

    }
}
