using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsWeb.Models
{
    public class News
    {
        public int NewsID { get; set; }

        [Display(Name ="Title")]
        [Required]
        public string ArticleTitle { get; set; }

        [Display(Name ="Body")]
        [Required]
        public string ArticleBody { get; set; }

        [Display(Name ="Image url (Optional)")]
        public string ImageUrl { get; set; }

        [Display(Name = "Author name")]
        [Required]
        public int AuthorId { get; set; }

        public Author Author { get; set; }


        public DateTime PublicationDate { get; set; }

        public DateTime? CreationDate { get; set; }
    }
}