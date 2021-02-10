using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Starset.Models
{
    public class RolesViewModel
    {
        public string Name { get; set; }
        public string UserTargetId { get; set; }
        public string RoleName { get; set; }
        public bool IsFriend { get; set; }
        public string UserInitiatorId { get; set; }
        public bool RequestSent { get; set; }
        public bool RequestReceived { get; set; }
    }
}