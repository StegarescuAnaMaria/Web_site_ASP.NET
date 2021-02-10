using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Starset.Models
{
    public class FriendRequest
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public string InitiatorId { get; set; }
        [Required]
        public string TargetId { get; set; }
        [Required]
        public bool Approved { get; set; }
        [Required]
        public bool Waiting { get; set; }
    }
}