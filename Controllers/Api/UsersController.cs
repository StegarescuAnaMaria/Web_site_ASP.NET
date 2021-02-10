using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Starset.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;


namespace Starset.Controllers.Api
{
    public class UsersController : ApiController
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> userManager;

        private UserStore<ApplicationUser> userStore;

        public UsersController()
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
        public IEnumerable<RolesViewModel> GetUsers()
        {
            var userRoles = new List<RolesViewModel>();

            var currentUser = userManager.FindById(User.Identity.GetUserId());

            var friends = _context.Friends.ToList();
            var friendRequests = _context.FriendRequests.ToList();
            

            //Get all the usernames
            foreach (var user in userStore.Users)
            {
                if (user != currentUser)
                {
                    var isFriend = friends.Exists(x => ((x.Id1 == user.Id) && (x.Id2 == currentUser.Id)) || ((x.Id2 == user.Id) && (x.Id1 == currentUser.Id)));
                    var requestSent = friendRequests.Exists(x => x.InitiatorId == currentUser.Id && x.TargetId == user.Id);
                    var requestReceived = friendRequests.Exists(x => x.InitiatorId == user.Id && x.TargetId == currentUser.Id);
                    var r = new RolesViewModel
                    {
                        UserTargetId=user.Id,
                        Name = user.Name,
                        UserInitiatorId = currentUser.Id
                    };
                    r.IsFriend = isFriend;
                    r.RequestSent = requestSent;
                    r.RequestReceived = requestReceived;
                    userRoles.Add(r);
                }    
            }
            //Get all the Roles for our users
            foreach (var user in userRoles)
            { 
                    var roles = userManager.GetRoles(userStore.Users.First(s => s.Name == user.Name).Id);
                foreach( var role in roles)
                {
                    user.RoleName = roles.First(r => r == role);
                }
            }

            return userRoles;
        }

    }
}
