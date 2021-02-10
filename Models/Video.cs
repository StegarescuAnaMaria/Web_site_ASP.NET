using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Starset.Models
{
    public class Video
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required,
        StringLength(100),
        Display(Name = "YouTube Video URL"),
        RegularExpression(@"http(?:s?):\/\/(?:www\.)?youtu(?:be\.com\/watch\?v=|\.be\/)([\w\-_]*)(&(amp;)?[\w\?‌​=]*)?", ErrorMessage ="This is not a valid YouTube URL")]
        public string Url { get; set; }

        [StringLength(50)]
        [RegularExpression(@"[a-z0-9A-Z]+")]
        public string VideoId { get; set; }

        [StringLength(100)]
        [RegularExpression(@"https://i\.ytimg\.com/vi/[A-Za-z0-9]+/maxresdefault\.jpg")]
        public string ImgLink { get; set; }

    }
}