using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Starset.Models
{
    public class Friends
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Id1 { get; set; }
        [Required]
        public string Id2 { get; set; }
    }
}