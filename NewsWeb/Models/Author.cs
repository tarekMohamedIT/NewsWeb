using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsWeb.Models
{
    public class Author
    {
        public int AuthorID { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "The name is too short, it must be at least 2 characters.")]
        [MaxLength(20, ErrorMessage ="The name is too long, it must be at most 20 characters.")]
        [RegularExpression("([A-Za-z]|\\s)+", ErrorMessage = "This field is in incorrect format")]
        
        public string Name { get; set; }
    }
}