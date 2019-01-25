using NewsWeb.validators;
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

        [WithinAWeek(ErrorMessage = "The date must be between today and a week from today")]
        public DateTime PublicationDate { get; set; }

        public DateTime? CreationDate { get; set; }
    }
}