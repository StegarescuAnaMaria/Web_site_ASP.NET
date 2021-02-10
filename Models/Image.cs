using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Starset.Models
{
    public class Image
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(255)]
        [Display(Name = "Upload Image")]
        public string Path { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}